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
    public partial class frmSearchBpartner : Form
    {
        public frmSearchBpartner()
        {
            InitializeComponent();
        }


        string stBpartnerCode = "";

        DataTable searchQuery = new DataTable();

        DataTable dtBpartnerInformation = new DataTable();

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

            if (this.cmbSrchNameLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("NAME",
                    this.cmbSrchNameLogic.SelectedItem.ToString(),
                    this.txtSrchName.Text, "");
            }

            if (this.cmbSrchName2Logic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("NAME2",
                    this.cmbSrchName2Logic.SelectedItem.ToString(),
                    this.txtSrchName2.Text, "");
            }

            if (this.cmbSrchTINLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("TIN",
                    this.cmbSrchTINLogic.SelectedItem.ToString(),
                    this.ntbSrchTIN.Amount, "");
            }

            if (this.cmbSrchVATLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("VATREGNO",
                    this.cmbSrchTINLogic.SelectedItem.ToString(),
                    this.ntbSrchVAT.Amount, "");
            }

            if (this.ckIsCustomer.CheckState != CheckState.Indeterminate)
            {
                string stIsCustomer = "N";
                if (this.ckIsCustomer.CheckState == CheckState.Checked)
                    stIsCustomer = "Y";
                this.addMoreCriteria("ISCUSTOMER", "Equals to", stIsCustomer, "");
            }

            if (this.ckIsVendor.CheckState != CheckState.Indeterminate)
            {
                string stIsVendor = "N";
                if (this.ckIsVendor.CheckState == CheckState.Checked)
                    stIsVendor = "Y";
                this.addMoreCriteria("ISVENDOR", "Equals to", stIsVendor, "");
            }

            if (this.ckSrchIsActive.CheckState != CheckState.Indeterminate)
            {
                string stIsActive = "N";
                if (this.ckSrchIsActive.CheckState == CheckState.Checked)
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


        private void frmSearchBpartner_Load(object sender, EventArgs e)
        {
            this.cmbSrchNameLogic.SelectedItem = "IGNOR";
            this.cmbSrchName2Logic.SelectedItem = "IGNOR";
            this.cmbSrchTINLogic.SelectedItem = "IGNOR";
            this.cmbSrchVATLogic.SelectedItem = "IGNOR";

            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");
        }



        private void cmbSrchNameLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbSrchNameLogic.SelectedItem.ToString(),
                this.txtSrchName);
        }

        private void cmbSrchName2Logic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbSrchName2Logic.SelectedItem.ToString(),
                this.txtSrchName2);
        }

        private void cmbSrchTINLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbSrchTINLogic.SelectedItem.ToString(),
                this.ntbSrchTIN);
        }

        private void cmbSrchVATLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbSrchVATLogic.SelectedItem.ToString(),
                this.ntbSrchVAT);
        }


        private void cmdSrchShowResult_Click(object sender, EventArgs e)
        {
            string logicalConnector = "AND";
            if (this.ckSrchAllOrAny.Checked)
                logicalConnector = "OR";

            this.establishSearchCriterion();

            this.dtBpartnerInformation =
                this.getDatafromDataBase.getM_BPARTNERInfo(this.searchQuery.Copy(),
                            logicalConnector, this.stBpartnerCode, "", 
                            triStateBool.ignor, triStateBool.ignor, triStateBool.ignor, 
                            false, logicalConnector);

            if (!this.getDatafromDataBase.checkIfTableContainesData(this.dtBpartnerInformation))
            {
                MessageBox.Show("No Result for current search Criterion.",
                    "SRP Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            generalResultInformation.searchResult.Clear();
            generalResultInformation.searchResult =
                        this.dtBpartnerInformation.Copy();
            this.Close();
        }

    }
}
