using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parroquia;

namespace conexionbd
{
    class ConexionBD
    {
        public static string usuario, contrasena, basedatos, host, puerto;
        public static bool carga_datos_desde_archivo = false;
        public static string conex;
        private MySqlConnection conexionBD;
        

        public ConexionBD(string h, string u, string pass, string port, string bd)
        {
            host = h;
            usuario = u;
            contrasena = pass;
            puerto = port;
            basedatos = bd;
        }

        public ConexionBD()
        {
            if (!carga_datos_desde_archivo)
            {
                host = "localhost";
                usuario = "root";
                contrasena = "SIMPUS2124--";
                puerto = "3306";
                basedatos = "parroquiaantunez";
            }
        }

        public void conexion()
        {
            try
            {
                conex = "server="+host+"; port="+puerto+"; user id=" + usuario + "; password=" + contrasena + "; database="+basedatos+";";
                conexionBD = new MySqlConnection(conex);
                conexionBD.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar a la base de datos de MySQL: \nDETALLES DEL ERROR: " + ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                carga_desde_archivo();
            }
        }

        public void carga_desde_archivo()
        {
            if (!carga_datos_desde_archivo)
            {
                carga_datos_desde_archivo = true;

                /** OBTENER LA INFORMACIÓN DEL ARCHIVO **/
                string line, archivo = "";
                System.IO.StreamReader file = new System.IO.StreamReader(@"C:\DOCSParroquia\informacion.txt");
                while ((line = file.ReadLine()) != null)
                {
                    archivo += line;
                }

                string[] caracteres = archivo.Split(' ');
                ConexionBD.host = caracteres[0];
                ConexionBD.usuario = caracteres[1];
                ConexionBD.contrasena = caracteres[2];
                ConexionBD.puerto = caracteres[3];
                ConexionBD.basedatos = caracteres[4];
                MessageBox.Show("" + caracteres.Length + "\n" + "LOCALHOST: " + caracteres[0] + "\nUSUARIO:" + caracteres[1]);
                file.Close();

                conexion();
            }
            else
            {
                new DatosConexionDB().ShowDialog();
            }
        }

        public MySqlDataReader obtenerBasesDatosMySQL(String consulta)
        {
            MySqlDataReader registrosObtenidosMySQL = null;

            MySqlCommand cmd = new MySqlCommand(consulta, conexionBD);
            try
            {
                registrosObtenidosMySQL = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al obtener bases de datos de MySQL: \nDETALLES DEL ERROR: " + ex.Message, "Error al obtener catálogos",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return registrosObtenidosMySQL;
        }

        public int peticion(String consulta)
        {
         
            int resultado=0;
            try
            {
                MySqlCommand cmd = new MySqlCommand(consulta, conexionBD);
                resultado = cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al ingresar datos en MySQL: \nDETALLES DEL ERROR: " + ex.Message, " Error al ingresar ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        public void Desconectar()
        {
            conexionBD.Close();
        }
    }
}