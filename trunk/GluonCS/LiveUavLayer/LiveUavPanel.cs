using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Communication.Frames.Incoming;
using Configuration;
using GluonCS.LiveUavLayer;
using GluonCS.Markers;
using System.IO;
using System.Xml.Serialization;
using Configuration.NavigationCommands;
using ZedGraph;

namespace GluonCS
{
    public partial class LiveUavPanel : LayerPropertiesPanel
    {
        private LiveUavModel model;
        private LineItem altitudeLineItem;
        private LineItem speedLineItem;
        private LineItem batteryVLineItem;
        private DateTime startDateTime = DateTime.Now;

        private Timer redrawNavigationTable;
        private Timer updatePanel;

        public LiveUavPanel()
            : base()
        {
            InitializeComponent();

            Control c = this;
            while (c.BackColor == Color.Transparent)
                c = c.Parent;
            _artificialHorizon.BackColor = c.BackColor;

            _zgAlt.GraphPane.IsFontsScaled = false;

            _zgAlt.GraphPane.Title.IsVisible = false;
            _zgAlt.GraphPane.YAxis.MajorGrid.IsVisible = true;
            _zgAlt.GraphPane.XAxis.Title.IsVisible = false;
            _zgAlt.AxisChange();
            _zgAlt.GraphPane.Legend.IsVisible = false;
            _zgAlt.GraphPane.IsFontsScaled = false;
            _zgAlt.GraphPane.XAxis.IsVisible = false;
            _zgAlt.GraphPane.YAxis.Title.Text = "AGL [m]";
            altitudeLineItem = _zgAlt.GraphPane.AddCurve("AGL", new PointPairList(), Color.Blue, SymbolType.None);

            _zgVel.GraphPane.Title.IsVisible = false;
            _zgVel.GraphPane.YAxis.MajorGrid.IsVisible = true;
            _zgVel.GraphPane.XAxis.Title.IsVisible = false;
            _zgVel.AxisChange();
            _zgVel.GraphPane.Legend.IsVisible = false;
            _zgVel.GraphPane.IsFontsScaled = false;
            _zgVel.GraphPane.XAxis.IsVisible = false;
            _zgVel.GraphPane.YAxis.Title.Text = "GS [km/h]";
            speedLineItem = _zgVel.GraphPane.AddCurve("GS", new PointPairList(), Color.Blue, SymbolType.None);

            _zgBatV.GraphPane.Title.IsVisible = false;
            _zgBatV.GraphPane.YAxis.MajorGrid.IsVisible = true;
            _zgBatV.GraphPane.XAxis.Title.IsVisible = false;
            _zgBatV.AxisChange();
            _zgBatV.GraphPane.Legend.IsVisible = false;
            _zgBatV.GraphPane.IsFontsScaled = false;
            _zgBatV.GraphPane.XAxis.IsVisible = false;
            _zgBatV.GraphPane.YAxis.Title.Text = "Bat [V]";
            batteryVLineItem = _zgBatV.GraphPane.AddCurve("Bat", new PointPairList(), Color.Blue, SymbolType.None);

            //zedGraphControl1.MasterPane.Add(_zgAlt.GraphPane.Clone());
            //zedGraphControl1.MasterPane.Add(_zgBatV.GraphPane.Clone());

            redrawNavigationTable = new Timer();
            redrawNavigationTable.Interval = 400;
            redrawNavigationTable.Tick += new EventHandler(redrawNavigationTable_Tick);
        }


        public void SetModel(LiveUavModel model)
        {
            this.model = model;

            for (int i = 1; i < model.MaxNumberOfNavigationInstructions(); i++)
            {
                ListViewItem lvi = new ListViewItem("" + i);
                lvi.Tag = model.GetNavigationInstructionLocal(i);
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem());
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem());
                _lv_navigation.Items.Add(lvi);
            }

