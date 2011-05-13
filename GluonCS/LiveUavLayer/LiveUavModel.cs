using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Communication.Frames.Configuration;
using Communication.Frames.Incoming;
using GMap.NET;
using System.IO.Ports;
using Communication;
using Amib.Threading;
using System.Threading;

namespace GluonCS.LiveUavLayer
{
    public class LiveUavModel
    {
        public delegate void ChangedEventHandler(object sender, EventArgs e);
        public event ChangedEventHandler NavigationLocalListChanged;
        public event ChangedEventHandler NavigationRemoteListChanged;
        public event ChangedEventHandler HomeChanged;
        public event ChangedEventHandler UavPositionChanged;
        public event ChangedEventHandler UavAttitudeChanged;
        public event ChangedEventHandler CommunicationLost;
        public event ChangedEventHandler CommunicationEstablished;

        private AutoResetEvent navigationLineReceived = new AutoResetEvent(false);  // used to wait for acknowledgement when a navigation instruction has been written

        public double Pitch = 0, Roll = 0, Yaw = 0;
        public PointLatLng UavPosition = new PointLatLng();
        public double Heading = 0, AltitudeGps = 0, SpeedMS = 0, AltitudeAglM = 0;
        public int NumberOfGpsSatellites = 0;
        public double BatteryVoltage = 0;
        public ControlInfo.FlightModes FlightMode = ControlInfo.FlightModes.AUTOPILOT;
        public bool CommunicationAlive = false;
        public int CurrentNavigationLine = 0;

        public LiveUavNavigationModel NavigationModel;
        public DateTime TakeoffTime = DateTime.Now;
        public DateTime BlockStartTime = DateTime.Now;
        private string lastBlockname = "";
        private bool hasTakenOff = false;

        private List<NavigationInstruction> navigation_local = new List<NavigationInstruction>(36);
        private List<NavigationInstruction> navigation_remote = new List<NavigationInstruction>(36);

        private UavNavigationSynchronize uavSynchronizer;

        private PointLatLng home;
        public PointLatLng Home { get { return home; } }

        private bool autoSync = true;
        public bool AutoSync
        {
            get { return autoSync; }
            set 
            { 
                autoSync = value;
                if (autoSync && uavSynchronizer != null)
                    uavSynchronizer.StartThread();
                else
                    uavSynchronizer.Pause();
            }
        }

        private SerialCommunication serial = null;
        public SerialCommunication Serial
        {
            set
            {
                serial = value;
                value.PressureTempCommunicationReceived += new SerialCommunication.ReceivePressureTempCommunicationFrame(connection_PressureTempCommunicationReceived);
                value.AttitudeCommunicationReceived += new SerialCommunication.ReceiveAttitudeCommunicationFrame(connection_AttitudeCommunicationReceived);
                value.NavigationInstructionCommunicationReceived += new SerialCommunication.ReceiveNavigationInstructionCommunicationFrame(connection_NavigationInstructionCommunicationReceived);
                value.GpsBasicCommunicationReceived += new SerialCommunication.ReceiveGpsBasicCommunicationFrame(connection_GpsBasicCommunicationReceived);
                value.ControlInfoCommunicationReceived += new SerialCommunication.ReceiveControlInfoCommunicationFrame(connection_ControlInfoCommunicationReceived);
                value.CommunicationEstablished += new SerialCommunication.EstablishedCommunication(connection_CommunicationEstablished);
                value.CommunicationLost += new SerialCommunication.LostCommunication(connection_CommunicationLost);
                uavSynchronizer = new UavNavigationSynchronize(this, serial);
                uavSynchronizer.StartThread();
            }
            get { return serial; }
        }


