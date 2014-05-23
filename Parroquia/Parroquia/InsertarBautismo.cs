using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parroquia
{
    public partial class InsertarBautismo : Form
    {
        public InsertarBautismo(String ID_btn)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (anio.Text == "" || nombre.Text == "")
            {
                MessageBox.Show(this, "Debe llenar todos los campos obligatorios en el formulario. Los campos obligatorios están marcados con un asterisco (*).","Campos en blanco", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
