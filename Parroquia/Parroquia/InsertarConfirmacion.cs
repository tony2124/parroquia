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
        public static String[] anios;

        //VARIABLES OCUPADAS PARA LA EDICION
        private int ID_REGISTRO;
        private Boolean edicion;
        private Boolean btn = false;


        MySqlDataReader Datos;
        ConexionBD Bdatos = new ConexionBD();

        public InsertarConfirmacion(String ID_libro)
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
                Datos = Bdatos.obtenerBasesDatosMySQL("select id_confirmacion from confirmaciones where id_libro =" + ID_LIBRO + ";");

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
        public InsertarConfirmacion(int id_registro,  String NOMMBRE_LIBRO)
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
            fecconf.Enabled = false;
            lugarbau.Enabled = false;
            fecbau.Enabled = false;
            padrino.Enabled = false;
            madrina.Enabled = false;
            ministro.Enabled = false;
            anioCombo.Enabled = false;
            registronull.Enabled = false;

            try
            {  
                textBox1.Text = NOMMBRE_LIBRO;
                Bdatos.conexion();

                Datos = Bdatos.obtenerBasesDatosMySQL("SELECT * FROM confirmaciones where id_confirmacion = " + ID_REGISTRO);

                if (Datos.HasRows)
                {
                    while (Datos.Read())
                    {
                        textBox2.Text = Datos.GetString(2);
                        textBox3.Text = Datos.GetString(3);
                        nombre.Text = Datos.GetString(4);
                        padre.Text = Datos.GetString(5);
                        madre.Text = Datos.GetString(6);
                        fecconf.Text = Datos.GetString(7);
                        fecbau.Text = Datos.GetString(8);
                        lugarbau.Text = Datos.GetString(9);
                        padrino.Text = Datos.GetString(10);
                        madrina.Text = Datos.GetString(11);
                        ministro.Text = Datos.GetString(12);
                        anioCombo.Text = Datos.GetString(13);
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

            if (!edicion)//si no esta puesta edicion se guarda normalmente
            {
                try
                {
                    Bdatos.conexion();
                    if (!registronull.Checked)
                    {
                        if ((nombre.Text.ToString().CompareTo("") == 0) ||
                       (padre.Text.ToString().CompareTo("") == 0) ||
                       (madre.Text.ToString().CompareTo("") == 0) ||
                       (padrino.Text.ToString().CompareTo("") == 0) ||
                       (madrina.Text.ToString().CompareTo("") == 0) ||
                       (lugarbau.Text.ToString().CompareTo("") == 0) ||
                       (ministro.Text.ToString().CompareTo("") == 0))
                        {
                            MessageBox.Show("Los campos marcados con el asterisco rojo son obligatorios, por favor llene los campos obligarios para guardar.", " Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    //Se guardan todos los campos en la base de datos

                    if (Bdatos.Insertar("insert into confirmaciones(id_libro,num_hoja,num_partida,nombre,padre,madre,fecha_confirmacion,fecha_bautismo,lugar_bautismo,padrino,madrina,presbitero,anio)" +
                            " values('" + int.Parse(ID_LIBRO) +
                            "','" + int.Parse(textBox2.Text.ToString()) +
                            "','" + int.Parse(textBox3.Text.ToString()) +
                            "','" + nombre.Text.ToString() +
                            "','" + padre.Text.ToString() +
                            "','" + madre.Text.ToString() +
                            "','" + fecconf.Value.ToString("yyyy-MM-dd") +
                            "','" + fecbau.Value.ToString("yyyy-MM-dd") +
                            "','" + lugarbau.Text.ToString() +
                            "','" + padrino.Text.ToString() +
                            "','" + madrina.Text.ToString() +
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

                        //actualizamos la tabla
                        //Parroquia.tablaBusqueda.Columns.Clear();
                        //Parroquia.Pintar_tabla();

                        /*Se establecen en blanco todos los campos*/
                        nombre.Text = "";
                        nombre.Focus();
                        padre.Text = "";
                        madre.Text = "";
                        padrino.Text = "";
                        madrina.Text = "";
                        fecbau.Value = DateTime.Now;
                        fecconf.Value = DateTime.Now;
                        lugarbau.Text = "";
                        ministro.Text = "";
                    }
                    else MessageBox.Show("Error al ingresar datos en MySQL ", " Error al ingresar ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Bdatos.Desconectar();
                }
                catch (Exception y)
                {
                    MessageBox.Show("Error al ingresar datos en MySQL: " +
                        y.Message, " Error al ingresar ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }
            }
            else//Si edicion esta puesta
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
                    fecconf.Enabled = true;
                    lugarbau.Enabled = true;
                    fecbau.Enabled = true;
                    padrino.Enabled = true;
                    madrina.Enabled = true;
                    ministro.Enabled = true;
                    anioCombo.Enabled = true;
                    registronull.Enabled = true;
                    return;
                }
                else
                {
                    //Actualizamos datos en la base de datos
                    if (!registronull.Checked)
                    {
                        if ((nombre.Text.ToString().CompareTo("") == 0) ||
                       (padre.Text.ToString().CompareTo("") == 0) ||
                       (madre.Text.ToString().CompareTo("") == 0) ||
                       (padrino.Text.ToString().CompareTo("") == 0) ||
                       (madrina.Text.ToString().CompareTo("") == 0) ||
                       (lugarbau.Text.ToString().CompareTo("") == 0) ||
                       (ministro.Text.ToString().CompareTo("") == 0))
                        {
                            MessageBox.Show("Los campos marcados con el asterisco rojo son obligatorios, por favor llene los campos obligarios para guardar.", " Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    Bdatos.conexion();
                    
                    if (Bdatos.Actualizar("UPDATE confirmaciones SET nombre='" + nombre.Text.ToString() +
                             "',padre='" + padre.Text.ToString() + "',madre='" + madre.Text.ToString() +
                             "',fecha_confirmacion='" + fecconf.Value.ToString("yyyy-MM-dd") + "',fecha_bautismo='" + fecbau.Value.ToString("yyyy-MM-dd") +
                             "',lugar_bautismo='" + lugarbau.Text.ToString() + "',padrino='" + padrino.Text.ToString() +
                             "',madrina='" + madrina.Text.ToString() + "',presbitero='" + ministro.Text.ToString() +
                             "',anio='" + anioCombo.Text.ToString() + "' where id_confirmacion= '" + ID_REGISTRO + "';") > 0)
                        {
                            MessageBox.Show("Registro actualizado correctamente ", " Acción exitosa",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btn = false;
                            this.guardarConfirBtn.Text = "Editar registro";
                            this.cancelBtnConfirmacion.Enabled = true;
                            this.guardaImprimeBtn.Enabled = true;

                            //Establecemos los componentes sin edicion
                            registronull.Checked = false;
                            nombre.Enabled = false;
                            padre.Enabled = false;
                            madre.Enabled = false;
                            fecconf.Enabled = false;
                            lugarbau.Enabled = false;
                            fecbau.Enabled = false;
                            padrino.Enabled = false;
                            madrina.Enabled = false;
                            ministro.Enabled = false;
                            anioCombo.Enabled = false;
                            registronull.Enabled = false;

                            //actualizar tabla de busqueda
                            Parroquia.btnbuscar.PerformClick();
                        }
                        else
                        MessageBox.Show("Error al actualizar datos en MySQL ", " Error al ingresar ",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Bdatos.Desconectar();
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

        private void registronull_CheckedChanged(object sender, EventArgs e)
        {
            if (registronull.Checked)
            {
                nombre.Text = "";
                nombre.Enabled = false;
                padre.Text = "";
                padre.Enabled = false;
                madre.Text = "";
                madre.Enabled = false;
                fecconf.Text = "";
                fecconf.Enabled = false;
                fecbau.Text = "";
                fecbau.Enabled = false;
                lugarbau.Text = "";
                lugarbau.Enabled = false;
                padrino.Text = "";
                padrino.Enabled = false;
                madrina.Text = "";
                madrina.Enabled = false;
                ministro.Text = "";
                ministro.Enabled = false;
               
                guardaImprimeBtn.Enabled = false;
            }
            else
            {
                nombre.Enabled = true;
                padre.Enabled = true;
                madre.Enabled = true;
                fecconf.Enabled = true;
                fecbau.Enabled = true;
                lugarbau.Enabled = true;
                padrino.Enabled = true;
                madrina.Enabled = true;
                ministro.Enabled = true;
                if (!edicion)
                    guardaImprimeBtn.Enabled = true;
                else guardaImprimeBtn.Enabled = false;
            }
        }

    }
}
