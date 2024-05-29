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
    public partial class frmProdcutBOM : Form
    {
        public frmProdcutBOM()
        {
            InitializeComponent();
        }


        public string productID = "";
        public decimal qtyProduced = 1;

        dataBuilder getDataFromDb = new dataBuilder();
        

        private void frmProdcutBOM_Load(object sender, EventArgs e)
        {
            if (this.productID == "")
            {
                this.Close(); 
            }

            DataTable dtproductInfo =
                this.getDataFromDb.getEM_M_PRODUCTInfo(null, "",
                            this.productID, false, triStateBool.ignor,
                            triStateBool.ignor, triStateBool.yes, false, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(dtproductInfo))
            {
                MessageBox.Show("No product found", "EasyMove",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            this.groupBox1.Text = dtproductInfo.Rows[0]["NAME"].ToString();

            DataTable dtProductBOM = 
                this.getDataFromDb.getM_PRODUCT_BOMInfo(null, "", "", 
                            this.productID, "", true, false, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(dtProductBOM))
            {
                MessageBox.Show("No BOM Found", "EasyMove", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            dtProductBOM.Columns.Add("ComponentName");
            
            for (int rowCounter = 0; rowCounter <= dtProductBOM.Rows.Count - 1; rowCounter++)
            {
                
                dtproductInfo =
                    this.getDataFromDb.getEM_M_PRODUCTInfo(null, "",
                            dtProductBOM.Rows[rowCounter]["M_PRODUCTBOM_ID"].ToString(),
                            false, triStateBool.ignor,
                            triStateBool.ignor, triStateBool.ignor, false, "AND");
                if (!this.getDataFromDb.checkIfTableContainesData(dtproductInfo))
                {
                    dtProductBOM.Rows[rowCounter]["ComponentName"] = "N/A";
                }
                else
                {
                    dtProductBOM.Rows[rowCounter]["ComponentName"] =
                        dtproductInfo.Rows[0]["NAME"].ToString();
                }

                dtProductBOM.Rows[rowCounter]["BOMQTY"] =
                    decimal.Parse(dtProductBOM.Rows[rowCounter]["BOMQTY"].ToString()) * 
                    this.qtyProduced;
 
            }

            dtProductBOM.Columns["LINE"].SetOrdinal(1);
            dtProductBOM.Columns["ComponentName"].SetOrdinal(2);
            dtProductBOM.Columns["BOMQTY"].SetOrdinal(3);

            this.dtgProductBOM.DataSource = dtProductBOM;

            this.dtgProductBOM.Columns["M_PRODUCT_BOM_ID"].Visible = false;
            this.dtgProductBOM.Columns["AD_CLIENT_ID"].Visible = false;
            this.dtgProductBOM.Columns["AD_ORG_ID"].Visible = false;
            this.dtgProductBOM.Columns["ISACTIVE"].Visible = false;
            this.dtgProductBOM.Columns["CREATED"].Visible = false;
            this.dtgProductBOM.Columns["CREATEDBY"].Visible = false;
            this.dtgProductBOM.Columns["UPDATED"].Visible = false;
            this.dtgProductBOM.Columns["UPDATEDBY"].Visible = false;
            this.dtgProductBOM.Columns["M_PRODUCT_ID"].Visible = false;
            this.dtgProductBOM.Columns["M_PRODUCTBOM_ID"].Visible = false;
            this.dtgProductBOM.Columns["DESCRIPTION"].Visible = false;
            this.dtgProductBOM.Columns["BOMTYPE"].Visible = false;

            this.dtgProductBOM.Columns["LINE"].HeaderText = "SN";
            this.dtgProductBOM.Columns["ComponentName"].HeaderText = "Component Name";
            if (this.qtyProduced == 1)
            {
                this.dtgProductBOM.Columns["BOMQTY"].HeaderText = "Each Item Qty";
            }
            else
            {
                this.dtgProductBOM.Columns["BOMQTY"].HeaderText = "Item Qty"; 
            }
        }

    }
}