        public LiveUavModel()
        {
            for (int i = 0; i < navigation_local.Capacity; i++)
            {
                lock (navigation_local)
                {
                    navigation_local.Insert(i, new NavigationInstruction(i, NavigationInstruction.navigation_command.EMPTY, 0, 0, 0, 0));
                }
                lock (navigation_remote)
                {
                    navigation_remote.Insert(i, new NavigationInstruction(i, NavigationInstruction.navigation_command.EMPTY, 0, 0, 0, 0));
                }
            }
            NavigationModel = new LiveUavNavigationModel(this);
            home = new PointLatLng(Properties.Settings.Default.HomeLatitude, Properties.Settings.Default.HomeLongitude);
            UavPosition = new PointLatLng(Properties.Settings.Default.HomeLatitude, Properties.Settings.Default.HomeLongitude);
        }

        ~LiveUavModel()
        {
            try
            {
                if (uavSynchronizer != null)
                    uavSynchronizer.Pause();
            }
            finally
            {
                //base.Finalize();
            }
        }

        public double DistanceNextWaypoint()
        {
            if (!NavigationModel.Commands.ContainsKey(NavigationModel.Commands[CurrentNavigationLine].TargetWp))
                return 0.0;
            NavigationInstruction ni = NavigationModel.Commands[NavigationModel.Commands[CurrentNavigationLine].TargetWp].Instruction;
            double latitude_meter_per_degree = 6363057.32484 / 180.0 * Math.PI;
            double longitude_meter_per_degree = latitude_meter_per_degree * Math.Cos(home.Lat / 180.0 * Math.PI);

            if (ni.opcode == NavigationInstruction.navigation_command.FLY_TO_REL ||
                ni.opcode == NavigationInstruction.navigation_command.FROM_TO_REL ||
                ni.opcode == NavigationInstruction.navigation_command.CIRCLE_REL)
            {
                double clon = home.Lng + ni.y / longitude_meter_per_degree;
                double clat = home.Lat + ni.x / latitude_meter_per_degree;

                return Math.Sqrt((UavPosition.Lat - clat) * (UavPosition.Lat - clat) * latitude_meter_per_degree * latitude_meter_per_degree + (UavPosition.Lng - clon) * (UavPosition.Lng - clon) * longitude_meter_per_degree * longitude_meter_per_degree);
            }
            else
            {
                return Math.Sqrt((UavPosition.Lat - ni.x / Math.PI * 180.0) * (UavPosition.Lat - ni.x / Math.PI * 180.0) * latitude_meter_per_degree * latitude_meter_per_degree + (UavPosition.Lng - ni.y / Math.PI * 180.0) * (UavPosition.Lng - ni.y / Math.PI * 180.0) * longitude_meter_per_degree * longitude_meter_per_degree);
            }
        }

        public double TargetAltitudeAglM()  // taken from next waypoint
        {
            if (!NavigationModel.Commands.ContainsKey(NavigationModel.Commands[CurrentNavigationLine].TargetWp))
                return 0.0;
            NavigationInstruction ni = NavigationModel.Commands[NavigationModel.Commands[CurrentNavigationLine].TargetWp].Instruction;
            if (ni.opcode == NavigationInstruction.navigation_command.CLIMB)
                return ni.x;
            else if (ni.opcode == NavigationInstruction.navigation_command.CIRCLE_ABS ||
                     ni.opcode == NavigationInstruction.navigation_command.CIRCLE_REL)
                return (double)ni.b;
            else
                return (double)ni.a;

        }

        public double DistanceHome()
        {
            double latitude_meter_per_degree = 6363057.32484 / 180.0 * Math.PI;
            double longitude_meter_per_degree = latitude_meter_per_degree * Math.Cos(home.Lat / 180.0 * Math.PI);

            return Math.Sqrt((UavPosition.Lat - home.Lat) * (UavPosition.Lat - home.Lat) * latitude_meter_per_degree * latitude_meter_per_degree + (UavPosition.Lng - home.Lng) * (UavPosition.Lng - home.Lng) * longitude_meter_per_degree * longitude_meter_per_degree);
        }

        void connection_CommunicationLost()
        {
            CommunicationAlive = false;
            if (CommunicationLost != null)
                CommunicationLost(this, EventArgs.Empty);
        }

        void connection_CommunicationEstablished()
        {
            CommunicationAlive = true;
            if (CommunicationEstablished != null)
                CommunicationEstablished(this, EventArgs.Empty);
        }

