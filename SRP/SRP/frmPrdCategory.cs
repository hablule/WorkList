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
    public partial class frmPrdCategory : Panel
    {
        public frmPrdCategory()
        {
            InitializeComponent();
            //this.frmPrdCategory_Load(this, new EventArgs());
        }
        
        string stringShopID = generalResultInformation.activeStation;
        int intPrdCategoryID = 0;

        static private Color clNormalLableColor = Color.Black;
        static private Color clErrorLableColor = Color.Red;
        static private Color clChangedLableColor = Color.Blue;


        DataTable dtNewPrdCategory = new DataTable();
        DataTable dtExistingCategory = new DataTable();

        private dataBuilder getDatafromDataBase = new dataBuilder();




        private void tlsNew_Click(object sender, EventArgs e)
        {
            this.intPrdCategoryID = 0;
            this.txtPrdCategoryName.Text = "";
            this.txtPrdCategoryDescritpion.Text = "";
            this.ckPrdCategoryIsActive.Checked = true;

            this.lblPrdCategoryName.ForeColor = clNormalLableColor;
            this.lblPrdCategoryDescription.ForeColor = clNormalLableColor;
            this.ckPrdCategoryIsActive.ForeColor = clNormalLableColor;
        }

        private void tlsSave_Click(object sender, EventArgs e)
        {
            string stTypeOfChange = "INSERT";
            if (this.txtPrdCategoryName.Text == "")
            {
                this.lblPrdCategoryName.ForeColor = clErrorLableColor;
                MessageBox.Show("Please complete the missing form element before proceeding.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            this.lblPrdCategoryName.ForeColor = clNormalLableColor;

            this.dtNewPrdCategory =
                this.getDatafromDataBase.getM_PRODUCTCATEGORYInfo(null, 
                            "", "", "", triStateBool.ignor, true, "");

            DataRow drNewPrdCategory = this.dtNewPrdCategory.NewRow();

            if (this.intPrdCategoryID != 0)
            {
                drNewPrdCategory["M_PRODUCTCATEGORY_ID"] = this.intPrdCategoryID;
                stTypeOfChange = "UPDATE";
            }
            else
                stTypeOfChange = "INSERT";

            drNewPrdCategory["M_SHOP_ID"] = this.stringShopID;
            drNewPrdCategory["NAME"] = this.txtPrdCategoryName.Text;
            drNewPrdCategory["DESCRIPTION"] = this.txtPrdCategoryDescritpion.Text;

            if (this.ckPrdCategoryIsActive.Checked)
                drNewPrdCategory["ISACTIVE"] = "Y";
            else
                drNewPrdCategory["ISACTIVE"] = "N";

            this.dtNewPrdCategory.Rows.Add(drNewPrdCategory);

            string[] primaryKeySepartor = { " <(", ")>||" };
            string[] primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                    (this.dtNewPrdCategory.Copy(), "M_PRODUCTCATEGORY", stTypeOfChange)[0]
                    .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            if (primaryKey.Length > 1 && stTypeOfChange == "INSERT")
            {
                this.intPrdCategoryID = int.Parse(primaryKey[1]);
                this.dtExistingCategory =
                    this.getDatafromDataBase.getM_PRODUCTCATEGORYInfo(null,
                            "", "", "", triStateBool.ignor,false, "");
                this.dtgPrdCategoryGridView.DataSource = this.dtExistingCategory;
                if (this.dtExistingCategory.Rows.Count > 0)
                    this.dtgPrdCategoryGridView.Rows[this.dtExistingCategory.Rows.Count - 1].Selected = true;
            }                
        }

        private void tlsSearch_Click(object sender, EventArgs e)
        {
            this.dtExistingCategory =
                    this.getDatafromDataBase.getM_PRODUCTCATEGORYInfo(null,
                            "", "", "", triStateBool.ignor, false, "");
            this.dtgPrdCategoryGridView.DataSource = this.dtExistingCategory;
            if (this.dtExistingCategory.Rows.Count > 0)
                this.dtgPrdCategoryGridView.Rows[0].Selected = true;            
        }

        private void dtgPrdCategoryGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgPrdCategoryGridView.SelectedRows.Count < 1)
            {
                return;
            }

            int selectedCityIndex =
                this.dtgPrdCategoryGridView.SelectedRows[0].Index;
            this.intPrdCategoryID =
                int.Parse(this.dtgPrdCategoryGridView.Rows[selectedCityIndex].
                        Cells["M_PRODUCTCATEGORY_ID"].Value.ToString());
            this.txtPrdCategoryName.Text =
                this.dtgPrdCategoryGridView.Rows[selectedCityIndex].Cells["NAME"].Value.ToString();
            this.txtPrdCategoryDescritpion.Text =
                this.dtgPrdCategoryGridView.Rows[selectedCityIndex].Cells["DESCRIPTION"].Value.ToString();

            if (this.dtgPrdCategoryGridView.Rows[selectedCityIndex].
                    Cells["ISACTIVE"].Value.ToString() == "Y")
                this.ckPrdCategoryIsActive.Checked = true;
            else
                this.ckPrdCategoryIsActive.Checked = false;
        }

        public void frmPrdCategory_Load(object sender, EventArgs e)
        {
            if (generalResultInformation.currentFormIsReadOnly)
            {
                this.tlsDelete.Visible = false;
                this.tlsNew.Visible = false;
                this.tlsSave.Visible = false;
            }

            this.tlsNew_Click(sender, e);
            this.dtExistingCategory =
                       this.getDatafromDataBase.getM_PRODUCTCATEGORYInfo(null,
                            "", "", "", triStateBool.ignor, true, "");

            this.dtgPrdCategoryGridView.DataSource = this.dtExistingCategory;
            if (this.dtExistingCategory.Rows.Count > 0)
                this.dtgPrdCategoryGridView.Rows[0].Selected = true;

            this.dtgPrdCategoryGridView.Columns["M_SHOP_ID"].Visible = false;
            this.dtgPrdCategoryGridView.Columns["AD_ORG_ID"].Visible = false;
            this.dtgPrdCategoryGridView.Columns["M_PRODUCTCATEGORY_ID"].Visible = false;
            this.dtgPrdCategoryGridView.Columns["CREATED"].Visible = false;
            this.dtgPrdCategoryGridView.Columns["UPDATED"].Visible = false;
            this.dtgPrdCategoryGridView.Columns["CREATEDBY"].Visible = false;
            this.dtgPrdCategoryGridView.Columns["UPDATEDBY"].Visible = false;

        }

    }
}
