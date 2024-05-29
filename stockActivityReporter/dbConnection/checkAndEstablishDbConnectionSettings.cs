using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;

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
                    if (dtSettingsTable.Rows[rowCounter][0].ToString() == "DataBaseName")
                        dbSettingInformationHandler.DataBaseName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "DataBaseType")
                    {
                        dbSettingInformationHandler.DataBaseType =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                        if(dbSettingInformationHandler.DataBaseType == "MySql")
                        {
                            generalResultInformation.dateFormat = "yyyy-MM-dd";
                        }
                        else if(dbSettingInformationHandler.DataBaseType == "Oracle")
                        {
                            generalResultInformation.dateFormat = "dd-MMM-yyyy";
                        }
                        else
                        {
                            generalResultInformation.dateFormat = "dd-MMM-yyyy";
                        } 
                    }
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "ErrorDir")
                        dbSettingInformationHandler.ErrorDirectory =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "DBPassword")
                        dbSettingInformationHandler.DBPassword =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "DBPort")
                        dbSettingInformationHandler.DBPort =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "ScriptDir")
                        dbSettingInformationHandler.ScriptDirectory =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "DBServerName")
                        dbSettingInformationHandler.ServerHostName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "DBUserName")
                        dbSettingInformationHandler.DBUserName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "WarningDir")
                        dbSettingInformationHandler.WarningDirectory =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "LogChangeScripts")
                        dbSettingInformationHandler.LogChangeScript =
                           Convert.ToBoolean(dtSettingsTable.Rows[rowCounter][1].ToString());
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "LDAPAuthenticated")
                    {
                        generalResultInformation.useLDAPAuthentication =
                            Convert.ToBoolean(dtSettingsTable.Rows[rowCounter][1].ToString());
                        generalResultInformation.LDAPConnectionSet =
                            generalResultInformation.useLDAPAuthentication;
                    }
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "UserName")
                        generalResultInformation.userName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "PrinterName")
                        otherSettings.PrinterName =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                    else if (dtSettingsTable.Rows[rowCounter][0].ToString() == "theme")
                        dbSettingInformationHandler.theme =
                            dtSettingsTable.Rows[rowCounter][1].ToString();
                }

                if (!dbSettingInformationHandler.LogChangeScript)
                {
                    dbSettingInformationHandler.ScriptDirectory = "";
                }

                if (dbSettingInformationHandler.DataBaseType == "MySql")
                    dbSettingInformationHandler.dbTablePrefix = "EM_";
                else
                    dbSettingInformationHandler.dbTablePrefix = "";

                if (dbSettingInformationHandler.DataBaseType == "MySql")
                    dbSettingInformationHandler.upperCaseFunction = "UCASE";
                else
                    dbSettingInformationHandler.upperCaseFunction = "UPPER";
            }
            catch
            { 
                
            }

        }

        private bool checkDataBaseConnection()
        {
            string connectionStatus = "";
            string mySqlDataBaseType = dbSettingInformationHandler.DataBaseType;
            string mySqlHostName = dbSettingInformationHandler.ServerHostName;
            string mySqlDataBaseName = dbSettingInformationHandler.DataBaseName;
            string mySqlUserName = dbSettingInformationHandler.DBUserName;
            string mySqlPassWord = dbSettingInformationHandler.DBPassword;
            string mySqlPort = dbSettingInformationHandler.DBPort;

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
                
        public bool establishDbConnectionSettins()
        {
            //CHECK SETTINGS
           CheckLine:            

            if (!File.Exists(settingFile))
            {
                if (File.Exists(dbSettingInformationHandler.settingFilePath_bkp))
                {
                    File.Copy(dbSettingInformationHandler.settingFilePath_bkp, settingFile, true);
                }
            }

            if (File.Exists(settingFile))
            {                
                dtSettingsTable.Clear();

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
                        new frmsettings().ShowDialog();
                        numberOfTrial--;
                        if (numberOfTrial <= 0)
                        {
                            return false;
                        }
                        goto CheckLine;
                    }
                }
                catch
                {
                    MessageBox.Show("Unable to Read Settings. Please re-configure settings.",
                    "Corupt Settings", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                    new frmsettings().ShowDialog();
                    numberOfTrial--;
                    if (numberOfTrial <= 0)
                    {
                        return false;
                    }
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
                if (numberOfTrial <= 0)
                {
                    return false;
                }
                goto CheckLine;
            }

            //LOAD SETTING TO GLOBAL VARIABLES
            this.setGobalDataBaseInformationVariables();
            //CHECK DB CONNECTION ON compiere
            //numberOfTrial = generalResultInformation.dbConfigTrials;
            if (!this.checkDataBaseConnection())
            {

                MessageBox.Show("Data Base Note Found. Please Check Your Setting.",
                    "Missing Settings", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                new frmsettings().ShowDialog();
                numberOfTrial--;
                if (numberOfTrial <= 0)
                {
                    return false;
                }
                goto CheckLine;
            }

            //Check Existance Of Log Directory
            if (!Directory.Exists(dbSettingInformationHandler.ErrorDirectory) ||
                !Directory.Exists(dbSettingInformationHandler.WarningDirectory))
            {
                MessageBox.Show("Critical Log Directory Not Found. Please Check Your Setting.",
                        "Missing Settings", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);                
            }
            
            GC.Collect();
            return true;
        }

        public void setSettings()
        {
            frmsettings frmStng = new frmsettings();
            frmStng.ShowDialog();
        }

    }
}
