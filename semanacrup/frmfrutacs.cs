using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace semanacrup
{
    public partial class frmfrutacs : Form
    {
        private string action = "";
        public frmfrutacs()
        {
            InitializeComponent();
        }

        private void frmfrutacs_Load(object sender, EventArgs e)
        {

        }
        public void fillDataGridView()
        {
          
            fruta fruta = new fruta();
;

            dataGridView1.Columns.Add("NOMBRE", "NOMBRE");
            dataGridView1.Columns.Add("CANTIDAD", "CANTIDAD");
            dataGridView1.Columns.Add("PESO", "PESO");
            dataGridView1.Columns.Add("PRECIO", "PRECIO");

     
            MySqlDataReader dataReader = fruta.getAllBooks();

            while (dataReader.Read())
            {
                dataGridView1.Rows.Add(
                        dataReader.GetValue(0),
                        dataReader.GetValue(1),
                        dataReader.GetValue(2),
                        dataReader.GetValue(3)
                       );
            }
        }

        public void clearDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
        }

        public void controlsDisable()
        {
            maskedTextBox1.Enabled = false;
            maskedTextBox2.Enabled = false;
            maskedTextBox3.Enabled = false;
            maskedTextBox4.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
        }
        public void controlsEnable()
        {
            maskedTextBox1.Enabled = true;
            maskedTextBox2.Enabled = true;
            maskedTextBox3.Enabled = true;
            maskedTextBox4.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
        }
   
        public void clearControls()
        {
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Debe escribir datos", "VALIDACION",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedTextBox2.Focus(); 

            }
            else
            {

                fruta fruta = new fruta();
                if (action == "edit")
                {
                    fruta._CANTIDAD = Convert.ToInt32(maskedTextBox2.Text);
                }


                fruta._NOMBRE = maskedTextBox1.Text;
                fruta._PESO = Convert.ToInt32(maskedTextBox3.Text);
                fruta._PRECIO = Convert.ToInt32(maskedTextBox4.Text);


                string mensaje = "Esta seguro que desea guardar el registro?";
                if (MetroFramework.MetroMessageBox.Show(this, mensaje, "CONFIRMACION",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
              
                    if (fruta.newEditBook(action))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Los datos se han guardado exitosamente!",
                            "CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                   
                    clearControls();
                    controlsDisable();
                    fillDataGridView();


                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mensaje = "¿Está seguró que desea cancelar?";
            if (MetroFramework.MetroMessageBox.Show(this, mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                clearControls();
                controlsDisable();


            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            controlsEnable();

            maskedTextBox1.Visible = true;
            maskedTextBox1.ReadOnly = true;
            label1.Visible = true;

       
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            maskedTextBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            maskedTextBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();


      
            action = "edit";
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = "Esta seguro que desea eliminar el registro?";
            if (MetroFramework.MetroMessageBox.Show(this, mensaje, "CONFIRMACION",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                fruta fruta = new fruta();
                fruta._CANTIDAD = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

         
                if (fruta.deletefruta())
                {
                    MetroFramework.MetroMessageBox.Show(this, "Los datos se han eliminado exitosamente!",
                        "CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
               fillDataGridView();

                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Los datos  no se han podido eliminar",
                        "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
      
            string mensaje = "¿Está seguró que desea salir?";
            if (MetroFramework.MetroMessageBox.Show(this, mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            clearControls();
            controlsEnable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

        

    