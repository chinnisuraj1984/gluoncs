using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap;
using GMap.NET;
using System.Drawing;


namespace GluonCS.Markers
{
    public class RelativeMarker : NavigationMarker
    {
        public Pen Pen;
        public GMapMarkerGoogleGreen InnerMarker;

        public RelativeMarker(PointLatLng p, int wp_number)
            : base(p, wp_number)
        {
            Pen = new Pen(Brushes.Red, 2);
            // do not forget set Size of the marker
            // if so, you shall have no event on it ;}
            Size = new System.Drawing.Size(14, 14);
            Offset = new System.Drawing.Point(-Size.Width / 2, -Size.Height / 2);
        }

        public override void OnRender(Graphics g)
        {
            g.DrawString(Number.ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, LocalPosition.X + 14 + 1, LocalPosition.Y + 0);
            g.DrawString(Number.ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, LocalPosition.X + 14 - 1, LocalPosition.Y + 0);
            g.DrawString(Number.ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, LocalPosition.X + 14, LocalPosition.Y + 0 + 1);
            g.DrawString(Number.ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, LocalPosition.X + 14, LocalPosition.Y + 0 - 1);
            g.DrawString(Number.ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Red, LocalPosition.X + 14, LocalPosition.Y + 0);
         
            g.FillEllipse(Brushes.White, new Rectangle(LocalPosition.X, LocalPosition.Y, Size.Width, Size.Height));
            g.DrawEllipse(Pen, new Rectangle(LocalPosition.X - (- 6) / 2, LocalPosition.Y - (- 6) / 2, Size.Width-6, Size.Height-6));        
        }
    }
}
