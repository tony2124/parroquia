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
        string usuario, contrasena, basedatos, host;
        public static string conex;
        private MySqlConnection conexionBD;

        public ConexionBD(string host, string usuario, string contrasena, string basedatos)
        {
            this.host = host;
            this.usuario = usuario;
            this.contrasena = contrasena;
            this.basedatos = basedatos;
        }

        public ConexionBD()
        {
            host = "localhost";
            usuario = "root";
            contrasena = "";
            basedatos = "parroquiaantunez";
        }

        public void conexion()
        {
            try
            {
                conex = "server="+host+"; port=3306; user id=" + usuario + "; password=" + contrasena + "; database=parroquiaantunez;";
                conexionBD = new MySqlConnection(conex);
                conexionBD.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar al servidor de MySQL: " +
                    ex.Message, "Error al conectar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
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
                MessageBox.Show("Error al obtener bases de datos de MySQL: " +
                    ex.Message, "Error al obtener catálogos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error al ingresar datos en MySQL: " + ex.Message, " Error al ingresar ",            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        public void Desconectar()
        {
            conexionBD.Close();
        }


    }
}