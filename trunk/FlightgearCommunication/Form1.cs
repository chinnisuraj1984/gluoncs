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

namespace FlightgearCommunication
{
    public partial class Form1 : Form
    {
        StreamReader sr;
        UdpClient client = new UdpClient();
        IPEndPoint localEp;

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
            proc.StartInfo.Arguments = "--fg-root=\"D:\\Program Files\\FlightGear\\data\" --fg-scenery=\"D:\\Program Files\\FlightGear\\data\\Scenery;D:\\Program Files\\FlightGear\\scenery;D:\\Program Files\\FlightGear\\terrasync\" --generic=socket,out,40,localhost,5000,udp,insgns-gps";
            //proc.StartInfo.Arguments = "--fg-root=\"D:\\Program Files\\FlightGear\\data\" --fg-scenery=\"D:\\Program Files\\FlightGear\\data\\Scenery;D:\\Program Files\\FlightGear\\scenery;D:\\Program Files\\FlightGear\\terrasync\" --airport=KGNV --aircraft=c172p --httpd=5500 --generic=socket,out,40,localhost,5000,udp,OutputProtocol --generic=socket,in,45,localhost,5010,udp,InputProtocol";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = false;
            proc.StartInfo.WorkingDirectory = "D:\\Program Files\\FlightGear\\bin\\";
            proc.Start();


            localEp = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            client.Client.Bind(localEp);

        }

        private void _btnRead_Click(object sender, EventArgs e)
        {
            byte[] bytes = client.Receive(ref localEp);
            string strData = Encoding.ASCII.GetString(bytes);//Encoding.Unicode.GetString(bytes);
            Console.WriteLine(strData);
        }
    }
}