        void connection_PressureTempCommunicationReceived(PressureTemp info)
        {
            //this.AltitudeAglM = info.Height;
        }

        void connection_NavigationInstructionCommunicationReceived(NavigationInstruction ni)
        {
            //if (navigationLineReceived.
            navigationLineReceived.Set();

            //Console.WriteLine("connection_NavigationInstructionCommunicationReceived ENTER");
            lock (navigation_remote)
            {
                ni.line--;
                if (navigation_remote.Count <= ni.line)
                    navigation_remote.Insert(ni.line, ni);
                else
                    navigation_remote[ni.line] = ni;

                if (NavigationRemoteListChanged != null)
                    NavigationRemoteListChanged(this, EventArgs.Empty);

                lock (navigation_local)
                {
                    if (navigation_local.Count <= ni.line)
                        navigation_local.Insert(ni.line, ni);
                    else
                        navigation_local[ni.line] = ni;
                }

                if (NavigationLocalListChanged != null)
                    NavigationLocalListChanged(this, EventArgs.Empty);
            }
            //Console.WriteLine("connection_NavigationInstructionCommunicationReceived LEAVE");
        }

        void connection_GpsBasicCommunicationReceived(GpsBasic gpsbasic)
        {
            //uavPath.Add(new PointLatLng(gpsbasic.Latitude / Math.PI * 180.0, gpsbasic.Longitude / Math.PI * 180.0));
            if (gpsbasic.Status == 2)
                NumberOfGpsSatellites = -1;
            else
                NumberOfGpsSatellites = gpsbasic.NumberOfSatellites;

            if (gpsbasic.NumberOfSatellites > 3)
                UavPosition = new PointLatLng(gpsbasic.Latitude / Math.PI * 180.0, gpsbasic.Longitude / Math.PI * 180.0);
            Heading = gpsbasic.Heading_deg;
            SpeedMS = gpsbasic.Speed_ms;
            
            if (UavPositionChanged != null)
                UavPositionChanged(this, EventArgs.Empty);

            if (!hasTakenOff && gpsbasic.Speed_ms > 1)
            {
                hasTakenOff = true;
                TakeoffTime = DateTime.Now;
            }
        }

        void connection_AttitudeCommunicationReceived(Attitude attitude)
        {
            Roll = attitude.RollDeg;
            Pitch = attitude.PitchDeg;
            Yaw = attitude.YawDeg;
            if (UavAttitudeChanged != null)
                UavAttitudeChanged(this, EventArgs.Empty);
        }

        void connection_ControlInfoCommunicationReceived(ControlInfo ci)
        {
            AltitudeAglM = ci.HeightAboveStartGround;
            BatteryVoltage = ci.BattVoltage;
            FlightMode = ci.FlightMode;
            CurrentNavigationLine = ci.CurrentNavigationLine;

            if (NavigationModel.Commands[CurrentNavigationLine].BlockName != lastBlockname)
            {
                lastBlockname = NavigationModel.Commands[CurrentNavigationLine].BlockName;
                BlockStartTime = DateTime.Now;
            }
        }

        public void SendToNavigationLine(int line)
        {
            serial.SendJumpToNavigationLine(line);
        }

        public void ReadNavigation()
        {
            if (serial != null)
                serial.SendNavigationRead();
        }


        public int MaxNumberOfNavigationInstructions()
        {
            return navigation_remote.Count;
        }
        public NavigationInstruction GetNavigationInstructionLocal(int i)
        {
            return new NavigationInstruction(navigation_local[i]);
        }
        public NavigationInstruction GetNavigationInstructionRemote(int i)
        {
            return new NavigationInstruction(navigation_remote[i]);
        }

        public void UpdateLocalNavigationInstruction(NavigationInstruction ni)
        {
            lock (navigation_local)
            {
                if (navigation_local.Count <= ni.line)
                    navigation_local.Insert(ni.line, ni);
                else
                    navigation_local[ni.line] = ni;
            }

            if (NavigationLocalListChanged != null)
                NavigationLocalListChanged(this, EventArgs.Empty);
        }

