namespace GluonCS.LiveUavLayer
{
    partial class WriteNavigationCommandsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WriteNavigationCommandsWindow));
            this._btn_cancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this._tmr_roll = new System.Windows.Forms.Timer(this.components);
            this._lbl_info = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _btn_cancel
            // 
            this._btn_cancel.Location = new System.Drawing.Point(106, 71);
            this._btn_cancel.Name = "_btn_cancel";
            this._btn_cancel.Size = new System.Drawing.Size(75, 23);
            this._btn_cancel.TabIndex = 0;
            this._btn_cancel.Text = "Cancel";
            this._btn_cancel.UseVisualStyleBackColor = true;
            this._btn_cancel.Click += new System.EventHandler(this._btn_cancel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 29);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.White;
            this.imageList.Images.SetKeyName(0, "arrow-circle.png");
            this.imageList.Images.SetKeyName(1, "arrow-circle-135.png");
            this.imageList.Images.SetKeyName(2, "arrow-circle-225.png");
            this.imageList.Images.SetKeyName(3, "arrow-circle-315.png");
            this.imageList.Images.SetKeyName(4, "tick.png");
            // 
            // _tmr_roll
            // 
            this._tmr_roll.Interval = 500;
            this._tmr_roll.Tick += new System.EventHandler(this._tmr_roll_Tick);
            // 
            // _lbl_info
            // 
            this._lbl_info.Location = new System.Drawing.Point(62, 19);
            this._lbl_info.Name = "_lbl_info";
            this._lbl_info.Size = new System.Drawing.Size(170, 29);
            this._lbl_info.TabIndex = 2;
            this._lbl_info.Text = "...";
            this._lbl_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WriteNavigationCommandsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 106);
            this.ControlBox = false;
            this.Controls.Add(this._lbl_info);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this._btn_cancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WriteNavigationCommandsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Synchronizing script";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btn_cancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Timer _tmr_roll;
        private System.Windows.Forms.Label _lbl_info;
    }
}