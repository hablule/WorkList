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

        private void frmsettings_Load(object sender, EventArgs e)
        {
            List<supportedDbList> dbTypeList =
                new List<supportedDbList>((supportedDbList[])Enum.GetValues(typeof(supportedDbList)));
            
            this.cmbDBType.Items.Clear();
            foreach (supportedDbList dbType in dbTypeList)
            {
                this.cmbDBType.Items.Add(dbType.ToString());
            }
            
            this.cmbDBType.SelectedIndex = 0;
            

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
                dtSettings.WriteXml(this.xmlFile);
            }
            else
            {
                this.readOrWriteFromXMLfile(true, this.grbCompiere);
            }

            this.cmbDBType_SelectedIndexChanged(sender, e);
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
                    if (controlName.Contains("txtDB"))
                        this.grbCompiere.Controls[controlName].Text =
                        dtSettings.Rows[rowCounter][1].ToString();
                    else if (controlName.Contains("ckDB"))
                        this.ckDBLogChangeScripts.Checked =
                            Convert.ToBoolean(dtSettings.Rows[rowCounter][1].ToString());
                    if (controlName.Contains("cmbDB"))
                        this.grbCompiere.Controls[controlName].Text =
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
                                if (grpbox.Controls[controlCounter].GetType().Equals(typeof(TextBox)) ||
                                    grpbox.Controls[controlCounter].GetType().Equals(typeof(ComboBox)))
                                {
                                    dtRow = dtSettings.NewRow();
                                    dtRow[0] = controlName;
                                    dtRow[1] = grpbox.Controls[controlName].Text;
                                    dtSettings.Rows.Add(dtRow);
                                }
                                else if (grpbox.Controls[controlCounter].GetType().Equals(typeof(CheckBox)))
                                {
                                      dtRow = dtSettings.NewRow();
                                        dtRow[0] = "ckCompLogChangeScripts";
                                        dtRow[1] = this.ckDBLogChangeScripts.Checked;
                                        dtSettings.Rows.Add(dtRow);

                                }                                
                                break;
                            }
                            else if (dtSettings.Rows[rowCounter][0].ToString() == controlName)
                            {

                                if (grpbox.Controls[controlCounter].GetType().Equals(typeof(CheckBox)))
                                {
                                    dtSettings.Rows[rowCounter][1] = this.ckDBLogChangeScripts.Checked;
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

        private void cmdDBSettingTest_Click(object sender, EventArgs e)
        {
            this.cmdDBSettingTest.Enabled = false;
            this.cmdDBSettingSave.Enabled = false;
            bool LogDirectoryExist = true;
            if (!checkAllNeccessaryFields(this.grbCompiere))
            {
                MessageBox.Show("Missing Items Detected. Please Check Again");
                this.cmdDBSettingTest.Enabled = true;
                this.cmdDBSettingSave.Enabled = true;
                return ;
            }

            persistanceClass checkDbConnection =
                new persistanceClass(cmbDBType.SelectedItem.ToString(),
                    txtDBServerName.Text,
                    txtDBName.Text,
                    txtDBUserName.Text,
                    txtDBPassword.Text,
                    txtDBPort.Text);
            
            string status = checkDbConnection.connectToDataBase(checkDbConnection);
            if (status == "Open")
            {
                MessageBox.Show("Connection Succeeded");
            }
            else
            {
                MessageBox.Show(status);
            }

            if (!Directory.Exists(txtDBWarningDir.Text)) 
            {
                lblDBWarningDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }
            if(!Directory.Exists(txtDBErrorDir.Text))
            {
                lblDBErrorDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }
            if(!Directory.Exists(txtDBScriptDir.Text))
            {
                lblDBScriptDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }
            if(!LogDirectoryExist)
            {
                MessageBox.Show("Critical Log Directory Not Found.",
                        "Missing Settings", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);       
            }

            checkDbConnection.closeConnection(checkDbConnection) ;                                                
            this.cmdDBSettingTest.Enabled = true;
            this.cmdDBSettingSave.Enabled = true;
        }
        
        private void cmdDBSettingSave_Click(object sender, EventArgs e)
        {
            this.cmdDBSettingSave.Enabled = false;
            if (!checkAllNeccessaryFields(this.grbCompiere))
            {
                MessageBox.Show("Missing Items Detected. Please Check Again");
                return;
            }
            else
            {
                readOrWriteFromXMLfile(false,this.grbCompiere);
            }
            this.cmdDBSettingSave.Enabled = true;
        }
                
        private void cmdDBScriptFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtDBScriptDir.Clear();
            this.txtDBScriptDir.Text =
                this.folderBrowserDialog1.SelectedPath;
            this.folderBrowserDialog1.SelectedPath = "";
        }

        private void cmdDBErrFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtDBErrorDir.Clear();
            this.txtDBErrorDir.Text =
                this.folderBrowserDialog1.SelectedPath;
        }

        private void cmdDBWarningFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtDBWarningDir.Clear();
            this.txtDBWarningDir.Text =
                this.folderBrowserDialog1.SelectedPath;
            this.folderBrowserDialog1.SelectedPath = "";

        }

        private void cmbDBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDBType.SelectedItem.ToString() ==
                supportedDbList.MsAccess_2007.ToString())
            {
                this.cmdDataFileLocation.Visible = true;
                this.lblDBName.Text = "Data File";
                this.txtDBName.Enabled = false;                
                this.lblDBPort.Visible = false;
                this.txtDBPort.Visible = false;
                this.txtDBName.Text = "";
                this.txtDBPort.Text = "0";
            }
            else
            {
                this.cmdDataFileLocation.Visible = false;
                this.lblDBName.Text = "DataBase Name";
                this.txtDBName.Enabled = true;
                this.lblDBPort.Visible = true;
                this.txtDBPort.Visible = true;
                this.txtDBName.Text = "";
                this.txtDBPort.Text = "";
            }
        }

        private void cmdDataFileLocation_Click(object sender, EventArgs e)
        {
            this.txtDBName.Text = "";
            this.openFileDialog1.Filter = 
                "Microsoft Office Access 2007 Databases|*.accdb"; ;
            this.openFileDialog1.ShowDialog();            
            this.txtDBName.Text =
                this.openFileDialog1.FileName;
            this.openFileDialog1.FileName = "";
        }

   
    }
}
