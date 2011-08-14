namespace GluonCS
{
    partial class LiveUavPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiveUavPanel));
            this._cockpitPanel = new BSE.Windows.Forms.Panel();
            this.splitter1 = new BSE.Windows.Forms.Splitter();
            this._ahPanel = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._ts2dah = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._tsFunjet = new System.Windows.Forms.ToolStripMenuItem();
            this._tsEasystar = new System.Windows.Forms.ToolStripMenuItem();
            this._tsPredator = new System.Windows.Forms.ToolStripMenuItem();
            this._artificialHorizon = new ArtificialHorizon.ArtificialHorizon();
            this._lblFlightMode = new System.Windows.Forms.Label();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this._btnConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._btnCenterUav = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this._ts_basicconfig = new System.Windows.Forms.ToolStripMenuItem();
            this._tbn_fullconfig = new System.Windows.Forms.ToolStripMenuItem();
            this._pbRcLink = new ProgressBarColored();
            this.label3 = new System.Windows.Forms.Label();
            this._pbLink = new ProgressBarColored();
            this._lblLink = new System.Windows.Forms.Label();
            this._pbGps = new ProgressBarColored();
            this._pbBattery = new ProgressBarColored();
            this.label1 = new System.Windows.Forms.Label();
            this._pbThrottle = new ProgressBarColored();
            this._lblBlockname = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this._panelStrip = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._zgAlt = new ZedGraph.ZedGraphControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._zgVel = new ZedGraph.ZedGraphControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this._zgBatV = new ZedGraph.ZedGraphControl();
            this._lblAltitudeAgl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this._lblFlightTime = new System.Windows.Forms.Label();
            this._lblTimeInBlock = new System.Windows.Forms.Label();
            this._lblTimeToWp = new System.Windows.Forms.Label();
            this._lblHomeDistance = new System.Windows.Forms.Label();
            this._lblDistNextWp = new System.Windows.Forms.Label();
            this._lblVoltage = new System.Windows.Forms.Label();
            this._lblSpeed = new System.Windows.Forms.Label();
            this._lblGpsSat = new System.Windows.Forms.Label();
            this._navigationPanel = new BSE.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._btn_up = new System.Windows.Forms.ToolStripButton();
            this._btn_down = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this._nav_open = new System.Windows.Forms.ToolStripMenuItem();
            this._nav_save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this._btnNaviRead = new System.Windows.Forms.ToolStripMenuItem();
            this._btnNaviWrite = new System.Windows.Forms.ToolStripMenuItem();
            this._btnNaviReload = new System.Windows.Forms.ToolStripMenuItem();
            this._btnAutoSync = new System.Windows.Forms.ToolStripButton();
            this._btnNaviBurn = new System.Windows.Forms.ToolStripButton();
            this._lv_navigation = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._imageListGps = new System.Windows.Forms.ImageList(this.components);
            this._gmapContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._cockpitPanel.SuspendLayout();
            this._ahPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this._panelStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this._navigationPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cockpitPanel
            // 
            this._cockpitPanel.AssociatedSplitter = this.splitter1;
            this._cockpitPanel.BackColor = System.Drawing.Color.Transparent;
            this._cockpitPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._cockpitPanel.CaptionFont = new System.Drawing.Font("Trebuchet MS", 8.75F, System.Drawing.FontStyle.Bold);
            this._cockpitPanel.CaptionHeight = 20;
            this._cockpitPanel.Controls.Add(this._ahPanel);
            this._cockpitPanel.Controls.Add(this._lblFlightMode);
            this._cockpitPanel.Controls.Add(this.toolStripContainer1);
            this._cockpitPanel.Controls.Add(this._pbRcLink);
            this._cockpitPanel.Controls.Add(this.label3);
            this._cockpitPanel.Controls.Add(this._pbLink);
            this._cockpitPanel.Controls.Add(this._lblLink);
            this._cockpitPanel.Controls.Add(this._pbGps);
            this._cockpitPanel.Controls.Add(this._pbBattery);
            this._cockpitPanel.Controls.Add(this.label1);
            this._cockpitPanel.Controls.Add(this._pbThrottle);
            this._cockpitPanel.Controls.Add(this._lblBlockname);
            this._cockpitPanel.Controls.Add(this.tableLayoutPanel3);
            this._cockpitPanel.Controls.Add(this._lblAltitudeAgl);
            this._cockpitPanel.Controls.Add(this.label9);
            this._cockpitPanel.Controls.Add(this.label14);
            this._cockpitPanel.Controls.Add(this._lblFlightTime);
            this._cockpitPanel.Controls.Add(this._lblTimeInBlock);
            this._cockpitPanel.Controls.Add(this._lblTimeToWp);
            this._cockpitPanel.Controls.Add(this._lblHomeDistance);
            this._cockpitPanel.Controls.Add(this._lblDistNextWp);
            this._cockpitPanel.Controls.Add(this._lblVoltage);
            this._cockpitPanel.Controls.Add(this._lblSpeed);
            this._cockpitPanel.Controls.Add(this._lblGpsSat);
            this._cockpitPanel.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(65)))), ((int)(((byte)(118)))));
            this._cockpitPanel.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this._cockpitPanel.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this._cockpitPanel.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this._cockpitPanel.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(164)))), ((int)(((byte)(224)))));
            this._cockpitPanel.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this._cockpitPanel.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(222)))));
            this._cockpitPanel.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(136)))));
            this._cockpitPanel.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this._cockpitPanel.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this._cockpitPanel.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._cockpitPanel.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(218)))), ((int)(((byte)(250)))));
            this._cockpitPanel.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._cockpitPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._cockpitPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this._cockpitPanel.Image = null;
            this._cockpitPanel.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this._cockpitPanel.Location = new System.Drawing.Point(0, 0);
            this._cockpitPanel.MinimumSize = new System.Drawing.Size(20, 20);
            this._cockpitPanel.Name = "_cockpitPanel";
            this._cockpitPanel.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this._cockpitPanel.ShowExpandIcon = true;
            this._cockpitPanel.Size = new System.Drawing.Size(343, 408);
            this._cockpitPanel.TabIndex = 0;
            this._cockpitPanel.Text = "Cockpit";
            this._cockpitPanel.ToolTipTextCloseIcon = null;
            this._cockpitPanel.ToolTipTextExpandIconPanelCollapsed = null;
            this._cockpitPanel.ToolTipTextExpandIconPanelExpanded = null;
            this._cockpitPanel.CloseClick += new System.EventHandler<System.EventArgs>(this._cockpitPanel_CloseClick);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Transparent;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 408);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(343, 3);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // _ahPanel
            // 
            this._ahPanel.ContextMenuStrip = this.contextMenuStrip1;
            this._ahPanel.Controls.Add(this._artificialHorizon);
            this._ahPanel.Location = new System.Drawing.Point(110, 54);
            this._ahPanel.Name = "_ahPanel";
            this._ahPanel.Size = new System.Drawing.Size(120, 123);
            this._ahPanel.TabIndex = 50;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ts2dah,
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(177, 70);
            // 
            // _ts2dah
            // 
            this._ts2dah.Name = "_ts2dah";
            this._ts2dah.Size = new System.Drawing.Size(176, 22);
            this._ts2dah.Text = "2D artificial horizon";
            this._ts2dah.Click += new System.EventHandler(this._ts2dah_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsFunjet,
            this._tsEasystar,
            this._tsPredator});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem1.Text = "3D artificial horizon";
            // 
            // _tsFunjet
            // 
            this._tsFunjet.Name = "_tsFunjet";
            this._tsFunjet.Size = new System.Drawing.Size(127, 22);
            this._tsFunjet.Text = "Funjet";
            this._tsFunjet.Click += new System.EventHandler(this._tsFunjet_Click);
            // 
            // _tsEasystar
            // 
            this._tsEasystar.Name = "_tsEasystar";
            this._tsEasystar.Size = new System.Drawing.Size(127, 22);
            this._tsEasystar.Text = "Easystar";
            this._tsEasystar.Click += new System.EventHandler(this._tsEasystar_Click);
            // 
            // _tsPredator
            // 
            this._tsPredator.Name = "_tsPredator";
            this._tsPredator.Size = new System.Drawing.Size(127, 22);
            this._tsPredator.Text = "Predator";
            this._tsPredator.Click += new System.EventHandler(this._tsPredator_Click);
            // 
            // _artificialHorizon
            // 
            this._artificialHorizon.AutoScroll = true;
            this._artificialHorizon.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this._artificialHorizon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._artificialHorizon.CornersRadius = 20F;
            this._artificialHorizon.Dock = System.Windows.Forms.DockStyle.Fill;
            this._artificialHorizon.Location = new System.Drawing.Point(0, 0);
            this._artificialHorizon.Name = "_artificialHorizon";
            this._artificialHorizon.pitch_angle = 0D;
            this._artificialHorizon.roll_angle = 0D;
            this._artificialHorizon.Size = new System.Drawing.Size(120, 123);
            this._artificialHorizon.TabIndex = 0;
            // 
            // _lblFlightMode
            // 
            this._lblFlightMode.BackColor = System.Drawing.Color.LightGray;
            this._lblFlightMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblFlightMode.Location = new System.Drawing.Point(7, 188);
            this._lblFlightMode.Name = "_lblFlightMode";
            this._lblFlightMode.Size = new System.Drawing.Size(134, 37);
            this._lblFlightMode.TabIndex = 48;
            this._lblFlightMode.Text = "Flight mode";
            this._lblFlightMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(341, 2);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripContainer1.Location = new System.Drawing.Point(1, 21);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(341, 27);
            this.toolStripContainer1.TabIndex = 47;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnConnect,
            this.toolStripSeparator2,
            this._btnCenterUav,
            this.toolStripSeparator3,
            this.toolStripDropDownButton3});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(266, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // _btnConnect
            // 
            this._btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("_btnConnect.Image")));
            this._btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnConnect.Name = "_btnConnect";
            this._btnConnect.Size = new System.Drawing.Size(23, 22);
            this._btnConnect.Text = "_btnConnect";
            this._btnConnect.Click += new System.EventHandler(this._btnConnect_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _btnCenterUav
            // 
            this._btnCenterUav.Image = ((System.Drawing.Image)(resources.GetObject("_btnCenterUav.Image")));
            this._btnCenterUav.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCenterUav.Name = "_btnCenterUav";
            this._btnCenterUav.Size = new System.Drawing.Size(83, 22);
            this._btnCenterUav.Text = "Center UAV";
            this._btnCenterUav.Click += new System.EventHandler(this._btnCenterUav_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ts_basicconfig,
            this._tbn_fullconfig});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(136, 22);
            this.toolStripDropDownButton3.Text = "Module configuration";
            this.toolStripDropDownButton3.ToolTipText = "Module configuration";
            // 
            // _ts_basicconfig
            // 
            this._ts_basicconfig.Name = "_ts_basicconfig";
            this._ts_basicconfig.Size = new System.Drawing.Size(109, 22);
            this._ts_basicconfig.Text = "Basic";
            this._ts_basicconfig.Click += new System.EventHandler(this._ts_basicconfig_Click);
            // 
            // _tbn_fullconfig
            // 
            this._tbn_fullconfig.Name = "_tbn_fullconfig";
            this._tbn_fullconfig.Size = new System.Drawing.Size(109, 22);
            this._tbn_fullconfig.Text = "Full";
            this._tbn_fullconfig.Click += new System.EventHandler(this._tbn_fullconfig_Click);
            // 
            // _pbRcLink
            // 
            this._pbRcLink.ForeColor = System.Drawing.Color.LimeGreen;
            this._pbRcLink.Location = new System.Drawing.Point(39, 123);
            this._pbRcLink.Name = "_pbRcLink";
            this._pbRcLink.Size = new System.Drawing.Size(64, 15);
            this._pbRcLink.Step = 1;
            this._pbRcLink.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this._pbRcLink.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "RC";
            // 
            // _pbLink
            // 
            this._pbLink.ForeColor = System.Drawing.Color.LimeGreen;
            this._pbLink.Location = new System.Drawing.Point(39, 102);
            this._pbLink.Name = "_pbLink";
            this._pbLink.Size = new System.Drawing.Size(64, 15);
            this._pbLink.Step = 1;
            this._pbLink.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this._pbLink.TabIndex = 44;
            this._pbLink.Value = 100;
            // 
            // _lblLink
            // 
            this._lblLink.AutoSize = true;
            this._lblLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblLink.Location = new System.Drawing.Point(5, 103);
            this._lblLink.Name = "_lblLink";
            this._lblLink.Size = new System.Drawing.Size(31, 13);
            this._lblLink.TabIndex = 43;
            this._lblLink.Text = "Link";
            // 
            // _pbGps
            // 
            this._pbGps.BackColor = System.Drawing.SystemColors.Control;
            this._pbGps.ForeColor = System.Drawing.Color.LimeGreen;
            this._pbGps.Location = new System.Drawing.Point(39, 80);
            this._pbGps.Maximum = 10;
            this._pbGps.Name = "_pbGps";
            this._pbGps.Size = new System.Drawing.Size(64, 16);
            this._pbGps.Step = 1;
            this._pbGps.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this._pbGps.TabIndex = 42;
            this._pbGps.Value = 6;
            // 
            // _pbBattery
            // 
            this._pbBattery.ForeColor = System.Drawing.Color.LimeGreen;
            this._pbBattery.Location = new System.Drawing.Point(38, 59);
            this._pbBattery.Name = "_pbBattery";
            this._pbBattery.Size = new System.Drawing.Size(64, 15);
            this._pbBattery.Step = 1;
            this._pbBattery.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this._pbBattery.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Throttle";
            // 
            // _pbThrottle
            // 
            this._pbThrottle.ForeColor = System.Drawing.Color.LimeGreen;
            this._pbThrottle.Location = new System.Drawing.Point(9, 163);
            this._pbThrottle.Name = "_pbThrottle";
            this._pbThrottle.Size = new System.Drawing.Size(91, 14);
            this._pbThrottle.Step = 1;
            this._pbThrottle.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this._pbThrottle.TabIndex = 40;
            // 
            // _lblBlockname
            // 
            this._lblBlockname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblBlockname.Location = new System.Drawing.Point(236, 102);
            this._lblBlockname.Name = "_lblBlockname";
            this._lblBlockname.Size = new System.Drawing.Size(97, 13);
            this._lblBlockname.TabIndex = 36;
            this._lblBlockname.Text = "Block name";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this._panelStrip, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 232);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(343, 179);
            this.tableLayoutPanel3.TabIndex = 35;
            // 
            // _panelStrip
            // 
            this._panelStrip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._panelStrip.Controls.Add(this.label2);
            this._panelStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelStrip.Location = new System.Drawing.Point(3, 3);
            this._panelStrip.Name = "_panelStrip";
            this._panelStrip.Size = new System.Drawing.Size(337, 32);
            this._panelStrip.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(333, 35);
            this.label2.TabIndex = 0;
            this.label2.Text = "Block commands created in the Navigation list will be automatically \r\nadded as bu" +
                "ttons to this strip.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(337, 135);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._zgAlt);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(329, 109);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Altitude";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _zgAlt
            // 
            this._zgAlt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._zgAlt.Dock = System.Windows.Forms.DockStyle.Fill;
            this._zgAlt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._zgAlt.IsAntiAlias = true;
            this._zgAlt.Location = new System.Drawing.Point(3, 3);
            this._zgAlt.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._zgAlt.Name = "_zgAlt";
            this._zgAlt.ScrollGrace = 0D;
            this._zgAlt.ScrollMaxX = 0D;
            this._zgAlt.ScrollMaxY = 0D;
            this._zgAlt.ScrollMaxY2 = 0D;
            this._zgAlt.ScrollMinX = 0D;
            this._zgAlt.ScrollMinY = 0D;
            this._zgAlt.ScrollMinY2 = 0D;
            this._zgAlt.Size = new System.Drawing.Size(323, 103);
            this._zgAlt.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._zgVel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(329, 109);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Speed";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _zgVel
            // 
            this._zgVel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._zgVel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._zgVel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._zgVel.IsAntiAlias = true;
            this._zgVel.Location = new System.Drawing.Point(3, 3);
            this._zgVel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._zgVel.Name = "_zgVel";
            this._zgVel.ScrollGrace = 0D;
            this._zgVel.ScrollMaxX = 0D;
            this._zgVel.ScrollMaxY = 0D;
            this._zgVel.ScrollMaxY2 = 0D;
            this._zgVel.ScrollMinX = 0D;
            this._zgVel.ScrollMinY = 0D;
            this._zgVel.ScrollMinY2 = 0D;
            this._zgVel.Size = new System.Drawing.Size(323, 103);
            this._zgVel.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this._zgBatV);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(329, 109);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Battery voltage";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // _zgBatV
            // 
            this._zgBatV.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._zgBatV.Dock = System.Windows.Forms.DockStyle.Fill;
            this._zgBatV.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._zgBatV.IsAntiAlias = true;
            this._zgBatV.Location = new System.Drawing.Point(3, 3);
            this._zgBatV.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._zgBatV.Name = "_zgBatV";
            this._zgBatV.ScrollGrace = 0D;
            this._zgBatV.ScrollMaxX = 0D;
            this._zgBatV.ScrollMaxY = 0D;
            this._zgBatV.ScrollMaxY2 = 0D;
            this._zgBatV.ScrollMinX = 0D;
            this._zgBatV.ScrollMinY = 0D;
            this._zgBatV.ScrollMinY2 = 0D;
            this._zgBatV.Size = new System.Drawing.Size(323, 103);
            this._zgBatV.TabIndex = 1;
            // 
            // _lblAltitudeAgl
            // 
            this._lblAltitudeAgl.AutoSize = true;
            this._lblAltitudeAgl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblAltitudeAgl.Location = new System.Drawing.Point(229, 209);
            this._lblAltitudeAgl.Name = "_lblAltitudeAgl";
            this._lblAltitudeAgl.Size = new System.Drawing.Size(69, 16);
            this._lblAltitudeAgl.TabIndex = 32;
            this._lblAltitudeAgl.Text = "0 m / 0 m";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(147, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 16);
            this.label9.TabIndex = 31;
            this.label9.Text = "Altitude AGL:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(147, 188);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 16);
            this.label14.TabIndex = 30;
            this.label14.Text = "Ground speed:";
            // 
            // _lblFlightTime
            // 
            this._lblFlightTime.Location = new System.Drawing.Point(236, 59);
            this._lblFlightTime.Name = "_lblFlightTime";
            this._lblFlightTime.Size = new System.Drawing.Size(100, 14);
            this._lblFlightTime.TabIndex = 29;
            this._lblFlightTime.Text = "Flight time: 0s";
            // 
            // _lblTimeInBlock
            // 
            this._lblTimeInBlock.Location = new System.Drawing.Point(236, 121);
            this._lblTimeInBlock.Name = "_lblTimeInBlock";
            this._lblTimeInBlock.Size = new System.Drawing.Size(100, 15);
            this._lblTimeInBlock.TabIndex = 28;
            this._lblTimeInBlock.Text = "Time in block: 0s";
            // 
            // _lblTimeToWp
            // 
            this._lblTimeToWp.Location = new System.Drawing.Point(236, 163);
            this._lblTimeToWp.Name = "_lblTimeToWp";
            this._lblTimeToWp.Size = new System.Drawing.Size(97, 19);
            this._lblTimeToWp.TabIndex = 27;
            this._lblTimeToWp.Text = "Time to WP: 0s";
            // 
            // _lblHomeDistance
            // 
            this._lblHomeDistance.Location = new System.Drawing.Point(236, 79);
            this._lblHomeDistance.Name = "_lblHomeDistance";
            this._lblHomeDistance.Size = new System.Drawing.Size(97, 17);
            this._lblHomeDistance.TabIndex = 26;
            this._lblHomeDistance.Text = "Home: 0m";
            // 
            // _lblDistNextWp
            // 
            this._lblDistNextWp.Location = new System.Drawing.Point(236, 142);
            this._lblDistNextWp.Name = "_lblDistNextWp";
            this._lblDistNextWp.Size = new System.Drawing.Size(97, 15);
            this._lblDistNextWp.TabIndex = 4;
            this._lblDistNextWp.Text = "Next WP: 0 m";
            // 
            // _lblVoltage
            // 
            this._lblVoltage.AutoSize = true;
            this._lblVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblVoltage.Location = new System.Drawing.Point(5, 57);
            this._lblVoltage.Name = "_lblVoltage";
            this._lblVoltage.Size = new System.Drawing.Size(28, 15);
            this._lblVoltage.TabIndex = 3;
            this._lblVoltage.Text = "Bat";
            // 
            // _lblSpeed
            // 
            this._lblSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblSpeed.Location = new System.Drawing.Point(241, 182);
            this._lblSpeed.Name = "_lblSpeed";
            this._lblSpeed.Size = new System.Drawing.Size(65, 29);
            this._lblSpeed.TabIndex = 2;
            this._lblSpeed.Text = "0 km/h";
            this._lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lblGpsSat
            // 
            this._lblGpsSat.AutoSize = true;
            this._lblGpsSat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblGpsSat.ImageKey = "ERROR";
            this._lblGpsSat.Location = new System.Drawing.Point(5, 80);
            this._lblGpsSat.Name = "_lblGpsSat";
            this._lblGpsSat.Size = new System.Drawing.Size(32, 15);
            this._lblGpsSat.TabIndex = 1;
            this._lblGpsSat.Text = "Gps";
            // 
            // _navigationPanel
            // 
            this._navigationPanel.AssociatedSplitter = this.splitter1;
            this._navigationPanel.BackColor = System.Drawing.Color.Transparent;
            this._navigationPanel.CaptionFont = new System.Drawing.Font("Trebuchet MS", 8.75F, System.Drawing.FontStyle.Bold);
            this._navigationPanel.CaptionHeight = 21;
            this._navigationPanel.Controls.Add(this.toolStrip1);
            this._navigationPanel.Controls.Add(this._lv_navigation);
            this._navigationPanel.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(65)))), ((int)(((byte)(118)))));
            this._navigationPanel.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this._navigationPanel.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this._navigationPanel.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this._navigationPanel.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(164)))), ((int)(((byte)(224)))));
            this._navigationPanel.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this._navigationPanel.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(222)))));
            this._navigationPanel.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(136)))));
            this._navigationPanel.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this._navigationPanel.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this._navigationPanel.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._navigationPanel.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(218)))), ((int)(((byte)(250)))));
            this._navigationPanel.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._navigationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._navigationPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this._navigationPanel.Image = null;
            this._navigationPanel.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this._navigationPanel.Location = new System.Drawing.Point(0, 408);
            this._navigationPanel.MinimumSize = new System.Drawing.Size(21, 21);
            this._navigationPanel.Name = "_navigationPanel";
            this._navigationPanel.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this._navigationPanel.ShowExpandIcon = true;
            this._navigationPanel.Size = new System.Drawing.Size(343, 228);
            this._navigationPanel.TabIndex = 2;
            this._navigationPanel.Text = "Navigation";
            this._navigationPanel.ToolTipTextCloseIcon = null;
            this._navigationPanel.ToolTipTextExpandIconPanelCollapsed = null;
            this._navigationPanel.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btn_up,
            this._btn_down,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this._btnAutoSync,
            this._btnNaviBurn});
            this.toolStrip1.Location = new System.Drawing.Point(1, 22);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(341, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _btn_up
            // 
            this._btn_up.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btn_up.Image = ((System.Drawing.Image)(resources.GetObject("_btn_up.Image")));
            this._btn_up.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btn_up.Name = "_btn_up";
            this._btn_up.Size = new System.Drawing.Size(23, 22);
            this._btn_up.Text = "Move up";
            this._btn_up.Click += new System.EventHandler(this._btn_up_Click);
            // 
            // _btn_down
            // 
            this._btn_down.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btn_down.Image = ((System.Drawing.Image)(resources.GetObject("_btn_down.Image")));
            this._btn_down.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btn_down.Name = "_btn_down";
            this._btn_down.Size = new System.Drawing.Size(23, 22);
            this._btn_down.Text = "Move down";
            this._btn_down.Click += new System.EventHandler(this._btn_down_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._nav_open,
            this._nav_save});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(52, 22);
            this.toolStripDropDownButton1.Text = "&File";
            // 
            // _nav_open
            // 
            this._nav_open.Image = ((System.Drawing.Image)(resources.GetObject("_nav_open.Image")));
            this._nav_open.Name = "_nav_open";
            this._nav_open.Size = new System.Drawing.Size(111, 22);
            this._nav_open.Text = "&Open";
            this._nav_open.Click += new System.EventHandler(this._nav_open_Click);
            // 
            // _nav_save
            // 
            this._nav_save.Image = ((System.Drawing.Image)(resources.GetObject("_nav_save.Image")));
            this._nav_save.Name = "_nav_save";
            this._nav_save.Size = new System.Drawing.Size(111, 22);
            this._nav_save.Text = "&Save";
            this._nav_save.Click += new System.EventHandler(this._nav_save_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnNaviRead,
            this._btnNaviWrite,
            this._btnNaviReload});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(55, 22);
            this.toolStripDropDownButton2.Text = "&Uav";
            // 
            // _btnNaviRead
            // 
            this._btnNaviRead.Name = "_btnNaviRead";
            this._btnNaviRead.Size = new System.Drawing.Size(169, 22);
            this._btnNaviRead.Text = "&Read";
            this._btnNaviRead.Click += new System.EventHandler(this._btnNaviRead_Click);
            // 
            // _btnNaviWrite
            // 
            this._btnNaviWrite.Name = "_btnNaviWrite";
            this._btnNaviWrite.Size = new System.Drawing.Size(169, 22);
            this._btnNaviWrite.Text = "&Write";
            this._btnNaviWrite.Click += new System.EventHandler(this._btnNaviWrite_Click);
            // 
            // _btnNaviReload
            // 
            this._btnNaviReload.Name = "_btnNaviReload";
            this._btnNaviReload.Size = new System.Drawing.Size(169, 22);
            this._btnNaviReload.Text = "Re&load from flash";
            this._btnNaviReload.Click += new System.EventHandler(this._btnNaviReload_Click);
            // 
            // _btnAutoSync
            // 
            this._btnAutoSync.CheckOnClick = true;
            this._btnAutoSync.Image = ((System.Drawing.Image)(resources.GetObject("_btnAutoSync.Image")));
            this._btnAutoSync.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnAutoSync.Name = "_btnAutoSync";
            this._btnAutoSync.Size = new System.Drawing.Size(76, 22);
            this._btnAutoSync.Text = "Auto-sync";
            this._btnAutoSync.CheckedChanged += new System.EventHandler(this._btnAutoSync_CheckedChanged);
            // 
            // _btnNaviBurn
            // 
            this._btnNaviBurn.Image = ((System.Drawing.Image)(resources.GetObject("_btnNaviBurn.Image")));
            this._btnNaviBurn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnNaviBurn.Name = "_btnNaviBurn";
            this._btnNaviBurn.Size = new System.Drawing.Size(49, 22);
            this._btnNaviBurn.Text = "Burn";
            this._btnNaviBurn.Click += new System.EventHandler(this._btnNaviBurn_Click);
            // 
            // _lv_navigation
            // 
            this._lv_navigation.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this._lv_navigation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._lv_navigation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this._lv_navigation.FullRowSelect = true;
            this._lv_navigation.GridLines = true;
            this._lv_navigation.HideSelection = false;
            this._lv_navigation.Location = new System.Drawing.Point(1, 50);
            this._lv_navigation.MultiSelect = false;
            this._lv_navigation.Name = "_lv_navigation";
            this._lv_navigation.Size = new System.Drawing.Size(341, 174);
            this._lv_navigation.TabIndex = 0;
            this._lv_navigation.UseCompatibleStateImageBehavior = false;
            this._lv_navigation.View = System.Windows.Forms.View.Details;
            this._lv_navigation.ItemActivate += new System.EventHandler(this._lv_navigation_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Command";
            this.columnHeader2.Width = 272;
            // 
            // _imageListGps
            // 
            this._imageListGps.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageListGps.ImageStream")));
            this._imageListGps.TransparentColor = System.Drawing.Color.Black;
            this._imageListGps.Images.SetKeyName(0, "OK");
            this._imageListGps.Images.SetKeyName(1, "NOK");
            this._imageListGps.Images.SetKeyName(2, "ERROR");
            // 
            // _gmapContextMenuStrip
            // 
            this._gmapContextMenuStrip.Name = "_gmapContextMenuStrip";
            this._gmapContextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // LiveUavPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this._navigationPanel);
            this.Controls.Add(this._cockpitPanel);
            this.Name = "LiveUavPanel";
            this.Size = new System.Drawing.Size(343, 636);
            this._cockpitPanel.ResumeLayout(false);
            this._cockpitPanel.PerformLayout();
            this._ahPanel.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this._panelStrip.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this._navigationPanel.ResumeLayout(false);
            this._navigationPanel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BSE.Windows.Forms.Panel _cockpitPanel;
        private BSE.Windows.Forms.Panel _navigationPanel;
        private ArtificialHorizon.ArtificialHorizon _artificialHorizon;
        private System.Windows.Forms.Label _lblGpsSat;
        private System.Windows.Forms.Label _lblDistNextWp;
        private System.Windows.Forms.Label _lblVoltage;
        private System.Windows.Forms.Label _lblSpeed;
        private System.Windows.Forms.ListView _lv_navigation;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ContextMenuStrip _gmapContextMenuStrip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem _nav_open;
        private System.Windows.Forms.ToolStripMenuItem _nav_save;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem _btnNaviRead;
        private System.Windows.Forms.ToolStripMenuItem _btnNaviWrite;
        private System.Windows.Forms.ToolStripButton _btnAutoSync;
        private System.Windows.Forms.ToolStripButton _btn_up;
        private System.Windows.Forms.ToolStripButton _btn_down;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ImageList _imageListGps;
        private System.Windows.Forms.ToolStripButton _btnNaviBurn;
        private System.Windows.Forms.ToolStripMenuItem _btnNaviReload;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ZedGraph.ZedGraphControl _zgAlt;
        private System.Windows.Forms.Label _lblFlightTime;
        private System.Windows.Forms.Label _lblTimeInBlock;
        private System.Windows.Forms.Label _lblTimeToWp;
        private System.Windows.Forms.Label _lblHomeDistance;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.FlowLayoutPanel _panelStrip;
        private System.Windows.Forms.Label _lblAltitudeAgl;
        private ZedGraph.ZedGraphControl _zgVel;
        private System.Windows.Forms.TabPage tabPage3;
        private ZedGraph.ZedGraphControl _zgBatV;
        private BSE.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label _lblBlockname;
        private System.Windows.Forms.Label label1;
        private ProgressBarColored _pbThrottle;
        private ProgressBarColored _pbGps;
        private ProgressBarColored _pbBattery;
        private System.Windows.Forms.Label _lblLink;
        private ProgressBarColored _pbLink;
        private System.Windows.Forms.Label label2;
        private ProgressBarColored _pbRcLink;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton _btnConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton _btnCenterUav;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label _lblFlightMode;
        private System.Windows.Forms.Panel _ahPanel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _ts2dah;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _tsFunjet;
        private System.Windows.Forms.ToolStripMenuItem _tsEasystar;
        private System.Windows.Forms.ToolStripMenuItem _tsPredator;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem _ts_basicconfig;
        private System.Windows.Forms.ToolStripMenuItem _tbn_fullconfig;
    }
}
