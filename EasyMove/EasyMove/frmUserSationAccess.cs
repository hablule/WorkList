using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyMove
{
    public partial class frmUserSationAccess : Form
    {
        public frmUserSationAccess()
        {
            InitializeComponent();
        }

        DataTable dtAllUserNames = new DataTable();
        DataTable dtAllStations = new DataTable();

        dataBuilder getDataFromDb = new dataBuilder();

        private void insetDataIntoComboBox(ComboBox _comboBoxContorl, DataTable dataSourceTable,
            int columnIndexToFeed, int selectedIndex)
        {
            int arraySize = dataSourceTable.Rows.Count;
            string[] arrayItems = new string[arraySize];
            string[] tempArray = { "" };
            if (!getDataFromDb.checkIfTableContainesData(dataSourceTable))
                return;

            if (!dataSourceTable.Columns.Contains("_Index"))
            {
                dataSourceTable.Columns.Add("_Index", System.Type.GetType("System.Int16"));

                for (int rowCounter = 0; rowCounter < dataSourceTable.Rows.Count; rowCounter++)
                {
                    dataSourceTable.Rows[rowCounter]["_Index"] = rowCounter;
                    //tempArray[0] = dataSourceTable.Rows[rowCounter][columnIndexToFeed].ToString();
                    //Array.Copy(tempArray, 0, arrayItems, rowCounter, 1);
                }
            }

            for (int rowCounter = 0; rowCounter < dataSourceTable.Rows.Count; rowCounter++)
            {
                arrayItems[rowCounter] = dataSourceTable.Rows[rowCounter][columnIndexToFeed].ToString();
                //Array.Copy(tempArray, 0, arrayItems, rowCounter, 1);
            }
            _comboBoxContorl.Items.AddRange(arrayItems);

            if (selectedIndex >= 0 &&
                selectedIndex < _comboBoxContorl.Items.Count)
                _comboBoxContorl.SelectedIndex = selectedIndex;
        }

        private void enableSetAccessButton()
        {
            if ((this.ddgUserName.SelectedRowKey != null) || (this.cmbStations.SelectedIndex >= 0 &&
                     this.cmbStations.SelectedIndex <= this.cmbStations.Items.Count - 1))
                this.cmdSetUserSationAccess.Enabled = true;
            else
                this.cmdSetUserSationAccess.Enabled = false;
        }

        private void frmUserSationAccess_Load(object sender, EventArgs e)
        {
            this.dtAllStations =
                this.getDataFromDb.getEM_STATIONInfo(null, "", "", true, false, "AND");
            DataRow drSation = this.dtAllStations.NewRow();

            drSation["EM_STATION_ID"] = generalResultInformation.allStationRepresentativeKey;
            drSation["ISACTIVE"] = 'Y';
            drSation["CREATEDBY"] = 1000000;
            drSation["UPDATEDBY"] = 1000000;
            drSation["VALUE"] = "*";
            drSation["NAME"] = "*";

            this.dtAllStations.Rows.InsertAt(drSation, 0);
            
            this.insetDataIntoComboBox(this.cmbStations, this.dtAllStations,
                                        this.dtAllStations.Columns.IndexOf("NAME"), 0);
            this.cmdSetUserSationAccess.Enabled = false;
        }

        private void cmdSetUserSationAccess_Click(object sender, EventArgs e)
        {
            DataTable userStatiionAccess =
                this.getDataFromDb.getEM_USER_STATIONACCESSInfo(null, "",
                                this.dtAllStations.Rows[this.cmbStations.SelectedIndex]["EM_STATION_ID"].ToString(),
                                this.ddgUserName.SelectedRowKey.ToString(), false, false, "AND");
            if (!getDataFromDb.checkIfTableContainesData(userStatiionAccess))
            {
                DataRow newUserStationAccess = userStatiionAccess.NewRow();

                newUserStationAccess["AD_USER_ID"] = 
                    this.ddgUserName.SelectedRowKey.ToString();
                newUserStationAccess["EM_STATION_ID"] =
                    this.dtAllStations.Rows[this.cmbStations.SelectedIndex]["EM_STATION_ID"].ToString();
                if(this.ckIsActive.Checked)
                    newUserStationAccess["ISACTIVE"] = "Y";
                else
                    newUserStationAccess["ISACTIVE"] = "N";

                newUserStationAccess["CREATEDBY"] = 
                    generalResultInformation.userId;
                newUserStationAccess["UPDATEDBY"] =
                    generalResultInformation.userId;
                if(this.ckIsReadOnlyAccess.Checked)
                    newUserStationAccess["ISREADONLY"] = "Y";
                else
                    newUserStationAccess["ISREADONLY"] = "N";

                userStatiionAccess.Rows.Add(newUserStationAccess);
                this.getDataFromDb.changeDataBaseTableData(userStatiionAccess,"EM_USER_STATIONACCESS", "INSERT");

            }
            else
            {
                if(this.ckIsActive.Checked)
                    userStatiionAccess.Rows[0]["ISACTIVE"] = "Y";
                else
                    userStatiionAccess.Rows[0]["ISACTIVE"] = "N";

                if(this.ckIsReadOnlyAccess.Checked)
                    userStatiionAccess.Rows[0]["ISREADONLY"] = "Y";
                else
                    userStatiionAccess.Rows[0]["ISREADONLY"] = "N";
                this.getDataFromDb.changeDataBaseTableData(userStatiionAccess, "EM_USER_STATIONACCESS", "UPDATE");
            }
        }
        
        private void ddgUserName_selectedItemChanged(object sender, EventArgs e)
        {
            this.enableSetAccessButton();
        }

        private void ddgUserName_SelectedItemClicked(object sender, EventArgs e)
        {
            this.dtAllUserNames =
               this.getDataFromDb.getEM_AD_USERInfo(null, "", "", "", "", true, false, "AND");

            this.ddgUserName.DataSource = this.dtAllUserNames;
            this.ddgUserName.HiddenColoumns = new int[]{this.dtAllUserNames.Columns.IndexOf("AD_CLIENT_ID"),
                                                        this.dtAllUserNames.Columns.IndexOf("AD_ORG_ID"),
                                                        this.dtAllUserNames.Columns.IndexOf("ISACTIVE"),
                                                        this.dtAllUserNames.Columns.IndexOf("CREATED"),
                                                        this.dtAllUserNames.Columns.IndexOf("CREATEDBY"),
                                                        this.dtAllUserNames.Columns.IndexOf("UPDATED"),
                                                        this.dtAllUserNames.Columns.IndexOf("UPDATEDBY"),
                                                        this.dtAllUserNames.Columns.IndexOf("PASSWORD")};
            this.ddgUserName.SelectedColomnIdex = this.dtAllUserNames.Columns.IndexOf("NAME");
            this.ddgUserName.DataTablePrimaryKey =
                 Convert.ToUInt16(this.dtAllUserNames.Columns.IndexOf("AD_USER_ID"));

        }

        private void ckIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckIsActive.Checked)
                this.ckIsReadOnlyAccess.Enabled = true;
            else
            {
                this.ckIsReadOnlyAccess.Enabled = false;
                this.ckIsReadOnlyAccess.Checked = false;
            }
        }

        private void cmbStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableSetAccessButton();
        }
        
    }
}
