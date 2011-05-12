namespace Configuration.NavigationCommands
{
    partial class Block
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._tbName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _tbName
            // 
            this._tbName.Location = new System.Drawing.Point(3, 3);
            this._tbName.Name = "_tbName";
            this._tbName.Size = new System.Drawing.Size(195, 20);
            this._tbName.TabIndex = 0;
            // 
            // Block
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tbName);
            this.Name = "Block";
            this.Size = new System.Drawing.Size(201, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _tbName;
    }
}
