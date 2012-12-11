using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32.DesktopWindowManager;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using GluonMapper;


namespace MapperWizard
{
    public partial class Wizard : Form
    {
        // complete image paths
        private HashSet<string> SetOfImagePaths = new HashSet<string>();
        // trigger -> milliseconds -> filename
        private Dictionary<int, Dictionary<int, string>> triggered_pictures = new Dictionary<int, Dictionary<int, string>>();
        // trigger -> milliseconds -> DataRow
        private Dictionary<int, Dictionary<int, DataRow>> trigger_ticks_map;
        // filename -> TaggedData
        Dictionary<string, TaggedData> image_tags;
        private DataSet autopilot_log;

        private string project_folder;

        private Thread GenerationThread;

        private string pix4dfile;

        public Wizard()
        {
            InitializeComponent();
        }

        private void _tb_project_name_TextChanged(object sender, EventArgs e)
        {
            _tb_project_folder.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Gluonpilot\\" + _tb_project_name.Text.Replace(' ', '_');
            if (_tb_project_name.Text.Length > 0)
                wizardPage1.AllowNext = true;
            else
                wizardPage1.AllowNext = false;
        }

#region Images
        private void _btn_add_images_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string file in ofd.FileNames)
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.Exists)
                    {
                        if (fi.Extension.ToUpper().Contains("JPG") || fi.Extension.ToUpper().Contains("JPEG"))
                        {
                            SetOfImagePaths.Add(file);
                        }
                    }
                    else
                    {
                        //throw new Exception("File " + file + " does not exist");
                    }
                }
                UpdateImagesListInfo();
            }
        }

        private void UpdateImagesListInfo()
        {
            long total_size = 0;
            _lb_images.Items.Clear();

            foreach (string file in SetOfImagePaths)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.Exists)
                {
                    total_size += fi.Length;
                    _lb_images.Items.Add(file);
                }
            }

            if (SetOfImagePaths.Count >= 3)
            {
                _lbl_select_images.Text = "" + SetOfImagePaths.Count + " images in " + (total_size / 1024) + " kB.";
                _lbl_select_images.ForeColor = Color.Black;
                wizardPage2.AllowNext = true;
            }
            else
            {
                _lbl_select_images.Text = "Please select at least 3 images";
                _lbl_select_images.ForeColor = Color.Red;
                                    wizardPage2.AllowNext = false;
            }
        }

        private void _btn_images_clear_Click(object sender, EventArgs e)
        {
            SetOfImagePaths.Clear();
            UpdateImagesListInfo();
        }

        private void _btn_add_folder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    foreach (string f in Directory.GetFiles(fbd.SelectedPath))
                    {
                        FileInfo fi = new FileInfo(f);
                        if (fi.Exists)
                        {
                            if (fi.Extension.ToUpper().Contains("JPG") || fi.Extension.ToUpper().Contains("JPEG"))
                                SetOfImagePaths.Add(f);
                        }
                    }
                    UpdateImagesListInfo();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error while processing pictures", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
#endregion

