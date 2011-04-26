using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap;
using GMap.NET;

namespace GluonCS.Markers
{
    class GluonHomeMarker : MoveableMarker
    {
        public Pen Pen;

        public GMapMarkerGoogleGreen InnerMarker;

        public GluonHomeMarker(PointLatLng p)
            : base(p)
        {
            Pen = new Pen(Brushes.Red, 1);

            // do not forget set Size of the marker
            // if so, you shall have no event on it ;}
            Size = new System.Drawing.Size(20, 16);
            Offset = new System.Drawing.Point(-Size.Width / 2, -Size.Height / 2);
        }

        public override void OnRender(Graphics g)
        {
            g.FillPolygon(Brushes.Red, new Point[]{
                    new Point(LocalPosition.X, LocalPosition.Y - Size.Height/2), 
                    new Point(LocalPosition.X + Size.Width, LocalPosition.Y - Size.Height/2), 
                    new Point(LocalPosition.X + Size.Width, LocalPosition.Y + Size.Height/2 - 5), 
                    new Point(LocalPosition.X + 5 + Size.Width/2, LocalPosition.Y + Size.Height/2 - 5), 
                    new Point(LocalPosition.X + Size.Width/2, LocalPosition.Y + Size.Height/2), 
                    new Point(LocalPosition.X + Size.Width/2- 5, LocalPosition.Y + Size.Height/2 - 5), 
                    new Point(LocalPosition.X , LocalPosition.Y + Size.Height/2 - 5)});
            g.DrawString("H", new Font(FontFamily.GenericSansSerif, 7), Brushes.White, LocalPosition.X + Size.Width / 2 - 5, LocalPosition.Y - Size.Height / 2);

        }
    }
}
