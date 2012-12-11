//using Aerowizard;

namespace MapperWizard
{
    partial class Wizard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wizard));
            this.wizardControl1 = new AeroWizard.WizardControl();
            this.wizardPage1 = new AeroWizard.WizardPage();
            this.label8 = new System.Windows.Forms.Label();
            this._pb_mosaicmill = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this._pb_pix4d = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this._tb_project_folder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._tb_project_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wizardPage2 = new AeroWizard.WizardPage();
            this._btn_images_clear = new System.Windows.Forms.Button();
            this._lbl_select_images = new System.Windows.Forms.Label();
            this._btn_add_folder = new System.Windows.Forms.Button();
            this._btn_add_images = new System.Windows.Forms.Button();
            this._lb_images = new System.Windows.Forms.ListBox();
            this.wizardPage_camera_log = new AeroWizard.WizardPage();
            this._lbl_camera_log_error = new System.Windows.Forms.Label();
            this._lbl_cameralog_info = new System.Windows.Forms.Label();
            this._btn_browse_camera_log = new System.Windows.Forms.Button();
            this._tb_camera_log = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.wizardPage4 = new AeroWizard.WizardPage();
            this._btn_download_from_module = new System.Windows.Forms.Button();
            this._lbl_autopilot_log_info = new System.Windows.Forms.Label();
            this._btn_browse_gluonlog = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this._tb_gluonpilot_logfile = new System.Windows.Forms.TextBox();
            this.wizardPage5 = new AeroWizard.WizardPage();
            this._cb_create_mosaicmill = new System.Windows.Forms.CheckBox();
            this._cb_delete_original = new System.Windows.Forms.CheckBox();
            this._cb_copy_to_project_folder = new System.Windows.Forms.CheckBox();
            this._cb_geotag = new System.Windows.Forms.CheckBox();
            this._cb_create_pix4d = new System.Windows.Forms.CheckBox();
            this._lv_imagetags = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wizardPage_final = new AeroWizard.WizardPage();
            this._pnl_result = new System.Windows.Forms.Panel();
            this._llbl_goto_project_folder = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this._llbl_pix4d_open = new System.Windows.Forms.LinkLabel();
            this._llbl_drone_mapper = new System.Windows.Forms.LinkLabel();
            this._lbl_progress_message = new System.Windows.Forms.Label();
            this._pb_final = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pb_mosaicmill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pb_pix4d)).BeginInit();
            this.wizardPage2.SuspendLayout();
            this.wizardPage_camera_log.SuspendLayout();
            this.wizardPage4.SuspendLayout();
            this.wizardPage5.SuspendLayout();
            this.wizardPage_final.SuspendLayout();
            this._pnl_result.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.Add(this.wizardPage1);
            this.wizardControl1.Pages.Add(this.wizardPage2);
            this.wizardControl1.Pages.Add(this.wizardPage_camera_log);
            this.wizardControl1.Pages.Add(this.wizardPage4);
            this.wizardControl1.Pages.Add(this.wizardPage5);
            this.wizardControl1.Pages.Add(this.wizardPage_final);
            this.wizardControl1.Size = new System.Drawing.Size(527, 460);
            this.wizardControl1.TabIndex = 0;
            this.wizardControl1.Title = "Gluon image mapping wizard";
            this.wizardControl1.Cancelling += new System.ComponentModel.CancelEventHandler(this.wizardControl1_Cancelling);
            // 
            // wizardPage1
            // 
            this.wizardPage1.AllowBack = false;
            this.wizardPage1.AllowNext = false;
            this.wizardPage1.Controls.Add(this.label8);
            this.wizardPage1.Controls.Add(this._pb_mosaicmill);
            this.wizardPage1.Controls.Add(this.label6);
            this.wizardPage1.Controls.Add(this._pb_pix4d);
            this.wizardPage1.Controls.Add(this.label5);
            this.wizardPage1.Controls.Add(this._tb_project_folder);
            this.wizardPage1.Controls.Add(this.label2);
            this.wizardPage1.Controls.Add(this._tb_project_name);
            this.wizardPage1.Controls.Add(this.label1);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.NextPage = this.wizardPage2;
            this.wizardPage1.Size = new System.Drawing.Size(480, 306);
            this.wizardPage1.TabIndex = 0;
            this.wizardPage1.Text = "Project settings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Supported systems:";
            // 
            // _pb_mosaicmill
            // 
            this._pb_mosaicmill.Cursor = System.Windows.Forms.Cursors.Hand;
            this._pb_mosaicmill.Image = ((System.Drawing.Image)(resources.GetObject("_pb_mosaicmill.Image")));
            this._pb_mosaicmill.Location = new System.Drawing.Point(350, 280);
            this._pb_mosaicmill.Name = "_pb_mosaicmill";
            this._pb_mosaicmill.Size = new System.Drawing.Size(90, 19);
            this._pb_mosaicmill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this._pb_mosaicmill.TabIndex = 7;
            this._pb_mosaicmill.TabStop = false;
            this._pb_mosaicmill.Click += new System.EventHandler(this._pb_mosaicmill_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(227, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "DroneMapper";
            // 
            // _pb_pix4d
            // 
            this._pb_pix4d.Cursor = System.Windows.Forms.Cursors.Hand;
            this._pb_pix4d.Image = ((System.Drawing.Image)(resources.GetObject("_pb_pix4d.Image")));
            this._pb_pix4d.Location = new System.Drawing.Point(141, 268);
            this._pb_pix4d.Name = "_pb_pix4d";
            this._pb_pix4d.Size = new System.Drawing.Size(53, 50);
            this._pb_pix4d.TabIndex = 6;
            this._pb_pix4d.TabStop = false;
            this._pb_pix4d.Click += new System.EventHandler(this._pb_pix4d_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(410, 30);
            this.label5.TabIndex = 5;
            this.label5.Text = "Please assign a name to your project.\r\nA project folder will be created to save a" +
                "ll the files generated in the final step.\r\n";
            // 
            // _tb_project_folder
            // 
            this._tb_project_folder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tb_project_folder.Location = new System.Drawing.Point(105, 96);
            this._tb_project_folder.Name = "_tb_project_folder";
            this._tb_project_folder.ReadOnly = true;
            this._tb_project_folder.Size = new System.Drawing.Size(331, 23);
            this._tb_project_folder.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Project folder";
            // 
            // _tb_project_name
            // 
            this._tb_project_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tb_project_name.Location = new System.Drawing.Point(105, 62);
            this._tb_project_name.Name = "_tb_project_name";
            this._tb_project_name.Size = new System.Drawing.Size(331, 23);
            this._tb_project_name.TabIndex = 2;
            this._tb_project_name.TextChanged += new System.EventHandler(this._tb_project_name_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Project name";
            // 
            // wizardPage2
            // 
            this.wizardPage2.AllowNext = false;
            this.wizardPage2.Controls.Add(this._btn_images_clear);
            this.wizardPage2.Controls.Add(this._lbl_select_images);
            this.wizardPage2.Controls.Add(this._btn_add_folder);
            this.wizardPage2.Controls.Add(this._btn_add_images);
            this.wizardPage2.Controls.Add(this._lb_images);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.NextPage = this.wizardPage_camera_log;
            this.wizardPage2.Size = new System.Drawing.Size(480, 306);
            this.wizardPage2.TabIndex = 1;
            this.wizardPage2.Text = "Select images";
            // 
            // _btn_images_clear
            // 
            this._btn_images_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btn_images_clear.Location = new System.Drawing.Point(387, 107);
            this._btn_images_clear.Name = "_btn_images_clear";
            this._btn_images_clear.Size = new System.Drawing.Size(90, 23);
            this._btn_images_clear.TabIndex = 4;
            this._btn_images_clear.Text = "Clear";
            this._btn_images_clear.UseVisualStyleBackColor = true;
            this._btn_images_clear.Click += new System.EventHandler(this._btn_images_clear_Click);
            // 
            // _lbl_select_images
            // 
            this._lbl_select_images.AutoSize = true;
            this._lbl_select_images.Location = new System.Drawing.Point(0, 0);
            this._lbl_select_images.Name = "_lbl_select_images";
            this._lbl_select_images.Size = new System.Drawing.Size(153, 15);
            this._lbl_select_images.TabIndex = 3;
            this._lbl_select_images.Text = "Please add at least 3 images";
            // 
            // _btn_add_folder
            // 
            this._btn_add_folder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btn_add_folder.Location = new System.Drawing.Point(387, 56);
            this._btn_add_folder.Name = "_btn_add_folder";
            this._btn_add_folder.Size = new System.Drawing.Size(90, 23);
            this._btn_add_folder.TabIndex = 2;
            this._btn_add_folder.Text = "Add folder";
            this._btn_add_folder.UseVisualStyleBackColor = true;
            this._btn_add_folder.Click += new System.EventHandler(this._btn_add_folder_Click);
            // 
            // _btn_add_images
            // 
            this._btn_add_images.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btn_add_images.Location = new System.Drawing.Point(387, 27);
            this._btn_add_images.Name = "_btn_add_images";
            this._btn_add_images.Size = new System.Drawing.Size(90, 23);
            this._btn_add_images.TabIndex = 1;
            this._btn_add_images.Text = "Add images";
            this._btn_add_images.UseVisualStyleBackColor = true;
            this._btn_add_images.Click += new System.EventHandler(this._btn_add_images_Click);
            // 
            // _lb_images
            // 
            this._lb_images.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._lb_images.FormattingEnabled = true;
            this._lb_images.HorizontalScrollbar = true;
            this._lb_images.ItemHeight = 15;
            this._lb_images.Location = new System.Drawing.Point(3, 27);
            this._lb_images.Name = "_lb_images";
            this._lb_images.Size = new System.Drawing.Size(378, 274);
            this._lb_images.TabIndex = 0;
            // 
            // wizardPage_camera_log
            // 
            this.wizardPage_camera_log.AllowNext = false;
            this.wizardPage_camera_log.Controls.Add(this._lbl_camera_log_error);
            this.wizardPage_camera_log.Controls.Add(this._lbl_cameralog_info);
            this.wizardPage_camera_log.Controls.Add(this._btn_browse_camera_log);
            this.wizardPage_camera_log.Controls.Add(this._tb_camera_log);
            this.wizardPage_camera_log.Controls.Add(this.label3);
            this.wizardPage_camera_log.Name = "wizardPage_camera_log";
            this.wizardPage_camera_log.NextPage = this.wizardPage4;
            this.wizardPage_camera_log.Size = new System.Drawing.Size(480, 306);
            this.wizardPage_camera_log.TabIndex = 2;
            this.wizardPage_camera_log.Text = "Select camera log file";
            this.wizardPage_camera_log.Initialize += new System.EventHandler<AeroWizard.WizardPageInitEventArgs>(this.wizardPage_camera_log_Initialize);
            // 
            // _lbl_camera_log_error
            // 
            this._lbl_camera_log_error.AutoSize = true;
            this._lbl_camera_log_error.ForeColor = System.Drawing.Color.Red;
            this._lbl_camera_log_error.Location = new System.Drawing.Point(4, 145);
            this._lbl_camera_log_error.Name = "_lbl_camera_log_error";
            this._lbl_camera_log_error.Size = new System.Drawing.Size(61, 15);
            this._lbl_camera_log_error.TabIndex = 4;
            this._lbl_camera_log_error.Text = "                  ";
            // 
            // _lbl_cameralog_info
            // 
            this._lbl_cameralog_info.Location = new System.Drawing.Point(7, 95);
            this._lbl_cameralog_info.Name = "_lbl_cameralog_info";
            this._lbl_cameralog_info.Size = new System.Drawing.Size(385, 37);
            this._lbl_cameralog_info.TabIndex = 3;
            // 
            // _btn_browse_camera_log
            // 
            this._btn_browse_camera_log.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btn_browse_camera_log.Location = new System.Drawing.Point(398, 68);
            this._btn_browse_camera_log.Name = "_btn_browse_camera_log";
            this._btn_browse_camera_log.Size = new System.Drawing.Size(75, 23);
            this._btn_browse_camera_log.TabIndex = 2;
            this._btn_browse_camera_log.Text = "Browse";
            this._btn_browse_camera_log.UseVisualStyleBackColor = true;
            this._btn_browse_camera_log.Click += new System.EventHandler(this._btn_browse_camera_log_Click);
            // 
            // _tb_camera_log
            // 
            this._tb_camera_log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tb_camera_log.Location = new System.Drawing.Point(7, 69);
            this._tb_camera_log.Name = "_tb_camera_log";
            this._tb_camera_log.ReadOnly = true;
            this._tb_camera_log.Size = new System.Drawing.Size(385, 23);
            this._tb_camera_log.TabIndex = 1;
            this._tb_camera_log.TextChanged += new System.EventHandler(this._tb_camera_log_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(398, 45);
            this.label3.TabIndex = 0;
            this.label3.Text = "The camera log file describes the exact moment when a picture was taken.\r\nIt can " +
                "be found in CHDK/LOG and contains the number of the first image \r\nin its file na" +
                "me.";
            // 
            // wizardPage4
            // 
            this.wizardPage4.AllowNext = false;
            this.wizardPage4.Controls.Add(this._btn_download_from_module);
            this.wizardPage4.Controls.Add(this._lbl_autopilot_log_info);
            this.wizardPage4.Controls.Add(this._btn_browse_gluonlog);
            this.wizardPage4.Controls.Add(this.label4);
            this.wizardPage4.Controls.Add(this._tb_gluonpilot_logfile);
            this.wizardPage4.Name = "wizardPage4";
            this.wizardPage4.NextPage = this.wizardPage5;
            this.wizardPage4.Size = new System.Drawing.Size(480, 306);
            this.wizardPage4.TabIndex = 3;
            this.wizardPage4.Text = "Select autopilot log file";
            // 
            // _btn_download_from_module
            // 
            this._btn_download_from_module.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btn_download_from_module.Location = new System.Drawing.Point(329, 67);
            this._btn_download_from_module.Name = "_btn_download_from_module";
            this._btn_download_from_module.Size = new System.Drawing.Size(148, 24);
            this._btn_download_from_module.TabIndex = 4;
            this._btn_download_from_module.Text = "Download from module";
            this._btn_download_from_module.UseVisualStyleBackColor = true;
            this._btn_download_from_module.Click += new System.EventHandler(this._btn_download_from_module_Click);
            // 
            // _lbl_autopilot_log_info
            // 
            this._lbl_autopilot_log_info.AutoSize = true;
            this._lbl_autopilot_log_info.Location = new System.Drawing.Point(4, 81);
            this._lbl_autopilot_log_info.Name = "_lbl_autopilot_log_info";
            this._lbl_autopilot_log_info.Size = new System.Drawing.Size(19, 15);
            this._lbl_autopilot_log_info.TabIndex = 3;
            this._lbl_autopilot_log_info.Text = "    ";
            // 
            // _btn_browse_gluonlog
            // 
            this._btn_browse_gluonlog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btn_browse_gluonlog.Location = new System.Drawing.Point(402, 38);
            this._btn_browse_gluonlog.Name = "_btn_browse_gluonlog";
            this._btn_browse_gluonlog.Size = new System.Drawing.Size(75, 23);
            this._btn_browse_gluonlog.TabIndex = 2;
            this._btn_browse_gluonlog.Text = "Browse";
            this._btn_browse_gluonlog.UseVisualStyleBackColor = true;
            this._btn_browse_gluonlog.Click += new System.EventHandler(this._btn_browse_gluonlog_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(441, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "The autopilot log file contains the GPS coordinates needed to tag our images with" +
                ".";
            // 
            // _tb_gluonpilot_logfile
            // 
            this._tb_gluonpilot_logfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tb_gluonpilot_logfile.Location = new System.Drawing.Point(3, 38);
            this._tb_gluonpilot_logfile.Name = "_tb_gluonpilot_logfile";
            this._tb_gluonpilot_logfile.ReadOnly = true;
            this._tb_gluonpilot_logfile.Size = new System.Drawing.Size(395, 23);
            this._tb_gluonpilot_logfile.TabIndex = 0;
            this._tb_gluonpilot_logfile.TextChanged += new System.EventHandler(this._tb_gluonpilot_logfile_TextChanged);
            // 
            // wizardPage5
            // 
            this.wizardPage5.Controls.Add(this._cb_create_mosaicmill);
            this.wizardPage5.Controls.Add(this._cb_delete_original);
            this.wizardPage5.Controls.Add(this._cb_copy_to_project_folder);
            this.wizardPage5.Controls.Add(this._cb_geotag);
            this.wizardPage5.Controls.Add(this._cb_create_pix4d);
            this.wizardPage5.Controls.Add(this._lv_imagetags);
            this.wizardPage5.Name = "wizardPage5";
            this.wizardPage5.Size = new System.Drawing.Size(480, 306);
            this.wizardPage5.TabIndex = 4;
            this.wizardPage5.Text = "Geo-reference images";
            this.wizardPage5.Initialize += new System.EventHandler<AeroWizard.WizardPageInitEventArgs>(this.wizardPage5_Initialize);
            this.wizardPage5.Rollback += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.wizardPage5_Rollback);
            // 
            // _cb_create_mosaicmill
            // 
            this._cb_create_mosaicmill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._cb_create_mosaicmill.AutoSize = true;
            this._cb_create_mosaicmill.Checked = true;
            this._cb_create_mosaicmill.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cb_create_mosaicmill.Location = new System.Drawing.Point(17, 211);
            this._cb_create_mosaicmill.Name = "_cb_create_mosaicmill";
            this._cb_create_mosaicmill.Size = new System.Drawing.Size(188, 19);
            this._cb_create_mosaicmill.TabIndex = 6;
            this._cb_create_mosaicmill.Text = "Create Mosaic Mill project files";
            this._cb_create_mosaicmill.UseVisualStyleBackColor = true;
            // 
            // _cb_delete_original
            // 
            this._cb_delete_original.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._cb_delete_original.AutoSize = true;
            this._cb_delete_original.Enabled = false;
            this._cb_delete_original.Location = new System.Drawing.Point(59, 284);
            this._cb_delete_original.Name = "_cb_delete_original";
            this._cb_delete_original.Size = new System.Drawing.Size(128, 19);
            this._cb_delete_original.TabIndex = 5;
            this._cb_delete_original.Text = "Delete original data";
            this._cb_delete_original.UseVisualStyleBackColor = true;
            // 
            // _cb_copy_to_project_folder
            // 
            this._cb_copy_to_project_folder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._cb_copy_to_project_folder.AutoSize = true;
            this._cb_copy_to_project_folder.Checked = true;
            this._cb_copy_to_project_folder.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cb_copy_to_project_folder.Location = new System.Drawing.Point(17, 259);
            this._cb_copy_to_project_folder.Name = "_cb_copy_to_project_folder";
            this._cb_copy_to_project_folder.Size = new System.Drawing.Size(198, 19);
            this._cb_copy_to_project_folder.TabIndex = 4;
            this._cb_copy_to_project_folder.Text = "Copy all images to project folder";
            this._cb_copy_to_project_folder.UseVisualStyleBackColor = true;
            this._cb_copy_to_project_folder.CheckedChanged += new System.EventHandler(this._cb_copy_to_project_folder_CheckedChanged);
            // 
            // _cb_geotag
            // 
            this._cb_geotag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._cb_geotag.AutoSize = true;
            this._cb_geotag.Checked = true;
            this._cb_geotag.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cb_geotag.Location = new System.Drawing.Point(17, 234);
            this._cb_geotag.Name = "_cb_geotag";
            this._cb_geotag.Size = new System.Drawing.Size(131, 19);
            this._cb_geotag.TabIndex = 3;
            this._cb_geotag.Text = "Geotag every image";
            this._cb_geotag.UseVisualStyleBackColor = true;
            // 
            // _cb_create_pix4d
            // 
            this._cb_create_pix4d.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._cb_create_pix4d.AutoSize = true;
            this._cb_create_pix4d.Checked = true;
            this._cb_create_pix4d.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cb_create_pix4d.Location = new System.Drawing.Point(17, 186);
            this._cb_create_pix4d.Name = "_cb_create_pix4d";
            this._cb_create_pix4d.Size = new System.Drawing.Size(151, 19);
            this._cb_create_pix4d.TabIndex = 1;
            this._cb_create_pix4d.Text = "Create Pix4D project file";
            this._cb_create_pix4d.UseVisualStyleBackColor = true;
            // 
            // _lv_imagetags
            // 
            this._lv_imagetags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._lv_imagetags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader7,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this._lv_imagetags.Location = new System.Drawing.Point(3, 3);
            this._lv_imagetags.Name = "_lv_imagetags";
            this._lv_imagetags.Size = new System.Drawing.Size(474, 173);
            this._lv_imagetags.TabIndex = 0;
            this._lv_imagetags.UseCompatibleStateImageBehavior = false;
            this._lv_imagetags.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Image";
            this.columnHeader1.Width = 96;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Latitude";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Longitude";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Altitude";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Pitch";
            this.columnHeader4.Width = 59;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Roll";
            this.columnHeader5.Width = 51;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Yaw";
            this.columnHeader6.Width = 53;
            // 
            // wizardPage_final
            // 
            this.wizardPage_final.Controls.Add(this._pnl_result);
            this.wizardPage_final.Controls.Add(this._lbl_progress_message);
            this.wizardPage_final.Controls.Add(this._pb_final);
            this.wizardPage_final.IsFinishPage = true;
            this.wizardPage_final.Name = "wizardPage_final";
            this.wizardPage_final.Size = new System.Drawing.Size(480, 306);
            this.wizardPage_final.TabIndex = 5;
            this.wizardPage_final.Text = "Result";
            this.wizardPage_final.Commit += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.wizardPage_final_Commit);
            this.wizardPage_final.Initialize += new System.EventHandler<AeroWizard.WizardPageInitEventArgs>(this.wizardPage_final_Initialize);
            this.wizardPage_final.Rollback += new System.EventHandler<AeroWizard.WizardPageConfirmEventArgs>(this.wizardPage_final_Rollback);
            // 
            // _pnl_result
            // 
            this._pnl_result.Controls.Add(this._llbl_goto_project_folder);
            this._pnl_result.Controls.Add(this.label7);
            this._pnl_result.Controls.Add(this._llbl_pix4d_open);
            this._pnl_result.Controls.Add(this._llbl_drone_mapper);
            this._pnl_result.Location = new System.Drawing.Point(29, 178);
            this._pnl_result.Name = "_pnl_result";
            this._pnl_result.Size = new System.Drawing.Size(265, 115);
            this._pnl_result.TabIndex = 6;
            this._pnl_result.Visible = false;
            // 
            // _llbl_goto_project_folder
            // 
            this._llbl_goto_project_folder.AutoSize = true;
            this._llbl_goto_project_folder.Location = new System.Drawing.Point(25, 85);
            this._llbl_goto_project_folder.Name = "_llbl_goto_project_folder";
            this._llbl_goto_project_folder.Size = new System.Drawing.Size(110, 15);
            this._llbl_goto_project_folder.TabIndex = 3;
            this._llbl_goto_project_folder.TabStop = true;
            this._llbl_goto_project_folder.Text = "Go to project folder";
            this._llbl_goto_project_folder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._llbl_goto_project_folder_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(207, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "The wizard has finished, you can now:";
            // 
            // _llbl_pix4d_open
            // 
            this._llbl_pix4d_open.AutoSize = true;
            this._llbl_pix4d_open.Enabled = false;
            this._llbl_pix4d_open.Location = new System.Drawing.Point(25, 35);
            this._llbl_pix4d_open.Name = "_llbl_pix4d_open";
            this._llbl_pix4d_open.Size = new System.Drawing.Size(121, 15);
            this._llbl_pix4d_open.TabIndex = 2;
            this._llbl_pix4d_open.TabStop = true;
            this._llbl_pix4d_open.Text = "Open project in Pix4D";
            this._llbl_pix4d_open.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._llbl_pix4d_open_LinkClicked);
            // 
            // _llbl_drone_mapper
            // 
            this._llbl_drone_mapper.AutoSize = true;
            this._llbl_drone_mapper.Enabled = false;
            this._llbl_drone_mapper.Location = new System.Drawing.Point(25, 60);
            this._llbl_drone_mapper.Name = "_llbl_drone_mapper";
            this._llbl_drone_mapper.Size = new System.Drawing.Size(135, 15);
            this._llbl_drone_mapper.TabIndex = 4;
            this._llbl_drone_mapper.TabStop = true;
            this._llbl_drone_mapper.Text = "Upload to DroneMapper";
            this._llbl_drone_mapper.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._llbl_drone_mapper_LinkClicked);
            // 
            // _lbl_progress_message
            // 
            this._lbl_progress_message.Location = new System.Drawing.Point(64, 38);
            this._lbl_progress_message.Name = "_lbl_progress_message";
            this._lbl_progress_message.Size = new System.Drawing.Size(346, 17);
            this._lbl_progress_message.TabIndex = 1;
            this._lbl_progress_message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // _pb_final
            // 
            this._pb_final.Location = new System.Drawing.Point(64, 61);
            this._pb_final.Name = "_pb_final";
            this._pb_final.Size = new System.Drawing.Size(346, 23);
            this._pb_final.TabIndex = 0;
            // 
            // Wizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 460);
            this.Controls.Add(this.wizardControl1);
            this.Name = "Wizard";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pb_mosaicmill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pb_pix4d)).EndInit();
            this.wizardPage2.ResumeLayout(false);
            this.wizardPage2.PerformLayout();
            this.wizardPage_camera_log.ResumeLayout(false);
            this.wizardPage_camera_log.PerformLayout();
            this.wizardPage4.ResumeLayout(false);
            this.wizardPage4.PerformLayout();
            this.wizardPage5.ResumeLayout(false);
            this.wizardPage5.PerformLayout();
            this.wizardPage_final.ResumeLayout(false);
            this._pnl_result.ResumeLayout(false);
            this._pnl_result.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AeroWizard.WizardControl wizardControl1;
        private AeroWizard.WizardPage wizardPage1;
        private AeroWizard.WizardPage wizardPage2;
        private AeroWizard.WizardPage wizardPage_camera_log;
        private AeroWizard.WizardPage wizardPage4;
        private AeroWizard.WizardPage wizardPage5;
        private System.Windows.Forms.TextBox _tb_project_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tb_project_folder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _btn_add_folder;
        private System.Windows.Forms.Button _btn_add_images;
        private System.Windows.Forms.ListBox _lb_images;
        private System.Windows.Forms.Label _lbl_select_images;
        private System.Windows.Forms.Button _btn_images_clear;
        private System.Windows.Forms.Button _btn_browse_camera_log;
        private System.Windows.Forms.TextBox _tb_camera_log;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label _lbl_cameralog_info;
        private System.Windows.Forms.Label _lbl_camera_log_error;
        private System.Windows.Forms.Button _btn_browse_gluonlog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _tb_gluonpilot_logfile;
        private System.Windows.Forms.Label _lbl_autopilot_log_info;
        private System.Windows.Forms.ListView _lv_imagetags;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.CheckBox _cb_delete_original;
        private System.Windows.Forms.CheckBox _cb_copy_to_project_folder;
        private System.Windows.Forms.CheckBox _cb_geotag;
        private System.Windows.Forms.CheckBox _cb_create_pix4d;
        private AeroWizard.WizardPage wizardPage_final;
        private System.Windows.Forms.ProgressBar _pb_final;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label _lbl_progress_message;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox _pb_pix4d;
        private System.Windows.Forms.Button _btn_download_from_module;
        private System.Windows.Forms.LinkLabel _llbl_drone_mapper;
        private System.Windows.Forms.LinkLabel _llbl_goto_project_folder;
        private System.Windows.Forms.LinkLabel _llbl_pix4d_open;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox _pb_mosaicmill;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox _cb_create_mosaicmill;
        private System.Windows.Forms.Panel _pnl_result;


    }
}

