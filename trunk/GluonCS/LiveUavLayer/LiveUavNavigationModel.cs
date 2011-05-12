using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Communication;
using Communication.Frames.Incoming;
using System.Timers;


namespace GluonCS.LiveUavLayer
{
    public class LiveUavNavigationModel
    {
        private LiveUavModel model;
        private Timer reSync;
        public Dictionary<int, NavigationCommand> Commands = new Dictionary<int, NavigationCommand>(1);

        public LiveUavNavigationModel(LiveUavModel model)
        {
            this.model = model;
            model.NavigationLocalListChanged += new LiveUavModel.ChangedEventHandler(model_NavigationLocalListChanged);
            model.NavigationRemoteListChanged += new LiveUavModel.ChangedEventHandler(model_NavigationRemoteListChanged);

            reSync = new Timer();
            reSync.Elapsed += new ElapsedEventHandler(reSync_Elapsed);
            Resync();
        }

        void reSync_Elapsed(object sender, ElapsedEventArgs e)
        {
            Resync();
            reSync.Stop();
        }

        void model_NavigationRemoteListChanged(object sender, EventArgs e)
        {
            reSync.Interval = 500;
            // if (zoomtowaypoints.Enabled)
            reSync.Stop();
            reSync.Start();
        }

        void model_NavigationLocalListChanged(object sender, EventArgs e)
        {
            reSync.Interval = 500;
            // if (zoomtowaypoints.Enabled)
            reSync.Stop();
            reSync.Start();
        }

        private void Resync()
        {
            Console.WriteLine("Resync");
            string blockname = "Start";
            lock (Commands)
            {
                for (int i = 0; i < model.MaxNumberOfNavigationInstructions(); i++)
                {
                    NavigationInstruction ni = model.GetNavigationInstructionLocal(i);
                    if (ni.opcode == NavigationInstruction.navigation_command.BLOCK)
                        blockname = ni.GetStringArgument();
                    
                    NavigationCommand nc = new NavigationCommand();
                    nc.BlockName = blockname;
                    nc.Instruction = new NavigationInstruction(ni);
                    nc.Line = ni.line;
                    if (model.GetNavigationInstructionRemote(i) != ni)
                        nc.Dirty = true;
                    else
                        nc.Dirty = false;
                    if (Commands.ContainsKey(i))
                        Commands[i] = nc;
                    else
                        Commands.Add(nc.Line, nc);
                }

                int targetWpLine = -1;
                for (int i = model.MaxNumberOfNavigationInstructions() - 1; i >= 0; i--)
                {
                    if (!Commands.ContainsKey(i))
                        continue;

                    NavigationInstruction.navigation_command opcode = Commands[i].Instruction.opcode;
                    if (opcode == NavigationInstruction.navigation_command.CIRCLE_ABS ||
                        opcode == NavigationInstruction.navigation_command.CIRCLE_REL ||
                        opcode == NavigationInstruction.navigation_command.FLY_TO_ABS ||
                        opcode == NavigationInstruction.navigation_command.FLY_TO_REL ||
                        opcode == NavigationInstruction.navigation_command.FROM_TO_ABS ||
                        opcode == NavigationInstruction.navigation_command.FROM_TO_REL)
                    {
                        targetWpLine = i;
                    }
                    Commands[i].TargetWp = targetWpLine;
                }
            }
        }
    }

    public class NavigationCommand
    {
        public int Line;
        public string BlockName;
        public bool Dirty;
        public int TargetWp;
        public NavigationInstruction Instruction;
    }
}
