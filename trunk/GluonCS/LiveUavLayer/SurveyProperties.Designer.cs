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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SurveyProperties));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._nudFlightPath = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this._btnBuild = new System.Windows.Forms.Button();
            this._dtbAltitudeM = new Configuration.DistanceTextBox();
            this._dtbDistanceM = new Configuration.DistanceTextBox();
            this._cbTriggerCommands = new System.Windows.Forms.CheckBox();
            this.surveyAngle1 = new GluonCS.LiveUavLayer.SurveyAngle();
            this._cbCross = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this._nudFlightPath)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // _nudFlightPath
            // 
            resources.ApplyResources(this._nudFlightPath, "_nudFlightPath");
            this._nudFlightPath.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this._nudFlightPath.Name = "_nudFlightPath";
            this._nudFlightPath.ValueChanged += new System.EventHandler(this._nudFlightPath_ValueChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // _btnBuild
            // 
            this._btnBuild.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this._btnBuild, "_btnBuild");
            this._btnBuild.Name = "_btnBuild";
            this._btnBuild.UseVisualStyleBackColor = true;
            this._btnBuild.Click += new System.EventHandler(this.button2_Click);
            // 
            // _dtbAltitudeM
            // 
            this._dtbAltitudeM.Color = System.Drawing.SystemColors.Window;
            this._dtbAltitudeM.DistanceM = 0D;
            resources.ApplyResources(this._dtbAltitudeM, "_dtbAltitudeM");
            this._dtbAltitudeM.Name = "_dtbAltitudeM";
            this._dtbAltitudeM.ReadOnly = false;
            this._dtbAltitudeM.UseAltitudeColoring = false;
            // 
            // _dtbDistanceM
            // 
            this._dtbDistanceM.Color = System.Drawing.SystemColors.Window;
            this._dtbDistanceM.DistanceM = 0D;
            resources.ApplyResources(this._dtbDistanceM, "_dtbDistanceM");
            this._dtbDistanceM.Name = "_dtbDistanceM";
            this._dtbDistanceM.ReadOnly = false;
            this._dtbDistanceM.UseAltitudeColoring = false;
            // 
            // _cbTriggerCommands
            // 
            resources.ApplyResources(this._cbTriggerCommands, "_cbTriggerCommands");
            this._cbTriggerCommands.Name = "_cbTriggerCommands";
            this._cbTriggerCommands.UseVisualStyleBackColor = true;
            // 
            // surveyAngle1
            // 
            this.surveyAngle1.Angle = 0D;
            this.surveyAngle1.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.surveyAngle1, "surveyAngle1");
            this.surveyAngle1.Name = "surveyAngle1";
            // 
            // _cbCross
            // 
            resources.ApplyResources(this._cbCross, "_cbCross");
            this._cbCross.Name = "_cbCross";
            this._cbCross.UseVisualStyleBackColor = true;
            // 
            // SurveyProperties
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._cbCross);
            this.Controls.Add(this._cbTriggerCommands);
            this.Controls.Add(this.surveyAngle1);
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
        private SurveyAngle surveyAngle1;
        private System.Windows.Forms.CheckBox _cbTriggerCommands;
        private System.Windows.Forms.CheckBox _cbCross;
    }
}