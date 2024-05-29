namespace appSecurity
{
    partial class frmappSecurityMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmappSecurityMain));
            this.cmdGenerateKey = new System.Windows.Forms.Button();
            this.txtNewKey = new System.Windows.Forms.TextBox();
            this.cmdRecordKey = new System.Windows.Forms.Button();
            this.lblExistingKey = new System.Windows.Forms.Label();
            this.sstStatusBar = new System.Windows.Forms.StatusStrip();
            this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
            this.visualStyler1 = new SkinSoft.VisualStyler.VisualStyler(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.visualStyler1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdGenerateKey
            // 
            this.cmdGenerateKey.Location = new System.Drawing.Point(104, 87);
            this.cmdGenerateKey.Name = "cmdGenerateKey";
            this.cmdGenerateKey.Size = new System.Drawing.Size(155, 23);
            this.cmdGenerateKey.TabIndex = 0;
            this.cmdGenerateKey.Text = "Generate Key";
            this.cmdGenerateKey.UseVisualStyleBackColor = true;
            this.cmdGenerateKey.Click += new System.EventHandler(this.cmdGenerateKey_Click);
            // 
            // txtNewKey
            // 
            this.txtNewKey.BackColor = System.Drawing.SystemColors.Window;
            this.txtNewKey.Location = new System.Drawing.Point(13, 61);
            this.txtNewKey.Name = "txtNewKey";
            this.txtNewKey.ReadOnly = true;
            this.txtNewKey.Size = new System.Drawing.Size(337, 20);
            this.txtNewKey.TabIndex = 1;
            this.txtNewKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdRecordKey
            // 
            this.cmdRecordKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRecordKey.Location = new System.Drawing.Point(61, 116);
            this.cmdRecordKey.Name = "cmdRecordKey";
            this.cmdRecordKey.Size = new System.Drawing.Size(240, 29);
            this.cmdRecordKey.TabIndex = 2;
            this.cmdRecordKey.Text = "Record/Update Key";
            this.cmdRecordKey.UseVisualStyleBackColor = true;
            this.cmdRecordKey.Click += new System.EventHandler(this.cmdRecordKey_Click);
            // 
            // lblExistingKey
            // 
            this.lblExistingKey.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblExistingKey.Location = new System.Drawing.Point(25, 37);
            this.lblExistingKey.Name = "lblExistingKey";
            this.lblExistingKey.Size = new System.Drawing.Size(313, 20);
            this.lblExistingKey.TabIndex = 3;
            this.lblExistingKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sstStatusBar
            // 
            this.sstStatusBar.Location = new System.Drawing.Point(0, 159);
            this.sstStatusBar.Name = "sstStatusBar";
            this.sstStatusBar.Size = new System.Drawing.Size(361, 22);
            this.sstStatusBar.SizingGrip = false;
            this.sstStatusBar.TabIndex = 4;
            this.sstStatusBar.Text = "statusStrip1";
            // 
            // mnuMainMenu
            // 
            this.mnuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMainMenu.Name = "mnuMainMenu";
            this.mnuMainMenu.Size = new System.Drawing.Size(361, 24);
            this.mnuMainMenu.TabIndex = 5;
            this.mnuMainMenu.Text = "menuStrip1";
            // 
            // visualStyler1
            // 
            this.visualStyler1.License = ((SkinSoft.VisualStyler.Licensing.VisualStylerLicense)(resources.GetObject("visualStyler1.License")));
            this.visualStyler1.LoadVisualStyle(null, "Aero (Black).vssf");
            // 
            // frmappSecurityMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 181);
            this.Controls.Add(this.sstStatusBar);
            this.Controls.Add(this.mnuMainMenu);
            this.Controls.Add(this.lblExistingKey);
            this.Controls.Add(this.cmdRecordKey);
            this.Controls.Add(this.txtNewKey);
            this.Controls.Add(this.cmdGenerateKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnuMainMenu;
            this.MaximizeBox = false;
            this.Name = "frmappSecurityMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Security Liquid Base";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmappSecurityMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.visualStyler1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGenerateKey;
        private System.Windows.Forms.TextBox txtNewKey;
        private System.Windows.Forms.Button cmdRecordKey;
        private System.Windows.Forms.Label lblExistingKey;
        private System.Windows.Forms.StatusStrip sstStatusBar;
        private System.Windows.Forms.MenuStrip mnuMainMenu;
        private SkinSoft.VisualStyler.VisualStyler visualStyler1;
    }
}

