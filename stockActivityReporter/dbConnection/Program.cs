using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace dbConnection
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


            if (Wow.Is64BitOperatingSystem)
            {
                generalResultInformation.MyOdbcDrvr = "MySQL ODBC 5.3 Unicode Driver";
            }
            else
            {
                generalResultInformation.MyOdbcDrvr = "MySQL ODBC 3.51 Driver";
            }

            Application.Run(new frmsettings());
        }
    }
}
