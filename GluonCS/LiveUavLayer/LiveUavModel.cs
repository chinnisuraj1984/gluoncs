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
using FlightgearCommunication;

namespace GluonCS.LiveUavLayer
{
    public class LiveUavModel
    {
        public delegate void ChangedEventHandler(object sender, EventArgs e);
        public delegate void TextReceivedEventHandler(string s);
        public event TextReceivedEventHandler InformationMessageReceived;
        public event ChangedEventHandler NavigationLocalListChanged;
        public event ChangedEventHandler NavigationRemoteListChanged;
        public event ChangedEventHandler HomeChanged;
        public event ChangedEventHandler UavPositionChanged;
        public event ChangedEventHandler UavAttitudeChanged;
        public event ChangedEventHandler CommunicationLost;
        public event ChangedEventHandler CommunicationEstablished;
        public event ChangedEventHandler CenterOnUav;

        private AutoResetEvent navigationLineReceived = new AutoResetEvent(false);  // used to wait for acknowledgement when a navigation instruction has been written

        public double Pitch = 0, Roll = 0, Yaw = 0;
        public PointLatLng UavPosition = new PointLatLng();
        public double Heading = 0, AltitudeGps = 0, SpeedMS = 0, AltitudeAglM = 0;
        public int NumberOfGpsSatellites = 0;
        public double BatteryVoltage = 0;
        public ControlInfo.FlightModes FlightMode = ControlInfo.FlightModes.AUTOPILOT;
        public bool CommunicationAlive = false;
        public int CurrentNavigationLine = 0;
        public TimeSpan FlightTime = new TimeSpan(0, 0, 0), BlockTime = new TimeSpan(0, 0, 0);
        public int RcLink = 0;
        public int ThrottlePct = 0;

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

        private bool hasReceivedAGpsPosition = false;  // used to set initial gps point = home

