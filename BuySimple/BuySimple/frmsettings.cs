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


        private void frmsettings_Load(object sender, EventArgs e)
        {
            this.cmbCompDataBaseType.SelectedIndex = 0;

            System.Drawing.Printing.PrinterSettings.StringCollection printersList =
                System.Drawing.Printing.PrinterSettings.InstalledPrinters;

            this.stInstalledPrinterNameList = new string[printersList.Count];
            printersList.CopyTo(this.stInstalledPrinterNameList, 0);

            this.cmbPOSPrinterNameList.Items.AddRange(this.stInstalledPrinterNameList);
            if (this.cmbPOSPrinterNameList.Items.Count > 0)
                this.cmbPOSPrinterNameList.SelectedIndex = 0;


            dataBuilder dtBulder = new dataBuilder();
            dtSettings.TableName = "Settings";
            dtSettings.Columns.Add("Parameter_Name");
            dtSettings.Columns.Add("Parameter_Value");
            try
            {
                dtSettings = 
                    new businessRule().readEncryptedXmlSettingFile(xmlFile);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (!dtBulder.checkIfTableContainesData(dtSettings))
            {
                new businessRule().writeDatatableToEncryptedXmlSettingFile(dtSettings, this.xmlFile);
            }
            else
            {
                this.readOrWriteFormXMLfile(true, this.grbCompiere);
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

            if (this.ckCompIsLDAPAuthenticated.Checked)
            {
                LDAPConnection tstConnection = new LDAPConnection();
                generalResultInformation.LDAPConnectionSet = tstConnection.authenticateConnection();
                if (!generalResultInformation.LDAPConnectionSet)
                {
                    MessageBox.Show("LDAP Not cofigured properly. Please Configure LADP or Uncheck 'LDAP Authenticated' Check box");
                    this.ckCompIsLDAPAuthenticated.ForeColor = Color.Red;

                    ckState = false;
                }
                else
                {
                    this.ckCompIsLDAPAuthenticated.ForeColor = Color.Black;
                }
            }
            else
            {
                this.ckCompIsLDAPAuthenticated.ForeColor = Color.Black;
            }

            return ckState;
        }

        private void readOrWriteFormXMLfile(bool read, GroupBox grpbox)
        {
            if (read)
            {
                dtSettings.Clear();
                dtSettings = 
                    new businessRule().readEncryptedXmlSettingFile(xmlFile);

                for (int rowCounter = 0;
                    rowCounter < dtSettings.Rows.Count;
                    rowCounter++)
                {
                    string controlName = dtSettings.Rows[rowCounter][0].ToString();
                    if (controlName.Contains("txtComp"))
                        this.grbCompiere.Controls[controlName].Text =
                        dtSettings.Rows[rowCounter][1].ToString();
                    else if (controlName.Contains("ckComp"))
                    {
                        CheckBox checkBoxControl = (CheckBox)this.grbCompiere.Controls[controlName];
                        checkBoxControl.Checked =
                            Convert.ToBoolean(dtSettings.Rows[rowCounter][1].ToString());
                    }
                    else if (controlName.Contains("cmbPOSPrinterNameList"))
                        if (this.cmbPOSPrinterNameList.Items.Contains(dtSettings.Rows[rowCounter][1].ToString()))
                            this.cmbPOSPrinterNameList.SelectedItem =
                                dtSettings.Rows[rowCounter][1].ToString();
                }
            }
            else
            {

                for (int controlCounter = 0;
                    controlCounter < grpbox.Controls.Count;
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
                            if (rowCounter >= dtSettings.Rows.Count)
                            {
                                dtRow = dtSettings.NewRow();
                                dtRow[0] = controlName;
                                if (grpbox.Controls[controlCounter].GetType().Equals(typeof(TextBox)))
                                {
                                    dtRow[1] = grpbox.Controls[controlName].Text;
                                }
                                else if (grpbox.Controls[controlCounter].GetType().Equals(typeof(CheckBox)))
                                {
                                    CheckBox checkBoxControl = (CheckBox)grpbox.Controls[controlName];
                                    dtRow[1] = checkBoxControl.Checked;
                                }
                                else if (grpbox.Controls[controlCounter].GetType().Equals(typeof(ComboBox)))
                                {
                                    if (controlName.Contains("POS"))
                                    {
                                        dtRow[1] = grpbox.Controls[controlName].Text;
                                    }
                                }
                                dtSettings.Rows.Add(dtRow);
                                break;
                            }
                            else if (dtSettings.Rows[rowCounter][0].ToString() == controlName)
                            {
                                if (grpbox.Controls[controlCounter].GetType().Equals(typeof(CheckBox)))
                                {
                                    CheckBox checkBoxControl = (CheckBox)grpbox.Controls[controlName];
                                    dtSettings.Rows[rowCounter][1] = checkBoxControl.Checked;
                                    break;
                                }
                                dtSettings.Rows[rowCounter][1] = grpbox.Controls[controlName].Text;
                                break;
                            }
                        }
                    }
                }

                new businessRule().writeDatatableToEncryptedXmlSettingFile(dtSettings, xmlFile);
            }
        }


        private void cmdCompSettingTest_Click(object sender, EventArgs e)
        {
            this.cmdCompSettingTest.Enabled = false;
            this.cmdCompSettingSave.Enabled = false;
            bool LogDirectoryExist = true;
            if (!checkAllNeccessaryFields(this.grbCompiere))
            {
                MessageBox.Show("Missing Items Detected. Please Check Again");
                this.cmdCompSettingTest.Enabled = true;
                this.cmdCompSettingSave.Enabled = true;
                return ;
            }

            persistanceClass checkDbConnection =
                new persistanceClass(cmbCompDataBaseType.SelectedItem.ToString(),
                    txtCompServerName.Text,
                    txtCompDataBaseName.Text,
                    txtCompUserName.Text,
                    txtCompPassword.Text,
                    txtCompPort.Text);
            
            string status = checkDbConnection.connectToDataBase(checkDbConnection);
            if (status == "Open")
            {
                MessageBox.Show("Connection Succeeded");
            }
            else
            {
                MessageBox.Show(status);
            }

            if (!Directory.Exists(txtCompWarningDir.Text)) 
            {
                lblCompWarningDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }
            if(!Directory.Exists(txtCompErrorDir.Text))
            {
                lblCompErrorDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }
            if(!Directory.Exists(txtCompScriptDir.Text))
            {
                lblCompScriptDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }
            if(!LogDirectoryExist)
            {
                MessageBox.Show("Critical Log Directory Not Found.",
                        "Missing Settings", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);       
            }

            checkDbConnection.closeConnection(checkDbConnection) ;                                                
            this.cmdCompSettingTest.Enabled = true;
            this.cmdCompSettingSave.Enabled = true;
        }
        
        private void cmdCompSettingSave_Click(object sender, EventArgs e)
        {
            this.cmdCompSettingSave.Enabled = false;
            if (!checkAllNeccessaryFields(this.grbCompiere))
            {
                MessageBox.Show("Missing Items Detected. Please Check Again");
                this.cmdCompSettingSave.Enabled = true;
                return;
            }

            readOrWriteFormXMLfile(false, this.grbCompiere);
            MessageBox.Show("Configuration Saved. Please Restart Application.");
            this.cmdCompSettingSave.Enabled = true;
        }
                
        private void cmdCompScriptFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtCompScriptDir.Clear();
            this.txtCompScriptDir.Text =
                this.folderBrowserDialog1.SelectedPath;
            this.folderBrowserDialog1.SelectedPath = "";
        }

        private void cmdCompErrFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtCompErrorDir.Clear();
            this.txtCompErrorDir.Text =
                this.folderBrowserDialog1.SelectedPath;
        }

        private void cmdCompWarningFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtCompWarningDir.Clear();
            this.txtCompWarningDir.Text =
                this.folderBrowserDialog1.SelectedPath;
            this.folderBrowserDialog1.SelectedPath = "";

        }

        private void ckIsLDAPAuthenticated_CheckedChanged(object sender, EventArgs e)
        {
            if (this.configureLDAP && this.ckCompIsLDAPAuthenticated.Checked)
            {
                frmCreateLDAPConnection frmCreateLDAPConnection = new frmCreateLDAPConnection();
                frmCreateLDAPConnection.ShowDialog();
            }
        }
   
    }
}
