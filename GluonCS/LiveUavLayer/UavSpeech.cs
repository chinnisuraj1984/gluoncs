using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GluonCS.LiveUavLayer
{
    public class UavSpeech
    {
        private LiveUavModel model;
        private System.Speech.Synthesis.SpeechSynthesizer speech;
        private bool stop = false;

        public UavSpeech(LiveUavModel model)
        {
            this.model = model;

            model.CommunicationLost += new LiveUavModel.ChangedEventHandler(model_CommunicationLost);
            model.CommunicationEstablished += new LiveUavModel.ChangedEventHandler(model_CommunicationEstablished);
            model.UavPositionChanged += new LiveUavModel.ChangedEventHandler(model_UavPositionChanged);
            model.InformationMessageReceived += new LiveUavModel.TextReceivedEventHandler(model_InformationMessageReceived);

            speech = new System.Speech.Synthesis.SpeechSynthesizer();
        }

        public void Stop()
        {
            stop = true;
        }

        private void Speak(string s)
        {
            if (Properties.Settings.Default.UseSpeech && !stop)
            {
                if (!s.Contains('+') && !s.Contains(';') && !s.Contains('?'))
                {
                    s = s.Replace(".", " ");
                    speech.SpeakAsyncCancelAll();
                    speech.SpeakAsync(s);
                }
            }
        }

        void model_InformationMessageReceived(string s)
        {
             Speak(s);
        }

        private static string last_block = "";
        void model_UavPositionChanged(object sender, EventArgs e)
        {
            string block = model.NavigationModel.Commands[model.CurrentNavigationLine].BlockName;
            if (block != last_block)
            {
                Speak("entering " + block);
                last_block = block;
            }
        }

        void model_CommunicationEstablished(object sender, EventArgs e)
        {
            Speak("Connection established");
        }

        void model_CommunicationLost(object sender, EventArgs e)
        {
            Speak("Connection lost");
        }
    }
}
