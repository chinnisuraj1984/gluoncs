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
using FlightgearCommunication;
using System.Threading;
using System.Globalization;

namespace GluonCS
{
    public partial class GluonCSForm : Form
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

        public GluonCSForm()
        {
            if (Properties.Settings.Default.Language == "Nederlands")
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("nl-NL");
            else if (Properties.Settings.Default.Language == "Deutsch")
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            InitializeComponent();

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
                    this.m_cboToolStripRenderer.Items.Add(type);
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
            model.InformationMessageReceived += new LiveUavModel.TextReceivedEventHandler(model_InformationMessageReceived);
            controller = new LiveUavLayer.GMapController(_gMapControl, model);
            liveUavPanel1.SetModel(model);

            uavspeech = new UavSpeech(model);

            activeOverlay = controller.Overlay;

            if (Enum.IsDefined(typeof(MapType), Properties.Settings.Default.MapType))
                _gMapControl.MapType = (MapType)Enum.Parse(typeof(MapType), Properties.Settings.Default.MapType, true);
        }

        void model_InformationMessageReceived(string s)
        {
            this.BeginInvoke(new UpdateTextBox(UpdateLog), new object[] { s });
        }
        
        private delegate void UpdateTextBox(string line);
        private void UpdateLog(string line)
        {
            //if (_cb_print_timestamp.Checked)
            _tbLog.AppendText("[" + DateTime.Now.ToString("hh:mm:ss.ff") + "]  ");
            _tbLog.AppendText(line + "\r\n");
            _tbLog.ScrollToCaret();
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

        //void _gMapControl_OnCurrentPositionChanged(PointLatLng point)
        //{
        //    cross.Position = point;
        //}

        //void _gMapControl_OnMapZoomChanged()
        //{
        //    cross.Position = _gMapControl.Position;
        //}

        //void _gMapControl_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (currentMarker != null && e.Button == MouseButtons.Left)
        //    {
        //        if (currentMarker.Overlay == top/* || currentMarker.Overlay == activeOverlay*/)
        //            currentMarker.Position = _gMapControl.FromLocalToLatLng(e.X, e.Y);
        //    }
        //}

        //void _gMapControl_MouseUp(object sender, MouseEventArgs e)
        //{
        //    isMouseDown = false;
        //    //if (!_gMapControl.IsDragging && e.Button == System.Windows.Forms.MouseButtons.Right)
        //    //    _gmapContextStrip.Show(_gMapControl, e.X, e.Y);
        //}

        //void _gMapControl_MouseDown(object sender, MouseEventArgs e)
        //{
        //    isMouseDown = true;
        //}

        //void _gMapControl_OnMarkerLeave(GMapMarker item)
        //{
        //    if (isMouseDown == false)
        //        currentMarker = null;
        //}

        //void _gMapControl_OnMarkerEnter(GMapMarker item)
        //{
        //    currentMarker = item;
        //}

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            uavspeech.Stop();
            Console.WriteLine("Closing serial...");
            if (model.Serial != null)
                model.Serial.Close();
            Console.WriteLine("done...");
            Properties.Settings.Default.MapPositionLatitude = _gMapControl.Position.Lat;
            Properties.Settings.Default.MapPositionLongitude = _gMapControl.Position.Lng;
            Properties.Settings.Default.MapZoomLevel = _gMapControl.Zoom;
            Properties.Settings.Default.Save();

            controller.Stop();
            model.InformationMessageReceived -= new LiveUavModel.TextReceivedEventHandler(model_InformationMessageReceived);
            model.Stop();
        }

        private void m_cboToolStripRenderer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type type = m_cboToolStripRenderer.SelectedItem as Type;
            if (type != null)
            {
                ToolStripProfessionalRenderer toolStripRenderer = Activator.CreateInstance(type) as ToolStripProfessionalRenderer;
                if (toolStripRenderer != null)
                {
                    if (toolStripRenderer.Equals(this.m_currentToolStripRenderer) == false)
                    {
                        //this.m_cboProfessionalColorTable.Items.Clear();
                        Type baseType = toolStripRenderer.ColorTable.GetType().BaseType;
                        if (baseType != null)
                        {
                            System.Reflection.Assembly assembly = toolStripRenderer.ColorTable.GetType().Assembly;
                            if (assembly != null)
                            {
                                Type[] types = assembly.GetTypes();

                                foreach (Type colorTableType in types)
                                {
                                    if ((colorTableType.IsClass == true) &&
                                        (baseType.IsAssignableFrom(colorTableType) == true) &&
                                        (baseType != colorTableType) &&
                                        (baseType.BaseType == typeof(BSE.Windows.Forms.ProfessionalColorTable)))
                                    {
                                        //this.m_cboProfessionalColorTable.Items.Add(colorTableType);
                                    }
                                }
                            }
                        }

                        BSE.Windows.Forms.ProfessionalColorTable colorTable = toolStripRenderer.ColorTable as BSE.Windows.Forms.ProfessionalColorTable;
                        if (colorTable != null)
                        {
                            BSE.Windows.Forms.PanelColors panelColorTable = colorTable.PanelColorTable;
                            if (panelColorTable != null)
                            {
                                BSE.Windows.Forms.PanelSettingsManager.SetPanelProperties(
                                    this.Controls,
                                    panelColorTable);
                            }
                        }
                        else
                        {
                            BSE.Windows.Forms.PanelColors panelColorTable = new BSE.Windows.Forms.PanelColors();
                            BSE.Windows.Forms.PanelSettingsManager.SetPanelProperties(
                                    this.Controls,
                                    panelColorTable);
                        }

                        this.m_currentToolStripRenderer = toolStripRenderer;
                        ToolStripManager.Renderer = this.m_currentToolStripRenderer;
                    }
                }
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (model.Serial == null && first_time_loading)
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
                        MessageBox.Show("Error connecting", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
    }
}
