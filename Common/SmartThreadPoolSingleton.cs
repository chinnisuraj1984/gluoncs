using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amib.Threading;

namespace Common
{
    public class SmartThreadPoolSingleton
    {
        private static SmartThreadPool _stp = new SmartThreadPool();

        public SmartThreadPoolSingleton()
        {
        }

        public static SmartThreadPool GetInstance()
        {
            return _stp;// new SmartThreadPool();
        }

        public static void Stop()
        {
            _stp.Cancel();
            _stp.Shutdown();
        }
    }
}