            model.NavigationLocalListChanged += new LiveUavModel.ChangedEventHandler(model_NavigationLocalListChanged);
            model.NavigationRemoteListChanged += new LiveUavModel.ChangedEventHandler(model_NavigationRemoteListChanged);
            model.UavAttitudeChanged += new LiveUavModel.ChangedEventHandler(model_UavAttitudeChanged);
            model.UavPositionChanged += new LiveUavModel.ChangedEventHandler(model_UavPositionChanged);
            model.HomeChanged += new LiveUavModel.ChangedEventHandler(model_HomeChanged);
            updatePanel = new Timer();
            updatePanel.Interval = 200;
            updatePanel.Tick += new EventHandler(updatePanel_Tick);
            updatePanel.Enabled = true;

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            if (model != null)
            {
                model.NavigationLocalListChanged -= new LiveUavModel.ChangedEventHandler(model_NavigationLocalListChanged);
                model.NavigationRemoteListChanged -= new LiveUavModel.ChangedEventHandler(model_NavigationRemoteListChanged);
                model.UavAttitudeChanged -= new LiveUavModel.ChangedEventHandler(model_UavAttitudeChanged);
                model.UavPositionChanged -= new LiveUavModel.ChangedEventHandler(model_UavPositionChanged);
            }
        }


        // Update the panel's labels. Not based on the events.
        void updatePanel_Tick(object sender, EventArgs e)
        {
            try
            {
                if (model.Serial != null && model.Serial.IsOpen)
                {
                    _btnConnect.Checked = true;
                    _btnAutoSync.Enabled = true;
                    _btnNaviBurn.Enabled = true;
                    _btnNaviRead.Enabled = true;
                    _btnNaviReload.Enabled = true;
                    _btnNaviWrite.Enabled = true;
                }
                else
                {
                    _btnConnect.Checked = false;
                    _btnAutoSync.Enabled = false;
                    _btnNaviBurn.Enabled = false;
                    _btnNaviRead.Enabled = false;
                    _btnNaviReload.Enabled = false;
                    _btnNaviWrite.Enabled = false;
                }

                if (!model.CommunicationAlive)
                {
                    _lblFlightMode.Text = "! Connection lost !";
                    _lblFlightMode.BackColor = Color.Orange;
                }
                else
                {
                    if (model.FlightMode == ControlInfo.FlightModes.AUTOPILOT)
                    {
                        _lblFlightMode.Text = "Autopilot ON";
                        _lblFlightMode.BackColor = Color.LimeGreen;
                    }
                    else if (model.FlightMode == ControlInfo.FlightModes.STABILIZED)
                    {
                        _lblFlightMode.Text = "Stabilized manual\r\nRC mode";
                        _lblFlightMode.BackColor = Color.Yellow;
                    }
                    else if (model.FlightMode == ControlInfo.FlightModes.MANUAL)
                    {
                        _lblFlightMode.Text = "Autopilot OFF\r\nManual RC mode";
                        _lblFlightMode.BackColor = Color.Red;
                    }
                }

                if (model.NumberOfGpsSatellites >= 0)
                {
                    if (model.NumberOfGpsSatellites < 6)
                    {
                        _pbGps.ForeColor = Color.Red;
                        _lblGpsSat.BackColor = Color.Red;
                        _pbGps.Text = "Acquiring (" + model.NumberOfGpsSatellites + ")";
                    }
                    else
                    {
                        _pbGps.ForeColor = Color.LimeGreen;
                        _lblGpsSat.BackColor = _lblGpsSat.Parent.BackColor;
                        _pbGps.Text = "Locked (" + model.NumberOfGpsSatellites + ")";
                    }
                    if (model.NumberOfGpsSatellites > _pbGps.Maximum)
                        _pbGps.Maximum = model.NumberOfGpsSatellites;
                    _pbGps.Value = model.NumberOfGpsSatellites;
                }
                else //if (model.NumberOfGpsSatellites == -1)
                {
                    _pbGps.Value = 0;
                    _pbGps.Text = "Not found";
                    _lblGpsSat.BackColor = Color.Red;
                }


                //_pbBattery.Value = (int)(model.BatteryVoltage * 10.0);
                _pbBattery.Text = model.BatteryVoltage.ToString() + " V";
                if (model.SecondsConnectionLost() > 0.3)
                {
                    _pbLink.Text = model.SecondsConnectionLost().ToString("F0") + " s lost";
                    _pbLink.Value = (int)Math.Max(0.0, Math.Min(100.0, 110.0 - model.SecondsConnectionLost() * 20.0));  // 5 seconds without connection = 0%
                    if (model.SecondsConnectionLost() < 3)
                    {
                        _pbLink.ForeColor = Color.Yellow;
                    }
                    else
                    {
                        _pbLink.ForeColor = Color.Red;
                        _lblLink.BackColor = Color.Red;
                    }
                }
                else
                {
                    _pbLink.Text = "OK";
                    _pbLink.Value = 100;
                    _pbLink.ForeColor = Color.LimeGreen;
                    _lblLink.BackColor = _lblLink.Parent.BackColor;
                }


                _pbRcLink.Value = model.RcLink;
                _pbThrottle.Value = model.ThrottlePct;

                _lblAltitudeAgl.Text = model.AltitudeAglM + " m / " + model.TargetAltitudeAglM() + " m";
                _lblDistNextWp.Text = "Next WP: " + model.DistanceNextWaypoint().ToString("F0") + " m";
                _lblHomeDistance.Text = "Home: " + model.DistanceHome().ToString("F0") + " m";

                _lblBlockname.Text = model.NavigationModel.Commands[model.CurrentNavigationLine].BlockName;
                _lblFlightTime.Text = "Flight time: " + (int)(model.FlightTime.TotalMinutes) + ":" + model.FlightTime.Seconds;
                _lblTimeInBlock.Text = "Time in block: " + (int)(model.BlockTime.TotalMinutes) + ":" + model.BlockTime.Seconds;

                // update listview with current navigation line selection
                foreach (ListViewItem lvi in _lv_navigation.Items)
                {
                    if (lvi.BackColor == Color.Yellow && lvi.Index != model.CurrentNavigationLine)
                        lvi.BackColor = _lv_navigation.Parent.BackColor;
                }
                foreach (Control c in _panelStrip.Controls)
                {
                    if (c.Text.TrimStart('&') == model.NavigationModel.Commands[model.CurrentNavigationLine].BlockName &&
                        c.BackColor != Color.Yellow)
                        c.BackColor = Color.Yellow;
                    else if (c.BackColor != Color.Transparent && c.Text.TrimStart('&') != model.NavigationModel.Commands[model.CurrentNavigationLine].BlockName)
                        c.BackColor = Color.Transparent;
                }

                if (_lv_navigation.Items.Count > model.CurrentNavigationLine && _lv_navigation.Items[model.CurrentNavigationLine].BackColor != Color.Yellow)
                    _lv_navigation.Items[model.CurrentNavigationLine].BackColor = Color.Yellow;

                if (model.SpeedMS < 0.001)
                    _lblTimeToWp.Text = "Time to WP: oo s";
                else
                {
                    TimeSpan ts = new TimeSpan(0, 0, (int)(model.DistanceNextWaypoint() / model.SpeedMS));
                    _lblTimeToWp.Text = "Time to WP: " + (int)ts.TotalMinutes + ":" + ts.Seconds;
                }
                _lblSpeed.Text = ((int)(model.SpeedMS * 3.6)).ToString() + " km/h";

                // Update graphs
                double time = (DateTime.Now - startDateTime).TotalSeconds;
                altitudeLineItem.AddPoint(time, model.AltitudeAglM);
                Scale xScale = _zgAlt.GraphPane.XAxis.Scale;
                if (time > xScale.Max - xScale.MajorStep)
                {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = xScale.Max - 180; // 180 seconden
                }
                _zgAlt.AxisChange();
                _zgAlt.Invalidate();


                speedLineItem.AddPoint(time, model.SpeedMS * 3.6);
                xScale = _zgVel.GraphPane.XAxis.Scale;
                if (time > xScale.Max - xScale.MajorStep)
                {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = xScale.Max - 180; // 180 seconden
                }
                _zgVel.AxisChange();
                _zgVel.Invalidate();

                batteryVLineItem.AddPoint(time, model.BatteryVoltage);
                xScale = _zgBatV.GraphPane.XAxis.Scale;
                if (time > xScale.Max - xScale.MajorStep)
                {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = xScale.Max - 180; // 180 seconden
                }
                _zgBatV.AxisChange();
                _zgBatV.Invalidate();
            }
            catch (Exception ex)
            {
                ;
            }
        }


