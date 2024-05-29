using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSDocumentPrinter
{
    public partial class frmCreateLDAPConnection : Form
    {
        public frmCreateLDAPConnection()
        {
            InitializeComponent();
        }

        private bool Connected { get; set; }
                

        private void CreateLDAPConnection_Load(object sender, EventArgs e)
        {
            generalResultInformation.LDAPConnectionSet = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            LDAPConnection connection = new LDAPConnection();
            
            bool isValid = connection.validateUser(servertxt.Text, porttxt.Text, usertxt.Text, passwtxt.Text);
            if (isValid)
            {
                string payLoad = "LDAP_SERVER=" + servertxt.Text + 
                                 ";LDAP_PORT=" + porttxt.Text +
                                 ";USERNAME=" + usertxt.Text +
                                 ";PASSWORD=" + passwtxt.Text + 
                                 ";";
                Util util = new Util();
                string encryptedPayload = util.Base64Encode(payLoad);
                DotnetEnv.CreateEnvFile(".env.LDAP", encryptedPayload);

                MessageBox.Show("Configuration values to LDAP saved successfully");

                generalResultInformation.LDAPConnectionSet = true;
                this.Close();
                // Application.Restart();
            }
            else
            {
                MessageBox.Show("Incorrect Configuration values. Can't connect to LDAP");
            }
        }



    }
}
