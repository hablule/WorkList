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
    public partial class frmSearchProduct : Form
    {
        public frmSearchProduct()
        {
            InitializeComponent();
        }

        string stProductCode = "";

        DataTable searchQuery = new DataTable();
        
        DataTable dtProductInformation = new DataTable();
        DataTable dtAllProductCategory = new DataTable();
        DataTable dtAllUOM = new DataTable();


        private dataBuilder getDatafromDataBase = new dataBuilder();



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


        private void establishSearchCriterion()
        {
            this.searchQuery.Rows.Clear();
            
            if (this.cmbPrdSrchCategoryLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("M_PRODUCTCATEGORY_ID",
                    this.cmbPrdSrchCategoryLogic.SelectedItem.ToString(),
                    this.dtAllProductCategory.
                        Rows[this.cmbPrdSrchCategory.SelectedIndex]
                                    ["M_PRODUCTCATEGORY_ID"].ToString(), "");
            }

            if (this.cmbPrdSrchCodeLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("CODE",
                    this.cmbPrdSrchCodeLogic.SelectedItem.ToString(),
                    this.txtPrdSrchCode.Text,"");
            }

            

            if (this.cmbPrdSrchNameLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("NAME",
                    this.cmbPrdSrchNameLogic.SelectedItem.ToString(),
                    this.txtPrdSrchName.Text,"");
            }

            if (this.cmbPrdSrchTypeLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("PRODUCTTYPE",
                    this.cmbPrdSrchTypeLogic.SelectedItem.ToString(),
                    this.cmbPrdSrchType.SelectedItem.ToString().Substring(0,1).ToUpperInvariant(),"");
            }

            if (this.cmbPrdSrchUOMLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("M_UOM_ID",
                    this.cmbPrdSrchUOMLogic.SelectedItem.ToString(),
                    this.dtAllUOM.
                        Rows[this.cmbPrdSrchUOM.SelectedIndex]["M_UOM_ID"].ToString(), "");
            }

            if (this.cmbPrdSrchUPC_EANLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("UPC_EAN",
                    this.cmbPrdSrchUPC_EANLogic.SelectedItem.ToString(),
                    this.txtPrdSrchUPC_EAN.Text,"");
            }

            if (this.cmbPrdSrchCrrCostLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("CURRENTCOST",
                    this.cmbPrdSrchCrrCostLogic.SelectedItem.ToString(),
                    this.ntbPrdSrchCrrCostFrom.Amount,
                    this.ntbPrdSrchCrrCostTo.Amount);
            }

            if (this.cmbPrdSrchCrrQtyLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("CURRENTQTY",
                    this.cmbPrdSrchCrrQtyLogic.SelectedItem.ToString(),
                    this.ntbPrdSrchCrrQtyFrom.Amount,
                    this.ntbPrdSrchCrrQtyTo.Amount);
            }

            if (this.cmbPrdSrchAccCostLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("ACCUMULATEDCOST",
                    this.cmbPrdSrchAccCostLogic.SelectedItem.ToString(),
                    this.ntbPrdSrchAccCostFrom.Amount,
                    this.ntbPrdSrchAccCostTo.Amount);
            }

            if (this.cmbPrdSrchAccQtyLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("ACCUMULATEDQTY",
                    this.cmbPrdSrchAccQtyLogic.SelectedItem.ToString(),
                    this.ntbPrdSrchAccQtyFrom.Amount,
                    this.ntbPrdSrchAccQtyTo.Amount);
            }

            if (this.ckPrdSrchIsActive.CheckState != CheckState.Indeterminate)
            {
                string stIsActive = "N";
                if (this.ckPrdSrchIsActive.CheckState == CheckState.Checked)
                    stIsActive = "Y";
                this.addMoreCriteria("ISACTIVE", "Equals to", stIsActive, "");
            }
        }

        private void enableDisableValueInsertionBox(string Logic, Control valueInsertionBox)
        {
            if (Logic == "IGNOR")
                valueInsertionBox.Enabled = false;
            else
                valueInsertionBox.Enabled = true;
        }

        private void frmSearchProduct_Load(object sender, EventArgs e)
        {
            this.cmbPrdSrchUPC_EANLogic.SelectedItem = "IGNOR";
            this.cmbPrdSrchUOMLogic.SelectedItem = "IGNOR";
            this.cmbPrdSrchTypeLogic.SelectedItem = "IGNOR";
            this.cmbPrdSrchNameLogic.SelectedItem = "IGNOR";
            this.cmbPrdSrchCrrQtyLogic.SelectedItem = "IGNOR";
            this.cmbPrdSrchCrrCostLogic.SelectedItem = "IGNOR";
            this.cmbPrdSrchCodeLogic.SelectedItem = "IGNOR";
            this.cmbPrdSrchCategoryLogic.SelectedItem = "IGNOR";
            this.cmbPrdSrchAccQtyLogic.SelectedItem = "IGNOR";
            this.cmbPrdSrchAccCostLogic.SelectedItem = "IGNOR";

            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");

            this.dtAllProductCategory =
                this.getDatafromDataBase.getM_PRODUCTCATEGORYInfo(null, "",
                    "", "", triStateBool.ignor, false, "");

            this.dtAllUOM =
                this.getDatafromDataBase.getM_UOMInfo(null, "",
                    "", "", "", triStateBool.ignor, false, "");

            for (int rowCounter = 0; 
                rowCounter <= this.dtAllProductCategory.Rows.Count - 1;
                rowCounter++)
            {
                this.cmbPrdSrchCategory.Items.Insert(rowCounter, 
                    this.dtAllProductCategory.Rows[rowCounter]["NAME"].ToString());
            }

            for (int rowCounter = 0;
               rowCounter <= this.dtAllUOM.Rows.Count - 1;
               rowCounter++)
            {
                this.cmbPrdSrchUOM.Items.Insert(rowCounter,
                    this.dtAllUOM.Rows[rowCounter]["NAME"].ToString());
            }

            
        }


        private void cmbPrdSrchCodeLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbPrdSrchCodeLogic.SelectedItem.ToString(),
                this.txtPrdSrchCode);
        }

        private void cmbPrdSrchNameLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbPrdSrchNameLogic.SelectedItem.ToString(),
                this.txtPrdSrchName);
        }

        private void cmbPrdSrchUPC_EANLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbPrdSrchUPC_EANLogic.SelectedItem.ToString(),
                this.txtPrdSrchUPC_EAN);
        }

        private void cmbPrdSrchCategoryLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbPrdSrchCategoryLogic.SelectedItem.ToString(),
                this.cmbPrdSrchCategory);
        }

        private void cmbPrdSrchUOMLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbPrdSrchUOMLogic.SelectedItem.ToString(),
                this.cmbPrdSrchUOM);
        }

        private void cmbPrdSrchTypeLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbPrdSrchTypeLogic.SelectedItem.ToString(),
                this.cmbPrdSrchType);

        }

        private void cmbPrdSrchCrrQtyLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbPrdSrchCrrQtyLogic.SelectedItem.ToString(),
                this.ntbPrdSrchCrrQtyFrom);

            if (this.cmbPrdSrchCrrQtyLogic.SelectedItem.ToString() == "In between of")
                this.ntbPrdSrchCrrQtyTo.Visible = true;
            else
                this.ntbPrdSrchCrrQtyTo.Visible = false;
        }

        private void cmbPrdSrchCrrCostLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbPrdSrchCrrCostLogic.SelectedItem.ToString(),
                this.ntbPrdSrchCrrCostFrom);

            if (this.cmbPrdSrchCrrCostLogic.SelectedItem.ToString() == "In between of")
                this.ntbPrdSrchCrrCostTo.Visible = true;
            else
                this.ntbPrdSrchCrrCostTo.Visible = false;
        }

        private void cmbPrdSrchAccQtyLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbPrdSrchAccQtyLogic.SelectedItem.ToString(),
                this.ntbPrdSrchAccQtyFrom);

            if (this.cmbPrdSrchAccQtyLogic.SelectedItem.ToString() == "In between of")
                this.ntbPrdSrchAccQtyTo.Visible = true;
            else
                this.ntbPrdSrchAccQtyTo.Visible = false;
        }

        private void cmbPrdSrchAccCostLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbPrdSrchAccCostLogic.SelectedItem.ToString(),
                this.ntbPrdSrchAccCostFrom);

            if (this.cmbPrdSrchAccCostLogic.SelectedItem.ToString() == "In between of")
                this.ntbPrdSrchAccCostTo.Visible = true;
            else
                this.ntbPrdSrchAccCostTo.Visible = false;
        }

        

        private void cmdPrdSrchShowImages_Click(object sender, EventArgs e)
        {            
            generalResultInformation.selectedProductId = "";
            frmProductImage frmProductImageList = new frmProductImage();
            frmProductImageList.ShowDialog();
            this.stProductCode =
                generalResultInformation.selectedProductId;            
        }

        private void cmdPrdSrchShowResult_Click(object sender, EventArgs e)
        {
            string logicalConnector = "AND";
            if (this.ckPrdSrchAllOrAny.Checked)
                logicalConnector = "OR";

            this.establishSearchCriterion();

            this.dtProductInformation =
                this.getDatafromDataBase.getV_PRDUCTCOSTInfo(this.searchQuery.Copy(),
                            logicalConnector, this.stProductCode, "", "", "", "", "", "", "", "",
                            0, 0, 0, 0, triStateBool.ignor, false, logicalConnector, 0);

            if(!this.getDatafromDataBase.checkIfTableContainesData(this.dtProductInformation))
            {
                MessageBox.Show("No Result for current search Criterion.",
                    "SRP Search", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                return;
            }

            generalResultInformation.searchResult.Clear();
            generalResultInformation.searchResult = 
                        this.dtProductInformation.Copy();
            this.Close();
        }
    }
}
