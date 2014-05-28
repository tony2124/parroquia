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

            try
            {
                /* CONSULTA A LA BASE PARA OBTENER INFORMACION DE LIBROS */
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

                textBox3.Text = "" + (Partida + 1);

                /*CALCULANDO LA HOJA*/    
                Hoja = Math.Ceiling((Partida + 1) / 10.0);
                textBox2.Text = "" + Hoja;
                
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
            try
            {  
                textBox1.Text = NOMMBRE_LIBRO;

                /* CONSULTA A LA BASE DE DATOS PARA OBTENER INFORMACION DEL LIBRO, HOJA Y PARTIDA */
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
            registrobis.Enabled = enabled;
        }

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
        private void guardarRegistro()
        {
            String bis = "0", partida = textBox3.Text;
            if (registrobis.Checked)
                bis = "1";

            //insertar datos
            if (Bdatos.Insertar("insert into bautismos(id_libro,num_hoja,num_partida,nombre,padre,madre,fecha_nac,lugar_nac,fecha_bautismo,padrino,madrina,presbitero,anotacion,anio,bis)" +
                " values('" + int.Parse(ID_LIBRO) +
                "','" + textBox2.Text +
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

                if (!registrobis.Checked)
                    Partida++;
                else
                    registrobis.Checked = false;

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
                //fechanac.Value = DateTime.Now;
                //fechabautismo.Value = DateTime.Now;
                lugarnac.Text = "";
                presbitero.Text = "";
                anotacion.Text = "";
            }
            else MessageBox.Show("Error al ingresar datos ", " Error al ingresar ",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            Bdatos.Desconectar();
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
                    guardarRegistro();
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
                    guardar.Text = "Guardar registro";
                    guardareimp.Enabled = false;
                    habilitarCampos(true);
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
                           (lugarnac.Text.ToString().CompareTo("") == 0) ||
                           (presbitero.Text.ToString().CompareTo("") == 0))
                        {
                            MessageBox.Show("Los campos marcados con el asterisco rojo son obligatorios, por favor llene los campos obligarios para guardar.", " Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

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
                        
                        //Establecemos los componentes sin edicion
                        registronull.Checked = false;
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
                        registronull.Enabled = false;
                        registrobis.Enabled = false;
                        
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
                        if ((nombre.Text.ToString().CompareTo("") == 0) ||
                        (padre.Text.ToString().CompareTo("") == 0) ||
                        (madre.Text.ToString().CompareTo("") == 0) ||
                        (padrino.Text.ToString().CompareTo("") == 0) ||
                        (madrina.Text.ToString().CompareTo("") == 0) ||
                        (lugarnac.Text.ToString().CompareTo("") == 0) ||
                        (presbitero.Text.ToString().CompareTo("") == 0))
                        {
                            MessageBox.Show("Los campos marcados con el asterisco rojo son obligatorios, por favor llene los campos obligarios para guardar.", " Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    //Se guardan todos los campos en la base de datos
                    String bis = "0", partida = textBox3.Text;
                    if (registrobis.Checked)
                    {
                        bis = "1";
                    }


                    if (Bdatos.Insertar("insert into bautismos(id_libro,num_hoja,num_partida,nombre,padre,madre,fecha_nac,lugar_nac,fecha_bautismo,padrino,madrina,presbitero,anotacion,anio,bis)" +
                        " values('" + int.Parse(ID_LIBRO) +
                        "','" + textBox2.Text +
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
                        MessageBox.Show("Datos ingresados correctamente ", " Acción exitosa",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                       

                        //DESPUES DE GUARDAR IMPRIMO

                        Cursor.Current = Cursors.WaitCursor;
                        //SE ESTABLECEN LAS PROPIEDADES DE IMPRESORA

                        PrintDialog pDialog = new PrintDialog();
                        PrintPreviewDialog ppD = new PrintPreviewDialog();
                        PrintDocument pd = new PrintDocument();

                        ppD.PrintPreviewControl.Zoom = 1;
                        ppD.WindowState = FormWindowState.Maximized;
                        ppD.MinimizeBox = true;

                        pDialog.AllowSomePages = false;
                        pDialog.AllowPrintToFile = false;


                        DialogResult = pDialog.ShowDialog();

                        if (DialogResult == DialogResult.OK)
                        {
                            pd.PrinterSettings = pDialog.PrinterSettings;
                            pd.PrinterSettings.Copies = pDialog.PrinterSettings.Copies;

                            pd.PrintPage += new PrintPageEventHandler
                                (this.pd_PrintPage_edicion);

                            ppD.Document = pd;
                            ppD.ShowDialog();
                            //pd.Print();
                        }

                        if (!registrobis.Checked)
                            Partida++;
                        else
                            registrobis.Checked = false;


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
                    else MessageBox.Show("Error al ingresar datos ", " Error al ingresar ",
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
            else
            {

                Cursor.Current = Cursors.WaitCursor;
                //SE ESTABLECEN LAS PROPIEDADES DE IMPRESORA

                PrintDialog pDialog = new PrintDialog();
                PrintPreviewDialog ppD = new PrintPreviewDialog();
                PrintDocument pd = new PrintDocument();

                ppD.PrintPreviewControl.Zoom = 1;
                ppD.MinimizeBox = true;
                ppD.WindowState = FormWindowState.Maximized;

                pDialog.AllowSomePages = false;
                pDialog.AllowPrintToFile = false;


                DialogResult = pDialog.ShowDialog();
                if (DialogResult == DialogResult.OK)
                {
                    pd.PrinterSettings = pDialog.PrinterSettings;
                    pd.PrintPage += new PrintPageEventHandler
                        (this.pd_PrintPage_edicion);
                    ppD.Document = pd;
                    ppD.ShowDialog();
                     //pd.Print();
                }
            }
            
            
        }

        public void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            //IMPRIME TITULO
            ev.Graphics.DrawString("ANTUNEZ MICHOACAN",
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 350, 50);
            ev.Graphics.DrawString("PARROQUIA DE NUESTRA SEÑORA DE GUADALUPE",
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 250, 80);
        }

        public void pd_PrintPage_edicion(object sender, PrintPageEventArgs ev)
        {
            //IMPRIME TITULO
            ev.Graphics.DrawString("ANTUNEZ MICHOACAN",
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 350, 50);
            ev.Graphics.DrawString("PARROQUIA DE NUESTRA SEÑORA DE GUADALUPE",
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 250, 80);

            //IMPRIME CATEGORIA
            ev.Graphics.DrawString("CATEGORIA: ",
                new Font("Times New Roman", 10, FontStyle.Regular),
                        Brushes.Black, 20, 120);
            ev.Graphics.DrawString("BAUTISMOS ",
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 200, 120);

            //IMPRIME LIBRO
            ev.Graphics.DrawString("LIBRO: ",
                new Font("Times New Roman", 10, FontStyle.Regular),
                        Brushes.Black, 20, 140);
            ev.Graphics.DrawString(textBox1.Text,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 200, 140);

            //IMPRIME FOJA
            ev.Graphics.DrawString("FOJA: ",
               new Font("Times New Roman", 10, FontStyle.Regular),
                       Brushes.Black, 20, 160);
            ev.Graphics.DrawString(textBox2.Text,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 200, 160);

            //IMPRIME PARTIDA
            ev.Graphics.DrawString("PARTIDA: ",
               new Font("Times New Roman", 10, FontStyle.Regular),
                       Brushes.Black, 20, 180);
            ev.Graphics.DrawString(textBox3.Text,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 200, 180);

            //IMPRIME Nombre
            ev.Graphics.DrawString("NOMBRE: ",
               new Font("Times New Roman", 10, FontStyle.Regular),
                       Brushes.Black, 20, 200);
            ev.Graphics.DrawString(nombre.Text,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 200, 200);

            //IMPRIME PAPA
            ev.Graphics.DrawString("PADRE: ",
               new Font("Times New Roman", 10, FontStyle.Regular),
                       Brushes.Black, 20, 220);
            ev.Graphics.DrawString(padre.Text,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 200, 220);

            //IMPRIME MADRE
            ev.Graphics.DrawString("MADRE: ",
               new Font("Times New Roman", 10, FontStyle.Regular),
                       Brushes.Black, 20, 240);
            ev.Graphics.DrawString(madre.Text,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 200, 240);

            //IMPRIME FECHA DE NACIMIENTO
            ev.Graphics.DrawString("FECHA DE NACIMIENTO: ",
               new Font("Times New Roman", 10, FontStyle.Regular),
                       Brushes.Black, 20, 260);
            ev.Graphics.DrawString(fechanac.Text,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 200, 260);

            //IMPRIME LUGAR DE NACIMIENTO
            ev.Graphics.DrawString("LUGAR DE NACIMIENTO: ",
               new Font("Times New Roman", 10, FontStyle.Regular),
                       Brushes.Black, 20, 280);
            ev.Graphics.DrawString(lugarnac.Text,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 200, 280);

            //IMPRIME LUGAR DE NACIMIENTO
            ev.Graphics.DrawString("FECHA DE BAUTISMO: ",
               new Font("Times New Roman", 10, FontStyle.Regular),
                       Brushes.Black, 20, 300);
            ev.Graphics.DrawString(fechabautismo.Text,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 200, 300);

            //IMPRIME PADRINOS
            ev.Graphics.DrawString("PADRINO (S): ",
               new Font("Times New Roman", 10, FontStyle.Regular),
                       Brushes.Black, 20, 320);
            ev.Graphics.DrawString(padrino.Text,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 200, 320);

            //IMPRIME MADRINA
            ev.Graphics.DrawString("MADRINA: ",
               new Font("Times New Roman", 10, FontStyle.Regular),
                       Brushes.Black, 20, 340);
            ev.Graphics.DrawString(madrina.Text,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 200, 340);

            //IMPRIME PRESBITERO
            ev.Graphics.DrawString("PRESBITERO: ",
               new Font("Times New Roman", 10, FontStyle.Regular),
                       Brushes.Black, 20, 360);
            ev.Graphics.DrawString(presbitero.Text,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 200, 360);

            //IMPRIME AÑO
            ev.Graphics.DrawString("AÑO: ",
               new Font("Times New Roman", 10, FontStyle.Regular),
                       Brushes.Black, 20, 380);
            ev.Graphics.DrawString(anio.Text,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 200, 380);

            //IMPRIME ANOTACIONES
            ev.Graphics.DrawString("ANOTACIONES: ",
               new Font("Times New Roman", 10, FontStyle.Regular),
                       Brushes.Black, 20, 400);
            ev.Graphics.DrawString(anotacion.Text,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 200, 400);
        }
            
        private void cancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        public void registrobis_CheckedChanged(object sender, EventArgs e)
        {
            if (registrobis.Checked)
            {
                textBox3.Text = (int.Parse(textBox3.Text) - 1) + "BIS";
            }
            else
            {
                textBox3.Text = (Partida + 1) + "";
            }
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
                fechanac.Text = "";
                fechanac.Enabled = false;
                fechabautismo.Text = "";
                fechabautismo.Enabled = false;
                lugarnac.Text = "";
                lugarnac.Enabled = false;
                padrino.Text = "";
                padrino.Enabled = false;
                madrina.Text = "";
                madrina.Enabled = false;
                presbitero.Text = "";
                presbitero.Enabled = false;
                anotacion.Text = "";
                anotacion.Enabled = false;
                guardareimp.Enabled = false;
            }
            else
            {
                nombre.Enabled = true;
                padre.Enabled = true;
                madre.Enabled = true;
                fechanac.Enabled = true;
                fechabautismo.Enabled = true;
                lugarnac.Enabled = true;
                padrino.Enabled = true;
                madrina.Enabled = true;
                presbitero.Enabled = true;
                anotacion.Enabled = true;
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

        private void label17_Click(object sender, EventArgs e)
        {

        }

    }
}