#region model events
        void model_HomeChanged(object sender, EventArgs e)
        {
            //_h
        }

        void model_UavPositionChanged(object sender, EventArgs e)
        {
            if (!updatePanel.Enabled)
            {
                updatePanel.Enabled = true;
            }
        }

        void model_UavAttitudeChanged(object sender, EventArgs e)
        {
            //_artificialHorizon.pitch_angle = model.Pitch;
            //_artificialHorizon.roll_angle = -model.Roll;
            if (_ahPanel.Controls[0] is ArtificialHorizon.ArtificialHorizon)
            {
                ArtificialHorizon.ArtificialHorizon ah = (ArtificialHorizon.ArtificialHorizon)_ahPanel.Controls[0];
                ah.pitch_angle = model.Pitch;
                ah.roll_angle = -model.Roll;
            }
            else
            {
                Artificial3DHorizon.AI3D ah = (Artificial3DHorizon.AI3D)_ahPanel.Controls[0];
                ah.Pitch = model.Pitch / 180.0 * Math.PI;
                ah.Roll = model.Roll / 180.0 * Math.PI;
            }

            if (!updatePanel.Enabled)
            {
                updatePanel.Enabled = true;
            }
        }

        void model_NavigationLocalListChanged(object sender, EventArgs e)
        {
            MethodInvoker m = delegate()
            {
                redrawNavigationTable.Stop();
                redrawNavigationTable.Start();
            };

            try
            {
                BeginInvoke(m);
            }
            catch
            {
            } 
        }

        void model_NavigationRemoteListChanged(object sender, EventArgs e)
        {
            MethodInvoker m = delegate()
            {
                redrawNavigationTable.Stop();
                redrawNavigationTable.Start();
            };

            try
            {
                BeginInvoke(m);
            }
            catch
            {
            } 
        }


        void redrawNavigationTable_Tick(object sender, EventArgs e)
        {
            RedrawNavigationtable();
            RedrawBlockButtons();
            redrawNavigationTable.Stop();
        }

        private void RedrawBlockButtons()   // from GUI thread
        {

        }

        private void RedrawNavigationtable()   // from GUI thread
        {
            Console.WriteLine("Redraw list");
            ListViewItem lvi;
            ListViewGroup lvg = new ListViewGroup("EMPTY");
            string lvg_name = "";
            int topitem = 0;
            for (int i = 0; i < _lv_navigation.Items.Count; i++)
            {
                //if (_lv_navigation.ClientRectangle.Contains(_lv_navigation.Items[i].Bounds))
                if (_lv_navigation.Items[i].Bounds.Top >= 15)
                {
                    topitem = i;
                    break;
                }
            }

            _lv_navigation.Groups.Clear();
            lock (model.NavigationModel.Commands)
            {
                for (int i = 0; i < model.MaxNumberOfNavigationInstructions(); i++)
                {
                    // Create groups(blocks)
                    if (lvg_name != model.NavigationModel.Commands[i].BlockName)
                    {
                        lvg_name = model.NavigationModel.Commands[i].BlockName;
                        lvg = new ListViewGroup(lvg_name);
                        _lv_navigation.Groups.Add(lvg);
                        //Console.WriteLine("Added group " + lvg_name + "(" + model.NavigationModel.Commands[i].BlockName + ")");
                    }

                    // Add items to list if there are not enough
                    while (_lv_navigation.Items.Count <= i)
                        _lv_navigation.Items.Add("" + (i)).SubItems.Add("");

                    if (model.GetNavigationInstructionLocal(i) != model.GetNavigationInstructionRemote(i))
                        _lv_navigation.Items[i].SubItems[1].Text = "* ";
                    else
                        _lv_navigation.Items[i].SubItems[1].Text = "";

                    lvi = _lv_navigation.Items[i];

                    if (i > 0)   // add indent
                    {
                        NavigationInstruction ni = model.GetNavigationInstructionRemote(i - 1);
                        if (ni.opcode == NavigationInstruction.navigation_command.IF_EQ ||
                            ni.opcode == NavigationInstruction.navigation_command.IF_GR ||
                            ni.opcode == NavigationInstruction.navigation_command.IF_NE ||
                            ni.opcode == NavigationInstruction.navigation_command.IF_SM)
                            lvi.SubItems[1].Text += "   ";
                    }
                    if (i+1 < model.MaxNumberOfNavigationInstructions())   // add indent
                    {
                        NavigationInstruction ni = model.GetNavigationInstructionRemote(i + 1);
                        if (ni.opcode == NavigationInstruction.navigation_command.UNTIL_EQ ||
                            ni.opcode == NavigationInstruction.navigation_command.UNTIL_GR ||
                            ni.opcode == NavigationInstruction.navigation_command.UNTIL_NE ||
                            ni.opcode == NavigationInstruction.navigation_command.UNTIL_SM)
                            lvi.SubItems[1].Text += "   ";
                    }

                    lvi.SubItems[1].Text +=
                        model.GetNavigationInstructionLocal(i).ToString();

                    lvi.Group = lvg;
                }
            }

            _lv_navigation.TopItem = _lv_navigation.Items[topitem];
            //_lv_navigation.EnsureVisible(topitem);
            _lv_navigation.Items[topitem].EnsureVisible();
            Console.WriteLine("Ensure visible " + topitem);

            _panelStrip.Controls.Clear();
            int totalwidth = 0;
            List<string> takenHotkeys = new List<string> { "i", "o", "c" };
            lock (model.NavigationModel.Commands)  // see navigationmodel
            {
                foreach (KeyValuePair<string, int> block in model.NavigationModel.Blocks)
                {
                    if (block.Key != "")
                    {
                        Button b = new Button();

                        // add hotkey to this block (fired from main form)
                        if (block.Key != "" && !takenHotkeys.Contains(block.Key.Substring(0, 1)))
                        {
                            b.Text = "&" + block.Key;
                            takenHotkeys.Add(block.Key.Substring(0, 1));
                        }
                        else
                            b.Text = block.Key;
                        b.Tag = block.Key;
                        b.Click += new EventHandler(CommandButton_Click);

                        totalwidth += b.Width;
                        _panelStrip.Controls.Add(b);
                    }
                }
            }
            if (_panelStrip.Controls.Count == 0)
            {
                System.Windows.Forms.Label l = new System.Windows.Forms.Label();
                l.Dock = System.Windows.Forms.DockStyle.Top;
                l.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                l.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                l.Location = new System.Drawing.Point(3, 0);
                l.Name = "label2";
                l.Size = new System.Drawing.Size(333, 35);
                l.TabIndex = 0;
                l.Text = "Block commands created in the Navigation list will be automatically \r\nadded as bu" +
                    "ttons to this strip.";
                l.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                _panelStrip.Controls.Add(l);
                _panelStrip.Height = l.Height;
            } 
            else
                _panelStrip.Height = (int)(Math.Ceiling((double)totalwidth / _panelStrip.Width)) * 30;
        }

        void CommandButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (model.NavigationModel.Blocks.ContainsKey((string)b.Tag))
            {
                model.SendToNavigationLine(model.NavigationModel.Blocks[(string)b.Tag]);
            }
            //throw new NotImplementedException();
        }
