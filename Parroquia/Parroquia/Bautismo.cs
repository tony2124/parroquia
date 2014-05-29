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
using System.Drawing.Printing;

namespace Parroquia
{
    public partial class Bautismo : Form
    {
        private String ID_LIBRO;
        private int Partida;
        private double Hoja;
        public static Object[] anios;

        //VARIABLES OCUPADAS PARA LA EDICION
        private int ID_REGISTRO;
        private Boolean edicion;
        private Boolean btn = false;
        public  String nLibro;

        MySqlDataReader Datos;
        ConexionBD Bdatos = new ConexionBD();

        /* CONSTRUCTOR PARA LA VENTANA DE INSERCION */
        public Bautismo(String ID_libro)
        {
            edicion = false;
            ID_LIBRO = ID_libro;

            calculoAnios();

            InitializeComponent();

            /* MODIFICACION DEL FORMULARIO EN CASO DE INSERCION DE REGISTRO */
            Text = "::INSERTAR REGISTRO DE BAUTISMO::";
            toolTip1.SetToolTip(guardar, ":: GUARDAR REGISTRO ::");
            toolTip1.SetToolTip(guardareimp, ":: GUARDAR E IMPRIMIR::");
            anio.Items.AddRange(Bautismo.anios);
            anio.Text = DateTime.Now.Year + "";
           

            try
            {
                /* CONSULTA A LA BASE PARA OBTENER INFORMACION DE LIBROS */
                Bdatos.conexion();
                Datos = Bdatos.obtenerBasesDatosMySQL("select nombre_libro from libros where id_libro=" + ID_LIBRO + ";");
                if (Datos.HasRows)
                {
                    while (Datos.Read())
                    {
                        libro.Text = Datos.GetString(0).ToString();
                    }
                }
                Datos.Close();

                /*Estableciendo la partida*/
                Partida = 0;
                Datos = Bdatos.obtenerBasesDatosMySQL("select id_bautismo from bautismos where id_libro ="+ID_LIBRO+" AND bis=0;");
                if (Datos.HasRows)
                {
                    while (Datos.Read())
                    {
                        Partida++;
                    }
                }
                Datos.Close();
                Bdatos.Desconectar();

                num_partida.Text = "" + (Partida + 1);

                /*CALCULANDO LA HOJA*/    
                Hoja = Math.Ceiling((Partida + 1) / 10.0);
                num_hoja.Text = "" + Hoja;
                
            }
            catch (Exception r) { MessageBox.Show("Error: " + r.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }


        /* CONSTRUCTOR PARA LA VENTANA DE EDICION */
        public Bautismo(int id_registro,  String NOMMBRE_LIBRO)
        {
            nLibro = NOMMBRE_LIBRO;
            edicion = true;
            ID_REGISTRO = id_registro;
            calculoAnios();

            InitializeComponent();
            habilitarCampos(false);

            /* MODIFICACION DEL FORMULARIO EN CASO DE EDICION DE BAUTISMO */
            registrobis.Visible = false;
            Text = "::MODIFICAR REGISTRO DE BAUTISMO::";
            toolTip1.SetToolTip(guardar, ":: MODIFICAR REGISTRO ::");
            toolTip1.SetToolTip(guardareimp, ":: IMPRIMIR::");
            anio.Items.AddRange(Bautismo.anios);
            anio.Text = DateTime.Now.Year + "";
            guardar.Image = global::Parroquia.Properties.Resources.actualizar;

            

            try
            {  
                libro.Text = NOMMBRE_LIBRO;

                /* CONSULTA A LA BASE DE DATOS PARA OBTENER INFORMACION DEL LIBRO, HOJA Y PARTIDA */
                Bdatos.conexion();
                Datos = Bdatos.obtenerBasesDatosMySQL("SELECT * FROM bautismos where id_bautismo = " + ID_REGISTRO);

                if (Datos.HasRows)
                {
                    while (Datos.Read())
                    {
                        num_hoja.Text = Datos.GetString(2);
                        num_partida.Text = Datos.GetString(3);
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

        /* CALCULAR LOS AÑOS */
        public void calculoAnios()
        {
            /*Calculo de años para el combobox */
            anios = new Object[(DateTime.Now.Year - 1970) + 1];
            int u = 0;
            for (int i = 1970; i <= DateTime.Now.Year; i++)
            {
                anios[u] = i;
                u++;
            }
        }

        /* HABILITA O DESHABILITA LOS CAMPOS */
        public void habilitarCampos(Boolean enabled)
        {
            nombre.Enabled = enabled;
            padre.Enabled = enabled;
            madre.Enabled = enabled;
            fechanac.Enabled = enabled;
            lugarnac.Enabled = enabled;
            fechabautismo.Enabled = enabled;
            padrino.Enabled = enabled;
            madrina.Enabled = enabled;
            presbitero.Enabled = enabled;
            anotacion.Enabled = enabled;
            anio.Enabled = enabled;
            registronull.Enabled = enabled;
            
        }

        /*Se establecen en blanco todos los campos*/
        public void limpiarCampos()
        {
            nombre.Text = "";
            nombre.Focus();
            padre.Text = "";
            madre.Text = "";
            padrino.Text = "";
            madrina.Text = "";
            //fechanac.Value = DateTime.Now;
            //fechabautismo.Value = DateTime.Now;
            lugarnac.Text = "";
            presbitero.Text = "";
            anotacion.Text = "";
        }

        /* VERIFICA SI HAY CAMPOS OBLIGATORIOS VACIOS */
        public Boolean camposVacios()
        {
            if ((nombre.Text.CompareTo("") == 0)    ||
                (padre.Text.CompareTo("") == 0)     ||
                (madre.Text.CompareTo("") == 0)     ||
                (padrino.Text.CompareTo("") == 0)   ||
                (madrina.Text.CompareTo("") == 0)   ||
                (lugarnac.Text.CompareTo("") == 0)  ||
                (presbitero.Text.CompareTo("") == 0))
            {
                MessageBox.Show("Los campos marcados con el asterisco rojo son obligatorios, por favor llene los campos obligarios para guardar.", " Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        /*INSERTAR REGISTRO EN LA BD */
        private Boolean guardarRegistro()
        {
            //Prepara la partida
            String bis = "0", partida = num_partida.Text;
            if (registrobis.Checked)
                bis = "1";

            //insertar datos
            if (Bdatos.Insertar("insert into bautismos(id_libro,num_hoja,num_partida,nombre,padre,madre,fecha_nac,lugar_nac,fecha_bautismo,padrino,madrina,presbitero,anotacion,anio,bis)" +
                " values('" + int.Parse(ID_LIBRO) +
                "','" + num_hoja.Text +
                "','" + partida +
                "','" + nombre.Text +
                "','" + padre.Text +
                "','" + madre.Text +
                "','" + fechanac.Value.ToString("yyyy-MM-dd") +
                "','" + lugarnac.Text +
                "','" + fechabautismo.Value.ToString("yyyy-MM-dd") +
                "','" + padrino.Text +
                "','" + madrina.Text +
                    "','" + presbitero.Text +
                    "','" + anotacion.Text +
                "','" + anio.Text +
                "'," + bis + ");") > 0)
            {
                MessageBox.Show("Datos ingresados correctamente ", " Acción exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else MessageBox.Show("Error al ingresar datos ", " Error al ingresar ",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            Bdatos.Desconectar();
            return false;
        }

        private Boolean actualizarRegistro()
        {
            Bdatos.conexion();
            if (Bdatos.Actualizar("UPDATE bautismos SET nombre='" + nombre.Text +
                    "',padre='" + padre.Text + "',madre='" + madre.Text +
                    "',fecha_nac='" + fechanac.Value.ToString("yyyy-MM-dd") + "',lugar_nac='" + lugarnac.Text +
                    "',fecha_bautismo='" + fechabautismo.Value.ToString("yyyy-MM-dd") + "',padrino='" + padrino.Text +
                    "',madrina='" + madrina.Text + "',presbitero='" + presbitero.Text +
                    "',anotacion='" + anotacion.Text + "',anio='" + anio.Text + "' where id_bautismo= '" + ID_REGISTRO + "';") > 0)
            {
                
                //Establecemos los componentes sin edicion
                habilitarCampos(false);
                guardareimp.Enabled = true;
                guardar.Image = global::Parroquia.Properties.Resources.actualizar;
                toolTip1.SetToolTip(guardar, ":: EDITAR REGISTRO ::");

                //actualizar tabla de busqueda
                Parroquia.btnbuscar.PerformClick();
                MessageBox.Show("Registro actualizado correctamente ", " Acción exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Bdatos.Desconectar();
                return true;
            }
            else
                MessageBox.Show("Error al actualizar datos en MySQL ", " Error al ingresar ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Bdatos.Desconectar();
            return false;
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (!edicion)//si no esta puesta edicion se guarda normalmente
            {
                try
                {
                    Bdatos.conexion();

                    if (!registronull.Checked)
                    {
                        if (camposVacios())
                            return;
                    }

                    if (guardarRegistro())
                    {
                        if (!registrobis.Checked)
                            Partida++;
                        else
                            registrobis.Checked = false;

                        num_partida.Text = "" + (Partida + 1);

                        Hoja = Math.Ceiling((Partida + 1) / 10.0);
                        num_hoja.Text = "" + Hoja;

                        limpiarCampos();
                    }
                }
                catch (Exception y)
                {
                    MessageBox.Show("Error al ingresar datos en MySQL: " + y.Message, " Error al ingresar ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else //Si edicion esta puesta
            {
                if (btn == false)
                {
                    btn = true;
                    guardar.Image = global::Parroquia.Properties.Resources.guardar1;
                    guardareimp.Enabled = false;
                    toolTip1.SetToolTip(guardar, ":: GUARDAR REGISTRO ::");
                    habilitarCampos(true);
                    return;
                }
                else
                {
                    if (!registronull.Checked)
                    {
                        if (camposVacios())
                            return;
                    }

                    if(actualizarRegistro())
                    {
                        btn = false;
                    }
                }

            }
        }

        //IMPRIMIR
        public void guardar_imprimir_Click(object sender, EventArgs e)
        {
            if (!edicion)
            {

                try
                {
                    Bdatos.conexion();

                    if (!registronull.Checked)
                    {
                        if (camposVacios())
                            return;
                    }

                    if(guardarRegistro()){
                        
                        //IMPRIMIR 

                        if (!registrobis.Checked)
                            Partida++;
                        else
                            registrobis.Checked = false;

                        num_partida.Text = "" + (Partida + 1);

                        Hoja = Math.Ceiling((Partida + 1) / 10.0);
                        num_hoja.Text = "" + Hoja;

                        limpiarCampos();

                    }
                   
                    Bdatos.Desconectar();

                }
                catch (Exception y)
                {
                    MessageBox.Show("Error al ingresar datos en MySQL: " + y.Message, " Error al ingresar ",   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                //IMPRIMIR
            }
            
        }

            
        private void cancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        public void registrobis_CheckedChanged(object sender, EventArgs e)
        {
            if (registrobis.Checked)
            {
                num_partida.Text = (int.Parse(num_partida.Text) - 1) + "BIS";
            }
            else
            {
                num_partida.Text = (Partida + 1) + "";
            }
        }

        private void registronull_CheckedChanged(object sender, EventArgs e)
        {
            if (registronull.Checked)
            {
                habilitarCampos(false);
                limpiarCampos();
                guardareimp.Enabled = false;
            }
            else
            {
                habilitarCampos(true);
                if(!edicion)
                    guardareimp.Enabled = true;
                else guardareimp.Enabled = false;
            }
        }

        private void botones(KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                guardar.PerformClick();
        }

        private void nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
        }

        private void padre_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
        }

        private void madre_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
        }

        private void lugarnac_KeyPress(object sender, KeyPressEventArgs e)
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

        private void presbitero_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
        }

        private void anotacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
        }

    }
}
