using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Globalization;

namespace Simulation
{
    public partial class Form1 : Form
    {
        StreamReader sr;
        UdpClient client = new UdpClient();
        UdpClient server = new UdpClient();
        IPEndPoint localEp;
        IPEndPoint localEp2;

        double pitch, roll, heading, lat, lng, altitude;

        public Form1()
        {
            InitializeComponent();
        }

        private void _btnStart_Click(object sender, EventArgs e)
        {
//            System.Diagnostics.Process.Start("D:\\Program Files\\FlightGear\\bin\\Win32\\fgfs --httpd=5500 --generic=socket,out,40,localhost,5000,udp,OutputProtocol --generic=socket,in,45,localhost,5010,udp,InputProtocol");
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "D:\\Program Files\\FlightGear\\bin\\Win32\\fgfs.exe";
            //proc.StartInfo.Arguments = "--fg-root=\"D:\\Program Files\\FlightGear\\data\" --fg-scenery=\"D:\\Program Files\\FlightGear\\data\\Scenery;D:\\Program Files\\FlightGear\\scenery;D:\\Program Files\\FlightGear\\terrasync\" --airport=KGNV --aircraft=c172p --httpd=5500 --generic=socket,out,40,localhost,5000,udp,OutputProtocol --generic=socket,in,45,localhost,5010,udp,InputProtocol";
            proc.StartInfo.Arguments = "--fg-root=\"D:\\Program Files\\FlightGear\\data\" --fg-scenery=\"D:\\Program Files\\FlightGear\\data\\Scenery;D:\\Program Files\\FlightGear\\scenery;D:\\Program Files\\FlightGear\\terrasync\"  --generic=socket,out,10,localhost,5000,udp,Gluonpilot --generic=socket,in,10,localhost,5001,udp,Gluonpilot  --geometry=400x300 --disable-random-objects --prop:/sim/rendering/random-vegetation=false --disable-ai-models --timeofday=noon --in-air --vc=18 --altitude=900 --glideslope=0 --aircraft=Malolo1 --pro=/sim/traffic-manager/enabled=false --lon=3.67064 --lat=50.85204";
            //proc.StartInfo.Arguments = "--fg-root=\"D:\\Program Files\\FlightGear\\data\" --fg-scenery=\"D:\\Program Files\\FlightGear\\data\\Scenery;D:\\Program Files\\FlightGear\\scenery;D:\\Program Files\\FlightGear\\terrasync\" --airport=KGNV --aircraft=c172p --httpd=5500 --generic=socket,out,40,localhost,5000,udp,OutputProtocol --generic=socket,in,45,localhost,5010,udp,InputProtocol";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = false;
            proc.StartInfo.WorkingDirectory = "D:\\Program Files\\FlightGear\\bin\\";
            proc.Start();


            localEp = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            client.Client.Bind(localEp);
            localEp2 = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5001);
            server.Client.Connect(localEp2);
            
            //server.Client.Bind(localEp);
            timer1.Enabled = true;
        }

        private void _btnRead_Click(object sender, EventArgs e)
        {
            byte[] bytes = client.Receive(ref localEp);
            string strData = Encoding.ASCII.GetString(bytes);//Encoding.Unicode.GetString(bytes);
            Console.WriteLine(strData);

            string[] lines = strData.Split('\t');

            lat = double.Parse(lines[1], CultureInfo.InvariantCulture);
            lng = double.Parse(lines[2], CultureInfo.InvariantCulture);
            altitude = double.Parse(lines[3], CultureInfo.InvariantCulture);

            heading = double.Parse(lines[4], CultureInfo.InvariantCulture);
            pitch = double.Parse(lines[5], CultureInfo.InvariantCulture);
            roll = double.Parse(lines[6], CultureInfo.InvariantCulture);

            artificialHorizon1.pitch_angle = pitch * 180 / Math.PI;
            artificialHorizon1.roll_angle = roll * 180 / Math.PI;

            string uit = "1\t" + ((((double)hScrollBar.Value) - 50.0) / 50.0).ToString(CultureInfo.InvariantCulture) + "\t" + ((((double)vScrollBar.Value) - 50.0) / 50.0).ToString(CultureInfo.InvariantCulture) + "\n";
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            
            //client.
            //client.Client.
            //client.Client.Listen(1);
            //client.Client.Accept();
            server.Client.Send(encoding.GetBytes(uit), SocketFlags.None);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _btnRead_Click(null, EventArgs.Empty);
        }
    }
}
