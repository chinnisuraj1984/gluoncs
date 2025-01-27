﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Communication;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;
using Configuration;

namespace Gluonpilot
{
    public partial class GluonConfig : Form
    {
        private DateTime connected;
        private int logging_height;
        private SerialCommunication_CSV _serial;
        
        public GluonConfig()
        {
            InitializeComponent();
            logging_height = splitContainer1.Panel2.Height;
            timer.Start();
        }

        public GluonConfig(SerialCommunication serial)
            : this()
        {
            if (serial is SerialCommunication_CSV)
            {
                this._serial = (SerialCommunication_CSV)serial;
                if (_serial != null && _serial.IsOpen)
                    _btn_connect.Checked = true;
                ConnectPanels();
            }
        }


        private void _btn_showlogging_Click(object sender, EventArgs e)
        {
            _btn_showlogging.Checked = !_btn_showlogging.Checked;

            if (_btn_showlogging.Checked)
            {
                this.Height += logging_height + splitContainer1.SplitterWidth;
                splitContainer1.Panel2Collapsed = false;
            }
            else
            {
                this.Height -= logging_height + splitContainer1.SplitterWidth;
                splitContainer1.Panel2Collapsed = true;
            }
            splitContainer1.Refresh();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (!splitContainer1.Panel2Collapsed)
                logging_height = splitContainer1.Panel2.Height;
        }

        private void GluonConfig_Resize(object sender, EventArgs e)
        {

        }

