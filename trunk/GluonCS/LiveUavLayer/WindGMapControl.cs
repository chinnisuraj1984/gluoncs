using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GluonCS.LiveUavLayer
{
    public class WindGMapControl : GMap.NET.WindowsForms.GMapControl
    {
        public double WindSpeed;
        public double WindDirectionRad;
        Image vane = null;

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (vane == null)
                vane = Image.FromFile("Resources\\windvane.png");
            base.OnPaint(e);

            double size = 30;
            //e.Graphics.DrawLine(new Pen(Brushes.Red, 3), new Point(this.Width - 50, 20), new Point((int)(this.Width - 50 + Math.Cos(WindDirectionRad) * size), (int)(20 - Math.Sin(WindDirectionRad) * size)));

            GraphicsState gs = e.Graphics.Save();
            /*PointF[] points1 = new PointF[4];
            points1[0] = new PointF(5, -10);
            points1[1] = new PointF(12, 20);
            points1[2] = new PointF(-12, 20);
            points1[3] = new PointF(-5, -10);
            PointF[] points2 = new PointF[4];
            points2[0] = new PointF(5, -10);
            points2[1] = new PointF(12, 20);
            points2[2] = new PointF(-12, 20);
            points2[3] = new PointF(-5, -10);*/
            e.Graphics.TranslateTransform(this.Width - 35, 35);
            e.Graphics.RotateTransform((float)(WindDirectionRad/Math.PI*180.0 + 180), MatrixOrder.Prepend);

            //e.Graphics.FillPolygon(Brushes.Red, points);
            e.Graphics.DrawImage(vane, new Rectangle(new Point(-vane.Width / 3, 0), new Size(2 * vane.Width / 3, 2 * vane.Height / 3)));
            e.Graphics.Restore(gs);

            string text = WindSpeed.ToString("0.0") + "m/s";
            e.Graphics.DrawString(text, this.Font, Brushes.Black, new PointF(this.Width - 50 + 1, 25 + 1));
            e.Graphics.DrawString(text, this.Font, Brushes.Black, new PointF(this.Width - 50 + 1, 25 - 1));
            e.Graphics.DrawString(text, this.Font, Brushes.Black, new PointF(this.Width - 50 - 1, 25 + 1));
            e.Graphics.DrawString(text, this.Font, Brushes.Black, new PointF(this.Width - 50 - 1, 25 - 1));
            e.Graphics.DrawString(text, this.Font, Brushes.White, new PointF(this.Width - 50, 25));

        }
    }
}
