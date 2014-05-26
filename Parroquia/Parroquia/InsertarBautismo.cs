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
using conexionbd;

namespace Parroquia
{
    public partial class InsertarBautismo : Form
    {
        private String ID_LIBRO;
        private int Partida;
        private double Hoja;
        public static Object[] anios;

        //VARIABLES OCUPADAS PARA LA EDICION
        private int ID_REGISTRO;
        private Boolean edicion;
        private Boolean btn = false;



        MySqlDataReader Datos;
        ConexionBD Bdatos = new ConexionBD();

        public InsertarBautismo(String ID_libro)
        {
            edicion = false;
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
                Datos = Bdatos.obtenerBasesDatosMySQL("select id_bautismo from bautismos;");

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

        public InsertarBautismo(int id_registro,  String NOMMBRE_LIBRO)
        {

            
            edicion = true;
            ID_REGISTRO = id_registro;

            anios = new Object[(DateTime.Now.Year - 1970) + 1];
            int u = 0;
            for (int i = 1970; i <= DateTime.Now.Year; i++)
            {
                anios[u] = i;
                u++;
            }

            InitializeComponent();
            //Establecemos los componentes sin edicion
            nombre.Enabled = false;
            padre.Enabled = false;
            madre.Enabled = false;
            fechanac.Enabled = false;
            lugarnac.Enabled = false;
            fechabautismo.Enabled = false;
            padrino.Enabled = false;
            madrina.Enabled = false;
            presbitero.Enabled = false;
            anotacion.Enabled = false;
            anio.Enabled = false;

            try
            {  
                textBox1.Text = NOMMBRE_LIBRO;
                Bdatos.conexion();

                Datos = Bdatos.obtenerBasesDatosMySQL("SELECT * FROM bautismos where id_bautismo = " + ID_REGISTRO);

                if (Datos.HasRows)
                {
                    while (Datos.Read())
                    {
                        textBox2.Text = Datos.GetString(2);
                        textBox3.Text = Datos.GetString(3);
                        nombre.Text = Datos.GetString(4);
                        padre.Text = Datos.GetString(5);
                        madre.Text = Datos.GetString(6);
                        fechanac.Text = Datos.GetString(7);
                        lugarnac.Text = Datos.GetString(8);
                        fechabautismo.Text = Datos.GetString(9);
                        padrino.Text = Datos.GetString(10);
                        madrina.Text = Datos.GetString(11);
                        presbitero.Text = Datos.GetString(12);
                        anotacion.Text = Datos.GetString(13);
                        anio.Text = Datos.GetString(14);
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

        private void guardar_Click(object sender, EventArgs e)
        {
            if (!edicion)//si no esta puesta edicion se guarda normalmente
            {
                try
                {
                    Bdatos.conexion();

                    if ((nombre.Text.ToString().CompareTo("") == 0) ||
                        (padre.Text.ToString().CompareTo("") == 0) ||
                        (madre.Text.ToString().CompareTo("") == 0) ||
                        (padrino.Text.ToString().CompareTo("") == 0) ||
                        (madrina.Text.ToString().CompareTo("") == 0) ||
                        (lugarnac.Text.ToString().CompareTo("") == 0) ||
                        (presbitero.Text.ToString().CompareTo("") == 0))
                        MessageBox.Show("Los campos marcados con el asterisco rojo son obligatorios, por favor llene los campos obligarios para guardar.", " Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {//Se guardan todos los campos en la base de datos
                        if (Bdatos.Insertar("insert into bautismos(id_libro,num_hoja,num_partida,nombre,padre,madre,fecha_nac,lugar_nac,fecha_bautismo,padrino,madrina,presbitero,anotacion,anio)" +
                            " values('" + int.Parse(ID_LIBRO) +
                            "','" + int.Parse(textBox2.Text.ToString()) +
                            "','" + int.Parse(textBox3.Text.ToString()) +
                            "','" + nombre.Text.ToString() +
                            "','" + padre.Text.ToString() +
                            "','" + madre.Text.ToString() +
                            "','" + fechanac.Value.ToString("yyyy-MM-dd") +
                            "','" + lugarnac.Text.ToString() +
                            "','" + fechabautismo.Value.ToString("yyyy-MM-dd") +
                            "','" + padrino.Text.ToString() +
                            "','" + madrina.Text.ToString() +
                             "','" + presbitero.Text.ToString() +
                             "','" + anotacion.Text.ToString() +
                            "','" + anio.Text.ToString() +
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
                            fechanac.Value = DateTime.Now;
                            fechabautismo.Value = DateTime.Now;
                            lugarnac.Text = "";
                            presbitero.Text = "";
                            anotacion.Text = "";
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
            else//Si edicion esta puesta
            {
                if (btn == false)
                {
                    btn = true;
                    this.guardar.Text = "Guardar registro";
                    this.cancelar.Enabled = false;
                    this.guardareimp.Enabled = false;

                    //Permitimes edicion a los componentes
                    nombre.Enabled = true;
                    padre.Enabled = true;
                    madre.Enabled = true;
                    fechanac.Enabled = true;
                    lugarnac.Enabled = true;
                    fechabautismo.Enabled = true;
                    padrino.Enabled = true;
                    madrina.Enabled = true;
                    presbitero.Enabled = true;
                    anotacion.Enabled = true;
                    anio.Enabled = true;
                }
                else {
                    //Actualizamos datos en la base de datos
                    if ((nombre.Text.ToString().CompareTo("") == 0) ||
                       (padre.Text.ToString().CompareTo("") == 0) ||
                       (madre.Text.ToString().CompareTo("") == 0) ||
                       (padrino.Text.ToString().CompareTo("") == 0) ||
                       (madrina.Text.ToString().CompareTo("") == 0) ||
                       (lugarnac.Text.ToString().CompareTo("") == 0) ||
                       (presbitero.Text.ToString().CompareTo("") == 0))
                        MessageBox.Show("Los campos marcados con el asterisco rojo son obligatorios, por favor llene los campos obligarios para guardar.", " Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        Bdatos.conexion();
                        if (Bdatos.Actualizar("UPDATE bautismos SET nombre='" + nombre.Text.ToString() +
                             "',padre='" + padre.Text.ToString() + "',madre='" + madre.Text.ToString() +
                             "',fecha_nac='" + fechanac.Value.ToString("yyyy-MM-dd") + "',lugar_nac='" + lugarnac.Text.ToString() +
                             "',fecha_bautismo='" + fechabautismo.Value.ToString("yyyy-MM-dd") + "',padrino='" + padrino.Text.ToString() +
                             "',madrina='" + madrina.Text.ToString() + "',presbitero='" + presbitero.Text.ToString() +
                             "',anotacion='" + anotacion.Text.ToString() + "',anio='" + anio.Text.ToString() + "' where id_bautismo= '" + ID_REGISTRO + "';") > 0)
                        {
                            MessageBox.Show("Registro actualizado correctamente ", " Acción exitosa",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btn = false;
                            this.guardar.Text = "Editar registro";
                            this.cancelar.Enabled = true;
                            this.guardareimp.Enabled = true;


                             //actualizamos la tabla
                            Parroquia.tablaBusqueda.Columns.Clear();
                            Parroquia.Pintar_tabla();
                            

                            //Establecemos los componentes sin edicion
                            nombre.Enabled = false;
                            padre.Enabled = false;
                            madre.Enabled = false;
                            fechanac.Enabled = false;
                            lugarnac.Enabled = false;
                            fechabautismo.Enabled = false;
                            padrino.Enabled = false;
                            madrina.Enabled = false;
                            presbitero.Enabled = false;
                            anotacion.Enabled = false;
                            anio.Enabled = false;
                        }
                        else
                            MessageBox.Show("Error al actualizar datos en MySQL ", " Error al ingresar ",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Bdatos.Desconectar();

                    }
                   
                    
                }
                   
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
