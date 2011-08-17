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
        private bool is_current_waypoint;

        public bool IsCurrentWaypoint
        {
            get { return is_current_waypoint; }
            set { is_current_waypoint = value; }
        }

        public NavigationMarker(PointLatLng p, int wp_number, bool is_current_waypoint)
            : base(p)
        {
            this.is_current_waypoint = is_current_waypoint;
            this.Number = wp_number;
        }
    }
}
