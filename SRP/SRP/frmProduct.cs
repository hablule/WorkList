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
    public partial class frmProduct : Panel
    {
        public frmProduct()
        {
            InitializeComponent();            
        }

        bool blcurrentRecordSaved = false;

        string stringShopID = generalResultInformation.activeStation;
        int intProductID = 0;
        int intUOMId = 0;
        string imageFile = "";

        
        Color clNormalLableColor = Color.Black;
        Color clErrorLableColor = Color.Red;
        Color clChangedLableColor = Color.Blue;

        DataTable dtNewProductInformation = new DataTable();
        DataTable dtExistingProductInformation = new DataTable();
        DataTable dtExistingActiveUOM = new DataTable();
        DataTable dtExistingActiveProductCategory = new DataTable();
        DataTable dtAllUOM = new DataTable();
        DataTable dtAllProductCategory = new DataTable();
        DataTable dtProductUnitConversionRate = new DataTable();

        private dataBuilder getDatafromDataBase = new dataBuilder();

        private void enableDisableFormElement()
        {
            if (this.intProductID != 0)
                this.blcurrentRecordSaved = true;
            else
                this.blcurrentRecordSaved = false;

            this.cmbProductType.Enabled = !this.blcurrentRecordSaved;
            this.cmbProductUOM.Enabled = !this.blcurrentRecordSaved;

            this.tlsConductPurchase.Enabled = this.blcurrentRecordSaved;
            this.tlsConductSales.Enabled = this.blcurrentRecordSaved;

            
        }

        private bool checkForCompleteNewRecord()
        {
            bool foundError = true;

            if (this.txtProductCode.Text == "")
            {
                this.lblProductCode.ForeColor = clErrorLableColor;
                foundError = false;
            }
            else
            {
                this.lblProductCode.ForeColor = clNormalLableColor;
            }

            if (this.txtProductName.Text == "")
            {
                this.lblProductName.ForeColor = clErrorLableColor;
                foundError = false;
            }
            else
            {
                this.lblProductName.ForeColor = clNormalLableColor;
            }

            if (this.cmbProductCategory.Items.Count <= 0 ||
                this.cmbProductCategory.SelectedIndex < 0 ||
                this.cmbProductCategory.SelectedIndex >= 
                this.cmbProductCategory.Items.Count)
            {
                this.lblProductCategory.ForeColor = clErrorLableColor;
                foundError = false;
            }
            else
            {
                this.lblProductCategory.ForeColor = clNormalLableColor;
            }

            if (this.cmbProductUOM.Items.Count <= 0 ||
                this.cmbProductUOM.SelectedIndex < 0 ||
                this.cmbProductUOM.SelectedIndex >=
                this.cmbProductUOM.Items.Count)
            {
                this.lblProductUOM.ForeColor = clErrorLableColor;
                foundError = false;
            }
            else
            {
                this.lblProductUOM.ForeColor = clNormalLableColor;
            }

            return foundError;
        }

        private bool checkForChangedRecord()
        {
            bool blFoundChage = false;
            if (this.intProductID == 0)
                return blFoundChage;

            DataTable dtProductInfor =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                    this.intProductID.ToString(), "", "", "", "", "",
                       "", "", triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

            if (dtProductInfor.Rows.Count <= 0)
                return blFoundChage;
            
            if (dtProductInfor.Rows[0]["CODE"].ToString() !=
                this.txtProductCode.Text)
            {
                this.lblProductCode.ForeColor = clChangedLableColor;
                blFoundChage = true;
            }
            else
            {
                this.lblProductCode.ForeColor = clNormalLableColor;
            }
                        
            if (dtProductInfor.Rows[0]["CODE2"].ToString() !=
                this.txtVendorCode.Text)
            {
                this.lblVendorCode.ForeColor = clChangedLableColor;
                blFoundChage = true;
            }
            else
            {
                this.lblVendorCode.ForeColor = clNormalLableColor;
            }

            if (dtProductInfor.Rows[0]["NAME"].ToString() !=
                this.txtProductName.Text)
            {
                this.lblProductName.ForeColor = clChangedLableColor;
                blFoundChage = true;
            }
            else
            {
                this.lblProductName.ForeColor = clNormalLableColor;
            }

            if (dtProductInfor.Rows[0]["UPC_EAN"].ToString() !=
                this.txtProductUPCEAN.Text)
            {
                this.lblProductUPCEAC.ForeColor = clChangedLableColor;
                blFoundChage = true;
            }
            else
            {
                this.lblProductUPCEAC.ForeColor = clNormalLableColor;
            }

            string stItemActive = "Y";
            if (!this.ckProductIsActive.Checked)
                stItemActive = "N";

            if (dtProductInfor.Rows[0]["ISACTIVE"].ToString() !=
                stItemActive)
            {
                this.ckProductIsActive.ForeColor = clChangedLableColor;
                blFoundChage = true;
            }
            else
            {
                this.ckProductIsActive.ForeColor = clNormalLableColor;
            }

            if (dtProductInfor.Rows[0]["PRODUCTTYPE"].ToString() !=
                this.cmbProductType.SelectedItem.ToString().Substring(0,1).ToUpperInvariant())
            {
                this.lblProductType.ForeColor = clChangedLableColor;
                blFoundChage = true;
            }
            else
            {
                this.lblProductType.ForeColor = clNormalLableColor;
            }

            if (dtProductInfor.Rows[0]["IMAGEPATH"].ToString() !=
                this.pbProductImage.ImageLocation)
            {
                this.lblProductImageBox.ForeColor = clChangedLableColor;
                blFoundChage = true;
            }
            else
            {
                this.lblProductImageBox.ForeColor = clNormalLableColor;
            }

            if (dtProductInfor.Rows[0]["PURCHASEPRICE"].ToString() !=
                this.ntbPurchasePrice.Amount)
            {
                this.lblProductPurchasePrice.ForeColor = clChangedLableColor;
                blFoundChage = true;
            }
            else
            {
                this.lblProductPurchasePrice.ForeColor = clNormalLableColor;
            }

            if (dtProductInfor.Rows[0]["SELLINGPRICE"].ToString() !=
                this.ntbSellingPrice.Amount)
            {
                this.lblProductSellingPrice.ForeColor = clChangedLableColor;
                blFoundChage = true;
            }
            else
            {
                this.lblProductSellingPrice.ForeColor = clNormalLableColor;
            }

            if (this.cmbProductUOM.SelectedIndex <
                this.dtExistingActiveUOM.Rows.Count)
            {
                if (dtProductInfor.Rows[0]["M_UOM_ID"].ToString() !=
                    this.dtExistingActiveUOM.
                        Rows[this.cmbProductUOM.SelectedIndex]["M_UOM_ID"].ToString())
                {
                    this.lblProductUOM.ForeColor = clChangedLableColor;
                    blFoundChage = true;
                }
                else
                {
                    this.lblProductUOM.ForeColor = clNormalLableColor;
                }
            }
            else
            {
                this.lblProductUOM.ForeColor = clNormalLableColor; 
            }

            if (this.cmbProductCategory.SelectedIndex <
                this.dtExistingActiveProductCategory.Rows.Count)
            {
                if (dtProductInfor.Rows[0]["M_PRODUCTCATEGORY_ID"].ToString() !=
                    this.dtExistingActiveProductCategory.
                        Rows[this.cmbProductCategory.SelectedIndex]
                            ["M_PRODUCTCATEGORY_ID"].ToString())
                {
                    this.lblProductCategory.ForeColor = clChangedLableColor;
                    blFoundChage = true;
                }
                else
                {
                    this.lblProductCategory.ForeColor = clNormalLableColor;
                }
            }
            else
            {
                this.lblProductCategory.ForeColor = clNormalLableColor;
            }


            return blFoundChage;
 
        }

        private void normalizeLableForeColor()
        {
            this.lblProductCode.ForeColor = clNormalLableColor;
            this.lblProductName.ForeColor = clNormalLableColor;
            this.lblProductUPCEAC.ForeColor = clNormalLableColor;
            this.ckProductIsActive.ForeColor = clNormalLableColor;
            this.lblProductType.ForeColor = clNormalLableColor;
            this.lblProductImageBox.ForeColor = clNormalLableColor;
            this.lblProductPurchasePrice.ForeColor = clNormalLableColor;
            this.lblProductSellingPrice.ForeColor = clNormalLableColor;
            this.lblProductUOM.ForeColor = clNormalLableColor;
            this.lblProductUOM.ForeColor = clNormalLableColor;
            this.lblProductCategory.ForeColor = clNormalLableColor;
            this.lblProductCategory.ForeColor = clNormalLableColor;
        }


        private void fillProductCategoryAndUOMComboboxs()
        {
            for (int rowCounter = 0;
               rowCounter < this.dtExistingActiveProductCategory.Rows.Count;
               rowCounter++)
                this.cmbProductCategory.Items.Insert(rowCounter, this.
                    dtExistingActiveProductCategory.Rows[rowCounter]["NAME"].ToString());

            for (int rowCounter = 0;
                rowCounter < this.dtExistingActiveUOM.Rows.Count;
                rowCounter++)
                this.cmbProductUOM.Items.Insert(rowCounter, this.
                    dtExistingActiveUOM.Rows[rowCounter]["NAME"].ToString());

            this.cmbProductType.SelectedIndex = 0;
            if (this.cmbProductCategory.Items.Count > 0)
                this.cmbProductCategory.SelectedIndex = 0;
            if (this.cmbProductUOM.Items.Count > 0)
                this.cmbProductUOM.SelectedIndex = 0;

        }

        private void fillUnitConversionBox()
        {
            this.dtProductUnitConversionRate.Rows.Clear();

            if (this.intProductID == 0 || this.intUOMId == 0)
                return;

            DataTable dtCurrentProductOtherUnitConversion = new DataTable();
                        
            DataRow drNewProductUnitConversion;
            DataTable dtUnitInfo = new DataTable();
            
            for (int rowCounter = 0; 
                 rowCounter <= this.dtExistingActiveUOM.Rows.Count - 1; rowCounter++)
            {
                if (this.dtExistingActiveUOM.Rows[rowCounter]["M_UOM_ID"].ToString() ==
                    this.intUOMId.ToString())
                    continue;

                string stUOMID =
                    this.dtExistingActiveUOM.Rows[rowCounter]["M_UOM_ID"].ToString();

                dtUnitInfo =
                    this.getDatafromDataBase.getM_UOMInfo(null, "",
                                    stUOMID, "", "", triStateBool.ignor, false, "AND");

                if (dtUnitInfo.Rows.Count <= 0)
                    continue;

                drNewProductUnitConversion =
                    this.dtProductUnitConversionRate.NewRow();

                drNewProductUnitConversion["Unit"] =
                        dtUnitInfo.Rows[0]["ABBREVATION"].ToString();

                drNewProductUnitConversion["M_BASE_UOM_ID"] = stUOMID;
                drNewProductUnitConversion["M_DRIVED_UOM_ID"] = this.intUOMId.ToString();

                drNewProductUnitConversion["Rate"] = "0";
                
                dtCurrentProductOtherUnitConversion =
                    this.getDatafromDataBase.getM_UOM_CONVERSIONInfo(null,
                                    "", this.intUOMId.ToString(),
                                    stUOMID,
                                    this.intProductID.ToString(), 0,
                                    triStateBool.yes, false, "AND");

                if (dtCurrentProductOtherUnitConversion.Rows.Count > 0)
                {
                    drNewProductUnitConversion["M_UOM_CONVERSION_ID"] =
                        dtCurrentProductOtherUnitConversion.
                                Rows[0]["M_UOM_CONVERSION_ID"].ToString();

                    drNewProductUnitConversion["Rate"] =
                        (1 / decimal.Parse(dtCurrentProductOtherUnitConversion.
                                            Rows[0]["MULTIPLIER"].ToString())).ToString();                    
                }
                else
                {

                    dtCurrentProductOtherUnitConversion =
                        this.getDatafromDataBase.getM_UOM_CONVERSIONInfo(null,
                                        "",
                                        stUOMID,
                                        this.intUOMId.ToString(),
                                        this.intProductID.ToString(), 0,
                                        triStateBool.yes, false, "AND");

                    if (dtCurrentProductOtherUnitConversion.Rows.Count > 0)
                    {
                        drNewProductUnitConversion["M_UOM_CONVERSION_ID"] =
                        dtCurrentProductOtherUnitConversion.
                                Rows[0]["M_UOM_CONVERSION_ID"].ToString();

                        drNewProductUnitConversion["Rate"] =
                            dtCurrentProductOtherUnitConversion.
                                    Rows[0]["MULTIPLIER"].ToString();
                    }
                }

                this.dtProductUnitConversionRate.
                        Rows.Add(drNewProductUnitConversion);
            }
        }

        private void saveConversionInfo()
        {
            DataTable dtConversionInfo =
                this.getDatafromDataBase.
                    getM_UOM_CONVERSIONInfo(null, "", "",
                        "", "", 0, triStateBool.ignor, true, "AND");

            DataTable dtConversionInfoToDiscard =
                        this.getDatafromDataBase.
                            getM_UOM_CONVERSIONInfo(null, "", "",
                            "", "", 0, triStateBool.ignor, true, "AND");

            DataRow drNewConversionInfo;

            DataRow drDeleteConversionInfo;

            ctlNumberTextBox converter = new ctlNumberTextBox();

            for (int rowCounter = 0; 
                 this.dtgUnitConversionView.Rows.Count > rowCounter; rowCounter++)
            {
                converter.Amount =
                    this.dtgUnitConversionView.
                        Rows[rowCounter].Cells["Rate"].Value.ToString();

                string conversionId =
                    this.dtgUnitConversionView.Rows[rowCounter].
                                Cells["M_UOM_CONVERSION_ID"].Value.ToString();

                if (converter.Amount == "0" ||
                    converter.Amount == "")
                {
                    if (conversionId == "")
                        continue;
                    drDeleteConversionInfo = 
                        dtConversionInfoToDiscard.NewRow();
                    
                    drDeleteConversionInfo["M_UOM_CONVERSION_ID"] = conversionId;
                    
                    dtConversionInfoToDiscard.Rows.Add(drDeleteConversionInfo);
                    continue;
                }
                
                drNewConversionInfo = dtConversionInfo.NewRow();

                if(conversionId != "")
                    drNewConversionInfo["M_UOM_CONVERSION_ID"] = conversionId;

                drNewConversionInfo["M_BASE_UOM_ID"] = 
                    this.dtgUnitConversionView.
                        Rows[rowCounter].Cells["M_BASE_UOM_ID"].Value.ToString();

                drNewConversionInfo["M_DRIVED_UOM_ID"] =
                    this.dtgUnitConversionView.
                        Rows[rowCounter].Cells["M_DRIVED_UOM_ID"].Value.ToString();

                drNewConversionInfo["M_PRODUCT_ID"] = this.intProductID;

                drNewConversionInfo["MULTIPLIER"] = converter.Amount;

                dtConversionInfo.Rows.Add(drNewConversionInfo);
            }

            this.getDatafromDataBase.
                        changeDataBaseTableData(dtConversionInfoToDiscard, 
                                                "M_UOM_CONVERSION", "DELETE");
            this.getDatafromDataBase.
                        changeDataBaseTableData(dtConversionInfo, 
                                                "M_UOM_CONVERSION", "UPDATE");
        }


        public void frmProduct_Load(object sender, EventArgs e)
        {
            if (generalResultInformation.currentFormIsReadOnly)
            {
                this.tlsDelete.Visible = false;
                this.tlsNew.Visible = false;
                this.tlsSave.Visible = false;
                this.cmdProductUOMConversion.Visible = false;
            }

            if (frmAccessPrivilages.accFrmInventoryIn == accessLevel.ReadWite)
            {
                this.tlsConductPurchase.Visible = true;
            }
            else
                this.tlsConductPurchase.Visible = false;


            if (frmAccessPrivilages.accFrmInventoryOut == accessLevel.ReadWite)
            {
                this.tlsConductSales.Visible = true;
            }
            else
                this.tlsConductSales.Visible = false;

            if (frmAccessPrivilages.accFrmUOMConversion == accessLevel.ReadWite)
            {
                this.cmdProductUOMConversion.Visible = false;
                this.pnlUnitConversionPanel.Visible = false;
            }
            else
            {
                this.cmdProductUOMConversion.Visible = true;
                this.pnlUnitConversionPanel.Visible = true;
            }

            this.dtExistingActiveProductCategory =
                this.getDatafromDataBase.getM_PRODUCTCATEGORYInfo(null, "",
                    "", "", triStateBool.yes, false, "AND");
            this.dtExistingActiveUOM =
                this.getDatafromDataBase.getM_UOMInfo(null, "",
                    "", "", "", triStateBool.yes, false, "AND");

            this.dtAllProductCategory =
                this.getDatafromDataBase.getM_PRODUCTCATEGORYInfo(null, "",
                    "", "", triStateBool.ignor, false, "AND");
            this.dtAllUOM =
                this.getDatafromDataBase.getM_UOMInfo(null, "",
                    "", "", "", triStateBool.ignor, false, "AND");

            this.fillProductCategoryAndUOMComboboxs();
            this.tlsNew_Click(sender, e);

            this.dtProductUnitConversionRate.Columns.Add("M_UOM_CONVERSION_ID");
            this.dtProductUnitConversionRate.Columns.Add("M_BASE_UOM_ID");
            this.dtProductUnitConversionRate.Columns.Add("M_DRIVED_UOM_ID");
            this.dtProductUnitConversionRate.Columns.Add("Unit");
            this.dtProductUnitConversionRate.Columns.Add("Rate");

            this.dtgUnitConversionView.DataSource = 
                this.dtProductUnitConversionRate;
            this.dtgUnitConversionView.Columns["M_UOM_CONVERSION_ID"].Visible = false;
            this.dtgUnitConversionView.Columns["M_BASE_UOM_ID"].Visible = false;
            this.dtgUnitConversionView.Columns["M_DRIVED_UOM_ID"].Visible = false;

            this.dtgUnitConversionView.Columns["Unit"].ReadOnly = true;

            this.dtExistingProductInformation =
                     this.getDatafromDataBase.getV_PRDUCTCOSTInfo(null, "", "",
                             "", "", "", "", "", "", "", "", 0, 0, 0, 0,
                             triStateBool.ignor,true, "",0);

            this.dtgProductGridView.DataSource = 
                this.dtExistingProductInformation;

            this.dtExistingProductInformation.Columns["CODE"].SetOrdinal(0);
            this.dtExistingProductInformation.Columns["NAME"].SetOrdinal(1);
            this.dtExistingProductInformation.Columns["CURRENTQTY"].SetOrdinal(2);

            this.dtgProductGridView.Columns["M_SHOP_ID"].Visible = false;
            this.dtgProductGridView.Columns["AD_ORG_ID"].Visible = false;
            this.dtgProductGridView.Columns["M_PRODUCT_ID"].Visible = false;
            this.dtgProductGridView.Columns["CREATED"].Visible = false;
            this.dtgProductGridView.Columns["UPDATED"].Visible = false;
            this.dtgProductGridView.Columns["CREATEDBY"].Visible = false;
            this.dtgProductGridView.Columns["UPDATEDBY"].Visible = false;
            this.dtgProductGridView.Columns["M_PRODUCTCATEGORY_ID"].Visible = false;
            this.dtgProductGridView.Columns["M_UOM_ID"].Visible = false;
            this.dtgProductGridView.Columns["IMAGEPATH"].Visible = false;

            this.dtgProductGridView.Columns["DESCRIPTION"].Visible = false;
            this.dtgProductGridView.Columns["PRODUCTTYPE"].Visible = false;
            this.dtgProductGridView.Columns["PURCHASEPRICE"].Visible = false;
            this.dtgProductGridView.Columns["CURRENTCOST"].Visible = false;
            this.dtgProductGridView.Columns["ACCUMULATEDQTY"].Visible = false;
            this.dtgProductGridView.Columns["ACCUMULATEDCOST"].Visible = false;
        }
        
        
        private void tlsNew_Click(object sender, EventArgs e)
        {
            if (this.cmdShowUnitConversion.Text == "hide")
                this.cmdShowUnitConversion_Click(sender, e);

            this.intProductID = 0;

            this.lblProductCode.ForeColor = clNormalLableColor;
            this.lblVendorCode.ForeColor = clNormalLableColor;
            this.lblProductName.ForeColor = clNormalLableColor;
            this.lblProductDescription.ForeColor = clNormalLableColor;
            this.lblProductUPCEAC.ForeColor = clNormalLableColor;

            this.txtProductCode.Text = "";
            this.txtVendorCode.Text = "";
            this.txtProductName.Text = "";
            this.txtProductDescription.Text = "";
            this.txtProductUPCEAN.Text = "";
            this.imageFile = "";
            this.pbProductImage.ImageLocation = "";

            this.ntbPurchasePrice.Amount = "0.00";
            this.ntbSellingPrice.Amount = "0.00";
                
            this.txtProductAccumulatedCost.Text = "0.00";
            this.txtProductAccumulatedQty.Text = "0";
            this.txtProductCurrentCost.Text = "0.00";
            this.txtProductCurrentQty.Text = "0";

            this.fillProductCategoryAndUOMComboboxs();
            this.normalizeLableForeColor();

            this.enableDisableFormElement();
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
            if (this.checkForChangedRecord())
            {
                if(MessageBox.Show("Are you sure you would like to Update the Highlited Items.\n" +
                         " There Could be Serious Information Alteration.",
                    "SRP SAVE Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) !=
                    DialogResult.Yes)
                return; 
            }

            this.normalizeLableForeColor();

            this.dtNewProductInformation =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "", "",
                        "", "","","","","","", triStateBool.ignor,true,"",generalResultInformation.dbBulkDataRetrivalSize);

            DataRow drNewProduct = this.dtNewProductInformation.NewRow();

            if (this.intProductID != 0)
            {
                drNewProduct["M_PRODUCT_ID"] = this.intProductID;
                stTypeOfChange = "UPDATE";
            }
            else
                stTypeOfChange = "INSERT";


            drNewProduct["M_SHOP_ID"] = this.stringShopID;
            drNewProduct["CODE"] = this.txtProductCode.Text;
            drNewProduct["CODE2"] = this.txtVendorCode.Text;
            drNewProduct["NAME"] = this.txtProductName.Text;
            drNewProduct["DESCRIPTION"] = this.txtProductDescription.Text;
            drNewProduct["UPC_EAN"] = this.txtProductUPCEAN.Text;
            drNewProduct["IMAGEPATH"] = this.imageFile;

            if (this.ckProductIsActive.Checked)
                drNewProduct["ISACTIVE"] = "Y";
            else
                drNewProduct["ISACTIVE"] = "N";

            if (this.dtExistingActiveProductCategory.Rows.Count >
                this.cmbProductCategory.SelectedIndex)
            {
                drNewProduct["M_PRODUCTCATEGORY_ID"] =
                    this.dtExistingActiveProductCategory.
                        Rows[this.cmbProductCategory.SelectedIndex]["M_PRODUCTCATEGORY_ID"];
            }
            else if (stTypeOfChange == "INSERT")
            {
                this.lblProductCategory.ForeColor = clErrorLableColor;
                MessageBox.Show("Please complete the missing form element before proceeding.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.dtExistingActiveUOM.Rows.Count >
                this.cmbProductUOM.SelectedIndex)
            {
                drNewProduct["M_UOM_ID"] =
                    this.dtExistingActiveUOM.
                        Rows[this.cmbProductUOM.SelectedIndex]["M_UOM_ID"];
            }
            else if (stTypeOfChange == "INSERT")
            {
                this.lblProductUOM.ForeColor = clErrorLableColor;
                MessageBox.Show("Please complete the missing form element before proceeding.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.cmbProductType.SelectedItem.ToString() == "Item")
                drNewProduct["PRODUCTTYPE"] = "I";
            else
                drNewProduct["PRODUCTTYPE"] = "S";

            drNewProduct["PURCHASEPRICE"] = decimal.Parse(this.ntbPurchasePrice.Amount);
            drNewProduct["SELLINGPRICE"] = decimal.Parse(this.ntbSellingPrice.Amount);

            
            this.dtNewProductInformation.Rows.Add(drNewProduct);

            string[] primaryKeySepartor = { " <(", ")>||" };
            string[] primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                    (this.dtNewProductInformation.Copy(), "M_PRODUCT", stTypeOfChange)[0]
                    .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            if (primaryKey.Length > 1)
            {
                DataTable dtProductCostInformation = 
                    this.getDatafromDataBase.getQ_COSTInfo(null, "", "", 0, 0, 0, 0,
                        triStateBool.ignor, true, "",generalResultInformation.dbBulkDataRetrivalSize);

                DataRow drProductCostInfo = dtProductCostInformation.NewRow();

                drProductCostInfo["M_PRODUCT_ID"] = primaryKey[1];
                drProductCostInfo["M_SHOP_ID"] = this.stringShopID;
                if (this.ckProductIsActive.Checked)
                    drProductCostInfo["ISACTIVE"] = "Y";
                else
                    drProductCostInfo["ISACTIVE"] = "N";

                drProductCostInfo["CURRENTQTY"] = 
                    this.txtProductCurrentQty.Text.Replace(",", "");
                drProductCostInfo["CURRENTCOST"] = 
                    this.txtProductCurrentCost.Text.Replace(",", "");
                drProductCostInfo["ACCUMULATEDQTY"] = 
                    this.txtProductAccumulatedQty.Text.Replace(",", "");
                drProductCostInfo["ACCUMULATEDCOST"] = 
                    this.txtProductAccumulatedCost.Text.Replace(",","");

                dtProductCostInformation.Rows.Add(drProductCostInfo);

                this.getDatafromDataBase.changeDataBaseTableData
                    (dtProductCostInformation.Copy(), "Q_COST", "INSERT");
            }
            
            if (primaryKey.Length > 1 && stTypeOfChange == "INSERT")
            {
                this.intProductID = int.Parse(primaryKey[1]);
                DataTable dtNewItemRecord =
                     this.getDatafromDataBase.getV_PRDUCTCOSTInfo(null, "", primaryKey[1],
                             "", "", "", "", "", "", "", "", 0, 0, 0, 0,
                             triStateBool.ignor, false, "AND", generalResultInformation.dbBulkDataRetrivalSize);

                if (dtNewItemRecord.Rows.Count > 0)
                {
                    DataRow drNewItemRow = this.dtExistingProductInformation.NewRow();
                    for (int columnCounter = 0; 
                        columnCounter < this.dtExistingProductInformation.Columns.Count; 
                        columnCounter++)
                    {
                        drNewItemRow[columnCounter] =
                            dtNewItemRecord.Rows[0][this.dtExistingProductInformation.Columns[columnCounter].ColumnName]; 
                    }
                    this.dtExistingProductInformation.Rows.Add(drNewItemRow);
                }

                this.dtgProductGridView.DataSource = this.dtExistingProductInformation;
                if (this.dtExistingProductInformation.Rows.Count > 0)
                    this.dtgProductGridView.
                        Rows[this.dtExistingProductInformation.Rows.Count - 1].Selected = true;
            }
            if (stTypeOfChange == "UPDATE")
                this.saveConversionInfo();

            this.enableDisableFormElement();
        }

        private void tlsSearch_Click(object sender, EventArgs e)
        {
            this.dtExistingProductInformation.Rows.Clear();
            this.tlsNew_Click(sender, e);
            frmSearchProduct frmPrdSrchResult = new frmSearchProduct();
            generalResultInformation.searchResult.Clear();
            frmPrdSrchResult.ShowDialog();
            if (generalResultInformation.searchResult.Rows.Count > 0)
                this.dtExistingProductInformation = 
                    generalResultInformation.searchResult.Copy();
            
            this.dtgProductGridView.DataSource = 
                this.dtExistingProductInformation;
            if (this.dtExistingProductInformation.Rows.Count > 0)
                this.dtgProductGridView.Rows[0].Selected = true;
        }

        private void tlsConductPurchase_Click(object sender, EventArgs e)
        {
            if (this.intProductID == 0)
                return;
            shortTransactionInformation.stProductId = this.intProductID.ToString();
            shortTransactionInformation.ttTransactionType = transactionType.InventoryIn;

            frmConductTrxCutWay frmNewItemPurchase = new frmConductTrxCutWay();
            frmNewItemPurchase.ShowDialog();
            if (shortTransactionInformation.transactionConducted)
            {
                this.dtExistingProductInformation.Rows.Clear();
                //this.tlsNew_Click(sender, e);
            }
        }

        private void tlsConductSales_Click(object sender, EventArgs e)
        {
            if (this.intProductID == 0)
                return;
            shortTransactionInformation.stProductId = this.intProductID.ToString();
            shortTransactionInformation.ttTransactionType = transactionType.InventoryOut;

            frmConductTrxCutWay frmNewItemPurchase = new frmConductTrxCutWay();
            frmNewItemPurchase.ShowDialog();
            if (shortTransactionInformation.transactionConducted)
                this.dtExistingProductInformation.Rows.Clear();

        }

        private void tlsShowCrruntItemTransaction_Click(object sender, EventArgs e)
        {
            generalResultInformation.selectedProductId =
                this.intProductID.ToString();
            frmItemTransactionHistory frmCrrItemTrxHstry = new frmItemTransactionHistory();
            frmCrrItemTrxHstry.ShowDialog();
        }


        private void pbProductImage_Click(object sender, EventArgs e)
        {
            this.pbProductImage.ImageLocation = "";
            this.imageFile = " ";
            this.ofdLoadItemImage.ShowDialog();
            this.imageFile = this.ofdLoadItemImage.FileName;
            if (System.IO.File.Exists(this.imageFile))
                this.pbProductImage.ImageLocation = this.imageFile;
            else
            {
                this.pbProductImage.ImageLocation = "";
                this.imageFile = " ";
            }
        }
               
        private void dtgProductGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgProductGridView.SelectedRows.Count < 1)
            {
                return;
            }

            ctlNumberTextBox ntbConverter = new ctlNumberTextBox();

            int selectedProductIndex =
                this.dtgProductGridView.SelectedRows[0].Index;
            this.intProductID =
                int.Parse(this.dtgProductGridView.Rows[selectedProductIndex].
                            Cells["M_PRODUCT_ID"].Value.ToString());
            this.txtProductName.Text =
                this.dtgProductGridView.Rows[selectedProductIndex].
                     Cells["NAME"].Value.ToString();
            this.txtProductDescription.Text =
                this.dtgProductGridView.Rows[selectedProductIndex].
                    Cells["DESCRIPTION"].Value.ToString();
            this.txtProductCode.Text =
                this.dtgProductGridView.Rows[selectedProductIndex].
                    Cells["CODE"].Value.ToString();
            this.txtVendorCode.Text =
                this.dtgProductGridView.Rows[selectedProductIndex].
                    Cells["CODE2"].Value.ToString();
            this.txtProductUPCEAN.Text =
                this.dtgProductGridView.Rows[selectedProductIndex].
                    Cells["UPC_EAN"].Value.ToString();
            ntbConverter.Amount =
                this.dtgProductGridView.Rows[selectedProductIndex].
                    Cells["CURRENTCOST"].Value.ToString();
            this.txtProductCurrentCost.Text = ntbConverter.Value;

            ntbConverter.Amount =
                this.dtgProductGridView.Rows[selectedProductIndex].
                    Cells["CURRENTQTY"].Value.ToString();
            this.txtProductCurrentQty.Text = ntbConverter.Value;

            ntbConverter.Amount =
                this.dtgProductGridView.Rows[selectedProductIndex].
                    Cells["ACCUMULATEDCOST"].Value.ToString();
            this.txtProductAccumulatedCost.Text = ntbConverter.Value;

            ntbConverter.Amount =
                this.dtgProductGridView.Rows[selectedProductIndex].
                    Cells["ACCUMULATEDQTY"].Value.ToString();
            this.txtProductAccumulatedQty.Text = ntbConverter.Value;

            this.ntbPurchasePrice.Amount =
                this.dtgProductGridView.Rows[selectedProductIndex].
                    Cells["PURCHASEPRICE"].Value.ToString();

            this.ntbSellingPrice.Amount =
                this.dtgProductGridView.Rows[selectedProductIndex].
                    Cells["SELLINGPRICE"].Value.ToString();

            if (this.dtgProductGridView.Rows[selectedProductIndex].
                    Cells["ISACTIVE"].Value.ToString() == "Y")
                this.ckProductIsActive.Checked = true;
            else
                this.ckProductIsActive.Checked = false;

            if (this.dtgProductGridView.Rows[selectedProductIndex].
                    Cells["PRODUCTTYPE"].Value.ToString() == "I")
                this.cmbProductType.SelectedItem = "Item";
            else
                this.cmbProductType.SelectedItem = "Service";

            if (this.dtgProductGridView.Rows[selectedProductIndex].
                    Cells["IMAGEPATH"].Value.ToString() != "")
            {
                if (System.IO.File.Exists(this.dtgProductGridView.Rows[selectedProductIndex].
                    Cells["IMAGEPATH"].Value.ToString()))
                    this.pbProductImage.ImageLocation =
                        this.dtgProductGridView.Rows[selectedProductIndex].
                                Cells["IMAGEPATH"].Value.ToString();
                    
                else
                    this.pbProductImage.ImageLocation = "";
            }
            else
                this.pbProductImage.ImageLocation = "";

            this.imageFile =
                        this.pbProductImage.ImageLocation;

            this.intUOMId =
                int.Parse(this.dtgProductGridView.Rows[selectedProductIndex].
                            Cells["M_UOM_ID"].Value.ToString());

            DataTable dtCurrentUOM =
                this.getDatafromDataBase.getM_UOMInfo(null, "",
                    this.dtgProductGridView.Rows[selectedProductIndex].
                        Cells["M_UOM_ID"].Value.ToString(), "", "", 
                              triStateBool.ignor, false, "AND");

            if (dtCurrentUOM.Rows.Count > 0)
            {
                if (dtCurrentUOM.Rows[0]["ISACTIVE"].ToString() == "Y")
                {
                    this.cmbProductUOM.SelectedIndex =
                        this.cmbProductUOM.Items.
                            IndexOf(dtCurrentUOM.Rows[0]["NAME"].ToString());
                }
                else
                {
                    this.cmbProductUOM.Items.Insert(this.cmbProductUOM.Items.Count, 
                        dtCurrentUOM.Rows[0]["NAME"].ToString());
                    this.cmbProductUOM.SelectedIndex =
                        this.cmbProductUOM.Items.Count-1; 
                }
            }


            DataTable dtCurrentProductCategory =
                this.getDatafromDataBase.getM_PRODUCTCATEGORYInfo(null, "",
                    this.dtgProductGridView.Rows[selectedProductIndex].
                        Cells["M_PRODUCTCATEGORY_ID"].Value.ToString(), "",
                              triStateBool.ignor, false, "AND");

            if (dtCurrentProductCategory.Rows.Count > 0)
            {
                if (dtCurrentProductCategory.Rows[0]["ISACTIVE"].ToString() == "Y")
                {
                    this.cmbProductCategory.SelectedIndex =
                        this.cmbProductCategory.Items.
                            IndexOf(dtCurrentProductCategory.
                                Rows[0]["NAME"].ToString());
                }
                else
                {
                    this.cmbProductCategory.Items.Insert(this.cmbProductCategory.Items.Count,
                        dtCurrentProductCategory.Rows[0]["NAME"].ToString());
                    this.cmbProductCategory.SelectedIndex =
                        this.cmbProductCategory.Items.Count-1;
                }
            }

            if (this.cmdShowUnitConversion.Text == "hide")
                this.cmdShowUnitConversion.Text = "show";
            else
                this.cmdShowUnitConversion.Text = "hide";
            this.cmdShowUnitConversion_Click(sender, e);

            this.enableDisableFormElement();
        }


        private void cmbProductCategory_DropDown(object sender, EventArgs e)
        {
            if (this.cmbProductCategory.Items.Count !=
                this.dtExistingActiveProductCategory.Rows.Count)
            {
                this.cmbProductCategory.Items.Clear();
                for (int rowCounter = 0;
                        rowCounter < this.dtExistingActiveProductCategory.Rows.Count;
                        rowCounter++)
                        this.cmbProductCategory.Items.Insert(rowCounter, this.
                            dtExistingActiveProductCategory.Rows[rowCounter]["NAME"].ToString());

            }
        }

        private void cmbProductUOM_DropDown(object sender, EventArgs e)
        {
            if (this.cmbProductUOM.Items.Count !=
                this.dtExistingActiveUOM.Rows.Count)
            {
                this.cmbProductUOM.Items.Clear();
                for (int rowCounter = 0;
                    rowCounter < this.dtExistingActiveUOM.Rows.Count;
                    rowCounter++)
                    this.cmbProductUOM.Items.Insert(rowCounter, this.
                        dtExistingActiveUOM.Rows[rowCounter]["NAME"].ToString());
            }
        }

        private void cmbProductUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.intProductID == 0)
                return;
            if (this.cmbProductUOM.SelectedIndex >= this.dtExistingActiveUOM.Rows.Count)
                return;
            if (this.intUOMId ==
                int.Parse(this.dtExistingActiveUOM.Rows
                    [this.cmbProductUOM.SelectedIndex]["M_UOM_ID"].ToString()))
                return;
            DataTable dtProductInfo =
                    this.getDatafromDataBase.getV_PRDUCTCOSTInfo(null, "",
                        this.intProductID.ToString(), "", "", "", "", "", "",
                          "", "", 0, 0, 0, 0,
                          triStateBool.ignor, false, "AND", generalResultInformation.dbBulkDataRetrivalSize);
            
            if (dtProductInfo.Rows.Count <= 0)
            {
                MessageBox.Show("There Seems to be a problem with this record. Please Try Later Again.",
                    "SRP ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.tlsNew_Click(sender, e);
            }

            DataTable dtUnitConversionInfo =
                this.getDatafromDataBase.getM_UOM_CONVERSIONInfo(null, "",
                    dtProductInfo.Rows[0]["M_UOM_ID"].ToString(),
                    this.dtExistingActiveUOM.Rows
                    [this.cmbProductUOM.SelectedIndex]["M_UOM_ID"].ToString(),
                    this.intProductID.ToString(), 0, triStateBool.yes, false, "AND");

            ctlNumberTextBox converter = new ctlNumberTextBox();

            converter.Amount =
                    dtProductInfo.Rows[0]["ACCUMULATEDCOST"].ToString();
            this.txtProductAccumulatedCost.Text = converter.Value;

            converter.Amount =
                dtProductInfo.Rows[0]["ACCUMULATEDQTY"].ToString();
            this.txtProductAccumulatedQty.Text = converter.Value;

            converter.Amount =
                dtProductInfo.Rows[0]["CURRENTCOST"].ToString();
            this.txtProductCurrentCost.Text = converter.Value;

            converter.Amount =
                dtProductInfo.Rows[0]["CURRENTQTY"].ToString();
            this.txtProductCurrentQty.Text = converter.Value;

            converter.Amount =
                dtProductInfo.Rows[0]["PURCHASEPRICE"].ToString();
            this.ntbPurchasePrice.Amount = converter.Amount;

            converter.Amount =
                dtProductInfo.Rows[0]["SELLINGPRICE"].ToString();
            this.ntbSellingPrice.Amount = converter.Amount;

            if (dtUnitConversionInfo.Rows.Count <= 0)
            {
                dtUnitConversionInfo =
                    this.getDatafromDataBase.getM_UOM_CONVERSIONInfo(null, "",
                        dtProductInfo.Rows[0]["M_UOM_ID"].ToString(),
                        this.dtExistingActiveUOM.Rows
                        [this.cmbProductUOM.SelectedIndex]["M_UOM_ID"].ToString(),"",
                        0, triStateBool.yes, false, "AND");
            }
            
            decimal multiplier = 1;
            if (dtUnitConversionInfo.Rows.Count <= 0)
            {
                goto finalLine;
                
            }
            
            multiplier =
                decimal.Parse(dtUnitConversionInfo.Rows[0]["MULTIPLIER"].ToString());
            converter.Amount =
                (decimal.Parse(this.txtProductAccumulatedCost.Text) * multiplier).ToString();
            this.txtProductAccumulatedCost.Text = converter.Value;

            converter.Amount = 
                (decimal.Parse(this.txtProductAccumulatedQty.Text) * multiplier).ToString();
            this.txtProductAccumulatedQty.Text = converter.Value;

            converter.Amount =
                (decimal.Parse(this.txtProductCurrentCost.Text) * multiplier).ToString();
            this.txtProductCurrentCost.Text = converter.Value;

            converter.Amount =
                (decimal.Parse(this.txtProductCurrentQty.Text) * multiplier).ToString();
            this.txtProductCurrentQty.Text = converter.Value;

            converter.Amount =
                (decimal.Parse(this.ntbPurchasePrice.Amount) * multiplier).ToString();
            this.ntbPurchasePrice.Amount = converter.Amount;

            converter.Amount =
                (decimal.Parse(this.ntbSellingPrice.Amount) * multiplier).ToString();
            this.ntbSellingPrice.Amount = converter.Amount;

            finalLine:
            this.intUOMId =
                int.Parse(this.dtExistingActiveUOM.Rows
                    [this.cmbProductUOM.SelectedIndex]["M_UOM_ID"].ToString());

            if (this.cmdShowUnitConversion.Text == "hide")
                this.cmdShowUnitConversion.Text = "show";
            else
                this.cmdShowUnitConversion.Text = "hide";
            this.cmdShowUnitConversion_Click(sender, e);
        }

        private void cmdProductUOMConversion_Click(object sender, EventArgs e)
        {
            if (this.intProductID <= 0)
                return;
            unitConvesionInformation.stBaseProductId =
                this.intProductID.ToString();

            DataTable dtCurrentUOM =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                    this.intProductID.ToString(), "", "","","","","","",
                        triStateBool.ignor,false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
            if (dtCurrentUOM.Rows.Count == 0)
                return;

            unitConvesionInformation.stBaseUnitId =
                dtCurrentUOM.Rows[0]["M_UOM_ID"].ToString();
            frmUnitConversion frmUntCnvrt = new frmUnitConversion();
            Form frmUntCnrtHolder = new Form();
            frmUntCnrtHolder.AutoSize = true;
            frmUntCnrtHolder.AutoScroll = true;
            frmUntCnrtHolder.Controls.Add(frmUntCnvrt);
            frmUntCnvrt.Dock = DockStyle.Fill;
            frmUntCnvrt.frmUnitConversion_Load(frmUntCnvrt, new EventArgs());
            frmUntCnrtHolder.ShowDialog();
        }

        private void cmdShowUnitConversion_Click(object sender, EventArgs e)
        {
            this.dtProductUnitConversionRate.Rows.Clear();
            
            if (this.cmdShowUnitConversion.Text == "show" &&
                this.intProductID > 0 && this.intUOMId > 0)
            {
                this.fillUnitConversionBox();
                this.cmdShowUnitConversion.Text = "hide";
                this.pnlUnitConversionPanel.Location = new Point(435, 184);
                this.dtgUnitConversionView.Size = new Size(150, 103);
                this.dtgUnitConversionView.Location = new Point(3, 24);
                this.dtgUnitConversionView.Visible = true;
                this.pnlUnitConversionPanel.Size = new Size(148, 130);
            }
            else
            {
                this.cmdShowUnitConversion.Text = "show";
                this.pnlUnitConversionPanel.Location = new Point(435, 223);
                this.dtgUnitConversionView.Size = new Size(20, 20);
                this.dtgUnitConversionView.Location = new Point(3, 3);
                this.dtgUnitConversionView.Visible = false;
                this.pnlUnitConversionPanel.Size = new Size(134, 223);
            }
            this.dtgUnitConversionView.Columns["M_UOM_CONVERSION_ID"].Visible = false;
            this.dtgUnitConversionView.Columns["M_BASE_UOM_ID"].Visible = false;
            this.dtgUnitConversionView.Columns["M_DRIVED_UOM_ID"].Visible = false;
        }
               
    }
}
