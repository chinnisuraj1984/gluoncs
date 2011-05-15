using System;
using System.Windows.Forms;
using System.Drawing;

public class ProgressBarColored : ProgressBar
{
    private SolidBrush brush = null;
    public string Text = "";

    public ProgressBarColored()
    {
        this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        string s;
        if (brush == null || brush.Color != this.ForeColor)
            brush = new SolidBrush(this.ForeColor);

        Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);
        if (ProgressBarRenderer.IsSupported)
            ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);
        rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
        rec.Height = rec.Height - 4;
        e.Graphics.FillRectangle(brush, 2, 2, rec.Width, rec.Height);

        if (Text.Length == 0 && this.Maximum == 100)
            s = "" + this.Value + "%";
        else if (Text.Length == 0)
            s = this.Value.ToString();
        else
            s = Text;
        SizeF sf1 = e.Graphics.MeasureString(s, new Font(FontFamily.GenericSansSerif, 8));
        e.Graphics.DrawString(s, new Font(FontFamily.GenericSansSerif, 8), Brushes.Black, this.Width / 2 - sf1.Width / 2, 1 + this.Height / 2 - sf1.Height / 2);

    }
}