#endregion

        private void _lv_navigation_ItemActivate(object sender, EventArgs e)
        {
            NavigationInstructionEdit nie = new NavigationInstructionEdit(model.GetNavigationInstructionLocal(_lv_navigation.SelectedIndices[0]), model.Home.Lat, model.Home.Lng);
            //NavigationCommandEditor nce =
            //    new NavigationCommandEditor(model.GetNavigationInstructionLocal(_lv_navigation.SelectedIndices[0]));
            if (nie.ShowDialog(this) == DialogResult.OK)
            {
                model.UpdateLocalNavigationInstruction(new NavigationInstruction(nie.NavigationInstr));
                Console.WriteLine(model.GetNavigationInstructionLocal(0));
                Console.WriteLine(model.GetNavigationInstructionRemote(0));
            }

            //_lv_navigation.SelectedItems[0].SubItems[1].Text = "* " +
            //    ((NavigationInstruction)_lv_navigation.SelectedItems[0].Tag).ToString();
            //dirty_list.Add(((NavigationInstruction)_lv_navigation.SelectedItems[0].Tag).line);
            //model.UpdateLocalNavigationInstruction(nce.GetNavigationInstruction());
        }

        private void _nav_save_Click(object sender, EventArgs e)
        {
            /* Copy listview to array */
            NavigationInstruction[] list = new NavigationInstruction[model.MaxNumberOfNavigationInstructions()];
            for (int i = 0; i < model.MaxNumberOfNavigationInstructions(); i++)
            {
                list[i] = new NavigationInstruction(model.GetNavigationInstructionLocal(i));
            }

            System.Windows.Forms.SaveFileDialog file = new System.Windows.Forms.SaveFileDialog();
            file.DefaultExt = "gnf";
            file.Filter = "Gluon navigation file (*.gnf)|*.gnf|All files (*.*)|*.*";
            if (file.ShowDialog() == DialogResult.OK)
            {
                Stream stream = file.OpenFile();
                //BinaryFormatter bformatter = new BinaryFormatter();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(NavigationInstruction[]));

                Console.WriteLine("Writing model information");
                xmlSerializer.Serialize(stream, list);
                stream.Close();
            }
        }

        private void _nav_open_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog file = new System.Windows.Forms.OpenFileDialog();
            file.DefaultExt = "gnf";
            file.Filter = "Gluon navigation file (*.gnf)|*.gnf|All files (*.*)|*.*";
            if (file.ShowDialog() == DialogResult.OK)
            {
                Stream stream = File.OpenRead(file.FileName);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(NavigationInstruction[]));

                Console.WriteLine("Reading model information");

                NavigationInstruction[] list = (NavigationInstruction[])xmlSerializer.Deserialize(stream);
                for (int i = 0; i < model.MaxNumberOfNavigationInstructions(); i++)
                {
                    if (i < list.Length)
                    {
                        model.UpdateLocalNavigationInstruction(list[i]);
                    }
                }
                stream.Close();
            }

            // update edit control
            //_lv_navigation_SelectedIndexChanged(null, null);
        }

        private void _btn_up_Click(object sender, EventArgs e)
        {
            if (_lv_navigation.SelectedIndices.Count == 1)
            {
                if (_lv_navigation.SelectedIndices[0] >= 1)
                {
                    NavigationInstruction ni2 = new NavigationInstruction(model.GetNavigationInstructionLocal(_lv_navigation.SelectedIndices[0]));
                    ni2.line--;
                    NavigationInstruction ni1 = new NavigationInstruction(model.GetNavigationInstructionLocal(_lv_navigation.SelectedIndices[0] - 1));
                    ni1.line++;
                    model.UpdateLocalNavigationInstruction(ni1);
                    model.UpdateLocalNavigationInstruction(ni2);
                    _lv_navigation.Items[ni2.line].Selected = true;
                }
            }
        }

        private void _btn_down_Click(object sender, EventArgs e)
        {
            if (_lv_navigation.SelectedIndices.Count == 1)
            {
                if (_lv_navigation.SelectedIndices[0] < _lv_navigation.Items.Count-1)
                {
                    NavigationInstruction ni2 = new NavigationInstruction(model.GetNavigationInstructionLocal(_lv_navigation.SelectedIndices[0]));
                    ni2.line++;
                    NavigationInstruction ni1 = new NavigationInstruction(model.GetNavigationInstructionLocal(_lv_navigation.SelectedIndices[0] + 1));
                    ni1.line--;
                    model.UpdateLocalNavigationInstruction(ni1);
                    model.UpdateLocalNavigationInstruction(ni2);
                    _lv_navigation.Items[ni2.line].Selected = true;
                }
            }
        }

        private void _btnNaviRead_Click(object sender, EventArgs e)
        {
            model.ReadNavigation();
        }

        private void _btnNaviBurn_Click(object sender, EventArgs e)
        {
            model.BurnRemoteNavigation();
        }

        private void _btnAutoSync_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                model.AutoSync = _btnAutoSync.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't synchronize with data that has not yet been received. \r\nPlease read the navigation data from the module first or perform a Write operation.", "Error synchronizing");
                _btnAutoSync.Checked = false;
            }
        }

        private void _btnNaviReload_Click(object sender, EventArgs e)
        {
            model.ReloadNavigation();
        }

        private void _btnNaviWrite_Click(object sender, EventArgs e)
        {
            bool ret = model.WriteLocalNavigation();

            if (ret == false)
            {
                MessageBox.Show(this, "There was an error when writing the navigation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _btnConfig_Click(object sender, EventArgs e)
        {
            
        }

        private void _btnConnect_Click(object sender, EventArgs e)
        {
            if (_btnConnect.Checked)
            {
                if (model.Serial != null && model.Serial.IsOpen)
                {
                    if (MessageBox.Show("Are you sure you want to close the connection?", "Are you sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) == DialogResult.Yes)
                        model.Serial.Close();
                }
                else
                    MessageBox.Show("Please first connect to the gluonpilot", "Configuration not possible", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ConnectForm cf = new ConnectForm();
                DialogResult r = cf.ShowDialog(this);
                if (r == System.Windows.Forms.DialogResult.Yes)
                {
                    model.Connect(cf.SerialPort.PortName, cf.SerialPort.BaudRate, cf.LogPath, cf.Simulation ? cf.FlightgearPath : "");
                    model.Serial.ReadAllConfig();
                }
                cf.Close();
            }
        }

        private void _cockpitPanel_CloseClick(object sender, EventArgs e)
        {

        }

        private void _btnCenterUav_Click(object sender, EventArgs e)
        {
            model.CenterMapOnUav();
        }

        private void _ts2dah_Click(object sender, EventArgs e)
        {
            _ahPanel.Controls.Clear();
            ArtificialHorizon.ArtificialHorizon ah = new ArtificialHorizon.ArtificialHorizon();
            _ahPanel.Controls.Add(ah);
            ah.Dock = DockStyle.Fill;
            Control c = this;
            while (c.BackColor == Color.Transparent)
                c = c.Parent;
            ah.BackColor = c.BackColor;
            ah.CornersRadius = 20;
        }

        private void Load3dAhModel(string model)
        {
            if (_ahPanel.Controls[0] is Artificial3DHorizon.AI3D)
            {
                Artificial3DHorizon.AI3D ah_old = (Artificial3DHorizon.AI3D)_ahPanel.Controls[0];
                _ahPanel.Controls.Clear();
                ah_old.Stop();
                ah_old.Dispose();
                ah_old = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            } else
                _ahPanel.Controls.Clear();
            Artificial3DHorizon.AI3D ah = new Artificial3DHorizon.AI3D(model);
            _ahPanel.Controls.Add(ah);
            ah.Dock = DockStyle.Fill;
            Control c = this;
            while (c.BackColor == Color.Transparent)
                c = c.Parent;
            ah.BackColor = c.BackColor;
        }


        private void _tsFunjet_Click(object sender, EventArgs e)
        {
            Load3dAhModel("Models\\Funjet\\funjet.x");
        }

        private void _tsEasystar_Click(object sender, EventArgs e)
        {
            Load3dAhModel("Models\\Easystar\\easystar.x");
        }

        private void _tsPredator_Click(object sender, EventArgs e)
        {
            Load3dAhModel("Models\\Reaper\\MQ-9-Reaper.x");
        }

        private void _ts_basicconfig_Click(object sender, EventArgs e)
        {
            if (model.Serial != null && model.Serial.IsOpen)
            {
                Gluonpilot.EasyConfig ec = new Gluonpilot.EasyConfig(model.Serial);
                ec.Show();
                model.Serial.ReadAllConfig();
            }
        }

        private void _tbn_fullconfig_Click(object sender, EventArgs e)
        {
            if (model.Serial != null && model.Serial.IsOpen)
            {
                Gluonpilot.GluonConfig gc = new Gluonpilot.GluonConfig(model.Serial);
                gc.Show();
                model.Serial.ReadAllConfig();
            }
        }

        private void _btnAddBlock_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog file = new System.Windows.Forms.OpenFileDialog();
            file.Title = "Please open the gluon navigation/block file you wish to insert";
            file.DefaultExt = "gnf";
            file.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\NavigationBlocks";

            file.Filter = "Gluon navigation file (*.gnf)|*.gnf|All files (*.*)|*.*";
            if (file.ShowDialog() == DialogResult.OK)
            {
                Stream stream = File.OpenRead(file.FileName);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(NavigationInstruction[]));

                Console.WriteLine("Reading model information");

                NavigationInstruction[] list = (NavigationInstruction[])xmlSerializer.Deserialize(stream);
                int selected_index = SelectNewBlockLine(); //_lv_navigation.SelectedIndices.Count == 0 ? 0 : _lv_navigation.SelectedIndices[0];
                if (selected_index == -1)
                    return;

                if (MessageBox.Show("The block will be inserted at line nr " + (selected_index + 1).ToString() + ".", "Inserting block", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    for (int i = 0; i < list.Length && list[i].opcode != NavigationInstruction.navigation_command.EMPTY; i++)
                    {
                        NavigationInstruction ni = list[i];
                        ni.line += selected_index;
                        if (ni.opcode == NavigationInstruction.navigation_command.GOTO)
                            ni.a += selected_index;

                        if (i < model.MaxNumberOfNavigationInstructions())
                            model.UpdateLocalNavigationInstruction(list[i]);
                    }
                }
                stream.Close();
            }
        }

        private void _btnNewSurvey_Click(object sender, EventArgs e)
        {
            int line;
            if (model.NavigationModel.Blocks.ContainsKey("Survey"))
            {
                if (MessageBox.Show("There already is a Survey block. It will be cleared.", "New survey block", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    line = model.NavigationModel.Blocks["Survey"];
                else
                    return;
            }
            else if (model.NavigationModel.Blocks.ContainsKey("DoSurvey"))
            {
                if (MessageBox.Show("There already is a DoSurvey block. It will be cleared.", "New survey block", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    line = model.NavigationModel.Blocks["DoSurvey"];
                else
                    return;
            }
            else
                line = SelectNewBlockLine();

            if (line == -1)
                return;

            NavigationInstruction ni = new NavigationInstruction();
            ni.line = line;
            ni.StringToArgument("Survey");
            ni.opcode = NavigationInstruction.navigation_command.BLOCK;
            model.UpdateLocalNavigationInstruction(ni);
            for(int i = line+1; i < model.MaxNumberOfNavigationInstructions() && model.GetNavigationInstructionLocal(i).opcode != NavigationInstruction.navigation_command.BLOCK; i++)
            {
                NavigationInstruction emptyni = new NavigationInstruction();
                emptyni.line = i;
                emptyni.opcode = NavigationInstruction.navigation_command.EMPTY;
                model.UpdateLocalNavigationInstruction(emptyni);
            }
        }

        private int SelectNewBlockLine()
        {
            int selected_index = _lv_navigation.SelectedIndices.Count == 0 ? 0 : _lv_navigation.SelectedIndices[0];

            DialogResult r = MessageBox.Show("Do you want me to insert the block at the first empty line?", "Add new block", MessageBoxButtons.YesNoCancel);
            if (r == DialogResult.Yes)
            {
                for (int i = 0; i < _lv_navigation.Items.Count; i++)
                {
                    if (model.GetNavigationInstructionLocal(i).opcode == NavigationInstruction.navigation_command.EMPTY)
                        return i;
                }
                MessageBox.Show("Sorry, no empty position detected. Please select the line where you want the block to be inserted and try again.", "Add block");
            }
            else if (r == DialogResult.No)
            {
                if (MessageBox.Show("Inserting the new block at the selected position " + (selected_index + 1).ToString() + "", "Add new block", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    return selected_index;
                }
            }
            return -1;
        }

        private void _btnBuildSurvey_Click(object sender, EventArgs e)
        {
            model.GenerateSurveyLines();
        }
    }
}
