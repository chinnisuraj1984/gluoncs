using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO.Ports;
using Microsoft.Win32;
using System.IO;
using System.Reflection;

namespace GluonCS.LiveUavLayer
{
    public partial class ConnectForm : Form
    {
        private Dictionary<string, string> comPortNames;
        public SerialPort SerialPort;
        private string Filename = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".log";
        public bool Simulation = false;

        public string FlightgearPath;

        public string LogPath { get { return _cbLogToFile.Checked ? _lblFilename.Text : ""; } }
        public string ReplayFilename { get { return _rbReplay.Checked ? _tbLoggedFilename.Text : ""; } }

        public ConnectForm()
        {
            InitializeComponent();

            _btn_portrefresh_Click(null, EventArgs.Empty);
            foreach (string k in _cbBaudrate.Items)
            {
                if (k == Properties.Settings.Default.LastComBaudrate.ToString())
                    _cbBaudrate.Text = k.ToString();
            }

            _cbLogToFile.Checked = Properties.Settings.Default.AutomaticLogging;
            _cbLogToFile_CheckedChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Begins recursive registry enumeration
        /// </summary>
        /// <param name="portsToMap">array of port names (i.e. COM1, COM2, etc)</param>
        /// <returns>a hashtable mapping Friendly names to non-friendly port values</returns>
        static Dictionary<string, string> BuildPortNameHash(string[] portsToMap)
        {
            Dictionary<string, string> oReturnTable = new Dictionary<string, string>();
            MineRegistryForPortName("SYSTEM\\CurrentControlSet\\Enum", oReturnTable, portsToMap);
            return oReturnTable;
        }

        /// <summary>
        /// Recursively enumerates registry subkeys starting with startKeyPath looking for 
        /// "Device Parameters" subkey. If key is present, friendly port name is extracted.
        /// </summary>
        /// <param name="startKeyPath">the start key from which to begin the enumeration</param>
        /// <param name="targetMap">dictionary that will get populated with 
        /// nonfriendly-to-friendly port names</param>
        /// <param name="portsToMap">array of port names (i.e. COM1, COM2, etc)</param>
        static void MineRegistryForPortName(string startKeyPath, Dictionary<string, string> targetMap,
            string[] portsToMap)
        {
            if (targetMap.Count >= portsToMap.Length)
                return;
            using (RegistryKey currentKey = Registry.LocalMachine)
            {
                try
                {
                    using (RegistryKey currentSubKey = currentKey.OpenSubKey(startKeyPath))
                    {
                        string[] currentSubkeys = currentSubKey.GetSubKeyNames();
                        if (currentSubkeys.Contains("Device Parameters") &&
                            startKeyPath != "SYSTEM\\CurrentControlSet\\Enum")
                        {
                            object portName = Registry.GetValue("HKEY_LOCAL_MACHINE\\" +
                                startKeyPath + "\\Device Parameters", "PortName", null);
                            if (portName == null ||
                                portsToMap.Contains(portName.ToString()) == false)
                                return;
                            object friendlyPortName = Registry.GetValue("HKEY_LOCAL_MACHINE\\" +
                                startKeyPath, "FriendlyName", null);
                            string friendlyName = "N/A";
                            if (friendlyPortName != null)
                                friendlyName = friendlyPortName.ToString();
                            if (friendlyName.Contains(portName.ToString()) == false)
                                friendlyName = string.Format("{0} ({1})", friendlyName, portName);

                            targetMap[portName.ToString()] = friendlyName;
                        }
                        else
                        {
                            foreach (string strSubKey in currentSubkeys)
                                MineRegistryForPortName(startKeyPath + "\\" + strSubKey, targetMap, portsToMap);
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error accessing key '{0}'.. Skipping..", startKeyPath);
                }
            }
        }

        private void _btn_connect_Click(object sender, EventArgs e)
        {
            SerialPort = new System.IO.Ports.SerialPort();
            if (_rbViaComPort.Checked)
            {
                if (comPortNames.ContainsValue(_cb_portnames.Text))
                {
                    foreach (string port in comPortNames.Keys)
                    {
                        if (comPortNames[port] == _cb_portnames.Text)
                        {
                            SerialPort.PortName = port;
                            MessageBox.Show("Connecting to port \"" + port + "\" with description \"" + comPortNames[port] + "\"");
                        }
                    }
                    //SerialPort.PortName = SerialPort.GetPortNames()[_cb_portnames.SelectedIndex].ToString();
                }
                else
                {
                    MessageBox.Show("Error connecting: invalid COM port", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    return;
                }
                if (_cbBaudrate.Text == "")
                {
                    MessageBox.Show("Error connecting: invalid baud rate", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    return;
                }

                int b;
                if (!int.TryParse(_cbBaudrate.Text, out b) || _cbBaudrate.SelectedItem == null)
                {
                    MessageBox.Show("Error connecting", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
                SerialPort.BaudRate = b;
                //SerialPort.Open();
                Properties.Settings.Default.LastComPortName = SerialPort.PortName;
                Properties.Settings.Default.LastComBaudrate = b;
                Properties.Settings.Default.Save();
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
            else if (_rbReplay.Checked)
                DialogResult = System.Windows.Forms.DialogResult.Yes;
            else
                DialogResult = System.Windows.Forms.DialogResult.Cancel;

            if (_cbSimulation.Checked)
            {
                this.Simulation = true;
                this.FlightgearPath = _tbFlightgear.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            }

            this.Close();
        }

        private void _cbLogToFile_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbLogToFile.Checked == true)
            {
                string map = Properties.Settings.Default.LogLocation;
                map = map.Replace("$GLUONMAP",  Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                if (System.IO.Directory.Exists(map))
                {
                    _lblFilename.Text = map + '\\' + Filename;
                }
                else
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(map);
                        _lblFilename.Text = map + '\\' + Filename;
                    }
                    catch (Exception ex)
                    {
                        _lblFilename.Text = Filename;
                    }
                }
                _btnChangeFilename.Enabled = true;
            }
            else
            {
                _lblFilename.Text = "...";
                _btnChangeFilename.Enabled = false;
            }
        }

        private void _btnChangeFilename_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                _lblFilename.Text = fbd.SelectedPath + "\\" + Filename;
        }

        private void _btnBrowseLoggedFile_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FileDialog fd = new System.Windows.Forms.OpenFileDialog();
            string map = Properties.Settings.Default.LogLocation;
            map = map.Replace("$GLUONMAP", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            if (System.IO.Directory.Exists(map))
            {
                fd.InitialDirectory = map;
            }
            fd.CheckFileExists = true;
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                _tbLoggedFilename.Text = fd.FileName;
        }

        private void _btn_portrefresh_Click(object sender, EventArgs e)
        {
            comPortNames = BuildPortNameHash(SerialPort.GetPortNames());
            _cb_portnames.Items.Clear();
            foreach (string key in comPortNames.Keys)
            {
                int i = _cb_portnames.Items.Add(comPortNames[key]);
                //_cb_portnames.Items[i]
                if (key == Properties.Settings.Default.LastComPortName)
                    _cb_portnames.SelectedIndex = i;
            }
        }

    }
}
