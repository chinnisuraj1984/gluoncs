using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace GluonCS
{
    public partial class SplashScreen : Form
    {
        private static string assemblyPath = Assembly.GetExecutingAssembly().GetName().Name.Replace(' ', '_');
        private Image splashimage = Image.FromStream(GetResource("Splash Screen.png"));

        public SplashScreen()
        {
            InitializeComponent();
        }

        public static System.IO.Stream GetResource(string fileName)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(assemblyPath + '.' + fileName);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //  Do nothing here!
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;

            gfx.DrawImage(splashimage, new Rectangle(0, 0, this.Width, this.Height));

        }

        public void fade()
        {
            fade_timer.Start();
        }

        private void fade_timer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
                this.Opacity -= 0.5;
            else
            {
                fade_timer.Stop();
                this.Close();
            }
        }
    }
}
