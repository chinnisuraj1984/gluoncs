namespace GluonCS.LiveUavLayer
{
    partial class ConnectForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectForm));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.xPanderPanelList1 = new BSE.Windows.Forms.XPanderPanelList();
            this.xPanderPanel2 = new BSE.Windows.Forms.XPanderPanel();
            this._rbOffline = new System.Windows.Forms.RadioButton();
            this._rbReplay = new System.Windows.Forms.RadioButton();
            this._rbViaComPort = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._btnBrowseLoggedFile = new System.Windows.Forms.Button();
            this._tbLoggedFilename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._btn_portrefresh = new System.Windows.Forms.Button();
            this._cbBaudrate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this._cb_portnames = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.xPanderPanel1 = new BSE.Windows.Forms.XPanderPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this._lblFilename = new System.Windows.Forms.Label();
            this._btnChangeFilename = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this._cbLogToFile = new System.Windows.Forms.CheckBox();
            this.xPanderPanel3 = new BSE.Windows.Forms.XPanderPanel();
            this.label1 = new System.Windows.Forms.Label();
            this._tbFlightgear = new System.Windows.Forms.TextBox();
            this._cbSimulationFG = new System.Windows.Forms.CheckBox();
            this._btn_connect = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._cbSimulation = new System.Windows.Forms.CheckBox();
            this.xPanderPanelList1.SuspendLayout();
            this.xPanderPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.xPanderPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.xPanderPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanderPanelList1
            // 
            this.xPanderPanelList1.CaptionStyle = BSE.Windows.Forms.CaptionStyle.Normal;
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel2);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel1);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel3);
            resources.ApplyResources(this.xPanderPanelList1, "xPanderPanelList1");
            this.xPanderPanelList1.GradientBackground = System.Drawing.Color.Empty;
            this.xPanderPanelList1.Name = "xPanderPanelList1";
            this.xPanderPanelList1.PanelColors = null;
            // 
            // xPanderPanel2
            // 
            this.xPanderPanel2.CaptionFont = new System.Drawing.Font("Trebuchet MS", 8.75F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel2.Controls.Add(this._rbOffline);
            this.xPanderPanel2.Controls.Add(this._rbReplay);
            this.xPanderPanel2.Controls.Add(this._rbViaComPort);
            this.xPanderPanel2.Controls.Add(this.groupBox2);
            this.xPanderPanel2.Controls.Add(this.groupBox1);
            this.xPanderPanel2.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel2.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(65)))), ((int)(((byte)(118)))));
            this.xPanderPanel2.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(154)))));
            this.xPanderPanel2.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(76)))));
            this.xPanderPanel2.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(116)))));
            this.xPanderPanel2.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.xPanderPanel2.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(164)))), ((int)(((byte)(224)))));
            this.xPanderPanel2.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.xPanderPanel2.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(128)))), ((int)(((byte)(62)))));
            this.xPanderPanel2.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(154)))));
            this.xPanderPanel2.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(109)))));
            this.xPanderPanel2.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(222)))));
            this.xPanderPanel2.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(136)))));
            this.xPanderPanel2.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(172)))));
            this.xPanderPanel2.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.xPanderPanel2.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.xPanderPanel2.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanel2.Expand = true;
            this.xPanderPanel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.Image = null;
            this.xPanderPanel2.Name = "xPanderPanel2";
            this.xPanderPanel2.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            resources.ApplyResources(this.xPanderPanel2, "xPanderPanel2");
            this.xPanderPanel2.ToolTipTextCloseIcon = null;
            this.xPanderPanel2.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel2.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // _rbOffline
            // 
            resources.ApplyResources(this._rbOffline, "_rbOffline");
            this._rbOffline.Name = "_rbOffline";
            this._rbOffline.TabStop = true;
            this._rbOffline.UseVisualStyleBackColor = true;
            // 
            // _rbReplay
            // 
            resources.ApplyResources(this._rbReplay, "_rbReplay");
            this._rbReplay.Name = "_rbReplay";
            this._rbReplay.UseVisualStyleBackColor = true;
            // 
            // _rbViaComPort
            // 
            resources.ApplyResources(this._rbViaComPort, "_rbViaComPort");
            this._rbViaComPort.Checked = true;
            this._rbViaComPort.Name = "_rbViaComPort";
            this._rbViaComPort.TabStop = true;
            this._rbViaComPort.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._btnBrowseLoggedFile);
            this.groupBox2.Controls.Add(this._tbLoggedFilename);
            this.groupBox2.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // _btnBrowseLoggedFile
            // 
            resources.ApplyResources(this._btnBrowseLoggedFile, "_btnBrowseLoggedFile");
            this._btnBrowseLoggedFile.Name = "_btnBrowseLoggedFile";
            this._btnBrowseLoggedFile.UseVisualStyleBackColor = true;
            this._btnBrowseLoggedFile.Click += new System.EventHandler(this._btnBrowseLoggedFile_Click);
            // 
            // _tbLoggedFilename
            // 
            resources.ApplyResources(this._tbLoggedFilename, "_tbLoggedFilename");
            this._tbLoggedFilename.Name = "_tbLoggedFilename";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._btn_portrefresh);
            this.groupBox1.Controls.Add(this._cbBaudrate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this._cb_portnames);
            this.groupBox1.Controls.Add(this.label5);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // _btn_portrefresh
            // 
            this._btn_portrefresh.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this._btn_portrefresh, "_btn_portrefresh");
            this._btn_portrefresh.ForeColor = System.Drawing.Color.Transparent;
            this._btn_portrefresh.Name = "_btn_portrefresh";
            this._btn_portrefresh.UseVisualStyleBackColor = true;
            this._btn_portrefresh.Click += new System.EventHandler(this._btn_portrefresh_Click);
            // 
            // _cbBaudrate
            // 
            this._cbBaudrate.FormattingEnabled = true;
            this._cbBaudrate.Items.AddRange(new object[] {
            resources.GetString("_cbBaudrate.Items"),
            resources.GetString("_cbBaudrate.Items1"),
            resources.GetString("_cbBaudrate.Items2"),
            resources.GetString("_cbBaudrate.Items3"),
            resources.GetString("_cbBaudrate.Items4"),
            resources.GetString("_cbBaudrate.Items5"),
            resources.GetString("_cbBaudrate.Items6"),
            resources.GetString("_cbBaudrate.Items7")});
            resources.ApplyResources(this._cbBaudrate, "_cbBaudrate");
            this._cbBaudrate.Name = "_cbBaudrate";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // _cb_portnames
            // 
            this._cb_portnames.FormattingEnabled = true;
            resources.ApplyResources(this._cb_portnames, "_cb_portnames");
            this._cb_portnames.Name = "_cb_portnames";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // xPanderPanel1
            // 
            this.xPanderPanel1.CaptionFont = new System.Drawing.Font("Trebuchet MS", 8.75F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel1.Controls.Add(this.label2);
            this.xPanderPanel1.Controls.Add(this.numericUpDown1);
            this.xPanderPanel1.Controls.Add(this._lblFilename);
            this.xPanderPanel1.Controls.Add(this._btnChangeFilename);
            this.xPanderPanel1.Controls.Add(this.checkBox2);
            this.xPanderPanel1.Controls.Add(this._cbLogToFile);
            this.xPanderPanel1.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel1.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(65)))), ((int)(((byte)(118)))));
            this.xPanderPanel1.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(154)))));
            this.xPanderPanel1.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(76)))));
            this.xPanderPanel1.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(116)))));
            this.xPanderPanel1.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(164)))), ((int)(((byte)(224)))));
            this.xPanderPanel1.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.xPanderPanel1.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(128)))), ((int)(((byte)(62)))));
            this.xPanderPanel1.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(154)))));
            this.xPanderPanel1.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(109)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(222)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(136)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(172)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.xPanderPanel1.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.Image = null;
            this.xPanderPanel1.Name = "xPanderPanel1";
            this.xPanderPanel1.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            resources.ApplyResources(this.xPanderPanel1, "xPanderPanel1");
            this.xPanderPanel1.ToolTipTextCloseIcon = null;
            this.xPanderPanel1.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel1.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // numericUpDown1
            // 
            resources.ApplyResources(this.numericUpDown1, "numericUpDown1");
            this.numericUpDown1.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Value = new decimal(new int[] {
            6170,
            0,
            0,
            0});
            // 
            // _lblFilename
            // 
            resources.ApplyResources(this._lblFilename, "_lblFilename");
            this._lblFilename.Name = "_lblFilename";
            // 
            // _btnChangeFilename
            // 
            resources.ApplyResources(this._btnChangeFilename, "_btnChangeFilename");
            this._btnChangeFilename.Name = "_btnChangeFilename";
            this._btnChangeFilename.UseVisualStyleBackColor = true;
            this._btnChangeFilename.Click += new System.EventHandler(this._btnChangeFilename_Click);
            // 
            // checkBox2
            // 
            resources.ApplyResources(this.checkBox2, "checkBox2");
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // _cbLogToFile
            // 
            resources.ApplyResources(this._cbLogToFile, "_cbLogToFile");
            this._cbLogToFile.Name = "_cbLogToFile";
            this._cbLogToFile.UseVisualStyleBackColor = true;
            this._cbLogToFile.CheckedChanged += new System.EventHandler(this._cbLogToFile_CheckedChanged);
            // 
            // xPanderPanel3
            // 
            this.xPanderPanel3.CaptionFont = new System.Drawing.Font("Trebuchet MS", 8.75F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel3.Controls.Add(this.label1);
            this.xPanderPanel3.Controls.Add(this._tbFlightgear);
            this.xPanderPanel3.Controls.Add(this._cbSimulation);
            this.xPanderPanel3.Controls.Add(this._cbSimulationFG);
            this.xPanderPanel3.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel3.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(65)))), ((int)(((byte)(118)))));
            this.xPanderPanel3.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(154)))));
            this.xPanderPanel3.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(76)))));
            this.xPanderPanel3.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(116)))));
            this.xPanderPanel3.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.xPanderPanel3.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(164)))), ((int)(((byte)(224)))));
            this.xPanderPanel3.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.xPanderPanel3.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(128)))), ((int)(((byte)(62)))));
            this.xPanderPanel3.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(154)))));
            this.xPanderPanel3.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(177)))), ((int)(((byte)(109)))));
            this.xPanderPanel3.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(222)))));
            this.xPanderPanel3.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(136)))));
            this.xPanderPanel3.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(172)))));
            this.xPanderPanel3.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.xPanderPanel3.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.xPanderPanel3.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xPanderPanel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.Image = null;
            this.xPanderPanel3.Name = "xPanderPanel3";
            this.xPanderPanel3.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            resources.ApplyResources(this.xPanderPanel3, "xPanderPanel3");
            this.xPanderPanel3.ToolTipTextCloseIcon = null;
            this.xPanderPanel3.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel3.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _tbFlightgear
            // 
            resources.ApplyResources(this._tbFlightgear, "_tbFlightgear");
            this._tbFlightgear.Name = "_tbFlightgear";
            // 
            // _cbSimulationFG
            // 
            resources.ApplyResources(this._cbSimulationFG, "_cbSimulationFG");
            this._cbSimulationFG.Name = "_cbSimulationFG";
            this._cbSimulationFG.UseVisualStyleBackColor = true;
            // 
            // _btn_connect
            // 
            resources.ApplyResources(this._btn_connect, "_btn_connect");
            this._btn_connect.Name = "_btn_connect";
            this._btn_connect.UseVisualStyleBackColor = true;
            this._btn_connect.Click += new System.EventHandler(this._btn_connect_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._btn_connect);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // _cbSimulation
            // 
            resources.ApplyResources(this._cbSimulation, "_cbSimulation");
            this._cbSimulation.Name = "_cbSimulation";
            this._cbSimulation.UseVisualStyleBackColor = true;
            // 
            // ConnectForm
            // 
            this.AcceptButton = this._btn_connect;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.xPanderPanelList1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ConnectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.xPanderPanelList1.ResumeLayout(false);
            this.xPanderPanel2.ResumeLayout(false);
            this.xPanderPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.xPanderPanel1.ResumeLayout(false);
            this.xPanderPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.xPanderPanel3.ResumeLayout(false);
            this.xPanderPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private BSE.Windows.Forms.XPanderPanelList xPanderPanelList1;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel2;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label _lblFilename;
        private System.Windows.Forms.Button _btnChangeFilename;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox _cbLogToFile;
        private System.Windows.Forms.RadioButton _rbReplay;
        private System.Windows.Forms.RadioButton _rbViaComPort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _btn_connect;
        private System.Windows.Forms.TextBox _tbLoggedFilename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _cbBaudrate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox _cb_portnames;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel3;
        private System.Windows.Forms.CheckBox _cbSimulationFG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbFlightgear;
        private System.Windows.Forms.Button _btnBrowseLoggedFile;
        private System.Windows.Forms.Button _btn_portrefresh;
        private System.Windows.Forms.RadioButton _rbOffline;
        private System.Windows.Forms.CheckBox _cbSimulation;
    }
}