using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;


namespace dbConnection
{
    public class checkAndEstablishDbConnectionSettings
    {
        private DataTable dtSettingsTable = new DataTable();
        private string settingFile = dbSettingInformationHandler.settingFilePath;
        private int numberOfTrial = generalResultInformation.dbConfigTrials;

        businessRule getDataAccordingToRule = new businessRule();

        private void setGobalDataBaseInformationVariables()
        {
            try
            {

                for (int rowCounter = 0;
                    rowCounter < dtSettingsTable.Rows.Count;
                    rowCounter++)
                {
                    if (dtSettingsTable.Rows[rowCounter][0].ToString() == "ckLogChangeScripts")
                        dbSettingInformationHandler.logChangeScript =
                            Convert.ToBoolean(dtSettingsTable.Rows[rowCounter][1].ToString());
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "ckIsLDAPAuthenticated")
                    {
                        generalResultInformation.useLDAPAuthentication =
                            Convert.ToBoolean(dtSettingsTable.Rows[rowCounter][1].ToString());
                        generalResultInformation.LDAPConnectionSet =
                            generalResultInformation.useLDAPAuthentication;
                    }
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtDataBaseName")
                        dbSettingInformationHandler.dataBaseName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtErrorDir")
                        dbSettingInformationHandler.errorDirectory =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtMapDataTiming")
                        dbSettingInformationHandler.updateTimeInterval =
                            Convert.ToInt32(dtSettingsTable.Rows[rowCounter][1].ToString());
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtPassword")
                        dbSettingInformationHandler.dbPassword =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtScriptDir")
                        dbSettingInformationHandler.scriptDirectory =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtServerName")
                        dbSettingInformationHandler.dbHostName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtUserName")
                        dbSettingInformationHandler.dbUsername =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtWarningDir")
                        dbSettingInformationHandler.warningDirectory =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtPort")
                        dbSettingInformationHandler.dbPort =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "cmbPrinterName")
                        otherSettings.defaultPrinterName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "UserName")
                        generalResultInformation.UserName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "theme")
                        dbSettingInformationHandler.theme =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "ntbApprovedAmount")
                        generalResultInformation.allowedOverageShortageAmount =
                            decimal.Parse(dtSettingsTable.Rows[rowCounter][1].ToString());
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "ckAllowOverageShortagePassKey")
                        generalResultInformation.allowOverageShortagePassKey =
                            Convert.ToBoolean(dtSettingsTable.Rows[rowCounter][1].ToString());
                }

                if (!dbSettingInformationHandler.logChangeScript)
                {
                    dbSettingInformationHandler.scriptDirectory = "";
                }
            }
            catch
            { 
                
            }

        }

        private bool checkDataBaseConnection()
        {
            string connectionStatus = "";
            string oraDataBaseType = dbSettingInformationHandler.dbDataBaseType;
            string oraHostName = dbSettingInformationHandler.dbHostName;
            string oraDataBaseName = dbSettingInformationHandler.dataBaseName;
            string oraUserName = dbSettingInformationHandler.dbUsername;
            string oraPassWord = dbSettingInformationHandler.dbPassword;
            string oraPort = dbSettingInformationHandler.dbPort;

            persistanceClass compiereConnection = new persistanceClass(oraDataBaseType, oraHostName,
                oraDataBaseName, oraUserName, oraPassWord, oraPort);

            connectionStatus = compiereConnection.connectToDataBase(compiereConnection);
            if (connectionStatus == "Open")
            {
                compiereConnection.closeConnection(compiereConnection);
                return true;                
            }
            else
            {
                return false;
            }
        }
        
        public bool establishDbConnectionSettins(Form checkerForm)
        {
            //CHECK SETTINGS
            dtSettingsTable.TableName = "Settings";
            dtSettingsTable.Columns.Add("Parameter_Name");
            dtSettingsTable.Columns.Add("Parameter_Value");

           CheckLine:
            if (numberOfTrial < 0)
            {
                checkerForm.WindowState = FormWindowState.Normal;
                return false;
            }
            if (File.Exists(settingFile))
            {
                try
                {                    
                    dtSettingsTable = 
                        this.getDataAccordingToRule.readEncryptedXmlSettingFile(settingFile);
                    dataBuilder checkTableData = new dataBuilder();
                    
                    if (!checkTableData.checkIfTableContainesData(dtSettingsTable))
                    {
                        MessageBox.Show("Please configure application settings first.",
                            "Application Not Configured", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        frmsettings settingForm = new frmsettings();
                        checkerForm.WindowState = FormWindowState.Minimized;
                        checkerForm.Enabled = false;
                        settingForm.ShowDialog();
                        checkerForm.Enabled = true;
                        numberOfTrial--;
                        goto CheckLine;
                    }
                }
                catch
                {
                    MessageBox.Show("Unable to Read Settings. Please re-configure settings.",
                    "Corrupt Settings", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                    frmsettings settingForm = new frmsettings();
                    checkerForm.WindowState = FormWindowState.Minimized;
                    checkerForm.Enabled = false;
                    settingForm.ShowDialog();
                    checkerForm.Enabled = true;
                    numberOfTrial--;
                    goto CheckLine;
                }
            }
            else
            {
                MessageBox.Show("Setting Not Found. Please configure application settings first.",
                    "Missing Settings", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                frmsettings settingForm = new frmsettings();
                checkerForm.WindowState = FormWindowState.Minimized;
                checkerForm.Enabled = false;
                settingForm.ShowDialog();
                checkerForm.Enabled = true;
                numberOfTrial--;
                goto CheckLine;
            }

            //LOAD SETTING TO GLOBAL VARIABLES
            this.setGobalDataBaseInformationVariables();
            //CHECK DB CONNECTION ON compiere
            numberOfTrial = generalResultInformation.dbConfigTrials;
            if (!this.checkDataBaseConnection())
            {

                MessageBox.Show("Data Base Note Found. Please Check Your Setting.",
                    "Missing Settings", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                frmsettings settingForm = new frmsettings();
                checkerForm.WindowState = FormWindowState.Minimized;
                checkerForm.Enabled = false;
                settingForm.ShowDialog();
                checkerForm.Enabled = true;
                numberOfTrial--;
                goto CheckLine;
            }

            //Check Existance Of Log Directory
            if (!Directory.Exists(dbSettingInformationHandler.errorDirectory) ||
                !Directory.Exists(dbSettingInformationHandler.warningDirectory))
            {
                MessageBox.Show("Critical Log Directory Not Found. Please Check Your Setting.",
                        "Missing Settings", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
            checkerForm.WindowState = FormWindowState.Normal;            
            return true;
        }

        public void setSettings()
        {
            frmsettings frmStng = new frmsettings();
            frmStng.ShowDialog();
        }
    
    }
}
