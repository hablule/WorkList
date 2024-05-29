using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace POSDataBridge
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
                    if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtPOSDataBaseName")
                        dbSettingInformationHandler.posDataBaseName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtPOSErrorDir")
                        dbSettingInformationHandler.posErrorDirectory =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtPOSMapDataTiming")
                        dbSettingInformationHandler.posSyncTimeInterval =
                            Convert.ToInt32(dtSettingsTable.Rows[rowCounter][1].ToString());
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtPOSPassword")
                        dbSettingInformationHandler.posDBPassword =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtPOSPort")
                        dbSettingInformationHandler.posDBPort =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtPOSScriptDir")
                        dbSettingInformationHandler.posScriptDirectory =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtPOSServerName")
                        dbSettingInformationHandler.posHostName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtPOSUserName")
                        dbSettingInformationHandler.posDBUserName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtPOSWarningDir")
                        dbSettingInformationHandler.posWarningDirectory =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "ckPOSLogChangeScripts")
                        dbSettingInformationHandler.posLogChangeScript =
                           Convert.ToBoolean(dtSettingsTable.Rows[rowCounter][1].ToString());
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "ckPOSAutoStartSynch")
                        dbSettingInformationHandler.posAutoStartSynch =
                           Convert.ToBoolean(dtSettingsTable.Rows[rowCounter][1].ToString());

                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtCompDataBaseName")
                        dbSettingInformationHandler.compDataBaseName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtCompErrorDir")
                        dbSettingInformationHandler.compErrorDirectory =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtCompMapDataTiming")
                        dbSettingInformationHandler.compSyncTimeInterval =
                            Convert.ToInt32(dtSettingsTable.Rows[rowCounter][1].ToString());
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtCompPassword")
                        dbSettingInformationHandler.compDBPassword =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtCompPort")
                        dbSettingInformationHandler.compDBPort =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtCompScriptDir")
                        dbSettingInformationHandler.compScriptDirectory =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtCompServerName")
                        dbSettingInformationHandler.compHostName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtCompUserName")
                        dbSettingInformationHandler.compDBUsername =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtCompWarningDir")
                        dbSettingInformationHandler.compWarningDirectory =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "ckCompLogChangeScripts")
                        dbSettingInformationHandler.compLogChangeScript =
                           Convert.ToBoolean(dtSettingsTable.Rows[rowCounter][1].ToString());
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "ckCompAutoStartSynch")
                        dbSettingInformationHandler.compAutoStartSynch =
                           Convert.ToBoolean(dtSettingsTable.Rows[rowCounter][1].ToString());
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "Station")
                        generalResultInformation.Station =
                            dtSettingsTable.Rows[rowCounter][1].ToString();  
                }

                if (!dbSettingInformationHandler.posLogChangeScript)
                {
                    dbSettingInformationHandler.posScriptDirectory = "";
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


        private bool checkPOSDataBaseConnection()
        {
            string connectionStatus = "";
            string mySqlDataBaseType = dbSettingInformationHandler.posDataBaseType;
            string mySqlHostName = dbSettingInformationHandler.posHostName;
            string mySqlDataBaseName = dbSettingInformationHandler.posDataBaseName;
            string mySqlUserName = dbSettingInformationHandler.posDBUserName;
            string mySqlPassWord = dbSettingInformationHandler.posDBPassword;
            string mySqlPort = dbSettingInformationHandler.posDBPort;

            persistanceClass posConnection = new persistanceClass(mySqlDataBaseType, mySqlHostName,
                mySqlDataBaseName, mySqlUserName, mySqlPassWord, mySqlPort);

            connectionStatus = posConnection.connectToDataBase(posConnection);
            if (connectionStatus == "Open")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool checkCompiereDataBaseConnection()
        {
            string connectionStatus = "";
            string oraDataBaseType = dbSettingInformationHandler.compDataBaseType;
            string oraHostName = dbSettingInformationHandler.compHostName;
            string oraDataBaseName = dbSettingInformationHandler.compDataBaseName;
            string oraUserName = dbSettingInformationHandler.compDBUsername;
            string oraPassWord = dbSettingInformationHandler.compDBPassword;
            string oraPort = dbSettingInformationHandler.compDBPort;

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
                checkerForm.Enabled = true;
                return false;
            }
            if (File.Exists(settingFile))
            {                
                try
                {                    
                    dtSettingsTable.ReadXml(settingFile);
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
                        numberOfTrial--;
                        goto CheckLine;
                    }
                }
                catch
                {
                    MessageBox.Show("Unable to Read Settings. Please re-configure settings.",
                    "Corupt Settings", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                    frmsettings settingForm = new frmsettings();
                    checkerForm.WindowState = FormWindowState.Minimized;
                    checkerForm.Enabled = false;
                    settingForm.ShowDialog();
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
                numberOfTrial--;
                goto CheckLine;
            }

            //LOAD SETTING TO GLOBAL VARIABLES
            this.setGobalDataBaseInformationVariables();
            //CHECK DB CONNECTION ON compiere
            numberOfTrial = generalResultInformation.dbConfigTrials;
            if (!this.checkPOSDataBaseConnection() ||
                !this.checkCompiereDataBaseConnection())
            {

                MessageBox.Show("Data Base Not Found. Please Check Your Setting.",
                    "Missing Settings", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                frmsettings settingForm = new frmsettings();
                checkerForm.WindowState = FormWindowState.Minimized;
                checkerForm.Enabled = false;
                settingForm.ShowDialog();
                numberOfTrial--;
                goto CheckLine;
            }

            //Check Existance Of Log Directory
            if (!Directory.Exists(dbSettingInformationHandler.posErrorDirectory) ||
                !Directory.Exists(dbSettingInformationHandler.posWarningDirectory))
            {
                MessageBox.Show("Critical Log Directory Not Found. Please Check Your Setting.",
                        "Missing Settings", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);                
            }
            //if (generalResultInformation.Station == "" ||
            //    generalResultInformation.Station == " ")
            //    return false;
            checkerForm.WindowState = FormWindowState.Normal;
            checkerForm.Enabled = true;
            return true;
        }

    }
}
