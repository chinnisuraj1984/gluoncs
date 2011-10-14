using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET;
using Common;

namespace GluonCS.LiveUavLayer
{
    public class Survey
    {


        private static List<PointLatLng> RotateList(List<PointLatLng> l, double angle)
        {
            List<PointLatLng> newl = new List<PointLatLng>();
            for (int i = 0; i < l.Count; i++)
            {
                double x = l[i].Lng;
                double y = l[i].Lat;
                double x2 = x * Math.Cos(angle) - y * Math.Sin(angle);
                double y2 = x * Math.Sin(angle) + y * Math.Cos(angle);
                newl.Add(new PointLatLng(y2, x2));
            }
            return newl;
        }

        private static bool PointInPolygon(List<PointLatLng> l, PointLatLng p)
        {
            int nvert = l.Count;
            int i, j;
            bool c = false;
            for (i = 0, j = nvert - 1; i < nvert; j = i++)
            {
                if (((l[i].Lat > p.Lat) != (l[j].Lat > p.Lat)) &&
                 (p.Lng < (l[j].Lng - l[i].Lng) * (p.Lat - l[i].Lat) / (l[j].Lat - l[i].Lat) + l[i].Lng))
                    c = !c;
            }
            return c;
        }

        public static List<PointLatLng> GenerateSurvey(List<PointLatLng> poly)
        {
            if (poly.Count < 3)
                return new List<PointLatLng>();

            double lat_deg_reference = poly[0].Lat;
            double lng_deg_reference = poly[0].Lng;

            // to relative
            for (int i = 0; i < poly.Count; i++)
            {
                LatLng rel = LatLng.ToRelative(lat_deg_reference, lng_deg_reference, poly[i].Lat, poly[i].Lng);  // use 0 as reference
                poly[i] = new PointLatLng(rel.Lat, rel.Lng);
            }

            poly = RotateList(poly, Properties.Settings.Default.SurveyAngleDeg / 180.0 * Math.PI);
            double maxLat = double.NegativeInfinity;
            double maxLng = double.NegativeInfinity;
            double minLng = double.PositiveInfinity;
            double minLat = double.PositiveInfinity;
            List<PointLatLng> route = new List<PointLatLng>();


            double dst_lat = Properties.Settings.Default.SurveyDistanceM;// / LatLng.LatitudeMeterPerDegree;
            double dst_lng = Properties.Settings.Default.SurveyDistanceM;// / LatLng.LongitudeMeterPerDegree(poly[0].Lat);
            // calculate boundingbox
            foreach (PointLatLng ll in poly)
            {
                if (ll.Lat > maxLat)
                    maxLat = ll.Lat + dst_lat / 2;
                if (ll.Lat < minLat)
                    minLat = ll.Lat - dst_lat / 2;
                if (ll.Lng < minLng)
                    minLng = ll.Lng - dst_lng / 2;
                if (ll.Lng > maxLng)
                    maxLng = ll.Lng + dst_lng / 2;
            }

            double lat = maxLat;
            double lng = minLng;
            //bool previous_in_polygon = false;
            while (true)
            {
                //route.Add(new PointLatLng(lat, lng));
                lng = minLng;
                for (; lng < maxLng; lng += dst_lng / 20)
                {
                    if (PointInPolygon(poly, new PointLatLng(lat, lng)))
                    {
                        route.Add(new PointLatLng(lat, lng));
                        break;
                    }
                }
                for (; lng < maxLng; lng += dst_lng / 20)
                {
                    if (!PointInPolygon(poly, new PointLatLng(lat, lng)))
                    {
                        route.Add(new PointLatLng(lat, lng));
                        break;
                    }
                }
                //route.Add(new PointLatLng(lat, lng));

                // turn right
                lat -= dst_lat / 2;
                /*for (double j = Math.PI / 2.0; j >= -Math.PI / 2.0; j -= Math.PI * 2.0 / 30.0)
                {
                    double clon = lng + Math.Cos(j) * dst_lng / 2.0;
                    double clat = lat + Math.Sin(j) * dst_lat / 2.0;
                    route.Add(new PointLatLng(clat, clon));
                }*/
                lat -= dst_lat / 2;

                //route.Add(new PointLatLng(lat, lng));
                lng = maxLng;
                for (; lng > minLng; lng -= dst_lng / 20)
                {
                    if (PointInPolygon(poly, new PointLatLng(lat, lng)))
                    {
                        route.Add(new PointLatLng(lat, lng));
                        break;
                    }
                }
                for (; lng > minLng; lng -= dst_lng / 20)
                {
                    if (!PointInPolygon(poly, new PointLatLng(lat, lng)))
                    {
                        route.Add(new PointLatLng(lat, lng));
                        break;
                    }
                }
                //lng = minLng;
                //route.Add(new PointLatLng(lat, lng));
                if (lat - dst_lat < minLat)
                    break;
                else
                {
                    lat -= dst_lat / 2;
                    /*for (double j = Math.PI / 2.0; j <= 3.0*Math.PI/2.0; j += Math.PI * 2.0 / 30.0)
                    {
                        double clon = lng + Math.Cos(j) * dst_lng / 2.0;
                        double clat = lat + Math.Sin(j) * dst_lat / 2.0;
                        route.Add(new PointLatLng(clat, clon));
                    }*/
                    lat -= dst_lat / 2;
                }
            }
            route = RotateList(route, -Properties.Settings.Default.SurveyAngleDeg / 180.0 * Math.PI);
            // to relative
            for (int i = 0; i < route.Count; i++)
            {
                LatLng abs = LatLng.ToAbsolute(lat_deg_reference, lng_deg_reference, route[i].Lat, route[i].Lng);
                route[i] = new PointLatLng(abs.Lat, abs.Lng);
            }
            return route;
        }
    }
}
