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
using MySql.Data.MySqlClient;

namespace Parroquia
{
    public partial class Parroquia : Form
    {
        ConexionBD BDatos;
        public static MySqlDataAdapter Adaptador;
        public static DataSet ds;

        public Parroquia()
        {
            BDatos = new ConexionBD();
            BDatos.conexion();

            Adaptador = new MySqlDataAdapter("select nombre, anio, id_libro, num_hoja,num_partida from comuniones", "server=localhost; port=3306; user id=root; password=; database=parroquiaantunez;");
            ds = new DataSet();
            Adaptador.Fill(ds,"prueba");

            BDatos.Desconectar();
            InitializeComponent();
            tablaBusqueda.DataSource = ds;
            tablaBusqueda.DataMember = "prueba";

            //Agregamos el boton de accion despues de todas las columnas
            this.tablaBusqueda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uu});

            //Agregamos nombre de headers de las columnas
            tablaBusqueda.Columns[0].HeaderText = "NOMBRE";
            tablaBusqueda.Columns[1].HeaderText = "AÑO";
            tablaBusqueda.Columns[2].HeaderText = "LIBRO";
            tablaBusqueda.Columns[3].HeaderText = "FOJA";
            tablaBusqueda.Columns[4].HeaderText = "PARTIDA";
            tablaBusqueda.Columns[5].HeaderText = "ACCION";

           

            //Centramos datos de las columnas
            tablaBusqueda.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tablaBusqueda.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tablaBusqueda.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tablaBusqueda.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tablaBusqueda.AutoResizeColumns();
            //Establecemos ancho de la columna nombres
            tablaBusqueda.Columns[0].Width = 400;
            //Oculto columna inicial
            tablaBusqueda.RowHeadersVisible = false;
            
        }

        private void informacionDeLaParroquiaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bautismoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Libros l = new Libros(1);
                l.ShowDialog();
            }
            catch (Exception g) { MessageBox.Show("Error: " + g.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void confirmaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
             try
            {
                Libros l = new Libros(2);
                l.ShowDialog();
            }
             catch (Exception g) { MessageBox.Show("Error: " + g.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void primeraComuniónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Libros l = new Libros(3);
                l.ShowDialog();
            }
            catch (Exception g) { MessageBox.Show("Error: " + g.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void matrimonioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Libros l = new Libros(4);
                l.ShowDialog();
            }
            catch (Exception g) { MessageBox.Show("Error: " + g.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
