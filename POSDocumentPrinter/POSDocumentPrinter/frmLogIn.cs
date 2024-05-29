using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace POSDocumentPrinter
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }

        string settingFile = dbSettingInformationHandler.settingFilePath;
        dataBuilder getDbInfo = new dataBuilder(); 
        businessRule getDataAccordingToRule = new businessRule();
              

        private bool validateUser()
        {
            DataTable userInfo = new DataTable();

            if (generalResultInformation.useLDAPAuthentication)
            {
                LDAPConnection authenticate = new LDAPConnection();

                userInfo =
                    this.getDbInfo.getUsersInfo(null, "", this.txtUserName.Text,
                                        "", "", "", generalResultInformation.Station,
                                        generalResultInformation.concernedNode,
                                        triaStateBool.yes, false, "AND");

                if (!getDbInfo.checkIfTableContainesData(userInfo))
                {
                    return false;
                }

                if (userInfo.Rows.Count != 1)
                {
                    return false;
                }

                if (!authenticate.validateUser(this.txtUserName.Text, this.txtPassWord.Text))
                {
                    return false;
                }
            }
            else
            {
                MD5 md5Hasher = MD5.Create();
                byte[] data =
                    md5Hasher.ComputeHash(Encoding.Default.GetBytes(this.txtPassWord.Text));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                userInfo =
                    this.getDbInfo.getUsersInfo(null, "", this.txtUserName.Text,
                               sBuilder.ToString(), "", "", generalResultInformation.Station,
                               generalResultInformation.concernedNode,
                               triaStateBool.yes, false, "AND");

                if (!this.getDbInfo.checkIfTableContainesData(userInfo))
                {
                    return false;
                }

                if (userInfo.Rows.Count != 1)
                {
                    return false;
                }
            }

            if (!
                (
                    userInfo.Rows[0]["user_type"].ToString() == "Sales User" ||
                    userInfo.Rows[0]["user_type"].ToString() == "System Admin" ||
                    userInfo.Rows[0]["user_type"].ToString() == "Super Admin" ||
                    userInfo.Rows[0]["user_type"].ToString() == "Admin" ||
                    userInfo.Rows[0]["user_type"].ToString() == "Sales Clerk"
                  )
                )
            {
                return false;
            }


            generalResultInformation.userFullName =
                userInfo.Rows[0]["full_name"].ToString();
            generalResultInformation.userId =
                userInfo.Rows[0]["id"].ToString();
            generalResultInformation.userName =
                userInfo.Rows[0]["username"].ToString();
            generalResultInformation.userType =
                userInfo.Rows[0]["user_type"].ToString();

            return true;

        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            generalResultInformation.logedIn = false;

            this.WindowState = 
                FormWindowState.Normal;
            this.Enabled = true;
            this.txtUserName.Text = generalResultInformation.userName;
            if (this.txtUserName.Text != "")
                this.SelectNextControl(this.txtUserName, true,true,false,false);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
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
                    "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //validate and get userId            
            if (!this.validateUser())
            {
                MessageBox.Show("Incorrect username or password. \n Please try again",
                    "New sales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtPassWord.Text = "";

                if (generalResultInformation.userLoginTrials <= 0)
                {
                    this.Close();
                    return;
                }
                else
                {
                    generalResultInformation.userLoginTrials--;
                    return;
                }
            }
            
            generalResultInformation.logedIn = true;
            DataTable dtSettingsTable =
                     this.getDataAccordingToRule.readEncryptedXmlSettingFile(settingFile);

            bool foundParameter = false;
            
            for (int rowCounter = dtSettingsTable.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                if (dtSettingsTable.Rows[rowCounter]["Parameter_Name"].ToString() == "UserName")
                {
                    dtSettingsTable.Rows[rowCounter]["Parameter_Value"] =
                        this.txtUserName.Text;
                    foundParameter = true;
                }
            }
            if (!foundParameter)
            {
                DataRow drNewSetting = dtSettingsTable.NewRow();
                drNewSetting["Parameter_Name"] = "UserName";
                drNewSetting["Parameter_Value"] = this.txtUserName.Text;

                dtSettingsTable.Rows.Add(drNewSetting);
            }

            this.getDataAccordingToRule.writeDatatableToEncryptedXmlSettingFile(dtSettingsTable, settingFile);            
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
