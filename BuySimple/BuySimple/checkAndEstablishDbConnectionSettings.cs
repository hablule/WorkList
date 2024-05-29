using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace BuySimple
{
    class checkAndEstablishDbConnectionSettings
    {
        private DataTable dtSettingsTable = new DataTable();
        private string settingFile = dbSettingInformationHandler.settingFilePath;
        private int numberOfTrial = generalResultInformation.dbConfigTrials;

        private bool setGobalDataBaseInformationVariables()
        {
            try
            {

                for (int rowCounter = 0;
                    rowCounter < dtSettingsTable.Rows.Count;
                    rowCounter++)
                {
                    if (dtSettingsTable.Rows[rowCounter][0].ToString() == "ckCompLogChangeScripts")
                        dbSettingInformationHandler.compLogChangeScript =
                            Convert.ToBoolean(dtSettingsTable.Rows[rowCounter][1].ToString());
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "ckCompIsLDAPAuthenticated")
                    {
                        generalResultInformation.useLDAPAuthentication =
                               Convert.ToBoolean(dtSettingsTable.Rows[rowCounter][1].ToString());
                        generalResultInformation.LDAPConnectionSet = 
                            generalResultInformation.useLDAPAuthentication;
                    }
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtCompDataBaseName")
                        dbSettingInformationHandler.compDataBaseName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtCompErrorDir")
                        dbSettingInformationHandler.compErrorDirectory =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtCompMapDataTiming")
                        dbSettingInformationHandler.compPurchaseCostUpdateTimeInterval =
                            Convert.ToInt32(dtSettingsTable.Rows[rowCounter][1].ToString());
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtCompPassword")
                        dbSettingInformationHandler.compPassword =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtCompScriptDir")
                        dbSettingInformationHandler.compScriptDirectory =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtCompServerName")
                        dbSettingInformationHandler.compHostName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtCompUserName")
                        dbSettingInformationHandler.compUsername =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtCompWarningDir")
                        dbSettingInformationHandler.compWarningDirectory =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtCompPort")
                        dbSettingInformationHandler.compPort =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "UserName")
                        generalResultInformation.UserName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "theme")
                        dbSettingInformationHandler.theme =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "cmbPOSPrinterNameList")
                        dbSettingInformationHandler.posPrinterNameList =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                }

                if (!dbSettingInformationHandler.compLogChangeScript)
                {
                    dbSettingInformationHandler.compScriptDirectory = "";
                }
            }
            catch
            {
                return false;
            }
            return true;

        }

        private bool checkCompiereDataBaseConnection()
        {
            string connectionStatus = "";
            string oraDataBaseType = dbSettingInformationHandler.compDataBaseType;
            string oraHostName = dbSettingInformationHandler.compHostName;
            string oraDataBaseName = dbSettingInformationHandler.compDataBaseName;
            string oraUserName = dbSettingInformationHandler.compUsername;
            string oraPassWord = dbSettingInformationHandler.compPassword;
            string oraPort = dbSettingInformationHandler.compPort;

            persistanceClass compiereConnection = new persistanceClass(oraDataBaseType, oraHostName,
                oraDataBaseName, oraUserName, oraPassWord, oraPort);

            connectionStatus = compiereConnection.connectToDataBase(compiereConnection);
            if (connectionStatus == "Open")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
                
        public bool establishDbConnectionSettins()
        {
            //CHECK SETTINGS
            dtSettingsTable.TableName = "Settings";
            dtSettingsTable.Columns.Add("Parameter_Name");
            dtSettingsTable.Columns.Add("Parameter_Value");

            if (!File.Exists(settingFile))
            {
                if (File.Exists(dbSettingInformationHandler.settingFilePath_bkp))
                {
                    File.Copy(dbSettingInformationHandler.settingFilePath_bkp, settingFile, true);
                }
            }

           CheckLine:
            if (numberOfTrial < 0)
            {
                GC.Collect();
                return false;
            }
            if (File.Exists(settingFile))
            {
                dtSettingsTable.Clear();

                try
                {
                    dtSettingsTable =
                        new businessRule().readEncryptedXmlSettingFile(settingFile);

                    dataBuilder checkTableData = new dataBuilder();
                    
                    if (!checkTableData.checkIfTableContainesData(dtSettingsTable))
                    {
                        MessageBox.Show("Please configure application settings first.",
                            "Application Not Configured", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        new frmsettings().ShowDialog();                        
                        numberOfTrial--;                        
                        goto CheckLine;
                    }
                }
                catch
                {
                    MessageBox.Show("Unable to Read Settings. Please re-configure settings.",
                    "Corrupt Settings", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                    new frmsettings().ShowDialog();
                    numberOfTrial--;
                    goto CheckLine;
                }
            }
            else
            {
                MessageBox.Show("Setting Not Found. Please configure application settings first.",
                    "Missing Settings", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                new frmsettings().ShowDialog();
                numberOfTrial--;
                goto CheckLine;
            }

            //LOAD SETTING TO GLOBAL VARIABLES
            this.setGobalDataBaseInformationVariables();
            //CHECK DB CONNECTION ON compiere
            numberOfTrial = generalResultInformation.dbConfigTrials;
            if (!this.checkCompiereDataBaseConnection())
            {

                MessageBox.Show("Data Base Note Found. Please Check Your Setting.",
                    "Missing Settings", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                new frmsettings().ShowDialog();
                numberOfTrial--;
                goto CheckLine;
            }

            //Check Existance Of Log Directory
            if (!Directory.Exists(dbSettingInformationHandler.compErrorDirectory) ||
                !Directory.Exists(dbSettingInformationHandler.compWarningDirectory))
            {
                MessageBox.Show("Critical Log Directory Not Found. Please Check Your Setting.",
                        "Missing Settings", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);                
            }
            GC.Collect();
            return true;
        }
    }
}
