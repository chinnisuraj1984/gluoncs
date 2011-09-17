namespace GluonCS
{
    partial class ReplayControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplayControl));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._btn_play = new System.Windows.Forms.ToolStripButton();
            this._btn_pauze = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._btn_double_speed = new System.Windows.Forms.ToolStripButton();
            this._btn_quad_speed = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btn_play,
            this._btn_pauze,
            this.toolStripSeparator1,
            this._btn_double_speed,
            this._btn_quad_speed});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(158, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _btn_play
            // 
            this._btn_play.Checked = true;
            this._btn_play.CheckState = System.Windows.Forms.CheckState.Checked;
            this._btn_play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btn_play.Image = ((System.Drawing.Image)(resources.GetObject("_btn_play.Image")));
            this._btn_play.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btn_play.Name = "_btn_play";
            this._btn_play.Size = new System.Drawing.Size(23, 22);
            this._btn_play.Text = "toolStripButton1";
            this._btn_play.ToolTipText = "Play";
            this._btn_play.Click += new System.EventHandler(this._btn_play_Click);
            // 
            // _btn_pauze
            // 
            this._btn_pauze.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btn_pauze.Image = ((System.Drawing.Image)(resources.GetObject("_btn_pauze.Image")));
            this._btn_pauze.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btn_pauze.Name = "_btn_pauze";
            this._btn_pauze.Size = new System.Drawing.Size(23, 22);
            this._btn_pauze.Text = "toolStripButton2";
            this._btn_pauze.ToolTipText = "Pause";
            this._btn_pauze.Click += new System.EventHandler(this._btn_pauze_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _btn_double_speed
            // 
            this._btn_double_speed.Image = ((System.Drawing.Image)(resources.GetObject("_btn_double_speed.Image")));
            this._btn_double_speed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btn_double_speed.Name = "_btn_double_speed";
            this._btn_double_speed.Size = new System.Drawing.Size(39, 22);
            this._btn_double_speed.Text = "2x";
            this._btn_double_speed.ToolTipText = "Play at double speed";
            this._btn_double_speed.Click += new System.EventHandler(this._btn_double_speed_Click);
            // 
            // _btn_quad_speed
            // 
            this._btn_quad_speed.Image = ((System.Drawing.Image)(resources.GetObject("_btn_quad_speed.Image")));
            this._btn_quad_speed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btn_quad_speed.Name = "_btn_quad_speed";
            this._btn_quad_speed.Size = new System.Drawing.Size(39, 22);
            this._btn_quad_speed.Text = "4x";
            this._btn_quad_speed.ToolTipText = "Play at 4x normal speed";
            this._btn_quad_speed.Click += new System.EventHandler(this._btn_quad_speed_Click);
            // 
            // ReplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(158, 25);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ReplayControl";
            this.Text = "ReplayControl";
            this.TopMost = true;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton _btn_play;
        private System.Windows.Forms.ToolStripButton _btn_pauze;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _btn_double_speed;
        private System.Windows.Forms.ToolStripButton _btn_quad_speed;
    }
}