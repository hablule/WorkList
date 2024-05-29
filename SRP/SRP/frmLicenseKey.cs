using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SRP
{
    public partial class frmLicenseKey : Form
    {
                

        public frmLicenseKey()
        {
            InitializeComponent();
        }

        appSecurity.manageWinRegistry regManger = new appSecurity.manageWinRegistry();
        string keyName = "licence";

        private void cmdClose_Click(object sender, EventArgs e)
        {
            if (this.txtKey.Text.Replace(" ", "").Trim() != "")
            {
                regManger.Write(keyName, this.txtKey.Text);
                //MessageBox.Show("Registration Successful");
            }
            else
            {
                MessageBox.Show("Key not Found");
                MessageBox.Show("Registration Failed");
            }
            this.Close();
        }
    }
}
