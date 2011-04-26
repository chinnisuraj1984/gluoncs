using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET;

namespace GluonCS.Markers
{
    public class NavigationMarker : MoveableMarker
    {
        public int Number;

        public NavigationMarker(PointLatLng p, int wp_number)
            : base(p)
        {
            this.Number = wp_number;
        }
    }
}
