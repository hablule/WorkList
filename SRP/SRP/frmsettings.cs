using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SRP
{
    public partial class frmsettings : Form
    {
        public frmsettings()
        {
            InitializeComponent();
        }

        DataTable dtSettings = new DataTable();
        string xmlFile = dbSettingInformationHandler.settingFilePath;
        DataRow dtRow;
        string[] stInstalledPrinterNameList;

        private void frmsettings_Load(object sender, EventArgs e)
        {            
            this.cmbSRPDataBaseType.SelectedIndex = 1;
            dataBuilder dtBulder = new dataBuilder();

            System.Drawing.Printing.PrinterSettings.StringCollection printersList =
                System.Drawing.Printing.PrinterSettings.InstalledPrinters;

            this.stInstalledPrinterNameList = new string[printersList.Count];
            printersList.CopyTo(this.stInstalledPrinterNameList, 0);

            this.cmbSRPPrinterName.Items.AddRange(this.stInstalledPrinterNameList);
            if(this.cmbSRPPrinterName.Items.Count > 0)
                this.cmbSRPPrinterName.SelectedIndex = 0;

            dtSettings.TableName = "Settings";
            dtSettings.Columns.Add("Parameter_Name");
            dtSettings.Columns.Add("Parameter_Value");
            try
            {
                this.dtSettings.ReadXml(xmlFile);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (!dtBulder.checkIfTableContainesData(dtSettings))
            {
                this.dtSettings.WriteXml(xmlFile);
            }
            else
            {
                this.readOrWriteFromXMLfile(true, this.grbSRP);
            }
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
            return ckState;
        }

        private void readOrWriteFromXMLfile(bool read, GroupBox grpbox)
        {
           if (read)
            {
               dtSettings.Clear(); 
               dtSettings.ReadXml(xmlFile);
                for (int rowCounter = 0;
                    rowCounter < dtSettings.Rows.Count;
                    rowCounter++)
                {
                    string controlName = dtSettings.Rows[rowCounter][0].ToString();
                    if (controlName.Contains("txtSRP"))
                        this.grbSRP.Controls[controlName].Text =
                        dtSettings.Rows[rowCounter][1].ToString();                    
                    else if (controlName.Contains("ckSRP"))
                        this.ckSRPLogChangeScripts.Checked =
                        Convert.ToBoolean(dtSettings.Rows[rowCounter][1].ToString());
                    else if (controlName.Contains("cmbSRPPrinterName"))
                        if (this.cmbSRPPrinterName.Items.Contains(dtSettings.Rows[rowCounter][1].ToString()))
                            this.cmbSRPPrinterName.SelectedItem =
                                dtSettings.Rows[rowCounter][1].ToString();
                }
            }

            else
            {
                
                for (int controlCounter = 0;
                    controlCounter < this.grbSRP.Controls.Count;
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
                            if (rowCounter  >= dtSettings.Rows.Count)
                            {
                                if (grpbox.Controls[controlCounter].GetType().Equals(typeof(TextBox)))
                                {
                                    dtRow = dtSettings.NewRow();
                                    dtRow[0] = controlName;
                                    dtRow[1] = grpbox.Controls[controlName].Text;
                                    dtSettings.Rows.Add(dtRow);
                                }
                                else if (grpbox.Controls[controlCounter].GetType().Equals(typeof(CheckBox)))
                                {
                                    if (controlName.Contains("SRP"))
                                    {
                                        dtRow = dtSettings.NewRow();
                                        dtRow[0] = "ckSRPLogChangeScripts";
                                        dtRow[1] = this.ckSRPLogChangeScripts.Checked;
                                        dtSettings.Rows.Add(dtRow);
                                    }                                   

                                }
                                else if (grpbox.Controls[controlCounter].GetType().Equals(typeof(ComboBox)))
                                {
                                    if (controlName.Contains("SRP"))
                                    {
                                        dtRow = dtSettings.NewRow();
                                        dtRow[0] = controlName;
                                        dtRow[1] = grpbox.Controls[controlName].Text;
                                        dtSettings.Rows.Add(dtRow);
                                    }

                                }
                                break;
                            }
                            else if (dtSettings.Rows[rowCounter][0].ToString() == controlName)
                            {

                                if (grpbox.Controls[controlCounter].GetType().Equals(typeof(CheckBox)))
                                {
                                    // grpbox.Controls[controlCounter] = new CheckBox();
                                    if (controlName.Contains("SRP"))
                                    {
                                        dtSettings.Rows[rowCounter][1] = 
                                            this.ckSRPLogChangeScripts.Checked;
                                    }                                    
                                    break;
                                }
                                dtSettings.Rows[rowCounter][1] = grpbox.Controls[controlName].Text;
                                break;
                            }
                        }
                    }
                }

                dtSettings.WriteXml (xmlFile);               
            }            
        }

        private void cmdSRPSettingTest_Click(object sender, EventArgs e)
        {
            bool LogDirectoryExist = true;
            this.cmdSRPSettingTest.Enabled = false;
            this.cmdSRPSettingSave.Enabled = false;

            if (!checkAllNeccessaryFields(this.grbSRP))
            {
                MessageBox.Show("Missing Items Detected. Please Check Again");
                this.cmdSRPSettingTest.Enabled = true;
                this.cmdSRPSettingSave.Enabled = true;
                return;
            }
            
            if (!Directory.Exists(txtSRPWarningDir.Text))
            {
                lblSRPWarningDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }

            if (!Directory.Exists(txtSRPErrorDir.Text))
            {
                lblSRPErrorDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }
            if (!Directory.Exists(txtSRPScriptDir.Text))
            {
                lblSRPScriptDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }
            if (!LogDirectoryExist)
            {
                MessageBox.Show("Critical Log Directory Not Found.",
                        "Missing Settings", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }

            persistanceClass checkDbConnection =
                new persistanceClass(cmbSRPDataBaseType.SelectedItem.ToString(),
                    txtSRPServerName.Text,
                    txtSRPDataBaseName.Text,
                    txtSRPUserName.Text,
                    txtSRPPassword.Text,
                    txtSRPPort.Text);

            string status = checkDbConnection.connectToDataBase(checkDbConnection);
            if (status == "Open")
            {
                MessageBox.Show("Connection Succeeded");
            }
            else
            {
                MessageBox.Show(status);
            }

            this.cmdSRPSettingTest.Enabled = true;
            this.cmdSRPSettingSave.Enabled = true;

        }

        private void cmdSRPSettingSave_Click(object sender, EventArgs e)
        {
            this.cmdSRPSettingSave.Enabled = false;
            if (!checkAllNeccessaryFields(this.grbSRP))
            {
                MessageBox.Show("Missing Items Detected. Please Check Again");
            }
            else
            {                
                readOrWriteFromXMLfile(false,this.grbSRP);
            }
            this.cmdSRPSettingSave.Enabled = true;
        }

        private void cmdSRPScriptFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtSRPScriptDir.Text = "";
            this.txtSRPScriptDir.Text =
                this.folderBrowserDialog1.SelectedPath;
            this.folderBrowserDialog1.SelectedPath = "";

        }

        private void cmdSRPErrFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtSRPErrorDir.Clear();
            this.txtSRPErrorDir.Text =
                this.folderBrowserDialog1.SelectedPath;
            this.folderBrowserDialog1.SelectedPath = "";
        }

        private void cmdSRPWarningFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtSRPWarningDir.Clear();
            this.txtSRPWarningDir.Text =
                this.folderBrowserDialog1.SelectedPath;
            this.folderBrowserDialog1.SelectedPath = "";
        }  
    }
}
