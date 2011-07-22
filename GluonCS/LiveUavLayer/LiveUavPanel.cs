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

            updatePanel = new Timer();
            updatePanel.Interval = 200;
            updatePanel.Tick += new EventHandler(updatePanel_Tick);
            updatePanel.Enabled = true;


        }

        // Update the panel's labels. Not based on the events.
        void updatePanel_Tick(object sender, EventArgs e)
        {
            if (model.Serial != null && model.Serial.IsOpen)
                _btnConnect.Checked = true;

            if (model.NumberOfGpsSatellites >= 0)
            {
                _lblGpsSat.Text = "GPS: " + model.NumberOfGpsSatellites;
                if (model.NumberOfGpsSatellites > 5)
                    _lblGpsSat.BackColor = Color.Green;
                else if (model.NumberOfGpsSatellites > 3)
                    _lblGpsSat.BackColor = Color.Orange;
                else
                    _lblGpsSat.BackColor = Color.Red;
            }

            if (model.NumberOfGpsSatellites == -1)
            {
                _pbGps.Value = 0;
                _pbGps.Text = "Not found";
                _lblGpsSat.BackColor = Color.Red;
            }
            else
            {
                if (model.NumberOfGpsSatellites < 6)
                {
                    _pbGps.ForeColor = Color.Red;
                    _lblGpsSat.BackColor = Color.Red;
                }
                else
                {
                    _pbGps.ForeColor = Color.Green;
                    _lblGpsSat.BackColor = _lblGpsSat.Parent.BackColor;
                }
                _pbGps.Value = model.NumberOfGpsSatellites;
                _pbGps.Text = model.NumberOfGpsSatellites.ToString();
            }

            _pbBattery.Value = (int)(model.BatteryVoltage * 10.0);
            _pbBattery.Text = model.BatteryVoltage.ToString() + " V";
            _pbLink.Value = (int)Math.Max(0.0, Math.Min(100.0, 110.0 - model.SecondsConnectionLost() * 20.0));  // 5 seconds without connection = 0%
            if (model.SecondsConnectionLost() > 1)
                _lblLink.BackColor = Color.Red;
            else
                _lblLink.BackColor = _lblLink.Parent.BackColor;
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
                if (lvi.BackColor == Color.Yellow && lvi.Index != model.CurrentNavigationLine)
                    lvi.BackColor = _lv_navigation.Parent.BackColor;
            if (_lv_navigation.Items[model.CurrentNavigationLine].BackColor != Color.Yellow)
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


#region model events

        void model_UavPositionChanged(object sender, EventArgs e)
        {
            if (!updatePanel.Enabled)
            {
                updatePanel.Enabled = true;
            }
        }

        void model_UavAttitudeChanged(object sender, EventArgs e)
        {
            _artificialHorizon.pitch_angle = model.Pitch;
            _artificialHorizon.roll_angle = -model.Roll;
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
                if (_lv_navigation.ClientRectangle.Contains(_lv_navigation.Items[i].Bounds))
                {
                    topitem = i;
                    continue;
                }
            }

            _lv_navigation.Groups.Clear();
            lock (model.NavigationModel.Commands)
            {
                for (int i = 0; i < model.MaxNumberOfNavigationInstructions(); i++)
                {
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

            //_lv_navigation.TopItem = topitem;
            _lv_navigation.EnsureVisible(topitem);
            _lv_navigation.Items[topitem].EnsureVisible();
            Console.WriteLine("Ensure visible " + topitem);

            _panelStrip.Controls.Clear();
            int totalwidth = 0;
            foreach (KeyValuePair<string, int> block in model.NavigationModel.Blocks)
            {
                Button b = new Button();
                b.Text = block.Key;
                b.Click += new EventHandler(CommandButton_Click);
                totalwidth += b.Width;
                _panelStrip.Controls.Add(b);
            }
            _panelStrip.Height = (int)(Math.Ceiling((double)totalwidth / _panelStrip.Width)) * 30;
        }

        void CommandButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (model.NavigationModel.Blocks.ContainsKey(b.Text))
            {
                model.SendToNavigationLine(model.NavigationModel.Blocks[b.Text]);
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
            model.AutoSync = _btnAutoSync.Checked;
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
            Gluonpilot.GluonConfig gc = new Gluonpilot.GluonConfig(model.Serial);
            gc.Show();
        }


    }
}
