using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Communication;
using Amib.Threading;
using System.Net;
using System.Net.Sockets;
using System.Globalization;

namespace Simulation
{
    public class FlightgearThread
    {
        private SerialCommunication serial;
        private SmartThreadPool smartThreadPool;

        private IPEndPoint localEp, remoteEp;
        UdpClient client = new UdpClient();
        UdpClient server = new UdpClient();

        double elevator, aileron, motor;

        public FlightgearThread(SerialCommunication serial, string path)
        {
            serial.SendReboot();

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = path + "\\bin\\Win32\\fgfs.exe";
            proc.StartInfo.Arguments = "--fg-root=\"" + path + "\\data\" --fg-scenery=\"" + path + "\\data\\Scenery;" + path + "\\scenery;" + path + "\\terrasync\"  --generic=socket,out,200,localhost,5000,udp,Gluonpilot --generic=socket,in,200,localhost,5001,udp,Gluonpilot  --geometry=400x300 --disable-random-objects --prop:/sim/rendering/random-vegetation=false --disable-ai-models --timeofday=noon --in-air --vc=18 --altitude=2000 --glideslope=0 --aircraft=Rascal110-JSBSim --lon=3.67064 --lat=50.85204";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = false;
            proc.StartInfo.WorkingDirectory = path + "\\bin\\";
            proc.Start();


            this.serial = serial;
            smartThreadPool = new SmartThreadPool();
            IWorkItemResult wir =
                smartThreadPool.QueueWorkItem(new WorkItemCallback(PassCommands), null);

            remoteEp = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            client.Client.Bind(remoteEp);
            localEp = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5001);
            server.Client.Connect(localEp);
            
            smartThreadPool.Start();

            serial.ServosCommunicationReceived += new SerialCommunication.ReceiveServosCommunicationFrame(serial_ServosCommunicationReceived);
        }


        void serial_ServosCommunicationReceived(Communication.Frames.Incoming.Servos s)
        {
            elevator = -((double)s.Elevator - 1500.0) / 500.0 * 1;
            aileron = ((double)s.Aileron - 1500.0) / 500.0 * 1;
            motor = ((double)s.Motor - 1000.0);
        }

        static double pitch = 0, roll = 0, heading = 0, lat = 0, lng = 0, altitude = 0;
        static bool DataFromFgReceived = false;

        private object PassCommands(object x)
        {

            while (true)
            {
                System.Threading.Thread.Sleep(200);

                byte[] bytes = client.Receive(ref remoteEp);
                string strData = Encoding.ASCII.GetString(bytes);//Encoding.Unicode.GetString(bytes);
                //Console.WriteLine(strData);

                string[] lines = strData.Split('\t');
                try
                {
                    if (lines.Length > 5 && double.Parse(lines[0], CultureInfo.InvariantCulture) > 0.1)  // first data is invalid
                    {
                        Console.WriteLine(strData);
                        lat = double.Parse(lines[1], CultureInfo.InvariantCulture);
                        lng = double.Parse(lines[2], CultureInfo.InvariantCulture);

                        if (lat > 60 * Math.PI / 180.0)
                            Console.WriteLine("no");
                        if (lat < 40 * Math.PI / 180.0)
                            Console.WriteLine("no");
                        if (lng > 60 / Math.PI * 180.0)
                            Console.WriteLine("no");

                        altitude = double.Parse(lines[3], CultureInfo.InvariantCulture);
                        heading = double.Parse(lines[4], CultureInfo.InvariantCulture) * 180.0 / 3.14159;
                        pitch = double.Parse(lines[5], CultureInfo.InvariantCulture);
                        roll = double.Parse(lines[6], CultureInfo.InvariantCulture);

                        if (!DataFromFgReceived)
                        {
                            serial.SendSimulationUpdate(lat, lng, roll, pitch, 0, 10, heading * Math.PI / 180.0);  // we start in-flight -> fake altitude 'take-off' position
                            DataFromFgReceived = true;
                            System.Threading.Thread.Sleep(20);
                            serial.SetSimulationOn();
                        } else
                            serial.SendSimulationUpdate(lat, lng, roll, pitch, altitude, 10, heading * Math.PI / 180.0);
                    }
                }
                catch (FormatException e)
                {
                }

                //string uit = motor.ToString(CultureInfo.InvariantCulture) + "\t" + aileron.ToString(CultureInfo.InvariantCulture) + "\t" + elevator.ToString(CultureInfo.InvariantCulture) + "\n";
                string uit = aileron.ToString(CultureInfo.InvariantCulture) + "\t" + elevator.ToString(CultureInfo.InvariantCulture) + "\n";
                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();

                server.Client.Send(encoding.GetBytes(uit), SocketFlags.None);
            }

            return null;
        }
    }
}
