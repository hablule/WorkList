using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace appSecurity
{
    public partial class frmappSecurityMain : Form
    {
        public frmappSecurityMain()
        {
            InitializeComponent();
        }

        string keyName = "licence";

        machineId generateMachineID = new machineId();
        manageWinRegistry regManger = new manageWinRegistry();

        private void frmappSecurityMain_Load(object sender, EventArgs e)
        {            
            this.lblExistingKey.Text =
                regManger.readReg(keyName);
            //this.visualStyler1.LoadVisualStyle("Skins\\Aero (Black).vssf");
        }

        private void cmdGenerateKey_Click(object sender, EventArgs e)
        {
            this.txtNewKey.Text = "";
            this.txtNewKey.Text = generateMachineID.generateValue();            
        }

        private void cmdRecordKey_Click(object sender, EventArgs e)
        {
            if (this.txtNewKey.Text.Replace(" ", "") != "")
            {
                regManger.Write(keyName, this.txtNewKey.Text);
                MessageBox.Show("Registration Successful");
            }
            else
            {
                MessageBox.Show("Key not Found");
                MessageBox.Show("Registration Failed");
            }
        }

    }
}
