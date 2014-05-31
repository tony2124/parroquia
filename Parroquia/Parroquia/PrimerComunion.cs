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
    public partial class PrimerComunion : Form
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

        /********** CONSTRUCTOR INSERTAR **********/
        public PrimerComunion(String ID_libro)
        {
            edicion = false;
            ID_LIBRO = ID_libro;
            calculoAnios();

            InitializeComponent();

            /* MODIFICACION DEL FORMULARIO EN CASO DE INSERCION DE REGISTRO */
            Text = "::INSERTAR REGISTRO DE PRIMERA COMUNIÓN ::";
            toolTip1.SetToolTip(guardar, ":: GUARDAR REGISTRO ::");
            toolTip1.SetToolTip(guardareimp, ":: GUARDAR E IMPRIMIR::");
            anio.Items.AddRange(anios);
            anio.Text = DateTime.Now.Year + "";
            try
            {
                Bdatos.conexion();

                Datos = Bdatos.obtenerBasesDatosMySQL("select nombre_libro from libros where id_libro="+ID_LIBRO+";");

                if (Datos.HasRows)
                {
                    while (Datos.Read()) {
                        libro.Text = Datos.GetString(0).ToString();
                        
                    }
                }
                Datos.Close();

                /*Estableciendo la partida*/
                Partida = 0;
                Datos = Bdatos.obtenerBasesDatosMySQL("select id_comunion from comuniones where id_libro =" + ID_LIBRO + "  AND bis=0;");

                if (Datos.HasRows)
                    while (Datos.Read())
                        Partida++;

                num_partida.Text = "" + (Partida+1);
         
                /*CALCULANDO LA HOJA*/
                Hoja = Math.Ceiling((Partida + 1) / 10.0);

                num_hoja.Text = "" + Hoja;
              
                Bdatos.Desconectar();
            }
            catch (Exception r) { MessageBox.Show("Error: " + r.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        //CONSTRUCTOR PARA EDICIONES
        public PrimerComunion(int id_registro, String NOMMBRE_LIBRO)
        {
            edicion = true;
            ID_REGISTRO = id_registro;
            InitializeComponent();
            habilitarCampos(false);

            /* MODIFICACION DEL FORMULARIO EN CASO DE EDICION DE BAUTISMO */
            registrobis.Visible = false;
            Text = "::MODIFICAR REGISTRO DE PRIMERA COMUNIÓN ::";
            toolTip1.SetToolTip(guardar, ":: MODIFICAR REGISTRO ::");
            toolTip1.SetToolTip(guardareimp, ":: IMPRIMIR::");
            anio.Items.AddRange(anios);
            anio.Text = DateTime.Now.Year + "";
            guardar.Image = global::Parroquia.Properties.Resources.actualizar;
            try
            {  
                libro.Text = NOMMBRE_LIBRO;
                Bdatos.conexion();

                Datos = Bdatos.obtenerBasesDatosMySQL("SELECT * FROM comuniones where id_comunion = " + ID_REGISTRO);

                if (Datos.HasRows)
                {
                    while (Datos.Read())
                    {
                        num_hoja.Text = Datos.GetString(2);
                        num_partida.Text = Datos.GetString(3);
                        nombre.Text = Datos.GetString(4);
                        padre.Text = Datos.GetString(5);
                        madre.Text = Datos.GetString(6);
                        fechaPrimerCom.Text = Datos.GetString(7);
                        fecha_bautism.Text = Datos.GetString(8);
                        lugar_bautismo.Text = Datos.GetString(9);
                        padrino.Text = Datos.GetString(10);
                        madrina.Text = Datos.GetString(11); 
                        anio.Text = Datos.GetString(12);
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
            fechaPrimerCom.Enabled = enabled;
            fecha_bautism.Enabled = enabled;
            lugar_bautismo.Enabled = enabled;
            padrino.Enabled = enabled;
            madrina.Enabled = enabled;
            anio.Enabled = enabled;
            registronull.Enabled = enabled;
            registrobis.Enabled = enabled;

        }

        /*Se establecen en blanco todos los campos*/
        public void limpiarCampos()
        {
            nombre.Text = "";
            nombre.Focus();
            padre.Text = "";
            madre.Text = "";
            lugar_bautismo.Text = "";
            padrino.Text = "";
            madrina.Text = "";
        }

        /***** CALCULAR HOJA ******/
        private void calculaPartida()
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

        /* VERIFICA SI HAY CAMPOS OBLIGATORIOS VACIOS */
        public Boolean camposVacios()
        {
            if ((nombre.Text.CompareTo("") == 0)    ||
                (padre.Text.CompareTo("") == 0)     ||
                (madre.Text.CompareTo("") == 0)     ||
                (padrino.Text.CompareTo("") == 0)   ||
                (madrina.Text.CompareTo("") == 0)   ||
                (lugar_bautismo.Text.CompareTo("") == 0))
            {
                MessageBox.Show("Los campos marcados con el asterisco rojo son obligatorios, por favor llene los campos obligarios para guardar.", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

         /*INSERTAR REGISTRO EN LA BD */
        private Boolean guardarRegistro()
        {
            //Se guardan todos los campos en la base de datos
            String bis = "0", partida = num_partida.Text;
            if (registrobis.Checked)
                bis = "1";
            Bdatos.conexion();
            if (Bdatos.peticion("insert into comuniones(id_libro,num_hoja,num_partida,nombre,padre,madre,fecha_comunion,fecha_bautismo,lugar_bautismo,padrino,madrina,anio, bis)" +
                " values('" + ID_LIBRO +
                "','" + num_hoja.Text +
                "','" + num_partida.Text +
                "','" + nombre.Text +
                "','" + padre.Text +
                "','" + madre.Text +
                "','" + fechaPrimerCom.Value.ToString("yyyy-MM-dd") +
                "','" + fecha_bautism.Value.ToString("yyyy-MM-dd") +
                "','" + lugar_bautismo.Text +
                "','" + padrino.Text +
                "','" + madrina.Text +
                "','" + anio.Text +
                "'," + bis + ");") > 0)
            {
                MessageBox.Show("Datos ingresados correctamente ", " Acción exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Bdatos.Desconectar();
                return true;
            }
            Bdatos.Desconectar();
            return false;
        }

         /*** ACTUALIZAR REGISTRO ***/
        private Boolean actualizarRegistro()
        {
            Bdatos.conexion();
            //Se hace la actualizacion en la base de datos
            if (Bdatos.peticion("UPDATE comuniones SET nombre='" + nombre.Text +
                "',padre='" + padre.Text + "',madre='" + madre.Text +
                "',fecha_comunion='" + fechaPrimerCom.Value.ToString("yyyy-MM-dd") + "',fecha_bautismo='" + fecha_bautism.Value.ToString("yyyy-MM-dd") +
                "',lugar_bautismo='" + lugar_bautismo.Text + "',padrino='" + padrino.Text +
                "',madrina='" + madrina.Text + "',anio='" + anio.Text +
                "' where id_comunion= '" + ID_REGISTRO + "';") > 0)
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
                    if (!registronull.Checked)
                    {
                        if (camposVacios())
                            return;
                    }

                    if (guardarRegistro())
                        calculaPartida();
                }
                catch (Exception y)
                {
                    MessageBox.Show("Error al ingresar datos en MySQL: " + y.Message, " Error al ingresar ", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }
            }
            else //SI LA EDICION ESTA PUESTA
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
                        if (camposVacios())
                            return;

                    if (actualizarRegistro())
                        btn = false;
                }
            }
        }

        private void guardaImprimeBtn_Click(object sender, EventArgs e)
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

                    if (guardarRegistro())
                    {
                        //IMPRIME

                        // Imprimir a = new Imprimir();

                        calculaPartida();
                    }
                    Bdatos.Desconectar();
                }
                catch (Exception y)
                {
                    MessageBox.Show("Error al ingresar datos en MySQL: " + y.Message, " Error al ingresar ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //IMPRIME
            }
        }


        private void nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            botones(e);
        }

        private void botones(KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                guardar.PerformClick();
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

        //METODO QUE MANDA LLAMAR EL REGISTRO BIS
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
                if (!edicion)
                    guardareimp.Enabled = true;
                else guardareimp.Enabled = false;
            }
        }

    }
}
