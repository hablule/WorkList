using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace POSDocumentPrinter
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
            this.cmbPOSDataBaseType.SelectedIndex = 1;

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
                dtSettings.ReadXml(xmlFile);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (!dtBulder.checkIfTableContainesData(dtSettings))
            {
                dtSettings.WriteXml(xmlFile);
            }
            else
            {                
                this.readOrWriteFormXMLfile(true, this.grbPOS);                
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

        private void readOrWriteFormXMLfile(bool read, GroupBox grpbox)
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
                    if (controlName.Contains("txtPOS"))
                        this.grbPOS.Controls[controlName].Text =
                        dtSettings.Rows[rowCounter][1].ToString();                    
                    else if (controlName.Contains("ckPOS"))
                    {
                        CheckBox checkBoxControl = (CheckBox)this.grbPOS.Controls[controlName];
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

                dtSettings.WriteXml (xmlFile);               
            }            
        }

                
        private void cmdPOSSettingTest_Click(object sender, EventArgs e)
        {
            bool LogDirectoryExist = true;
            this.cmdPOSSettingTest.Enabled = false;
            this.cmdPOSSettingSave.Enabled = false;

            if (!checkAllNeccessaryFields(this.grbPOS))
            {
                MessageBox.Show("Missing Items Detected. Please Check Again");
            }
            
            if (!Directory.Exists(txtPOSWarningDir.Text))
            {
                lblPOSWarningDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }

            if (!Directory.Exists(txtPOSErrorDir.Text))
            {
                lblPOSErrorDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }
            if (!Directory.Exists(txtPOSScriptDir.Text))
            {
                lblPOSScriptDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }
            if (!LogDirectoryExist)
            {
                MessageBox.Show("Critical Log Directory Not Found.",
                        "Missing Settings", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }

            persistanceClass checkDbConnection =
                new persistanceClass(cmbPOSDataBaseType.SelectedItem.ToString(),
                    txtPOSServerName.Text,
                    txtPOSDataBaseName.Text,
                    txtPOSUserName.Text,
                    txtPOSPassword.Text,
                    txtPOSPort.Text);

            string status = checkDbConnection.connectToDataBase(checkDbConnection);
            if (status == "Open")
            {
                MessageBox.Show("Connection Succeeded");
            }
            else
            {
                MessageBox.Show(status);
            }

            this.cmdPOSSettingTest.Enabled = true;
            this.cmdPOSSettingSave.Enabled = true;

        }
        
        private void cmdPOSSettingSave_Click(object sender, EventArgs e)
        {
            this.cmdPOSSettingSave.Enabled = false;
            if (!checkAllNeccessaryFields(this.grbPOS))
            {
                MessageBox.Show("Missing Items Detected. Please Check Again");
            }
            else
            {                
                readOrWriteFormXMLfile(false,this.grbPOS);
            }
            this.cmdPOSSettingSave.Enabled = true;
        }


        private void cmdPOSScriptFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtPOSScriptDir.Text = "";
            this.txtPOSScriptDir.Text =
                this.folderBrowserDialog1.SelectedPath;
            this.folderBrowserDialog1.SelectedPath = "";

        }

        private void cmdPOSErrFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtPOSErrorDir.Clear();
            this.txtPOSErrorDir.Text =
                this.folderBrowserDialog1.SelectedPath;
            this.folderBrowserDialog1.SelectedPath = "";
        }

        private void cmdPOSWarningFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtPOSWarningDir.Clear();
            this.txtPOSWarningDir.Text =
                this.folderBrowserDialog1.SelectedPath;
            this.folderBrowserDialog1.SelectedPath = "";
        }      
           
    }
}
