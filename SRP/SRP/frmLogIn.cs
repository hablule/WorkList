using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SRP
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }

        string settingFile = dbSettingInformationHandler.settingFilePath;
        dataBuilder getDbInfo = new dataBuilder();
        businessRule userAuthentication = new businessRule();

        DataTable userSection = new DataTable();
        DataTable userId = new DataTable();

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            //Check If anotherUser Is LogedIn            
            checkAndEstablishDbConnectionSettings dbConnection = 
                new checkAndEstablishDbConnectionSettings();
            if (!dbConnection.establishDbConnectionSettins(this))
            {
                MessageBox.Show("Unable to Login to the System", "Log In", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                return;
            }
            
            this.WindowState = FormWindowState.Normal;
            this.Enabled = true;
            this.txtUserName.Text = generalResultInformation.userName;
            if (this.txtUserName.Text != "")
                this.SelectNextControl(this.txtUserName, true,true,false,false);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
                        
            if (this.txtUserName.Text == "")
                this.txtUserName.BackColor = Color.Red;
            else
                this.txtUserName.BackColor = Color.White;
            if (this.txtPassWord.Text == "")
                txtPassWord.BackColor = Color.Red;
            else
                this.txtPassWord.BackColor = Color.White;
            if (this.txtPassWord.BackColor == Color.Red ||
                this.txtUserName.BackColor == Color.Red)
            {
                MessageBox.Show("Please Insert Required Entries Before You Proceed.",
                    "SRP LogIn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            //validate and get userId            
            if (!userAuthentication.validateUser(this.txtUserName.Text,
                                                    this.txtPassWord.Text))
                if (generalResultInformation.userLoginTrials <= 0)
                    Application.Exit();
                else
                {
                    generalResultInformation.userLoginTrials--;
                    MessageBox.Show("Invalid username or password.",
                    "SRP LogIn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            generalResultInformation.logedIn = true;
            DataTable dtSettingsTable = new DataTable();
            bool foundParameter = false;
            dtSettingsTable.TableName = "Settings";
            dtSettingsTable.Columns.Add("Parameter_Name");
            dtSettingsTable.Columns.Add("Parameter_Value");
            dtSettingsTable.ReadXml(settingFile);
            for (int rowCounter = dtSettingsTable.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                if (dtSettingsTable.Rows[rowCounter]["Parameter_Name"].ToString() == "UserName")
                {
                    dtSettingsTable.Rows[rowCounter]["Parameter_Value"] =
                        this.txtUserName.Text;
                    dtSettingsTable.WriteXml(settingFile);
                    foundParameter = true;
                    break;
                }
            }
            if (!foundParameter)
            {
                DataRow drNewSetting = dtSettingsTable.NewRow();
                drNewSetting["Parameter_Name"] = "UserName";
                drNewSetting["Parameter_Value"] = this.txtUserName.Text;

                dtSettingsTable.Rows.Add(drNewSetting);
                dtSettingsTable.WriteXml(settingFile);
            }            
            this.Close();                       
        }

        private void txtPassWord_TextChanged(object sender, EventArgs e)
        {
            this.txtPassWord.BackColor = Color.White;
            //this.cmbSection.Items.Clear();
            //this.cmbSection.Enabled = false;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            this.txtUserName.BackColor = Color.White;
            //this.cmbSection.Items.Clear();
            //this.cmbSection.Enabled = false;
        }

    }
}
