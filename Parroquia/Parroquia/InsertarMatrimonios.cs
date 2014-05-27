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
    public partial class InsertarMatrimonios : Form
    {
        private String ID_LIBRO;
        private int Partida;
        private double Hoja;
        static public Object[] anios;

        //VARIABLES OCUPADAS PARA LA EDICION
        private int ID_REGISTRO;
        private Boolean edicion;
        private Boolean btn = false;

        MySqlDataReader Datos;
        ConexionBD Bdatos = new ConexionBD();

        public InsertarMatrimonios(String ID_libro)
        {
            ID_LIBRO = ID_libro;

            anios = new Object[(DateTime.Now.Year - 1970) + 1];
            int u = 0;
            for (int i = 1970; i <= DateTime.Now.Year; i++)
            {
                anios[u] = i;
                u++;
            }

            InitializeComponent();

            try
            {
                Bdatos.conexion();

                Datos = Bdatos.obtenerBasesDatosMySQL("select nombre_libro from libros where id_libro=" + ID_LIBRO + ";");

                if (Datos.HasRows)
                {
                    while (Datos.Read())
                    {
                        textBox1.Text = Datos.GetString(0).ToString();

                    }
                }
                Datos.Close();

                /*Estableciendo la partida*/
                Partida = 0;
                Datos = Bdatos.obtenerBasesDatosMySQL("select id_matrimonio from matrimonios;");

                if (Datos.HasRows)
                {
                    while (Datos.Read())
                    {
                        Partida++;
                    }
                }

                textBox3.Text = "" + (Partida + 1);

                /*CALCULANDO LA HOJA*/
                Hoja = Math.Ceiling((Partida + 1) / 10.0);

                textBox2.Text = "" + Hoja;


                Bdatos.Desconectar();
            }
            catch (Exception r) { MessageBox.Show("Error: " + r.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        //CONSTRUCTOR PARA EDICIONES
        public InsertarMatrimonios(int id_registro, String NOMMBRE_LIBRO)
        {
            edicion = true;
            ID_REGISTRO = id_registro;

            anios = new String[(DateTime.Now.Year - 1970) + 1];
            int u = 0;
            for (int i = 1970; i <= DateTime.Now.Year; i++)
            {
                anios[u] = i+"";
                u++;
            }

            InitializeComponent();
            //Establecemos los componentes sin edicion
        /*    nombre.Enabled = false;
            padre.Enabled = false;
            madre.Enabled = false;
            fechaPrimerCom.Enabled = false;
            lugar_bautismo.Enabled = false;
            fecha_bautism.Enabled = false;
            padrino.Enabled = false;
            madrina.Enabled = false;
            anioCombo.Enabled = false;*/

            try
            {  
                textBox1.Text = NOMMBRE_LIBRO;
                Bdatos.conexion();

                Datos = Bdatos.obtenerBasesDatosMySQL("SELECT * FROM matrimonios where id_matrimonio = " + ID_REGISTRO);

                if (Datos.HasRows)
                {
                    while (Datos.Read())
                    {
                        textBox2.Text = Datos.GetString(2);
                        textBox3.Text = Datos.GetString(3);
                     /*   nombre.Text = Datos.GetString(4);
                        padre.Text = Datos.GetString(5);
                        madre.Text = Datos.GetString(6);
                        fechaPrimerCom.Text = Datos.GetString(7);
                        fecha_bautism.Text = Datos.GetString(8);
                        lugar_bautismo.Text = Datos.GetString(9);
                        padrino.Text = Datos.GetString(10);
                        madrina.Text = Datos.GetString(11); 
                        anioCombo.Text = Datos.GetString(12);*/
                    }
                }
                Bdatos.Desconectar();
            }
            catch (Exception j)
            {
                MessageBox.Show("Error al mostrar edicion. "+j.Message, " Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guardarConfirBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Bdatos.conexion();

                if ((novio.Text.ToString().CompareTo("") == 0) ||
                    (novia.Text.ToString().CompareTo("") == 0) ||
                    (testigo1.Text.ToString().CompareTo("") == 0) ||
                    (lugar_celebracion.Text.ToString().CompareTo("") == 0) ||
                    (testigo2.Text.ToString().CompareTo("") == 0) ||
                    (asistente.Text.ToString().CompareTo("") == 0))
                    MessageBox.Show("Los campos marcados con el asterisco rojo son obligatorios, por favor llene los campos obligarios para guardar.", " Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {//Se guardan todos los campos en la base de datos
                    if (Bdatos.Insertar("insert into matrimonios(id_libro,num_hoja,num_partida,novio,novia,fecha_matrimonio,lugar_celebracion,testigo1,testigo2,asistente,nota_marginal,anio)" +
                        " values('" + int.Parse(ID_LIBRO) +
                        "','" + int.Parse(textBox2.Text.ToString()) +
                        "','" + int.Parse(textBox3.Text.ToString()) +
                        "','" + novio.Text.ToString() +
                        "','" + novia.Text.ToString() +
                        "','" + fecha_Matrimonio.Value.ToString("yyyy-MM-dd") +
                        "','" + lugar_celebracion.Text.ToString() +
                        "','" + testigo1.Text.ToString() +
                        "','" + testigo2.Text.ToString() +
                        "','" + asistente.Text.ToString() +
                        "','" + notas_marginales.Text.ToString() +
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
                        novio.Text = "";
                        novia.Text = "";
                        lugar_celebracion.Text = "";
                        testigo1.Text = "";
                        testigo2.Text = "";
                        asistente.Text = "";
                        notas_marginales.Text = "";
                        fecha_Matrimonio.Value = DateTime.Now;
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

        private void botones(KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                guardarConfirBtn.PerformClick();
        }

        private void padre_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
        }

        private void madre_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
        }

        private void lugar_bautismo_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
        }

        private void padrino_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
        }

        private void madrina_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
        }

        private void ministro_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
        }

        private void cancelBtnConfirmacion_Click(object sender, EventArgs e)
        {
            Dispose();
        }


    }
}
