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
    public partial class frmProductImage : Form
    {
        public frmProductImage()
        {
            InitializeComponent();
        }

        private string stImageLocation = "";
        private string stProductID = "";

        bool txtCodeChanged = false;
        bool txtCode2Changed = false;
        bool txtUPC_EANChanged = false;
        bool txtDescriptionChanged = false;
        bool userIsTyping = false;

        const int intMarginBetweenImage = 10;
        bool blDisplayedPicture = false;
        int intNumberOfImagesDipayedAccross = 0;
        int intDisplayedCategoryIndex = 0;
        int intDisplayedStockStatusIndex = 0;
        string stDisplayedProdcutCode = "";
        string stDisplayedProdcutCode2 = "";
        string stDisplayedUPC_EAN = "";
        string stDisplayedProdcutName = "";

        Color clImageBackColor = Color.DarkGray;
        DataTable searchQuery = new DataTable();
        DataTable dtAllActiveProductsOnDisplay = new DataTable();
        DataTable dtProductCostinfo = new DataTable();
        DataTable dtAllProductCategory = new DataTable();

        DataTable dtItemDetailInformation = new DataTable();

        PictureBox pbPrdImage;

        System.Drawing.Size szPictureSize = new Size(176, 157);
        System.Drawing.Point location;
        
        private dataBuilder getDatafromDataBase = new dataBuilder();
        private businessRule getDataAccordingToRule = new businessRule();


        private void addMoreCriteria(string field, string criterion, string valueFrom, string valueTo)
        {
            if (field == "" || criterion == "" || valueFrom == "")
                return;
            if (criterion == "In between of")
            {
                this.addMoreCriteria(field, "Greater or equals to", valueFrom, "");
                this.addMoreCriteria(field, "Lesser or equal to", valueTo, "");
            }
            else
            {
                DataRow criteriaValue = this.searchQuery.NewRow();

                criteriaValue["Field"] = field;
                criteriaValue["Criterion"] = this.generateEquivalentSymbol(criterion);
                if (criteriaValue["Criterion"].ToString().Contains("like"))
                    criteriaValue["Value"] = "%" + valueFrom.ToUpper() + "%";
                else
                    criteriaValue["Value"] = valueFrom;
                this.searchQuery.Rows.Add(criteriaValue);
            }
        }

        private string generateEquivalentSymbol(string symbolInText)
        {
            if (symbolInText == "Equals to")
                return "=";
            if (symbolInText == "Not equals to")
                return "!=";
            if (symbolInText == "Similar to")
                return "like";
            if (symbolInText == "Not Similar to")
                return "not like";
            if (symbolInText == "Greater than")
                return ">";
            if (symbolInText == "Greater or equals to")
                return ">=";
            if (symbolInText == "Less than")
                return "<";
            if (symbolInText == "Lesser or equal to")
                return "<=";
            return "";
        }
        
        
        private void buildProductToDispaly()
        {
            this.dtItemDetailInformation.Rows.Clear();
            if(this.searchQuery.Columns.Count <= 0)
            {
                this.searchQuery.Columns.Add("Field");
                this.searchQuery.Columns.Add("Criterion");
                this.searchQuery.Columns.Add("Value");
            }
            string stProductCategoryID = "";
            string stProductName = "";
            string stProductCode = "";
            string stProductCode2 = "";
            string stUPC_EAN = "";
            this.searchQuery.Rows.Clear();
            DataRow criteriaValue = this.searchQuery.NewRow();
            criteriaValue["Field"] = "CURRENTQTY";
            criteriaValue["Value"] = "0";

            try 
            {
                if (this.tlscmbProductCategory.SelectedIndex > 0)
                {
                    stProductCategoryID =
                        this.dtAllProductCategory.Rows
                            [this.tlscmbProductCategory.SelectedIndex - 1]
                            ["M_PRODUCTCATEGORY_ID"].ToString();
                }
                if (this.tlstxtProductName.Text != "")
                {
                    stProductName = this.tlstxtProductName.Text.Replace(" ", "%");
                }
                if(this.tlstxtProductCode.Text != "")
                {
                    stProductCode = this.tlstxtProductCode.Text.Replace(" ", "%");
                }

                if (this.tlstxtProductCode2.Text != "")
                {
                    stProductCode2 = this.tlstxtProductCode2.Text.Replace(" ", "%");
                }

                if (this.tlstxtUPC_EAN.Text != "")
                {
                    stUPC_EAN = this.tlstxtUPC_EAN.Text.Replace(" ", "%");
                }

                if (this.tlscmbStockStatus.SelectedItem.ToString() == "Stock Equals Zero")
                {
                    criteriaValue["Criterion"] = " = ";
                }
                else if (this.tlscmbStockStatus.SelectedItem.ToString() == "Stock Not Zero")
                {
                    criteriaValue["Criterion"] = " != ";
                }
                else if (this.tlscmbStockStatus.SelectedItem.ToString() == "Stock Above Zero")
                {
                    criteriaValue["Criterion"] = " > ";
                }
                else if (this.tlscmbStockStatus.SelectedItem.ToString() == "Stock Below Zero")
                {
                    criteriaValue["Criterion"] = " < ";
                }

                this.searchQuery.Rows.Add(criteriaValue);

                this.dtAllActiveProductsOnDisplay =
                    this.getDatafromDataBase.getV_PRDUCTCOSTInfo(searchQuery, "AND", "",
                            "", stProductCategoryID, stProductCode, stProductCode2,
                            stProductName, "", stUPC_EAN, "", 0, 0, 0, 0, triStateBool.yes, false, "AND", 
                            generalResultInformation.dbBulkDataRetrivalSize);
            }
            catch
            {
                return;
            }            
        }

        private void insertPrdNameToList()
        {
            this.lbItemNameList.Items.Clear();
            for (int rowCounter = 0;
                    rowCounter <= this.dtAllActiveProductsOnDisplay.Rows.Count - 1;
                    rowCounter++)
            {
                this.lbItemNameList.Items.Add
                    (this.dtAllActiveProductsOnDisplay.Rows[rowCounter]["NAME"].ToString());
            }
        }

        private void displayPicturesOnForm(bool renderPicture)
        {
            int formCurrentWidth = this.pnlImageContainer.Size.Width;
            int numberOfImagesAccross = int.Parse((formCurrentWidth /
                        (szPictureSize.Width + intMarginBetweenImage)).ToString());
            if (numberOfImagesAccross == 0)
                numberOfImagesAccross = 1;

            if (this.tlscmbProductCategory.SelectedIndex == this.intDisplayedCategoryIndex &&
                this.tlscmbStockStatus.SelectedIndex == this.intDisplayedStockStatusIndex &&
                this.tlstxtProductCode.Text == this.stDisplayedProdcutCode &&
                this.tlstxtProductCode2.Text == this.stDisplayedProdcutCode2 &&
                this.tlstxtUPC_EAN.Text == this.stDisplayedUPC_EAN &&
                this.tlstxtProductName.Text == this.stDisplayedProdcutName &&
                this.blDisplayedPicture == renderPicture &&
                this.intNumberOfImagesDipayedAccross == numberOfImagesAccross)
                return;

            if (!(this.tlscmbProductCategory.SelectedIndex == this.intDisplayedCategoryIndex &&
                this.tlscmbStockStatus.SelectedIndex == this.intDisplayedStockStatusIndex &&
                this.tlstxtProductCode.Text == this.stDisplayedProdcutCode &&
                this.tlstxtProductCode2.Text == this.stDisplayedProdcutCode2 &&
                this.tlstxtUPC_EAN.Text == this.stDisplayedUPC_EAN &&
                this.tlstxtProductName.Text == this.stDisplayedProdcutName))
            {
                this.buildProductToDispaly();
                this.insertPrdNameToList();
            }

            

            string stImageLocation = "";
            string stImageName = "";
            string stPrdocutCode = "";
            string stPrdocutName = "";
            int intProductListNavigator = 0;

            this.pnlImageContainer.Controls.Clear();            

            this.location = new Point(2, 2);
           // this.pnlImageContainer.SuspendLayout();
            for (int rowCounter = intProductListNavigator, imageCounter = numberOfImagesAccross-1; 
                    rowCounter <= this.dtAllActiveProductsOnDisplay.Rows.Count - 1;                 
                    rowCounter++, imageCounter--)
            {
                stImageLocation = renderPicture ?
                    this.dtAllActiveProductsOnDisplay.Rows[rowCounter]["IMAGEPATH"].ToString() : "";
                stImageName =
                    this.dtAllActiveProductsOnDisplay.Rows[rowCounter]["M_PRODUCT_ID"].ToString();

                stPrdocutCode =
                    this.dtAllActiveProductsOnDisplay.Rows[rowCounter]["CODE"].ToString();

                stPrdocutName =
                    this.dtAllActiveProductsOnDisplay.Rows[rowCounter]["NAME"].ToString();
                                
                this.pbPrdImage = new PictureBox();
                this.pbPrdImage.Tag = rowCounter;
                this.pbPrdImage.BackColor = clImageBackColor;
                this.pbPrdImage.Size = szPictureSize;
                if (System.IO.File.Exists(stImageLocation))
                    this.pbPrdImage.ImageLocation = stImageLocation;
                
                ToolTip ttp = new ToolTip();
                string tpPrdInfo = stPrdocutCode + "\n" + stPrdocutName;
                ttp.IsBalloon = true;
                ttp.SetToolTip(this.pbPrdImage, tpPrdInfo);

                this.pbPrdImage.Name = stImageName;
                this.pbPrdImage.SizeMode = PictureBoxSizeMode.Zoom;
                this.pbPrdImage.Click += new EventHandler(productImage_Clicked);
                this.pbPrdImage.DoubleClick += new EventHandler(productImage_DoubleClicked);                
                this.pnlImageContainer.Controls.Add(this.pbPrdImage);
                this.pbPrdImage.Location = this.location;
                this.location.X += intMarginBetweenImage + this.szPictureSize.Width;
                
                if (imageCounter == 0)
                {
                    imageCounter = numberOfImagesAccross;
                    this.location.Y += intMarginBetweenImage + szPictureSize.Height;
                    this.location.X = 2;
                }
            }
            //this.pnlImageContainer.ResumeLayout(false);

            this.intNumberOfImagesDipayedAccross = this.tlscmbProductCategory.SelectedIndex;
            this.intDisplayedStockStatusIndex = this.tlscmbStockStatus.SelectedIndex;
            this.stDisplayedProdcutCode = this.tlstxtProductCode.Text;
            this.stDisplayedProdcutCode2 = this.tlstxtProductCode2.Text;
            this.stDisplayedUPC_EAN = this.tlstxtUPC_EAN.Text;
            this.stDisplayedProdcutName = this.tlstxtProductName.Text;
            this.intNumberOfImagesDipayedAccross = numberOfImagesAccross;
            this.blDisplayedPicture = renderPicture;

            this.intDisplayedCategoryIndex = this.tlscmbProductCategory.SelectedIndex;
        }

        private void displayItemDetailInformation()
        {
            this.dtItemDetailInformation.Rows.Clear();
            DataTable dtUserReadableStoreList =
                this.getDataAccordingToRule.getCurrentUserAccessableWarehouse(triStateBool.ignor, 
                            triStateBool.ignor, triStateBool.ignor, triStateBool.ignor,
                            triStateBool.ignor, triStateBool.ignor, triStateBool.yes,
                            triStateBool.yes, "AND");

            if (!this.getDatafromDataBase.checkIfTableContainesData(dtUserReadableStoreList))
            {
                this.dtItemDetailInformation.Rows.Clear();
                return;
            }

            this.searchQuery.Rows.Clear();
            for (int strCounter = 0; strCounter <= dtUserReadableStoreList.Rows.Count - 1; strCounter++)
            {
                this.addMoreCriteria("M_WAREHOUSE_ID", "Equals to",
                    dtUserReadableStoreList.Rows[strCounter]["M_WAREHOUSE_ID"].ToString(),"");
            }
                
            DataTable dtStockInformation =
                this.getDatafromDataBase.
                        getQ_STOCKInfo(this.searchQuery, "OR", this.stProductID, "",
                            triStateBool.yes, false, "AND");

            if (!this.getDatafromDataBase.checkIfTableContainesData(dtStockInformation))
            {
                this.dtItemDetailInformation.Rows.Clear();
                return;
            }

            DataTable dtProductInfo =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "", 
                    this.stProductID, "", "", "", "", "", "", "", triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
            
            string dcProductPrice = "0";
            string stUnit = "";
            string stProductCode = "N/A";
            string stProductName = "N/A";            

            ctlNumberTextBox numberFormater = new ctlNumberTextBox();
            numberFormater.AllowNegative = true;

            if (this.getDatafromDataBase.
                checkIfTableContainesData(dtProductInfo))
            {
                dcProductPrice =
                    dtProductInfo.Rows[0]["SELLINGPRICE"].ToString();
                stProductCode =
                    dtProductInfo.Rows[0]["CODE"].ToString();
                stProductName =
                    dtProductInfo.Rows[0]["NAME"].ToString();

                numberFormater.Amount = dcProductPrice;
                dcProductPrice = numberFormater.Amount;
                
                DataTable dtUnitInfo =
                    this.getDatafromDataBase.getM_UOMInfo(null, "",
                        dtProductInfo.Rows[0]["M_UOM_ID"].ToString(), "", "",
                            triStateBool.ignor, false, "AND");

                if (this.getDatafromDataBase.checkIfTableContainesData(dtUnitInfo))
                {
                    stUnit = dtUnitInfo.Rows[0]["ABBREVATION"].ToString();
                    numberFormater.StandardPrecision =
                        int.Parse(dtUnitInfo.Rows[0]["STDPRECISION"].ToString());
                }
            }

            for (int rowCounter = 0; 
                rowCounter <= dtStockInformation.Rows.Count - 1; rowCounter++)
            {
                DataTable dtWarehouseInfo =
                    this.getDatafromDataBase.getM_WarehouseInfo(null, "",
                        dtStockInformation.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString(),
                        "", triStateBool.ignor, triStateBool.ignor, false, "AND");
                string storeName = "N/A";
                if (this.getDatafromDataBase.checkIfTableContainesData(dtWarehouseInfo))
                {
                    storeName = dtWarehouseInfo.Rows[0]["NAME"].ToString();
                }

                DataRow drNewItemDetailInfo = this.dtItemDetailInformation.NewRow();

                drNewItemDetailInfo["Code"] = stProductCode;
                drNewItemDetailInfo["Name"] = stProductName;
                
                drNewItemDetailInfo["Price"] = dcProductPrice;
                drNewItemDetailInfo["Warehouse"] = storeName;
                numberFormater.Amount =
                    dtStockInformation.Rows[rowCounter]["CURRENTQTY"].ToString();
                drNewItemDetailInfo["Stock Qty"] = numberFormater.Value;

                this.dtItemDetailInformation.Rows.Add(drNewItemDetailInfo);
            }
            this.dtgItemDetailInfo.DataSource = this.dtItemDetailInformation;

        }


        private void frmProductImage_Load(object sender, EventArgs e)
        {            
            this.tlscmbProductCategory.Items.Insert(this.tlscmbProductCategory.Items.Count, "-ALL Category-");
            
            this.dtAllProductCategory =
                this.getDatafromDataBase.
                        getM_PRODUCTCATEGORYInfo(null, "", "", 
                            "", triStateBool.ignor, false, "AND");
            for (int rowCounter = 0; 
                rowCounter <= dtAllProductCategory.Rows.Count - 1; 
                rowCounter++)
            {
                this.tlscmbProductCategory.Items.Insert(this.tlscmbProductCategory.Items.Count,
                            this.dtAllProductCategory.Rows[rowCounter]["NAME"].ToString());
            }

            if (this.searchQuery.Columns.Count <= 0)
            {
                this.searchQuery.Columns.Add("Field");
                this.searchQuery.Columns.Add("Criterion");
                this.searchQuery.Columns.Add("Value");
            }

            this.tlscmbStockStatus.SelectedIndex =
                this.tlscmbStockStatus.Items.IndexOf("Stock Above Zero");

            this.tlscmbProductCategory.SelectedIndex =
                this.tlscmbProductCategory.Items.IndexOf("-ALL Category-");

            this.dtItemDetailInformation.Columns.Add("Code");
            this.dtItemDetailInformation.Columns.Add("Name");
            this.dtItemDetailInformation.Columns.Add("Price");
            this.dtItemDetailInformation.Columns.Add("Warehouse");
            this.dtItemDetailInformation.Columns.Add("Stock Qty");

            this.dtgItemDetailInfo.DataSource = this.dtItemDetailInformation;

            this.displayPicturesOnForm(false);
        }
           
        private void productImage_Clicked(object sender, EventArgs e)
        {
            PictureBox currentImageBox = (PictureBox)sender;
            this.stProductID = currentImageBox.Name;
            this.displayItemDetailInformation();
            this.stImageLocation = currentImageBox.ImageLocation;
            this.lbItemNameList.SelectedIndex = 
                int.Parse(currentImageBox.Tag.ToString());
                       
        }

        private void pnlImageContainer_SizeChanged(object sender, EventArgs e)
        {
            this.displayPicturesOnForm(false);
        }
        

        private void tlsProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.displayPicturesOnForm();
            this.blDisplayedPicture = false;
        }
     
        private void tlscmbStockStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.displayPicturesOnForm();
            this.blDisplayedPicture = false;
        }

        private void tlstxtProductCode_TextChanged(object sender, EventArgs e)
        {
            this.blDisplayedPicture = false;
            if (this.tlstxtProductCode.Text == "")
            {
                this.txtCodeChanged = true;
                this.userIsTyping = true;
                // this.displayPicturesOnForm();
                return;
            }
            if (this.tlstxtProductCode.Text.Replace(" ", "") == "")
                return;
            // this.displayPicturesOnForm();
            this.txtCodeChanged = true;
            this.userIsTyping = true;            
        }

        private void tlstxtProductCode2_TextChanged(object sender, EventArgs e)
        {
            this.blDisplayedPicture = false;
            if (this.tlstxtProductCode2.Text == "")
            {
                this.txtCode2Changed = true;
                this.userIsTyping = true;
                // this.displayPicturesOnForm();
                return;
            }
            if (this.tlstxtProductCode2.Text.Replace(" ", "") == "")
                return;
            // this.displayPicturesOnForm();
            this.txtCode2Changed = true;
            this.userIsTyping = true;
        }

        private void tlstxtUPC_EAN_TextChanged(object sender, EventArgs e)
        {
            this.blDisplayedPicture = false;
            if (this.tlstxtUPC_EAN.Text == "")
            {
                this.txtUPC_EANChanged = true;
                this.userIsTyping = true;
                // this.displayPicturesOnForm();
                return;
            }
            if (this.tlstxtUPC_EAN.Text.Replace(" ", "") == "")
                return;
            // this.displayPicturesOnForm();
            this.txtUPC_EANChanged = true;
            this.userIsTyping = true;
        }          

        private void tlstxtProductName_TextChanged(object sender, EventArgs e)
        {
            this.blDisplayedPicture = false;
            if (this.tlstxtProductName.Text == "")
            {
                //this.displayPicturesOnForm();
                this.txtDescriptionChanged = true;
                this.userIsTyping = true;
                return;
            }

            if (this.tlstxtProductName.Text.Replace(" ", "") == "")
                return;
            // this.displayPicturesOnForm();
            this.txtDescriptionChanged = true;
            this.userIsTyping = true;
        }
        

        private void productImage_DoubleClicked(object sender, EventArgs e)
        {
            PictureBox currentImageBox = (PictureBox)sender;
            generalResultInformation.selectedProductId = currentImageBox.Name;
            this.Close();           
        }
        
        private void lbItemNameList_Click(object sender, EventArgs e)
        {
            if (this.lbItemNameList.SelectedIndex >=
                    this.lbItemNameList.Items.Count ||
                this.lbItemNameList.SelectedIndex < 0)
                return;
                        
            this.stProductID =
                this.dtAllActiveProductsOnDisplay.
                    Rows[this.lbItemNameList.SelectedIndex]
                        ["M_PRODUCT_ID"].ToString();

            this.displayPicturesOnForm(true);

            this.displayItemDetailInformation();
            
            this.stImageLocation =
                this.dtAllActiveProductsOnDisplay.
                    Rows[this.lbItemNameList.SelectedIndex]["IMAGEPATH"].ToString();
            
            this.pnlImageContainer.Controls[stProductID].Select();
            this.lbItemNameList.Focus();
        }

        private void lbItemNameList_DoubleClick(object sender, EventArgs e)
        {
            if (this.lbItemNameList.SelectedIndex >=
                    this.lbItemNameList.Items.Count ||
                this.lbItemNameList.SelectedIndex < 0)
                return;

            string productId =
                this.dtAllActiveProductsOnDisplay.
                    Rows[this.lbItemNameList.SelectedIndex]["M_PRODUCT_ID"].ToString();
            
            generalResultInformation.selectedProductId = productId;

            this.Close();
        }

        private void dtgItemDetailInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgItemDetailInfo.SelectedRows.Count <= 0)
                return;

            string productId =
                this.dtAllActiveProductsOnDisplay.
                    Rows[this.lbItemNameList.SelectedIndex]["M_PRODUCT_ID"].ToString();

            generalResultInformation.selectedProductId = productId;

            this.Close();
        }

        private void tmrRequestEnded_Tick(object sender, EventArgs e)
        {
            if (this.userIsTyping)            
                this.userIsTyping = false;
            else
                this.displayPicturesOnForm(false || this.blDisplayedPicture);
        }

              
        
    }
}
