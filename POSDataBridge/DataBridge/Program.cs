using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace POSDataBridge
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool createdNew;
            // To prevent the program to be started twice
            ///Create new mutex
            System.Threading.Mutex appMutex =
                new System.Threading.Mutex(true, Application.ProductName, out createdNew);
            ///if creation of mutex is successful
            if (createdNew)
            {
                Application.Run(new frmPosCompiereBridge());
                appMutex.ReleaseMutex();                
            }            
            else
            {
                string msg = String.Format("The Program \"{0}\" is already running", Application.ProductName);
                System.Windows.Forms.MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);                
            }                        
        }
    }
}
