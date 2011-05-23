namespace Configuration
{
    partial class NavigationInstructionEdit
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
            this._btn_ok = new System.Windows.Forms.Button();
            this._btn_cancel = new System.Windows.Forms.Button();
            this._cb_opcode = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // _btn_ok
            // 
            this._btn_ok.Location = new System.Drawing.Point(368, 233);
            this._btn_ok.Name = "_btn_ok";
            this._btn_ok.Size = new System.Drawing.Size(75, 23);
            this._btn_ok.TabIndex = 0;
            this._btn_ok.Text = "Ok";
            this._btn_ok.UseVisualStyleBackColor = true;
            this._btn_ok.Click += new System.EventHandler(this._btn_ok_Click);
            // 
            // _btn_cancel
            // 
            this._btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btn_cancel.Location = new System.Drawing.Point(22, 233);
            this._btn_cancel.Name = "_btn_cancel";
            this._btn_cancel.Size = new System.Drawing.Size(75, 23);
            this._btn_cancel.TabIndex = 1;
            this._btn_cancel.Text = "Cancel";
            this._btn_cancel.UseVisualStyleBackColor = true;
            this._btn_cancel.Click += new System.EventHandler(this._btn_cancel_Click);
            // 
            // _cb_opcode
            // 
            this._cb_opcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cb_opcode.FormattingEnabled = true;
            this._cb_opcode.Items.AddRange(new object[] {
            "EMPTY",
            "GOTO",
            "CLIMB",
            "FROM_TO",
            "FLY_TO",
            "CIRCLE",
            "IF",
            "UNTIL()",
            "SERVO_SET(channel, position_us)",
            "SERVO_TRIGGER(channel, position_us, hold_sec)",
            "BLOCK"});
            this._cb_opcode.Location = new System.Drawing.Point(22, 12);
            this._cb_opcode.Name = "_cb_opcode";
            this._cb_opcode.Size = new System.Drawing.Size(205, 21);
            this._cb_opcode.TabIndex = 6;
            this._cb_opcode.SelectedIndexChanged += new System.EventHandler(this._cb_opcode_SelectedIndexChanged);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Location = new System.Drawing.Point(22, 39);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(0, 0);
            this.tableLayoutPanel.TabIndex = 10;
            // 
            // NavigationInstructionEdit
            // 
            this.AcceptButton = this._btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btn_cancel;
            this.ClientSize = new System.Drawing.Size(457, 268);
            this.Controls.Add(this._cb_opcode);
            this.Controls.Add(this._btn_ok);
            this.Controls.Add(this._btn_cancel);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NavigationInstructionEdit";
            this.Text = "Edit navigation instruction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btn_ok;
        private System.Windows.Forms.Button _btn_cancel;
        private System.Windows.Forms.ComboBox _cb_opcode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    }
}