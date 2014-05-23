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
    public partial class InsertarConfirmacion : Form
    {
        private String ID_LIBRO;
        private int Partida;
        private double Hoja;


        MySqlDataReader Datos;
        ConexionBD Bdatos = new ConexionBD();

        public InsertarConfirmacion(String ID_libro)
        {
            ID_LIBRO = ID_libro;
            //MessageBox.Show(ID_LIBRO);
            InitializeComponent();
            try
            {
                Bdatos.conexion();

                Datos = Bdatos.obtenerBasesDatosMySQL("select nombre_libro from libros where id_libro="+ID_LIBRO+";");

                if (Datos.HasRows)
                {
                    while (Datos.Read()) {
                        textBox1.Text = Datos.GetString(0).ToString();
                        
                    }
                }
                Datos.Close();

                /*Estableciendo la partida*/
                Partida = 0;
                Datos = Bdatos.obtenerBasesDatosMySQL("select id_confirmacion from confirmaciones;");

                if (Datos.HasRows)
                {
                    while (Datos.Read())
                    {
                        Partida++;
                    }
                }

                textBox3.Text = "" + (Partida+1);
         
                /*CALCULANDO LA HOJA*/
                Hoja = Math.Ceiling((Partida + 1) / 10.0);

                textBox2.Text = "" + Hoja;
               

                Bdatos.Desconectar();
            }
            catch (Exception r) { MessageBox.Show("Error: " + r.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void guardarConfirBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Bdatos.conexion();

                if ((nombre.Text.ToString().CompareTo("") == 0) ||
                    (padre.Text.ToString().CompareTo("") == 0) ||
                    (madre.Text.ToString().CompareTo("") == 0) ||
                    (padrino.Text.ToString().CompareTo("") == 0) ||
                    (madrina.Text.ToString().CompareTo("") == 0) ||
                    (lugar_bautismo.Text.ToString().CompareTo("") == 0) ||
                    (ministro.Text.ToString().CompareTo("") == 0))
                    MessageBox.Show("Tiene que llenar todos los campos para poder guardar", " Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (Bdatos.Insertar("insert into confirmaciones(id_libro,num_hoja,num_partida,nombre,padre,madre,padrino,madrina,fecha_bautismo,fecha_confirmacion,lugar_bautismo,ministro,anio)" +
                        " values('" + int.Parse(ID_LIBRO) +
                        "','" + int.Parse(textBox2.Text.ToString()) +
                        "','" + int.Parse(textBox3.Text.ToString()) +
                        "','" + nombre.Text.ToString() +
                        "','" + padre.Text.ToString() +
                        "','" + madre.Text.ToString() +
                        "','" + padrino.Text.ToString() +
                        "','" + madrina.Text.ToString() +
                        "','" + fecha_bautism.Value.ToString("yyyy-MM-dd") +
                         "','" + fecha_Confirm.Value.ToString("yyyy-MM-dd") +
                         "','" + lugar_bautismo.Text.ToString() +
                         "','" + ministro.Text.ToString() +
                        "','" + anioCombo.Text.ToString() +
                        "');") > 0)
                    {
                        MessageBox.Show("Datos ingresados correctamente ", " Acción exitosa",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Partida++;
                        textBox3.Text = "" + (Partida + 1);

                        Hoja = Math.Ceiling((Partida + 1) / 10.0);
                        textBox2.Text = "" + Hoja;

                        /*Se establecen en blanco todos los campos*/
                        nombre.Text = "";
                        padre.Text = "";
                        madre.Text = "";
                        padrino.Text = "";
                        madrina.Text = "";
                        fecha_bautism.Value = DateTime.Now;
                        fecha_Confirm.Value = DateTime.Now;
                        lugar_bautismo.Text = "";
                        ministro.Text = "";
                        anioCombo.Text = DateTime.Now.Year.ToString();
                    }
                    else MessageBox.Show("Error al ingresar datos en MySQL ", " Error al ingresar ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Bdatos.Desconectar();
                }
                
                
            }
            catch (Exception y)
            {
                MessageBox.Show("Error al ingresar datos en MySQL: " +
                    y.Message, " Error al ingresar ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        private void guardaImprimeBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
