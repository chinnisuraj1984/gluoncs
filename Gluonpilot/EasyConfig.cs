using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Communication;
using Communication.Frames;


namespace Gluonpilot
{
    public partial class EasyConfig : Form
    {
        private SerialCommunication serial;
        Communication.Frames.Configuration.AllConfig config = null;
        private Artificial3DHorizon.AI3D aI3D = null;
        private bool guiUpdateBusy = false;


        public EasyConfig()
        {
            InitializeComponent();
        }


        public EasyConfig(SerialCommunication serial) : this()
        {
            this.serial = serial;
            serial.AllConfigCommunicationReceived += new SerialCommunication.ReceiveAllConfigCommunicationFrame(serial_AllConfigCommunicationReceived);
            serial.AttitudeCommunicationReceived += new SerialCommunication.ReceiveAttitudeCommunicationFrame(serial_AttitudeCommunicationReceived);
            serial.RcInputCommunicationReceived += new SerialCommunication.ReceiveRcInputCommunicationFrame(serial_RcInputCommunicationReceived);
        }

        void serial_RcInputCommunicationReceived(Communication.Frames.Incoming.RcInput rcinput)
        {
            if (config != null)
            {
                MethodInvoker m = delegate()
                {
                    ProgressBar[] pbs = { _pbChannel1, _pbChannel2, _pbChannel3, _pbChannel4, _pbChannel5, _pbChannel6 };
                    for (int i = 0; i < 6; i++)
                    {
                        if (rcinput.GetPwm(i + 1) > 900)
                            pbs[i].Value = rcinput.GetPwm(i + 1) - 900;
                        else
                            pbs[i].Value = 0;
                    }

                    Label[] channel_labels = {_lblInterpretation1, _lblInterpretation2, _lblInterpretation3, _lblInterpretation4, _lblInterpretation5, _lblInterpretation6 };
                    if (rcinput.GetPwm(config.channel_ap) > 1750)
                        channel_labels[config.channel_ap - 1].Text = "Autopilot mode";
                    else if (rcinput.GetPwm(config.channel_ap) > 1350)
                        channel_labels[config.channel_ap - 1].Text = "Stabilized mode";
                    else if (rcinput.GetPwm(config.channel_ap) > 950)
                        channel_labels[config.channel_ap - 1].Text = "Manual mode";
                    else
                        channel_labels[config.channel_ap - 1].Text = "Undetermined";

                    if (rcinput.GetPwm(config.channel_motor) > 950)
                        channel_labels[config.channel_motor - 1].Text = "Throttle " + ((int)((rcinput.GetPwm(config.channel_motor) - 1000) / 10)).ToString() + "%";
                    else if (rcinput.GetPwm(config.channel_motor) > 800)
                        channel_labels[config.channel_motor - 1].Text = "Throttle in autopilot failsafe";
                    else
                        channel_labels[config.channel_motor - 1].Text = "Undetermined";

                    if (rcinput.GetPwm(config.channel_pitch) > 1750)
                        channel_labels[config.channel_pitch - 1].Text = "Pitching UP";
                    else if (rcinput.GetPwm(config.channel_pitch) > 1250)
                        channel_labels[config.channel_pitch - 1].Text = "Pithing +- neutral";
                    else if (rcinput.GetPwm(config.channel_pitch) > 950)
                        channel_labels[config.channel_pitch - 1].Text = "Pithing DOWN";
                    else
                        channel_labels[config.channel_pitch - 1].Text = "Undetermined";

                    if (rcinput.GetPwm(config.channel_roll) > 1750)
                        channel_labels[config.channel_roll - 1].Text = "Rolling RIGHT";
                    else if (rcinput.GetPwm(config.channel_roll) > 1250)
                        channel_labels[config.channel_roll - 1].Text = "Roll +- neutral";
                    else if (rcinput.GetPwm(config.channel_roll) > 950)
                        channel_labels[config.channel_roll - 1].Text = "Rolling LEFT";
                    else
                        channel_labels[config.channel_roll - 1].Text = "Undetermined";
                };

                try
                {
                    BeginInvoke(m);
                }
                catch
                {
                } 
            }
        }

        void serial_AttitudeCommunicationReceived(Communication.Frames.Incoming.Attitude attitude)
        {
            if (aI3D != null)
            {
                aI3D.Roll = attitude.RollDeg / 180.0 * Math.PI;
                aI3D.Pitch = attitude.PitchDeg / 180.0 * Math.PI;
            }
            artificialHorizon1.pitch_angle = attitude.PitchDeg;
            artificialHorizon1.roll_angle = -attitude.RollDeg;
        }


        void serial_AllConfigCommunicationReceived(Communication.Frames.Configuration.AllConfig config)
        {
            guiUpdateBusy = true;
            _tmrGuiUpdateBusy.Enabled = true;
            _tmrGuiUpdateBusy.Start();

            this.config = config;

            MethodInvoker m = delegate()
            {
                _cbInvert1.Checked = config.servo_reverse[0];
                _cbInvert2.Checked = config.servo_reverse[1];
                _cbInvert3.Checked = config.servo_reverse[2];
                _cbInvert4.Checked = config.servo_reverse[3];
                _cbInvert5.Checked = config.servo_reverse[4];
                _cbInvert6.Checked = config.servo_reverse[5];

                ComboBox[] cbn = { _cbInputFunction1, _cbInputFunction2, _cbInputFunction3, _cbInputFunction4, _cbInputFunction5, _cbInputFunction6 };

                if (config.channel_ap <= 5)
                    cbn[config.channel_ap - 1].SelectedIndex = 4;
                if (config.channel_motor <= 5)
                    cbn[config.channel_motor - 1].SelectedIndex = 3;
                if (config.channel_pitch <= 5)
                    cbn[config.channel_pitch - 1].SelectedIndex = 0;
                if (config.channel_roll <= 5)
                    cbn[config.channel_roll - 1].SelectedIndex = 1;
                if (config.channel_yaw <= 5)
                    cbn[config.channel_yaw - 1].SelectedIndex = 2;

                if (config.control_mixing < _cbMixing.Items.Count)
                    _cbMixing.SelectedIndex = config.control_mixing;

                _hsPitchSensitivity.Value = (int)(config.pid_pitch2elevator_p * 10.0);
                _hsRollSensitivity.Value = (int)(config.pid_roll2aileron_p * 10.0);
            };

            try
            {
                BeginInvoke(m);
            }
            catch
            {
            } 
        }

