using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using GMap.NET;
using System.Globalization;
using System.Net;

namespace GluonCS
{
    public partial class Setup : Form
    {
        private GMapControl map;
        public Setup(GMapControl map)
        {
            this.map = map;
            InitializeComponent();
            _tbCacheSize.Text = string.Format(CultureInfo.InvariantCulture, "{0:0.0}MB of {1:0.0}MB", map.Manager.MemoryCacheSize, map.Manager.MemoryCacheCapacity);
            _cbMapType.DataSource = Enum.GetValues(typeof(MapType));
            _cbMapType.SelectedItem = map.MapType;
            _cbCacheMode.DataSource = Enum.GetValues(typeof(AccessMode));
            _cbCacheMode.SelectedItem = GMaps.Instance.Mode;
            _cbUavAltSpeed.Checked = Properties.Settings.Default.ShowUavSpeedAltitude;
            _cbUseProxy.Checked = Properties.Settings.Default.UseProxy;
            _tbAddressproxy.Text = Properties.Settings.Default.ProxyAddress;
            _tbLoginProxy.Text = Properties.Settings.Default.ProxyUsername;
            _mtbPasswdProxy.Text = Properties.Settings.Default.ProxyPassword;
            _tbUavName.Text = Properties.Settings.Default.UavName;
            _dtb_altitude.DistanceM = Properties.Settings.Default.DefaultAltitudeM;
            _dtb_radius.DistanceM = Properties.Settings.Default.DefaultCircleRadius;
            _cbUseSpeech.Checked = Properties.Settings.Default.UseSpeech;

            _cbLanguage.SelectedText = Properties.Settings.Default.Language;
        }

        private void _btnClearCache_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure?", "Clear map cache?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    System.IO.Directory.Delete(map.CacheLocation, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void _cbMapType_DropDownClosed(object sender, EventArgs e)
        {
            map.MapType = (MapType)_cbMapType.SelectedValue;
        }

        private void _cbCacheMode_DropDownClosed(object sender, EventArgs e)
        {
            GMaps.Instance.Mode = (AccessMode)_cbCacheMode.SelectedValue;
            map.ReloadMap();
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.UseProxy = _cbUseProxy.Checked;
            Properties.Settings.Default.ProxyAddress = _tbAddressproxy.Text;
            Properties.Settings.Default.ProxyUsername = _tbLoginProxy.Text;
            Properties.Settings.Default.ProxyPassword = _mtbPasswdProxy.Text;
            Properties.Settings.Default.MapType = _cbMapType.SelectedValue.ToString();
            Properties.Settings.Default.ShowUavSpeedAltitude = _cbUavAltSpeed.Checked;
            Properties.Settings.Default.UavName = _tbUavName.Text;
            Properties.Settings.Default.DefaultAltitudeM = _dtb_altitude.DistanceM;
            Properties.Settings.Default.DefaultCircleRadius = _dtb_radius.DistanceM;
            Properties.Settings.Default.UseSpeech = _cbUseSpeech.Checked;
            Properties.Settings.Default.Language = (string)(_cbLanguage.SelectedItem.ToString());
            Properties.Settings.Default.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void _cbMapType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _tbUavName_TextChanged(object sender, EventArgs e)
        {

        }

        private void _cbUseSpeech_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
