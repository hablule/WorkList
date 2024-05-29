
namespace BuySimple
{
    partial class frmCreateLDAPConnection
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
            this.servertxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.porttxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.usertxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passwtxt = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // servertxt
            // 
            this.servertxt.Location = new System.Drawing.Point(83, 35);
            this.servertxt.Name = "servertxt";
            this.servertxt.Size = new System.Drawing.Size(209, 20);
            this.servertxt.TabIndex = 0;
            this.servertxt.Text = "gloriousplc.net";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.porttxt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.usertxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.servertxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.passwtxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 167);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LDAP Connection";
            // 
            // porttxt
            // 
            this.porttxt.Location = new System.Drawing.Point(83, 59);
            this.porttxt.Name = "porttxt";
            this.porttxt.Size = new System.Drawing.Size(209, 20);
            this.porttxt.TabIndex = 7;
            this.porttxt.Text = "389";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Port";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // usertxt
            // 
            this.usertxt.Location = new System.Drawing.Point(83, 85);
            this.usertxt.Name = "usertxt";
            this.usertxt.Size = new System.Drawing.Size(209, 20);
            this.usertxt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username";
            // 
            // passwtxt
            // 
            this.passwtxt.Location = new System.Drawing.Point(83, 111);
            this.passwtxt.Name = "passwtxt";
            this.passwtxt.PasswordChar = '*';
            this.passwtxt.Size = new System.Drawing.Size(209, 20);
            this.passwtxt.TabIndex = 2;
            // 
            // frmCreateLDAPConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 191);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCreateLDAPConnection";
            this.Text = "CreateLDAPConnection";
            this.Load += new System.EventHandler(this.CreateLDAPConnection_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox servertxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox porttxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox usertxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwtxt;
    }
}