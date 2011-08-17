namespace GluonCS
{
    partial class GluonCSForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GluonCSForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._btnZoomin = new System.Windows.Forms.ToolStripButton();
            this._btnZoomout = new System.Windows.Forms.ToolStripButton();
            this._gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.splitter3 = new BSE.Windows.Forms.Splitter();
            this.panel4 = new BSE.Windows.Forms.Panel();
            this._tbLog = new System.Windows.Forms.TextBox();
            this.m_cboToolStripRenderer = new System.Windows.Forms.ComboBox();
            this.splitter2 = new BSE.Windows.Forms.Splitter();
            this._layersPanel = new BSE.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._btnOptions = new System.Windows.Forms.ToolStripMenuItem();
            this._gmapContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.liveUavPanel1 = new GluonCS.LiveUavPanel();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            this._layersPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this._gmapContextStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 722);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(849, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._gMapControl);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitter3);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel4);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitter2);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._layersPanel);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(849, 698);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(849, 722);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnZoomin,
            this._btnZoomout});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(24, 57);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _btnZoomin
            // 
            this._btnZoomin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnZoomin.Image = ((System.Drawing.Image)(resources.GetObject("_btnZoomin.Image")));
            this._btnZoomin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnZoomin.Name = "_btnZoomin";
            this._btnZoomin.Size = new System.Drawing.Size(22, 20);
            this._btnZoomin.Text = "Zoom in";
            this._btnZoomin.Click += new System.EventHandler(this._btnZoomin_Click);
            // 
            // _btnZoomout
            // 
            this._btnZoomout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnZoomout.Image = ((System.Drawing.Image)(resources.GetObject("_btnZoomout.Image")));
            this._btnZoomout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnZoomout.Name = "_btnZoomout";
            this._btnZoomout.Size = new System.Drawing.Size(22, 20);
            this._btnZoomout.Text = "Zoom out";
            this._btnZoomout.ToolTipText = "Zoom out";
            this._btnZoomout.Click += new System.EventHandler(this._btnZoomout_Click);
            // 
            // _gMapControl
            // 
            this._gMapControl.Bearing = 0F;
            this._gMapControl.CanDragMap = true;
            this._gMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gMapControl.GrayScaleMode = false;
            this._gMapControl.LevelsKeepInMemmory = 5;
            this._gMapControl.Location = new System.Drawing.Point(0, 0);
            this._gMapControl.MapType = GMap.NET.MapType.GoogleHybrid;
            this._gMapControl.MarkersEnabled = true;
            this._gMapControl.MaxZoom = 20;
            this._gMapControl.MinZoom = 1;
            this._gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this._gMapControl.Name = "_gMapControl";
            this._gMapControl.PolygonsEnabled = true;
            this._gMapControl.Position = ((GMap.NET.PointLatLng)(resources.GetObject("_gMapControl.Position")));
            this._gMapControl.RetryLoadTile = 0;
            this._gMapControl.RoutesEnabled = true;
            this._gMapControl.ShowTileGridLines = false;
            this._gMapControl.Size = new System.Drawing.Size(495, 595);
            this._gMapControl.TabIndex = 4;
            this._gMapControl.Zoom = 5D;
            // 
            // splitter3
            // 
            this.splitter3.BackColor = System.Drawing.Color.Transparent;
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter3.Location = new System.Drawing.Point(0, 595);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(495, 3);
            this.splitter3.TabIndex = 3;
            this.splitter3.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.AssociatedSplitter = this.splitter3;
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.CaptionFont = new System.Drawing.Font("Trebuchet MS", 12.5F, System.Drawing.FontStyle.Bold);
            this.panel4.CaptionHeight = 27;
            this.panel4.Controls.Add(this._tbLog);
            this.panel4.Controls.Add(this.m_cboToolStripRenderer);
            this.panel4.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(65)))), ((int)(((byte)(118)))));
            this.panel4.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.panel4.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panel4.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel4.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(164)))), ((int)(((byte)(224)))));
            this.panel4.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.panel4.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(222)))));
            this.panel4.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(136)))));
            this.panel4.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panel4.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panel4.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.panel4.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(218)))), ((int)(((byte)(250)))));
            this.panel4.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel4.Image = null;
            this.panel4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panel4.Location = new System.Drawing.Point(0, 598);
            this.panel4.MinimumSize = new System.Drawing.Size(27, 27);
            this.panel4.Name = "panel4";
            this.panel4.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.panel4.ShowExpandIcon = true;
            this.panel4.Size = new System.Drawing.Size(495, 100);
            this.panel4.TabIndex = 2;
            this.panel4.Text = "Logging";
            this.panel4.ToolTipTextCloseIcon = null;
            this.panel4.ToolTipTextExpandIconPanelCollapsed = null;
            this.panel4.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // _tbLog
            // 
            this._tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tbLog.Location = new System.Drawing.Point(1, 28);
            this._tbLog.Multiline = true;
            this._tbLog.Name = "_tbLog";
            this._tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._tbLog.Size = new System.Drawing.Size(493, 71);
            this._tbLog.TabIndex = 1;
            // 
            // m_cboToolStripRenderer
            // 
            this.m_cboToolStripRenderer.FormattingEnabled = true;
            this.m_cboToolStripRenderer.Location = new System.Drawing.Point(229, 31);
            this.m_cboToolStripRenderer.Name = "m_cboToolStripRenderer";
            this.m_cboToolStripRenderer.Size = new System.Drawing.Size(121, 21);
            this.m_cboToolStripRenderer.TabIndex = 0;
            this.m_cboToolStripRenderer.SelectedIndexChanged += new System.EventHandler(this.m_cboToolStripRenderer_SelectedIndexChanged);
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.Transparent;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(495, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 698);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // _layersPanel
            // 
            this._layersPanel.AssociatedSplitter = this.splitter2;
            this._layersPanel.BackColor = System.Drawing.Color.Transparent;
            this._layersPanel.CaptionFont = new System.Drawing.Font("Trebuchet MS", 12.5F, System.Drawing.FontStyle.Bold);
            this._layersPanel.CaptionHeight = 27;
            this._layersPanel.Controls.Add(this.liveUavPanel1);
            this._layersPanel.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(65)))), ((int)(((byte)(118)))));
            this._layersPanel.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this._layersPanel.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this._layersPanel.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this._layersPanel.CustomColors.CaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(164)))), ((int)(((byte)(224)))));
            this._layersPanel.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this._layersPanel.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(222)))));
            this._layersPanel.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(136)))));
            this._layersPanel.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this._layersPanel.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this._layersPanel.CustomColors.ContentGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._layersPanel.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(218)))), ((int)(((byte)(250)))));
            this._layersPanel.CustomColors.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._layersPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this._layersPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this._layersPanel.Image = null;
            this._layersPanel.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this._layersPanel.Location = new System.Drawing.Point(498, 0);
            this._layersPanel.MinimumSize = new System.Drawing.Size(27, 27);
            this._layersPanel.Name = "_layersPanel";
            this._layersPanel.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this._layersPanel.ShowExpandIcon = true;
            this._layersPanel.Size = new System.Drawing.Size(351, 698);
            this._layersPanel.TabIndex = 0;
            this._layersPanel.Text = "Uav information";
            this._layersPanel.ToolTipTextCloseIcon = null;
            this._layersPanel.ToolTipTextExpandIconPanelCollapsed = null;
            this._layersPanel.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(849, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnOptions});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // _btnOptions
            // 
            this._btnOptions.Name = "_btnOptions";
            this._btnOptions.Size = new System.Drawing.Size(122, 22);
            this._btnOptions.Text = "Options";
            this._btnOptions.Click += new System.EventHandler(this._btnOptions_Click);
            // 
            // _gmapContextStrip
            // 
            this._gmapContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomToolStripMenuItem,
            this.zoomoutToolStripMenuItem,
            this.toolStripSeparator1});
            this._gmapContextStrip.Name = "_gmapContextStrip";
            this._gmapContextStrip.Size = new System.Drawing.Size(131, 54);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.zoomToolStripMenuItem.Text = "&Zoom";
            // 
            // zoomoutToolStripMenuItem
            // 
            this.zoomoutToolStripMenuItem.Name = "zoomoutToolStripMenuItem";
            this.zoomoutToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.zoomoutToolStripMenuItem.Text = "Zoom &out";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // liveUavPanel1
            // 
            this.liveUavPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.liveUavPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.liveUavPanel1.Location = new System.Drawing.Point(1, 28);
            this.liveUavPanel1.Name = "liveUavPanel1";
            this.liveUavPanel1.Size = new System.Drawing.Size(349, 669);
            this.liveUavPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 744);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Gluon Control Station";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this._layersPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this._gmapContextStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private BSE.Windows.Forms.Splitter splitter3;
        private BSE.Windows.Forms.Panel panel4;
        private BSE.Windows.Forms.Splitter splitter2;
        private GMap.NET.WindowsForms.GMapControl _gMapControl;
        private BSE.Windows.Forms.Panel _layersPanel;
        private System.Windows.Forms.ContextMenuStrip _gmapContextStrip;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ComboBox m_cboToolStripRenderer;
        private LiveUavPanel liveUavPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton _btnZoomin;
        private System.Windows.Forms.ToolStripButton _btnZoomout;
        private System.Windows.Forms.ToolStripMenuItem _btnOptions;
        private System.Windows.Forms.TextBox _tbLog;
    }
}

