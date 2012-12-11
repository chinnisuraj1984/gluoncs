using GluonCS.LiveUavLayer;

namespace GluonCS
{
    partial class GluonCSFormSwallow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GluonCSFormSwallow));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._btnZoomin = new System.Windows.Forms.ToolStripButton();
            this._btnZoomout = new System.Windows.Forms.ToolStripButton();
            this._btnGoto = new System.Windows.Forms.ToolStripButton();
            this._btn_speaker = new System.Windows.Forms.ToolStripButton();
            this._gMapControl = new GluonCS.LiveUavLayer.WindGMapControl();
            this.splitter3 = new BSE.Windows.Forms.Splitter();
            this.splitter2 = new BSE.Windows.Forms.Splitter();
            this._layersPanel = new BSE.Windows.Forms.Panel();
            this.liveUavPanel1 = new GluonCS.LiveUavPanelSwallow();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._gmapContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this._layersPanel.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitter2);
            this.toolStripContainer1.ContentPanel.Controls.Add(this._layersPanel);
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnZoomin,
            this._btnZoomout,
            this._btnGoto,
            this._btn_speaker});
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
            // _btnGoto
            // 
            this._btnGoto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this._btnGoto, "_btnGoto");
            this._btnGoto.Name = "_btnGoto";
            this._btnGoto.Click += new System.EventHandler(this._btnGoto_Click);
            // 
            // _btn_speaker
            // 
            this._btn_speaker.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this._btn_speaker, "_btn_speaker");
            this._btn_speaker.Name = "_btn_speaker";
            this._btn_speaker.Click += new System.EventHandler(this._btn_speaker_Click);
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
            // splitter3
            // 
            this.splitter3.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.splitter3, "splitter3");
            this.splitter3.Name = "splitter3";
            this.splitter3.TabStop = false;
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
            // liveUavPanel1
            // 
            resources.ApplyResources(this.liveUavPanel1, "liveUavPanel1");
            this.liveUavPanel1.Name = "liveUavPanel1";
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "sound_mute.png");
            this.imageList1.Images.SetKeyName(1, "sound.png");
            // 
            // GluonCSFormSwallow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "GluonCSFormSwallow";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this._layersPanel.ResumeLayout(false);
            this._gmapContextStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private BSE.Windows.Forms.Splitter splitter3;
        private BSE.Windows.Forms.Splitter splitter2;
        private WindGMapControl _gMapControl;
        private BSE.Windows.Forms.Panel _layersPanel;
        private System.Windows.Forms.ContextMenuStrip _gmapContextStrip;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private LiveUavPanelSwallow liveUavPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton _btnZoomin;
        private System.Windows.Forms.ToolStripButton _btnZoomout;
        private System.Windows.Forms.ToolStripButton _btnGoto;
        private System.Windows.Forms.ToolStripButton _btn_speaker;
        private System.Windows.Forms.ImageList imageList1;
    }
}

