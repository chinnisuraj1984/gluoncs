using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Communication.Frames.Incoming;
using System.IO;
using GluonCS.LiveUavLayer;

namespace GluonMapper
{
    public partial class DownloadLog : Form
    {
        private Communication.SerialCommunication_CSV _serial;
        private int first_time_received = -1;
        private int last_time_received = -1;
        private DataSet loglines;

        private string filename;

        public DownloadLog(string resultfilename)
        {
            filename = resultfilename;

            InitializeComponent();

            ConnectForm cf = new ConnectForm(true);
            if (cf.ShowDialog(this) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    _serial = new Communication.SerialCommunication_CSV();
                    _serial.Open(cf.SerialPort.PortName, cf.SerialPort.BaudRate);

                    _serial.DatalogTableCommunicationReceived += new Communication.SerialCommunication.ReceiveDatalogTableCommunicationFrame(_serial_DatalogTableCommunicationReceived);
                    _serial.DatalogLineCommunicationReceived += new Communication.SerialCommunication.ReceiveDatalogLineCommunicationFrame(_serial_DatalogLineCommunicationReceived);
                    _serial.SendDatalogTableRequest();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting");
                }
            }
        }

        void _serial_DatalogLineCommunicationReceived(DatalogLine line)
        {
            this.BeginInvoke(new D_ReceiveDatalogLine(DatalogLine), new object[] { line });
        }
        private delegate void D_ReceiveDatalogLine(DatalogLine line);
        private void DatalogLine(DatalogLine line)
        {
            timer_no_data.Stop();
            timer_no_data.Start();

            // first call: init dataset & headers
            if (loglines == null)
            {
                loglines = new DataSet();
                loglines.Tables.Add("Data");

                foreach (string s in line.Header)
                    loglines.Tables["Data"].Columns.Add(s);

                _dgv_datalog.SelectionMode = DataGridViewSelectionMode.CellSelect;
                _dgv_datalog.DataSource = loglines;
                _dgv_datalog.DataMember = "Data";
                foreach (DataGridViewColumn dgvc in _dgv_datalog.Columns)
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                _dgv_datalog.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
            }

            // add row
            DataRow dr = loglines.Tables["Data"].NewRow();
            dr.ItemArray = new String[line.Line.Length];
            for (int i = 0; i < line.Line.Length; i++)
                dr[i] = line.Line[i];
            loglines.Tables["Data"].Rows.Add(dr);

            _pb.Value = (_pb.Value + 1) % 100;

            if (first_time_received == -1 && loglines.Tables["Data"].Columns.Contains("Time"))
            {
                first_time_received = int.Parse(loglines.Tables["Data"].Rows[0]["Time"].ToString());
            }

            last_time_received = int.Parse(loglines.Tables["Data"].Rows[0]["Time"].ToString());
            _lblStatus.Text = "" + first_time_received / 10000 + ":" + (first_time_received / 100) % 100 + ":" + first_time_received % 100 + " - " +
                   last_time_received / 10000 + ":" + (last_time_received / 100) % 100 + ":" + last_time_received % 100 + " (" + time_text(loglines.Tables["Data"].Rows.Count / 4) + " received)";
        }

        private string time_text(int seconds)
        {
            if (seconds > 3600)
                return "" + seconds / 3600 + "h " + (seconds % 3600) / 60 + "m " + seconds % 60 + "s";
            else if (seconds > 60)
                return "" + (seconds % 3600) / 60 + "m " + seconds % 60 + "s";
            else
                return "" + seconds % 60 + "s";
        }

        void _serial_DatalogTableCommunicationReceived(Communication.Frames.Incoming.DatalogTable table)
        {
            this.BeginInvoke(new Action<DatalogTable>(DatalogTable), new object[] { table });
        }

        private void DatalogTable(DatalogTable table)
        {
            // Create columns if needed
            while (_lv_datalogtable.Items.Count <= table.Index)
                _lv_datalogtable.Items.Add("");
            _lv_datalogtable.Items[table.Index] = new ListViewItem();

            // Create row subitems if needed
            while (_lv_datalogtable.Items[table.Index].SubItems.Count <= 4)
                _lv_datalogtable.Items[table.Index].SubItems.Add("");

            // Assign data to row
            _lv_datalogtable.Items[table.Index].SubItems[0] = new ListViewItem.ListViewSubItem(_lv_datalogtable.Items[table.Index], table.Index.ToString());
            _lv_datalogtable.Items[table.Index].SubItems[1] = new ListViewItem.ListViewSubItem(_lv_datalogtable.Items[table.Index], table.StartPage.ToString());
            string date = table.Date / 10000 + "/" + (table.Date / 100) % 100 + "/" + table.Date % 100;
            string time = table.Time / 10000 + ":" + (table.Time / 100) % 100 + ":" + table.Time % 100;
            _lv_datalogtable.Items[table.Index].SubItems[2] = new ListViewItem.ListViewSubItem(_lv_datalogtable.Items[table.Index], date);
            _lv_datalogtable.Items[table.Index].SubItems[3] = new ListViewItem.ListViewSubItem(_lv_datalogtable.Items[table.Index], time);

            try
            {
                _lv_datalogtable.Items[table.Index].Tag =
                    new DateTime((int)table.Date % 100 + 2000,
                                 (int)(table.Date / 100) % 100,
                                 (int)table.Date / 10000,
                                 (int)table.Time / 10000,
                                 (int)(table.Time / 100) % 100,
                                 (int)table.Time % 100);
            }
            catch (Exception ex) // datetime exception -> no valid date set
            {
                _lv_datalogtable.Items[table.Index].Tag = DateTime.Now;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (_serial == null || (_serial != null && !_serial.IsOpen))
            {
                _btnConnected.Image = imageList.Images[1];
                _btnConnected.Checked = false;
                _btnReadIndex.Enabled = false;
            }
            else if (_serial != null && _serial.IsOpen)
            {
                _btnConnected.Image = imageList.Images[0];
                _btnConnected.Checked = true;
                _btnReadIndex.Enabled = true;
            }

            if (_lv_datalogtable.SelectedIndices.Count == 1)
                _btnDownload.Enabled = true;
            else
                _btnDownload.Enabled = false;
        }

        private void DownloadLog_Activated(object sender, EventArgs e)
        {


        }

        private void _btnReadIndex_Click(object sender, EventArgs e)
        {
            _serial.SendDatalogTableRequest();
        }

        private void _btnDownload_Click(object sender, EventArgs e)
        {
            loglines = null;
            if (_lv_datalogtable.SelectedIndices.Count != 1 ||
                _lv_datalogtable.SelectedIndices[0] < 0 ||
                _lv_datalogtable.SelectedIndices[0] > 15)
                MessageBox.Show("Please select 1 row from the index table.");
            else
                _serial.SendDatalogTableRead(_lv_datalogtable.SelectedIndices[0]);

            first_time_received = -1;
            last_time_received = -1;
        }

        private void _lv_datalogtable_DoubleClick(object sender, EventArgs e)
        {
            _btnDownload_Click(this, EventArgs.Empty);
        }

        private void timer_no_data_Tick(object sender, EventArgs e)
        {
            timer_no_data.Stop();
            MessageBox.Show("The data has been retrieved.", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            try
            {
                FileInfo fi = new FileInfo(filename);
                DirectoryInfo di = new DirectoryInfo(fi.DirectoryName);
                if (!di.Exists)
                    di.Create();

                Stream s;
                s = new FileStream(filename, FileMode.Create);
                loglines.WriteXml(s);
                s.Close();

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            this.Close();
        }
    }
}
