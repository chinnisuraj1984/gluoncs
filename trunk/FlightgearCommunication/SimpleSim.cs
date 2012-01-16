using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Communication;
using Amib.Threading;
using System.Net;
using System.Net.Sockets;
using System.Globalization;
using Common;


namespace Simulation
{
    public class SimpleSim
    {
        AirplaneModel model;

        private SerialCommunication serial;
        private SmartThreadPool smartThreadPool;
        private bool inSimulationMode = false;

        double elevator, aileron, motor;

        public SimpleSim(SerialCommunication serial, string path, LatLng home)
        {
            //serial.SendReboot();

            model = new AirplaneModel(home);

            this.serial = serial;
            smartThreadPool = new SmartThreadPool();
            IWorkItemResult wir =
                smartThreadPool.QueueWorkItem(new WorkItemCallback(PassCommands), null);

            smartThreadPool.Start();

            serial.ServosCommunicationReceived += new SerialCommunication.ReceiveServosCommunicationFrame(serial_ServosCommunicationReceived);
            serial.ControlInfoCommunicationReceived += new SerialCommunication.ReceiveControlInfoCommunicationFrame(serial_ControlInfoCommunicationReceived);
        }

        public void Stop()
        {
            smartThreadPool.Shutdown();
        }

        void serial_ControlInfoCommunicationReceived(Communication.Frames.Incoming.ControlInfo ci)
        {
            if (!inSimulationMode)
            {
                serial.SetSimulationOn();
                inSimulationMode = true;
            }
        }


        void serial_ServosCommunicationReceived(Communication.Frames.Incoming.Servos s)
        {
            elevator = 0;// -((double)s.Elevator - 1500.0) / 500.0 * 1;
            aileron = ((double)s.Aileron - 1500.0) / 500.0;
            Console.WriteLine("->" + aileron);
            motor = ((double)s.Motor - 1000.0);
        }

        static double pitch = 0, roll = 0, heading = 0, lat = 0, lng = 0, altitude = 0;
        static bool DataFromFgReceived = false;

        private object PassCommands(object x)
        {

            while (true)
            {
                System.Threading.Thread.Sleep(100);

                try
                {
                    model.ElevatorAngle = elevator;
                    model.AileronAngle = aileron;
                    model.Step(0.1);

                    serial.SendSimulationUpdate(model.Position.Lat / 180.0 * Math.PI,
                                                model.Position.Lng / 180.0 * Math.PI,
                                                model.Roll, model.Pitch, 100, model.Speed, model.Yaw);  // we start in-flight -> fake altitude 'take-off' position
                }
                catch (FormatException e)
                {
                }

                //string uit = motor.ToString(CultureInfo.InvariantCulture) + "\t" + aileron.ToString(CultureInfo.InvariantCulture) + "\t" + elevator.ToString(CultureInfo.InvariantCulture) + "\n";
                string uit = aileron.ToString(CultureInfo.InvariantCulture) + "\t" + elevator.ToString(CultureInfo.InvariantCulture) + "\n";
            }

            return null;
        }
    }
}