#region Cameralog

        private void wizardPage_camera_log_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            foreach (string filepath in SetOfImagePaths)
            {
                FileInfo fi = new FileInfo(filepath);
                string number = fi.Name.ToUpper().Replace(".JPG", "").Replace(".JPEG", "").Replace("IMG_", "");
                FileInfo guesslog = new FileInfo(fi.DirectoryName + "\\..\\..\\CHDK\\LOGS\\log" + number + ".txt");
                if (guesslog.Exists)
                {
                    _tb_camera_log.Text = guesslog.FullName;
                    break;
                }
            }
        }

        private void _btn_browse_camera_log_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Camera log files|*.txt|All files|*.*";
            if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                _tb_camera_log.Text = ofd.FileName;
            }
        }

        

        private void _tb_camera_log_TextChanged(object sender, EventArgs e)
        {
            int match_number = 0;
            HashSet<string> all_images = new HashSet<string>();

            try
            {
                ProcessCameraLogFile(_tb_camera_log.Text);
             
                // make hashset of all images in the camera log
                foreach (int i in triggered_pictures.Keys)
                {
                    all_images.UnionWith(triggered_pictures[i].Values);
                }
                foreach (string s in SetOfImagePaths)
                {
                    FileInfo fi = new FileInfo(s);
                    string name = fi.Name;
                    if (all_images.Contains(name))
                        match_number++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There has been an error processing the log file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _lbl_cameralog_info.Text = "" + all_images.Count.ToString() + " pictures in " + triggered_pictures.Keys.Count.ToString() + " triggers";
            _lbl_cameralog_info.Text += "\n" + (int)((double)match_number / (double)SetOfImagePaths.Count * 100.0) + "% matched with the selected image files (" + match_number + "/" + SetOfImagePaths.Count + ")";

            if (match_number == 0)
            {
                _lbl_camera_log_error.Text = "No images from the camera log are matched with the selected images";
                wizardPage_camera_log.AllowNext = false;
            }
            else
            {
                _lbl_camera_log_error.Text = "";
                wizardPage_camera_log.AllowNext = true;
            }
        }

        private void ProcessCameraLogFile(string logfile)
        {
            // trigger -> milliseconds -> filename
            triggered_pictures = new Dictionary<int, Dictionary<int, string>>();

            FileInfo fi = new FileInfo(logfile);
            if (fi.Exists)
            {
                if (fi.Length < 1000 * 1000)
                {
                    string[] lines = File.ReadAllLines(logfile);
                    if (!lines[0].StartsWith("Trigger ") && !(lines[0].Split(';').Length >= 2))
                        throw new Exception("Invalid log file");
                    else
                    {
                        int current_trigger = 1;
                        int count_pic = 0;
                        int first_trigger = -1;
                        foreach (string logline in lines)
                        {
                            if (logline.StartsWith("Trigger "))
                            {
                                current_trigger = int.Parse(logline.Remove(0, 8));
                                if (first_trigger == -1)
                                    first_trigger = current_trigger;
                                triggered_pictures.Add(current_trigger - first_trigger + 1, new Dictionary<int, string>());
                            }
                            else if (logline.StartsWith("IMG") || logline.Split(';').Length >= 2)
                            {
                                string[] parts = logline.Split(';');
                                if (parts.Length == 2) // old
                                {
                                    //string filename = "IMG_" + int.Parse(parts[0].Split(' ')[1]).ToString("0000") + ".JPG";
                                    string filename = "IMG_" + int.Parse(parts[0].Split('_')[1].Replace(" ", "").Substring(0, 4)).ToString("0000") + ".JPG";
                                    int ms = int.Parse(parts[1]);
                                    triggered_pictures[current_trigger].Add(ms, filename);
                                    System.Console.WriteLine("->" + current_trigger + " @ " + ms + "ms = " + filename);
                                    count_pic++;
                                }
                                else if (parts.Length == 3)
                                {
                                    current_trigger = int.Parse(parts[0]);
                                    if (first_trigger == -1)
                                        first_trigger = current_trigger;
                                    current_trigger = current_trigger - first_trigger + 1;
                                    if (!triggered_pictures.Keys.Contains(current_trigger))
                                        triggered_pictures.Add(current_trigger, new Dictionary<int, string>());
                                    string pic_filename = parts[1];
                                    int ms = int.Parse(parts[2]);
                                    triggered_pictures[current_trigger].Add(ms, pic_filename);
                                    System.Console.WriteLine("->" + current_trigger + " @ " + ms + "ms = " + pic_filename);
                                }
                                count_pic++;
                            }
                        }


                        if (count_pic < 3)
                            throw new Exception("The number of pictures is too low to continue (" + count_pic + ")");
                        else
                        {
                            
                        }
                    }
                }
                else
                {
                    throw new Exception("File size too long to be a log file");
                }
            }
            else
            {
                throw new Exception("File " + logfile + " does not exist");
            }
        }

#endregion

#region Gluonpilot log
        private void ProcessDatalogFile(string filename)
        {
            autopilot_log = new DataSet();
            autopilot_log.ReadXml(filename, XmlReadMode.Auto);

            double datalog_frequency = LogFrequency(autopilot_log);
            System.Console.WriteLine("" + datalog_frequency);

            trigger_ticks_map = new Dictionary<int, Dictionary<int, DataRow>>();

            string last_time = autopilot_log.Tables[0].Rows[0]["Time"].ToString();
            int time_occurence = 0;
            int last_trigger = 0;
            int ticks_since_trigger = 0;
            foreach (DataRow dr in autopilot_log.Tables[0].Rows)
            {
                int trigger = 0;
                int.TryParse(dr["ServoTrigger"].ToString(), out trigger);

                // try to keep track of time;
                if (last_time != dr["Time"].ToString())
                {
                    time_occurence = 0;
                    last_time = dr["Time"].ToString();
                }
                else
                    time_occurence++;

                // add new key to dictionary when we encounter a new trigger
                if (trigger != last_trigger)
                {
                    last_trigger = trigger;
                    time_occurence = 0;
                    trigger_ticks_map.Add(trigger, new Dictionary<int, DataRow>());
                    ticks_since_trigger = 0;
                }
                else
                    ticks_since_trigger++;

                if (trigger != 0)
                {
                    trigger_ticks_map[trigger].Add(ticks_since_trigger, dr);
                }
            }
        }

        private double LogFrequency(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count < 5)
                throw new Exception("Log file is too small");

            string initial_time = ds.Tables[0].Rows[0]["Time"].ToString();
            string time = string.Empty;
            int freq = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["Time"].ToString() == initial_time)
                    continue;
                else if (time == string.Empty)
                {
                    time = dr["Time"].ToString();
                    freq++;
                }
                else if (dr["Time"].ToString() != time)
                {
                    break;
                }
                else
                {
                    freq++;
                }
            }
            return 1.0 / (double)freq;
        }


        private void _btn_browse_gluonlog_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Autopilot log files|*.xml|All files|*.*";
            if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                _tb_gluonpilot_logfile.Text = ofd.FileName;
            }
        }

        private void _tb_gluonpilot_logfile_TextChanged(object sender, EventArgs e)
        {
            ProcessDatalogFile(_tb_gluonpilot_logfile.Text);

            _lbl_autopilot_log_info.Text = "" + trigger_ticks_map.Keys.Count + " triggers found";

            if (trigger_ticks_map.Keys.Count < triggered_pictures.Keys.Count)
            {
                _lbl_autopilot_log_info.Text += "\n\nThis does not match with the number or triggers in the camera log file (" + triggered_pictures.Keys.Count + ")!";
                wizardPage4.AllowNext = true;
            }

            if (trigger_ticks_map.Keys.Count == 0)
            {
                wizardPage4.AllowNext = false;
                _lbl_autopilot_log_info.Text = "No triggers found!";
            }
            else
                wizardPage4.AllowNext = true;
        }

