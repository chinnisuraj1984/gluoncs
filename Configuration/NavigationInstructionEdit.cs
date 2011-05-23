using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Communication.Frames.Incoming;
using System.Globalization;
using Configuration.NavigationCommands;


namespace Configuration
{
    public partial class NavigationInstructionEdit : Form
    {
        NavigationInstruction ni;

        public NavigationInstruction NavigationInstr
        {
            get { return ni; }

        }

        public NavigationInstructionEdit(NavigationInstruction ni, double homelat, double homelng)
        {
            InitializeComponent();
            this.ni = ni;

            if ((int)ni.opcode > 25)
                ni.opcode = 0;

                /*
                    0. EMPTY
                    GOTO
                    CLIMB
                    FROM_TO
                    FLY_TO
                    5. CIRCLE
                    IF()
                    UNTIL()
                    SERVO_SET(channel, position_us)
                    SERVO_TRIGGER(channel, position_us, hold_sec)
                    10 BLOCK
                    */
            if (ni.opcode == NavigationInstruction.navigation_command.BLOCK)
                _cb_opcode.SelectedIndex = 10;
            else if (ni.opcode == NavigationInstruction.navigation_command.CIRCLE_ABS ||
                     ni.opcode == NavigationInstruction.navigation_command.CIRCLE_REL)
                _cb_opcode.SelectedIndex = 5;
            else if (ni.opcode == NavigationInstruction.navigation_command.CLIMB)
                _cb_opcode.SelectedIndex = 2;
            else if (ni.opcode == NavigationInstruction.navigation_command.EMPTY)
                _cb_opcode.SelectedIndex = 0;
            else if (ni.opcode == NavigationInstruction.navigation_command.FLY_TO_ABS ||
                     ni.opcode == NavigationInstruction.navigation_command.FLY_TO_REL)
                _cb_opcode.SelectedIndex = 4;
            else if (ni.opcode == NavigationInstruction.navigation_command.FROM_TO_ABS ||
                        ni.opcode == NavigationInstruction.navigation_command.FROM_TO_REL)
                _cb_opcode.SelectedIndex = 3;
            else if (ni.opcode == NavigationInstruction.navigation_command.GOTO)
                _cb_opcode.SelectedIndex = 1;
            else if (ni.opcode == NavigationInstruction.navigation_command.SERVO_SET)
                _cb_opcode.SelectedIndex = 8;
            else if (ni.opcode == NavigationInstruction.navigation_command.SERVO_TRIGGER)
                _cb_opcode.SelectedIndex = 9;
            else if (ni.opcode == NavigationInstruction.navigation_command.IF_EQ ||
                     ni.opcode == NavigationInstruction.navigation_command.IF_NE ||
                     ni.opcode == NavigationInstruction.navigation_command.IF_GR ||
                     ni.opcode == NavigationInstruction.navigation_command.IF_SM)
                _cb_opcode.SelectedIndex = 6;
            //_cb_opcode.SelectedIndex = (int)ni.opcode;
        }


        private void _btn_cancel_Click(object sender, EventArgs e)
        {
            //this.ni = copy_ni;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void _btn_ok_Click(object sender, EventArgs e)
        {
            ni = ((INavigationCommandViewer)tableLayoutPanel.Controls[0]).GetNavigationInstruction();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void _cb_opcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_gb_edit.Enabled = true;

            //ni.opcode = (NavigationInstruction.navigation_command)_cb_opcode.SelectedIndex;

            // already a navigationcommand on the panel? delete it so we can add a new one.
            if (tableLayoutPanel.Controls.Count > 0)
                tableLayoutPanel.Controls.RemoveAt(tableLayoutPanel.Controls.Count-1);

            // Add the correct usercontrol
            Control c;
            if (_cb_opcode.Text == "CIRCLE")
                c = new NavigationCommands.Circle(ni);
            else if (_cb_opcode.Text.StartsWith("GOTO"))
                c = new NavigationCommands.Goto(ni);
            else if (_cb_opcode.Text.StartsWith("CLIMB"))
                c = new NavigationCommands.Climb(ni);
            else if (_cb_opcode.Text.StartsWith("SERVO_SET"))
                c = new NavigationCommands.ServoSet(ni);
            else if (_cb_opcode.Text.StartsWith("SERVO_TRIGGER"))
                c = new NavigationCommands.ServoTrigger(ni);
            else if (_cb_opcode.Text.StartsWith("FLY_TO"))
                c = new NavigationCommands.FlyTo(ni);
            else if (_cb_opcode.Text.StartsWith("FROM_TO"))
                c = new NavigationCommands.FromTo(ni);
            else if (_cb_opcode.Text.StartsWith("IF"))
                c = new NavigationCommands.If(ni);
            else if (_cb_opcode.SelectedIndex == (int)NavigationInstruction.navigation_command.FLY_TO_REL)
                c = new NavigationCommands.FlyToRel(ni);
            else if (_cb_opcode.SelectedIndex == (int)NavigationInstruction.navigation_command.CIRCLE_ABS)
                c = new NavigationCommands.CircleAbs(ni);
            else if (_cb_opcode.SelectedIndex == (int)NavigationInstruction.navigation_command.FLY_TO_ABS)
                c = new NavigationCommands.FlyToAbs(ni);
            else if (_cb_opcode.SelectedIndex == (int)NavigationInstruction.navigation_command.FROM_TO_REL)
                c = new NavigationCommands.FromToRel(ni);
            else if (_cb_opcode.SelectedIndex == (int)NavigationInstruction.navigation_command.FROM_TO_ABS)
                c = new NavigationCommands.FromToAbs(ni);
            else if (_cb_opcode.SelectedIndex == (int)NavigationInstruction.navigation_command.UNTIL_GR)
                c = new NavigationCommands.UntilGr(ni);
            else if (_cb_opcode.SelectedIndex == (int)NavigationInstruction.navigation_command.UNTIL_SM)
                c = new NavigationCommands.UntilSm(ni);
            else if (_cb_opcode.SelectedIndex == (int)NavigationInstruction.navigation_command.UNTIL_EQ)
                c = new NavigationCommands.UntilEq(ni);
            else if (_cb_opcode.SelectedIndex == (int)NavigationInstruction.navigation_command.UNTIL_NE)
                c = new NavigationCommands.UntilNe(ni);
            else if (_cb_opcode.SelectedIndex == (int)NavigationInstruction.navigation_command.IF_GR)
                c = new NavigationCommands.IfGr(ni);
            else if (_cb_opcode.SelectedIndex == (int)NavigationInstruction.navigation_command.IF_SM)
                c = new NavigationCommands.IfSm(ni);
            else if (_cb_opcode.SelectedIndex == (int)NavigationInstruction.navigation_command.IF_EQ)
                c = new NavigationCommands.IfEq(ni);
            else if (_cb_opcode.SelectedIndex == (int)NavigationInstruction.navigation_command.IF_NE)
                c = new NavigationCommands.IfNe(ni);
            else //if (_cb_opcode.SelectedIndex == (int)NavigationInstruction.navigation_command.EMPTY)
                c = new NavigationCommands.Empty(ni);

            // add our edit-control
            tableLayoutPanel.Controls.Add(c);
            tableLayoutPanel.SetCellPosition(c, new TableLayoutPanelCellPosition(0, 1));

            // Do some lay-outin'
            c.Anchor = AnchorStyles.None;
            //tableLayoutPanel.RowStyles[0].Height = c.Height;
            //tableLayoutPanel.Height = c.Height + 30;
            //this.Height = tableLayoutPanel.Height;
        }

    }
}
