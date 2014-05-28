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
        static ConexionBD BDatos;

        public static MySqlDataAdapter Adaptador;
        public static DataSet ds;


        public Parroquia()
        {
            BDatos = new ConexionBD();
            BDatos.conexion();
            InitializeComponent();

        }

        public void Pintar_tabla(String filtro, String libros)
        {
            Adaptador = new MySqlDataAdapter("select id_confirmacion as id,id_libro,id_categoria, nombre,anio,nombre_categoria,nombre_libro, num_hoja,num_partida" +
           " from confirmaciones natural join libros natural join categorias where (nombre like '%" + filtro + "%' or anio = '"+filtro+"') "+libros+" union " +
           "select id_matrimonio as id,id_libro,id_categoria, novio as nombre,anio,nombre_categoria,nombre_libro,  num_hoja,num_partida" +
           " from matrimonios natural join libros natural join categorias where (novio like '%" + filtro + "%' or anio = '" + filtro + "') "+libros+" union " +
            "select id_matrimonio as id,id_libro,id_categoria, novia as nombre,anio,nombre_categoria,nombre_libro,  num_hoja,num_partida" +
           " from matrimonios natural join libros natural join categorias where (novia like '%" + filtro + "%' or anio = '" + filtro + "') "+libros+" union " +
           "select id_comunion as id,id_libro,id_categoria, nombre,anio,nombre_categoria,nombre_libro,  num_hoja,num_partida" +
           " from comuniones natural join libros natural join categorias where (nombre like '%" + filtro + "%' or anio = '" + filtro + "') "+libros+" union " +
           " select id_bautismo as id,id_libro,id_categoria, nombre,anio,nombre_categoria,nombre_libro,  num_hoja,num_partida" +
           " from bautismos natural join libros natural join categorias where (nombre like '%" + filtro + "%' or anio = '" + filtro + "') "+libros+" order by nombre asc ",
           ConexionBD.conex);
            ds = new DataSet();
            Adaptador.Fill(ds, "prueba");

            BDatos.Desconectar();
            
            tablaBusqueda.DataSource = ds;
            tablaBusqueda.DataMember = "prueba";

            //Ancho de columnas al tamaño del contenido
            tablaBusqueda.AutoResizeColumns();

            //Agregamos nombre de headers de las columnas
            tablaBusqueda.Columns[0].Visible = false;
            tablaBusqueda.Columns[0].HeaderText = "ID";

            tablaBusqueda.Columns[1].Visible = false;
            tablaBusqueda.Columns[1].HeaderText = "ID_LIBRO";

            tablaBusqueda.Columns[2].Visible = false;

            tablaBusqueda.Columns[3].HeaderText = "NOMBRE";
            tablaBusqueda.Columns[3].Width = 420;

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
           
            if (e.RowIndex >= 0)
            {
                if (int.Parse(tablaBusqueda["id_categoria", e.RowIndex].Value + "") == 1)
                {
                    InsertarBautismo ib = new InsertarBautismo(int.Parse(tablaBusqueda["ID", e.RowIndex].Value + ""), tablaBusqueda["nombre_libro", e.RowIndex].Value + "");
                    ib.ShowDialog();
                }else
                if (int.Parse(tablaBusqueda["id_categoria", e.RowIndex].Value + "") == 2)
                {
                    InsertarConfirmacion ic = new InsertarConfirmacion(int.Parse(tablaBusqueda["ID", e.RowIndex].Value + ""), tablaBusqueda["nombre_libro", e.RowIndex].Value + "");
                    ic.ShowDialog();
                }
                else
                if (int.Parse(tablaBusqueda["id_categoria", e.RowIndex].Value + "") == 3)
                {
                    InsertarPrimerComunion ipc = new InsertarPrimerComunion(int.Parse(tablaBusqueda["ID", e.RowIndex].Value + ""), tablaBusqueda["nombre_libro", e.RowIndex].Value + "");
                    ipc.ShowDialog();
                }
                else
                if (int.Parse(tablaBusqueda["id_categoria", e.RowIndex].Value + "") == 4)
                {
                    InsertarMatrimonios im = new InsertarMatrimonios(int.Parse(tablaBusqueda["ID", e.RowIndex].Value + ""), tablaBusqueda["nombre_libro", e.RowIndex].Value + "");
                    im.ShowDialog();
                }
               
            }

        
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
            if (e.KeyChar == 13)
                btnbuscar.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string libro = "";
            if (librobautismo.Checked)
                libro = "and id_categoria = 1";
            else if (libroconfirmacion.Checked)
                libro = "and id_categoria = 2";
            else if (librocomunion.Checked)
                libro = "and id_categoria = 3";
            else if (libromatrimonio.Checked)
                libro = "and id_categoria = 4";

            Pintar_tabla(busqueda.Text, libro);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToLongTimeString()+"                Fecha:   "+DateTime.Now.ToLongDateString();
        }

        public void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void acercaDeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new acercade().ShowDialog() ;
        }

    }
}
