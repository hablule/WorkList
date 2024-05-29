using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace dbConnection
{
    public partial class frmsettings : Form
    {
        public frmsettings()
        {
            InitializeComponent();
        }

        bool configureLDAP = false;

        DataTable dtSettings = new DataTable();
        string xmlFile = dbSettingInformationHandler.settingFilePath;
        DataRow dtRow;
        string[] stInstalledPrinterNameList;

        businessRule getDataAccordingToRule = new businessRule();
        

        private void frmsettings_Load(object sender, EventArgs e)
        {            
            this.DataBaseType.SelectedIndex = 1;
            dataBuilder dtBulder = new dataBuilder();

            System.Drawing.Printing.PrinterSettings.StringCollection printersList =
                System.Drawing.Printing.PrinterSettings.InstalledPrinters;

            this.stInstalledPrinterNameList = 
                new string[printersList.Count];
            printersList.CopyTo(this.stInstalledPrinterNameList, 0);

            this.PrinterName.Items.AddRange(this.stInstalledPrinterNameList);
            if(this.PrinterName.Items.Count > 0)
                this.PrinterName.SelectedIndex = 0;
            
            try
            {
                this.dtSettings = 
                    this.getDataAccordingToRule.readEncryptedXmlSettingFile(xmlFile);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (!dtBulder.checkIfTableContainesData(dtSettings))
            {
                this.getDataAccordingToRule.writeDatatableToEncryptedXmlSettingFile(this.dtSettings, xmlFile);
            }
            else
            {
                this.readOrWriteFromXMLfile(true, this.grbEasyMove);
            }

            this.configureLDAP = true;
        }
        
        private bool checkAllNeccessaryFields(Control ckControl)
        {
            string controlName = "";
            bool ckState = true;
                        
            for (int controlCounter = 0;
                controlCounter < ckControl.Controls.Count; 
                controlCounter++)
            {
                controlName = ckControl.Controls[controlCounter].Name;
                if (ckControl.Controls[controlCounter] is TextBox)
                {
                    if (ckControl.Controls[controlCounter].Text == "")
                    {

                        ckControl.Controls["lbl" + controlName].ForeColor =
                            Color.Red;
                        ckState = false;
                    }
                    else
                    {
                        ckControl.Controls["lbl" + controlName].ForeColor =
                            Color.Black;
                    }
                    
                }
            }

            if (this.LDAPAuthenticated.Checked)
            {
                LDAPConnection tstConnection = new LDAPConnection();
                generalResultInformation.LDAPConnectionSet = tstConnection.authenticateConnection();
                if (!generalResultInformation.LDAPConnectionSet)
                {
                    MessageBox.Show("LDAP Not cofigured properly. Please Configure LADP or Uncheck 'LDAP Authenticated' Check box");
                    this.LDAPAuthenticated.ForeColor = Color.Red;

                    ckState = false;
                }
                else
                {
                    this.LDAPAuthenticated.ForeColor = Color.Black;
                }
            }
            else
            {
                this.LDAPAuthenticated.ForeColor = Color.Black;
            }

            return ckState;
        }

        
        private void readOrWriteFromXMLfile(bool read, GroupBox grpbox)
        {
           if (read)
            {
                this.dtSettings =
                     this.getDataAccordingToRule.readEncryptedXmlSettingFile(xmlFile); 
               
                for (int rowCounter = 0;
                    rowCounter < dtSettings.Rows.Count;
                    rowCounter++)
                {
                    string controlName = dtSettings.Rows[rowCounter][0].ToString();
                    if (this.grbEasyMove.Controls[controlName] is TextBox)
                    {
                        this.grbEasyMove.Controls[controlName].Text =
                        dtSettings.Rows[rowCounter][1].ToString(); 
                    }
                    else if (this.grbEasyMove.Controls[controlName] is CheckBox)
                    {
                        ((CheckBox)this.grbEasyMove.Controls[controlName]).Checked =
                            Convert.ToBoolean(dtSettings.Rows[rowCounter][1].ToString());
                    }
                    else if (this.grbEasyMove.Controls[controlName] is ComboBox)
                    {
                        if (((ComboBox)this.grbEasyMove.Controls[controlName]).Items.Contains(dtSettings.Rows[rowCounter][1].ToString()))
                        {
                            ((ComboBox)this.grbEasyMove.Controls[controlName]).SelectedItem =
                                dtSettings.Rows[rowCounter][1].ToString();
                        }
                    }
                }
            }

            else
            {   
                for (int controlCounter = 0;
                    controlCounter < this.grbEasyMove.Controls.Count;
                    controlCounter++)
                {
                    string controlName =
                        grpbox.Controls[controlCounter].Name;
                    if (grpbox.Controls[controlName].GetType().Equals(typeof(TextBox)) ||
                        grpbox.Controls[controlName].GetType().Equals(typeof(CheckBox)) ||
                        grpbox.Controls[controlName].GetType().Equals(typeof(ComboBox)))
                    {
                        for (int rowCounter = 0; ; rowCounter++)
                        {
                            if (rowCounter  > dtSettings.Rows.Count - 1)
                            {
                                dtRow = dtSettings.NewRow();
                                dtRow[0] = controlName;

                                if (grpbox.Controls[controlCounter].GetType().Equals(typeof(TextBox)))
                                {                                    
                                    dtRow[1] = grpbox.Controls[controlName].Text;                                    
                                }
                                else if (grpbox.Controls[controlCounter].GetType().Equals(typeof(CheckBox)))
                                {
                                    dtRow[1] = ((CheckBox)grpbox.Controls[controlCounter]).Checked;
                                }
                                else if (grpbox.Controls[controlCounter].GetType().Equals(typeof(ComboBox)))
                                {
                                    dtRow[1] = ((ComboBox)grpbox.Controls[controlCounter]).SelectedItem.ToString();
                                }

                                dtSettings.Rows.Add(dtRow);
                                break;
                            }
                            else if (dtSettings.Rows[rowCounter][0].ToString() == controlName)
                            {
                                if (grpbox.Controls[controlCounter].GetType().Equals(typeof(TextBox)))
                                {
                                    dtSettings.Rows[rowCounter][1] = grpbox.Controls[controlName].Text;
                                }
                                else if (grpbox.Controls[controlCounter].GetType().Equals(typeof(CheckBox)))
                                {
                                    dtSettings.Rows[rowCounter][1] = ((CheckBox)grpbox.Controls[controlCounter]).Checked;
                                }
                                else if (grpbox.Controls[controlCounter].GetType().Equals(typeof(ComboBox)))
                                {
                                    dtSettings.Rows[rowCounter][1] = ((ComboBox)grpbox.Controls[controlCounter]).SelectedItem.ToString();
                                }
                                break;
                            }
                        }
                    }
                }
                this.getDataAccordingToRule.writeDatatableToEncryptedXmlSettingFile(this.dtSettings, xmlFile);                
            }            
        }

        private void cmdEasyMoveSettingTest_Click(object sender, EventArgs e)
        {
            bool LogDirectoryExist = true;
            this.cmdSettingTest.Enabled = false;
            this.cmdSettingSave.Enabled = false;

            if (!checkAllNeccessaryFields(this.grbEasyMove))
            {
                MessageBox.Show("Missing Items Detected. Please Check Again");
                this.cmdSettingTest.Enabled = true;
                this.cmdSettingSave.Enabled = true;
                return;
            }

            if (!Directory.Exists(WarningDir.Text))
            {
                lblWarningDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }
            else
            {
                lblWarningDir.ForeColor = Color.Black;
            }

            if (!Directory.Exists(ErrorDir.Text))
            {
                lblErrorDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }
            else
            {
                lblErrorDir.ForeColor = Color.Black;
            }

            if (!Directory.Exists(ScriptDir.Text))
            {
                lblScriptDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }
            else
            {
                lblScriptDir.ForeColor = Color.Black;
            }

            if (!LogDirectoryExist)
            {
                MessageBox.Show("Critical Log Directory Not Found.",
                        "Missing Settings", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }

            persistanceClass checkDbConnection =
                new persistanceClass(DataBaseType.SelectedItem.ToString(),
                    DBServerName.Text,
                    DataBaseName.Text,
                    DBUserName.Text,
                    DBPassword.Text,
                    DBPort.Text);

            string status = checkDbConnection.connectToDataBase(checkDbConnection);
            if (status == "Open")
            {
                MessageBox.Show("Connection Succeeded");
            }
            else
            {
                MessageBox.Show(status);
            }

            this.cmdSettingTest.Enabled = true;
            this.cmdSettingSave.Enabled = true;

        }

        private void cmdEasyMoveSettingSave_Click(object sender, EventArgs e)
        {
            this.cmdSettingSave.Enabled = false;
            if (!checkAllNeccessaryFields(this.grbEasyMove))
            {
                MessageBox.Show("Missing Items Detected. Please Check Again");
            }
            else
            {
                readOrWriteFromXMLfile(false, this.grbEasyMove);
                MessageBox.Show("Configuration Saved. Please Restart Application.");
            }
            this.cmdSettingSave.Enabled = true;
        }


        private void cmdEasyMoveScriptFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.ScriptDir.Text = "";
            this.ScriptDir.Text =
                this.folderBrowserDialog1.SelectedPath;
            this.folderBrowserDialog1.SelectedPath = "";

        }

        private void cmdEasyMoveErrFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.ErrorDir.Clear();
            this.ErrorDir.Text =
                this.folderBrowserDialog1.SelectedPath;
            this.folderBrowserDialog1.SelectedPath = "";
        }

        private void cmdEasyMoveWarningFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.WarningDir.Clear();
            this.WarningDir.Text =
                this.folderBrowserDialog1.SelectedPath;
            this.folderBrowserDialog1.SelectedPath = "";
        }

        private void LDAPAuthenticated_CheckedChanged(object sender, EventArgs e)
        {
            if (this.configureLDAP && this.LDAPAuthenticated.Checked)
            {
                frmCreateLDAPConnection frmCreateLDAPConnection = new frmCreateLDAPConnection();
                frmCreateLDAPConnection.ShowDialog();
            }
        }

    }
}
