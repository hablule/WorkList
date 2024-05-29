using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BuySimple
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }

        bool userAccessAllOrganisation = false;

        string settingFile = dbSettingInformationHandler.settingFilePath;     
        string stUserId = "";

        dataBuilder getDbInfo = new dataBuilder();
        businessRule getDataAccordingToRule = new businessRule();

        DataTable userSection = new DataTable();
        DataTable userId = new DataTable();

        

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            //Check If anotherUser Is LogedIn
            if (generalResultInformation.logedIn)
            {
                MessageBox.Show("Program Is Already Running. Please Exit the running application first.",
                    "Log In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            checkAndEstablishDbConnectionSettings dbConnection = new checkAndEstablishDbConnectionSettings();
            if (!dbConnection.establishDbConnectionSettins())
            {
                MessageBox.Show("Unable to Login to the System", "Log In", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            //this.txtUserName.Text = "Administrator";
            //this.txtPassWord.Text = "admin@gplc";
            this.txtUserName.Text = generalResultInformation.UserName;
            this.cmbSection.Enabled = false;
            if (this.txtUserName.Text != "")
                this.SelectNextControl(this.txtUserName, true, true, false, false);

            this.visualStyler2.LoadVisualStyle(dbSettingInformationHandler.theme);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (this.cmbSection.Items.Count <= 0)
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
                this.userId =
                    this.getDataAccordingToRule.authenticateUser(this.txtUserName.Text, this.txtPassWord.Text);

                if (!getDbInfo.checkIfTableContainesData(userId))
                {
                    MessageBox.Show("Invalid Username or PassWord. Try Again",
                        "Log In", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.stUserId = this.userId.Rows[0]["AD_USER_ID"].ToString();                                
                generalResultInformation.clientId =
                    this.userId.Rows[0]["AD_CLIENT_ID"].ToString();
               

                this.userSection =
                    this.getDbInfo.getAD_USER_ORGACCESSInfo(null,"","",
                    this.stUserId,true,false,"AND");

                if (!getDbInfo.checkIfTableContainesData(userSection))
                {
                    MessageBox.Show("User Not Assigned To Any Organisation. Try Again",
                        "Log In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                this.txtUserName.BackColor = Color.FromKnownColor(KnownColor.Control);
                this.txtPassWord.BackColor = Color.FromKnownColor(KnownColor.Control);
                
                string [] organisationIDList = new string[this.userSection.Rows.Count];
                for(int rowCounter = 0; rowCounter <= this.userSection.Rows.Count-1;
                    rowCounter ++)
                {
                    if(this.userSection.Rows[rowCounter]["AD_ORG_ID"].ToString() ==
                        generalResultInformation.allOrganisationRepresentativeKey)
                    {
                        this.userAccessAllOrganisation = true;
                        break;
                    }
                        organisationIDList[rowCounter] =
                        this.userSection.Rows[rowCounter]["AD_ORG_ID"].ToString();
                }

                if(!this.userAccessAllOrganisation)
                    this.userSection = 
                        this.getDbInfo.getAD_ORGInfo(
                            this.getDataAccordingToRule.
                                buildOrganisationSelectionCriteria(organisationIDList,false),
                                "OR","", true, false, "AND");
                else
                    this.userSection = 
                        this.getDbInfo.getAD_ORGInfo(null,"","", true, false, "AND");

                this.userSection.Columns.Add("Index", System.Type.GetType("System.Int16"));
                
                for (int rowCounter = 0; rowCounter < userSection.Rows.Count; rowCounter++)
                {
                    this.userSection.Rows[rowCounter]["Index"] = rowCounter;                    
                }
                for (int rowCounter = 0; rowCounter < userSection.Rows.Count; rowCounter++)
                {
                    this.cmbSection.Items.Insert(Convert.ToInt16(userSection.Rows[rowCounter]["Index"]),
                        userSection.Rows[rowCounter]["NAME"].ToString());
                }
                this.cmbSection.Enabled = true;
                this.cmbSection.SelectedIndex = 0;
            }

            else if (this.cmbSection.Items.Count > 0)
            {
                //set globalVariables and Exit
                generalResultInformation.userId = this.stUserId;
                generalResultInformation.organiztionId =
                    this.userSection.Rows[this.cmbSection.SelectedIndex]["AD_ORG_ID"].ToString();
                generalResultInformation.userCanEditSettings =
                    this.getDataAccordingToRule.userCanModifySettings(this.stUserId);
                this.userSection =
                    this.getDbInfo.getAD_USER_ORGACCESSInfo(null, "",
                        this.userSection.Rows[this.cmbSection.SelectedIndex]["AD_ORG_ID"].ToString(),
                        this.stUserId, true, false, "AND");
                if(this.userSection.Rows.Count <= 0)
                    this.userSection =
                        this.getDbInfo.getAD_USER_ORGACCESSInfo(null, "",
                            generalResultInformation.allOrganisationRepresentativeKey,
                            this.stUserId, true, false, "AND");

                if (this.userSection.Rows.Count > 0)
                {
                    if (userSection.Rows[0]["ISREADONLY"].ToString() == "N")
                        generalResultInformation.userprevilageIsReadOnly = false;
                }
                else
                    generalResultInformation.userprevilageIsReadOnly = true;
                if (generalResultInformation.organiztionId != "" &&
                    generalResultInformation.clientId != "" &&
                    generalResultInformation.userId != "")
                    generalResultInformation.logedIn = true;
                else
                    generalResultInformation.logedIn = false;
                DataTable dtSettingsTable = new DataTable();
                bool foundParameter = false;
                dtSettingsTable.TableName = "Settings";
                dtSettingsTable.Columns.Add("Parameter_Name");
                dtSettingsTable.Columns.Add("Parameter_Value");

                dtSettingsTable =
                    this.getDataAccordingToRule.readEncryptedXmlSettingFile(settingFile);

                for (int rowCounter = dtSettingsTable.Rows.Count - 1;
                    rowCounter >= 0; rowCounter--)
                {
                    if (dtSettingsTable.Rows[rowCounter]["Parameter_Name"].ToString() == "UserName")
                    {
                        dtSettingsTable.Rows[rowCounter]["Parameter_Value"] =
                            this.txtUserName.Text;
                        this.getDataAccordingToRule.writeDatatableToEncryptedXmlSettingFile(dtSettingsTable, settingFile);
                        foundParameter = true;
                    }
                }
                if (!foundParameter)
                {
                    DataRow drNewSetting = dtSettingsTable.NewRow();
                    drNewSetting["Parameter_Name"] = "UserName";
                    drNewSetting["Parameter_Value"] = this.txtUserName.Text;

                    dtSettingsTable.Rows.Add(drNewSetting);
                    this.getDataAccordingToRule.writeDatatableToEncryptedXmlSettingFile(dtSettingsTable, settingFile);
                }
                this.Close();
                this.visualStyler2.Shutdown();
            }
        }

        private void txtPassWord_TextChanged(object sender, EventArgs e)
        {
            this.txtPassWord.BackColor = Color.White;
            this.cmbSection.Items.Clear();
            this.cmbSection.Enabled = false;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            this.txtUserName.BackColor = Color.White;
            this.cmbSection.Items.Clear();
            this.cmbSection.Enabled = false;
        }
                        
    }
}
