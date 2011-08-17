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
    public class AbsoluteMarker : NavigationMarker
    {
        public Pen Pen;
        public GMapMarkerGoogleGreen InnerMarker;
        private bool out_of_sync;


        public AbsoluteMarker(PointLatLng p, int wp_number, bool out_of_sync = false, bool is_current_waypoint = false)
            : base(p, wp_number, is_current_waypoint)
        {

            // do not forget set Size of the marker
            // if so, you shall have no event on it ;}
            Size = new System.Drawing.Size(14, 14);
            Offset = new System.Drawing.Point(-Size.Width / 2, -Size.Height / 2);
            this.out_of_sync = out_of_sync;
            if (out_of_sync)
                Pen = new Pen(Brushes.Gray, 2);
            else
                Pen = new Pen(Brushes.Red, 2);
        }

        public override void OnRender(Graphics g)
        {
            Brush backgroundmarkercolor = Brushes.White;
            if (IsCurrentWaypoint)
                backgroundmarkercolor = Brushes.Yellow;

            Number++; // we visualize 0 as 1
            g.DrawString(Number.ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, LocalPosition.X + 14 + 1, LocalPosition.Y + 0);
            g.DrawString(Number.ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, LocalPosition.X + 14 - 1, LocalPosition.Y + 0);
            g.DrawString(Number.ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, LocalPosition.X + 14, LocalPosition.Y + 0 + 1);
            g.DrawString(Number.ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, LocalPosition.X + 14, LocalPosition.Y + 0 - 1);
            if (out_of_sync)
                g.DrawString(Number.ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.LightGray, LocalPosition.X + 14, LocalPosition.Y + 0);
            else
                g.DrawString(Number.ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Red, LocalPosition.X + 14, LocalPosition.Y + 0);

            g.FillRectangle(backgroundmarkercolor, new Rectangle(LocalPosition.X, LocalPosition.Y, Size.Width, Size.Height));
            g.DrawRectangle(Pen, new Rectangle(LocalPosition.X - (-6) / 2, LocalPosition.Y - (-6) / 2, Size.Width - 6, Size.Height - 6));
            Number--;

        }
    }
}