        private void _btnRead_Click(object sender, EventArgs e)
        {
            serial.ReadAllConfig();
        }

        private void _cbMixing_SelectedIndexChanged(object sender, EventArgs e)
        {
            //serial.Send
            if (_cbMixing.SelectedItem.ToString() == "Aileron")
            {
                _lblFunctionOut1.Text = "Aileron 1";
                _lblFunctionOut2.Text = "Aileron 2";
                _lblFunctionOut3.Text = "Elevator";
                _lblFunctionOut4.Text = "Motor";
                _lblFunctionOut5.Text = "Yaw";
                _lblFunctionOut6.Text = "Camera roll";
            }
            if (_cbMixing.SelectedItem.ToString() == "Delta+")
            {
                _lblFunctionOut1.Text = "Elevon 1";
                _lblFunctionOut2.Text = "Elevon 2";
                _lblFunctionOut3.Text = "";
                _lblFunctionOut4.Text = "Motor";
                _lblFunctionOut5.Text = "";
                _lblFunctionOut6.Text = "";
            }
            if (_cbMixing.SelectedItem.ToString() == "Delta-")
            {
                _lblFunctionOut1.Text = "Elevon 1";
                _lblFunctionOut2.Text = "Elevon 2";
                _lblFunctionOut3.Text = "";
                _lblFunctionOut4.Text = "Motor";
                _lblFunctionOut5.Text = "";
                _lblFunctionOut6.Text = "";
            }
        }

        private void _btnCalibrateGyroscopes_Click(object sender, EventArgs e)
        {
            serial.SendCalibrateGyros();
        }

        private void _btnCalibrateAccelerometers_Click(object sender, EventArgs e)
        {
            serial.SendCalibrateAcceleros();
        }

        private void EasyConfig_Load(object sender, EventArgs e)
        {
            aI3D = new Artificial3DHorizon.AI3D("Models\\Funjet\\funjet.x");
            aI3D.Dock = DockStyle.Fill;
            _pl3d.Controls.Add(aI3D);
            Control c = this;
            while (c.BackColor == Color.Transparent)
                c = c.Parent;
            aI3D.BackColor = c.BackColor;
        }

        private void _hsSensitivity_ValueChanged(object sender, EventArgs e)
        {
            _lblRollSensitivity.Text = "(" + (((double)_hsRollSensitivity.Value) / 10.0).ToString("F1") + ")";
            _lblPitchSensitivity.Text = "(" + (((double)_hsPitchSensitivity.Value) / 10.0).ToString("F1") + ")";
        }

        private void _cbInvert_CheckedChanged(object sender, EventArgs e)
        {
            if (!guiUpdateBusy)
                serial.SendServoReverse(_cbInvert1.Checked, _cbInvert2.Checked, _cbInvert3.Checked, _cbInvert4.Checked, _cbInvert5.Checked, _cbInvert6.Checked);
        }

        private void _tmrGuiUpdateBusy_Tick(object sender, EventArgs e)
        {
            guiUpdateBusy = false;
        }

        private void _cbInputFunction_SelectionChanged(object sender, EventArgs e)
        {
            if (!guiUpdateBusy)
            {
                // Pitch Roll Yaw Motor Mode (none)
                int channel_ap = 4, channel_motor = 3, channel_pitch = 0, channel_roll = 1, channel_yaw = 2;
                int[] channels = { channel_pitch, channel_roll, channel_yaw, channel_motor, channel_ap };
                if (_cbInputFunction1.SelectedIndex >= 0)
                    channels[_cbInputFunction1.SelectedIndex] = 1;
                if (_cbInputFunction2.SelectedIndex >= 0)
                    channels[_cbInputFunction2.SelectedIndex] = 2;
                if (_cbInputFunction3.SelectedIndex >= 0)
                    channels[_cbInputFunction3.SelectedIndex] = 3;
                if (_cbInputFunction4.SelectedIndex >= 0)
                    channels[_cbInputFunction4.SelectedIndex] = 4;
                if (_cbInputFunction5.SelectedIndex >= 0)
                    channels[_cbInputFunction5.SelectedIndex] = 5;
                serial.SendConfigChannels(config.rc_ppm, channels[channel_ap], channels[channel_motor], channels[channel_pitch], channels[channel_roll], channels[channel_yaw]);
            }
        }

        private void EasyConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            serial.AllConfigCommunicationReceived -= new SerialCommunication.ReceiveAllConfigCommunicationFrame(serial_AllConfigCommunicationReceived);
            serial.AttitudeCommunicationReceived -= new SerialCommunication.ReceiveAttitudeCommunicationFrame(serial_AttitudeCommunicationReceived);
            serial.RcInputCommunicationReceived -= new SerialCommunication.ReceiveRcInputCommunicationFrame(serial_RcInputCommunicationReceived);

        }
    }
}
