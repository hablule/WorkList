namespace utldecm
{
    partial class frmOpenIncomingInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpenIncomingInventory));
            this.tmrWindowLife = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tmrContentBlinker = new System.Windows.Forms.Timer(this.components);
            this.tmrControlLocationChanger = new System.Windows.Forms.Timer(this.components);
            this.tmrTopMost = new System.Windows.Forms.Timer(this.components);
            this.tmrFollowMouse = new System.Windows.Forms.Timer(this.components);
            this.tmrSelfReplicate = new System.Windows.Forms.Timer(this.components);
            this.cmdClose = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblColck = new System.Windows.Forms.Label();
            this.tmrShowCloseCntDwn = new System.Windows.Forms.Timer(this.components);
            this.tmrAbortExecution = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrWindowLife
            // 
            this.tmrWindowLife.Tick += new System.EventHandler(this.tmrWindowLife_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Close Open Incomings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(2, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(374, 375);
            this.label2.TabIndex = 1;
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tmrContentBlinker
            // 
            this.tmrContentBlinker.Tick += new System.EventHandler(this.tmrContentBlinker_Tick);
            // 
            // tmrControlLocationChanger
            // 
            this.tmrControlLocationChanger.Interval = 500;
            this.tmrControlLocationChanger.Tick += new System.EventHandler(this.tmrControlLocationChanger_Tick);
            // 
            // tmrTopMost
            // 
            this.tmrTopMost.Enabled = true;
            this.tmrTopMost.Tick += new System.EventHandler(this.tmrTopMost_Tick);
            // 
            // tmrFollowMouse
            // 
            this.tmrFollowMouse.Interval = 10;
            this.tmrFollowMouse.Tick += new System.EventHandler(this.tmrFollowMouse_Tick);
            // 
            // tmrSelfReplicate
            // 
            this.tmrSelfReplicate.Tick += new System.EventHandler(this.tmrSelfReplicate_Tick);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdClose.BackColor = System.Drawing.Color.DimGray;
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdClose.Image = ((System.Drawing.Image)(resources.GetObject("cmdClose.Image")));
            this.cmdClose.Location = new System.Drawing.Point(240, 48);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 42);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Visible = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(104, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(130, 22);
            this.textBox1.TabIndex = 3;
            this.textBox1.Visible = false;
            // 
            // lblColck
            // 
            this.lblColck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblColck.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColck.Location = new System.Drawing.Point(250, 73);
            this.lblColck.Name = "lblColck";
            this.lblColck.Size = new System.Drawing.Size(126, 43);
            this.lblColck.TabIndex = 4;
            this.lblColck.Text = "00:00";
            this.lblColck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblColck.Visible = false;
            // 
            // tmrShowCloseCntDwn
            // 
            this.tmrShowCloseCntDwn.Interval = 1000;
            this.tmrShowCloseCntDwn.Tick += new System.EventHandler(this.tmrShowCloseCntDwn_Tick);
            // 
            // tmrAbortExecution
            // 
            this.tmrAbortExecution.Enabled = true;
            this.tmrAbortExecution.Interval = 1;
            this.tmrAbortExecution.Tick += new System.EventHandler(this.tmrAbortExecution_Tick);
            // 
            // frmOpenIncomingInventory
            // 
            this.AcceptButton = this.cmdClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 477);
            this.Controls.Add(this.lblColck);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(55, 55);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOpenIncomingInventory";
            this.ShowInTaskbar = false;
            this.Text = "Open Incoming Inventory 2.0a";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmOpenIncomingInventory_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOpenIncomingInventory_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrWindowLife;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tmrContentBlinker;
        private System.Windows.Forms.Timer tmrControlLocationChanger;
        private System.Windows.Forms.Timer tmrTopMost;
        private System.Windows.Forms.Timer tmrFollowMouse;
        private System.Windows.Forms.Timer tmrSelfReplicate;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblColck;
        private System.Windows.Forms.Timer tmrShowCloseCntDwn;
        private System.Windows.Forms.Timer tmrAbortExecution;
    }
}