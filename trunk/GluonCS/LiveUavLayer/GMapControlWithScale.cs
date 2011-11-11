using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap;
using System.Drawing;
using System.Drawing.Drawing2D;
using GMap.NET;


namespace GluonCS.LiveUavLayer
{
    public class GMapControlWithScale : GMap.NET.WindowsForms.GMapControl
    {

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            PointLatLng ll1 = this.FromLocalToLatLng(0, 0);
            PointLatLng ll2 = this.FromLocalToLatLng(100, 0);

            // meter / 100px
            double MeterPerPixels100 = (ll2.Lng - ll1.Lng) * Common.LatLng.LongitudeMeterPerDegree(ll1.Lat);
            double PixelPerMeter = 100.0/MeterPerPixels100;
            //if (Properties.Settings.Default.
            if (MeterPerPixels100 < 10)
            {
                int pixs = (int)(10.0 * PixelPerMeter);
                DrawScaledRectangle(e.Graphics, pixs);
                DrawContrastString("10m", e.Graphics, pixs / 2, this.Height - 37, 8, Brushes.White);
            }
            else if (MeterPerPixels100 < 300)
            {
                int pixs = (int)(100.0 * PixelPerMeter);
                DrawScaledRectangle(e.Graphics, pixs);
                DrawContrastString("100m", e.Graphics, pixs / 2, this.Height - 37, 8, Brushes.White);
            }
            else if (MeterPerPixels100 < 3000)
            {
                int pixs = (int)(1000.0 * PixelPerMeter);
                DrawScaledRectangle(e.Graphics, pixs);
                DrawContrastString("1000m", e.Graphics, pixs / 2, this.Height - 37, 8, Brushes.White);
            }
            else// if (MeterPerPixels100 < 10000)
            {
                int pixs = (int)(10000.0 * PixelPerMeter);
                DrawScaledRectangle(e.Graphics, pixs);
                DrawContrastString("10000m", e.Graphics, pixs / 2, this.Height - 37, 8, Brushes.White);
            }
        }

        private void DrawContrastString(string s, Graphics g, int x, int y, int fontsize, Brush fontColor)
        {
            g.DrawString(s, new Font(FontFamily.GenericSansSerif, fontsize), Brushes.Black, x + 1, y);
            g.DrawString(s, new Font(FontFamily.GenericSansSerif, fontsize), Brushes.Black, x - 1, y);
            g.DrawString(s, new Font(FontFamily.GenericSansSerif, fontsize), Brushes.Black, x, y + 1);
            g.DrawString(s, new Font(FontFamily.GenericSansSerif, fontsize), Brushes.Black, x, y - 1);
            g.DrawString(s, new Font(FontFamily.GenericSansSerif, fontsize), fontColor, x, y);
        }

        private void DrawScaledRectangle(Graphics g, int pixs)
        {
            g.FillRectangle(Brushes.Black, new Rectangle(20, this.Height - 25, pixs/4, 8));
            g.FillRectangle(Brushes.White, new Rectangle(20 + 1*pixs / 4, this.Height - 25, pixs/4, 8));
            g.FillRectangle(Brushes.Black, new Rectangle(20 + 2*pixs / 4, this.Height - 25, pixs/4, 8));
            g.FillRectangle(Brushes.White, new Rectangle(20 + 3*pixs / 4, this.Height - 25, pixs/4, 8));
            g.DrawRectangle(Pens.Black, new Rectangle(20, this.Height - 25, pixs, 8));
        }
    }
}
