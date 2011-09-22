namespace GluonCS.LiveUavLayer
{
    partial class SurveyProperties
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
            this.label1 = new System.Windows.Forms.Label();
            this._dtbDistanceM = new Configuration.DistanceTextBox();
            this._dtbAltitudeM = new Configuration.DistanceTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._nudFlightPath = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this._btnBuild = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._nudFlightPath)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Distance between lines";
            // 
            // _dtbDistanceM
            // 
            this._dtbDistanceM.Color = System.Drawing.SystemColors.Window;
            this._dtbDistanceM.DistanceM = 0D;
            this._dtbDistanceM.Location = new System.Drawing.Point(134, 16);
            this._dtbDistanceM.Name = "_dtbDistanceM";
            this._dtbDistanceM.ReadOnly = false;
            this._dtbDistanceM.Size = new System.Drawing.Size(134, 23);
            this._dtbDistanceM.TabIndex = 1;
            this._dtbDistanceM.UseAltitudeColoring = false;
            // 
            // _dtbAltitudeM
            // 
            this._dtbAltitudeM.Color = System.Drawing.SystemColors.Window;
            this._dtbAltitudeM.DistanceM = 0D;
            this._dtbAltitudeM.Location = new System.Drawing.Point(134, 53);
            this._dtbAltitudeM.Name = "_dtbAltitudeM";
            this._dtbAltitudeM.ReadOnly = false;
            this._dtbAltitudeM.Size = new System.Drawing.Size(133, 21);
            this._dtbAltitudeM.TabIndex = 2;
            this._dtbAltitudeM.UseAltitudeColoring = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Altitude above ground";
            // 
            // _nudFlightPath
            // 
            this._nudFlightPath.Location = new System.Drawing.Point(134, 95);
            this._nudFlightPath.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this._nudFlightPath.Name = "_nudFlightPath";
            this._nudFlightPath.Size = new System.Drawing.Size(58, 20);
            this._nudFlightPath.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Flight path angle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "degrees";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(14, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 24);
            this.button1.TabIndex = 6;
            this.button1.Text = "&Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // _btnBuild
            // 
            this._btnBuild.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnBuild.Location = new System.Drawing.Point(177, 137);
            this._btnBuild.Name = "_btnBuild";
            this._btnBuild.Size = new System.Drawing.Size(103, 24);
            this._btnBuild.TabIndex = 6;
            this._btnBuild.Text = "&Build path";
            this._btnBuild.UseVisualStyleBackColor = true;
            this._btnBuild.Click += new System.EventHandler(this.button2_Click);
            // 
            // SurveyProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 173);
            this.Controls.Add(this._btnBuild);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._nudFlightPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._dtbAltitudeM);
            this.Controls.Add(this._dtbDistanceM);
            this.Controls.Add(this.label1);
            this.Name = "SurveyProperties";
            this.Text = "Survey properties";
            ((System.ComponentModel.ISupportInitialize)(this._nudFlightPath)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Configuration.DistanceTextBox _dtbDistanceM;
        private Configuration.DistanceTextBox _dtbAltitudeM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown _nudFlightPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button _btnBuild;
    }
}