        private bool autoSync = false;
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
            }
            get { return serial; }
        }

        public SerialCommunication_replay Replay(string filename, string logpath)
        {
            Serial = new SerialCommunication_replay(filename);

            SubscribeSerial(logpath);

            return (SerialCommunication_replay)Serial;
        }

        private void SubscribeSerial(string logpath)
        {
            if (logpath != "")
                Serial.LogToFilename = logpath;

            Serial.PressureTempCommunicationReceived += new SerialCommunication.ReceivePressureTempCommunicationFrame(connection_PressureTempCommunicationReceived);
            Serial.AttitudeCommunicationReceived += new SerialCommunication.ReceiveAttitudeCommunicationFrame(connection_AttitudeCommunicationReceived);
            Serial.NavigationInstructionCommunicationReceived += new SerialCommunication.ReceiveNavigationInstructionCommunicationFrame(connection_NavigationInstructionCommunicationReceived);
            Serial.GpsBasicCommunicationReceived += new SerialCommunication.ReceiveGpsBasicCommunicationFrame(connection_GpsBasicCommunicationReceived);
            Serial.ControlInfoCommunicationReceived += new SerialCommunication.ReceiveControlInfoCommunicationFrame(connection_ControlInfoCommunicationReceived);
            Serial.CommunicationEstablished += new SerialCommunication.EstablishedCommunication(connection_CommunicationEstablished);
            Serial.CommunicationLost += new SerialCommunication.LostCommunication(connection_CommunicationLost);
            Serial.NonParsedCommunicationReceived += new SerialCommunication.ReceiveNonParsedCommunication(connection_NonParsedCommunicationReceived);
            Serial.GyroAccProcCommunicationReceived += new SerialCommunication.ReceiveGyroAccProcCommunicationFrame(connection_GyroAccProcCommunicationReceived);
            uavSynchronizer = new UavNavigationSynchronize(this, serial);
            uavSynchronizer.StartThread();
        }

        DateTime last_msg;
        List<double> pl = new List<double>();
        List<double> ql = new List<double>();
        List<double> rl = new List<double>();
        void connection_GyroAccProcCommunicationReceived(GyroAccProcessed ga)
        {
            if (last_msg == null)
                last_msg = DateTime.Now;

            pl.Add(ga.GyroX);
            ql.Add(ga.GyroY);
            rl.Add(ga.GyroZ);
        }
        double p, q, r;
        private void CalcGyroAvg()
        {
            p = 0;
            foreach (double d in pl)
                p += d;
            p /= (double)pl.Count;
            pl.Clear();
            q = 0;
            foreach (double d in ql)
                q += d;
            q /= (double)ql.Count;
            ql.Clear();
            r = 0;
            foreach (double d in rl)
                r += d;
            r /= (double)rl.Count;
            rl.Clear();
        }
        int c = 0;
        double lastheading = 0;
        double last_altitude = 0;
        double[] old_Gps = new double[3];
        List<double> Winds = new List<double>();
        double yaw = 0;
        DateTime lastcall;
        private void CalcWind()
        {
            if (yaw == 0 && SpeedMS > 2)
                yaw = Heading / 180 * Math.PI;

            if (c++ % 4 == 0)
            {
                double[] Gps = {Math.Cos(Heading / 180.0 * Math.PI) * SpeedMS,
                                Math.Sin(Heading / 180.0 * Math.PI) * SpeedMS,
                                AltitudeAglM - last_altitude};
                CalcGyroAvg();

                double[] VelocityDiff = new double[3];
                for (int i = 0; i < old_Gps.Length; i++)
                    VelocityDiff[i] = Gps[i] - old_Gps[i];

                Roll /= 180 / Math.PI;
                double dyaw = (Math.Sin(Roll) * q  + Math.Cos(Roll) * r)/180*Math.PI;
                if( !double.IsNaN(dyaw))
                    yaw += dyaw;
                Console.WriteLine((DateTime.Now - lastcall).TotalSeconds);
                if (yaw < 0)
                    yaw += Math.PI * 2;
                if (yaw > Math.PI * 2)
                    yaw -= Math.PI * 2;

                double DirectionDiff = Math.Sqrt(Math.Sin(Roll) * q * Math.Sin(Roll) * q + Math.Cos(Roll) * r * Math.Cos(Roll) * r) / 180.0 * Math.PI;
                Roll *= 180 / Math.PI;
                if (Math.Abs(DirectionDiff) > 10.0 / 180 * Math.PI)
                {
                    double w = Math.Sqrt(VelocityDiff[0] * VelocityDiff[0] + VelocityDiff[1] * VelocityDiff[1] + VelocityDiff[2] * VelocityDiff[2]) / DirectionDiff;
                    //w -= SpeedMS;
                    Console.WriteLine("Velocity = " + w);
                    Winds.Add(w);
                }

                double theta = (Heading-lastheading) / 180.0 * Math.PI - DirectionDiff;

                double Wx = (Gps[0] + old_Gps[0] - (Math.Cos(theta) - Math.Sin(theta)))/2;

                lastheading = Heading/180.0*Math.PI;
                yaw = yaw * 0.9 + lastheading * 0.1;

                last_altitude = AltitudeAglM;
                for (int i = 0; i < old_Gps.Length; i++)
                    old_Gps[i] = Gps[i];

                lastcall = DateTime.Now;
            }
        }

        public void Connect(string port, int baudrate, string logpath, string flightgearpath)
        {
            SerialCommunication_CSV s = new SerialCommunication_CSV();
            Serial = s;

            SubscribeSerial(logpath);

            s.Open(port, baudrate);

            if (flightgearpath != "")
            {
                FlightgearThread fgt = new FlightgearThread(Serial, flightgearpath);
            }
        }

        public void Stop()
        {
            if (Serial != null)
            {
                Serial.PressureTempCommunicationReceived -= new SerialCommunication.ReceivePressureTempCommunicationFrame(connection_PressureTempCommunicationReceived);
                Serial.AttitudeCommunicationReceived -= new SerialCommunication.ReceiveAttitudeCommunicationFrame(connection_AttitudeCommunicationReceived);
                Serial.NavigationInstructionCommunicationReceived -= new SerialCommunication.ReceiveNavigationInstructionCommunicationFrame(connection_NavigationInstructionCommunicationReceived);
                Serial.GpsBasicCommunicationReceived -= new SerialCommunication.ReceiveGpsBasicCommunicationFrame(connection_GpsBasicCommunicationReceived);
                Serial.ControlInfoCommunicationReceived -= new SerialCommunication.ReceiveControlInfoCommunicationFrame(connection_ControlInfoCommunicationReceived);
                Serial.CommunicationEstablished -= new SerialCommunication.EstablishedCommunication(connection_CommunicationEstablished);
                Serial.CommunicationLost -= new SerialCommunication.LostCommunication(connection_CommunicationLost);
                Serial.NonParsedCommunicationReceived -= new SerialCommunication.ReceiveNonParsedCommunication(connection_NonParsedCommunicationReceived);
            }
            if (uavSynchronizer != null)
                uavSynchronizer.Pause();
            NavigationModel.Stop();
            Properties.Settings.Default.HomeLatitude = Home.Lat;
            Properties.Settings.Default.HomeLongitude = Home.Lng;
            Properties.Settings.Default.Save();
        }

        private void connection_NonParsedCommunicationReceived(string line)
        {
            if (InformationMessageReceived != null)
                InformationMessageReceived(line);
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

        public void CenterMapOnUav()
        {
            if (CenterOnUav != null)
                CenterOnUav(this, EventArgs.Empty);
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

        public double SecondsConnectionLost()
        {
            if (serial == null)
                return 999;
            else
                return serial.SecondsConnectionLost();
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
                NavigationInstruction ni2 = new NavigationInstruction(ni);
                ni2.line--;
                if (navigation_remote.Count <= ni2.line)
                    navigation_remote.Insert(ni2.line, ni2);
                else
                    navigation_remote[ni2.line] = ni2;

                if (NavigationRemoteListChanged != null)
                    NavigationRemoteListChanged(this, EventArgs.Empty);

                lock (navigation_local)
                {
                    if (navigation_local.Count <= ni2.line)
                        navigation_local.Insert(ni2.line, ni2);
                    else
                        navigation_local[ni2.line] = ni2;
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
            Heading = yaw*180/Math.PI;// gpsbasic.Heading_deg;
            SpeedMS = gpsbasic.Speed_ms;
            
            if (UavPositionChanged != null)
                UavPositionChanged(this, EventArgs.Empty);

            if (!hasTakenOff && gpsbasic.Speed_ms > 1)
            {
                hasTakenOff = true;
                TakeoffTime = DateTime.Now;
            }

            if (!hasReceivedAGpsPosition)
            {
                home = new PointLatLng(gpsbasic.Latitude / Math.PI * 180.0, gpsbasic.Longitude / Math.PI * 180.0);
                HomeChanged(this, EventArgs.Empty);
                hasReceivedAGpsPosition = true;
            }
            CalcWind();
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
                BlockStartTime = DateTime.Now; // remove me
            }
            FlightTime = new TimeSpan(0,0,ci.FlightTime);
            BlockTime = new TimeSpan(0, 0, ci.BlockTime);
            this.RcLink = ci.RcLink;
            ThrottlePct = ci.Throttle;
        }

        public void SendToNavigationLine(int line)
        {
            if (serial != null)
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
                    navigation_local[ni.line] = new NavigationInstruction(ni);
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
                if (ni.line < navigation_remote.Count && ni != navigation_remote[ni.line])
                {
                    ni.line++;
                    serial.SendNavigationInstruction(ni);
                    if (!navigationLineReceived.WaitOne(500))  // wait for a navigationlinereceived event before sending another update
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
        }

        void serial_NavigationInstructionCommunicationReceived(NavigationInstruction ni)
        {
            // OK, we received some information about the navigation we can start synchronizing
            if (ni.line > maxLineNumberReceived)
                maxLineNumberReceived = ni.line;
        }

        public void StartThread()
        {
            if (smartThreadPool == null)
                smartThreadPool = new SmartThreadPool();
            smartThreadPool.Name = "SynchronizeNavigation";
            IWorkItemResult wir =
                smartThreadPool.QueueWorkItem(new WorkItemCallback(SynchronizeNavigation), null);
            smartThreadPool.Start();
            serial.NavigationInstructionCommunicationReceived += new SerialCommunication.ReceiveNavigationInstructionCommunicationFrame(serial_NavigationInstructionCommunicationReceived);
        }

        public void Pause()
        {
            try
            {
                //smartThreadPool.Cancel();
                if (smartThreadPool != null)// && smartThreadPool.InUseThreads > 0)
                {
                    smartThreadPool.Shutdown();
                    smartThreadPool = null;
                }
                serial.NavigationInstructionCommunicationReceived -= new SerialCommunication.ReceiveNavigationInstructionCommunicationFrame(serial_NavigationInstructionCommunicationReceived);
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

            while (/*!SmartThreadPool.IsWorkItemCanceled*/model.Serial.IsOpen && model.AutoSync)
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
                            if (serial != null && serial.IsOpen)
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
