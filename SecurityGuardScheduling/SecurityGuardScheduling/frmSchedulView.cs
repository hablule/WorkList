using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SecurityGuardScheduling
{
    public partial class frmSchedulView : Form
    {
        public frmSchedulView()
        {
            InitializeComponent();
        }

        public DataTable dtSchedul = new DataTable();

        private void frmSchedulView_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = dtSchedul;
        }
    }
}
