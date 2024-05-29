using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SRP
{
    public partial class frmFormAccess : Panel
    {
        public frmFormAccess()
        {
            InitializeComponent();
        }


        bool isNewRecord = false;

        int intCurrentShopId = -1;
        int intCurrentUserId = -1;        

        Color clNormalLableColor = Color.Black;
        Color clErrorLableColor = Color.Red;
        Color clChangedLableColor = Color.Blue;

        DataTable dtActiveshopList = new DataTable();
        DataTable dtActiveUserList = new DataTable();        

        string[] stActiveShopName;
        string[] stActiveUserName;        

        DataTable dtExistingFormAccess = new DataTable();
        DataTable dtNewFormAccess = new DataTable();

        dataBuilder getDatafromDataBase = new dataBuilder();

        private void completeExistingFormAccessInfo()
        {
            DataTable dtFormAccessLinkedInfo = new DataTable();
            for (int rowCounter = 0; rowCounter <= this.dtExistingFormAccess.Rows.Count - 1; rowCounter++)
            {
                dtFormAccessLinkedInfo =
                    this.getDatafromDataBase.getU_USERInfo(null, "",
                            this.dtExistingFormAccess.Rows[rowCounter]["U_USER_ID"].ToString(),
                            "", "", "", triStateBool.ignor, false, "AND");
                if (dtFormAccessLinkedInfo.Rows.Count >= 1)
                    this.dtExistingFormAccess.Rows[rowCounter]["User"] =
                        dtFormAccessLinkedInfo.Rows[0]["USERNAME"].ToString();

                dtFormAccessLinkedInfo =
                    this.getDatafromDataBase.getM_SHOPInfo(null, "",
                        this.dtExistingFormAccess.Rows[rowCounter]["M_SHOP_ID"].ToString(),
                        "", triStateBool.ignor, false, "AND");

                if (dtFormAccessLinkedInfo.Rows.Count >= 1)
                    this.dtExistingFormAccess.Rows[rowCounter]["Shop"] =
                        dtFormAccessLinkedInfo.Rows[0]["NAME"].ToString();                
            }
        }

        private void setGridControlData()
        {
            this.dtExistingFormAccess.Columns.Add("Shop");
            this.dtExistingFormAccess.Columns.Add("User");            

            this.dtExistingFormAccess.Columns["Shop"].SetOrdinal(0);
            this.dtExistingFormAccess.Columns["User"].SetOrdinal(1);
            
            this.completeExistingFormAccessInfo();

            this.dtgFormAccessGridView.DataSource = this.dtExistingFormAccess;

            this.dtgFormAccessGridView.Columns["M_SHOP_ID"].Visible = false;
            this.dtgFormAccessGridView.Columns["U_USER_ID"].Visible = false;            
            this.dtgFormAccessGridView.Columns["CREATED"].Visible = false;
            this.dtgFormAccessGridView.Columns["CREATEDBY"].Visible = false;
            this.dtgFormAccessGridView.Columns["UPDATED"].Visible = false;
            this.dtgFormAccessGridView.Columns["UPDATEDBY"].Visible = false;
            this.dtgFormAccessGridView.Columns["DESCRIPTION"].Visible = false;
        }

        private bool checkForCompleteNewRecord()
        {
            bool foundError = false;

            if (this.intCurrentShopId == -1)
            {
                this.lblStation.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblStation.ForeColor = clNormalLableColor;
            }

            if (this.intCurrentUserId == -1)
            {
                this.lblUser.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblUser.ForeColor = clNormalLableColor;
            }

            if (this.cmbFormItemList.SelectedIndex == 0)
            {
                this.lblFormName.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblFormName.ForeColor = clNormalLableColor;
            }

            if (this.cmbAccessLevel.SelectedIndex == 0)
            {
                this.lblAccessLevel.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblAccessLevel.ForeColor = clNormalLableColor;
            }

            return foundError;
        }



        public void frmFormAccess_Load(object sender, EventArgs e)
        {
            if (generalResultInformation.currentFormIsReadOnly)
            {
                this.tlsDelete.Visible = false;
                this.tlsNew.Visible = false;
                this.tlsSave.Visible = false;
            }

            this.cmbFormItemList.Items.Clear();
            this.cmbFormItemList.Items.Add("-Select Form-");
            this.cmbFormItemList.Items.AddRange(generalResultInformation.formNameList);
            this.tlsNew_Click(sender, e);

            this.dtExistingFormAccess =
                this.getDatafromDataBase.getU_FORMACCESS(null, "",
                    "", "", "",accessLevel.ignor, triStateBool.ignor, true, "");

            this.dtActiveshopList =
                this.getDatafromDataBase.getM_SHOPInfo(null, "",
                    "", "", triStateBool.yes, false, "AND");

            this.stActiveShopName =
                    new string[this.dtActiveshopList.Rows.Count + 1];
            this.stActiveShopName[0] = " - Select Shop - ";

            if (this.dtActiveshopList.Rows.Count >= 1)
            {
                for (int rowCounter = 0;
                    rowCounter <= this.dtActiveshopList.Rows.Count - 1;
                    rowCounter++)
                {
                    this.stActiveShopName[rowCounter + 1] =
                        this.dtActiveshopList.Rows[rowCounter]["NAME"].ToString();
                }
            }

            this.dtActiveUserList =
                this.getDatafromDataBase.getU_USERInfo(null, "",
                    "", "", "", "", triStateBool.yes, false, "AND");

            this.stActiveUserName =
                new string[this.dtActiveUserList.Rows.Count + 1];
            this.stActiveUserName[0] = " - Select User - ";

            if (this.dtActiveUserList.Rows.Count >= 1)
            {
                for (int rowCounter = 0;
                    rowCounter <= this.dtActiveUserList.Rows.Count - 1;
                    rowCounter++)
                {
                    this.stActiveUserName[rowCounter + 1] =
                        this.dtActiveUserList.Rows[rowCounter]["USERNAME"].ToString();
                }
            }            

            this.cmbStationList_DropDown(sender, e);
            this.cmbUserList_DropDown(sender, e);

            this.setGridControlData();
        }

        private void tlsNew_Click(object sender, EventArgs e)
        {
            this.isNewRecord = true;

            this.intCurrentShopId = -1;
            this.intCurrentUserId = -1;

            if (this.cmbAccessLevel.Items.Count > 0)
                this.cmbAccessLevel.SelectedIndex = 0;
            if (this.cmbFormItemList.Items.Count > 0)
                this.cmbFormItemList.SelectedIndex = 0;
            
            this.cmbStationList_DropDown(sender, e);
            this.cmbUserList_DropDown(sender, e);            

            this.txtDescription.Text = "";            
        }

        private void tlsSave_Click(object sender, EventArgs e)
        {
            if (this.checkForCompleteNewRecord())
            {
                MessageBox.Show("Please complete the missing form element before proceeding.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string stTypeOfChange = "INSERT";

            this.dtNewFormAccess =
                 this.getDatafromDataBase.getU_FORMACCESS(null, "",
                    this.intCurrentShopId.ToString(), this.intCurrentUserId.ToString(),
                    this.cmbFormItemList.SelectedItem.ToString(),accessLevel.ignor, 
                    triStateBool.ignor, false, "AND");

            if (!this.isNewRecord || this.dtNewFormAccess.Rows.Count >= 1)
                stTypeOfChange = "UPDATE";

            DataRow drNewFormAccess = this.dtNewFormAccess.NewRow();

            drNewFormAccess["M_SHOP_ID"] = this.intCurrentShopId;
            drNewFormAccess["U_USER_ID"] = this.intCurrentUserId;
            drNewFormAccess["FORMNAME"] = this.cmbFormItemList.SelectedItem.ToString();
            drNewFormAccess["ACCESSLEVEL"] = this.cmbAccessLevel.SelectedItem.ToString();
            drNewFormAccess["DESCRIPTION"] = this.txtDescription.Text;

            this.dtNewFormAccess.Rows.Add(drNewFormAccess);

            string[] primaryKeySepartor = { " <(", ")>||" };
            string[] primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                    (this.dtNewFormAccess, "U_FORMACCESS", stTypeOfChange)[0]
                    .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            this.dtExistingFormAccess =
                this.getDatafromDataBase.getU_FORMACCESS(null, "",
                    "", "", "",accessLevel.ignor, triStateBool.ignor, false, "");
            this.setGridControlData();
            if (this.dtExistingFormAccess.Rows.Count >= 1)
                this.dtgFormAccessGridView.
                    Rows[this.dtgFormAccessGridView.Rows.Count - 1].Selected = true;
        }

        private void tlsDelete_Click(object sender, EventArgs e)
        {
            this.dtNewFormAccess =
                 this.getDatafromDataBase.getU_FORMACCESS(null, "",
                    this.intCurrentShopId.ToString(), this.intCurrentUserId.ToString(),
                    this.cmbFormItemList.SelectedItem.ToString(),accessLevel.ignor,
                    triStateBool.ignor, false, "AND");

            if (this.checkForCompleteNewRecord())
            {
                return;
            }

            string stTypeOfChange = "DELETE";

            

            this.getDatafromDataBase.changeDataBaseTableData
                    (this.dtNewFormAccess, "U_FORMACCESS", stTypeOfChange);

            this.dtExistingFormAccess =
                this.getDatafromDataBase.getU_FORMACCESS(null, "",
                    "", "", "",accessLevel.ignor, triStateBool.ignor, false, "");
            this.setGridControlData();
            if (this.dtExistingFormAccess.Rows.Count >= 1)
                this.dtgFormAccessGridView.
                    Rows[this.dtgFormAccessGridView.Rows.Count - 1].Selected = true;
            else
                this.tlsNew_Click(sender, e);
        }

        private void tlsSearch_Click(object sender, EventArgs e)
        {
            this.dtExistingFormAccess =
                this.getDatafromDataBase.getU_FORMACCESS(null, "",
                    "", "", "",accessLevel.ignor, triStateBool.ignor, false, "");
            this.setGridControlData();
            if (this.dtExistingFormAccess.Rows.Count >= 1)
                this.dtgFormAccessGridView.Rows[0].Selected = true;
        }


        private void cmbStationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbStationList.SelectedIndex > 0)
                this.intCurrentShopId =
                    int.Parse(this.dtActiveshopList.
                                Rows[this.cmbStationList.SelectedIndex - 1]["M_SHOP_ID"].
                                ToString());
            else
                this.intCurrentShopId = -1;
        }

        private void cmbUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbUserList.SelectedIndex > 0)
                this.intCurrentUserId =
                    int.Parse(this.dtActiveUserList.
                                Rows[this.cmbUserList.SelectedIndex - 1]["U_USER_ID"].
                                ToString());
            else
                this.intCurrentUserId = -1;
        }

        private void cmbStationList_DropDown(object sender, EventArgs e)
        {
            this.cmbStationList.Items.Clear();
            if (this.stActiveShopName != null)
            {
                this.cmbStationList.Items.AddRange(this.stActiveShopName);
                this.cmbStationList.SelectedIndex = 0;
            }
        }

        private void cmbUserList_DropDown(object sender, EventArgs e)
        {
            this.cmbUserList.Items.Clear();
            if (this.stActiveUserName != null)
            {
                this.cmbUserList.Items.AddRange(this.stActiveUserName);
                this.cmbUserList.SelectedIndex = 0;
            }
        }


        private void dtgFormAccessGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgFormAccessGridView.SelectedRows.Count < 1)
            {
                return;
            }

            int selectedFormAccessIndex =
                this.dtgFormAccessGridView.SelectedRows[0].Index;

            this.cmbStationList.SelectedIndex = 0;
            for (int rowCounter = 0;
                rowCounter <= this.dtActiveshopList.Rows.Count - 1; rowCounter++)
            {
                if (this.dtgFormAccessGridView.
                        Rows[selectedFormAccessIndex].
                                Cells["M_SHOP_ID"].Value.ToString() ==
                            this.dtActiveshopList.Rows[rowCounter]["M_SHOP_ID"].ToString())
                {
                    this.cmbStationList.SelectedIndex = rowCounter + 1;
                    break;
                }
            }

            this.cmbUserList.SelectedIndex = 0;
            for (int rowCounter = 0;
                rowCounter <= this.dtActiveUserList.Rows.Count - 1; rowCounter++)
            {
                if (this.dtgFormAccessGridView.
                        Rows[selectedFormAccessIndex].
                                Cells["U_USER_ID"].Value.ToString() ==
                            this.dtActiveUserList.Rows[rowCounter]["U_USER_ID"].ToString())
                {
                    this.cmbUserList.SelectedIndex = rowCounter + 1;
                    break;
                }
            }
                        
            int indexOfAccessLevel =
                this.cmbAccessLevel.Items.IndexOf(
                        this.dtgFormAccessGridView.Rows[selectedFormAccessIndex].
                            Cells["ACCESSLEVEL"].Value.ToString());

            if (indexOfAccessLevel >= 0 && 
                indexOfAccessLevel <= this.cmbAccessLevel.Items.Count)
            {
                this.cmbAccessLevel.SelectedIndex = indexOfAccessLevel;
            }
            else
                this.cmbAccessLevel.SelectedIndex = 0;


            int indexOfFormList =
                this.cmbFormItemList.Items.IndexOf(
                        this.dtgFormAccessGridView.Rows[selectedFormAccessIndex].
                            Cells["FORMNAME"].Value.ToString());

            if (indexOfFormList >= 0 &&
                indexOfFormList <= this.cmbFormItemList.Items.Count)
            {
                this.cmbFormItemList.SelectedIndex = indexOfFormList;
            }
            else
                this.cmbFormItemList.SelectedIndex = 0;
            this.txtDescription.Text =
                this.dtgFormAccessGridView.Rows[selectedFormAccessIndex].
                            Cells["DESCRIPTION"].Value.ToString();

        }
        
    }
}
