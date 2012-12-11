using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using GMap.NET.WindowsForms;
using GMap;
using GMap.NET;
using GluonCS.Markers;
using GMap.NET.WindowsForms.Markers;
using GluonCS.LiveUavLayer;
using Communication;
using System.IO.Ports;
using System.Net;
using Simulation;
using System.Threading;
using System.Globalization;
using Common;

namespace GluonCS
{
    public partial class GluonCSFormSwallow : Form
    {
        private LiveUavLayer.GMapController controller;
        private GMapOverlay top;
        private GMapOverlay activeOverlay;
        private GMapMarker currentMarker = null;
        private bool isMouseDown = false;
        private GMapMarker cross;
        private bool first_time_loading = true;
        LiveUavLayer.LiveUavModel model;

        private ToolStripRenderer m_currentToolStripRenderer;
        private BSE.Windows.Forms.ProfessionalColorTable m_currentProfessionalColorTable;

        private System.Speech.Synthesis.SpeechSynthesizer ss = new System.Speech.Synthesis.SpeechSynthesizer();
        private UavSpeech uavspeech;

        public GluonCSFormSwallow()
        {
            //SplashScreen splash = new SplashScreen();
            //splash.Show();


            Console.WriteLine("-> " + Properties.Settings.Default.Language);
            if (Properties.Settings.Default.Language == "Nederlands")
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("nl-NL");
            else if (Properties.Settings.Default.Language == "Deutsch")
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
            else if (Properties.Settings.Default.Language == "Vietnamese")
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            InitializeComponent();

            if (Properties.Settings.Default.UseSpeech)
                _btn_speaker.Image = imageList1.Images[1];
            else
                _btn_speaker.Image = imageList1.Images[0];


            /////////////
            System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom("BSE.Windows.Forms.dll");
            Type[] types = assembly.GetTypes();
            Type typeOfClass = null;

            typeOfClass = typeof(System.Windows.Forms.ToolStripProfessionalRenderer);
            foreach (Type type in types)
            {
                if ((type.IsClass == true) &&
                    (typeOfClass.IsAssignableFrom(type) == true))
                {
                    //this.m_cboToolStripRenderer.Items.Add(type);
                }
            }

            //this.m_cboToolStripRenderer.Items.Add(typeof(ToolStripProfessionalRenderer));
            //this.m_cboToolStripRenderer.SelectedItem = typeof(BSE.Windows.Forms.Office2007Renderer);
            ///////////////
  
            _gMapControl.Position = new PointLatLng(Properties.Settings.Default.MapPositionLatitude, Properties.Settings.Default.MapPositionLongitude);
            _gMapControl.Zoom = Properties.Settings.Default.MapZoomLevel;

            SetProxy();

            //top = new GMapOverlay(_gMapControl, "top");
            //_gMapControl.Overlays.Add(top);

            //cross = new GMapMarkerCross(_gMapControl.Position);
            //top.Markers.Add(cross);

            //_gMapControl.OnMarkerEnter += new MarkerEnter(_gMapControl_OnMarkerEnter);
            //_gMapControl.OnMarkerLeave += new MarkerLeave(_gMapControl_OnMarkerLeave);
            //_gMapControl.MouseDown += new MouseEventHandler(_gMapControl_MouseDown);
            //_gMapControl.MouseUp += new MouseEventHandler(_gMapControl_MouseUp);
           // _gMapControl.MouseMove += new MouseEventHandler(_gMapControl_MouseMove);
            //_gMapControl.OnMapZoomChanged += new MapZoomChanged(_gMapControl_OnMapZoomChanged);
            //_gMapControl.OnCurrentPositionChanged += new CurrentPositionChanged(_gMapControl_OnCurrentPositionChanged);
            
            

            // uav layer
            model = new LiveUavLayer.LiveUavModel();
            uavspeech = new UavSpeech(model);
            model.InformationMessageReceived += new LiveUavModel.TextReceivedEventHandler(model_InformationMessageReceived);
            controller = new LiveUavLayer.GMapController(_gMapControl, model);
            liveUavPanel1.SetModel(model);

            activeOverlay = controller.Overlay;

            if (Enum.IsDefined(typeof(MapType), Properties.Settings.Default.MapType))
                _gMapControl.MapType = (MapType)Enum.Parse(typeof(MapType), Properties.Settings.Default.MapType, true);


            //MessageBox.Show("Welcome to the evaluation version of the autopilot ground control station!", "Welcome!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            
            //splash.fade();
            //splash.Close();
        }

        void model_InformationMessageReceived(string s)
        {
            //this.BeginInvoke(new UpdateTextBox(UpdateLog), new object[] { s });
        }
        
        private delegate void UpdateTextBox(string line);
        private void UpdateLog(string line)
        {
            //_tbLog.AppendText("[" + DateTime.Now.ToString("hh:mm:ss.ff") + "]  ");
            //_tbLog.AppendText(line + "\r\n");
            //_tbLog.ScrollToCaret();
        }

            
        private void SetProxy()
        {
            if (Properties.Settings.Default.UseProxy)
            {
                int port = 80;
                string[] add = Properties.Settings.Default.ProxyAddress.Split(':');
                if (add.Length == 2)
                {
                    int.TryParse(add[1], out port);
                    _gMapControl.Manager.Proxy = new WebProxy("http://" + add[0] + ":" + port, false, null, new System.Net.NetworkCredential(Properties.Settings.Default.ProxyUsername, Properties.Settings.Default.ProxyPassword, ""));
                }
                else
                {
                    _gMapControl.Manager.Proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, 80);
                }
            } else
                _gMapControl.Manager.Proxy = null; 
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Closing serial...");
            if (model.Serial != null && model.Serial.IsOpen)
                model.Serial.Close();
            Console.WriteLine("done...");