        public void BurnRemoteNavigation()
        {
            serial.SendNavigationBurn();
        }
        public bool WriteLocalNavigation()
        {
            bool ret = true;
            for (int i = 0; i < navigation_local.Count; i++)
            {
                NavigationInstruction ni = new NavigationInstruction(navigation_local[i]);
                if (ni != navigation_remote[ni.line])
                {
                    ni.line++;
                    serial.SendNavigationInstruction(ni);
                    if (!navigationLineReceived.WaitOne(2000))  // wait for a navigationlinereceived event before sending another update
                    {
                        Console.WriteLine("TIMEOUT");
                        ret = false;
                    }
                }
            }
            return ret;
        }
        public void ReloadNavigation()
        {
            serial.SendNavigationLoad();
            Thread.Sleep(100);
            serial.SendNavigationRead();
        }

        public bool IsNavigationSynchronized(int i)
        {
            if (navigation_local.Count > i)
                return navigation_local[i] == navigation_remote[i];
            else
                return false;
        }

        public void UpdateHome(GMap.NET.PointLatLng newposition)
        {
            home.Lat = newposition.Lat;
            home.Lng = newposition.Lng;
            if (HomeChanged != null)
                HomeChanged(this, EventArgs.Empty);
            if (NavigationLocalListChanged != null)
                NavigationLocalListChanged(this, EventArgs.Empty);
            Properties.Settings.Default.HomeLatitude = Home.Lat;
            Properties.Settings.Default.HomeLongitude = Home.Lng;
            Properties.Settings.Default.Save();
        }
    }


    class UavNavigationSynchronize
    {
        private LiveUavModel model;
        private SerialCommunication serial;
        private SmartThreadPool smartThreadPool;
        private int maxLineNumberReceived = -1;

        public UavNavigationSynchronize(LiveUavModel model, SerialCommunication serial)
        {
            this.model = model;
            this.serial = serial;
            serial.NavigationInstructionCommunicationReceived += new SerialCommunication.ReceiveNavigationInstructionCommunicationFrame(serial_NavigationInstructionCommunicationReceived);
        }

        void serial_NavigationInstructionCommunicationReceived(NavigationInstruction ni)
        {
            // OK, we received some information about the navigation we can start synchronizing
            if (ni.line > maxLineNumberReceived)
                maxLineNumberReceived = ni.line;
        }

        public void StartThread()
        {
            smartThreadPool = new SmartThreadPool();
            smartThreadPool.Name = "SynchronizeNavigation";
            IWorkItemResult wir =
                smartThreadPool.QueueWorkItem(new WorkItemCallback(SynchronizeNavigation), null);
            smartThreadPool.Start();
        }

        public void Pause()
        {
            try
            {
                smartThreadPool.Cancel();
                if (smartThreadPool != null && smartThreadPool.InUseThreads > 0)
                    smartThreadPool.Shutdown();
            }
            catch (ObjectDisposedException e)
            {

            }
        }

        private object SynchronizeNavigation(object x)
        {
            Console.WriteLine("Thread for synchro started");

            while (maxLineNumberReceived == -1 && model.Serial.IsOpen)
            {
                Console.WriteLine("Waiting for NI...");
                Thread.Sleep(1000);
            }

            while (/*!SmartThreadPool.IsWorkItemCanceled*/model.Serial.IsOpen)
            {
                for (int i = 0; i < model.MaxNumberOfNavigationInstructions() && i < maxLineNumberReceived; i++)
                {
                    if (!model.IsNavigationSynchronized(i))
                    {
                        if (serial != null)
                        {
                            Console.WriteLine("Sync " + i);
                            NavigationInstruction ni = new NavigationInstruction(model.GetNavigationInstructionLocal(i));
                            ni.line++;
                            serial.SendNavigationInstruction(ni);
                            Thread.Sleep(100);
                        }
                    }
                }
                Thread.Sleep(350);
                //Console.WriteLine("Waiting for NI...");
            }
            return null;
        }
    }
}
