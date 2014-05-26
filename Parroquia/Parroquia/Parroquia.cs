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

            Adaptador = new MySqlDataAdapter("select id_confirmacion as id,id_libro,id_categoria, nombre,anio,nombre_categoria,nombre_libro, num_hoja,num_partida" +
            " from confirmaciones natural join libros natural join categorias union "+
            "select id_matrimonio as id,id_libro,id_categoria, novio as nombre,anio,nombre_categoria,nombre_libro,  num_hoja,num_partida" +
            " from matrimonios natural join libros natural join categorias union " +
             "select id_matrimonio as id,id_libro,id_categoria, novia as nombre,anio,nombre_categoria,nombre_libro,  num_hoja,num_partida" +
            " from matrimonios natural join libros natural join categorias union " +
            "select id_comunion as id,id_libro,id_comunion, nombre,anio,nombre_categoria,nombre_libro,  num_hoja,num_partida" +
            " from comuniones natural join libros natural join categorias union " +
            " select id_bautismo as id,id_libro,id_categoria, nombre,anio,nombre_categoria,nombre_libro,  num_hoja,num_partida" +
            " from bautismos natural join libros natural join categorias order by nombre asc ",
            "server=localhost; port=3306; user id=root; password=; database=parroquiaantunez;");
            ds = new DataSet();
            Adaptador.Fill(ds,"prueba");

            BDatos.Desconectar();
            InitializeComponent();
            tablaBusqueda.DataSource = ds;
            tablaBusqueda.DataMember = "prueba";

            //Agregamos el boton de accion despues de todas las columnas
            this.tablaBusqueda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uu});

            //Ancho de columnas al tamaño del contenido
            tablaBusqueda.AutoResizeColumns();

            //Agregamos nombre de headers de las columnas
            tablaBusqueda.Columns[0].Visible = false;
            tablaBusqueda.Columns[1].Visible = false;
            tablaBusqueda.Columns[2].Visible = false;

            tablaBusqueda.Columns[3].HeaderText = "NOMBRE";
            tablaBusqueda.Columns[3].Width = 380;

            tablaBusqueda.Columns[4].HeaderText = "AÑO";
            tablaBusqueda.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tablaBusqueda.Columns[5].HeaderText = "CATEGORIA";
            tablaBusqueda.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tablaBusqueda.Columns[6].HeaderText = "LIBRO";
            tablaBusqueda.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tablaBusqueda.Columns[7].HeaderText = "FOJA";
            tablaBusqueda.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tablaBusqueda.Columns[8].HeaderText = "PARTIDA";
            tablaBusqueda.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //Oculto columna inicial
            tablaBusqueda.RowHeadersVisible = false;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(e.RowIndex+": "+tablaBusqueda.Rows[e.RowIndex].Cells[0].Value);
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
