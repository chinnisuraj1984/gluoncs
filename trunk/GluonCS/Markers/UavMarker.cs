using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap;
using GMap.NET;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace GluonCS.Markers
{
    public class UavMarker : GMapMarker
    {
        public double Yaw = 80;
        public double AltitudeAglM = 0;
        public double SpeedMS = 0;
        public string AlarmMessage = "";

        public UavMarker(PointLatLng p)
            : base(p)
        {
            // do not forget set Size of the marker
            // if so, you shall have no event on it ;}
            Size = new System.Drawing.Size(36, 14);
            //Offset = new System.Drawing.Point(-Size.Width / 2, -Size.Height / 2);
            this.IsHitTestVisible = false;
        }

        public override void OnRender(Graphics g)
        {
            SizeF sf1, sf2;

            GraphicsState s = g.Save();
            g.TranslateTransform(LocalPosition.X, LocalPosition.Y);
            g.RotateTransform((float)Yaw, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            g.FillPolygon(Brushes.Red, new Point[]{
                    new Point(0, 0 - Size.Height/2), 
                    new Point(0 + Size.Width/2, 0 + Size.Height/2), 
                    new Point(0 , 0 + Size.Height/2 - Size.Height/5), 
                    new Point(0 - Size.Width/2, 0 + Size.Height/2)});
            g.DrawPolygon(new Pen(Brushes.DarkRed, 1), new Point[]{
                    new Point(0, 0 - Size.Height/2), 
                    new Point(0 + Size.Width/2, 0 + Size.Height/2), 
                    new Point(0 , 0 + Size.Height/2 - Size.Height/5), 
                    new Point(0 - Size.Width/2, 0 + Size.Height/2)});
            g.Restore(s);

            
            sf1 = g.MeasureString("Gluonpilot", new Font(FontFamily.GenericSansSerif, 7));
            DrawContrastString("Gluonpilot", g, LocalPosition.X - (int)sf1.Width / 2, LocalPosition.Y + Size.Height / 2 + 5, 7, Brushes.White);

            if (Properties.Settings.Default.ShowUavSpeedAltitude)
            {
                string speed = ((int)(SpeedMS * 3.6)).ToString();
                sf1 = g.MeasureString(speed, new Font(FontFamily.GenericSansSerif, 8));
                sf2 = g.MeasureString("km/h", new Font(FontFamily.GenericSansSerif, 7));
                DrawContrastString(speed, g, LocalPosition.X - (int)(sf1.Width / 2 + sf2.Width / 2), LocalPosition.Y - Size.Height / 2 - (int)sf1.Height - 5, 8, Brushes.White);
                DrawContrastString("km/h", g, LocalPosition.X - (int)(-sf1.Width / 2 + sf2.Width / 2), LocalPosition.Y - Size.Height / 2 - (int)sf1.Height - 5, 7, Brushes.White);

                string altitude = AltitudeAglM.ToString();
                sf1 = g.MeasureString(altitude, new Font(FontFamily.GenericSansSerif, 8));
                sf2 = g.MeasureString("m AGL", new Font(FontFamily.GenericSansSerif, 7));
                DrawContrastString(altitude, g, LocalPosition.X + Size.Width / 2 - 5, LocalPosition.Y - (int)sf1.Height / 2, 8, Brushes.White);
                DrawContrastString("m AGL", g, LocalPosition.X + Size.Width / 2 - 5 + (int)sf1.Width, LocalPosition.Y - (int)sf1.Height / 2 + (int)sf1.Height - (int)sf2.Height - 1, 7, Brushes.White);
            }

            if (AlarmMessage.Length > 0)
            {
                sf1 = g.MeasureString(AlarmMessage, new Font(FontFamily.GenericSansSerif, 7));
                DrawContrastString(AlarmMessage, g, LocalPosition.X - (int)sf1.Width / 2, LocalPosition.Y + Size.Height / 2 + 5 + (int)sf1.Height + 5, 7, Brushes.Red);
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
    }
}
