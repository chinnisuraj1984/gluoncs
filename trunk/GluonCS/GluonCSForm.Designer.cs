using GluonCS.LiveUavLayer;
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._btnZoomin = new System.Windows.Forms.ToolStripButton();
            this._btnZoomout = new System.Windows.Forms.ToolStripButton();
            this.splitter3 = new BSE.Windows.Forms.Splitter();
            this.panel4 = new BSE.Windows.Forms.Panel();
            this._tbLog = new System.Windows.Forms.TextBox();
            this.m_cboToolStripRenderer = new System.Windows.Forms.ComboBox();
            this.splitter2 = new BSE.Windows.Forms.Splitter();
            this._layersPanel = new BSE.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._btnOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._gmapContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._gMapControl = new GluonCS.LiveUavLayer.WindGMapControl();
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
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnZoomin,
            this._btnZoomout});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Name = "toolStrip1";
            // 
            // _btnZoomin
            // 
            this._btnZoomin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this._btnZoomin, "_btnZoomin");
            this._btnZoomin.Name = "_btnZoomin";
            this._btnZoomin.Click += new System.EventHandler(this._btnZoomin_Click);
            // 
            // _btnZoomout
            // 
            this._btnZoomout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this._btnZoomout, "_btnZoomout");
            this._btnZoomout.Name = "_btnZoomout";
            this._btnZoomout.Click += new System.EventHandler(this._btnZoomout_Click);
            // 
            // splitter3
            // 
            this.splitter3.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.splitter3, "splitter3");
            this.splitter3.Name = "splitter3";
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
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel4.Image = null;
            this.panel4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panel4.MinimumSize = new System.Drawing.Size(27, 27);
            this.panel4.Name = "panel4";
            this.panel4.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.panel4.ShowExpandIcon = true;
            this.panel4.ToolTipTextCloseIcon = null;
            this.panel4.ToolTipTextExpandIconPanelCollapsed = null;
            this.panel4.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // _tbLog
            // 
            resources.ApplyResources(this._tbLog, "_tbLog");
            this._tbLog.Name = "_tbLog";
            // 
            // m_cboToolStripRenderer
            // 
            this.m_cboToolStripRenderer.FormattingEnabled = true;
            resources.ApplyResources(this.m_cboToolStripRenderer, "m_cboToolStripRenderer");
            this.m_cboToolStripRenderer.Name = "m_cboToolStripRenderer";
            this.m_cboToolStripRenderer.SelectedIndexChanged += new System.EventHandler(this.m_cboToolStripRenderer_SelectedIndexChanged);
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.splitter2, "splitter2");
            this.splitter2.Name = "splitter2";
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
            resources.ApplyResources(this._layersPanel, "_layersPanel");
            this._layersPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this._layersPanel.Image = null;
            this._layersPanel.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this._layersPanel.MinimumSize = new System.Drawing.Size(27, 27);
            this._layersPanel.Name = "_layersPanel";
            this._layersPanel.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this._layersPanel.ShowExpandIcon = true;
            this._layersPanel.ToolTipTextCloseIcon = null;
            this._layersPanel.ToolTipTextExpandIconPanelCollapsed = null;
            this._layersPanel.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnOptions});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // _btnOptions
            // 
            this._btnOptions.Name = "_btnOptions";
            resources.ApplyResources(this._btnOptions, "_btnOptions");
            this._btnOptions.Click += new System.EventHandler(this._btnOptions_Click);
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // _gmapContextStrip
            // 
            this._gmapContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomToolStripMenuItem,
            this.zoomoutToolStripMenuItem,
            this.toolStripSeparator1});
            this._gmapContextStrip.Name = "_gmapContextStrip";
            resources.ApplyResources(this._gmapContextStrip, "_gmapContextStrip");
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            resources.ApplyResources(this.zoomToolStripMenuItem, "zoomToolStripMenuItem");
            // 
            // zoomoutToolStripMenuItem
            // 
            this.zoomoutToolStripMenuItem.Name = "zoomoutToolStripMenuItem";
            resources.ApplyResources(this.zoomoutToolStripMenuItem, "zoomoutToolStripMenuItem");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // _gMapControl
            // 
            this._gMapControl.Bearing = 0F;
            this._gMapControl.CanDragMap = true;
            resources.ApplyResources(this._gMapControl, "_gMapControl");
            this._gMapControl.GrayScaleMode = false;
            this._gMapControl.LevelsKeepInMemmory = 5;
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
            this._gMapControl.Zoom = 5D;
            // 
            // liveUavPanel1
            // 
            resources.ApplyResources(this.liveUavPanel1, "liveUavPanel1");
            this.liveUavPanel1.Name = "liveUavPanel1";
            // 
            // GluonCSForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GluonCSForm";
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
        private WindGMapControl _gMapControl;
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

