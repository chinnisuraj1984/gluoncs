using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GluonCS.LiveUavLayer
{
    public partial class SurveyAngle : UserControl
    {
        private Image surveyImage;

        public delegate void AngleChangedDelegate(double new_angle);

        public event AngleChangedDelegate AngleChanged;

        private double start_angle_deg = 0;
        private double start_angle_deg_click = 0;

        private double angle_deg;
        public double Angle
        {
            get
            {
                return angle_deg;
            }
            set
            {
                angle_deg = value;
            }
        }

        public SurveyAngle()
        {
            InitializeComponent();
            try
            {
                surveyImage = Image.FromFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\Resources\\surveyimage.png");
            }
            catch (Exception ex)
            {
            }
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(Pens.DarkGray, 0, 0, this.Width, this.Height);
            if (surveyImage != null)
            {
                e.Graphics.FillRectangle(Brushes.White, new Rectangle(1, 1, this.Width-2, this.Height-2));
                e.Graphics.TranslateTransform(75, 75);
                e.Graphics.RotateTransform((float)angle_deg);
                e.Graphics.DrawImage(surveyImage, new Point(-50, -50));
            }
        }

        private void SurveyAngle_MouseClick(object sender, MouseEventArgs e)
        {
            //angle_deg = Math.Atan(((double)e.Y - (double)this.Height / 2.0) / ((double)e.X - (double)this.Width / 2.0)) / Math.PI * 180.0;
            //this.Invalidate();
        }

        private void SurveyAngle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                angle_deg = start_angle_deg_click  - start_angle_deg + Math.Atan2(((double)e.Y - (double)this.Height / 2.0), ((double)e.X - (double)this.Width / 2.0)) / Math.PI * 180.0;
                if (angle_deg < 0)
                    angle_deg += 360.0;
                if (angle_deg > 360)
                    angle_deg -= 360.0;

                this.Invalidate();
                if (AngleChanged != null)
                    AngleChanged(angle_deg);
            }
        }

        private void SurveyAngle_MouseDown(object sender, MouseEventArgs e)
        {
            start_angle_deg = Math.Atan2(((double)e.Y - (double)this.Height / 2.0), ((double)e.X - (double)this.Width / 2.0)) / Math.PI * 180.0;
            start_angle_deg_click = angle_deg;
        }
    }
}
