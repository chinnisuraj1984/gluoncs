namespace GluonCS.LiveUavLayer
{
    partial class ReadNavigationCommandsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadNavigationCommandsWindow));
            this._btn_cancel = new System.Windows.Forms.Button();
            this.lbl_info = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _btn_cancel
            // 
            this._btn_cancel.Location = new System.Drawing.Point(105, 70);
            this._btn_cancel.Name = "_btn_cancel";
            this._btn_cancel.Size = new System.Drawing.Size(75, 23);
            this._btn_cancel.TabIndex = 0;
            this._btn_cancel.Text = "Cancel";
            this._btn_cancel.UseVisualStyleBackColor = true;
            this._btn_cancel.Click += new System.EventHandler(this._btn_cancel_Click);
            // 
            // lbl_info
            // 
            this.lbl_info.Location = new System.Drawing.Point(54, 31);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(183, 23);
            this.lbl_info.TabIndex = 1;
            this.lbl_info.Text = "...";
            this.lbl_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(21, 28);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(62, 38);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "tick.png");
            // 
            // timer
            // 
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ReadNavigationCommandsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 105);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this._btn_cancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReadNavigationCommandsWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Read waypoints";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReadNavigationCommandsWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btn_cancel;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Timer timer;
    }
}