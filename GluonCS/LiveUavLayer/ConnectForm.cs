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
        private Hashtable comPortNames;
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
        /// <param name="oPortsToMap">array of port names (i.e. COM1, COM2, etc)</param>
        /// <returns>a hashtable mapping Friendly names to non-friendly port values</returns>
        Hashtable BuildPortNameHash(string[] oPortsToMap)
        {
            Hashtable oReturnTable = new Hashtable();
            try
            {
                MineRegistryForPortName("SYSTEM\\CurrentControlSet\\Enum", oReturnTable, oPortsToMap);
            }
            catch (Exception e)
            {
                foreach (string s in oPortsToMap)
                    oReturnTable[s] = s;
            }
            return oReturnTable;
        }
        /// <summary>
        /// Recursively enumerates registry subkeys starting with strStartKey looking for 
        /// "Device Parameters" subkey. If key is present, friendly port name is extracted.
        /// </summary>
        /// <param name="strStartKey">the start key from which to begin the enumeration</param>
        /// <param name="oTargetMap">hashtable that will get populated with 
        /// friendly-to-nonfriendly port names</param>
        /// <param name="oPortNamesToMatch">array of port names (i.e. COM1, COM2, etc)</param>
        void MineRegistryForPortName(string strStartKey, Hashtable oTargetMap, string[] oPortNamesToMatch)
        {
            if (oTargetMap.Count >= oPortNamesToMatch.Length)
                return;
            RegistryKey oCurrentKey = Registry.LocalMachine;
            oCurrentKey = oCurrentKey.OpenSubKey(strStartKey);
            string[] oSubKeyNames = oCurrentKey.GetSubKeyNames();
            if (oSubKeyNames.Contains("Device Parameters") && strStartKey != "SYSTEM\\CurrentControlSet\\Enum")
            {
                object oPortNameValue = Registry.GetValue("HKEY_LOCAL_MACHINE\\" +
                    strStartKey + "\\Device Parameters", "PortName", null);
                if (oPortNameValue == null ||
                    oPortNamesToMatch.Contains(oPortNameValue.ToString()) == false)
                    return;
                object oFriendlyName = Registry.GetValue("HKEY_LOCAL_MACHINE\\" +
                    strStartKey, "FriendlyName", null);
                string strFriendlyName = "N/A";
                if (oFriendlyName != null)
                    strFriendlyName = oFriendlyName.ToString();
                if (strFriendlyName.Contains(oPortNameValue.ToString()) == false)
                    strFriendlyName = string.Format("{0} ({1})", strFriendlyName, oPortNameValue);
                oTargetMap[strFriendlyName] = oPortNameValue;
            }
            else
            {
                foreach (string strSubKey in oSubKeyNames)
                    MineRegistryForPortName(strStartKey + "\\" + strSubKey, oTargetMap, oPortNamesToMatch);
            }
        }

        private void _btn_connect_Click(object sender, EventArgs e)
        {
            SerialPort = new System.IO.Ports.SerialPort();
            if (_rbViaComPort.Checked)
            {
                if (comPortNames.ContainsKey(_cb_portnames.Text))
                    SerialPort.PortName = comPortNames[_cb_portnames.Text].ToString();
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
            else if (_cbSimulation.Checked)
            {
                this.Simulation = true;
                this.FlightgearPath = _tbFlightgear.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
            else if (_rbReplay.Checked)
                DialogResult = System.Windows.Forms.DialogResult.Yes;
            else
                DialogResult = System.Windows.Forms.DialogResult.Cancel;


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
                int i = _cb_portnames.Items.Add(key);
                if (comPortNames[key].ToString() == Properties.Settings.Default.LastComPortName)
                    _cb_portnames.SelectedIndex = i;
            }
        }

    }
}
