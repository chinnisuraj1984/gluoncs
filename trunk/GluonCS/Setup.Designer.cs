namespace GluonCS
{
    partial class Setup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._cbLanguage = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this._cbUseSpeech = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._tbUavName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this._cbUavAltSpeed = new System.Windows.Forms.CheckBox();
            this._cbMeasurementUnit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._mtbPasswdProxy = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._tbLoginProxy = new System.Windows.Forms.TextBox();
            this._tbAddressproxy = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._cbUseProxy = new System.Windows.Forms.CheckBox();
            this._tbCacheSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._btnClearCache = new System.Windows.Forms.Button();
            this._cbCacheMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._cbMapType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._btnOk = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this._tbLogLocation = new System.Windows.Forms.TextBox();
            this._btnBrowseLogmap = new System.Windows.Forms.Button();
            this._cbLogging = new System.Windows.Forms.CheckBox();
            this._dtb_radius = new Configuration.DistanceTextBox();
            this._dtb_altitude = new Configuration.DistanceTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._cbLanguage);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this._cbUseSpeech);
            this.tabPage2.Controls.Add(this._dtb_radius);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this._dtb_altitude);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this._tbUavName);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this._cbUavAltSpeed);
            this.tabPage2.Controls.Add(this._cbMeasurementUnit);
            this.tabPage2.Controls.Add(this.label4);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _cbLanguage
            // 
            this._cbLanguage.FormattingEnabled = true;
            this._cbLanguage.Items.AddRange(new object[] {
            resources.GetString("_cbLanguage.Items"),
            resources.GetString("_cbLanguage.Items1"),
            resources.GetString("_cbLanguage.Items2")});
            resources.ApplyResources(this._cbLanguage, "_cbLanguage");
            this._cbLanguage.Name = "_cbLanguage";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // _cbUseSpeech
            // 
            resources.ApplyResources(this._cbUseSpeech, "_cbUseSpeech");
            this._cbUseSpeech.Name = "_cbUseSpeech";
            this._cbUseSpeech.UseVisualStyleBackColor = true;
            this._cbUseSpeech.CheckedChanged += new System.EventHandler(this._cbUseSpeech_CheckedChanged);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // _tbUavName
            // 
            resources.ApplyResources(this._tbUavName, "_tbUavName");
            this._tbUavName.Name = "_tbUavName";
            this._tbUavName.TextChanged += new System.EventHandler(this._tbUavName_TextChanged);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // _cbUavAltSpeed
            // 
            resources.ApplyResources(this._cbUavAltSpeed, "_cbUavAltSpeed");
            this._cbUavAltSpeed.Name = "_cbUavAltSpeed";
            this._cbUavAltSpeed.UseVisualStyleBackColor = true;
            // 
            // _cbMeasurementUnit
            // 
            this._cbMeasurementUnit.FormattingEnabled = true;
            this._cbMeasurementUnit.Items.AddRange(new object[] {
            resources.GetString("_cbMeasurementUnit.Items"),
            resources.GetString("_cbMeasurementUnit.Items1")});
            resources.ApplyResources(this._cbMeasurementUnit, "_cbMeasurementUnit");
            this._cbMeasurementUnit.Name = "_cbMeasurementUnit";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._mtbPasswdProxy);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this._tbLoginProxy);
            this.tabPage1.Controls.Add(this._tbAddressproxy);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this._cbUseProxy);
            this.tabPage1.Controls.Add(this._tbCacheSize);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this._btnClearCache);
            this.tabPage1.Controls.Add(this._cbCacheMode);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this._cbMapType);
            this.tabPage1.Controls.Add(this.label1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _mtbPasswdProxy
            // 
            resources.ApplyResources(this._mtbPasswdProxy, "_mtbPasswdProxy");
            this._mtbPasswdProxy.Name = "_mtbPasswdProxy";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // _tbLoginProxy
            // 
            resources.ApplyResources(this._tbLoginProxy, "_tbLoginProxy");
            this._tbLoginProxy.Name = "_tbLoginProxy";
            // 
            // _tbAddressproxy
            // 
            resources.ApplyResources(this._tbAddressproxy, "_tbAddressproxy");
            this._tbAddressproxy.Name = "_tbAddressproxy";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // _cbUseProxy
            // 
            resources.ApplyResources(this._cbUseProxy, "_cbUseProxy");
            this._cbUseProxy.Name = "_cbUseProxy";
            this._cbUseProxy.UseVisualStyleBackColor = true;
            // 
            // _tbCacheSize
            // 
            resources.ApplyResources(this._tbCacheSize, "_tbCacheSize");
            this._tbCacheSize.Name = "_tbCacheSize";
            this._tbCacheSize.ReadOnly = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // _btnClearCache
            // 
            resources.ApplyResources(this._btnClearCache, "_btnClearCache");
            this._btnClearCache.Name = "_btnClearCache";
            this._btnClearCache.UseVisualStyleBackColor = true;
            this._btnClearCache.Click += new System.EventHandler(this._btnClearCache_Click);
            // 
            // _cbCacheMode
            // 
            this._cbCacheMode.FormattingEnabled = true;
            resources.ApplyResources(this._cbCacheMode, "_cbCacheMode");
            this._cbCacheMode.Name = "_cbCacheMode";
            this._cbCacheMode.DropDownClosed += new System.EventHandler(this._cbCacheMode_DropDownClosed);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // _cbMapType
            // 
            this._cbMapType.FormattingEnabled = true;
            resources.ApplyResources(this._cbMapType, "_cbMapType");
            this._cbMapType.Name = "_cbMapType";
            this._cbMapType.SelectedIndexChanged += new System.EventHandler(this._cbMapType_SelectedIndexChanged);
            this._cbMapType.DropDownClosed += new System.EventHandler(this._cbMapType_DropDownClosed);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _btnOk
            // 
            resources.ApplyResources(this._btnOk, "_btnOk");
            this._btnOk.Name = "_btnOk";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._btnCancel, "_btnCancel");
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this._cbLogging);
            this.tabPage3.Controls.Add(this._btnBrowseLogmap);
            this.tabPage3.Controls.Add(this._tbLogLocation);
            this.tabPage3.Controls.Add(this.label12);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // _tbLogLocation
            // 
            resources.ApplyResources(this._tbLogLocation, "_tbLogLocation");
            this._tbLogLocation.Name = "_tbLogLocation";
            // 
            // _btnBrowseLogmap
            // 
            resources.ApplyResources(this._btnBrowseLogmap, "_btnBrowseLogmap");
            this._btnBrowseLogmap.Name = "_btnBrowseLogmap";
            this._btnBrowseLogmap.UseVisualStyleBackColor = true;
            this._btnBrowseLogmap.Click += new System.EventHandler(this._btnBrowseLogmap_Click);
            // 
            // _cbLogging
            // 
            resources.ApplyResources(this._cbLogging, "_cbLogging");
            this._cbLogging.Name = "_cbLogging";
            this._cbLogging.UseVisualStyleBackColor = true;
            // 
            // _dtb_radius
            // 
            this._dtb_radius.Color = System.Drawing.SystemColors.Window;
            this._dtb_radius.DistanceM = 0D;
            resources.ApplyResources(this._dtb_radius, "_dtb_radius");
            this._dtb_radius.Name = "_dtb_radius";
            this._dtb_radius.ReadOnly = false;
            this._dtb_radius.UseAltitudeColoring = false;
            // 
            // _dtb_altitude
            // 
            this._dtb_altitude.Color = System.Drawing.SystemColors.Window;
            this._dtb_altitude.DistanceM = 0D;
            resources.ApplyResources(this._dtb_altitude, "_dtb_altitude");
            this._dtb_altitude.Name = "_dtb_altitude";
            this._dtb_altitude.ReadOnly = false;
            this._dtb_altitude.UseAltitudeColoring = false;
            // 
            // Setup
            // 
            this.AcceptButton = this._btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Setup";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox _tbCacheSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _btnClearCache;
        private System.Windows.Forms.ComboBox _cbCacheMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _cbMapType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox _cbUavAltSpeed;
        private System.Windows.Forms.ComboBox _cbMeasurementUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.MaskedTextBox _mtbPasswdProxy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _tbLoginProxy;
        private System.Windows.Forms.TextBox _tbAddressproxy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox _cbUseProxy;
        private System.Windows.Forms.TextBox _tbUavName;
        private System.Windows.Forms.Label label8;
        private Configuration.DistanceTextBox _dtb_altitude;
        private System.Windows.Forms.Label label9;
        private Configuration.DistanceTextBox _dtb_radius;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox _cbUseSpeech;
        private System.Windows.Forms.ComboBox _cbLanguage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox _cbLogging;
        private System.Windows.Forms.Button _btnBrowseLogmap;
        private System.Windows.Forms.TextBox _tbLogLocation;
        private System.Windows.Forms.Label label12;
    }
}