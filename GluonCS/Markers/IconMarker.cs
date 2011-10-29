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
using System.Drawing.Text;


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
                //pin = Image.FromFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\Resources\\marker_empty_white.png");
                pin = Image.FromFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\Resources\\marker_empty_red.png");
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
            Size = new System.Drawing.Size(2*pin.Width/3, pin.Height);
            Offset = new System.Drawing.Point(-pin.Width / 2 +5, -Size.Height);
            if (out_of_sync)
                Pen = new Pen(Brushes.Gray, 2);
            else
                Pen = new Pen(Brushes.Red, 2);
        }

        public override void OnRender(Graphics g)
        {
            string str = Name == "" ? (Number + 1).ToString() : Name;
            int y_pad = 0;

            Brush backgroundmarkercolor = Brushes.White;
            if (IsCurrentWaypoint)
                backgroundmarkercolor = Brushes.Yellow;

            /*g.DrawString(str, new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, LocalPosition.X + 14 + 1, LocalPosition.Y + 4);
            g.DrawString(str, new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, LocalPosition.X + 14 - 1, LocalPosition.Y + 4);
            g.DrawString(str, new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, LocalPosition.X + 14, LocalPosition.Y + 4 + 1);
            g.DrawString(str, new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.Black, LocalPosition.X + 14, LocalPosition.Y + 4 - 1);
            if (out_of_sync)
                g.DrawString(str, new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), Brushes.LightGray, LocalPosition.X + 14, LocalPosition.Y + 4);
            else
                g.DrawString(str, new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold), myredbrush , LocalPosition.X + 14, LocalPosition.Y + 4);
            */

            //g.FillRectangle(backgroundmarkercolor, new Rectangle(LocalPosition.X, LocalPosition.Y, Size.Width, Size.Height));
            if (out_of_sync)
                g.DrawImage(pingray, new Point(LocalPosition.X - 4, LocalPosition.Y + pin.Height - Size.Height +2));
            else if (IsCurrentWaypoint)
                g.DrawImage(pinyellow, new Point(LocalPosition.X - 4, LocalPosition.Y + pin.Height - Size.Height + 2));
            else
                g.DrawImage(pin, new Point(LocalPosition.X - 4, LocalPosition.Y + pin.Height - Size.Height + 2));
            //g.DrawRectangle(Pen, new Rectangle(LocalPosition.X - (-6) / 2, LocalPosition.Y - (-6) / 2, Size.Width - 6, Size.Height - 6));

            /*SizeF sf = g.MeasureString(str, new Font(FontFamily.GenericSansSerif, 6, FontStyle.Bold));
            g.DrawString(str, new Font(FontFamily.GenericSansSerif, 6, FontStyle.Bold), mygraybrush, LocalPosition.X + 9 - ((int)sf.Width/2) - 2, LocalPosition.Y + 6);*/

            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            Font font = new Font(FontFamily.GenericSansSerif, 7, FontStyle.Bold);
            SizeF sf = g.MeasureString(str, font);
 
            if (str.Length > 2)
                y_pad += pin.Height / 2 + 12;

            float ypos = LocalPosition.Y + 4;
            float xpos = (float)LocalPosition.X + (float)12 - (float)Math.Floor(sf.Width / 2 - 0.0) - 2;
            if (str.Length > 1 && str.Substring(0, 1) == "1")
                xpos -= 1; // hack to make it look better

            g.DrawString(str, font, Brushes.Black, xpos + 1, ypos + 1 + y_pad);
            g.DrawString(str, font, Brushes.Black, xpos + 1, ypos - 1 + y_pad);
            g.DrawString(str, font, Brushes.Black, xpos - 1, ypos + 1 + y_pad);
            g.DrawString(str, font, Brushes.Black, xpos - 1, ypos - 1 + y_pad);
            g.DrawString(str, font, Brushes.White, xpos, ypos + y_pad);

        }
    }
}
