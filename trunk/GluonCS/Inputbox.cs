using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GluonCS
{
    public partial class Inputbox : Form
    {
        private string mMainInstruction = "";
        private Font m_mainInstructionFont = new Font("Arial", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        private int m_mainInstructionHeight;

        public double Val1 { get { return _dtb1.DistanceM; } }
        public double Val2 { get { return _dtb2.DistanceM; } }

        public Inputbox(string title, string tekst, string field1, string field2, double value1, double value2)
        {

            InitializeComponent();
            mMainInstruction = tekst;
            this.Text = title;
            _lblLine1.Text = field1;
            _lblLine2.Text = field2;

            _dtb1.DistanceM = value1;
            _dtb2.DistanceM = value2;

            if (field2.Length == 0)
            {
                _lblLine2.Visible = false;
                _dtb2.Visible = false;
            }

            pictureBox.Image = SystemIcons.Question.ToBitmap();
        }


        //--------------------------------------------------------------------------------
        const int MAIN_INSTRUCTION_LEFT_MARGIN = 46;
        const int MAIN_INSTRUCTION_RIGHT_MARGIN = 8;

        SizeF GetMainInstructionTextSizeF()
        {
            SizeF mzSize = new SizeF(_pnl_main_instruction.Width - MAIN_INSTRUCTION_LEFT_MARGIN - MAIN_INSTRUCTION_RIGHT_MARGIN, 5000.0F);
            Graphics g = Graphics.FromHwnd(this.Handle);
            SizeF textSize = g.MeasureString(mMainInstruction, m_mainInstructionFont, mzSize);
            m_mainInstructionHeight = (int)textSize.Height;
            return textSize;
        }

        private void _pnl_main_instruction_Paint(object sender, PaintEventArgs e)
        {
            SizeF szL = GetMainInstructionTextSizeF();
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            e.Graphics.DrawString(mMainInstruction, m_mainInstructionFont, new SolidBrush(Color.DarkBlue), new RectangleF(new PointF(MAIN_INSTRUCTION_LEFT_MARGIN, 10), szL));
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

    }
}