#endregion

#region GeoReference

        private void GeoReferenceAllImages()
        {
            int triggers = triggered_pictures.Keys.Count;
            image_tags = new Dictionary<string, TaggedData>();

            for (int i = 1; i <= triggers; i++) 
            {
                if (!triggered_pictures.ContainsKey(i))
                    continue;
                foreach (int key in triggered_pictures[i].Keys)  // milliseconds
                {
                    int tick_key;
                    string filename;
                    try
                    {
                        tick_key = (int)Math.Round((double)key / 1000.0 * 4.0);
                        filename = triggered_pictures[i][key].ToUpper();

                        //if (trigger_ticks_map[i][tick_key].
                        image_tags.Add(filename, new TaggedData(trigger_ticks_map[i][tick_key]["Latitude"].ToString(), trigger_ticks_map[i][tick_key]["Longitude"].ToString(), trigger_ticks_map[i][tick_key]["HeightGPS"].ToString(), trigger_ticks_map[i][tick_key]["HeadingGPS"].ToString(), trigger_ticks_map[i][tick_key]["Pitch"].ToString(), trigger_ticks_map[i][tick_key]["Roll"].ToString()));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error key");
                    }
                }
            }
        }


        private void wizardPage5_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            string[] tekst = (_cb_create_pix4d.Text.Split('('));
            _cb_create_pix4d.Text = tekst[0] + " (" + _tb_project_folder.Text + "\\pix4d.xml)";

            GeoReferenceAllImages();
            _lv_imagetags.Items.Clear();

            foreach (string s in image_tags.Keys)
            {
                ListViewItem lvi = _lv_imagetags.Items.Add(s);
                lvi.SubItems.Add(image_tags[s].Lat);
                lvi.SubItems.Add(image_tags[s].Lng);
                lvi.SubItems.Add(image_tags[s].AltM);
                lvi.SubItems.Add(image_tags[s].Pitch);
                lvi.SubItems.Add(image_tags[s].Roll);
                lvi.SubItems.Add(image_tags[s].Yaw);
            }

            this.wizardControl1.NextButtonText = "Generate!";
        }


