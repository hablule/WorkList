using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace POSDocumentPrinter
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
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "RefreshTime")
                        dbSettingInformationHandler.posRefreshTimeInterval =
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
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "station")
                        generalResultInformation.Station =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "centralStation")
                        generalResultInformation.centralStation =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "concernedNode")
                        generalResultInformation.concernedNode =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "cmbPOSPrinterNameList")
                        dbSettingInformationHandler.posPrinterNameList =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "machineRegistrationNumber")
                        generalResultInformation.machineRegistrationNumber =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "posEnableDeliveryOrderPrint")
                        dbSettingInformationHandler.posEnableDeliveryOrderPrint =
                           Convert.ToBoolean(dtSettingsTable.Rows[rowCounter][1].ToString());
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "UserName")
                        generalResultInformation.userName =
                           dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "theme")
                        dbSettingInformationHandler.theme =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                }

                if (!dbSettingInformationHandler.posLogChangeScript)
                {
                    dbSettingInformationHandler.posScriptDirectory = "";
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
        
        public bool establishDbConnectionSettins(Form checkerForm)
        {
            //CHECK SETTINGS
            dtSettingsTable.TableName = "Settings";
            dtSettingsTable.Columns.Add("Parameter_Name");
            dtSettingsTable.Columns.Add("Parameter_Value");
           CheckLine:
            if (numberOfTrial < 0)
            {
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
            if (!this.checkPOSDataBaseConnection())
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
            return true;
        }

    }
}
