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
    public partial class ReadNavigationCommandsWindow : Form
    {
        private LiveUavModel model;
        private Dictionary<int, bool> received_instr = new Dictionary<int, bool>();
        private int retry = 0;

        public ReadNavigationCommandsWindow(LiveUavModel model)
        {
            InitializeComponent();
            this.model = model;

            if (!model.CommunicationAlive)
            {
                lbl_info.Text = "No link detected!";
                _btn_cancel.Text = "Ok";
            }
            else
            {
                model.ReadNavigation();
                timer.Start();
            }

            for (int i = 0; i < 72 && i < model.MaxNumberOfNavigationInstructions(); i++)
                received_instr[i] = false;

            model.Serial.NavigationInstructionCommunicationReceived += new Communication.SerialCommunication.ReceiveNavigationInstructionCommunicationFrame(Serial_NavigationInstructionCommunicationReceived);
        }

        private int ReceivedInstructions()
        {
            int count = 0;
            foreach (int key in received_instr.Keys)
                if (received_instr[key] == true)
                    count++;
            return count;
        }

        private void UpdateLabel()
        {
            int received = ReceivedInstructions();

            if (received == model.MaxNumberOfNavigationInstructions())
            {
                pictureBox.Image = imageList.Images[0];
                lbl_info.Text = "Done!";
                _btn_cancel.Text = "Ok";
            }
            else
            {
                lbl_info.Text = "" + received + " / " + model.MaxNumberOfNavigationInstructions() + " received";
                if (retry > 0)
                    lbl_info.Text += " (retry " + retry + ")";
            }
        }

        void Serial_NavigationInstructionCommunicationReceived(Communication.Frames.Incoming.NavigationInstruction ni)
        {
            MethodInvoker m = delegate()
            {
                received_instr[ni.line] = true;

                UpdateLabel();
            };

            try
            {
                BeginInvoke(m);
            }
            catch
            {
            } 

        }


        private void _btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // not all instructions have been received -> retry
            if (ReceivedInstructions() != model.MaxNumberOfNavigationInstructions())
            {
                retry++;
                model.ReadNavigation();
                UpdateLabel();
            }
        }
    }
}
