using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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


namespace GluonCS
{
    public partial class Form1 : Form
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

        public Form1()
        {
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

            top = new GMapOverlay(_gMapControl, "top");
            _gMapControl.Overlays.Add(top);

            cross = new GMapMarkerCross(_gMapControl.Position);
            top.Markers.Add(cross);

            _gMapControl.OnMarkerEnter += new MarkerEnter(_gMapControl_OnMarkerEnter);
            _gMapControl.OnMarkerLeave += new MarkerLeave(_gMapControl_OnMarkerLeave);
            _gMapControl.MouseDown += new MouseEventHandler(_gMapControl_MouseDown);
            _gMapControl.MouseUp += new MouseEventHandler(_gMapControl_MouseUp);
            _gMapControl.MouseMove += new MouseEventHandler(_gMapControl_MouseMove);
            _gMapControl.OnMapZoomChanged += new MapZoomChanged(_gMapControl_OnMapZoomChanged);
            _gMapControl.OnCurrentPositionChanged += new CurrentPositionChanged(_gMapControl_OnCurrentPositionChanged);
            
            
            // uav layer
            model = new LiveUavLayer.LiveUavModel();
            controller = new LiveUavLayer.GMapController(_gMapControl, model);
            liveUavPanel1.SetModel(model);

            activeOverlay = controller.Overlay;

            _gMapControl.MapType = Properties.Settings.Default.MapType;
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
                    _gMapControl.Manager.Proxy = new WebProxy(add[0], port);
                }
                else
                {
                    _gMapControl.Manager.Proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, 80);
                }
            } else
                _gMapControl.Manager.Proxy = null; 
        }

        void _gMapControl_OnCurrentPositionChanged(PointLatLng point)
        {
            cross.Position = point;
        }

        void _gMapControl_OnMapZoomChanged()
        {
            cross.Position = _gMapControl.Position;
        }

        void _gMapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentMarker != null && e.Button == MouseButtons.Left)
            {
                if (currentMarker.Overlay == top/* || currentMarker.Overlay == activeOverlay*/)
                    currentMarker.Position = _gMapControl.FromLocalToLatLng(e.X, e.Y);
            }
        }

        void _gMapControl_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            //if (!_gMapControl.IsDragging && e.Button == System.Windows.Forms.MouseButtons.Right)
            //    _gmapContextStrip.Show(_gMapControl, e.X, e.Y);
        }

        void _gMapControl_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
        }

        void _gMapControl_OnMarkerLeave(GMapMarker item)
        {
            if (isMouseDown == false)
                currentMarker = null;
        }

        void _gMapControl_OnMarkerEnter(GMapMarker item)
        {
            currentMarker = item;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Closing serial...");
            if (model.Serial != null)
                model.Serial.Close();
            Console.WriteLine("done...");
            Properties.Settings.Default.MapPositionLatitude = _gMapControl.Position.Lat;
            Properties.Settings.Default.MapPositionLongitude = _gMapControl.Position.Lng;
            Properties.Settings.Default.MapZoomLevel = _gMapControl.Zoom;
            Properties.Settings.Default.Save();
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
                    Console.WriteLine("OK");
                    SerialCommunication_CSV c = new SerialCommunication_CSV();
                    c.Open(cf.SerialPort.PortName, cf.SerialPort.BaudRate);
                    model.Serial = c;
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

    }
}
