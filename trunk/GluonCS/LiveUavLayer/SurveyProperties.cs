using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GluonCS.LiveUavLayer
{
    public partial class SurveyProperties : Form
    {
        public double DistanceM = 75;
        public double AngleDeg = 0;
        public double AltitudeM = 100;

        public SurveyProperties()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DistanceM = _dtbDistanceM.DistanceM;
            AngleDeg = (int)_nudFlightPath.Value;
            AltitudeM = _dtbAltitudeM.DistanceM;

            Properties.Settings.Default.SurveyAltitudeM = AltitudeM;
            Properties.Settings.Default.SurveyAngleDeg = AngleDeg;
            Properties.Settings.Default.SurveyDistanceM = DistanceM;
            Properties.Settings.Default.Save();
        }
    }
}
