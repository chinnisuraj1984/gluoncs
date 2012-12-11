namespace GluonCS
{
    partial class Inputbox
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this._pnl_main_instruction = new System.Windows.Forms.Panel();
            this._lblLine1 = new System.Windows.Forms.Label();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._lblLine2 = new System.Windows.Forms.Label();
            this._dtb1 = new Configuration.DistanceTextBox();
            this._dtb2 = new Configuration.DistanceTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(8, 8);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(32, 32);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // _pnl_main_instruction
            // 
            this._pnl_main_instruction.Location = new System.Drawing.Point(0, 0);
            this._pnl_main_instruction.Name = "_pnl_main_instruction";
            this._pnl_main_instruction.Size = new System.Drawing.Size(383, 62);
            this._pnl_main_instruction.TabIndex = 1;
            this._pnl_main_instruction.Paint += new System.Windows.Forms.PaintEventHandler(this._pnl_main_instruction_Paint);
            // 
            // _lblLine1
            // 
            this._lblLine1.AutoSize = true;
            this._lblLine1.Location = new System.Drawing.Point(44, 52);
            this._lblLine1.Name = "_lblLine1";
            this._lblLine1.Size = new System.Drawing.Size(35, 13);
            this._lblLine1.TabIndex = 2;
            this._lblLine1.Text = "label1";
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(295, 126);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 3;
            this._btnCancel.Text = "&Annuleren";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.Location = new System.Drawing.Point(214, 126);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 4;
            this._btnOK.Text = "&Ok";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Location = new System.Drawing.Point(0, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 50);
            this.panel1.TabIndex = 5;
            // 
            // _lblLine2
            // 
            this._lblLine2.AutoSize = true;
            this._lblLine2.Location = new System.Drawing.Point(200, 52);
            this._lblLine2.Name = "_lblLine2";
            this._lblLine2.Size = new System.Drawing.Size(35, 13);
            this._lblLine2.TabIndex = 6;
            this._lblLine2.Text = "label1";
            // 
            // _dtb1
            // 
            this._dtb1.Color = System.Drawing.SystemColors.Window;
            this._dtb1.DistanceM = 0D;
            this._dtb1.Location = new System.Drawing.Point(47, 68);
            this._dtb1.Name = "_dtb1";
            this._dtb1.ReadOnly = false;
            this._dtb1.Size = new System.Drawing.Size(99, 21);
            this._dtb1.TabIndex = 7;
            this._dtb1.UseAltitudeColoring = false;
            // 
            // _dtb2
            // 
            this._dtb2.Color = System.Drawing.SystemColors.Window;
            this._dtb2.DistanceM = 0D;
            this._dtb2.Location = new System.Drawing.Point(203, 68);
            this._dtb2.Name = "_dtb2";
            this._dtb2.ReadOnly = false;
            this._dtb2.Size = new System.Drawing.Size(99, 21);
            this._dtb2.TabIndex = 8;
            this._dtb2.UseAltitudeColoring = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(0, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(383, 1);
            this.panel2.TabIndex = 9;
            // 
            // Inputbox
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(382, 161);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this._dtb2);
            this.Controls.Add(this._dtb1);
            this.Controls.Add(this._lblLine2);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._lblLine1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this._pnl_main_instruction);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inputbox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inputbox";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel _pnl_main_instruction;
        private System.Windows.Forms.Label _lblLine1;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _lblLine2;
        private Configuration.DistanceTextBox _dtb1;
        private Configuration.DistanceTextBox _dtb2;
        private System.Windows.Forms.Panel panel2;
    }
}