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
        public Dictionary<string,int> Blocks = new Dictionary<string,int>(5);  // block name and start line


        public LiveUavNavigationModel(LiveUavModel model)
        {
            this.model = model;
            model.NavigationLocalListChanged += new LiveUavModel.ChangedEventHandler(model_NavigationLocalListChanged);
            model.NavigationRemoteListChanged += new LiveUavModel.ChangedEventHandler(model_NavigationRemoteListChanged);

            reSync = new Timer();
            reSync.Elapsed += new ElapsedEventHandler(reSync_Elapsed);
            Resync();
        }

        public int WaypointsInBlock(string blockname)
        {
            lock (Commands)
            {
                int counter = 0;
                if (!Blocks.ContainsKey(blockname))
                    return 0;

                if (Blocks.ContainsKey(blockname))
                {
                    for (int i = Blocks[blockname] + 1; i < Commands.Count && Commands[i].BlockName == blockname; i++)
                    {
                        if (Commands[i].Instruction.HasAbsoluteCoordinates() || Commands[i].Instruction.HasRelativeCoordinates())
                            counter++;
                    }
                    return counter;
                }
                else
                    return 0;
            }
        }

        public void Stop()
        {
            reSync.Elapsed -= new ElapsedEventHandler(reSync_Elapsed);
            reSync.Stop();
        }

        void reSync_Elapsed(object sender, ElapsedEventArgs e)
        {
            Resync();
            reSync.Stop();
        }

        void model_NavigationRemoteListChanged(object sender, EventArgs e)
        {
            reSync.Interval = 100;
            // if (zoomtowaypoints.Enabled)
            reSync.Stop();
            reSync.Start();
        }

        void model_NavigationLocalListChanged(object sender, EventArgs e)
        {
            Resync();
            /*
            reSync.Interval = 100;
            // if (zoomtowaypoints.Enabled)
            reSync.Stop();
            reSync.Start();*/
        }

        private void Resync()
        {
            Console.WriteLine("Resync");
            string blockname = "Start";
            lock (Commands)
            {
                Blocks.Clear();
                for (int i = 0; i < model.MaxNumberOfNavigationInstructions(); i++)
                {
                    NavigationInstruction ni = model.GetNavigationInstructionLocal(i);
                    if (ni.opcode == NavigationInstruction.navigation_command.BLOCK)
                    {
                        blockname = ni.GetStringArgument();
                        if (!Blocks.ContainsKey(ni.GetStringArgument()))
                            Blocks.Add(ni.GetStringArgument(), ni.line);
                    }
                    
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

                    if (Commands[i].Instruction.IsWaypoint())
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
