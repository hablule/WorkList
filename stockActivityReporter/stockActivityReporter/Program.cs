using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using dbConnection;

namespace stockActivityReporter
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
                new System.Threading.Thread(() =>
                {
                    System.Threading.Thread.CurrentThread.IsBackground = true;

                    dtsTransactionInfo dtsTransactionInfo = new dtsTransactionInfo();

                    rptCountSheet aRprt = new rptCountSheet();
                    aRprt.FileName = "rptCountSheet.rpt";
                    aRprt.SetDataSource(dtsTransactionInfo);

                    CrystalDecisions.Windows.Forms.CrystalReportViewer vwr = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                    vwr.ReportSource = aRprt;
                    vwr.Dock = DockStyle.Fill;

                    System.Windows.Forms.Form aForm = new Form();
                    aForm.Controls.Add(vwr);
                    aForm.WindowState = FormWindowState.Minimized;
                    aForm.Load += new System.EventHandler((object obj, EventArgs e) => { ((Form)obj).Close(); });
                    aForm.ShowDialog();

                    dtsTransactionInfo.Dispose();
                    aRprt.Dispose();
                    vwr.Dispose();
                    aForm.Dispose();
                }).Start();
                             
                Application.Run(new frmLogIn());
                appMutex.ReleaseMutex();
                if (generalResultInformation.logedIn)
                    Application.Run(new stockActivityReport());
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
