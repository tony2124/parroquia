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

            //Realizo conexion a la base de datos
            BDatos = new ConexionBD();
            BDatos.conexion();

           InitializeComponent();
        }

        public void crearLibro(object sender, EventArgs e)
        {
           /* BDatos.conexion();

            //Evaluacion para que los nombres no sean iguales
            String nombreLibro = "LIBRO " + (tamanio + 1);
            int iguales = 0;
            MySqlDataReader Datos = BDatos.obtenerBasesDatosMySQL("select nombre_libro from libros");
            if(Datos.HasRows)
                while (Datos.Read())
                {
                    if (Datos.GetString(0).CompareTo(nombreLibro) == 0)
                    {
                        iguales++;
                        
                    }
                }
            if(iguales>0)
            nombreLibro = nombreLibro + " ("+iguales+")";

            Datos.Close();
            if (BDatos.Insertar("insert into libros (id_categoria, nombre_libro) values("+CATEGORIA+",'"+nombreLibro+"');") > 0)
            {
                //cada vez que agrego un libro verifico si tiene un label el panel
                //y si es el caso, lo quito
                if (panelContenedorLibros.Controls.Contains(label1))
                    panelContenedorLibros.Controls.Remove(label1);
               
                    
                Pintar();
                MessageBox.Show("Se ha agregado un libro nuevo"
                    , " Acción ejecutada con exito ",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Se ha detectado un problema al agregar un libro"
                   , " Error ",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            BDatos.Desconectar();*/
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

    }
}
