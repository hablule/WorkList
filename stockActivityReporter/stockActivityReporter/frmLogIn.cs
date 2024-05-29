using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using dbConnection;
using System.Security.Cryptography;

namespace stockActivityReporter
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }
                
        string settingFile = "";
                
        
        string stUserId = "";
                

        dataBuilder getDbInfo = new dataBuilder();
        businessRule getDataAccordingToRule = new businessRule();
        dbConnection.businessRule dbConnectionRule = new dbConnection.businessRule();

        

        DataTable userOrgansation = new DataTable();
        DataTable userWarehouse = new DataTable();
        DataTable userLocators = new DataTable();
        DataTable userId = new DataTable();


        dataBuilder getDataFromDB = new dataBuilder();
        checkAndEstablishDbConnectionSettings dbCk =
                new checkAndEstablishDbConnectionSettings();



        private void frmLogIn_Load(object sender, EventArgs e)
        {
            this.settingFile = 
                dbSettingInformationHandler.settingFilePath;
            
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


            this.txtUserName.Text = generalResultInformation.userName;
            
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

            if (!this.getDataAccordingToRule.validateUser(this.txtUserName.Text, this.txtPassWord.Text))
            {
                MessageBox.Show("Invalid Username or PassWord. Try Again",
                    "Log In", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.userId = 
                this.getDbInfo.getAD_USERInfo(null, "", "", this.txtUserName.Text, "", true, false, "AND");

            this.stUserId = 
                this.userId.Rows[0]["AD_USER_ID"].ToString();

            generalResultInformation.userId = this.stUserId;

            generalResultInformation.clientId =
                this.userId.Rows[0]["AD_CLIENT_ID"].ToString();

            this.userWarehouse = 
                this.getDataFromDB.getAD_USER_WAREHOUSE_ACCESSInfo(null,"","",
                    this.stUserId, true, false, "AND");

            if (!getDbInfo.checkIfTableContainesData(this.userWarehouse))
            {
                this.userOrgansation =
                this.getDataFromDB.getAD_USER_ORGACCESSInfo(null, "", "",
                        this.stUserId, true, false, "AND");

                if (!getDbInfo.checkIfTableContainesData(userOrgansation))
                {
                    MessageBox.Show("User Has not Access To Any warehouse. Try Again",
                        "Log In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                this.userWarehouse =
                    this.getDataFromDB.getM_WAREHOUSEInfo(null, "", "", "",
                        true, true, "AND");
                DataTable warehouses = new DataTable();

                foreach (DataRow dr in userOrgansation.Rows)
                {
                    if (dr["AD_ORG_ID"].ToString() ==
                        generalResultInformation.allOrganisationRepresentativeKey)
                    {
                        this.userWarehouse =
                            this.getDataFromDB.getM_WAREHOUSEInfo(null, "", 
                            "", "", true, false, "AND");
                        break;
                    }
                    warehouses =
                        this.getDataFromDB.getM_WAREHOUSEInfo(null, "",
                                dr["AD_ORG_ID"].ToString(), "",
                                true, false, "AND");
                    this.userWarehouse.Merge(warehouses, true, MissingSchemaAction.Add);
                }

                this.userWarehouse =
                    this.getDataFromDB.clearRedundantRow(this.userWarehouse);
            }
            else
            {                
                DataTable userWareHouseAccess = 
                    this.userWarehouse.Copy();

                this.userWarehouse =
                    this.getDataFromDB.getM_WAREHOUSEInfo(null, "", "", "",
                        true, true, "AND");

                DataTable warehouses = new DataTable();

                foreach (DataRow dr in userWareHouseAccess.Rows)
                {
                    if (dr["M_WAREHOUSE_ID"].ToString() ==
                        generalResultInformation.allWarehouseRepresentativeKey)
                    {
                        this.userWarehouse =
                            this.getDataFromDB.getM_WAREHOUSEInfo(null, "",
                            "", "", true, false, "AND");
                        break;
                    }

                    warehouses =
                        this.getDataFromDB.getM_WAREHOUSEInfo(null, "",
                                "", dr["M_WAREHOUSE_ID"].ToString(),
                                true, false, "AND");
                    this.userWarehouse.Merge(warehouses, true, MissingSchemaAction.Add);
                }

                this.userWarehouse =
                    this.getDataFromDB.clearRedundantRow(this.userWarehouse);
            }

            this.userLocators =
                    this.getDataFromDB.getM_LOCATORInfo(null, "", "",
                        "", true, true, "AND");

            DataTable locators = new DataTable();

            foreach (DataRow dr in this.userWarehouse.Rows)
            {
                locators =
                    this.getDataFromDB.getM_LOCATORInfo(null, "",
                            "", dr["M_WAREHOUSE_ID"].ToString(),
                            true, false, "AND");

                this.userLocators.Merge(locators, true, MissingSchemaAction.Add);
            }

            this.userLocators =
                this.getDataFromDB.clearRedundantRow(this.userLocators);
            
            generalResultInformation.userId = this.stUserId;

            generalResultInformation.AccessableWarehouse = this.userWarehouse.Copy();
            generalResultInformation.AccessableLocators = this.userLocators.Copy();


            generalResultInformation.userCanEditSettings =
                    this.getDataAccordingToRule.userCanModifySettings(generalResultInformation.userId);


            DataTable dtSettingsTable = new DataTable();
            bool foundParameter = false;
            dtSettingsTable =
                        this.dbConnectionRule.readEncryptedXmlSettingFile(settingFile);
            
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

            this.dbConnectionRule.writeDatatableToEncryptedXmlSettingFile(dtSettingsTable, settingFile);
            

            if (generalResultInformation.clientId != "" &&
                generalResultInformation.userId != "")
                generalResultInformation.logedIn = true;
            else
                generalResultInformation.logedIn = false;

            this.visualStyler2.Shutdown();
            this.Close();
        }

        private void txtPassWord_TextChanged(object sender, EventArgs e)
        {
            this.txtPassWord.BackColor = Color.White;            
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            this.txtUserName.BackColor = Color.White;            
        }
                        
    }
}
