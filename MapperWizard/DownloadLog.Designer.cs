namespace GluonMapper
{
    partial class DownloadLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadLog));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._btnConnected = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._btnReadIndex = new System.Windows.Forms.ToolStripButton();
            this._btnDownload = new System.Windows.Forms.ToolStripButton();
            this._lv_datalogtable = new System.Windows.Forms.ListView();
            this.columnHeaderIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._dgv_datalog = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._pb = new System.Windows.Forms.ToolStripProgressBar();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this._lblStatus = new System.Windows.Forms.Label();
            this.timer_no_data = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgv_datalog)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnConnected,
            this.toolStripSeparator1,
            this._btnReadIndex,
            this._btnDownload});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(297, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _btnConnected
            // 
            this._btnConnected.Image = ((System.Drawing.Image)(resources.GetObject("_btnConnected.Image")));
            this._btnConnected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnConnected.Name = "_btnConnected";
            this._btnConnected.Size = new System.Drawing.Size(69, 35);
            this._btnConnected.Text = "Connected";
            this._btnConnected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // _btnReadIndex
            // 
            this._btnReadIndex.Image = ((System.Drawing.Image)(resources.GetObject("_btnReadIndex.Image")));
            this._btnReadIndex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnReadIndex.Name = "_btnReadIndex";
            this._btnReadIndex.Size = new System.Drawing.Size(68, 35);
            this._btnReadIndex.Text = "Read index";
            this._btnReadIndex.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._btnReadIndex.Click += new System.EventHandler(this._btnReadIndex_Click);
            // 
            // _btnDownload
            // 
            this._btnDownload.Image = ((System.Drawing.Image)(resources.GetObject("_btnDownload.Image")));
            this._btnDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnDownload.Name = "_btnDownload";
            this._btnDownload.Size = new System.Drawing.Size(111, 35);
            this._btnDownload.Text = "Download selected";
            this._btnDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._btnDownload.Click += new System.EventHandler(this._btnDownload_Click);
            // 
            // _lv_datalogtable
            // 
            this._lv_datalogtable.AutoArrange = false;
            this._lv_datalogtable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIndex,
            this.columnHeaderPage,
            this.columnHeaderDate,
            this.columnHeaderTime});
            this._lv_datalogtable.FullRowSelect = true;
            this._lv_datalogtable.GridLines = true;
            this._lv_datalogtable.HideSelection = false;
            this._lv_datalogtable.Location = new System.Drawing.Point(12, 43);
            this._lv_datalogtable.MultiSelect = false;
            this._lv_datalogtable.Name = "_lv_datalogtable";
            this._lv_datalogtable.ShowItemToolTips = true;
            this._lv_datalogtable.Size = new System.Drawing.Size(267, 234);
            this._lv_datalogtable.TabIndex = 4;
            this._lv_datalogtable.UseCompatibleStateImageBehavior = false;
            this._lv_datalogtable.View = System.Windows.Forms.View.Details;
            this._lv_datalogtable.DoubleClick += new System.EventHandler(this._lv_datalogtable_DoubleClick);
            // 
            // columnHeaderIndex
            // 
            this.columnHeaderIndex.Text = "Index";
            this.columnHeaderIndex.Width = 38;
            // 
            // columnHeaderPage
            // 
            this.columnHeaderPage.Text = "Page start";
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Text = "Date       ";
            this.columnHeaderDate.Width = 72;
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "Time       ";
            this.columnHeaderTime.Width = 65;
            // 
            // _dgv_datalog
            // 
            this._dgv_datalog.AllowUserToAddRows = false;
            this._dgv_datalog.AllowUserToDeleteRows = false;
            this._dgv_datalog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._dgv_datalog.Location = new System.Drawing.Point(6, 314);
            this._dgv_datalog.Name = "_dgv_datalog";
            this._dgv_datalog.ReadOnly = true;
            this._dgv_datalog.Size = new System.Drawing.Size(273, 173);
            this._dgv_datalog.TabIndex = 10;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._pb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 305);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(297, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _pb
            // 
            this._pb.AutoSize = false;
            this._pb.Name = "_pb";
            this._pb.Size = new System.Drawing.Size(250, 16);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "connect.png");
            this.imageList.Images.SetKeyName(1, "disconnect.png");
            // 
            // timer
            // 
            this.timer.Interval = 300;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // _lblStatus
            // 
            this._lblStatus.Location = new System.Drawing.Point(12, 284);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(267, 20);
            this._lblStatus.TabIndex = 13;
            this._lblStatus.Text = "...";
            this._lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timer_no_data
            // 
            this.timer_no_data.Interval = 2000;
            this.timer_no_data.Tick += new System.EventHandler(this.timer_no_data_Tick);
            // 
            // DownloadLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 327);
            this.Controls.Add(this._lblStatus);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._dgv_datalog);
            this.Controls.Add(this._lv_datalogtable);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DownloadLog";
            this.Text = "Download gluonpilot datalog";
            this.Activated += new System.EventHandler(this.DownloadLog_Activated);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgv_datalog)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton _btnReadIndex;
        private System.Windows.Forms.ListView _lv_datalogtable;
        private System.Windows.Forms.ColumnHeader columnHeaderIndex;
        private System.Windows.Forms.ColumnHeader columnHeaderPage;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.DataGridView _dgv_datalog;
        private System.Windows.Forms.ToolStripButton _btnDownload;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripProgressBar _pb;
        private System.Windows.Forms.ToolStripButton _btnConnected;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label _lblStatus;
        private System.Windows.Forms.Timer timer_no_data;
    }
}