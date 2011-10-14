using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap;
using GMap.NET;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace GluonCS.Markers
{
    public class IconMarker : NavigationMarker
    {
        public Pen Pen;
        private static Image pin;
        private static Image pingray;
        private static Image pinyellow;
        public bool IsAbsolute;
        private Brush myredbrush = new SolidBrush(Color.FromArgb(255, 252, 112, 112));
        private Brush mygraybrush = new SolidBrush(Color.FromArgb(255, 62, 62, 62));

        private void LoadImages()
        {
            if (pin == null)
                pin = Image.FromFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\Resources\\marker_empty_white.png");
            if (pingray == null)
                pingray = Image.FromFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\Resources\\marker_empty_gray.png");
            if (pinyellow == null)
                pinyellow = Image.FromFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\Resources\\marker_empty_yellow.png");
        }

        public IconMarker(PointLatLng p, int wp_number, bool is_absolute, bool out_of_sync = false, bool is_current_waypoint = false)
            : base(p, wp_number, is_current_waypoint, out_of_sync)
        {
            LoadImages();

            IsAbsolute = is_absolute;
            // do not forget set Size of the marker
            // if so, you shall have no event on it ;}
            Size = new System.Drawing.Size(14, 24);
            Offset = new System.Drawing.Point(-Size.Width / 2, -Size.Height);
            if (out_of_sync)
                Pen = new Pen(Brushes.Gray, 2);
            else
                Pen = new Pen(Brushes.Red, 2);
        }

        public override void OnRender(Graphics g)
        {
            string str = Name == "" ? (Number + 1).ToString() : Name;

            Brush backgroundmarkercolor = Brushes.White;
            if (IsCurrentWaypoint)
                backgroundmarkercolor = Brushes.Yellow;

            g.DrawString(str, new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, LocalPosition.X + 14 + 1, LocalPosition.Y + 4);
            g.DrawString(str, new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, LocalPosition.X + 14 - 1, LocalPosition.Y + 4);
            g.DrawString(str, new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, LocalPosition.X + 14, LocalPosition.Y + 4 + 1);
            g.DrawString(str, new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, LocalPosition.X + 14, LocalPosition.Y + 4 - 1);
            if (out_of_sync)
                g.DrawString(str, new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.LightGray, LocalPosition.X + 14, LocalPosition.Y + 4);
            else
                g.DrawString(str, new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), myredbrush , LocalPosition.X + 14, LocalPosition.Y + 4);
            

            //g.FillRectangle(backgroundmarkercolor, new Rectangle(LocalPosition.X, LocalPosition.Y, Size.Width, Size.Height));
            if (out_of_sync)
                g.DrawImage(pingray, new Point(LocalPosition.X - 4, LocalPosition.Y + pin.Height - Size.Height +2));
            else if (IsCurrentWaypoint)
                g.DrawImage(pinyellow, new Point(LocalPosition.X - 4, LocalPosition.Y + pin.Height - Size.Height + 2));
            else
                g.DrawImage(pin, new Point(LocalPosition.X - 4, LocalPosition.Y + pin.Height - Size.Height + 2));
            //g.DrawRectangle(Pen, new Rectangle(LocalPosition.X - (-6) / 2, LocalPosition.Y - (-6) / 2, Size.Width - 6, Size.Height - 6));

            /*SizeF sf = g.MeasureString(str, new Font(FontFamily.GenericSansSerif, 6, FontStyle.Bold));
            g.DrawString(str, new Font(FontFamily.GenericSansSerif, 6, FontStyle.Bold), mygraybrush, LocalPosition.X + 9 - ((int)sf.Width/2) - 2, LocalPosition.Y + 6);
            */
            /*SizeF sf = g.MeasureString(str, new Font(FontFamily.GenericSansSerif, 7, FontStyle.Regular));
            g.DrawString(str, new Font(FontFamily.GenericSansSerif, 7, FontStyle.Regular), mygraybrush, LocalPosition.X + 9 - ((int)sf.Width / 2) - 2, LocalPosition.Y + 3);*/

        }
    }
}
