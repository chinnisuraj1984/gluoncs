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

namespace GluonCS
{
    public partial class LiveUavPanel : LayerPropertiesPanel
    {
        private LiveUavModel model;

        public LiveUavPanel()
            : base()
        {
            InitializeComponent();

            Control c = this;
            while (c.BackColor == Color.Transparent)
                c = c.Parent;
            _artificialHorizon.BackColor = c.BackColor;

            _zgAlt.GraphPane.IsFontsScaled = false;
        }

        public void SetModel(LiveUavModel model)
        {
            this.model = model;

            for (int i = 0; i < model.MaxNumberOfNavigationInstructions(); i++)
            {
                ListViewItem lvi = new ListViewItem("" + i);
                lvi.Tag = model.GetNavigationInstructionLocal(i);
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem());
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem());
                _lv_navigation.Items.Add(lvi);
            }

            model.NavigationLocalListChanged += new LiveUavModel.ChangedEventHandler(model_NavigationLocalListChanged);
            model.UavAttitudeChanged += new LiveUavModel.ChangedEventHandler(model_UavAttitudeChanged);
            model.UavPositionChanged += new LiveUavModel.ChangedEventHandler(model_UavPositionChanged);
        }

#region model events

        void model_UavPositionChanged(object sender, EventArgs e)
        {
            MethodInvoker m = delegate()
            {
                if (model.NumberOfGpsSatellites >= 0)
                {
                    _lblGpsSat.Text = "GPS: " + model.NumberOfGpsSatellites;
                    if (model.NumberOfGpsSatellites > 5)
                        _lblGpsSat.ForeColor = Color.Green;
                    else if (model.NumberOfGpsSatellites > 3)
                        _lblGpsSat.ForeColor = Color.Orange;
                    else
                        _lblGpsSat.ForeColor = Color.Red;
                }
                _lblSpeed.Text = ((int)(model.SpeedMS * 3.6)).ToString() + " km/h";
                _lblGpsSat.Text = "GPS: " + model.NumberOfGpsSatellites;
            };

            try
            {
                BeginInvoke(m);
            }
            catch
            {
            } 
        }

        void model_UavAttitudeChanged(object sender, EventArgs e)
        {
            _artificialHorizon.pitch_angle = model.Pitch;
            _artificialHorizon.roll_angle = -model.Roll;
        }

        void model_NavigationLocalListChanged(object sender, EventArgs e)
        {
            MethodInvoker m = delegate()
            {
                for (int i = 0; i < model.MaxNumberOfNavigationInstructions(); i++)
                {
                    // Add items to list if there are not enough
                    while(_lv_navigation.Items.Count <= i)
                        _lv_navigation.Items.Add(""+(i+1)).SubItems.Add("");

                    if (model.GetNavigationInstructionLocal(i) != model.GetNavigationInstructionRemote(i))
                        _lv_navigation.Items[i].SubItems[1].Text = "* ";
                    else
                        _lv_navigation.Items[i].SubItems[1].Text = "";

                    _lv_navigation.Items[i].SubItems[1].Text +=
                        model.GetNavigationInstructionLocal(i).ToString();
                }
            };

            try
            {
                BeginInvoke(m);
            }
            catch
            {
            } 
        }
#endregion

        private void _lv_navigation_ItemActivate(object sender, EventArgs e)
        {
            NavigationCommandEditor nce =
                new NavigationCommandEditor(model.GetNavigationInstructionLocal(_lv_navigation.SelectedIndices[0]));
            nce.ShowDialog(this);
            model.UpdateLocalNavigationInstruction(nce.GetNavigationInstruction());


            //_lv_navigation.SelectedItems[0].SubItems[1].Text = "* " +
            //    ((NavigationInstruction)_lv_navigation.SelectedItems[0].Tag).ToString();
            //dirty_list.Add(((NavigationInstruction)_lv_navigation.SelectedItems[0].Tag).line);
            //model.UpdateNavigationInstruction(nce.GetNavigationInstruction());
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

        private void button1_Click(object sender, EventArgs e)
        {
            ToolStripProfessionalRenderer renderer = ToolStripManager.Renderer as ToolStripProfessionalRenderer;
            if (renderer != null)
            {
                BSE.Windows.Forms.ProfessionalColorTable colorTable = renderer.ColorTable as BSE.Windows.Forms.ProfessionalColorTable;
                if (colorTable != null)
                {
                    colorTable.UseSystemColors = !colorTable.UseSystemColors;
                    renderer = Activator.CreateInstance(renderer.GetType(), new object[] { colorTable }) as ToolStripProfessionalRenderer;

                    BSE.Windows.Forms.PanelColors panelColors = colorTable.PanelColorTable;
                    if (panelColors != null)
                    {
                        panelColors.UseSystemColors = colorTable.UseSystemColors;
                        BSE.Windows.Forms.PanelSettingsManager.SetPanelProperties(
                            this.Controls,
                            panelColors);
                    }

                    ToolStripManager.Renderer = renderer;
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

    }
}
