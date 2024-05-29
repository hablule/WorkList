using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SRP
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
            licenceValidation copyValidator = new licenceValidation();            
            if (copyValidator.validCopy)
            {
                Application.Run(new frmLogIn());
                if (generalResultInformation.userId != "" &&
                    generalResultInformation.logedIn)
                    Application.Run(new frmMainWindow());
            }
            else
            {                
                MessageBox.Show("This Is Invalid License Copy. " +
                    "\nPlease Contact blueVibe System Solutions.","License Notice",
                    MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
        }
    }
}
