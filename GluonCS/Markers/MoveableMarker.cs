using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap;
using GMap.NET;

namespace GluonCS.Markers
{
    public class MoveableMarker : GMapMarker
    {
        bool IsMoveable = true;

        public MoveableMarker(PointLatLng p)
            : base(p)
        {
        }
    }
}