        private void _btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (_btn_connect.Checked)
                {
                    _serial.Close();
                    //DisconnectPanels();

                    _btn_connect.Checked = false;
                }
                else
                {
                    connected = DateTime.Now;
                    /*if (_serial != null)
                    {
                        //_serial.Close();
                        string portname = _serial.PortName;
                        int baudrate = _serial.BaudRate;
                        //if (_serial == null)
                        //_serial = new SerialCommunication_CSV();
                        _serial.Open(portname, baudrate);
                        _btnBasicConfiguration.Enabled = true;
                    }
                    else
                    {*/
                        ConnectDialog cd = new ConnectDialog();
                        cd.ShowDialog(this);
                        if (_serial == null)
                        {
                            _serial = new SerialCommunication_CSV();
                            ConnectPanels();
                        }
                        _serial.Open(cd.SelectedPort(), cd.SelectedBaudrate());
                       
                    //}
                    //ConnectPanels();
                    _btn_connect.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConnectPanels()
        {
            configurationControl.Connect(_serial);
            datalogging.Connect(_serial);
            gluonConfigEasy.Connect(_serial);
            osdConfig1.Connect(_serial);
            //navigationListView1.Connect(_serial);
            gcsMainPanel1.Connect(_serial);

            //_btnBasicConfiguration.Enabled = true;
            _btn_reboot.Enabled = true;

            _serial.CommunicationReceived += new SerialCommunication_CSV.ReceiveCommunication(ReceiveCommunication);
            _serial.NonParsedCommunicationReceived += new SerialCommunication.ReceiveNonParsedCommunication(ReceiveNonParsedCommunication);
        }

        private void DisconnectPanels()
        {
            configurationControl.Disconnect();
            datalogging.Disconnect();
            gluonConfigEasy.Disconnect();
            osdConfig1.Disconnect();
            //navigationListView1.Disconnect();
            gcsMainPanel1.Disconnnect();

            //_btnBasicConfiguration.Enabled = false;
            _btn_reboot.Enabled = false;

            if (_serial != null)
            {
                _serial.CommunicationReceived -= new SerialCommunication_CSV.ReceiveCommunication(ReceiveCommunication);
                _serial.NonParsedCommunicationReceived -= new SerialCommunication.ReceiveNonParsedCommunication(ReceiveNonParsedCommunication);
            }
        }


        private delegate void UpdateTextBox(string line);
        private void ReceiveCommunication(string line)
        {
            if (!this._cb_hide_parsed.Checked)
                this.BeginInvoke(new UpdateTextBox(UpdateText), new object[] { line });
        }
        private void ReceiveNonParsedCommunication(string line)
        {
            if (this._cb_hide_parsed.Checked)
                this.BeginInvoke(new UpdateTextBox(UpdateText), new object[] { line });
        }
        private void UpdateText(string line)
        {
            if (_cb_print_timestamp.Checked)
                _tb_logging.AppendText("[" + DateTime.Now.ToString("hh:mm:ss.ff") + "]  ");
            _tb_logging.AppendText(line + "\r\n");
            _tb_logging.ScrollToCaret();
        }

        private void _btn_reboot_Click(object sender, EventArgs e)
        {
            _serial.SendReboot();
        }

        private void _btn_firmware_upgrade_Click(object sender, EventArgs e)
        {
            int baudrate = _serial.BaudRate;
            string port = _serial.PortName;

            bool connected = _btn_connect.Checked;

            //if (MessageBox.Show(this, "Upgrading the firmware may enable features\r\nwhich are not legal in your country.\r\nYou are fully responsibel for your flights.\r\nAre you sure you wish to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            //    return;
            if (Properties.Settings.Default.ShowFirmwareUpgradeWarning)
            {
                PSTaskDialog.cTaskDialog.ShowTaskDialogBox("Warning",
                     "Are you sure you wish to upgrade the firmware?",
                     "Upgrading the firmware may enable features which are not legal in your country. We are not aware of the laws in your country and cannot be held responsible. You are fully responsible for your own actions.",
                      "", "", "Don't show this message again", "", "I know what I am doing and take full responsability|Cancel", PSTaskDialog.eTaskDialogButtons.OK, PSTaskDialog.eSysIcons.Warning, PSTaskDialog.eSysIcons.Warning);
                if (PSTaskDialog.cTaskDialog.VerificationChecked)
                {
                    Properties.Settings.Default.ShowFirmwareUpgradeWarning = false;
                    Properties.Settings.Default.Save();
                }

                if (PSTaskDialog.cTaskDialog.CommandButtonResult == 1)
                    return;
            }



            if (_serial == null)   // Ask COM port & baudrate if not known yet
            {
                ConnectDialog cd = new ConnectDialog();
                cd.ShowDialog(this);
                _serial = new SerialCommunication_CSV();
                _serial.Open(cd.SelectedPort(), cd.SelectedBaudrate());
                ConnectPanels();
            }

            FileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() != DialogResult.OK)
                return;

            if (_serial.IsOpen)  // Close the current connection if it's open
                _serial.Close(); //_btn_connect_Click(null, null);

            string c = " -k=" + port + " -f=\"" + fd.FileName + "\"  -p -d=dsPIC33FJ256MC710 -u=" + baudrate + " -q=0a;24;5a;5a;3b;31;31;32;33;2a;33;61;0a -r=115200 -b=1200 -o";
            Process p = System.Diagnostics.Process.Start(Application.StartupPath + "\\ds30loader\\ds30LoaderConsole.exe", c);
            p.WaitForExit();



            if (p.ExitCode != -1)
                MessageBox.Show("New firmware has been written", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (MessageBox.Show("There has been an error!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    _btn_firmware_upgrade_Click(null, null);
            }
            
            if (connected)  // Reconnect if the state was connected
            {
                _serial.Open(port, baudrate);//_btn_connect_Click(null, null);
            }
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if (_serial != null && _serial.IsOpen)
            {
                _tssl_downloadspeed.Text = _serial.ThroughputKbS().ToString("###.") + " B/s";
                _tssl_time.Text = (DateTime.Now - connected).Minutes + ":" + (DateTime.Now - connected).Seconds;
                _tc_main.TabPages[0].Controls[0].Enabled = true;
                _btn_reboot.Enabled = true;
                _btn_connect.Checked = true;
                _btn_connect.Text = "Connected";
            }
            else
            {
                _tc_main.TabPages[0].Controls[0].Enabled = false;
                _btn_reboot.Enabled = false;
                _btn_connect.Checked = false;
                _btn_connect.Text = "Disconnected";
            }
        }

        private void _btnBasicConfiguration_Click(object sender, EventArgs e)
        {
            if (_serial != null && _serial.IsOpen)
            {
                Gluonpilot.EasyConfig ec = new Gluonpilot.EasyConfig(_serial);
                ec.Show();
                //_serial.ReadAllConfig();
                ReadConfiguration rc = new ReadConfiguration(_serial);
                rc.ShowDialog();
            }
        }

        private void GluonConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            DisconnectPanels();
            //if (_btn_connect.Checked)
            //    _btn_connect_Click(this, EventArgs.Empty);
        }

        private void _tc_main_TabIndexChanged(object sender, EventArgs e)
        {
        }

        private void _tc_main_Selected(object sender, TabControlEventArgs e)
        {
            if (_tc_main.SelectedIndex == 2)
            {
                if (Properties.Settings.Default.ShowAdvancedWiredWarning)
                {
                    PSTaskDialog.cTaskDialog.ShowTaskDialogBox("Warning",
                         "Please make sure you are connected with a wired (USB) connection!",
                         "This advanced configuration sends a lot of data towards the module. Wireless connections are not reliable enough to do this.\n\nWhen doing changes, you should send these to the module using the \"Write\" button. If you are satisfied with the changes, you can burn them to the non-volatile memory using the \"Burn\" button.",
                         "", "", "Don't show this message again", "", "", PSTaskDialog.eTaskDialogButtons.OK, PSTaskDialog.eSysIcons.Warning, PSTaskDialog.eSysIcons.Warning);
                    if (PSTaskDialog.cTaskDialog.VerificationChecked)
                    {
                        Properties.Settings.Default.ShowAdvancedWiredWarning = false;
                        Properties.Settings.Default.Save();
                    }
                }
                //MessageBox.Show("Please only use the advanced configuration when using a wired (USB) connection!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (_tc_main.SelectedIndex == 0)
            {
                if (Properties.Settings.Default.ShowEasyConfigInfo)
                {
                    PSTaskDialog.cTaskDialog.ShowTaskDialogBox("Basic configuration",
                         "How basic configuration works",
                         "The basic configuration tab allows you to edit the basic settings to get your UAV flying.\nAll changes are immediate and you should only burn the settings to the flash memory when you're done.",
                         "\n - It is recommended to start with the factory settings and calibrate the sensors.\n - After that you should program your RC-transmitter to make sure the \"interpretations\" are correct.\n - Choose the mixing type that suits your UAV and invert the servos that don't turn the right way.\n - Test manual & stabilized mode on the ground and make sure it is behaving normally to your input.\n - Fly your UAV in stabilized mode and adapt the rate settings if needed.", "", "Don't show this message again", "", "", PSTaskDialog.eTaskDialogButtons.OK, PSTaskDialog.eSysIcons.Information, PSTaskDialog.eSysIcons.Information);
                    if (PSTaskDialog.cTaskDialog.VerificationChecked)
                    {
                        Properties.Settings.Default.ShowEasyConfigInfo = false;
                        Properties.Settings.Default.Save();
                    }
                }
                //MessageBox.Show("Please only use the advanced configuration when using a wired (USB) connection!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GluonConfig_Shown(object sender, EventArgs e)
        {
            if (_serial != null && _serial.IsOpen)
            {
                ReadConfiguration rc = new ReadConfiguration(_serial);
                if (rc.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    PSTaskDialog.cTaskDialog.ShowTaskDialogBox("Error", "Error reading configuration",
                        "Reading the configuration failed. This configuration tool won't work.",
                        "Please make sure there is an active connection before opening this window and retry. It may not work as expected.",
                        "", "", "", "", PSTaskDialog.eTaskDialogButtons.OK, PSTaskDialog.eSysIcons.Error, PSTaskDialog.eSysIcons.Error);
            }
        }
    }
}
