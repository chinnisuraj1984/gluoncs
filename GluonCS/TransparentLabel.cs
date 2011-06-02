using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GluonCS
{
    /// <summary>
  /// A label that can be transparent.
  /// </summary>
  public class TransparentLabel : Control
  {
    /// <summary>
    /// Creates a new <see cref="TransparentLabel"/> instance.
    /// </summary>
    public TransparentLabel()
    {
      TabStop = false;

      //this.SetStyle(
      //    ControlStyles.UserPaint |
      //    ControlStyles.AllPaintingInWmPaint |
      //    ControlStyles.OptimizedDoubleBuffer, true);
    }

    /// <summary>
    /// Gets the creation parameters.
    /// </summary>
    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams cp = base.CreateParams;
        cp.ExStyle |= 0x20;
        return cp;
      }
    }

    /// <summary>
    /// Paints the background.
    /// </summary>
    /// <param name="e">E.</param>
    protected override void OnPaintBackground(PaintEventArgs e)
    {
      // do nothing
      //e.Graphics.DrawImageUnscaled(_backBuffer, 0, 0);
    }

    /// <summary>
    /// Paints the control.
    /// </summary>
    /// <param name="e">E.</param>
    protected override void OnPaint(PaintEventArgs e)
    {
      DrawText();
    }

    public const int WM_ERASEBKGND = 0x0014;
    public const int WM_PAINT = 0x000F;
    public const int WM_NCPAINT = 0x0085;
    protected override void WndProc(ref Message m)
    {
      base.WndProc(ref m);

      if (m.Msg == WM_PAINT || m.Msg == WM_ERASEBKGND || m.Msg == WM_NCPAINT)
      {
        DrawText();
      }
    }

    private Bitmap _backBuffer;
    private void DrawText()
    {
        //if ((DateTime.Now - lastUpdate).TotalMilliseconds > 500)
        //    lastUpdate = DateTime.Now;
        //else
        //{
        //    CreateGraphics().DrawImageUnscaled(_backBuffer, 0, 0);
        //    return;
        //}

        //if (_backBuffer == null)
        //{
        //    _backBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
        //}
        //Graphics graphics = Graphics.FromImage(_backBuffer);

        //graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
        //graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
        //graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

      using (Graphics graphics = CreateGraphics())
      using (SolidBrush brush = new SolidBrush(ForeColor))
      {
          SizeF size = graphics.MeasureString(_text, Font);
        // first figure out the top
        float top = 0;
        switch (textAlign)
        {
          case ContentAlignment.MiddleLeft:
          case ContentAlignment.MiddleCenter:
          case ContentAlignment.MiddleRight:
            top = (Height - size.Height) / 2;
            break;
          case ContentAlignment.BottomLeft:
          case ContentAlignment.BottomCenter:
          case ContentAlignment.BottomRight:
            top = Height - size.Height;
            break;
        }

        float left = -1;
        switch (textAlign)
        {
          case ContentAlignment.TopLeft:
          case ContentAlignment.MiddleLeft:
          case ContentAlignment.BottomLeft:
            if (RightToLeft == RightToLeft.Yes)
              left = Width - size.Width;
            else
              left = -1;
            break;
          case ContentAlignment.TopCenter:
          case ContentAlignment.MiddleCenter:
          case ContentAlignment.BottomCenter:
            left = (Width - size.Width) / 2;
            break;
          case ContentAlignment.TopRight:
          case ContentAlignment.MiddleRight:
          case ContentAlignment.BottomRight:
            if (RightToLeft == RightToLeft.Yes)
              left = -1;
            else
              left = Width - size.Width;
            break;
        }
        graphics.DrawString(_text, Font, brush, left, top);
      }
      //CreateGraphics().DrawImageUnscaled(_backBuffer, 0, 0);
    }

    /// <summary>
    /// Gets or sets the text associated with this control.
    /// </summary>
    /// <returns>
    /// The text associated with this control.
    /// </returns>
    /// 
    private DateTime lastUpdate = DateTime.Now;
    private DateTime lastUpdate2 = DateTime.Now;
    private string _text;
    public override string Text
    {
      get
      {
        return base.Text;
      }
      set
      {
          _text = Text;
          base.Text = value;

          RecreateHandle();

      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// One of the <see cref="T:System.Windows.Forms.RightToLeft"/> values. The default is <see cref="F:System.Windows.Forms.RightToLeft.Inherit"/>.
    /// </returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">
    /// The assigned value is not one of the <see cref="T:System.Windows.Forms.RightToLeft"/> values.
    /// </exception>
    public override RightToLeft RightToLeft
    {
      get
      {
        return base.RightToLeft;
      }
      set
      {
        base.RightToLeft = value;
        RecreateHandle();
      }
    }

    /// <summary>
    /// Gets or sets the font of the text displayed by the control.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// The <see cref="T:System.Drawing.Font"/> to apply to the text displayed by the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultFont"/> property.
    /// </returns>
    public override Font Font
    {
      get
      {
        return base.Font;
      }
      set
      {
        base.Font = value;
        RecreateHandle();
      }
    }

    private ContentAlignment textAlign = ContentAlignment.TopLeft;
    /// <summary>
    /// Gets or sets the text alignment.
    /// </summary>
    public ContentAlignment TextAlign
    {
      get { return textAlign; }
      set
      {
        textAlign = value;
        RecreateHandle();
      }
    }
  } 
}
