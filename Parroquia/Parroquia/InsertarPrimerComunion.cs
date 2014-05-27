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
    public partial class InsertarPrimerComunion : Form
    {
        private String ID_LIBRO;
        private int Partida;
        private double Hoja;
        public static String[] anios;

        //VARIABLES OCUPADAS PARA LA EDICION
        private int ID_REGISTRO;
        private Boolean edicion;
        private Boolean btn = false;


        MySqlDataReader Datos;
        ConexionBD Bdatos = new ConexionBD();

        public InsertarPrimerComunion(String ID_libro)
        {
            edicion = false;
            ID_LIBRO = ID_libro;

            anios = new String[(DateTime.Now.Year - 1970)+1];
            int u = 0;
            for (int i = 1970; i <= DateTime.Now.Year; i++)
            {
                anios[u] = i+"";
                u++;
            }
                
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
                Datos = Bdatos.obtenerBasesDatosMySQL("select id_comunion from comuniones;");

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


        //CONSTRUCTOR PARA EDICIONES
        public InsertarPrimerComunion(int id_registro, String NOMMBRE_LIBRO)
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
            nombre.Enabled = false;
            padre.Enabled = false;
            madre.Enabled = false;
            fechaPrimerCom.Enabled = false;
            lugar_bautismo.Enabled = false;
            fecha_bautism.Enabled = false;
            padrino.Enabled = false;
            madrina.Enabled = false;
            anioCombo.Enabled = false;

            try
            {  
                textBox1.Text = NOMMBRE_LIBRO;
                Bdatos.conexion();

                Datos = Bdatos.obtenerBasesDatosMySQL("SELECT * FROM comuniones where id_comunion = " + ID_REGISTRO);

                if (Datos.HasRows)
                {
                    while (Datos.Read())
                    {
                        textBox2.Text = Datos.GetString(2);
                        textBox3.Text = Datos.GetString(3);
                        nombre.Text = Datos.GetString(4);
                        padre.Text = Datos.GetString(5);
                        madre.Text = Datos.GetString(6);
                        fechaPrimerCom.Text = Datos.GetString(7);
                        fecha_bautism.Text = Datos.GetString(8);
                        lugar_bautismo.Text = Datos.GetString(9);
                        padrino.Text = Datos.GetString(10);
                        madrina.Text = Datos.GetString(11); 
                        anioCombo.Text = Datos.GetString(12);
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



        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void guardarConfirBtn_Click(object sender, EventArgs e)
        {
            if (!edicion) //SI NO ESTA PUESTO EDICION SE GUARDA NORMALMENTE
            {
                try
                {
                    Bdatos.conexion();

                    if ((nombre.Text.ToString().CompareTo("") == 0) ||
                        (padre.Text.ToString().CompareTo("") == 0) ||
                        (madre.Text.ToString().CompareTo("") == 0) ||
                        (padrino.Text.ToString().CompareTo("") == 0) ||
                        (madrina.Text.ToString().CompareTo("") == 0) ||
                        (lugar_bautismo.Text.ToString().CompareTo("") == 0))
                        MessageBox.Show("Los campos marcados con el asterisco rojo son obligatorios, por favor llene los campos obligarios para guardar.", " Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {//Se guardan todos los campos en la base de datos
                        if (Bdatos.Insertar("insert into comuniones(id_libro,num_hoja,num_partida,nombre,padre,madre,fecha_comunion,fecha_bautismo,lugar_bautismo,padrino,madrina,anio)" +
                            " values('" + int.Parse(ID_LIBRO) +
                            "','" + int.Parse(textBox2.Text.ToString()) +
                            "','" + int.Parse(textBox3.Text.ToString()) +
                            "','" + nombre.Text.ToString() +
                            "','" + padre.Text.ToString() +
                            "','" + madre.Text.ToString() +
                            "','" + fechaPrimerCom.Value.ToString("yyyy-MM-dd") +
                            "','" + fecha_bautism.Value.ToString("yyyy-MM-dd") +
                            "','" + lugar_bautismo.Text.ToString() +
                            "','" + padrino.Text.ToString() +
                            "','" + madrina.Text.ToString() +
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
                            nombre.Focus();
                            padre.Text = "";
                            madre.Text = "";
                            padrino.Text = "";
                            madrina.Text = "";
                            fecha_bautism.Value = DateTime.Now;
                            fechaPrimerCom.Value = DateTime.Now;
                            lugar_bautismo.Text = "";
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
            else //SI LA EDICION ESTA PUESTA
            {
                if (btn == false)
                {
                    btn = true;
                    this.guardarConfirBtn.Text = "Guardar registro";
                    this.guardaImprimeBtn.Enabled = false;

                    //Permitimes edicion a los componentes
                    nombre.Enabled = true;
                    padre.Enabled = true;
                    madre.Enabled = true;
                    fechaPrimerCom.Enabled = true;
                    lugar_bautismo.Enabled = true;
                    fecha_bautism.Enabled = true;
                    padrino.Enabled = true;
                    madrina.Enabled = true;
                    anioCombo.Enabled = true;
                }
                else
                {
                    //Actualizamos datos en la base de datos
                    if ((nombre.Text.ToString().CompareTo("") == 0) ||
                       (padre.Text.ToString().CompareTo("") == 0) ||
                       (madre.Text.ToString().CompareTo("") == 0) ||
                       (padrino.Text.ToString().CompareTo("") == 0) ||
                       (madrina.Text.ToString().CompareTo("") == 0) ||
                       (lugar_bautismo.Text.ToString().CompareTo("") == 0))
                        MessageBox.Show("Los campos marcados con el asterisco rojo son obligatorios, por favor llene los campos obligarios para guardar.", " Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        Bdatos.conexion();
                        //Se hace la actualizacion en la base de datos
                        if (Bdatos.Actualizar("UPDATE comuniones SET nombre='" + nombre.Text.ToString() +
                             "',padre='" + padre.Text.ToString() + "',madre='" + madre.Text.ToString() +
                             "',fecha_comunion='" + fechaPrimerCom.Value.ToString("yyyy-MM-dd") + "',fecha_bautismo='" + fecha_bautism.Value.ToString("yyyy-MM-dd") +
                             "',lugar_bautismo='" + lugar_bautismo.Text.ToString() + "',padrino='" + padrino.Text.ToString() +
                             "',madrina='" + madrina.Text.ToString() +"',anio='" + anioCombo.Text.ToString() + 
                             "' where id_comunion= '" + ID_REGISTRO + "';") > 0)
                        {
                            MessageBox.Show("Registro actualizado correctamente ", " Acción exitosa",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btn = false;
                            this.guardarConfirBtn.Text = "Editar registro";
                            this.cancelBtnConfirmacion.Enabled = true;
                            this.guardaImprimeBtn.Enabled = true;


                            //actualizamos la tabla
                            Parroquia.btnbuscar.PerformClick();
                            //Establecemos los componentes sin edicion
                            nombre.Enabled = false;
                            padre.Enabled = false;
                            madre.Enabled = false;
                            fechaPrimerCom.Enabled = false;
                            lugar_bautismo.Enabled = false;
                            fecha_bautism.Enabled = false;
                            padrino.Enabled = false;
                            madrina.Enabled = false;
                            anioCombo.Enabled = false;
                        }
                        else
                            MessageBox.Show("Error al actualizar datos en MySQL ", " Error al ingresar ",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Bdatos.Desconectar();
                    }
                }

            }
        }

        private void guardaImprimeBtn_Click(object sender, EventArgs e)
        {

        }


        private void nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
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

    }
}
