using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using System.Windows.Forms;
using System.Drawing;
using GluonCS.Markers;
using Communication.Frames.Incoming;
using Configuration.NavigationCommands;
using Configuration;
using Common;
using System.IO;


namespace GluonCS.LiveUavLayer
{
    public class GMapController
    {
        private WindGMapControl gmap;
        private LiveUavModel model;
        private GMapMarker current_marker = null;  // when dragging a marker
        private GMapMarker home;
        private bool is_mouse_down = false;
        private Point click_offset;
        private bool hasReceivedGps = false;
        private int current_waypointline = -1;

        private bool zoomToReceivedWaypoints = false;
        private Timer zoomtowaypoints;

        private Timer guiUpdateTimer;

        public GMapOverlay Overlay;
        public GMapOverlay NavigationOverlay;
        private GMapRoute uavRoute;
        private UavMarker uavMarker;

        private ContextMenuStrip general_menustrip = new ContextMenuStrip();
        private ContextMenuStrip map_menustrip = new ContextMenuStrip();
        private ContextMenuStrip navigationmarker_menustrip = new ContextMenuStrip();
        private ContextMenuStrip current_contextmenu = new ContextMenuStrip();  // contains the merged menus


        public GMapController(WindGMapControl gmap,
                              LiveUavModel model)
        {
            try
            {
                System.Net.IPHostEntry e = System.Net.Dns.GetHostEntry("www.google.com");
            }
            catch
            {
                gmap.Manager.Mode = AccessMode.CacheOnly;
                MessageBox.Show("No internet connection avaible, using cache.", "Gluon control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.gmap = gmap;
            this.model = model;
            Overlay = new GMapOverlay(gmap, "LiveUav1");
            NavigationOverlay = new GMapOverlay(gmap, "NavigationOverlay");
            gmap.Overlays.Add(NavigationOverlay);
            gmap.Overlays.Add(Overlay);
            gmap.DragButton = MouseButtons.Left;
            home = new Markers.GluonHomeMarker(model.Home);
            Overlay.Markers.Add(home);

            uavMarker = new UavMarker(model.UavPosition);
            Overlay.Markers.Add(uavMarker);

            uavRoute = new GMapRoute(new List<PointLatLng>(), "uav");
            uavRoute.Stroke.Color = Color.FromArgb(150, Color.Yellow);
            //uavRoute.Stroke.Brush = Brushes.Yellow;
            uavRoute.Stroke.Width = 4;
            Overlay.Routes.Add(uavRoute);
            //uavRoute.Points.Add(new PointLatLng(um.Position.Lat - 0.0001, um.Position.Lng - 0.0001));
            //uavRoute.Points.Add(new PointLatLng(um.Position.Lat - 0.0001, um.Position.Lng));
            //uavRoute.Points.Add(new PointLatLng(um.Position.Lat, um.Position.Lng));
            gmap.UpdateRouteLocalPosition(uavRoute);

            gmap.OnMarkerEnter += new MarkerEnter(gmap_OnMarkerEnter);
            gmap.OnMarkerLeave += new MarkerLeave(gmap_OnMarkerLeave);
            gmap.MouseDown += new System.Windows.Forms.MouseEventHandler(gmap_MouseDown);
            gmap.MouseUp += new System.Windows.Forms.MouseEventHandler(gmap_MouseUp);
            gmap.MouseMove += new MouseEventHandler(gmap_MouseMove);
            gmap.OnMarkerClick += new MarkerClick(gmap_OnMarkerClick);
            model.NavigationLocalListChanged += new LiveUavModel.ChangedEventHandler(model_NavigationLocalListChanged);
            model.HomeChanged += new LiveUavModel.ChangedEventHandler(model_HomeChanged);
            model.UavPositionChanged += new LiveUavModel.ChangedEventHandler(model_UavPositionChanged);
            model.UavAttitudeChanged += new LiveUavModel.ChangedEventHandler(model_UavAttitudeChanged);
            model.CommunicationLost += new LiveUavModel.ChangedEventHandler(model_CommunicationLost);
            model.CommunicationEstablished += new LiveUavModel.ChangedEventHandler(model_CommunicationEstablished);
            model.CenterOnUav += new LiveUavModel.ChangedEventHandler(model_CenterUav);

            // context menu strips
            ToolStripItem i = general_menustrip.Items.Add("Set &home");
            i.Click += new EventHandler(SetHome_Click);
            i = general_menustrip.Items.Add("Add &absolute waypoint");
            i.Image = Image.FromFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\Resources\\marker_empty_red.png");
            i.Click += new EventHandler(AddAbsolute_Click);
            i = general_menustrip.Items.Add("Add &relative waypoint");
            i.Click += new EventHandler(AddRelative_Click);

            navigationmarker_menustrip.Items.Add("-");
            i = navigationmarker_menustrip.Items.Add("&Delete waypoint");
            i.Click+= new EventHandler(DeleteWaypoint_Click);
            i = navigationmarker_menustrip.Items.Add("&Change absolute <-> relative");
            i.Click += new EventHandler(ChangeAbsRelWaypoint_Click);
            i = navigationmarker_menustrip.Items.Add("&Properties");
            i.Click += new EventHandler(WaypointProperties_Click);


            zoomtowaypoints = new Timer();
            zoomtowaypoints.Tick += new EventHandler(zoomtowaypoints_Tick);

            guiUpdateTimer = new Timer();
            guiUpdateTimer.Interval = 200;
            guiUpdateTimer.Tick += new EventHandler(guiUpdateTimer_Tick);
            guiUpdateTimer.Start();
        }


        public void Stop()
        {
            try
            {

                model.NavigationLocalListChanged -= new LiveUavModel.ChangedEventHandler(model_NavigationLocalListChanged);
                model.HomeChanged -= new LiveUavModel.ChangedEventHandler(model_HomeChanged);
                model.UavPositionChanged -= new LiveUavModel.ChangedEventHandler(model_UavPositionChanged);
                model.UavAttitudeChanged -= new LiveUavModel.ChangedEventHandler(model_UavAttitudeChanged);
                model.CommunicationLost -= new LiveUavModel.ChangedEventHandler(model_CommunicationLost);
                model.CommunicationEstablished -= new LiveUavModel.ChangedEventHandler(model_CommunicationEstablished);
                model.CenterOnUav -= new LiveUavModel.ChangedEventHandler(model_CenterUav);
            }
            catch (Exception ex)
            {
            }
            guiUpdateTimer.Stop();
            zoomtowaypoints.Stop();
            gmap.Dispose();
        }

        void model_CenterUav(object sender, EventArgs e)
        {
            gmap.Position = uavMarker.Position;
        }

        public void RecenterMap()
        {
            double maxlat = home.Position.Lat, maxlng = home.Position.Lng, minlat = home.Position.Lat, minlng = home.Position.Lng;
            foreach (GMapMarker m in NavigationOverlay.Markers)
            {
                if (m.Position.Lat > maxlat)
                    maxlat = m.Position.Lat;
                if (m.Position.Lat < minlat)
                    minlat = m.Position.Lat;
                if (m.Position.Lng > maxlng)
                    maxlng = m.Position.Lng;
                if (m.Position.Lng < minlng)
                    minlng = m.Position.Lng;
            }
            gmap.Position = new PointLatLng((maxlat + minlat) / 2.0, (maxlng + minlng) / 2.0);
        }

        void UpdateCurrentMarkerInModel(int x, int y)
        {
            if (current_marker is RelativeMarker)
            {
                PointLatLng p = gmap.FromLocalToLatLng(x, y);
                NavigationInstruction ni = model.GetNavigationInstructionLocal(((RelativeMarker)current_marker).Number);
                LatLng rel = LatLng.ToRelative(home.Position.Lat, home.Position.Lng, p.Lat, p.Lng);
                ni.x = rel.Lat;
                ni.y = rel.Lng;
                model.UpdateLocalNavigationInstruction(ni);  // not good way to go
            }
            if (current_marker is AbsoluteMarker)
            {
                PointLatLng p = gmap.FromLocalToLatLng(x, y);
                NavigationInstruction ni = model.GetNavigationInstructionLocal(((AbsoluteMarker)current_marker).Number);
                ni.x = p.Lat / 180.0 * Math.PI;
                ni.y = p.Lng / 180.0 * Math.PI; ;
                model.UpdateLocalNavigationInstruction(ni);  // not good way to go
            }
            if (current_marker is IconMarker && ((IconMarker)current_marker).IsAbsolute)
            {
                PointLatLng p = gmap.FromLocalToLatLng(x, y);
                NavigationInstruction ni = model.GetNavigationInstructionLocal(((IconMarker)current_marker).Number);
                ni.x = p.Lat / 180.0 * Math.PI;
                ni.y = p.Lng / 180.0 * Math.PI; ;
                model.UpdateLocalNavigationInstruction(ni);  // not good way to go
            }
        }

#region Model events

        void model_CommunicationEstablished(object sender, EventArgs e)
        {
            gmap.GrayScaleMode = false;
            uavMarker.AlarmMessage = "";
        }

        void model_CommunicationLost(object sender, EventArgs e)
        {
            gmap.GrayScaleMode = true;
            uavMarker.AlarmMessage = "Connection lost!";
        }

        void model_UavAttitudeChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void guiUpdateTimer_Tick(object sender, EventArgs e)
        {
            MethodInvoker m = delegate()
            {
                gmap.WindSpeed = Math.Sqrt(model.WindX * model.WindX + model.WindY * model.WindY);
                gmap.WindDirectionRad = Math.Atan2(model.WindY, model.WindX);
                home.Position = model.Home;
                // should be somewhere else...
                if (model.CurrentNavigationLine != current_waypointline)
                {
                    if (current_waypointline == -1)
                    {
                        current_waypointline = model.NavigationModel.Commands[model.CurrentNavigationLine].TargetWp;
                    }

                    // Is the new navigationcommand a waypoint?
                    if (model.GetNavigationInstructionLocal(model.CurrentNavigationLine).IsWaypoint() ||
                        model.GetNavigationInstructionLocal(model.CurrentNavigationLine).opcode == NavigationInstruction.navigation_command.BLOCK)
                    {
                        //current_waypointline = model.CurrentNavigationLine;
                        current_waypointline = model.NavigationModel.Commands[model.CurrentNavigationLine].TargetWp;
                        // Yes, update
                        foreach (GMapMarker marker in NavigationOverlay.Markers)
                        {
                            NavigationMarker nm = marker as NavigationMarker;
                            if (nm != null)
                            {
                                if (nm.Number == current_waypointline)
                                    nm.IsCurrentWaypoint = true;
                                else
                                    nm.IsCurrentWaypoint = false;
                                gmap.UpdateMarkerLocalPosition(nm);
                            }
                        }
                        gmap.Invalidate();
                    }
                }


                if (model.NumberOfGpsSatellites > 3)
                {
                    bool containedUav = gmap.CurrentViewArea.Contains(uavMarker.Position);

                    uavRoute.Points.Add(new PointLatLng(model.UavPosition.Lat, model.UavPosition.Lng));
                    if (uavRoute.Points.Count > 800) // time to delete some old point on the pad (can become annoying after a while)
                        uavRoute.Points.RemoveRange(0, 100);

                    gmap.UpdateRouteLocalPosition(uavRoute);
                    uavMarker.Yaw = model.Yaw;
                    uavMarker.AltitudeAglM = model.AltitudeAglM;
                    uavMarker.SpeedMS = model.SpeedMS;
                    uavMarker.Position = new PointLatLng(model.UavPosition.Lat, model.UavPosition.Lng);
                    gmap.UpdateMarkerLocalPosition(uavMarker);
                    if (Properties.Settings.Default.FollowUav)
                        gmap.Position = uavMarker.Position;
                    //this.NavigationOverlay.

                    if (!hasReceivedGps)  // first gps position? center on UAV
                    {
                        gmap.Position = new PointLatLng(model.UavPosition.Lat, model.UavPosition.Lng);
                        home.Position = new PointLatLng(model.UavPosition.Lat, model.UavPosition.Lng);
                        hasReceivedGps = true;
                    }

                    // if the uav is flying out of the screen, move the map
                    if (!gmap.CurrentViewArea.Contains(uavMarker.Position) && containedUav)
                        gmap.Position = new PointLatLng(model.UavPosition.Lat, model.UavPosition.Lng);
                }
            };

            try
            {
                gmap.BeginInvoke(m);
            }
            catch
            {
            } 
        }


        void model_UavPositionChanged(object sender, EventArgs e)
        {
            
        }

        void model_HomeChanged(object sender, EventArgs e)
        {
            home.Position = model.Home;
            //UavMarker um = new UavMarker(model.Home);
            //Overlay.Markers.Add(um);
        }


        private PointLatLng prevprevPoint(int i)
        {
            if (i < 2)
                return new PointLatLng();

            NavigationInstruction next = model.GetNavigationInstructionLocal(i - 2);
            if (next.HasAbsoluteCoordinates())
                return new PointLatLng(next.x / Math.PI * 180.0, next.y / Math.PI * 180.0);
            else if (next.HasRelativeCoordinates())
                return new PointLatLng(home.Position.Lat + next.x / LatLng.LatitudeMeterPerDegree,
                                       home.Position.Lng + next.y / LatLng.LongitudeMeterPerDegree(gmap.Position.Lat));
            else
                return new PointLatLng();
        }


        private PointLatLng nextPoint(int i)
        {
            //if (i >= model.)
            //    return new PointLatLng();

            NavigationInstruction next = model.GetNavigationInstructionLocal(i + 1);
            if (next.HasAbsoluteCoordinates())
                return new PointLatLng(next.x / Math.PI * 180.0, next.y / Math.PI * 180.0);
            else if (next.HasRelativeCoordinates())
                return new PointLatLng(home.Position.Lat + next.x / LatLng.LatitudeMeterPerDegree,
                                       home.Position.Lng + next.y / LatLng.LongitudeMeterPerDegree(gmap.Position.Lat));
            else
                return new PointLatLng();
        }

        // remove routes and markers for navigation and recreate them
        // according to the model
        void model_NavigationLocalListChanged(object sender, EventArgs e)
        {
            // from our model -> start on paint thread
            MethodInvoker m = delegate()
            {
                List<PointLatLng> l = new List<PointLatLng>();
                NavigationOverlay.Markers.Clear();
                NavigationOverlay.Routes.Clear();
                NavigationOverlay.Polygons.Clear();
                //current_waypointline = -1;

                string lastblockname = "Start";
                for (int i = 0; i < model.MaxNumberOfNavigationInstructions(); i++)
                {
                    MoveableMarker mm = new MoveableMarker(gmap.Position);
                    NavigationInstruction ni = model.GetNavigationInstructionLocal(i);

                    // if new block name -> don't connect blocks with a path!
                    if (model.NavigationModel.Commands[i].BlockName != lastblockname)
                    {
                        lastblockname = model.NavigationModel.Commands[i].BlockName;
                        GMapRoute r = new GMapRoute(l, "test" + (new Random()).Next(10000));
                        NavigationOverlay.Routes.Add(r);
                        r.Stroke.Color = Color.FromArgb(150, Color.Red);
                        l = new List<PointLatLng>();
                    }

                    // create marker
                    if (ni.HasRelativeCoordinates() || ni.HasAbsoluteCoordinates())
                    {
                        if (ni.HasRelativeCoordinates())
                        {
                            if (model.IsNavigationSynchronized(i))
                                mm = new RelativeMarker(gmap.Position, i, false);
                            else
                                mm = new RelativeMarker(gmap.Position, i, true);
                            mm.Position = new PointLatLng(home.Position.Lat + ni.x / LatLng.LatitudeMeterPerDegree,
                                                          home.Position.Lng + ni.y / LatLng.LongitudeMeterPerDegree(gmap.Position.Lat));
                        }
                        else if (ni.HasAbsoluteCoordinates())
                        {
                            if (model.IsNavigationSynchronized(i))
                                mm = new IconMarker(gmap.Position, i, true, false, i==current_waypointline);
                            else
                                mm = new IconMarker(gmap.Position, i, true, true, i == current_waypointline);

                            mm.Position = new PointLatLng(ni.x / Math.PI * 180.0,
                                                          ni.y / Math.PI * 180.0);

                        }
                        NavigationOverlay.Markers.Add(mm);
                        mm.ToolTipText = ni.ToString();
                        l.Add(mm.Position);

                        if (!zoomToReceivedWaypoints)
                        {
                            zoomtowaypoints.Interval = 500;
                            // if (zoomtowaypoints.Enabled)
                            zoomtowaypoints.Stop();
                            zoomtowaypoints.Start();
                        }
                    }

                    // circle to
                    if (ni.opcode == NavigationInstruction.navigation_command.CIRCLE_TO_ABS)
                    {
                        if (NavigationOverlay.Markers.Count >= 2)
                        {
                            l.RemoveAt(l.Count - 1);  // remove previously added point; to be replaced with a circle segment!
                            GMapMarker thisone = NavigationOverlay.Markers[NavigationOverlay.Markers.Count - 1];
                            GMapMarker previous = NavigationOverlay.Markers[NavigationOverlay.Markers.Count - 2];
                            double angle = Math.Atan2(-(thisone.Position.Lat - previous.Position.Lat) * LatLng.LatitudeMeterPerDegree,
                                                      (thisone.Position.Lng - previous.Position.Lng) * LatLng.LongitudeMeterPerDegree(gmap.Position.Lat)) + Math.PI / 2.0;
                            PointLatLng center = new PointLatLng((thisone.Position.Lat + previous.Position.Lat) / 2.0, (thisone.Position.Lng + previous.Position.Lng) / 2.0);
                            
                            PointLatLng prev_or_next = nextPoint(i);
                            if (prev_or_next.Lat == 0) // there is no next point, use previous
                                prev_or_next = prevprevPoint(i);

                            double angle2 = Math.Atan2(-(previous.Position.Lat - prev_or_next.Lat) * LatLng.LatitudeMeterPerDegree,
                                                      (previous.Position.Lng - prev_or_next.Lng) * LatLng.LongitudeMeterPerDegree(gmap.Position.Lat)) +  Math.PI / 2.0;
                            double diffheading = angle - angle2;
                            if (diffheading > Math.PI)
                                diffheading -= 2*Math.PI;
                            if (diffheading < -Math.PI)
                                diffheading += 2*Math.PI;

                            double radius = Math.Sqrt(Math.Pow((thisone.Position.Lat - previous.Position.Lat) * LatLng.LatitudeMeterPerDegree, 2) +
                                            Math.Pow((thisone.Position.Lng - previous.Position.Lng) * LatLng.LongitudeMeterPerDegree(gmap.Position.Lat), 2)) / 2.0;

                            List<PointLatLng> circleto = new List<PointLatLng>();
                            if (diffheading > 0)
                            {
                                for (double a = angle; a < angle + Math.PI + (Math.PI * 2.0 / 20.0); a += Math.PI * 2.0 / 20.0)
                                {
                                    double clon = center.Lng + Math.Sin(a - Math.PI) * radius / LatLng.LongitudeMeterPerDegree(gmap.Position.Lat);
                                    double clat = center.Lat + Math.Cos(a - Math.PI) * radius / LatLng.LatitudeMeterPerDegree;
                                    circleto.Add(new PointLatLng(clat, clon));
                                }
                            }
                            else
                            {
                                for (double a = angle; a > angle - Math.PI - (Math.PI * 2.0 / 20.0); a -= Math.PI * 2.0 / 20.0)
                                {
                                    double clon = center.Lng + Math.Sin(a - Math.PI) * radius / LatLng.LongitudeMeterPerDegree(gmap.Position.Lat);
                                    double clat = center.Lat + Math.Cos(a - Math.PI) * radius / LatLng.LatitudeMeterPerDegree;
                                    circleto.Add(new PointLatLng(clat, clon));
                                }
                            }
                            //circleto.Reverse();
                            GMapRoute cr = new GMapRoute(circleto, "circleto");
                            cr.Stroke.Color = Color.FromArgb(100, Color.Red);
                            NavigationOverlay.Routes.Add(cr);
                            l.AddRange(circleto);
                        }
                    }

                    // draw circle path
                    if (ni.opcode == NavigationInstruction.navigation_command.CIRCLE_ABS ||
                        ni.opcode == NavigationInstruction.navigation_command.CIRCLE_REL)
                    {
                        List<PointLatLng> c = new List<PointLatLng>();
                        for (double j = 0.0; j <= Math.PI * 2.00001; j += Math.PI * 2.0 / 30.0)
                        {
                            double clon = mm.Position.Lng + Math.Cos(j) * ni.a / LatLng.LongitudeMeterPerDegree(gmap.Position.Lat);
                            double clat = mm.Position.Lat + Math.Sin(j) * ni.a / LatLng.LatitudeMeterPerDegree;
                            c.Add(new PointLatLng(clat, clon));
                        }
                        GMapRoute cr = new GMapRoute(c, "circle");
                        NavigationOverlay.Routes.Add(cr);
                        cr.Stroke.Color = Color.FromArgb(150, Color.Red);
                        l.Add(mm.Position);
                    }


                    // determine current dragged marker
                    NavigationMarker current_dragging_marker = current_marker as NavigationMarker;
                    if (current_dragging_marker != null)
                    {
                        if (current_dragging_marker.Number == i)
                            current_dragging_marker = mm as NavigationMarker;
                    }

                    if (model.NavigationModel.WaypointsInBlock(model.NavigationModel.Commands[i].BlockName) == 1)
                    {
                        if (mm is NavigationMarker)
                        {
                            ((NavigationMarker)mm).Name = model.NavigationModel.Commands[i].BlockName;
                        }
                    }
                }
                
                // draw route
                GMapRoute rr = new GMapRoute(l, "test"+(new Random()).Next(10000));
                NavigationOverlay.Routes.Add(rr);
                rr.Stroke.Color = Color.FromArgb(150, Color.Red);
                gmap.UpdateRouteLocalPosition(rr);

                // survey
                l.Clear();
                for (int i = 0; i < model.NavigationModel.Commands.Count; i++)
                {
                    NavigationInstruction ni = model.GetNavigationInstructionLocal(i);
                    if (model.NavigationModel.Commands[i].BlockName.StartsWith("Survey") && ni.HasAbsoluteCoordinates())
                        l.Add(new PointLatLng(ni.x / Math.PI * 180.0, ni.y / Math.PI * 180.0));
                }
                GMapPolygon gp = new GMapPolygon(l, "survey");
                gp.Stroke.Color = Color.FromArgb(140, Color.Blue);
                //gp.Fill = new SolidBrush(Color.Blue);
                NavigationOverlay.Polygons.Add(gp);

                List<PointLatLng> points = Survey.GenerateSurvey(l, Properties.Settings.Default.SurveyAngleDeg, Properties.Settings.Default.SurveyDistanceM);
                foreach (PointLatLng pll in points)
                {
                    //NavigationOverlay.Markers.Add(new AbsoluteMarker(pll, 0));
                }
                NavigationOverlay.Routes.Add(new GMapRoute(points, "surv"));
            };

            try
            {
                gmap.BeginInvoke(m);
            }
            catch
            {
            } 

        }


        //
        void zoomtowaypoints_Tick(object sender, EventArgs e)
        {
            //zoomToReceivedWaypoints = true;
            //double zoom = gmap.Zoom;
            //gmap.ZoomAndCenterMarkers("NavigationOverlay"); //gmap.GetRectOfAllMarkers("");
            //if (gmap.Zoom > zoom)
            //    gmap.Zoom = zoom;
            //zoomtowaypoints.Stop();

            //above code seems to contain a gmap bug
            zoomToReceivedWaypoints = true;
            zoomtowaypoints.Stop();
            RecenterMap();
        }

#endregion


        #region Contextmenu events

        void WaypointProperties_Click(object sender, EventArgs e)
        {
            if (current_marker is NavigationMarker)
            {
                NavigationMarker nm = (NavigationMarker)current_marker;

                NavigationInstructionEdit nie =
                    new NavigationInstructionEdit(model.GetNavigationInstructionLocal(nm.Number), model.Home.Lat, model.Home.Lng);
                if (nie.ShowDialog(null) == DialogResult.OK)
                {
                    model.UpdateLocalNavigationInstruction(new NavigationInstruction(nie.NavigationInstr));
                    Console.WriteLine(model.GetNavigationInstructionLocal(0));
                    Console.WriteLine(model.GetNavigationInstructionRemote(0));
                }
            }
        }

        void ChangeAbsRelWaypoint_Click(object sender, EventArgs e)
        {
            if (current_marker is NavigationMarker)
            {
                NavigationMarker nm = (NavigationMarker)current_marker;
                NavigationInstruction ni = model.GetNavigationInstructionLocal(nm.Number);
                PointLatLng p = (PointLatLng)current_contextmenu.Tag;

                if (ni.opcode == NavigationInstruction.navigation_command.CIRCLE_REL ||
                    ni.opcode == NavigationInstruction.navigation_command.FLY_TO_REL ||
                    ni.opcode == NavigationInstruction.navigation_command.FROM_TO_REL ||
                    ni.opcode == NavigationInstruction.navigation_command.FLARE_TO_REL ||
                    ni.opcode == NavigationInstruction.navigation_command.GLIDE_TO_REL ||
                    ni.opcode == NavigationInstruction.navigation_command.CIRCLE_TO_REL)
                {
                    ni.x = p.Lat / 180.0 * Math.PI;
                    ni.y = p.Lng / 180.0 * Math.PI;
                }
                else if (ni.opcode == NavigationInstruction.navigation_command.CIRCLE_ABS ||
                        ni.opcode == NavigationInstruction.navigation_command.FLY_TO_ABS ||
                        ni.opcode == NavigationInstruction.navigation_command.FROM_TO_ABS ||
                        ni.opcode == NavigationInstruction.navigation_command.FLARE_TO_ABS ||
                        ni.opcode == NavigationInstruction.navigation_command.GLIDE_TO_ABS ||
                        ni.opcode == NavigationInstruction.navigation_command.CIRCLE_TO_ABS)
                {
                    LatLng rel = LatLng.ToRelative(home.Position.Lat, home.Position.Lng, nm.Position.Lat, nm.Position.Lng);
                    ni.x = rel.Lat;
                    ni.y = rel.Lng;
                }

                if (ni.opcode == NavigationInstruction.navigation_command.CIRCLE_REL)
                    ni.opcode = NavigationInstruction.navigation_command.CIRCLE_ABS;
                else if (ni.opcode == NavigationInstruction.navigation_command.CIRCLE_TO_REL)
                    ni.opcode = NavigationInstruction.navigation_command.CIRCLE_TO_ABS;
                else if (ni.opcode == NavigationInstruction.navigation_command.FLY_TO_REL)
                    ni.opcode = NavigationInstruction.navigation_command.FLY_TO_ABS;
                else if (ni.opcode == NavigationInstruction.navigation_command.FROM_TO_REL)
                    ni.opcode = NavigationInstruction.navigation_command.FROM_TO_ABS;
                else if (ni.opcode == NavigationInstruction.navigation_command.CIRCLE_ABS)
                    ni.opcode = NavigationInstruction.navigation_command.CIRCLE_REL;
                else if (ni.opcode == NavigationInstruction.navigation_command.CIRCLE_TO_ABS)
                    ni.opcode = NavigationInstruction.navigation_command.CIRCLE_TO_REL;
                else if (ni.opcode == NavigationInstruction.navigation_command.FLY_TO_ABS)
                    ni.opcode = NavigationInstruction.navigation_command.FLY_TO_REL;
                else if (ni.opcode == NavigationInstruction.navigation_command.FROM_TO_ABS)
                    ni.opcode = NavigationInstruction.navigation_command.FROM_TO_REL;
                else if (ni.opcode == NavigationInstruction.navigation_command.FLARE_TO_ABS)
                    ni.opcode = NavigationInstruction.navigation_command.FLARE_TO_REL;
                else if (ni.opcode == NavigationInstruction.navigation_command.FLARE_TO_REL)
                    ni.opcode = NavigationInstruction.navigation_command.FLARE_TO_ABS;
                else if (ni.opcode == NavigationInstruction.navigation_command.GLIDE_TO_ABS)
                    ni.opcode = NavigationInstruction.navigation_command.GLIDE_TO_REL;
                else if (ni.opcode == NavigationInstruction.navigation_command.GLIDE_TO_REL)
                    ni.opcode = NavigationInstruction.navigation_command.GLIDE_TO_ABS;
                model.UpdateLocalNavigationInstruction(ni);
            }
        }

        void DeleteWaypoint_Click(object sender, EventArgs e)
        {
            if (current_marker is NavigationMarker)
            {
                NavigationMarker nm = (NavigationMarker)current_marker;
                for (int i = 0; i < model.MaxNumberOfNavigationInstructions(); i++)
                {
                    if (nm.Number == i)
                    {
                        for (int j = i + 1; j < model.MaxNumberOfNavigationInstructions(); j++)
                        {
                            NavigationInstruction ni = model.GetNavigationInstructionLocal(j);
                            ni.line--;
                            if (ni.opcode == NavigationInstruction.navigation_command.GOTO)
                                ni.a--;
                            model.UpdateLocalNavigationInstruction(ni);
                        }
                        break;
                    }
                }
            }
        }

        void SetHome_Click(object sender, EventArgs e)
        {
            model.UpdateHome((PointLatLng)current_contextmenu.Tag);
        }

        void AddRelative_Click(object sender, EventArgs e)
        {
            PointLatLng p = (PointLatLng)current_contextmenu.Tag;
            for (int i = 0; i < model.MaxNumberOfNavigationInstructions(); i++)
            {
                NavigationInstruction ni = model.GetNavigationInstructionLocal(i);
                if (ni.opcode == NavigationInstruction.navigation_command.EMPTY)
                {
                    ni.opcode = NavigationInstruction.navigation_command.FLY_TO_REL;
                    LatLng abs = LatLng.ToRelative(home.Position.Lat, home.Position.Lng, p.Lat, p.Lng);
                    ni.x = abs.Lat;
                    ni.y = abs.Lng;
                    ni.a = (int)Properties.Settings.Default.DefaultAltitudeM;
                    model.UpdateLocalNavigationInstruction(ni);
                    break;
                }
            }
        }
        void AddAbsolute_Click(object sender, EventArgs e)
        {
            PointLatLng p = (PointLatLng)current_contextmenu.Tag;
            for (int i = 0; i < model.MaxNumberOfNavigationInstructions(); i++)
            {
                NavigationInstruction ni = model.GetNavigationInstructionLocal(i);

                if (ni.opcode == NavigationInstruction.navigation_command.EMPTY)
                {
                    ni.opcode = NavigationInstruction.navigation_command.FLY_TO_ABS;
                    ni.x = p.Lat / 180.0 * Math.PI;
                    ni.y = p.Lng / 180.0 * Math.PI;
                    ni.a = (int)Properties.Settings.Default.DefaultAltitudeM;
                    model.UpdateLocalNavigationInstruction(ni);
                    break;
                }
            }
        }

#endregion

#region gmap events

        void gmap_MouseMove(object sender, MouseEventArgs e)
        {
            if (current_marker != null && e.Button == MouseButtons.Left && is_mouse_down)
            {
                if (current_marker == home)
                {
                    model.UpdateHome(gmap.FromLocalToLatLng(e.X, e.Y));
                }

                if (current_marker.Overlay == NavigationOverlay)
                {
                    current_marker.Position = gmap.FromLocalToLatLng(e.X - click_offset.X, e.Y - click_offset.Y);
                    if (current_marker is NavigationMarker)
                    {
                        UpdateCurrentMarkerInModel(e.X - click_offset.X, e.Y - click_offset.Y);
                    }
                }
            }
            if (!gmap.IsMouseOverMarker && e.Button == MouseButtons.None)
                current_marker = null;
        }

        void gmap_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (current_marker != null && current_marker.Overlay == NavigationOverlay &&
                e.Button == MouseButtons.Left)
            {
                if ((DateTime.Now - lastclick).TotalMilliseconds < 500) // fake doubleclick
                {
                    WaypointProperties_Click(this, EventArgs.Empty);
                }
                else
                {
                    lastclick = DateTime.Now;
                }
                if (gmap.IsDragging && is_mouse_down)
                    UpdateCurrentMarkerInModel(e.X, e.Y);
                
            }

            if (e.Button == MouseButtons.Right && !gmap.IsDragging)
            {
                ToolStripManager.RevertMerge(current_contextmenu);
                ToolStripManager.Merge(general_menustrip, current_contextmenu);
                if (current_marker != null)
                {
                    ToolStripManager.Merge(navigationmarker_menustrip, current_contextmenu);
                    current_contextmenu.Tag = current_marker.Position;
                }
                else
                    current_contextmenu.Tag = gmap.FromLocalToLatLng(e.X, e.Y);
                current_contextmenu.Show(gmap, e.X, e.Y);
            }
            is_mouse_down = false;
        }

        void gmap_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && current_marker != null)
                is_mouse_down = true;
            else
                is_mouse_down = false;
            if (current_marker != null)
            {
                click_offset = new Point(e.X - current_marker.LocalPosition.X + current_marker.Offset.X, e.Y - current_marker.LocalPosition.Y + current_marker.Offset.Y);
            }
        }

        void gmap_OnMarkerLeave(GMapMarker item)
        {
            if (is_mouse_down == false)
                current_marker = null;
        }

        void gmap_OnMarkerEnter(GMapMarker item)
        {
            if (current_marker == null && (item.Overlay == Overlay || item.Overlay == NavigationOverlay))
            {
                current_marker = item;
            }
        }

        DateTime lastclick = DateTime.Now;
        void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            ;
        }
#endregion 
    }
}
