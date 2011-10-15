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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._tbUavName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this._cbUavAltSpeed = new System.Windows.Forms.CheckBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
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
            this.label9 = new System.Windows.Forms.Label();
            this._dtb_altitude = new Configuration.DistanceTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this._dtb_radius = new Configuration.DistanceTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(266, 240);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._dtb_radius);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this._dtb_altitude);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this._tbUavName);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this._cbUavAltSpeed);
            this.tabPage2.Controls.Add(this.comboBox3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(258, 214);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "General";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _tbUavName
            // 
            this._tbUavName.Location = new System.Drawing.Point(74, 69);
            this._tbUavName.Name = "_tbUavName";
            this._tbUavName.Size = new System.Drawing.Size(155, 20);
            this._tbUavName.TabIndex = 5;
            this._tbUavName.TextChanged += new System.EventHandler(this._tbUavName_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Uav name";
            // 
            // _cbUavAltSpeed
            // 
            this._cbUavAltSpeed.AutoSize = true;
            this._cbUavAltSpeed.Location = new System.Drawing.Point(9, 38);
            this._cbUavAltSpeed.Name = "_cbUavAltSpeed";
            this._cbUavAltSpeed.Size = new System.Drawing.Size(198, 17);
            this._cbUavAltSpeed.TabIndex = 3;
            this._cbUavAltSpeed.Text = "Show speed and altitude under UAV";
            this._cbUavAltSpeed.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            this.comboBox3.Enabled = false;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "km/h",
            "mph"});
            this.comboBox3.Location = new System.Drawing.Point(135, 11);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(94, 21);
            this.comboBox3.TabIndex = 1;
            this.comboBox3.Text = "km/h";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Used measurement units";
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
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(258, 214);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Map";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _mtbPasswdProxy
            // 
            this._mtbPasswdProxy.Location = new System.Drawing.Point(183, 170);
            this._mtbPasswdProxy.Name = "_mtbPasswdProxy";
            this._mtbPasswdProxy.Size = new System.Drawing.Size(56, 20);
            this._mtbPasswdProxy.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(133, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Passwd:";
            // 
            // _tbLoginProxy
            // 
            this._tbLoginProxy.Location = new System.Drawing.Point(63, 170);
            this._tbLoginProxy.Name = "_tbLoginProxy";
            this._tbLoginProxy.Size = new System.Drawing.Size(64, 20);
            this._tbLoginProxy.TabIndex = 11;
            // 
            // _tbAddressproxy
            // 
            this._tbAddressproxy.Location = new System.Drawing.Point(63, 144);
            this._tbAddressproxy.Name = "_tbAddressproxy";
            this._tbAddressproxy.Size = new System.Drawing.Size(176, 20);
            this._tbAddressproxy.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Login:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Address:";
            // 
            // _cbUseProxy
            // 
            this._cbUseProxy.AutoSize = true;
            this._cbUseProxy.Location = new System.Drawing.Point(9, 123);
            this._cbUseProxy.Name = "_cbUseProxy";
            this._cbUseProxy.Size = new System.Drawing.Size(73, 17);
            this._cbUseProxy.TabIndex = 7;
            this._cbUseProxy.Text = "Use proxy";
            this._cbUseProxy.UseVisualStyleBackColor = true;
            // 
            // _tbCacheSize
            // 
            this._tbCacheSize.Location = new System.Drawing.Point(76, 72);
            this._tbCacheSize.Name = "_tbCacheSize";
            this._tbCacheSize.ReadOnly = true;
            this._tbCacheSize.Size = new System.Drawing.Size(83, 20);
            this._tbCacheSize.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cache size:";
            // 
            // _btnClearCache
            // 
            this._btnClearCache.Location = new System.Drawing.Point(165, 70);
            this._btnClearCache.Name = "_btnClearCache";
            this._btnClearCache.Size = new System.Drawing.Size(74, 23);
            this._btnClearCache.TabIndex = 4;
            this._btnClearCache.Text = "Clear cache";
            this._btnClearCache.UseVisualStyleBackColor = true;
            this._btnClearCache.Click += new System.EventHandler(this._btnClearCache_Click);
            // 
            // _cbCacheMode
            // 
            this._cbCacheMode.FormattingEnabled = true;
            this._cbCacheMode.Location = new System.Drawing.Point(76, 40);
            this._cbCacheMode.Name = "_cbCacheMode";
            this._cbCacheMode.Size = new System.Drawing.Size(163, 21);
            this._cbCacheMode.TabIndex = 3;
            this._cbCacheMode.DropDownClosed += new System.EventHandler(this._cbCacheMode_DropDownClosed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cache mode:";
            // 
            // _cbMapType
            // 
            this._cbMapType.FormattingEnabled = true;
            this._cbMapType.Location = new System.Drawing.Point(76, 7);
            this._cbMapType.Name = "_cbMapType";
            this._cbMapType.Size = new System.Drawing.Size(163, 21);
            this._cbMapType.TabIndex = 1;
            this._cbMapType.SelectedIndexChanged += new System.EventHandler(this._cbMapType_SelectedIndexChanged);
            this._cbMapType.DropDownClosed += new System.EventHandler(this._cbMapType_DropDownClosed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Map type:";
            // 
            // _btnOk
            // 
            this._btnOk.Location = new System.Drawing.Point(199, 258);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(75, 23);
            this._btnOk.TabIndex = 1;
            this._btnOk.Text = "Save";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(12, 258);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 2;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Default altitude";
            // 
            // _dtb_altitude
            // 
            this._dtb_altitude.Color = System.Drawing.SystemColors.Window;
            this._dtb_altitude.DistanceM = 0D;
            this._dtb_altitude.Location = new System.Drawing.Point(90, 105);
            this._dtb_altitude.Name = "_dtb_altitude";
            this._dtb_altitude.ReadOnly = false;
            this._dtb_altitude.Size = new System.Drawing.Size(108, 24);
            this._dtb_altitude.TabIndex = 7;
            this._dtb_altitude.UseAltitudeColoring = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Default circle radius";
            // 
            // _dtb_radius
            // 
            this._dtb_radius.Color = System.Drawing.SystemColors.Window;
            this._dtb_radius.DistanceM = 0D;
            this._dtb_radius.Location = new System.Drawing.Point(112, 135);
            this._dtb_radius.Name = "_dtb_radius";
            this._dtb_radius.ReadOnly = false;
            this._dtb_radius.Size = new System.Drawing.Size(108, 24);
            this._dtb_radius.TabIndex = 9;
            this._dtb_radius.UseAltitudeColoring = false;
            // 
            // Setup
            // 
            this.AcceptButton = this._btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(290, 293);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Setup";
            this.Text = "Setup";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
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
        private System.Windows.Forms.ComboBox comboBox3;
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
    }
}