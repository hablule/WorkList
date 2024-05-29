using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace EasyMoveDataBridge
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
                    if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtEasyMoveDataBaseName")
                        dbSettingInformationHandler.easyMoveDataBaseName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtEasyMoveErrorDir")
                        dbSettingInformationHandler.easyMoveErrorDirectory =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtEasyMoveMapDataTiming")
                        dbSettingInformationHandler.easyMoveSyncTimeInterval =
                            Convert.ToInt32(dtSettingsTable.Rows[rowCounter][1].ToString());
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtEasyMovePassword")
                        dbSettingInformationHandler.easyMoveDBPassword =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtEasyMovePort")
                        dbSettingInformationHandler.easyMoveDBPort =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtEasyMoveScriptDir")
                        dbSettingInformationHandler.easyMoveScriptDirectory =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtEasyMoveServerName")
                        dbSettingInformationHandler.easyMoveHostName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtEasyMoveUserName")
                        dbSettingInformationHandler.easyMoveDBUserName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "txtEasyMoveWarningDir")
                        dbSettingInformationHandler.easyMoveWarningDirectory =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "ckEasyMoveLogChangeScripts")
                        dbSettingInformationHandler.easyMoveLogChangeScript =
                           Convert.ToBoolean(dtSettingsTable.Rows[rowCounter][1].ToString());
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "ckEasyMoveAutoStartSynch")
                        dbSettingInformationHandler.easyMoveAutoStartSynch =
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

                if (!dbSettingInformationHandler.easyMoveLogChangeScript)
                {
                    dbSettingInformationHandler.easyMoveScriptDirectory = "";
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


        private bool checkEasyMoveDataBaseConnection()
        {
            string connectionStatus = "";
            string mySqlDataBaseType = dbSettingInformationHandler.easyMoveDataBaseType;
            string mySqlHostName = dbSettingInformationHandler.easyMoveHostName;
            string mySqlDataBaseName = dbSettingInformationHandler.easyMoveDataBaseName;
            string mySqlUserName = dbSettingInformationHandler.easyMoveDBUserName;
            string mySqlPassWord = dbSettingInformationHandler.easyMoveDBPassword;
            string mySqlPort = dbSettingInformationHandler.easyMoveDBPort;

            persistanceClass easyMoveConnection = new persistanceClass(mySqlDataBaseType, mySqlHostName,
                mySqlDataBaseName, mySqlUserName, mySqlPassWord, mySqlPort);

            connectionStatus = easyMoveConnection.connectToDataBase(easyMoveConnection);
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
            if (!this.checkEasyMoveDataBaseConnection() ||
                !this.checkCompiereDataBaseConnection())
            {

                MessageBox.Show("Data Base Note Found. Please Check Your Setting.",
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
            if (!Directory.Exists(dbSettingInformationHandler.easyMoveErrorDirectory) ||
                !Directory.Exists(dbSettingInformationHandler.easyMoveWarningDirectory))
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
