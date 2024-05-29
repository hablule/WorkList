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
    public partial class frmOrganisationAccess : Panel
    {
        public frmOrganisationAccess()
        {
            InitializeComponent();
        }

        bool isNewRecord = false;

        int intCurrentShopId = -1;
        int intCurrentUserId = -1;
        int intCurrentOrganisationId = -1;

        Color clNormalLableColor = Color.Black;
        Color clErrorLableColor = Color.Red;
        Color clChangedLableColor = Color.Blue;

        DataTable dtActiveshopList = new DataTable();
        DataTable dtActiveUserList = new DataTable();
        DataTable dtActiveOrganisationList = new DataTable();

        string[] stActiveShopName;
        string[] stActiveUserName;
        string[] stActiveOrganisations;

        DataTable dtExistingOrganisationAccess = new DataTable();
        DataTable dtNewOrganisationAccess = new DataTable();

        dataBuilder getDatafromDataBase = new dataBuilder();

        private void completeExistingOrganisationAccessInfo()
        {
            DataTable dtOrganisationAccessLinkedInfo = new DataTable();
            for (int rowCounter = 0; rowCounter <= this.dtExistingOrganisationAccess.Rows.Count - 1; rowCounter++)
            {
                dtOrganisationAccessLinkedInfo =
                    this.getDatafromDataBase.getU_USERInfo(null, "",
                            this.dtExistingOrganisationAccess.Rows[rowCounter]["U_USER_ID"].ToString(),
                            "", "", "", triStateBool.ignor, false, "AND");
                if(dtOrganisationAccessLinkedInfo.Rows.Count >= 1)
                    this.dtExistingOrganisationAccess.Rows[rowCounter]["User"] =
                        dtOrganisationAccessLinkedInfo.Rows[0]["FIRSTNAME"].ToString() + " " +
                        dtOrganisationAccessLinkedInfo.Rows[0]["MIDDLENAME"].ToString();

                dtOrganisationAccessLinkedInfo =
                    this.getDatafromDataBase.getM_SHOPInfo(null,"",
                        this.dtExistingOrganisationAccess.Rows[rowCounter]["M_SHOP_ID"].ToString(),
                        "",triStateBool.ignor,false,"AND");

                if (dtOrganisationAccessLinkedInfo.Rows.Count >= 1)
                    this.dtExistingOrganisationAccess.Rows[rowCounter]["Shop"] =
                        dtOrganisationAccessLinkedInfo.Rows[0]["NAME"].ToString();

                dtOrganisationAccessLinkedInfo =
                    this.getDatafromDataBase.getAD_ORGInfo(null,"",
                            this.dtExistingOrganisationAccess.Rows[rowCounter]["AD_ORG_ID"].ToString(),
                            "", triStateBool.ignor, false, "AND");

                if (dtOrganisationAccessLinkedInfo.Rows.Count >= 1)
                    this.dtExistingOrganisationAccess.Rows[rowCounter]["Organisation"] =
                        dtOrganisationAccessLinkedInfo.Rows[0]["NAME"].ToString();
            }
        }

        private void setGridControlData()
        {
            this.dtExistingOrganisationAccess.Columns.Add("Shop");
            this.dtExistingOrganisationAccess.Columns.Add("User");
            this.dtExistingOrganisationAccess.Columns.Add("Organisation");

            this.dtExistingOrganisationAccess.Columns["Shop"].SetOrdinal(0);
            this.dtExistingOrganisationAccess.Columns["User"].SetOrdinal(1);
            this.dtExistingOrganisationAccess.Columns["Organisation"].SetOrdinal(2);

            this.completeExistingOrganisationAccessInfo();
            
            this.dtgOrganisationAccessView.DataSource = this.dtExistingOrganisationAccess;

            this.dtgOrganisationAccessView.Columns["M_SHOP_ID"].Visible = false;
            this.dtgOrganisationAccessView.Columns["U_USER_ID"].Visible = false;
            this.dtgOrganisationAccessView.Columns["AD_ORG_ID"].Visible = false;
            this.dtgOrganisationAccessView.Columns["CREATED"].Visible = false;
            this.dtgOrganisationAccessView.Columns["CREATEDBY"].Visible = false;
            this.dtgOrganisationAccessView.Columns["UPDATED"].Visible = false;
            this.dtgOrganisationAccessView.Columns["UPDATEDBY"].Visible = false;
            this.dtgOrganisationAccessView.Columns["DESCRIPTION"].Visible = false;
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

            if (this.intCurrentOrganisationId == -1)
            {
                this.lblOrganisation.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblOrganisation.ForeColor = clNormalLableColor;
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



        public void frmOrganisationAccess_Load(object sender, EventArgs e)
        {
            if (generalResultInformation.currentFormIsReadOnly)
            {
                this.tlsDelete.Visible = false;
                this.tlsNew.Visible = false;
                this.tlsSave.Visible = false;
            }

            this.tlsNew_Click(sender, e);

            this.dtExistingOrganisationAccess =
                this.getDatafromDataBase.getU_ORGACCESS(null, "", "", "",
                        "", accessLevel.ignor, triStateBool.ignor, 
                        true, "AND");

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
                    this.stActiveShopName[rowCounter+1] =
                        this.dtActiveshopList.Rows[rowCounter]["NAME"].ToString();
                }
            }

            this.dtActiveUserList =
                this.getDatafromDataBase.getU_USERInfo(null, "",
                    "", "", "", "", triStateBool.yes, false, "AND");

            this.stActiveUserName = 
                new string[this.dtActiveUserList.Rows.Count+1];
            this.stActiveUserName[0] = " - Select User - ";
            
            if (this.dtActiveUserList.Rows.Count >= 1)
            {                
                for (int rowCounter = 0;
                    rowCounter <= this.dtActiveUserList.Rows.Count - 1;
                    rowCounter++)
                {
                    this.stActiveUserName[rowCounter+1] =
                        this.dtActiveUserList.Rows[rowCounter]["USERNAME"].ToString();
                }
            }

            this.dtActiveOrganisationList =
                this.getDatafromDataBase.getAD_ORGInfo(null, "",
                    "", "", triStateBool.yes, false, "AND");

            this.stActiveOrganisations =
                    new string[this.dtActiveOrganisationList.Rows.Count + 1];
            this.stActiveOrganisations[0] = " - Select Organisation - ";

            if (this.dtActiveOrganisationList.Rows.Count >= 1)
            {                
                for (int rowCounter = 0;
                    rowCounter <= this.dtActiveOrganisationList.Rows.Count - 1;
                    rowCounter++)
                {
                    this.stActiveOrganisations[rowCounter+1] =
                        this.dtActiveOrganisationList.Rows[rowCounter]["NAME"].ToString();
                }
            }

            this.cmbStation_DropDown(sender, e);
            this.cmbUser_DropDown(sender, e);
            this.cmbOrganisation_DropDown(sender, e);

            this.setGridControlData();
        }


        private void cmbStation_DropDown(object sender, EventArgs e)
        {
            this.cmbStation.Items.Clear();
            if (this.stActiveShopName != null)
            {
                this.cmbStation.Items.AddRange(this.stActiveShopName);
                this.cmbStation.SelectedIndex = 0;
            }
        }

        private void cmbUser_DropDown(object sender, EventArgs e)
        {
            this.cmbUser.Items.Clear();
            if (this.stActiveUserName != null)
            {
                this.cmbUser.Items.AddRange(this.stActiveUserName);
                this.cmbUser.SelectedIndex = 0;
            }
        }

        private void cmbOrganisation_DropDown(object sender, EventArgs e)
        {
            this.cmbOrganisation.Items.Clear();
            if (this.stActiveOrganisations != null)
            {
                this.cmbOrganisation.Items.AddRange(this.stActiveOrganisations);
                this.cmbOrganisation.SelectedIndex = 0;
            }
        }


        private void tlsNew_Click(object sender, EventArgs e)
        {
            this.isNewRecord = true;

            this.intCurrentShopId = -1;
            this.intCurrentUserId = -1;
            this.intCurrentOrganisationId = -1;

            this.cmbStation_DropDown(sender, e);
            this.cmbUser_DropDown(sender, e);
            this.cmbOrganisation_DropDown(sender, e);

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

            this.dtNewOrganisationAccess =
                this.getDatafromDataBase.getU_ORGACCESS(null, "",
                    this.intCurrentShopId.ToString(), this.intCurrentOrganisationId.ToString(),
                    this.intCurrentUserId.ToString(), accessLevel.ignor,
                    triStateBool.ignor, false, "AND");


            if (!this.isNewRecord || this.dtNewOrganisationAccess.Rows.Count >= 1)
                    stTypeOfChange = "UPDATE";

            DataRow drNewOrganisationAccess = this.dtNewOrganisationAccess.NewRow();

            drNewOrganisationAccess["M_SHOP_ID"] = this.intCurrentShopId;
            drNewOrganisationAccess["U_USER_ID"] = this.intCurrentUserId;
            drNewOrganisationAccess["AD_ORG_ID"] = this.intCurrentOrganisationId;
            drNewOrganisationAccess["ACCESSLEVEL"] = this.cmbAccessLevel.SelectedItem.ToString();
            drNewOrganisationAccess["DESCRIPTION"] = this.txtDescription.Text;

            if (this.ckIsActive.Checked)
                drNewOrganisationAccess["ISACTIVE"] = "Y";
            else
                drNewOrganisationAccess["ISACTIVE"] = "N";
            
            
            this.dtNewOrganisationAccess.Rows.Add(drNewOrganisationAccess);

            string[] primaryKeySepartor = { " <(", ")>||" };
            string[] primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                    (this.dtNewOrganisationAccess, "U_ORGACCESS", stTypeOfChange)[0]
                    .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            this.dtExistingOrganisationAccess =
                this.getDatafromDataBase.getU_ORGACCESS(null, "",
                    "", "", "", accessLevel.ignor, triStateBool.ignor, false, "AND");

            this.setGridControlData();
            if (this.dtgOrganisationAccessView.Rows.Count >= 1)
                this.dtgOrganisationAccessView.
                    Rows[this.dtgOrganisationAccessView.Rows.Count - 1].Selected = true;
        }

        private void tlsDelete_Click(object sender, EventArgs e)
        {
            if (this.checkForCompleteNewRecord())
            {
                return;
            }

            string stTypeOfChange = "DELETE";

            this.dtNewOrganisationAccess =
                this.getDatafromDataBase.getU_ORGACCESS(null, "",
                    this.intCurrentShopId.ToString(), this.intCurrentUserId.ToString(),
                    this.intCurrentOrganisationId.ToString(),
                    accessLevel.ignor, triStateBool.ignor, false, "AND");


            this.getDatafromDataBase.changeDataBaseTableData
                    (this.dtNewOrganisationAccess, "U_ORGACCESS", stTypeOfChange);

            this.dtExistingOrganisationAccess =
               this.getDatafromDataBase.getU_ORGACCESS(null, "",
                   "", "", "",accessLevel.ignor, triStateBool.ignor, false, "AND");

            this.setGridControlData();

            if (this.dtgOrganisationAccessView.Rows.Count >= 1)
                this.dtgOrganisationAccessView.
                    Rows[this.dtgOrganisationAccessView.Rows.Count - 1].Selected = true;
            else
                this.tlsNew_Click(sender, e);
        }

        private void tlsSearch_Click(object sender, EventArgs e)
        {
            this.dtExistingOrganisationAccess =
                this.getDatafromDataBase.getU_ORGACCESS(null, "",
                    "", "", "", accessLevel.ignor, triStateBool.ignor, false, "AND");
            this.setGridControlData();
            if (this.dtgOrganisationAccessView.Rows.Count >= 1)
                this.dtgOrganisationAccessView.Rows[0].Selected = true;
        }


        private void dtgOrganisationAccessView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgOrganisationAccessView.SelectedRows.Count < 1)
            {
                return;
            }

            int selectedOrganisationAccessIndex =
                this.dtgOrganisationAccessView.SelectedRows[0].Index;

            if (this.dtgOrganisationAccessView.
                    Rows[selectedOrganisationAccessIndex].
                            Cells["ISACTIVE"].Value.ToString() == "Y")
                this.ckIsActive.Checked = true;
            else
                this.ckIsActive.Checked = false;
            
            this.cmbStation.SelectedIndex = 0;
            for (int rowCounter = 0; 
                rowCounter <= this.dtActiveshopList.Rows.Count - 1; rowCounter++)
            {
                if (this.dtgOrganisationAccessView.
                        Rows[selectedOrganisationAccessIndex].
                                Cells["M_SHOP_ID"].Value.ToString() ==
                            this.dtActiveshopList.Rows[rowCounter]["M_SHOP_ID"].ToString())
                {
                    this.cmbStation.SelectedIndex = rowCounter+1;                    
                    break;
                }
            }

            this.cmbUser.SelectedIndex = 0;
            for (int rowCounter = 0;
                rowCounter <= this.dtActiveUserList.Rows.Count - 1; rowCounter++)
            {
                if (this.dtgOrganisationAccessView.
                        Rows[selectedOrganisationAccessIndex].
                                Cells["U_USER_ID"].Value.ToString() ==
                            this.dtActiveUserList.Rows[rowCounter]["U_USER_ID"].ToString())
                {
                    this.cmbUser.SelectedIndex = rowCounter+1;                    
                    break;
                }
            }

            this.cmbOrganisation.SelectedIndex = 0;
            for (int rowCounter = 0;
                rowCounter <= this.dtActiveOrganisationList.Rows.Count - 1; rowCounter++)
            {
                if (this.dtgOrganisationAccessView.
                        Rows[selectedOrganisationAccessIndex].
                                Cells["AD_ORG_ID"].Value.ToString() ==
                            this.dtActiveOrganisationList.Rows[rowCounter]["AD_ORG_ID"].ToString())
                {
                    this.cmbOrganisation.SelectedIndex = rowCounter+1;
                    break;
                }
            }

            int indexOfAccessLevel =
               this.cmbAccessLevel.Items.IndexOf(
                       this.dtgOrganisationAccessView.Rows[selectedOrganisationAccessIndex].
                           Cells["ACCESSLEVEL"].Value.ToString());

            if (indexOfAccessLevel >= 0 &&
                indexOfAccessLevel <= this.cmbAccessLevel.Items.Count)
            {
                this.cmbAccessLevel.SelectedIndex = indexOfAccessLevel;
            }
            else
                this.cmbAccessLevel.SelectedIndex = 0;

            this.txtDescription.Text =
                this.dtgOrganisationAccessView.Rows[selectedOrganisationAccessIndex].
                            Cells["DESCRIPTION"].Value.ToString();
        }

        private void cmbStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbStation.SelectedIndex > 0)
                this.intCurrentShopId =
                    int.Parse(this.dtActiveshopList.
                                Rows[this.cmbStation.SelectedIndex-1]["M_SHOP_ID"].
                                ToString());
            else
                this.intCurrentShopId = -1;
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbUser.SelectedIndex > 0)
                this.intCurrentUserId =
                    int.Parse(this.dtActiveUserList.
                                Rows[this.cmbUser.SelectedIndex-1]["U_USER_ID"].
                                ToString());
            else
                this.intCurrentUserId = -1;
        }

        private void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbOrganisation.SelectedIndex > 0)
                this.intCurrentOrganisationId =
                    int.Parse(this.dtActiveOrganisationList.
                                Rows[this.cmbOrganisation.SelectedIndex - 1]["AD_ORG_ID"].
                                ToString());
            else
                this.intCurrentOrganisationId = -1;
        }
          

                
    }
}
