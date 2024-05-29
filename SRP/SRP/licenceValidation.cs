using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using appSecurity;
using System.Windows.Forms;

namespace SRP
{
    class licenceValidation
    {
        private appSecurity.manageWinRegistry regReader = new manageWinRegistry();
        private appSecurity.machineId machine = new machineId();
        private string keyName = "licence";
        public bool validCopy;

        public licenceValidation()
        {
            this.validCopy = false;
            if (regReader.readReg(keyName) == machine.generateValue())
                this.validCopy = true;
            else
            {
                MessageBox.Show("This Is Invalid License Copy. " +
                    "\nPlease Inpute correct license.", "License Notice",
               MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.validCopy = registerLicense();
            }
        }

        public bool registerLicense()
        {
            frmLicenseKey frLn = new frmLicenseKey();
            frLn.ShowDialog();

            if (regReader.readReg(keyName) == machine.generateValue())
            {
                return true;
            }
            else
            {
                return false;
            }            
        }
    }
}
