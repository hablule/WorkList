using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SRP
{
    public partial class DropDownDataGrid : UserControl
    {
        private bool userKeyedToTextBox = false;
        private bool userStoppedInsertionToTextBox = false;
        
        private int columnIndex = 0;
        private UInt16 primaryKeyColIndex = 0;
        private bool autoFilter = true;
        private int[] hidenColoumnIndex = { };
        private DataTable dataSourceTable = new DataTable();
        private DataTable dataResultTable = new DataTable();

        private bool showGridBoxSpecialCommands = false;
        private object selectedRowPrimaryKey = null;
        
        public event EventHandler SelectedItemClicked;

        public event EventHandler selectedItemChanged;

        public bool ClearButtonEnabled
        {
            get
            {
                return cmdClear.Enabled;
            }
            set
            {
                //EnableClearButton = value;
                cmdClear.Enabled = value;
            }
        }
        public bool NewButtonEnabled
        {
            get
            {
                return cmdNew.Enabled;
            }
            set
            {
                //EnableNewButton = value;
                cmdNew.Enabled = value;
            }
        }
        public bool RefreshButtonEnabled
        {
            get
            {
                return cmdRefresh.Enabled;
            }
            set
            {
                //EnableRefreshButton = value;
                cmdRefresh.Enabled = value;
            }
        }
        public bool FindButtonEnabled
        {
            get
            {
                return cmdFind.Enabled;
            }
            set
            {
                //EnableFindButton = value;
                cmdFind.Enabled = value;
            }
        }

        public int SelectedColomnIdex
        {
            get
            {
                return columnIndex;
            }
            set
            {
                columnIndex = value;
            }
        }

        public UInt16 DataTablePrimaryKey
        {
            get
            {
                return primaryKeyColIndex;
            }
            set
            {
                primaryKeyColIndex = value;
            }
        }

        public object SelectedRowKey
        {
            get
            {
                return selectedRowPrimaryKey;
            }
            set
            {
                selectedRowPrimaryKey = value;
            }
        }

        public string SelectedItem
        {
            get
            {
                return txtSelectedItem.Text ;
            }
            set
            {
                txtSelectedItem.Text = value.ToString();
            }
        }

        public DataTable DataSource
        {
            get
            {
                return dataSourceTable;
            }
            set
            {
                dataSourceTable = value;
                
            }
        }

        public bool AutoFilter
        {
            get
            {
                return autoFilter;
            }
            set
            {
                autoFilter = value;
            }
        }

        public bool ShowGridFunctions
        {
            get
            {
                return showGridBoxSpecialCommands;
            }
            set
            {
                showGridBoxSpecialCommands = value;
            }
        }

        public Image Image
        {
            get
            {
                return cmdShowHideGridBox.Image;
            }
            set
            {
                cmdShowHideGridBox.Image = value;
            }
        }

        public DataTable SelectedRow
        {
            get 
            {
                return dataResultTable;
            }
        }

        public int[] HiddenColoumns
        {
            get
            { return this.hidenColoumnIndex; }
            set
            { this.hidenColoumnIndex = value; }
        }

        public DropDownDataGrid()
        {
            InitializeComponent();
        }

        private void hideGridColoumns()
        {
            for (int arrayIndex = 0; arrayIndex < hidenColoumnIndex.Length; arrayIndex++)
            {
                if(this.dtgDataDisplayGrid.Columns.Count > hidenColoumnIndex[arrayIndex])
                    this.dtgDataDisplayGrid.Columns[hidenColoumnIndex[arrayIndex]].Visible = false;
            }
        }

        private DataTable filterData(string criteria)
        {
            DataTable filteredData = new DataTable();
            if (dataSourceTable.Rows.Count > 0 && dataSourceTable.Columns.Count > 0)
            {
                string rowValue = "";
                filteredData = dataSourceTable.Copy();
                for (int rowCounter = filteredData.Rows.Count - 1;
                    rowCounter >= 0; rowCounter--)
                {
                    rowValue = 
                        filteredData.Rows[rowCounter][columnIndex].ToString();
                    rowValue = rowValue.ToUpperInvariant();
                    criteria = criteria.ToUpperInvariant();
                    if (!rowValue.Contains(criteria))
                        filteredData.Rows.RemoveAt(rowCounter);
                }
            }
            return filteredData;
        }

        private DataTable clearRedundantRow(DataTable tableToClear)
        {
            for (int rowCounter = tableToClear.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                for (int rowCounter2 = rowCounter - 1;
                    rowCounter2 >= 0; rowCounter2--)
                {
                    if (tableToClear.Rows[rowCounter][primaryKeyColIndex].ToString() ==
                        tableToClear.Rows[rowCounter2][primaryKeyColIndex].ToString())
                    {
                        tableToClear.Rows.RemoveAt(rowCounter);
                        break;
                    }
                }
            }
            return tableToClear;
        }

        private void DetermineGridContent(object sender, EventArgs e)
        {
            DataTable resultTable = new DataTable();
            
            try
            {
                if(this.SelectedItemClicked != null)
                    SelectedItemClicked.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Contact Your Admin: Error " + ex.Message);
            }
            

            if (txtSelectedItem.Text == "")
            {
                resultTable.Clear();
                resultTable = dataSourceTable.Copy();
                dtgDataDisplayGrid.DataSource = dataSourceTable;
            }
            else
            {
                dtgDataDisplayGrid.DataSource = null;
                resultTable.Clear();
                string[] Separtors = { " ", "%" };
                string[] textTofilter =
                    txtSelectedItem.Text.Split(Separtors, StringSplitOptions.RemoveEmptyEntries);
                foreach (string st in textTofilter)
                {
                    resultTable.Merge(filterData(st));                    
                }
                resultTable = clearRedundantRow(resultTable);
                dtgDataDisplayGrid.DataSource = resultTable;              
            }

            if (dtgDataDisplayGrid.Rows.Count == 1)
            {
                this.selectedRowPrimaryKey = resultTable.Rows[0][primaryKeyColIndex];
            }
            else if (dtgDataDisplayGrid.Rows.Count != 1)
            {
                this.selectedRowPrimaryKey = null;
            }

            if (dtgDataDisplayGrid.Columns.Count > primaryKeyColIndex && primaryKeyColIndex != columnIndex)
                dtgDataDisplayGrid.Columns[primaryKeyColIndex].Visible = false;
            this.hideGridColoumns();
                            
            if (dtgDataDisplayGrid.Rows.Count < 1)
            {
                this.txtSelectedItem.BackColor = Color.Red;
                return;
            }
            else
            {
                this.txtSelectedItem.BackColor = Color.White;
            }

        }

        private void invokeSelectedItemChange(object sender, EventArgs e)
        {
            try
            {
                if (this.selectedItemChanged != null)
                    selectedItemChanged.Invoke(sender, e);
            }
            catch
            {
            }
        }

        private void ShowHideGrid(object sender, EventArgs e)
        {
            DetermineGridContent(sender,e);
            
            if (!this.dtgDataDisplayGrid.Visible)
            {
                if (showGridBoxSpecialCommands)
                {
                    //tblPanalSpecialFunctionButtons.Visible = true;
                    tblPanalOverallHolder.RowStyles[2].Height = 32;                    
                }
                else
                {
                    tblPanalOverallHolder.RowStyles[2].Height = 0;
                    //tblPanalSpecialFunctionButtons.Visible = false;
                }
            }
            else
            {
                //tblPanalSpecialFunctionButtons.Visible = false;
                tblPanalOverallHolder.RowStyles[2].Height = 0;
            }
            this.dtgDataDisplayGrid.Visible = !(this.dtgDataDisplayGrid.Visible);
                        
        }

        private void dtgDataDisplayGrid_DClick
            (object sender, DataGridViewCellEventArgs e)
        {
            DataTable resultTable = new DataTable();
            int selectedRowIndex = -1;
            if (dtgDataDisplayGrid.SelectedRows.Count > 0)
            {
                selectedRowIndex = dtgDataDisplayGrid.SelectedRows[0].Index;
                if (selectedRowIndex == -1)
                    selectedRowIndex = dtgDataDisplayGrid.CurrentCell.RowIndex;
                if (selectedRowIndex == -1)
                {
                    this.txtSelectedItem.Select(this.txtSelectedItem.Text.Length, 0);
                    dtgDataDisplayGrid.Visible = false;
                    tblPanalOverallHolder.RowStyles[2].Height = 0;
                    return;
                }
                resultTable = (DataTable)dtgDataDisplayGrid.DataSource;
                //this.txtSelectedItem.Text = resultTable.Rows[selectedRowIndex][columnIndex].ToString();
                //this.selectedRowPrimaryKey = resultTable.Rows[selectedRowIndex][primaryKeyColIndex];
                this.txtSelectedItem.Text = dtgDataDisplayGrid.SelectedRows[0].Cells[columnIndex].Value.ToString();
                this.selectedRowPrimaryKey = dtgDataDisplayGrid.SelectedRows[0].Cells[primaryKeyColIndex].Value;

                for (int rowCounter = resultTable.Rows.Count - 1; 
                    rowCounter >= 0; rowCounter--)
                { 
                    if(resultTable.Rows[rowCounter][primaryKeyColIndex].ToString()
                        != this.selectedRowPrimaryKey.ToString())
                        resultTable.Rows.RemoveAt(rowCounter);
                }
                this.dataResultTable = resultTable.Copy();
            }
            this.txtSelectedItem.Select(this.txtSelectedItem.Text.Length, 0);
            dtgDataDisplayGrid.Visible = false;
            tblPanalOverallHolder.RowStyles[2].Height = 0;
            this.invokeSelectedItemChange(sender, e);
        }

        private void txtSelectedItem_TextChange
            (object sender, EventArgs e)
       {
           if (!userKeyedToTextBox || !userStoppedInsertionToTextBox)
               return;

            DetermineGridContent(sender,e);
            dtgDataDisplayGrid.Visible = true;
            if (showGridBoxSpecialCommands)
                tblPanalOverallHolder.RowStyles[2].Height = 32;
            else            
                tblPanalOverallHolder.RowStyles[2].Height = 0;
            //this.invokeSelectedItemChange(sender, e);
            userKeyedToTextBox = false;
        }

        private void dropDownDataGrid_LostFocus (object sender, EventArgs e)
        {
            tblPanalOverallHolder.RowStyles[2].Height = 0;
            dtgDataDisplayGrid.Visible = false;

            if (this.txtSelectedItem.Text == "")
            {
                selectedRowPrimaryKey = null;
                this.dataResultTable.Clear();
                this.txtSelectedItem.BackColor = Color.White;
                this.invokeSelectedItemChange(sender, e);
                return;                
            }

            DetermineGridContent(sender,e);
                        
            DataTable validData = new DataTable();
            validData = (DataTable) dtgDataDisplayGrid.DataSource;

            if (selectedRowPrimaryKey != null)
            {
                for (int rowCounter = validData.Rows.Count - 1;
                    rowCounter >= 0; rowCounter--)
                {
                    if (selectedRowPrimaryKey.ToString().ToUpperInvariant() ==
                        Convert.ToString(validData.Rows[rowCounter][primaryKeyColIndex]).ToUpperInvariant())
                    {
                        if (this.txtSelectedItem.Text.ToUpperInvariant() ==
                            Convert.ToString(validData.Rows[rowCounter][columnIndex]).ToUpperInvariant())
                        {
                            for (int rowCounter2 = validData.Rows.Count - 1;
                                rowCounter2 >= 0; rowCounter2--)
                            {
                                if (rowCounter2 != rowCounter)
                                    validData.Rows.RemoveAt(rowCounter2);
                            }
                            this.dataResultTable = validData.Copy();
                            this.invokeSelectedItemChange(sender, e);
                            return;
                        }
                        else
                        {
                            this.txtSelectedItem.BackColor = Color.Red;
                            selectedRowPrimaryKey = null;
                            this.dataResultTable.Clear();
                            this.invokeSelectedItemChange(sender, e);
                            return;
                        }
                    }
                }
                this.txtSelectedItem.BackColor = Color.Red;
                selectedRowPrimaryKey = null;
                this.dataResultTable.Clear();
                this.invokeSelectedItemChange(sender, e);
            }

            else
            {
                if (validData.Rows.Count < 1)
                {
                    selectedRowPrimaryKey = null;
                    this.txtSelectedItem.BackColor = Color.Red;
                    this.dataResultTable.Clear();
                    this.invokeSelectedItemChange(sender, e);
                    return;
                }
                for (int rowCounter = validData.Rows.Count - 1;
                    rowCounter >= 0; rowCounter--)
                {
                    if (this.txtSelectedItem.Text.ToUpperInvariant() ==
                        Convert.ToString(validData.Rows[rowCounter][columnIndex]).ToUpperInvariant())
                    {
                        this.txtSelectedItem.Text = validData.Rows[rowCounter][SelectedColomnIdex].ToString();
                        this.selectedRowPrimaryKey = validData.Rows[rowCounter][primaryKeyColIndex];
                        
                        for (int rowCounter2 = validData.Rows.Count - 1;
                                rowCounter2 >= 0; rowCounter2--)
                        {
                            if (rowCounter2 != rowCounter)
                                validData.Rows.RemoveAt(rowCounter2);
                        }
                        this.dataResultTable = validData.Copy();
                        this.invokeSelectedItemChange(sender, e);
                        return;
                    }                    
                }
                this.txtSelectedItem.BackColor = Color.Red;
                this.dataResultTable.Clear();
                this.invokeSelectedItemChange(sender, e);
            }
        }

        private void dropDownDataGrid_GotFocus(object sender, EventArgs e)
        {
            selectedRowPrimaryKey = null;
            this.dataResultTable.Clear();
            this.BringToFront();
        }
        
        private void ctlDropDownDataGrid_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled)
            {this.txtSelectedItem.BackColor = Color.White;}
            else
            {this.txtSelectedItem.BackColor = Color.FromKnownColor(KnownColor.Control);}
                                     
        }

        private void txtSelectedItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            userKeyedToTextBox = true;
            userStoppedInsertionToTextBox = false;
        }
        
        private void tmrUserKeyInterval_Tick(object sender, EventArgs e)
        {
            if (!userKeyedToTextBox)
                return;

            if (!userStoppedInsertionToTextBox)
            {
                userStoppedInsertionToTextBox = true;
            }
            else
            {
                this.txtSelectedItem_TextChange(sender, e);
            }
        }

    }
}
