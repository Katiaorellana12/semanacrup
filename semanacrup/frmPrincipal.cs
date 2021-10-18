using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace semanacrup
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void fRUTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmfrutacs form = new frmfrutacs();
            form.MdiParent = this;
            form.Show();
        }
    }
}
