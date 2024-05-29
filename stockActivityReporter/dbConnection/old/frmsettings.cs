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

        DataTable dtSettings = new DataTable();
        string xmlFile = dbSettingInformationHandler.settingFilePath;
        DataRow dtRow;
        string[] stInstalledPrinterNameList;

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


            dtSettings.TableName = "Settings";
            dtSettings.Columns.Add("Parameter_Name");
            dtSettings.Columns.Add("Parameter_Value");
            try
            {
                dtSettings.ReadXml(xmlFile);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (!dtBulder.checkIfTableContainesData(dtSettings))
            {
                dtSettings.WriteXml(this.xmlFile);
            }
            else
            {
                this.readOrWriteFromXMLfile(true, this.grbCompiere);
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
                    if (controlName.Contains("txt"))
                        this.grbCompiere.Controls[controlName].Text =
                        dtSettings.Rows[rowCounter][1].ToString();
                    else if (controlName.Contains("ck"))
                        this.ckLogChangeScripts.Checked =
                            Convert.ToBoolean(dtSettings.Rows[rowCounter][1].ToString());
                    else if (controlName.Contains("cmbPrinterName"))
                        if (this.cmbPrinterName.Items.Contains(dtSettings.Rows[rowCounter][1].ToString()))
                            this.cmbPrinterName.SelectedItem =
                                dtSettings.Rows[rowCounter][1].ToString();
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
                                      dtRow = dtSettings.NewRow();
                                        dtRow[0] = "ckLogChangeScripts";
                                        dtRow[1] = this.ckLogChangeScripts.Checked;
                                        dtSettings.Rows.Add(dtRow);

                                }
                                else if (grpbox.Controls[controlCounter].GetType().Equals(typeof(ComboBox)))
                                {
                                    dtRow = dtSettings.NewRow();
                                    dtRow[0] = controlName;
                                    dtRow[1] = grpbox.Controls[controlName].Text;
                                    dtSettings.Rows.Add(dtRow);
                                }
                                break;
                            }
                            else if (dtSettings.Rows[rowCounter][0].ToString() == controlName)
                            {

                                if (grpbox.Controls[controlCounter].GetType().Equals(typeof(CheckBox)))
                                {
                                    dtSettings.Rows[rowCounter][1] = this.ckLogChangeScripts.Checked;
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

        private void cmdSettingTest_Click(object sender, EventArgs e)
        {
            this.cmdSettingTest.Enabled = false;
            this.cmdSettingSave.Enabled = false;
            bool LogDirectoryExist = true;
            if (!checkAllNeccessaryFields(this.grbCompiere))
            {
                MessageBox.Show("Missing Items Detected. Please Check Again");
                return ;
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
                return;
            }
            else
            {
                readOrWriteFromXMLfile(false,this.grbCompiere);
            }
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

    }
}
