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
        public bool IncludeTriggerCommands = false;
        public bool DoCross = false;

        public SurveyProperties()
        {
            InitializeComponent();
            _dtbAltitudeM.DistanceM = Properties.Settings.Default.SurveyAltitudeM;
            _dtbDistanceM.DistanceM = Properties.Settings.Default.SurveyDistanceM;
            _nudFlightPath.Value = (decimal)Properties.Settings.Default.SurveyAngleDeg;
            _cbTriggerCommands.Checked = Properties.Settings.Default.SurveyIncludeTriggerCommands;
            _cbCross.Checked = Properties.Settings.Default.SurveyDoCross;
            surveyAngle1.AngleChanged += new SurveyAngle.AngleChangedDelegate(surveyAngle1_AngleChanged);
        }

        void surveyAngle1_AngleChanged(double new_angle)
        {
            if ((double)_nudFlightPath.Maximum >= new_angle && (double)_nudFlightPath.Minimum <= new_angle)
                _nudFlightPath.Value = (decimal)new_angle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DistanceM = _dtbDistanceM.DistanceM;
            AngleDeg = (int)_nudFlightPath.Value;
            AltitudeM = _dtbAltitudeM.DistanceM;
            IncludeTriggerCommands = _cbTriggerCommands.Checked;
            DoCross = _cbCross.Checked;

            Properties.Settings.Default.SurveyAltitudeM = AltitudeM;
            Properties.Settings.Default.SurveyAngleDeg = AngleDeg;
            Properties.Settings.Default.SurveyDistanceM = DistanceM;
            Properties.Settings.Default.SurveyIncludeTriggerCommands = IncludeTriggerCommands;
            Properties.Settings.Default.SurveyDoCross = DoCross;
            Properties.Settings.Default.Save();
        }

        private void _nudFlightPath_ValueChanged(object sender, EventArgs e)
        {
            if (_nudFlightPath.Value == 360)
                _nudFlightPath.Value = 0;
            surveyAngle1.Angle = (double)_nudFlightPath.Value;
            surveyAngle1.Invalidate();
        }
    }
}
