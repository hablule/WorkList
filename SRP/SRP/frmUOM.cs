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
    public partial class frmUOM : Panel
    {
        public frmUOM()
        {
            InitializeComponent();            
        }

        string stringShopID = generalResultInformation.activeStation;
        int intUOMID = 0;

        static private Color clNormalLableColor = Color.Black;
        static private Color clErrorLableColor = Color.Red;
        static private Color clChangedLableColor = Color.Blue;

        DataTable dtNewUOMinformation = new DataTable();
        DataTable dtExistingUOMInformation = new DataTable();

        private dataBuilder getDatafromDataBase = new dataBuilder();


        private bool checkForCompleteNewRecord()
        {
            bool foundError = true;
            
            if (this.txtUOMName.Text == "")
            {
                this.lblUOMName.ForeColor = clErrorLableColor;
                foundError = false;
            }
            else
            {
                this.lblUOMName.ForeColor = clNormalLableColor;
            }

            if (this.txtUOMAbbreviation.Text == "")
            {
                this.lblUOMAbbreviation.ForeColor = clErrorLableColor;
                foundError = false;
            }
            else
            {
                this.lblUOMAbbreviation.ForeColor = clNormalLableColor;
            }

            if (this.ntbUOMStdPrecision.Amount == "")
            {
                this.lblUOMStdPrecision.ForeColor = clErrorLableColor;
                foundError = false;
            }
            else
            {
                this.lblUOMStdPrecision.ForeColor = clNormalLableColor;
            }

            return foundError;
        }



        public void frmUOM_Load(object sender, EventArgs e)
        {
            if (generalResultInformation.currentFormIsReadOnly)
            {
                this.tlsDelete.Visible = false;
                this.tlsNew.Visible = false;
                this.tlsSave.Visible = false;                
            }

            this.tlsNew_Click(sender, e);
            this.dtExistingUOMInformation =
                    this.getDatafromDataBase.getM_UOMInfo(null, "", "",
                            "", "", triStateBool.ignor,true, "");
            this.dtgUOMGridView.DataSource = this.dtExistingUOMInformation;
            if (this.dtExistingUOMInformation.Rows.Count > 0)
                this.dtgUOMGridView.Rows[0].Selected = true;

            this.dtgUOMGridView.Columns["M_SHOP_ID"].Visible = false;
            this.dtgUOMGridView.Columns["AD_ORG_ID"].Visible = false;
            this.dtgUOMGridView.Columns["M_UOM_ID"].Visible = false;
            this.dtgUOMGridView.Columns["CREATED"].Visible = false;
            this.dtgUOMGridView.Columns["UPDATED"].Visible = false;
            this.dtgUOMGridView.Columns["CREATEDBY"].Visible = false;
            this.dtgUOMGridView.Columns["UPDATEDBY"].Visible = false;
        }
        

        private void tlsNew_Click(object sender, EventArgs e)
        {
            this.intUOMID = 0;

            this.txtUOMName.Text = "";
            this.txtUOMDescription.Text = "";
            this.txtUOMAbbreviation.Text = "";

            this.ntbUOMStdPrecision.Amount = "0";
            this.ckUOMIsActive.Checked = true;
        }

        private void tlsSave_Click(object sender, EventArgs e)
        {
            string stTypeOfChange = "INSERT";
            if (!this.checkForCompleteNewRecord())
            {
                MessageBox.Show("Please complete the missing form element before proceeding.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                        
            this.dtNewUOMinformation =
                this.getDatafromDataBase.getM_UOMInfo(null, "", "",
                        "", "", triStateBool.ignor, true, "");

            DataRow drNewUOM = dtNewUOMinformation.NewRow();

            if (this.intUOMID != 0)
            {
                drNewUOM["M_UOM_ID"] = this.intUOMID;
                stTypeOfChange = "UPDATE";
            }
            else
                stTypeOfChange = "INSERT";

            drNewUOM["M_SHOP_ID"] = this.stringShopID;
            drNewUOM["NAME"] = this.txtUOMName.Text;
            drNewUOM["DESCRIPTION"] = this.txtUOMDescription.Text;
            if (this.ckUOMIsActive.Checked)
                drNewUOM["ISACTIVE"] = "Y";
            else
                drNewUOM["ISACTIVE"] = "N";
            drNewUOM["STDPRECISION"] = this.ntbUOMStdPrecision.Amount;
            drNewUOM["ABBREVATION"] = this.txtUOMAbbreviation.Text;

            this.dtNewUOMinformation.Rows.Add(drNewUOM);

            string[] primaryKeySepartor = { " <(", ")>||" };
            string[] primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                    (this.dtNewUOMinformation.Copy(), "M_UOM", stTypeOfChange)[0]
                    .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            if (primaryKey.Length > 1 && stTypeOfChange == "INSERT")
            {
                this.intUOMID = int.Parse(primaryKey[1]);
                this.dtExistingUOMInformation =
                    this.getDatafromDataBase.getM_UOMInfo(null, "", "", 
                            "", "", triStateBool.ignor, false, "");
                this.dtgUOMGridView.DataSource = this.dtExistingUOMInformation;
                if (this.dtExistingUOMInformation.Rows.Count > 0)
                    this.dtgUOMGridView.Rows[this.dtExistingUOMInformation.Rows.Count-1].Selected = true;
            }        
            
        }

        private void tlsSearch_Click(object sender, EventArgs e)
        {
            this.dtExistingUOMInformation =
                    this.getDatafromDataBase.getM_UOMInfo(null, "", "", 
                            "","", triStateBool.ignor, false, "");
            this.dtgUOMGridView.DataSource = this.dtExistingUOMInformation;
            if (this.dtExistingUOMInformation.Rows.Count > 0)
                this.dtgUOMGridView.Rows[0].Selected = true;

            this.dtgUOMGridView.Columns["M_UOM_ID"].Visible = false;
            this.dtgUOMGridView.Columns["CREATED"].Visible = false;
            this.dtgUOMGridView.Columns["UPDATED"].Visible = false;
        }

        private void dtgUOMGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgUOMGridView.SelectedRows.Count < 1)
            {
                return;
            }

            int selectedCityIndex =
                this.dtgUOMGridView.SelectedRows[0].Index;
            this.intUOMID =
                int.Parse(this.dtgUOMGridView.Rows[selectedCityIndex].Cells["M_UOM_ID"].Value.ToString());
            this.txtUOMName.Text =
                this.dtgUOMGridView.Rows[selectedCityIndex].Cells["NAME"].Value.ToString();
            this.txtUOMDescription.Text =
                this.dtgUOMGridView.Rows[selectedCityIndex].Cells["DESCRIPTION"].Value.ToString();
            this.ntbUOMStdPrecision.Amount =
                this.dtgUOMGridView.Rows[selectedCityIndex].Cells["STDPRECISION"].Value.ToString();
            this.txtUOMAbbreviation.Text =
                this.dtgUOMGridView.Rows[selectedCityIndex].Cells["ABBREVATION"].Value.ToString();

            if (this.dtgUOMGridView.Rows[selectedCityIndex].
                    Cells["ISACTIVE"].Value.ToString() == "Y")
                this.ckUOMIsActive.Checked = true;
            else
                this.ckUOMIsActive.Checked = false;
        }

        


    }
}
