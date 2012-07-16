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
    public partial class WriteNavigationCommandsWindow : Form
    {
        static int image = 0;
        LiveUavModel model;
        int are_synchronized = 0;

        bool was_synchronizing;

        int original_synchronized = 0;

        public WriteNavigationCommandsWindow(LiveUavModel model)
        {
            InitializeComponent();
            _tmr_roll.Start();
            this.model = model;

            was_synchronizing = model.AutoSync;

            UpdateNotSynchronized();
            original_synchronized = are_synchronized;

            //System.Threading.Thread.Sleep(2000);  // ugly hack

            if (model.maxLineNumberReceived < 36)
                model.CreateFakeRemoteList();

            model.AutoSync = true;
        }

        private void _tmr_roll_Tick(object sender, EventArgs e)
        {
            image = --image % 4;
            image = image < 0 ? image + 4 : image;
            pictureBox1.Image = imageList.Images[image];

            int max = model.MaxNumberOfNavigationInstructions();
            UpdateNotSynchronized();
            _lbl_info.Text = "" + (are_synchronized) + " / " + max + " synchronized (" + (are_synchronized - original_synchronized) + " updated)";

            if (are_synchronized == max)
            {
                model.AutoSync = was_synchronizing;
                _btn_cancel.Text = "Ok";
                pictureBox1.Image = imageList.Images[4];
            }
        }

        private void UpdateNotSynchronized()
        {
            are_synchronized = 0;
            for (int i = 0; i < model.MaxNumberOfNavigationInstructions(); i++)
                if (model.IsNavigationSynchronized(i))
                    are_synchronized++;
        }

        private void _btn_cancel_Click(object sender, EventArgs e)
        {
            model.AutoSync = was_synchronizing;
            this.Close();
        }
    }
}
