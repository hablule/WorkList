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
    public partial class frmSearchBOM : Form
    {
        public frmSearchBOM()
        {
            InitializeComponent();
        }


        businessRule getData = new businessRule();
        dataBuilder getDataFromDb = new dataBuilder();

        DataTable searchQuery = new DataTable();
        
        string stSearchQuery = "";
        string logicalConnector = "AND";


        private void insetDataIntoComboBox(ComboBox _comboBoxContorl, DataTable dataSourceTable,
            int columnIndexToFeed, int selectedIndex)
        {
            if (!getDataFromDb.checkIfTableContainesData(dataSourceTable))
                return;

            if (!dataSourceTable.Columns.Contains("_Index"))
                dataSourceTable.Columns.Add("_Index", System.Type.GetType("System.Int16"));

            for (int rowCounter = 0; rowCounter < dataSourceTable.Rows.Count; rowCounter++)
            {
                dataSourceTable.Rows[rowCounter]["_Index"] = rowCounter;
            }
            for (int rowCounter = 0; rowCounter < dataSourceTable.Rows.Count; rowCounter++)
            {
                _comboBoxContorl.Items.Insert(Convert.ToInt16(dataSourceTable.Rows[rowCounter]["_Index"]),
                    dataSourceTable.Rows[rowCounter][columnIndexToFeed].ToString());
            }
            if (selectedIndex >= 0 &&
                selectedIndex < _comboBoxContorl.Items.Count)
                _comboBoxContorl.SelectedIndex = selectedIndex;
        }

        private void enableDisableValueInsertionBox(string Logic, Control valueInsertionBox)
        {
            if (Logic == "IGNOR")
                valueInsertionBox.Enabled = false;
            else
                valueInsertionBox.Enabled = true;
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
                if (criteriaValue["Criterion"].ToString() == "like")
                    criteriaValue["Value"] = "%" + valueFrom.ToUpper() + "%";
                else
                    criteriaValue["Value"] = valueFrom;
                this.searchQuery.Rows.Add(criteriaValue);
            }

        }

        private void establishSearchCriterion()
        {
            this.searchQuery.Clear();

           

            if (this.cmbProductLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgProduct.SelectedRowKey != null)
            {
                this.addMoreCriteria("M_PRODUCT_ID", this.cmbProductLogic.SelectedItem.ToString(),
                    this.ddgProduct.SelectedRowKey.ToString(), "");
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
            if (symbolInText == "Not similar to")
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



        private void frmSearchBOM_Load(object sender, EventArgs e)
        {
           
            this.cmbProductLogic.SelectedItem = "IGNOR";
            
            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");
            

            //this.ckAllOrAny.Checked = true;
            generalResultInformation.searchResult.Clear();
            generalResultInformation.searchCritrion.Clear();

        }


        private void cmbProductLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbProductLogic.SelectedItem.ToString(),
                this.ddgProduct);
        }

        private void ddgProduct_SelectedItemClicked(object sender, EventArgs e)
        {
            DataTable productInformation =
               getData.getProducts(true, false, triStateBool.ignor, triStateBool.ignor, 
                            triStateBool.ignor, triStateBool.yes, triStateBool.ignor,
                            true, this.ddgProduct.SelectedItem, "", true);

            ddgProduct.DataSource = productInformation;
            ddgProduct.DataTablePrimaryKey = Convert.ToUInt16(productInformation.Columns.IndexOf("M_PRODUCT_ID"));
            ddgProduct.SelectedColomnIdex = productInformation.Columns.IndexOf("NAME");
            int[] hiddenProductColumns = { productInformation.Columns.IndexOf("C_UOM_ID"), 
                                             productInformation.Columns.IndexOf("M_PRODUCT_CATEGORY_ID") };
            ddgProduct.HiddenColoumns = hiddenProductColumns;
        }


        private void ckAllOrAny_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckAllOrAny.Checked)
                this.logicalConnector = "OR";
            else
                this.logicalConnector = "AND"; 
        }

        
        private void cmbSearchAndIncludeToPreviousResult_Click(object sender, EventArgs e)
        {
            DialogResult considerPreviousCriteria =
                MessageBox.Show("Should New Search Result Consider Previous Criterion",
                        "Look Up", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (considerPreviousCriteria == DialogResult.Cancel)
                return;

            this.Enabled = false;

            DataTable currentSearchCriteriaResult = new DataTable();
            string columnNameToCompareWith = "C_ORDERLINE_ID";

            this.establishSearchCriterion();

            currentSearchCriteriaResult =
                this.getDataFromDb.getM_PRODUCT_BOMInfo(this.searchQuery, this.logicalConnector, "",
                            "", "", false, false, "AND");


            if (considerPreviousCriteria == DialogResult.Yes)
            {
                if (!this.getDataFromDb.checkIfTableContainesData
                (currentSearchCriteriaResult))
                {
                    MessageBox.Show("No Record Found For Search Query",
                        "Look Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    generalResultInformation.searchResult.Clear();
                    this.Enabled = true;
                    return;
                }
                generalResultInformation.searchResult =
                    this.getDataFromDb.mergeTables(generalResultInformation.searchResult,
                    currentSearchCriteriaResult, columnNameToCompareWith, true);
            }

            else if (considerPreviousCriteria == DialogResult.No)
            {
                generalResultInformation.searchResult =
                    this.getDataFromDb.mergeTables(generalResultInformation.searchResult,
                    currentSearchCriteriaResult, columnNameToCompareWith, false);
            }
            this.Enabled = true;

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            //this.establishSearchCriterion();
            generalResultInformation.searchCritrion = this.searchQuery;
            generalResultInformation.logicConnector = this.logicalConnector;

            if (!this.getDataFromDb.checkIfTableContainesData
                (generalResultInformation.searchResult))
            {
                MessageBox.Show("No Record Found For Search Query",
                    "Look Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Enabled = true;
                return;
            }



            DataTable dtproductInfo;

            generalResultInformation.searchResult.Columns.Add("Product");
            generalResultInformation.searchResult.Columns.Add("ComponentName");
            generalResultInformation.searchResult.Columns.Add("Unit");

            for (int rowCounter = 0; rowCounter <= generalResultInformation.searchResult.Rows.Count - 1;
                rowCounter++)
            {

                dtproductInfo =
                    this.getDataFromDb.getEM_M_PRODUCTInfo(null, "",
                            generalResultInformation.searchResult.Rows[rowCounter]["M_PRODUCTBOM_ID"].ToString(),
                            false, triStateBool.ignor,
                            triStateBool.ignor, triStateBool.ignor, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(dtproductInfo))
                {
                    generalResultInformation.searchResult.Rows[rowCounter]["ComponentName"] = "N/A";
                    generalResultInformation.searchResult.Rows[rowCounter]["Unit"] = "N/A";
                }
                else
                {
                    generalResultInformation.searchResult.Rows[rowCounter]["ComponentName"] =
                        dtproductInfo.Rows[0]["NAME"].ToString();

                    dtproductInfo = this.getDataFromDb.getEM_C_UOMInfo(null, "",
                            dtproductInfo.Rows[0]["C_UOM_ID"].ToString(), false, false, "AND");

                    if (!this.getDataFromDb.checkIfTableContainesData(dtproductInfo))
                    {
                        generalResultInformation.searchResult.Rows[rowCounter]["Unit"] = "N/A";
                    }
                    else
                    {
                        generalResultInformation.searchResult.Rows[rowCounter]["Unit"] =
                            dtproductInfo.Rows[0]["NAME"].ToString();
                    }

                }

                if (rowCounter > 0)
                {
                    if (generalResultInformation.searchResult.Rows[rowCounter]["M_PRODUCTBOM_ID"].ToString() !=
                       generalResultInformation.searchResult.Rows[rowCounter]["M_PRODUCTBOM_ID"].ToString())
                    {
                        dtproductInfo =
                            this.getDataFromDb.getEM_M_PRODUCTInfo(null, "",
                                generalResultInformation.searchResult.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                                false, triStateBool.ignor,
                                triStateBool.ignor, triStateBool.ignor, false, "AND");

                        if (!this.getDataFromDb.checkIfTableContainesData(dtproductInfo))
                        {
                            generalResultInformation.searchResult.Rows[rowCounter]["Product"] = "N/A";
                        }
                        else
                        {
                            generalResultInformation.searchResult.Rows[rowCounter]["Product"] =
                                dtproductInfo.Rows[0]["NAME"].ToString();
                        }

                    }
                    else
                    {
                        generalResultInformation.searchResult.Rows[rowCounter]["Product"] =
                            generalResultInformation.searchResult.Rows[rowCounter - 1]["Product"].ToString();

                    }
                }
                else
                {
                    dtproductInfo =
                           this.getDataFromDb.getEM_M_PRODUCTInfo(null, "",
                               generalResultInformation.searchResult.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                               false, triStateBool.ignor,
                               triStateBool.ignor, triStateBool.ignor, false, "AND");

                    if (!this.getDataFromDb.checkIfTableContainesData(dtproductInfo))
                    {
                        generalResultInformation.searchResult.Rows[rowCounter]["Product"] = "N/A";
                    }
                    else
                    {
                        generalResultInformation.searchResult.Rows[rowCounter]["Product"] =
                            dtproductInfo.Rows[0]["NAME"].ToString();
                    }
                }
            }

            
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("AD_CLIENT_ID"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("AD_ORG_ID"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("ISACTIVE"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("CREATED"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("CREATEDBY"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("UPDATED"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("UPDATEDBY"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("M_PRODUCTBOM_ID"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("DESCRIPTION"));
            generalResultInformation.searchResult.Columns.RemoveAt(generalResultInformation.searchResult.Columns.IndexOf("BOMTYPE"));

            generalResultInformation.searchResult.Columns["M_PRODUCT_BOM_ID"].ColumnName = "C_ORDERLINE_ID";
            generalResultInformation.searchResult.Columns["M_PRODUCT_ID"].ColumnName = "C_ORDER_ID";
            generalResultInformation.searchResult.Columns["Product"].ColumnName = "Customer";
            generalResultInformation.searchResult.Columns["ComponentName"].ColumnName = "Product";
            generalResultInformation.searchResult.Columns["BOMQTY"].ColumnName = "QTYORDERED";

            
            this.Enabled = true;
            this.Close();

        }
               
            
    }
}
