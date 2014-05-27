using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using conexionbd;
using MySql.Data.MySqlClient;

namespace Parroquia
{
    public partial class Libros : Form
    {
        //Declaro variable global tipo publica para recibir 
        //como parametros de que categoria se quiero abrir el libro
        private int CATEGORIA;
        private String Categorias;

        private MySqlDataReader conjuntoDatos;
        private int tamanio;
        private ConexionBD BDatos;

        //constructor me recibe los parametros de la categoria 
        //de donde se manda llamar.
        public Libros(int categoria)
        {
            //Asigno los parametos recibidos a la variable global
            CATEGORIA = categoria;

            if (CATEGORIA == 1)
                this.Categorias = "Bautismo";
            if (CATEGORIA == 2)
                this.Categorias = "Confirmación";
            if (CATEGORIA == 3)
                this.Categorias = "Primera Comunión";
            if (CATEGORIA == 4)
                this.Categorias = "Matrimonio";
        
            try
            {
                //Realizo conexion a la base de datos
                BDatos = new ConexionBD();
                BDatos.conexion();
                InitializeComponent();
            }
            catch (Exception h)
            {
                Dispose();
                MessageBox.Show("Error al conectar al servidor de MySQL: " +
                    h.Message, "Error al conectar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        public void crearLibro(object sender, EventArgs e)
        {
            crearLibro cl = new crearLibro(CATEGORIA);
            cl.ShowDialog();

            panelContenedorLibros.Controls.Clear();
            BDatos.conexion();
            Pintar();
            BDatos.Desconectar();
        }

        public void eliminarLibro(object sender, EventArgs e)
        {
            eliminarLibro El = new eliminarLibro(CATEGORIA,tamanio);
            El.ShowDialog();
            panelContenedorLibros.Controls.Clear();
            BDatos.conexion();
            Pintar();
            BDatos.Desconectar();
        }

        public void cancelarVentana(object sender, EventArgs e)
        {
            Dispose();
        }

        public void Insertar(object sender, EventArgs e)
        {
            if (CATEGORIA == 1)
            {
                Button b = (Button)sender;
                InsertarBautismo ib = new InsertarBautismo(b.Name.ToString());
                ib.ShowDialog(); 
            }

            if (CATEGORIA == 2)
            {
                Button b = (Button)sender;
                InsertarConfirmacion ic = new InsertarConfirmacion(b.Name.ToString());
                ic.ShowDialog();
                
            }

            if (CATEGORIA == 3)
            {
                Button b = (Button)sender;
                InsertarPrimerComunion ipc = new InsertarPrimerComunion(b.Name.ToString());
                ipc.ShowDialog();

            }

            if (CATEGORIA == 4)
            {
                Button b = (Button)sender;
                InsertarMatrimonios im = new InsertarMatrimonios(b.Name.ToString());
                im.ShowDialog();

            }
        }

        public void editarLibro(object sender, EventArgs e) 
        {
            editarLibro Editl = new editarLibro(CATEGORIA, tamanio);
            Editl.ShowDialog();
            panelContenedorLibros.Controls.Clear();
            BDatos.conexion();
            Pintar();
            BDatos.Desconectar();
        }

    }
}
