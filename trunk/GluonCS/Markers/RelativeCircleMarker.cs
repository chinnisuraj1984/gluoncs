using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GMap.NET;

namespace GluonCS.Markers
{
    public class RelativeCircleMarker : RelativeMarker
    {
        private double groundresolution;

        public RelativeCircleMarker(PointLatLng p, int number, double groundresolution)
            : base(p, number)
        {
            this.groundresolution = groundresolution;
        }

        public override void OnRender(Graphics g)
        {
            base.OnRender(g);
            int radius_px = 40;
            g.DrawEllipse(Pens.Red, new Rectangle(LocalPosition.X + Size.Width / 2 - radius_px / 2, LocalPosition.Y + Size.Height / 2 - radius_px / 2, radius_px, radius_px));
        }
    }
}