            uavspeech.Stop();

            Properties.Settings.Default.MapPositionLatitude = _gMapControl.Position.Lat;
            Properties.Settings.Default.MapPositionLongitude = _gMapControl.Position.Lng;
            Properties.Settings.Default.MapZoomLevel = _gMapControl.Zoom;
            Properties.Settings.Default.Save();

            controller.Stop();
            liveUavPanel1.Stop();
            model.InformationMessageReceived -= new LiveUavModel.TextReceivedEventHandler(model_InformationMessageReceived);
            model.Stop();


            SmartThreadPoolSingleton.Stop();
        }


        private void Form1_Activated(object sender, EventArgs e)
        {
            if (/*model.Serial == null && */first_time_loading)
            {
                first_time_loading = false;
                ConnectForm cf = new ConnectForm();
                DialogResult r = cf.ShowDialog(this);
                if (r == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        if (cf.ReplayFilename != "")
                        {
                            SerialCommunication_replay scr = model.Replay(cf.ReplayFilename, cf.LogPath);
                            ReplayControl rc = new ReplayControl();
                            rc.SerialReplay = scr;
                            rc.Show();
                        }
                        else
                            model.Connect(cf.SerialPort.PortName, cf.SerialPort.BaudRate, cf.LogPath, cf.Simulation ? cf.FlightgearPath : "");
                        //c.NonParsedCommunicationReceived += new SerialCommunication.ReceiveNonParsedCommunication(c_NonParsedCommunicationReceived);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error connecting\r\n" + ex.ToString() + "\r\n" + ex.InnerException, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                else if (r == System.Windows.Forms.DialogResult.Cancel)
                {
                    Console.WriteLine("Cancel");
                }
                cf.Close();
            }
            
        }


        private void _btnZoomin_Click(object sender, EventArgs e)
        {
            _gMapControl.Zoom++;
        }

        private void _btnZoomout_Click(object sender, EventArgs e)
        {
            _gMapControl.Zoom--;
        }

        private void _btnOptions_Click(object sender, EventArgs e)
        {
            Setup s = new Setup(_gMapControl);
            if (s.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                SetProxy();
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetFocus();

        /** 
         *   Hotkeys
         */
        Keys[] previous_keys = new System.Windows.Forms.Keys[4];
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Control focused = null;
            IntPtr handle = GetFocus();
            if (handle != IntPtr.Zero)
            {
                focused = Control.FromHandle(handle);
                if (focused is TextBox)
                {
                    return false;
                }
                else
                {

                    previous_keys[3] = previous_keys[2];
                    previous_keys[2] = previous_keys[1];
                    previous_keys[1] = previous_keys[0];
                    previous_keys[0] = keyData;

                    if (previous_keys[3] == System.Windows.Forms.Keys.N &&
                        previous_keys[2] == System.Windows.Forms.Keys.F &&
                        previous_keys[1] == System.Windows.Forms.Keys.I &&
                        previous_keys[0] == System.Windows.Forms.Keys.G)
                    {
                        Gluonpilot.GluonConfig gc = new Gluonpilot.GluonConfig(model.Serial);
                        gc.Show();
                    }
                    if (previous_keys[3] == System.Windows.Forms.Keys.E &&
                        previous_keys[2] == System.Windows.Forms.Keys.T &&
                        previous_keys[1] == System.Windows.Forms.Keys.U &&
                        previous_keys[0] == System.Windows.Forms.Keys.P)
                    {
                        Setup s = new Setup(_gMapControl);
                        if (s.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                            SetProxy();
                    }
                    if (previous_keys[3] == System.Windows.Forms.Keys.N &&
                        previous_keys[2] == System.Windows.Forms.Keys.A &&
                        previous_keys[1] == System.Windows.Forms.Keys.V &&
                        previous_keys[0] == System.Windows.Forms.Keys.I)
                    {
                        liveUavPanel1.ShowNavi();
                    }


                    if (keyData == System.Windows.Forms.Keys.C)
                    {
                        model.CenterMapOnUav();
                        return true;
                    }
                    else if (keyData == System.Windows.Forms.Keys.I)
                    {
                        _btnZoomin_Click(null, EventArgs.Empty);
                        return true;
                    }
                    else if (keyData == System.Windows.Forms.Keys.O)
                    {
                        _btnZoomout_Click(null, EventArgs.Empty);
                        return true;
                    }
                    else
                    {
                        foreach (string block in model.NavigationModel.Blocks.Keys)
                        {
                            if (block.Substring(0, 1).ToLower() == keyData.ToString().ToLower())
                            {
                                model.SendToNavigationLine(model.NavigationModel.Blocks[block]);
                                return true;
                            }
                        }
                        return false;
                    }
                }
                
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void _btnSurveyOptions_Click(object sender, EventArgs e)
        {
            SurveyProperties sp = new SurveyProperties();
            sp.ShowDialog(this);
        }


        private void _btnGoto_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Goto this location:", "Goto", "Enter street, city and country", _gMapControl.Location.X + _gMapControl.Width / 2, _gMapControl.Location.Y + _gMapControl.Height / 2);
            _gMapControl.SetCurrentPositionByKeywords(input);
        }

        private void _btn_speaker_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.UseSpeech)
            {
                Properties.Settings.Default.UseSpeech = false;
                Properties.Settings.Default.Save();
                _btn_speaker.Image = imageList1.Images[0];
            }
            else
            {
                Properties.Settings.Default.UseSpeech = true;
                Properties.Settings.Default.Save();
                _btn_speaker.Image = imageList1.Images[1];
            }
        }
    }
}
