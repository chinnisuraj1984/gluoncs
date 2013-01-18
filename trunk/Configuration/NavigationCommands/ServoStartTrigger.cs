using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Communication.Frames.Incoming;

namespace Configuration.NavigationCommands
{
    public partial class ServoStartTrigger : UserControl, INavigationCommandViewer
    {
        private NavigationInstruction ni;

        public ServoStartTrigger(NavigationInstruction ni)
        {
            InitializeComponent();
            SetNavigationInstruction(ni);
        }

        #region INavigationCommandViewer Members

        public NavigationInstruction GetNavigationInstruction()
        {
            ni.a = (int)_nud_channel.Value - 1;
            ni.b = (int)_nud_us.Value;
            //ni.x = ((double)_nud_position_hold.Value) / 1000.0;
            if (!_cb_trigger_mode.SelectedItem.ToString().Contains("istance"))
                ni.x = ((double)_nud_time_between_triggers_ms.Value) / 1000.0;
            else
                ni.x = ((double)_nud_time_between_triggers_ms.Value);
            ni.y = _cb_trigger_mode.SelectedIndex;
            ni.opcode = NavigationInstruction.navigation_command.SERVO_TRIGGER_START;
            return ni;
        }

        public void SetNavigationInstruction(NavigationInstruction ni)
        {
            this.ni = ni;
            _nud_channel.Value = Math.Min(7, ni.a) + 1;
            _nud_us.Value = Math.Min(_nud_us.Maximum, Math.Max(_nud_us.Minimum, ni.b));
            //_nud_position_hold.Value = (int)(Math.Max(0.001, Math.Min(3, ni.x)) * 1000.0);

            if (Math.Round(ni.y) == 1)
                _cb_trigger_mode.SelectedIndex = 1;
            else if (Math.Round(ni.y) == 2)
                _cb_trigger_mode.SelectedIndex = 2;
            else
                _cb_trigger_mode.SelectedIndex = 0;

            if (!_cb_trigger_mode.SelectedItem.ToString().Contains("istance"))
                _nud_time_between_triggers_ms.Value = (int)(Math.Min(_nud_time_between_triggers_ms.Maximum, Math.Max(_nud_time_between_triggers_ms.Minimum, (int)(ni.x * 1000.0))));
            else
                _nud_time_between_triggers_ms.Value = (int)(Math.Min(_nud_time_between_triggers_ms.Maximum, Math.Max(_nud_time_between_triggers_ms.Minimum, (int)(ni.x))));

        }

        #endregion

        private void _cb_trigger_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _nud_time_between_triggers_ms.Enabled = true;
            _nud_us.Enabled = true;
            _nud_time_between_triggers_ms.Increment = 100;

            if (_cb_trigger_mode.SelectedItem != null && _cb_trigger_mode.SelectedItem.ToString().Contains("istance"))
            {
                label4.Text = "Distance between triggers [m]";
                _nud_time_between_triggers_ms.Increment = 1;
            }
            else
            {
                label4.Text = "Time between triggers [ms]";
                if (_cb_trigger_mode.SelectedItem != null && _cb_trigger_mode.SelectedItem.ToString().Contains("CHDK"))
                {
                    _nud_time_between_triggers_ms.Enabled = false;
                    _nud_us.Enabled = false;
                }
            }
        }
    }
}
