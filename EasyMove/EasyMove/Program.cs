using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EasyMove
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

                    dtsMovementInfo dsCurrentMovementInfo = new dtsMovementInfo();

                    crptMaterialRequest aMtrlRequst = new crptMaterialRequest();
                    aMtrlRequst.FileName = "crptMaterialRequest.rpt";
                    aMtrlRequst.SetDataSource(dsCurrentMovementInfo);

                    CrystalDecisions.Windows.Forms.CrystalReportViewer vwr = new CrystalDecisions.Windows.Forms.CrystalReportViewer();                    
                    vwr.ReportSource = aMtrlRequst;
                    vwr.Dock = DockStyle.Fill;

                    System.Windows.Forms.Form aForm = new Form();
                    aForm.Controls.Add(vwr);
                    aForm.WindowState = FormWindowState.Minimized;
                    aForm.Load += new System.EventHandler((object obj, EventArgs e) => { ((Form)obj).Close(); });
                    aForm.ShowDialog();

                    dsCurrentMovementInfo.Dispose();
                    aMtrlRequst.Dispose();
                    vwr.Dispose();
                    aForm.Dispose();
                }).Start();

                if (Wow.Is64BitOperatingSystem)
                {
                    generalResultInformation.MyOdbcDrvr = "MySQL ODBC 5.3 Unicode Driver";
                }
                else
                {
                    generalResultInformation.MyOdbcDrvr = "MySQL ODBC 3.51 Driver"; 
                }

                Application.Run(new frmLogIn());
                appMutex.ReleaseMutex();
                if (generalResultInformation.userId != "" &&
                    generalResultInformation.logedIn)
                {                    
                    Application.Run(new frmMainWindow());                    
                }                    
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
