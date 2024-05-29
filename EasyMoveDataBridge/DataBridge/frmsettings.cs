using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EasyMoveDataBridge
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
            this.cmbCompDataBaseType.SelectedIndex = 0;
            this.cmbEasyMoveDataBaseType.SelectedIndex = 1;
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
                this.readOrWriteFormXMLfile(true, this.grbCompiere);                
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
                    if (controlName.Contains("txtComp"))
                        this.grbCompiere.Controls[controlName].Text =
                        dtSettings.Rows[rowCounter][1].ToString();
                    else if (controlName.Contains("txtEasyMove"))
                        this.grbEasyMove.Controls[controlName].Text =
                        dtSettings.Rows[rowCounter][1].ToString();
                    else if (controlName.Contains("ckComp"))
                    {
                        CheckBox checkBoxControl = (CheckBox)this.grbCompiere.Controls[controlName];
                        checkBoxControl.Checked =
                            Convert.ToBoolean(dtSettings.Rows[rowCounter][1].ToString());
                    }
                    else if (controlName.Contains("ckEasyMove"))
                    {
                        CheckBox checkBoxControl = (CheckBox)this.grbEasyMove.Controls[controlName];
                        checkBoxControl.Checked =
                            Convert.ToBoolean(dtSettings.Rows[rowCounter][1].ToString());
                    }
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
                        grpbox.Controls[controlName].GetType().Equals(typeof(CheckBox)))
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
                                dtSettings.Rows.Add(dtRow);

                                //else if (grpbox.Controls[controlCounter].GetType().Equals(typeof(CheckBox)))
                                //{
                                //    if (controlName.Contains("POS"))
                                //    {
                                //        dtRow = dtSettings.NewRow();
                                //        dtRow[0] = "ckPOSLogChangeScripts";
                                //        dtRow[1] = this.ckPOSLogChangeScripts.Checked;
                                //        dtSettings.Rows.Add(dtRow);
                                //    }
                                //    else
                                //    {
                                //        dtRow = dtSettings.NewRow();
                                //        dtRow[0] = "ckCompLogChangeScripts";
                                //        dtRow[1] = this.ckCompLogChangeScripts.Checked;
                                //        dtSettings.Rows.Add(dtRow);
                                //    }
                                //}
                                break;
                            }
                            else if (dtSettings.Rows[rowCounter][0].ToString() == controlName)
                            {
                                if (grpbox.Controls[controlCounter].GetType().Equals(typeof(CheckBox)))
                                {
                                    CheckBox checkBoxControl = (CheckBox)grpbox.Controls[controlName];
                                    dtSettings.Rows[rowCounter][1] = checkBoxControl.Checked;
                                    //if (controlName.Contains("POS"))
                                    //{
                                    //    dtSettings.Rows[rowCounter][1] = this.ckPOSLogChangeScripts.Checked;
                                    //}
                                    //else
                                    //{
                                    //    dtSettings.Rows[rowCounter][1] = this.ckCompLogChangeScripts.Checked;
                                    //}
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


        private void cmdCompSettingTest_Click(object sender, EventArgs e)
        {
            this.cmdCompSettingTest.Enabled = false;
            this.cmdCompSettingSave.Enabled = false;
            bool LogDirectoryExist = true;
            if (!checkAllNeccessaryFields(this.grbCompiere))
            {
                MessageBox.Show("Missing Items Detected. Please Check Again");
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
                                                
            this.cmdCompSettingTest.Enabled = true;
            this.cmdCompSettingSave.Enabled = true;
        }
                
        private void cmdPOSSettingTest_Click(object sender, EventArgs e)
        {
            bool LogDirectoryExist = true;
            this.cmdEasyMoveSettingTest.Enabled = false;
            this.cmdEasyMoveSettingSave.Enabled = false;

            if (!checkAllNeccessaryFields(this.grbEasyMove))
            {
                MessageBox.Show("Missing Items Detected. Please Check Again");
            }
            
            if (!Directory.Exists(txtEasyMoveWarningDir.Text))
            {
                lblEasyMoveWarningDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }

            if (!Directory.Exists(txtEasyMoveErrorDir.Text))
            {
                lblEasyMoveErrorDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }
            if (!Directory.Exists(txtEasyMoveScriptDir.Text))
            {
                lblEasyMoveScriptDir.ForeColor = Color.Red;
                LogDirectoryExist = false;
            }
            if (!LogDirectoryExist)
            {
                MessageBox.Show("Critical Log Directory Not Found.",
                        "Missing Settings", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }

            persistanceClass checkDbConnection =
                new persistanceClass(cmbEasyMoveDataBaseType.SelectedItem.ToString(),
                    txtEasyMoveServerName.Text,
                    txtEasyMoveDataBaseName.Text,
                    txtEasyMoveUserName.Text,
                    txtEasyMovePassword.Text,
                    txtEasyMovePort.Text);

            string status = checkDbConnection.connectToDataBase(checkDbConnection);
            if (status == "Open")
            {
                MessageBox.Show("Connection Succeeded");
            }
            else
            {
                MessageBox.Show(status);
            }

            this.cmdEasyMoveSettingTest.Enabled = true;
            this.cmdEasyMoveSettingSave.Enabled = true;

        }
        

        private void cmdCompSettingSave_Click(object sender, EventArgs e)
        {
            this.cmdCompSettingSave.Enabled = false;
            if (!checkAllNeccessaryFields(this.grbCompiere))
            {
                MessageBox.Show("Missing Items Detected. Please Check Again");
            }
            else
            {
                readOrWriteFormXMLfile(false,this.grbCompiere);
            }
            this.cmdCompSettingSave.Enabled = true;
        }

        private void cmdPOSSettingSave_Click(object sender, EventArgs e)
        {
            this.cmdEasyMoveSettingSave.Enabled = false;
            if (!checkAllNeccessaryFields(this.grbEasyMove))
            {
                MessageBox.Show("Missing Items Detected. Please Check Again");
            }
            else
            {                
                readOrWriteFormXMLfile(false,this.grbEasyMove);
            }
            this.cmdEasyMoveSettingSave.Enabled = true;
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
            this.folderBrowserDialog1.SelectedPath = "";
        }

        private void cmdCompWarningFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtCompWarningDir.Clear();
            this.txtCompWarningDir.Text =
                this.folderBrowserDialog1.SelectedPath;
            this.folderBrowserDialog1.SelectedPath = "";

        }

        private void cmdPOSScriptFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtEasyMoveScriptDir.Text = "";
            this.txtEasyMoveScriptDir.Text =
                this.folderBrowserDialog1.SelectedPath;
            this.folderBrowserDialog1.SelectedPath = "";

        }

        private void cmdPOSErrFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtEasyMoveErrorDir.Clear();
            this.txtEasyMoveErrorDir.Text =
                this.folderBrowserDialog1.SelectedPath;
            this.folderBrowserDialog1.SelectedPath = "";
        }

        private void cmdPOSWarningFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.txtEasyMoveWarningDir.Clear();
            this.txtEasyMoveWarningDir.Text =
                this.folderBrowserDialog1.SelectedPath;
            this.folderBrowserDialog1.SelectedPath = "";
        }      
           
    }
}
