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
    public partial class frmUnitConversion : Panel
    {
        public frmUnitConversion()
        {
            InitializeComponent();
        }

        string stringShopID = generalResultInformation.activeStation;
        int intUOMConversionID = 0;

        DataTable dtAllActiveUOM = new DataTable();
        DataTable dtDrivedUOMList = new DataTable();
        DataTable dtAllActiveProduct = new DataTable();
        DataTable dtAllUnitConversion = new DataTable();
        DataTable dtNewUnitConversion = new DataTable();
        
        Color clNormalLableColor = Color.Black;
        Color clErrorLableColor = Color.Red;
        Color clChangedLableColor = Color.Blue;

        private dataBuilder getDatafromDataBase = new dataBuilder();

        private bool checkForCompleteNewRecord()
        {
            bool foundError = true;
                        
            if (this.cmbUCBaseUOM.Items.Count <= 0 ||
                this.cmbUCBaseUOM.SelectedIndex < 0 ||
                this.cmbUCBaseUOM.SelectedIndex >=
                this.dtAllActiveUOM.Rows.Count)
            {
                this.lblUCBaseUOM.ForeColor = clErrorLableColor;
                foundError = false;
            }
            else
            {
                this.lblUCBaseUOM.ForeColor = clNormalLableColor;
            }

            if (this.cmbUCDrivedUOM.Items.Count <= 0 ||
                this.cmbUCDrivedUOM.SelectedIndex < 0 ||
                this.cmbUCDrivedUOM.SelectedIndex >=
                this.dtDrivedUOMList.Rows.Count)
            {
                this.lblUCDrivedUnit.ForeColor = clErrorLableColor;
                foundError = false;
            }
            else
            {
                this.lblUCDrivedUnit.ForeColor = clNormalLableColor;
            }

            if (this.ntbMultiplier.Amount == "0")
            {
                this.lblUCMulitplier.ForeColor = clErrorLableColor;
                foundError = false;
            }
            else
            {
                this.lblUCMulitplier.ForeColor = clNormalLableColor; 
            }

            return foundError;
        }

        private void fillBaseUOMComboBox()
        {
            this.cmbUCBaseUOM.Items.Clear();
            for (int rowCounter = 0;
                rowCounter <= this.dtAllActiveUOM.Rows.Count - 1; rowCounter++)
            {
                this.cmbUCBaseUOM.Items.Insert(rowCounter,
                    this.dtAllActiveUOM.Rows[rowCounter]["NAME"].ToString());
            }
            if (this.cmbUCBaseUOM.Items.Count > 0)
            {
                if (unitConvesionInformation.stBaseUnitId != "")
                {
                    bool blUnitFound = false;
                    for (int rowCounter = 0;
                        rowCounter <= this.dtAllActiveUOM.Rows.Count - 1; rowCounter++)
                    {
                        if (this.dtAllActiveUOM.Rows[rowCounter]["M_UOM_ID"].ToString() ==
                            unitConvesionInformation.stBaseUnitId)
                        {
                            this.cmbUCBaseUOM.SelectedIndex = rowCounter;
                            blUnitFound = true;
                            break;
                        }                       
                    }
                    if (!blUnitFound)
                    {
                        DataTable dtAllUOM =
                            this.getDatafromDataBase.getM_UOMInfo(null, "",
                                unitConvesionInformation.stBaseUnitId,
                                    "", "", triStateBool.ignor, false, "AND");
                        if (dtAllUOM.Rows.Count > 0)
                        {
                            this.cmbUCBaseUOM.Items.Insert(this.cmbUCBaseUOM.Items.Count,
                                    dtAllUOM.Rows[0]["NAME"].ToString());
                            this.cmbUCBaseUOM.SelectedIndex =
                                this.cmbUCBaseUOM.Items.Count - 1;
                        }
                    }
                }
                else
                    this.cmbUCBaseUOM.SelectedIndex = 0;
            }
 
        }

        private void fillDrivedUOMComboBox()
        {
            this.cmbUCDrivedUOM.Items.Clear();
            this.dtDrivedUOMList = 
                this.dtAllActiveUOM.Copy();
            if (this.cmbUCBaseUOM.Items.Count == this.dtAllActiveUOM.Rows.Count)
            {
                for (int rowCounter = 0;
                    rowCounter <= dtDrivedUOMList.Rows.Count - 1; rowCounter++)
                {
                    if (dtDrivedUOMList.Rows[rowCounter]["M_UOM_ID"].ToString() ==
                        this.dtAllActiveUOM.Rows[this.cmbUCBaseUOM.SelectedIndex]
                        ["M_UOM_ID"].ToString())
                    {
                        dtDrivedUOMList.Rows.RemoveAt(rowCounter);
                        break;
                    }
                }
            }

            for (int rowCounter = 0;
                rowCounter <= dtDrivedUOMList.Rows.Count - 1; rowCounter++)
            {
                this.cmbUCDrivedUOM.Items.Insert(rowCounter,
                    dtDrivedUOMList.Rows[rowCounter]["NAME"].ToString());
            }
            if (this.cmbUCBaseUOM.Items.Count > 0)
                this.cmbUCDrivedUOM.SelectedIndex = 0;
        }

        private void fillChoosenProduct()
        {
            if (unitConvesionInformation.stBaseProductId == "")
                return;
            DataTable dtProductInfor =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                    unitConvesionInformation.stBaseProductId, "", "", "",
                    "", "", "", "", triStateBool.ignor,
                    false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
            if (dtProductInfor.Rows.Count <= 0)
                return;
            this.ddgUCProduct.SelectedItem =
                dtProductInfor.Rows[0]["NAME"].ToString();
            this.ddgUCProduct.SelectedRowKey =
                dtProductInfor.Rows[0]["M_PRODUCT_ID"].ToString();
        }


        public void frmUnitConversion_Load(object sender, EventArgs e)
        {
            if (generalResultInformation.currentFormIsReadOnly)
            {
                this.tlsDelete.Visible = false;
                this.tlsNew.Visible = false;
                this.tlsSave.Visible = false;                
            }

            this.dtAllActiveUOM =
                this.getDatafromDataBase.getM_UOMInfo(null, "", "", 
                    "", "", triStateBool.yes, false, "AND");

            this.dtAllActiveProduct =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "", "",
                        "", "", "", "", "", "", "", 
                               triStateBool.yes, true, "AND",generalResultInformation.dbBulkDataRetrivalSize);

            this.dtAllUnitConversion =
                this.getDatafromDataBase.getM_UOM_CONVERSIONInfo(null, "",
                    "", "", "", 0, triStateBool.ignor, true, "AND");

            this.fillBaseUOMComboBox();

            this.ddgUCProduct.DataSource = this.dtAllActiveProduct.Copy();

            this.fillChoosenProduct();

            this.dtAllUnitConversion.Columns.Add("BASE UNIT");
            this.dtAllUnitConversion.Columns.Add("DRIVED UNIT");
            this.dtAllUnitConversion.Columns.Add("APPLICABLE PRODUCT");

            this.dtAllUnitConversion.Columns["BASE UNIT"].SetOrdinal(0);
            this.dtAllUnitConversion.Columns["DRIVED UNIT"].SetOrdinal(1);
            this.dtAllUnitConversion.Columns["APPLICABLE PRODUCT"].SetOrdinal(2);
            this.dtAllUnitConversion.Columns["MULTIPLIER"].SetOrdinal(3);
            
            this.dtgUCGridView.DataSource = this.dtAllUnitConversion;

            this.dtgUCGridView.Columns["M_SHOP_ID"].Visible = false;
            this.dtgUCGridView.Columns["AD_ORG_ID"].Visible = false;
            this.dtgUCGridView.Columns["M_UOM_CONVERSION_ID"].Visible = false;
            this.dtgUCGridView.Columns["M_BASE_UOM_ID"].Visible = false;
            this.dtgUCGridView.Columns["M_DRIVED_UOM_ID"].Visible = false;
            this.dtgUCGridView.Columns["M_PRODUCT_ID"].Visible = false;
            this.dtgUCGridView.Columns["CREATED"].Visible = false;
            this.dtgUCGridView.Columns["CREATEDBY"].Visible = false;
            this.dtgUCGridView.Columns["UPDATED"].Visible = false;
            this.dtgUCGridView.Columns["UPDATEDBY"].Visible = false;
        }

        private void tlsNew_Click(object sender, EventArgs e)
        {
            this.fillBaseUOMComboBox();
            this.fillChoosenProduct();
            this.txtUCDescripton.Text = "";
            this.intUOMConversionID = 0;
            this.ntbMultiplier.Amount = "0";
            this.ddgUCProduct.SelectedRow.Clear();
            this.ddgUCProduct.SelectedRowKey = null;
            this.ddgUCProduct.SelectedItem = "";
           
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

            this.dtNewUnitConversion =
                this.getDatafromDataBase.getM_UOM_CONVERSIONInfo(null, "",
                        "", "", "", 0, triStateBool.ignor, true, "");

            DataRow drNewUnitConversion = this.dtNewUnitConversion.NewRow();

            if (this.intUOMConversionID != 0)
            {
                drNewUnitConversion["M_UOM_CONVERSION_ID"] = 
                    this.intUOMConversionID;
                stTypeOfChange = "UPDATE";
            }
            else
                stTypeOfChange = "INSERT";

            drNewUnitConversion["M_SHOP_ID"] = this.stringShopID;

            drNewUnitConversion["M_BASE_UOM_ID"] =
                this.dtAllActiveUOM.Rows[this.cmbUCBaseUOM.SelectedIndex]
                                    ["M_UOM_ID"].ToString();
                        
            drNewUnitConversion["M_DRIVED_UOM_ID"] =
                this.dtDrivedUOMList.Rows[this.cmbUCDrivedUOM.SelectedIndex]
                                    ["M_UOM_ID"].ToString();
            if (this.ddgUCProduct.SelectedRowKey != null)
                drNewUnitConversion["M_PRODUCT_ID"] =
                    this.ddgUCProduct.SelectedRowKey.ToString();
            else
                drNewUnitConversion["M_PRODUCT_ID"] = "0";

            if(this.ckIsActive.Checked)
                drNewUnitConversion["ISACTIVE"] = "Y";
            else
                drNewUnitConversion["ISACTIVE"] = "N";
            drNewUnitConversion["DESCRIPTION"] = 
                this.txtUCDescripton.Text;
            drNewUnitConversion["MULTIPLIER"] = 
                decimal.Parse(this.ntbMultiplier.Amount);

            this.dtNewUnitConversion.Rows.Add(drNewUnitConversion);


            string[] primaryKeySepartor = { " <(", ")>||" };
            string[] primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                    (this.dtNewUnitConversion.Copy(), "M_UOM_CONVERSION", stTypeOfChange)[0]
                    .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            if (primaryKey.Length > 1 && stTypeOfChange == "INSERT")
            {
                this.intUOMConversionID = int.Parse(primaryKey[1]);
                this.tlsSearch_Click(sender, e);                
                if (this.dtAllUnitConversion.Rows.Count > 0)
                    this.dtgUCGridView.
                        Rows[this.dtAllUnitConversion.Rows.Count - 1].Selected = true;
            }
        }

        private void tlsSearch_Click(object sender, EventArgs e)
        {
            this.dtAllUnitConversion =
                this.getDatafromDataBase.
                    getM_UOM_CONVERSIONInfo(null, "", "", "",
                        "", 0, triStateBool.ignor, false, "AND");

            this.dtAllUnitConversion.Columns.Add("BASE UNIT");
            this.dtAllUnitConversion.Columns.Add("DRIVED UNIT");
            this.dtAllUnitConversion.Columns.Add("APPLICABLE PRODUCT");

            this.dtAllUnitConversion.Columns["BASE UNIT"].SetOrdinal(0);
            this.dtAllUnitConversion.Columns["DRIVED UNIT"].SetOrdinal(1);
            this.dtAllUnitConversion.Columns["APPLICABLE PRODUCT"].SetOrdinal(2);
            this.dtAllUnitConversion.Columns["MULTIPLIER"].SetOrdinal(3);

            for (int rowCounter = 0;
                    rowCounter <= this.dtAllUnitConversion.Rows.Count - 1;
                    rowCounter++)
            {
                DataTable dtUnitInfo =
                     this.getDatafromDataBase.getM_UOMInfo(null, "",
                          this.dtAllUnitConversion.Rows[rowCounter]["M_BASE_UOM_ID"].ToString(),
                                "", "", triStateBool.ignor, false, "AND");

                if(dtUnitInfo.Rows.Count > 0)
                    this.dtAllUnitConversion.Rows[rowCounter]["BASE UNIT"] = 
                        dtUnitInfo.Rows[0]["NAME"].ToString();

                dtUnitInfo =
                     this.getDatafromDataBase.getM_UOMInfo(null, "",
                                this.dtAllUnitConversion.Rows[rowCounter]["M_DRIVED_UOM_ID"].ToString(),
                                "", "", triStateBool.ignor, false, "AND");

                if (dtUnitInfo.Rows.Count > 0)
                    this.dtAllUnitConversion.Rows[rowCounter]["DRIVED UNIT"] =
                        dtUnitInfo.Rows[0]["NAME"].ToString();

                DataTable dtProductInfo =
                    this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                              this.dtAllUnitConversion.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                              "", "", "", "", "", "", "", 
                              triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

                if (dtProductInfo.Rows.Count > 0)
                    this.dtAllUnitConversion.Rows[rowCounter]["APPLICABLE PRODUCT"] =
                        dtProductInfo.Rows[0]["NAME"].ToString();
            }
            this.dtgUCGridView.DataSource = this.dtAllUnitConversion;
        }

        private void cmbUCBaseUOM_DropDown(object sender, EventArgs e)
        {
            this.fillBaseUOMComboBox();
        }

        private void cmbUCDrivedUOM_DropDown(object sender, EventArgs e)
        {
            this.fillDrivedUOMComboBox();
        }

        private void cmbUCBaseUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.fillDrivedUOMComboBox();
        }

        private void ddgUCProduct_SelectedItemClicked(object sender, EventArgs e)
        {
            DataTable dtExistingAllProductInformation =
                this.getDatafromDataBase.getV_PRDUCTCOSTInfo(null, "", "",
                        "", "", "", "", this.ddgUCProduct.SelectedItem, "", "", "",0,0,0,0, 
                               triStateBool.yes, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
            this.ddgUCProduct.DataSource = dtExistingAllProductInformation;
            this.ddgUCProduct.DataTablePrimaryKey =
                Convert.ToUInt16(dtExistingAllProductInformation.Columns.IndexOf("M_PRODUCT_ID"));
            this.ddgUCProduct.SelectedColomnIdex =
                dtExistingAllProductInformation.Columns.IndexOf("NAME");
            this.ddgUCProduct.HiddenColoumns = new int[]
                                {
                                    dtExistingAllProductInformation.Columns.IndexOf("M_SHOP_ID"),
                                    dtExistingAllProductInformation.Columns.IndexOf("AD_ORG_ID"),
                                    dtExistingAllProductInformation.Columns.IndexOf("CREATED"),
                                    dtExistingAllProductInformation.Columns.IndexOf("UPDATED"),
                                    dtExistingAllProductInformation.Columns.IndexOf("M_PRODUCTCATEGORY_ID"),
                                    dtExistingAllProductInformation.Columns.IndexOf("M_UOM_ID"),
                                    dtExistingAllProductInformation.Columns.IndexOf("CREATEDBY"),
                                    dtExistingAllProductInformation.Columns.IndexOf("UPDATEDBY"),
                                    dtExistingAllProductInformation.Columns.IndexOf("ISACTIVE"),
                                    dtExistingAllProductInformation.Columns.IndexOf("DESCRIPTION"),
                                    dtExistingAllProductInformation.Columns.IndexOf("PRODUCTTYPE"),
                                    dtExistingAllProductInformation.Columns.IndexOf("IMAGEPATH"),
                                    dtExistingAllProductInformation.Columns.IndexOf("PURCHASEPRICE"),
                                    dtExistingAllProductInformation.Columns.IndexOf("CURRENTCOST"),
                                    dtExistingAllProductInformation.Columns.IndexOf("ACCUMULATEDQTY"),
                                    dtExistingAllProductInformation.Columns.IndexOf("ACCUMULATEDCOST")
                                };

        }

        private void ddgUCProduct_selectedItemChanged(object sender, EventArgs e)
        {

        }

        private void cmdUCShowImage_Click(object sender, EventArgs e)
        {
            this.ddgUCProduct.SelectedRow.Clear();
            this.ddgUCProduct.SelectedRowKey = null;
            this.ddgUCProduct.SelectedItem = "";

            generalResultInformation.selectedProductId = "";
            frmProductImage frmProductImageList = new frmProductImage();
            frmProductImageList.ShowDialog();
            if (generalResultInformation.selectedProductId != "")
            {
                DataTable dtProdcutInfo =
                    this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                                generalResultInformation.selectedProductId,
                                "", "", "", "", "", "", "", 
                                triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

                this.ddgUCProduct.SelectedItem = dtProdcutInfo.Rows[0]["NAME"].ToString();
                this.ddgUCProduct.SelectedRowKey = dtProdcutInfo.Rows[0]["M_PRODUCT_ID"];
            }            
        }

        private void dtgUCGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgUCGridView.SelectedRows.Count < 1)
            {
                return;
            }

            int selectedProductIndex =
               this.dtgUCGridView.SelectedRows[0].Index;
            this.intUOMConversionID =
                int.Parse(this.dtgUCGridView.Rows[selectedProductIndex].
                            Cells["M_UOM_CONVERSION_ID"].Value.ToString());
            
            bool itemFoundInList = false;
            for (int rowCounter = 0; 
                    rowCounter <= this.dtAllActiveUOM.Rows.Count - 1;
                    rowCounter++ )
            {
                if (this.dtgUCGridView.Rows[selectedProductIndex].
                            Cells["M_BASE_UOM_ID"].Value.ToString() ==
                    this.dtAllActiveUOM.Rows[rowCounter]["M_UOM_ID"].ToString())
                {
                    this.cmbUCBaseUOM.SelectedIndex = rowCounter;
                    itemFoundInList = true;
                    break;
                }
            }
            if (!itemFoundInList)
            {
                this.cmbUCBaseUOM.Items.Insert(this.cmbUCBaseUOM.Items.Count,
                        this.dtgUCGridView.Rows[selectedProductIndex].
                            Cells["BASE UNIT"].Value.ToString());
                this.cmbUCBaseUOM.SelectedIndex = this.cmbUCBaseUOM.Items.Count - 1;
            }

            itemFoundInList = false;
            for (int rowCounter = 0;
                    rowCounter <= this.dtDrivedUOMList.Rows.Count - 1;
                    rowCounter++)
            {
                if (this.dtgUCGridView.Rows[selectedProductIndex].
                            Cells["M_DRIVED_UOM_ID"].Value.ToString() ==
                    this.dtDrivedUOMList.Rows[rowCounter]["M_UOM_ID"].ToString())
                {
                    this.cmbUCDrivedUOM.SelectedIndex = rowCounter;
                    itemFoundInList = true;
                    break;
                }
            }

            if (!itemFoundInList)
            {
                this.cmbUCDrivedUOM.Items.Insert(this.cmbUCDrivedUOM.Items.Count,
                        this.dtgUCGridView.Rows[selectedProductIndex].
                            Cells["DRIVED UNIT"].Value.ToString());
                this.cmbUCDrivedUOM.SelectedIndex = this.cmbUCDrivedUOM.Items.Count - 1;
            }

            this.txtUCDescripton.Text =
                this.dtgUCGridView.Rows[selectedProductIndex].
                            Cells["DESCRIPTION"].Value.ToString(); ;

            this.ddgUCProduct.SelectedRowKey = 
                this.dtgUCGridView.Rows[selectedProductIndex].
                            Cells["M_PRODUCT_ID"].Value.ToString();
            this.ddgUCProduct.SelectedItem = 
                this.dtgUCGridView.Rows[selectedProductIndex].
                            Cells["APPLICABLE PRODUCT"].Value.ToString();

            if (this.dtgUCGridView.Rows[selectedProductIndex].
                     Cells["ISACTIVE"].Value.ToString() == "Y")
                this.ckIsActive.Checked = true;
            else
                this.ckIsActive.Checked = false;

            this.ntbMultiplier.Amount = 
                this.dtgUCGridView.Rows[selectedProductIndex].
                            Cells["MULTIPLIER"].Value.ToString();
        }


    }
}
