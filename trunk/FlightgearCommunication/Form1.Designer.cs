namespace Simulation
{
    partial class Form1
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
            this._btnStart = new System.Windows.Forms.Button();
            this._btnRead = new System.Windows.Forms.Button();
            this.artificialHorizon1 = new ArtificialHorizon.ArtificialHorizon();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // _btnStart
            // 
            this._btnStart.Location = new System.Drawing.Point(103, 65);
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(75, 23);
            this._btnStart.TabIndex = 0;
            this._btnStart.Text = "Start";
            this._btnStart.UseVisualStyleBackColor = true;
            this._btnStart.Click += new System.EventHandler(this._btnStart_Click);
            // 
            // _btnRead
            // 
            this._btnRead.Location = new System.Drawing.Point(103, 106);
            this._btnRead.Name = "_btnRead";
            this._btnRead.Size = new System.Drawing.Size(75, 23);
            this._btnRead.TabIndex = 1;
            this._btnRead.Text = "Read";
            this._btnRead.UseVisualStyleBackColor = true;
            this._btnRead.Click += new System.EventHandler(this._btnRead_Click);
            // 
            // artificialHorizon1
            // 
            this.artificialHorizon1.AutoScroll = true;
            this.artificialHorizon1.CornersRadius = 30F;
            this.artificialHorizon1.Location = new System.Drawing.Point(82, 135);
            this.artificialHorizon1.Name = "artificialHorizon1";
            this.artificialHorizon1.pitch_angle = 0D;
            this.artificialHorizon1.roll_angle = 0D;
            this.artificialHorizon1.Size = new System.Drawing.Size(120, 119);
            this.artificialHorizon1.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // hScrollBar
            // 
            this.hScrollBar.Location = new System.Drawing.Point(13, 9);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(270, 34);
            this.hScrollBar.TabIndex = 3;
            this.hScrollBar.Value = 50;
            // 
            // vScrollBar
            // 
            this.vScrollBar.Location = new System.Drawing.Point(247, 48);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(36, 206);
            this.vScrollBar.TabIndex = 4;
            this.vScrollBar.Value = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.artificialHorizon1);
            this.Controls.Add(this._btnRead);
            this.Controls.Add(this._btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnStart;
        private System.Windows.Forms.Button _btnRead;
        private ArtificialHorizon.ArtificialHorizon artificialHorizon1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.VScrollBar vScrollBar;
    }
}

