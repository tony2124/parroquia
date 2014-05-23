using conexionbd;
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
    public partial class Parroquia : Form
    {
        ConexionBD conexion; 
        public Parroquia()
        {
            InitializeComponent();
            conexion = new ConexionBD();
        }

        private void informacionDeLaParroquiaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bautismoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Libros l = new Libros(1);
            l.ShowDialog();
        }

        private void confirmaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Libros l = new Libros(2);
            l.ShowDialog();
        }

        private void primeraComuniónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Libros l = new Libros(3);
            l.ShowDialog();
        }

        private void matrimonioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Libros l = new Libros(4);
            l.ShowDialog();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
