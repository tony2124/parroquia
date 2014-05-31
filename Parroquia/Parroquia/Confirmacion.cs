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
    public partial class Confirmacion : Form
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

        /*CONSTRUCTOR PARA INSERTAR REGISTRO */
        public Confirmacion(String ID_libro)
        {
            edicion = false;
            ID_LIBRO = ID_libro;
            calculoAnios();
            InitializeComponent();
            
            try
            {
                Bdatos.conexion();
                Datos = Bdatos.obtenerBasesDatosMySQL("select nombre_libro from libros where id_libro="+ID_LIBRO+";");
                if (Datos.HasRows)
                {
                    while (Datos.Read()) {
                        libro.Text = Datos.GetString(0);                        
                    }
                }
                Datos.Close();

                /**** MODIFICANDO EL FORMULARIO *****/
                toolTip1.SetToolTip(this.guardarConfirBtn, ":: GUARDAR REGISTRO ::");
                toolTip1.SetToolTip(this.guardaImprimeBtn, ":: GUARDAR E IMPRIMIR ::");
                Text = ":: INSERTAR REGISTRO DE CONFIRMACIÓN ::";
                anioCombo.Items.AddRange(Confirmacion.anios);
                anioCombo.Text = DateTime.Now.Year + "";


                /*Estableciendo la partida*/
                Partida = 0;
                Datos = Bdatos.obtenerBasesDatosMySQL("select id_confirmacion from confirmaciones where id_libro =" + ID_LIBRO + " AND bis=0 ;");

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
        public Confirmacion(int id_registro,  String NOMMBRE_LIBRO)
        {  
            edicion = true;
            ID_REGISTRO = id_registro;
            calculoAnios();

            InitializeComponent();
            //Establecemos los componentes sin edicion

            habilitarCampos(false);

            /******* MODIFICACION DEL FORMULARIO *******/
            guardarConfirBtn.Image = global::Parroquia.Properties.Resources.actualizar;
            toolTip1.SetToolTip(this.guardarConfirBtn, ":: MODIFICAR REGISTRO ::");
            toolTip1.SetToolTip(this.guardaImprimeBtn, ":: IMPRIMIR ::");
            Text = ":: MODIFICAR REGISTRO DE CONFIRMACIÓN ::";
            anioCombo.Items.AddRange(Confirmacion.anios);
            anioCombo.Text = DateTime.Now.Year + "";

            try
            {  
                libro.Text = NOMMBRE_LIBRO;
                Bdatos.conexion();

                Datos = Bdatos.obtenerBasesDatosMySQL("SELECT * FROM confirmaciones where id_confirmacion = " + ID_REGISTRO);

                if (Datos.HasRows)
                {
                    while (Datos.Read())
                    {
                        num_hoja.Text = Datos.GetString(2);
                        num_partida.Text = Datos.GetString(3);
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

        /* CALCULAR LOS AÑOS */
        public void calculoAnios()
        {
            /*Calculo de años para el combobox */
            anios = new Object[(DateTime.Now.Year - 1970) + 1];
            int u = 0;
            for (int i = 1970; i <= DateTime.Now.Year; i++)
            {
                anios[u] = i+"";
                u++;
            }
        }

        /* HABILITA O DESHABILITA LOS CAMPOS */
        public void habilitarCampos(Boolean enabled)
        {
            nombre.Enabled = enabled;
            padre.Enabled = enabled;
            madre.Enabled = enabled;
            fecconf.Enabled = enabled;
            lugarbau.Enabled = enabled;
            fecbau.Enabled = enabled;
            padrino.Enabled = enabled;
            madrina.Enabled = enabled;
            ministro.Enabled = enabled;
            anioCombo.Enabled = enabled;
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
            padrino.Text = "";
            madrina.Text = "";
            //fecbau.Value = DateTime.Now;
            //fecconf.Value = DateTime.Now;
            lugarbau.Text = "";
            ministro.Text = "";
        }

        /* VERIFICA SI HAY CAMPOS OBLIGATORIOS VACIOS */
        public Boolean camposVacios()
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
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        /** GUARDAR EL REGISTRO A LA BD */
        public bool guardarRegistro()
        {
            //Se prepara para verificar si es BIS
            String bis = "0", partida = num_partida.Text;
            if (registrobis.Checked)
                bis = "1";
            
            if (Bdatos.peticion("insert into confirmaciones(id_libro,num_hoja,num_partida,nombre,padre,madre,fecha_confirmacion,fecha_bautismo,lugar_bautismo,padrino,madrina,presbitero,anio,bis)" +
                    " values('" + int.Parse(ID_LIBRO) +
                    "','" + int.Parse(num_hoja.Text) +
                    "','" + num_partida.Text +
                    "','" + nombre.Text +
                    "','" + padre.Text +
                    "','" + madre.Text +
                    "','" + fecconf.Value.ToString("yyyy-MM-dd") +
                    "','" + fecbau.Value.ToString("yyyy-MM-dd") +
                    "','" + lugarbau.Text +
                    "','" + padrino.Text +
                    "','" + madrina.Text +
                    "','" + ministro.Text +
                    "','" + anioCombo.Text +
                    "'," + bis + ");") > 0)
            {
                MessageBox.Show("Datos ingresados correctamente ", " Acción exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Bdatos.Desconectar();
                return true;
            }
            else MessageBox.Show("Error al ingresar datos en MySQL ", " Error al ingresar ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Bdatos.Desconectar();
            return false;
        }

        private void guardarConfirBtn_Click(object sender, EventArgs e)
        {

            if (!edicion)//si no esta puesta edicion se guarda normalmente
            {
                try
                {
                    Bdatos.conexion();
                    if (!registronull.Checked)
                        if(camposVacios())
                            return;
                    
                    if (guardarRegistro())
                        calculaPartida();
                }
                catch (Exception y)
                {
                    MessageBox.Show("Error al ingresar datos en MySQL: " + y.Message, " Error al ingresar ", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }
            }
            else //Si edicion esta puesta
            {
                if (btn == false)
                {
                    btn = true;
                    guardarConfirBtn.Image = global::Parroquia.Properties.Resources.guardar1;
                    guardaImprimeBtn.Enabled = false;
                    toolTip1.SetToolTip(guardarConfirBtn, ":: GUARDAR REGISTRO ::");
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

                    if (actualizarRegistro())
                    {
                        btn = false;
                    }
                }
            }
        }

        private bool actualizarRegistro()
        {
            Bdatos.conexion();

            if (Bdatos.peticion("UPDATE confirmaciones SET nombre='" + nombre.Text +
                     "',padre='" + padre.Text + "',madre='" + madre.Text +
                     "',fecha_confirmacion='" + fecconf.Value.ToString("yyyy-MM-dd") + "',fecha_bautismo='" + fecbau.Value.ToString("yyyy-MM-dd") +
                     "',lugar_bautismo='" + lugarbau.Text + "',padrino='" + padrino.Text +
                     "',madrina='" + madrina.Text + "',presbitero='" + ministro.Text +
                     "',anio='" + anioCombo.Text + "' where id_confirmacion= '" + ID_REGISTRO + "';") > 0)
            {
                btn = false;
                this.guardaImprimeBtn.Enabled = true;
                guardarConfirBtn.Image = global::Parroquia.Properties.Resources.actualizar;
                toolTip1.SetToolTip(guardarConfirBtn, ":: MODIFICAR REGISTRO ::");

                habilitarCampos(false);

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
                formatosImpresion fi = new formatosImpresion(libro.Text, num_hoja.Text,
                             num_partida.Text, nombre.Text, padre.Text, madre.Text, lugarbau.Text,
                             fecbau.Value.ToString("yyyy-MMMM-dd"), fecconf.Value.ToString("yyyy-MMMM-dd"),
                             ministro.Text, madrina.Text, padrino.Text,"",2);
                fi.ShowDialog();

            }
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

        private void registrobis_CheckedChanged(object sender, EventArgs e)
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
                guardaImprimeBtn.Enabled = false;
            }
            else
            {
                habilitarCampos(true);
                if (!edicion)
                    guardaImprimeBtn.Enabled = true;
                else guardaImprimeBtn.Enabled = false;
            }
        }

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
    }
}
