using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GluonCS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //try
            //{

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new GluonCSForm());

            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show((string)e.Message + "\n" + e.InnerException,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
