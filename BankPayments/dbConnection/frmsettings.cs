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
            this.cmbDataBaseType.SelectedIndex = 0;
            dataBuilder dtBulder = new dataBuilder();

            System.Drawing.Printing.PrinterSettings.StringCollection printersList =
                System.Drawing.Printing.PrinterSettings.InstalledPrinters;

            this.stInstalledPrinterNameList = new string[printersList.Count];
            printersList.CopyTo(this.stInstalledPrinterNameList, 0);

            this.cmbPrinterName.Items.AddRange(this.stInstalledPrinterNameList);
            if (this.cmbPrinterName.Items.Count > 0)
                this.cmbPrinterName.SelectedIndex = 0;

            this.cmbCheckPrinter.Items.AddRange(this.stInstalledPrinterNameList);
            if (this.cmbCheckPrinter.Items.Count > 0)
                this.cmbCheckPrinter.SelectedIndex = 0;


            dtSettings.TableName = "Settings";
            dtSettings.Columns.Add("Parameter_Name");
            dtSettings.Columns.Add("Parameter_Value");

            try
            {
                dtSettings =
                    this.getDataAccordingToRule.readEncryptedXmlSettingFile(xmlFile);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (!dtBulder.checkIfTableContainesData(dtSettings))
            {
                this.getDataAccordingToRule.writeDatatableToEncryptedXmlSettingFile(dtSettings, this.xmlFile);
            }
            else
            {
                this.readOrWriteFromXMLfile(true, this.grbCompiere);
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
                if (controlName.Contains("txt"))
                {
                    if (ckControl.Controls[controlCounter].Text == "")
                    {

                        ckControl.Controls[controlName.
                            Replace("txt", "lbl")].ForeColor =
                            Color.Red;
                        ckState = false;
                        //break;
                    }
                    else
                    {
                        ckControl.Controls[controlName.
                            Replace("txt", "lbl")].ForeColor =
                            Color.Black;

                    }
                    
                }
            }

            if (this.ckIsLDAPAuthenticated.Checked)
            {
                LDAPConnection tstConnection = new LDAPConnection();
                generalResultInformation.LDAPConnectionSet = tstConnection.authenticateConnection();
                if (!generalResultInformation.LDAPConnectionSet)
                {
                    MessageBox.Show("LDAP Not cofigured properly. Please Configure LADP or Uncheck 'LDAP Authenticated' Check box");
                    this.ckIsLDAPAuthenticated.ForeColor = Color.Red;

                    ckState = false;
                }
                else
                {
                    this.ckIsLDAPAuthenticated.ForeColor = Color.Black;
                }
            }
            else
            {
                this.ckIsLDAPAuthenticated.ForeColor = Color.Black;
            }


            return ckState;
        }

        private void readOrWriteFromXMLfile(bool read, GroupBox grpbox)
        {
           if (read)
            {
               dtSettings.Clear();
               dtSettings =
                   this.getDataAccordingToRule.readEncryptedXmlSettingFile(xmlFile);
               for (int rowCounter = 0;
                   rowCounter < dtSettings.Rows.Count;
                   rowCounter++)
               {
                   string controlName = dtSettings.Rows[rowCounter][0].ToString();
                   if (this.grbCompiere.Controls[controlName] is TextBox)
                   {
                       this.grbCompiere.Controls[controlName].Text =
                           dtSettings.Rows[rowCounter][1].ToString();
                   }
                   else if (this.grbCompiere.Controls[controlName] is CheckBox)
                   {
                       ((CheckBox)this.grbCompiere.Controls[controlName]).Checked =
                           Convert.ToBoolean(dtSettings.Rows[rowCounter][1].ToString());
                   }
                   else if (this.grbCompiere.Controls[controlName] is ComboBox)
                   {
                       if (((ComboBox)this.grbCompiere.Controls[controlName]).Items.Contains(dtSettings.Rows[rowCounter][1].ToString()))
                       {
                           ((ComboBox)this.grbCompiere.Controls[controlName]).SelectedItem =
                               dtSettings.Rows[rowCounter][1].ToString();
                       }
                   }
                   else if (this.grbCompiere.Controls[controlName] is customControls.ctlNumberTextBox)
                   {
                       ((customControls.ctlNumberTextBox)this.grbCompiere.Controls[controlName]).Amount =
                               dtSettings.Rows[rowCounter][1].ToString();                      
                   }
               }
            }
            else
            {
                
                for (int controlCounter = 0;
                    controlCounter < this.grbCompiere.Controls.Count;
                    controlCounter++)
                {
                    string controlName =
                        grpbox.Controls[controlCounter].Name;

                    if (
                            grpbox.Controls[controlName].GetType().Equals(typeof(TextBox)) ||
                            grpbox.Controls[controlName].GetType().Equals(typeof(CheckBox)) ||
                            grpbox.Controls[controlName].GetType().Equals(typeof(ComboBox)) ||
                            grpbox.Controls[controlName].GetType().Equals(typeof(customControls.ctlNumberTextBox))
                        )
                    {
                        for (int rowCounter = 0; ; rowCounter++)
                        {
                            if (rowCounter  >= dtSettings.Rows.Count)
                            {
                                dtRow = dtSettings.NewRow();
                                dtRow[0] = controlName;

                                if (grpbox.Controls[controlCounter].GetType().Equals(typeof(TextBox)))
                                {                                    
                                    dtRow[1] = grpbox.Controls[controlName].Text;
                                }
                                else if (grpbox.Controls[controlCounter].GetType().Equals(typeof(CheckBox)))
                                {
                                        dtRow[1] = (((CheckBox)grpbox.Controls[controlCounter]).Checked);
                                }
                                else if (grpbox.Controls[controlCounter].GetType().Equals(typeof(ComboBox)))
                                {
                                    dtRow[1] = grpbox.Controls[controlName].Text;
                                }
                                else if (grpbox.Controls[controlCounter].GetType().Equals(typeof(customControls.ctlNumberTextBox)))
                                {
                                    dtRow[1] = ((customControls.ctlNumberTextBox)grpbox.Controls[controlName]).Amount;
                                }

                                dtSettings.Rows.Add(dtRow);
                                break;
                            }
                            else if (dtSettings.Rows[rowCounter][0].ToString() == controlName)
                            {
                                if (grpbox.Controls[controlCounter].GetType().Equals(typeof(CheckBox)))
                                {
                                    dtSettings.Rows[rowCounter][1] = (((CheckBox)grpbox.Controls[controlCounter]).Checked);
                                }
                                else if (grpbox.Controls[controlCounter].GetType().Equals(typeof(customControls.ctlNumberTextBox)))
                                {
                                    dtSettings.Rows[rowCounter][1] = (((customControls.ctlNumberTextBox)grpbox.Controls[controlCounter]).Amount);
                                }
                                else
                                {
                                    dtSettings.Rows[rowCounter][1] = grpbox.Controls[controlName].Text;
                                }
                            }
                        }
                    }
                }

                this.getDataAccordingToRule.writeDatatableToEncryptedXmlSettingFile(dtSettings, xmlFile);               
            }
        }

        private void cmdSettingTest_Click(object sender, EventArgs e)
        {
            this.cmdSettingTest.Enabled = false;
            this.cmdSettingSave.Enabled = false;
            bool LogDirectoryExist = true;
            if (!checkAllNeccessaryFields(this.grbCompiere))
            {
                MessageBox.Show("Missing Items Detected. Please Check Again");
                this.cmdSettingTest.Enabled = true;
                this.cmdSettingSave.Enabled = true;
                return;
            }

            persistanceClass checkDbConnection =
                new persistanceClass(cmbDataBaseType.SelectedItem.ToString(),
                    txtServerName.Text,
                    txtDataBaseName.Text,
                    txtUserName.Text,
                    txtPassword.Text,
                    txtPort.Text);
            
            string status = checkDbConnection.connectToDataBase(checkDbConnection);
            if (status == "Open")
            {
                MessageBox.Show("Connection Succeeded");
            }
            else
            {
                MessageBox.Show(status);
            }

            if (!Directory.Exists(txtWarningDir.Text)) 
            {
                lblWarningDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }
            if(!Directory.Exists(txtErrorDir.Text))
            {
                lblErrorDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }
            if(!Directory.Exists(txtScriptDir.Text))
            {
                lblScriptDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }
            if(!LogDirectoryExist)
            {
                MessageBox.Show("Critical Log Directory Not Found.",
                        "Missing Settings", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);       
            }

            checkDbConnection.closeConnection(checkDbConnection) ;                                                
            this.cmdSettingTest.Enabled = true;
            this.cmdSettingSave.Enabled = true;
        }
        
        private void cmdSettingSave_Click(object sender, EventArgs e)
        {
            this.cmdSettingSave.Enabled = false;
            if (!checkAllNeccessaryFields(this.grbCompiere))
            {
                MessageBox.Show("Missing Items Detected. Please Check Again");
                this.cmdSettingSave.Enabled = true;
                return;
            }

            readOrWriteFromXMLfile(false, this.grbCompiere);
            MessageBox.Show("Configuration Saved. Please Restart Application.");
            this.cmdSettingSave.Enabled = true;
        }
                
        private void cmdScriptFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtScriptDir.Clear();
            this.txtScriptDir.Text =
                this.folderBrowserDialog1.SelectedPath;
            this.folderBrowserDialog1.SelectedPath = "";
        }

        private void cmdErrFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtErrorDir.Clear();
            this.txtErrorDir.Text =
                this.folderBrowserDialog1.SelectedPath;
        }

        private void cmdWarningFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtWarningDir.Clear();
            this.txtWarningDir.Text =
                this.folderBrowserDialog1.SelectedPath;
            this.folderBrowserDialog1.SelectedPath = "";

        }

        private void ckIsLDAPAuthenticated_CheckedChanged(object sender, EventArgs e)
        {
            if (this.configureLDAP && this.ckIsLDAPAuthenticated.Checked)
            {
                frmCreateLDAPConnection frmCreateLDAPConnection = new frmCreateLDAPConnection();
                frmCreateLDAPConnection.ShowDialog();
            }
        }



    }
}