#endregion

#region Generation


        private void DoGeneration()
        {
            if (_cb_copy_to_project_folder.Checked)
            {
                CopyImages();
                try
                {
                    FileInfo fi = new FileInfo(_tb_camera_log.Text);
                    Directory.CreateDirectory(_tb_project_folder.Text + "\\CHDK\\LOGS");
                    File.Copy(_tb_camera_log.Text, _tb_project_folder.Text + "\\CHDK\\LOGS\\" + fi.Name);
                }
                catch (Exception ex)
                {
                    ; // unable to copy camera log file
                }
                try
                {
                    FileInfo fi = new FileInfo(_tb_gluonpilot_logfile.Text);
                    File.Copy(_tb_gluonpilot_logfile.Text, _tb_project_folder.Text + "\\autopilot.xml");
                }
                catch (Exception ex)
                {
                    ; // unable to copy camera log file
                }
            }

            if (_cb_geotag.Checked)
                GeoTagImages();

            if (_cb_create_pix4d.Checked)
            {
                ShowProgress(0, "Creating Pix4D project file");

                if (!Directory.Exists(project_folder))
                    Directory.CreateDirectory(project_folder);

                pix4dfile = project_folder + "\\" + _tb_project_name.Text.Replace(' ', '_') + "_pix4d.xml";
                StreamWriter sw = new StreamWriter(new FileStream(pix4dfile, FileMode.Create));
                sw.Write(GeneratePix4dXml(""));
                sw.Close();

                ShowProgress(5, "Pix4D project file created");
            }

            if (_cb_create_mosaicmill.Checked)
            {
                MosaicMill.Generate(project_folder, SetOfImagePaths, image_tags);
            }

            this.Invoke((Action)(() => GenerationFinished()));
        }

        private void wizardPage_final_Initialize(object sender, AeroWizard.WizardPageInitEventArgs e)
        {
            if (GenerationThread == null)
            {
                _pnl_result.Visible = false;

                _pb_final.Value = 0;
                _pb_final.Maximum = 0;
                if (_cb_create_pix4d.Checked)
                    _pb_final.Maximum += 5;
                if (_cb_geotag.Checked)
                    _pb_final.Maximum += image_tags.Keys.Count;
                if (_cb_copy_to_project_folder.Checked)
                    _pb_final.Maximum += image_tags.Keys.Count;

                project_folder = _tb_project_folder.Text;

                wizardPage_final.AllowBack = false;
                wizardPage_final.AllowNext = false;
                wizardPage_final.AllowCancel = true;

                GenerationThread = new Thread(new ThreadStart(this.DoGeneration));
                GenerationThread.Start();
                while (!GenerationThread.IsAlive) ;
            }
        }

        private void GenerationFinished()
        {
            GenerationThread = null;
            ShowProgress(0, "Finished!");
            wizardPage_final.AllowBack = true;
            wizardPage_final.AllowNext = true;
            wizardPage_final.AllowCancel = false;

            if (pix4dfile != string.Empty)
                _llbl_pix4d_open.Enabled = true;

            if (_cb_geotag.Checked)
                _llbl_drone_mapper.Enabled = true;

             _pnl_result.Visible = true;
        }

        private void CopyImages()
        {
            string new_path = project_folder + "\\DCIM\\Copy";
            if (!Directory.Exists(project_folder + "\\DCIM"))
                Directory.CreateDirectory(project_folder + "\\DCIM");
            if (!Directory.Exists(new_path))
                Directory.CreateDirectory(new_path);

            HashSet<string> new_SetOfImagePaths = new HashSet<string>();

            foreach (string original in SetOfImagePaths)
            {
                FileInfo fi = new FileInfo(original);
                if (image_tags.Keys.Contains(fi.Name))
                {
                    ShowProgress(1, "Copying " + fi.Name);

                    string newfile = new_path + "\\" + fi.Name;
                    if (!(new FileInfo(newfile).Exists))
                        fi.CopyTo(newfile);

                    new_SetOfImagePaths.Add(new_path + "\\" + fi.Name);
                }
            }
            SetOfImagePaths = new_SetOfImagePaths;
        }


        private void GeoTagImages()
        {
            foreach (string fn in SetOfImagePaths)
            {
                FileInfo fi = new FileInfo(fn);
                string name = fi.Name.ToUpper();

                if (image_tags.Keys.Contains(name))
                {
                    Geotagger.Geotag(fn, name, double.Parse(image_tags[name].Lat, System.Globalization.CultureInfo.InvariantCulture),
                        double.Parse(image_tags[name].Lng, System.Globalization.CultureInfo.InvariantCulture),
                        double.Parse(image_tags[name].AltM, System.Globalization.CultureInfo.InvariantCulture));
                }
                ShowProgress(1, "Tagging " + name);
  
            }
        }
        public void ShowProgress(int inc, string message)
        {
            this.Invoke((Action)(() => _pb_final.Value += inc));
            this.Invoke((Action)(() => _lbl_progress_message.Text = message));
        }

        private string GeneratePix4dXml(string filename)
        {
            int tagged_images = 0;

            string projectname = _tb_project_name.Text; // Microsoft.VisualBasic.Interaction.InputBox("Please enter a project name for Pix4d", "Project name", _tbProjectName.Text);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine("<!DOCTYPE Pix4D>");
            sb.AppendLine("<pix4uav>");
            sb.AppendLine("  <version value=\"1615\"/>");
            sb.AppendLine("  <id value=\"Gluonpilot\"/>");
            sb.AppendLine("  <projectName value=\"" + projectname + "\"/>");

            sb.AppendLine("  <workspace path=\"./\"/>");
            sb.AppendLine("  <wkt value=\"WGS84\"/>");
            sb.AppendLine("  <wktImage value=\"WGS84\"/>");
            sb.AppendLine("  <wktGCP value=\"WGS84\"/>");
            sb.AppendLine("  <uploaded value=\"no\"/>");
            sb.AppendLine("  <processed value =\"true\"/>");

            foreach (string fn in SetOfImagePaths)
            {
                FileInfo fi = new FileInfo(fn);
                string name = fi.Name.ToUpper();
                if (image_tags.ContainsKey(name))
                {
                    System.Console.WriteLine("-> " + name + " - " + image_tags[name].Lat.ToString());
                    sb.AppendLine("  <image path=\"" + fn + "\">");
                    sb.AppendLine(String.Format("      <gps alt=\"{0}\" lat=\"{1}\" lng=\"{2}\"/>", image_tags[name].AltM, image_tags[name].Lat, image_tags[name].Lng));
                    sb.AppendLine(String.Format("      <ori yaw=\"{0}\" pitch=\"{1}\" roll=\"{2}\"/>", image_tags[name].Yaw, image_tags[name].Pitch, image_tags[name].Roll));
                    sb.AppendLine("      <okp kappa=\"0.0\" phi=\"0.0\" omega=\"0.0\"/>");
                    sb.AppendLine("      <xyz x=\"0.0\" y=\"0.0\" z=\"0.0\"/>");
                    sb.AppendLine("  </image>");

                    tagged_images++;
                }
            }

            sb.AppendLine("</pix4uav>");
            return sb.ToString();
        }

        private void wizardPage_final_Commit(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {
            this.Close();
        }

        private void wizardPage_final_Rollback(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {
            //if (GenerationThread != null && GenerationThread.IsAlive)
            //    GenerationThread.Abort();
            //_pb_final.Value = _pb_final.Maximum;
            //_lbl_progress_message.Text = "Aborted...";
        }

        private void wizardControl1_Cancelling(object sender, CancelEventArgs e)
        {
            if (GenerationThread != null && GenerationThread.IsAlive)
            {
                if (MessageBox.Show("Are you sure you want to cancel processing and quit?", "Are you sure?", MessageBoxButtons.YesNoCancel) == System.Windows.Forms.DialogResult.Yes)
                {
                    GenerationThread.Abort();
                    this.Close();
                }
            }
            else
                this.Close();
        }


        private void _cb_copy_to_project_folder_CheckedChanged(object sender, EventArgs e)
        {
            if (_cb_copy_to_project_folder.Checked)
                _cb_delete_original.Enabled = true;
            else
            {
                _cb_delete_original.Enabled = false;
                _cb_delete_original.Checked = false;
            }
        }

        private void _llbl_pix4d_open_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (true/* MessageBox.Show(this, "Would you like to open the file in Pix4D?", "Open file?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes*/)
            {
                FileInfo fi = new FileInfo("C:\\Program Files (x86)\\Pix4UAV Cloud\\pix4uavcloud.exe");
                if (!fi.Exists)
                {
                    fi = new FileInfo("C:\\Program Files\\Pix4UAV Cloud\\pix4uavcloud.exe");
                    if (!fi.Exists)
                    {
                        MessageBox.Show(this, "The Pix4D application could not be started.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                System.Diagnostics.Process.Start(fi.FullName, "-gui -xml " + pix4dfile);
            }
        }

        private void _llbl_drone_mapper_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(this, "Please upload the geo-referenced JPG images to DroneMapper", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start("http://www.dronemapper.com");
        }

        private void _llbl_goto_project_folder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(project_folder);
        }
#endregion 

        private void _pb_pix4d_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.pix4d.com");
        }

        private void _pb_mosaicmill_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.mosaicmill.com");
        }

        private void _btn_download_from_module_Click(object sender, EventArgs e)
        {
            string filename = _tb_project_folder.Text + "\\gluonpilot.xml";
            DownloadLog dl = new DownloadLog(filename);
            if (dl.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                _tb_gluonpilot_logfile.Text = filename;
            }
            else
                _tb_gluonpilot_logfile.Text = "";
        }

        private void wizardPage5_Rollback(object sender, AeroWizard.WizardPageConfirmEventArgs e)
        {
            this.wizardControl1.NextButtonText = "Next";
        }


    }

    public class TaggedData
    {
        public string Lat, Lng, AltM, Yaw, Pitch, Roll;
        public TaggedData(string lat, string lng, string altm, string yaw, string pitch, string roll)
        {
            Lat = lat;
            Lng = lng;
            AltM = altm;
            Yaw = yaw;
            Pitch = pitch;
            Roll = roll;
        }
    }

}
