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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmtest frm = new frmtest();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmfrutacs frm = new frmfrutacs();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
