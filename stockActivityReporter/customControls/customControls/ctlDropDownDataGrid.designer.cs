namespace customControls
{
    partial class DropDownDataGrid
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgDataDisplayGrid = new System.Windows.Forms.DataGridView();
            this.tblPanalSpecialFunctionButtons = new System.Windows.Forms.TableLayoutPanel();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdFind = new System.Windows.Forms.Button();
            this.tblPanalOverallHolder = new System.Windows.Forms.TableLayoutPanel();
            this.tblPanalCriteriaInsertionBox = new System.Windows.Forms.TableLayoutPanel();
            this.txtSelectedItem = new System.Windows.Forms.TextBox();
            this.cmdShowHideGridBox = new System.Windows.Forms.Button();
            this.tmrUserKeyInterval = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDataDisplayGrid)).BeginInit();
            this.tblPanalSpecialFunctionButtons.SuspendLayout();
            this.tblPanalOverallHolder.SuspendLayout();
            this.tblPanalCriteriaInsertionBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgDataDisplayGrid
            // 
            this.dtgDataDisplayGrid.AllowUserToAddRows = false;
            this.dtgDataDisplayGrid.AllowUserToDeleteRows = false;
            this.dtgDataDisplayGrid.AllowUserToOrderColumns = true;
            this.dtgDataDisplayGrid.AllowUserToResizeColumns = false;
            this.dtgDataDisplayGrid.AllowUserToResizeRows = false;
            this.dtgDataDisplayGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgDataDisplayGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgDataDisplayGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgDataDisplayGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgDataDisplayGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgDataDisplayGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDataDisplayGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgDataDisplayGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDataDisplayGrid.GridColor = System.Drawing.SystemColors.Window;
            this.dtgDataDisplayGrid.Location = new System.Drawing.Point(1, 23);
            this.dtgDataDisplayGrid.Margin = new System.Windows.Forms.Padding(0);
            this.dtgDataDisplayGrid.MultiSelect = false;
            this.dtgDataDisplayGrid.Name = "dtgDataDisplayGrid";
            this.dtgDataDisplayGrid.ReadOnly = true;
            this.dtgDataDisplayGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgDataDisplayGrid.RowHeadersVisible = false;
            this.dtgDataDisplayGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dtgDataDisplayGrid.RowTemplate.ReadOnly = true;
            this.dtgDataDisplayGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDataDisplayGrid.Size = new System.Drawing.Size(430, 177);
            this.dtgDataDisplayGrid.TabIndex = 2;
            this.dtgDataDisplayGrid.TabStop = false;
            this.dtgDataDisplayGrid.Visible = false;
            this.dtgDataDisplayGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDataDisplayGrid_DClick);
            // 
            // tblPanalSpecialFunctionButtons
            // 
            this.tblPanalSpecialFunctionButtons.AutoSize = true;
            this.tblPanalSpecialFunctionButtons.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblPanalSpecialFunctionButtons.ColumnCount = 5;
            this.tblPanalSpecialFunctionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tblPanalSpecialFunctionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tblPanalSpecialFunctionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tblPanalSpecialFunctionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tblPanalSpecialFunctionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblPanalSpecialFunctionButtons.Controls.Add(this.cmdClear, 0, 0);
            this.tblPanalSpecialFunctionButtons.Controls.Add(this.cmdNew, 1, 0);
            this.tblPanalSpecialFunctionButtons.Controls.Add(this.cmdRefresh, 2, 0);
            this.tblPanalSpecialFunctionButtons.Controls.Add(this.cmdFind, 3, 0);
            this.tblPanalSpecialFunctionButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPanalSpecialFunctionButtons.Location = new System.Drawing.Point(1, 201);
            this.tblPanalSpecialFunctionButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tblPanalSpecialFunctionButtons.Name = "tblPanalSpecialFunctionButtons";
            this.tblPanalSpecialFunctionButtons.RowCount = 1;
            this.tblPanalSpecialFunctionButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPanalSpecialFunctionButtons.Size = new System.Drawing.Size(430, 1);
            this.tblPanalSpecialFunctionButtons.TabIndex = 5;
            // 
            // cmdClear
            // 
            this.cmdClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClear.Location = new System.Drawing.Point(1, 1);
            this.cmdClear.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(47, 1);
            this.cmdClear.TabIndex = 0;
            this.cmdClear.TabStop = false;
            this.cmdClear.Text = "Clear";
            this.cmdClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdClear.UseVisualStyleBackColor = true;
            // 
            // cmdNew
            // 
            this.cmdNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNew.Location = new System.Drawing.Point(49, 1);
            this.cmdNew.Margin = new System.Windows.Forms.Padding(0);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(45, 1);
            this.cmdNew.TabIndex = 1;
            this.cmdNew.TabStop = false;
            this.cmdNew.Text = "New";
            this.cmdNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdNew.UseVisualStyleBackColor = true;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRefresh.Location = new System.Drawing.Point(95, 1);
            this.cmdRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(65, 1);
            this.cmdRefresh.TabIndex = 2;
            this.cmdRefresh.TabStop = false;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            // 
            // cmdFind
            // 
            this.cmdFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFind.Location = new System.Drawing.Point(161, 1);
            this.cmdFind.Margin = new System.Windows.Forms.Padding(0);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(50, 1);
            this.cmdFind.TabIndex = 3;
            this.cmdFind.TabStop = false;
            this.cmdFind.Text = "Find";
            this.cmdFind.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdFind.UseVisualStyleBackColor = true;
            // 
            // tblPanalOverallHolder
            // 
            this.tblPanalOverallHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblPanalOverallHolder.AutoSize = true;
            this.tblPanalOverallHolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblPanalOverallHolder.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblPanalOverallHolder.ColumnCount = 1;
            this.tblPanalOverallHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPanalOverallHolder.Controls.Add(this.tblPanalSpecialFunctionButtons, 0, 2);
            this.tblPanalOverallHolder.Controls.Add(this.tblPanalCriteriaInsertionBox, 0, 0);
            this.tblPanalOverallHolder.Controls.Add(this.dtgDataDisplayGrid, 0, 1);
            this.tblPanalOverallHolder.Location = new System.Drawing.Point(4, 3);
            this.tblPanalOverallHolder.Margin = new System.Windows.Forms.Padding(0);
            this.tblPanalOverallHolder.Name = "tblPanalOverallHolder";
            this.tblPanalOverallHolder.RowCount = 3;
            this.tblPanalOverallHolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tblPanalOverallHolder.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblPanalOverallHolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tblPanalOverallHolder.Size = new System.Drawing.Size(432, 202);
            this.tblPanalOverallHolder.TabIndex = 6;
            // 
            // tblPanalCriteriaInsertionBox
            // 
            this.tblPanalCriteriaInsertionBox.ColumnCount = 2;
            this.tblPanalCriteriaInsertionBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 92.36111F));
            this.tblPanalCriteriaInsertionBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.638889F));
            this.tblPanalCriteriaInsertionBox.Controls.Add(this.txtSelectedItem, 0, 0);
            this.tblPanalCriteriaInsertionBox.Controls.Add(this.cmdShowHideGridBox, 1, 0);
            this.tblPanalCriteriaInsertionBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPanalCriteriaInsertionBox.Location = new System.Drawing.Point(1, 1);
            this.tblPanalCriteriaInsertionBox.Margin = new System.Windows.Forms.Padding(0);
            this.tblPanalCriteriaInsertionBox.Name = "tblPanalCriteriaInsertionBox";
            this.tblPanalCriteriaInsertionBox.RowCount = 1;
            this.tblPanalCriteriaInsertionBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPanalCriteriaInsertionBox.Size = new System.Drawing.Size(430, 21);
            this.tblPanalCriteriaInsertionBox.TabIndex = 6;
            // 
            // txtSelectedItem
            // 
            this.txtSelectedItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSelectedItem.Location = new System.Drawing.Point(0, 0);
            this.txtSelectedItem.Margin = new System.Windows.Forms.Padding(0);
            this.txtSelectedItem.Name = "txtSelectedItem";
            this.txtSelectedItem.Size = new System.Drawing.Size(397, 20);
            this.txtSelectedItem.TabIndex = 0;
            this.txtSelectedItem.TextChanged += new System.EventHandler(this.txtSelectedItem_TextChange);
            this.txtSelectedItem.Click += new System.EventHandler(this.ShowHideGrid);
            this.txtSelectedItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSelectedItem_KeyPress);
            // 
            // cmdShowHideGridBox
            // 
            this.cmdShowHideGridBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdShowHideGridBox.Location = new System.Drawing.Point(397, 0);
            this.cmdShowHideGridBox.Margin = new System.Windows.Forms.Padding(0);
            this.cmdShowHideGridBox.Name = "cmdShowHideGridBox";
            this.cmdShowHideGridBox.Size = new System.Drawing.Size(33, 21);
            this.cmdShowHideGridBox.TabIndex = 1;
            this.cmdShowHideGridBox.TabStop = false;
            this.cmdShowHideGridBox.Text = "...";
            this.cmdShowHideGridBox.UseVisualStyleBackColor = true;
            this.cmdShowHideGridBox.Click += new System.EventHandler(this.ShowHideGrid);
            // 
            // tmrUserKeyInterval
            // 
            this.tmrUserKeyInterval.Enabled = true;
            this.tmrUserKeyInterval.Tick += new System.EventHandler(this.tmrUserKeyInterval_Tick);
            // 
            // DropDownDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.tblPanalOverallHolder);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DropDownDataGrid";
            this.Size = new System.Drawing.Size(438, 208);
            this.Leave += new System.EventHandler(this.dropDownDataGrid_LostFocus);
            this.Enter += new System.EventHandler(this.dropDownDataGrid_GotFocus);
            this.EnabledChanged += new System.EventHandler(this.ctlDropDownDataGrid_EnabledChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDataDisplayGrid)).EndInit();
            this.tblPanalSpecialFunctionButtons.ResumeLayout(false);
            this.tblPanalOverallHolder.ResumeLayout(false);
            this.tblPanalOverallHolder.PerformLayout();
            this.tblPanalCriteriaInsertionBox.ResumeLayout(false);
            this.tblPanalCriteriaInsertionBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgDataDisplayGrid;
        private System.Windows.Forms.TableLayoutPanel tblPanalSpecialFunctionButtons;
        private System.Windows.Forms.TableLayoutPanel tblPanalOverallHolder;
        private System.Windows.Forms.TextBox txtSelectedItem;
        private System.Windows.Forms.Button cmdShowHideGridBox;
        private System.Windows.Forms.TableLayoutPanel tblPanalCriteriaInsertionBox;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdFind;
        private System.Windows.Forms.Timer tmrUserKeyInterval;

    }
}
