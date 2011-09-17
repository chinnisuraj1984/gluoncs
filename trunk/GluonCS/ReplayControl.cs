using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Communication;

namespace GluonCS
{
    public partial class ReplayControl : Form
    {
        public SerialCommunication_replay SerialReplay;  
 
        public ReplayControl()
        {
            InitializeComponent();
        }

        private void _btn_play_Click(object sender, EventArgs e)
        {
            if (_btn_play.Checked)
            {
                SerialReplay.Play = false;
                _btn_play.Checked = false;
                _btn_pauze.Checked = true;
            }
            else
            {
                SerialReplay.Play = true;
                _btn_play.Checked = true;
                _btn_pauze.Checked = false;
            }
        }

        private void _btn_pauze_Click(object sender, EventArgs e)
        {
            if (_btn_pauze.Checked)
            {
                SerialReplay.Play = true;
                _btn_play.Checked = true;
                _btn_pauze.Checked = false;
            }
            else
            {
                SerialReplay.Play = false;
                _btn_play.Checked = false;
                _btn_pauze.Checked = true;
            }
        }

        private void _btn_double_speed_Click(object sender, EventArgs e)
        {
            if (!_btn_double_speed.Checked)
            {
                SerialReplay.DoubleSpeed = true;
                SerialReplay.QuadSpeed = false;
                _btn_double_speed.Checked = true;
                _btn_quad_speed.Checked = false;
            }
            else
            {
                SerialReplay.DoubleSpeed = false;
                SerialReplay.QuadSpeed = false;
                _btn_double_speed.Checked = false;
                _btn_quad_speed.Checked = false;
            }
        }

        private void _btn_quad_speed_Click(object sender, EventArgs e)
        {
            if (!_btn_quad_speed.Checked)
            {
                SerialReplay.QuadSpeed = true;
                SerialReplay.DoubleSpeed = false;
                _btn_double_speed.Checked = false;
                _btn_quad_speed.Checked = true;
            }
            else
            {
                SerialReplay.DoubleSpeed = false;
                SerialReplay.QuadSpeed = false;
                _btn_double_speed.Checked = false;
                _btn_quad_speed.Checked = false;
            }
        }
    }
}
