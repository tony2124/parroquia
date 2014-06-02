using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using conexionbd;
using MySql.Data.MySqlClient;

namespace Parroquia
{
    class Imprimir
    {
        PrintDialog pDialog;
        PrintPreviewDialog ppD ;
        PrintDocument pd;
        Image newImage;

        //Controladores para imprimir las anotaciones en diferentes renglones*/
        /**/ public int cont = 0;
        /***********************************************************************/

        public static String libro, foja, partida, nombre, padre, madre, 
            lugarNacimiento, fechaNacimiento, fechaBautismo, presbitero, 
            madrina, padrino, anotacion, lugarBautismo, fechaConfirmacion,
            fechaComunion, parroquiaBautismo, diocesisBautismo,
            nombre_parroquia, nombre_parroco, ubicacion_parroquia;

        public static bool impresion = true;

        public int CATEGORIA, FORMATO;
        public ConexionBD DbDatos;
        public MySqlDataReader datos;

        public void leerArchivoBautismo()
        {
            if(CATEGORIA == 1){
                if (FORMATO == 0)
                    newImage = Image.FromFile("C:\\DOCSParroquia\\Bautismo.jpg");
                else if (FORMATO == 1)
                    newImage = Image.FromFile("C:\\DOCSParroquia\\BautismoFormatoOriginal1.jpg");
                else if(FORMATO == 2)
                    newImage = Image.FromFile("C:\\DOCSParroquia\\BautismoFormatoOriginal2.jpg");
            }
            else if (CATEGORIA == 2)
            {
                if (FORMATO == 0)
                    newImage = Image.FromFile("C:\\DOCSParroquia\\Confirmacion.jpg");
                else if (FORMATO == 1)
                {
                    newImage = Image.FromFile("C:\\DOCSParroquia\\ConfirmacionOriginal.jpg");
                }

            }
            else if (CATEGORIA == 3)
            {
                if (FORMATO == 0)
                    newImage = Image.FromFile("C:\\DOCSParroquia\\PrimeraComunion.jpg");
            }
                



        }

        public Boolean ImpresoraProperties()
        {
            pDialog = new PrintDialog();
            ppD = new PrintPreviewDialog();
            pd = new PrintDocument();


            ppD.PrintPreviewControl.Zoom = 1;
            ppD.WindowState = FormWindowState.Maximized;
            ppD.MinimizeBox = true;
            ppD.ShowInTaskbar = true;

            pDialog.AllowSomePages = false;
            pDialog.AllowPrintToFile = false;
            DialogResult t = pDialog.ShowDialog();
            if (t == DialogResult.OK)
                return true;
            else
                return false;
            
        }

        public Imprimir(String a, String b, String c, String d, 
            String e, String f, String g, String h,
            String i, String j, String k, String l, String m, int categoria,
            int formato)
        {
            //OBTENGO NOMBRE DE LA PARROQUIA, NOMBRE DEL PARROCO Y
            //LA UBICACION DE LA PARROQUIA DE LA BASE DE DATOS
            DbDatos = new ConexionBD();
            DbDatos.conexion();

            datos = DbDatos.obtenerBasesDatosMySQL("select nombre_parroquia, nombre_parroco, ubicacion_parroquia from informacion");

            if (datos.HasRows)
            {
                while (datos.Read())
                {
                    nombre_parroquia = datos.GetString(0).ToUpper();
                    nombre_parroco = datos.GetString(1).ToUpper();
                    ubicacion_parroquia = datos.GetString(2).ToUpper();
                }
            }
            DbDatos.Desconectar();


            //Asignacion de variables
            libro = a;
            foja = b;
            partida = c;
            CATEGORIA = categoria;
            FORMATO = formato;

            if (categoria == 1 || categoria == 2)
            {
                nombre = d;
                padre = e;
                madre = f;

                presbitero = j;
                madrina = k;
                padrino = l;
            }

            if (categoria == 1)
            { 
                lugarNacimiento = g;
                fechaNacimiento = h;
                fechaBautismo = i;
                anotacion = m;
            }
            else if (categoria == 2)
            {
                lugarBautismo = g;
                fechaBautismo = h;
                fechaConfirmacion = i;

            }
            else if (categoria == 3)
            {
                nombre = d;
                padre = e;
                madre = f;
                fechaComunion = g;
                fechaBautismo = h;
                lugarBautismo = i;
                padrino = j;
                madrina = k;

            }



            //DESPUES DE GUARDAR IMPRIMO
            Cursor.Current = Cursors.WaitCursor;
            
            if (CATEGORIA == 2 && FORMATO == 1)
            {
                DialogConfirmacion dc = new DialogConfirmacion();
                dc.ShowDialog();

                impresion = DialogConfirmacion.impresion;
            }

            if (impresion)
            {
                //SE ESTABLECEN LAS PROPIEDADES DE IMPRESORA
                if (ImpresoraProperties())
                {
                    //SE LEE EL ARCHIVO QUE SE IMPRIMIRA
                    leerArchivoBautismo();

                    //SE manda a imprimir el archivo leido y lleno de informacion
                    mandaImpresion();

                }
            }
        }

        public void mandaImpresion(){
            pd.PrinterSettings = pDialog.PrinterSettings;
            pd.PrinterSettings.Copies = pDialog.PrinterSettings.Copies;

            if(CATEGORIA == 1){
               if(FORMATO == 0)
                    pd.PrintPage += new PrintPageEventHandler
                        (this.imprimirBautismoCopia);
               else if (FORMATO == 1)
                   pd.PrintPage += new PrintPageEventHandler
                        (this.imprimirBautismoFormato1);
                else if(FORMATO == 2)
                   pd.PrintPage += new PrintPageEventHandler
                        (this.imprimirBautismoFormato2);
            }
            else if (CATEGORIA == 2)
            {
                if (FORMATO == 0)
                    pd.PrintPage += new PrintPageEventHandler
                       (this.imprimirConfirmacionCopia);
                else if (FORMATO == 1)
                {
                    pd.PrintPage += new PrintPageEventHandler
                       (this.imprimirConfirmacionOriginal);
                }
            }
            else if (CATEGORIA == 3)
            {
                if (FORMATO == 0)
                    pd.PrintPage += new PrintPageEventHandler
                       (this.imprimirComunionCopia);
                else if (FORMATO == 1)
                {

                }
            }
            ppD.Document = pd;
            ppD.ShowDialog();
            ppD.BringToFront();

            //pd.Print();
        }

        private void imprimirConfirmacionOriginal(object sender, PrintPageEventArgs ev)
        {
            String[] fecha;
            imprimeImagen(ev);
            
            /*OBTENCION DE LA MITAD DE LA HOJA***********************/
            float tamaño_total, mitad;
            tamaño_total = 880 - ev.Graphics.MeasureString(nombre, new Font("Times New Roman", 10, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            /********************************************************/

            //IMPRIME NOMBRE
            ev.Graphics.DrawString(nombre,
               new Font("Times New Roman", 10, FontStyle.Bold),
                       Brushes.Black, mitad-100, 241);

            //IMPRIME PADRES
            ev.Graphics.DrawString(padre+" Y \n \n"+madre,
               new Font("Times New Roman", 10, FontStyle.Bold),
               Brushes.Black, 160, 329);


            //IMPRIME PADRINOS
            String padrinos = "";
            if (padrino.Length > 4 && madrina.Length < 4)
                padrinos = padrino;
            else if (padrino.Length < 4 && madrina.Length > 4)
                padrinos = madrina;
            else if (padrino.Length > 4 && madrina.Length > 4)
                padrinos = padrino + " Y " + madrina;
            ev.Graphics.DrawString(padrinos,
                new Font("Times New Roman", 10, FontStyle.Bold),
                Brushes.Black, 165, 392);

            //IMPRIME LUGAR DE BAUTISMO
            ev.Graphics.DrawString(lugarBautismo,
                new Font("Times New Roman", 10, FontStyle.Bold),
                Brushes.Black, 165, 425);

            /*********************************************************/
            /*FALTA PARROQUIA DEL BAUTIZADO***************************/
            /*********************************************************/
            //IMPRIME PARROQUIA DEL BAUTIZADO
            ev.Graphics.DrawString(parroquiaBautismo.ToUpper(),
                new Font("Times New Roman", 10, FontStyle.Bold),
                Brushes.Black, 155, 455);

            //IMPRIME LIBRO
            tamaño_total = 880 - ev.Graphics.MeasureString(libro, 
                new Font("Times New Roman", 6, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(libro,
                new Font("Times New Roman", 6, FontStyle.Bold),
                Brushes.Black, mitad-341, 489);

            //IMPRIME HOJA
            tamaño_total = 880 - ev.Graphics.MeasureString(foja,
                new Font("Times New Roman", 8, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(foja,
                new Font("Times New Roman", 8, FontStyle.Bold),
                Brushes.Black, mitad - 292, 486);

            //IMPRIME PARTIDA
            tamaño_total = 880 - ev.Graphics.MeasureString(partida,
                new Font("Times New Roman", 8, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(partida,
                new Font("Times New Roman", 8, FontStyle.Bold),
                Brushes.Black, mitad - 242, 489);

            //IMPRIME FECHA DE BAUTISMO
            //separo la fecha de bautismo
            fecha = fechaBautismo.Split('-');
            fecha[1] = fecha[1].ToUpper();
            //imprimo el dia
            ev.Graphics.DrawString(fecha[2],
                new Font("Times New Roman", 11, FontStyle.Bold),
                        Brushes.Black, 310, 488);

            //imprimo el mes
            ev.Graphics.DrawString(fecha[1],
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 395, 490);

            //imprimo el año
            ev.Graphics.DrawString(fecha[0],
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 538, 491);

            //IMPRIME DIOCESIS DEL BAUTIZADO
            ev.Graphics.DrawString(diocesisBautismo.ToUpper(),
                new Font("Times New Roman", 10, FontStyle.Bold),
                Brushes.Black, 210, 520);

            //IMPRIME PARROQUIA DE CONFIRMACION
            ev.Graphics.DrawString(nombre_parroquia+" EN "+ubicacion_parroquia,
                new Font("Times New Roman", 10, FontStyle.Bold),
                Brushes.Black, 250, 552);

            //IMPRIME FECHA DE CONFIRMACION
            //separo la fecha de CONFIRMACION
            fecha = fechaConfirmacion.Split('-');
            fecha[1] = fecha[1].ToUpper();
            //imprimo el dia
            ev.Graphics.DrawString(fecha[2],
                new Font("Times New Roman", 11, FontStyle.Bold),
                        Brushes.Black, 285, 640);

            //imprimo el mes
            ev.Graphics.DrawString(fecha[1],
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 350, 643);

            //imprimo el año
            ev.Graphics.DrawString(fecha[0],
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 500, 645);

        }

        //METODO PARA IMPRIMIR FORMATO COPIA EN COMUNIONES
        private void imprimirComunionCopia(object sender, PrintPageEventArgs ev)
        {
            String[] fecha;
            imprimeImagen(ev);
            /*OBTENCION DE LA MITAD DE LA HOJA***********************/
            float tamaño_total, mitad;
            tamaño_total = 880 - ev.Graphics.MeasureString(nombre, new Font("Times New Roman", 18, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            /********************************************************/

            //IMPRIME NOMBRE
            ev.Graphics.DrawString(nombre,
               new Font("Times New Roman", 18, FontStyle.Bold),
                       Brushes.Black, mitad, 385);

            //IMPRIME FECHA DE COMUNION
            fecha = fechaComunion.Split('-');
            ev.Graphics.DrawString(fecha[2] + " DE " + fecha[1].ToUpper() + " DE " + fecha[0] + ".",
                new Font("Times New Roman", 12, FontStyle.Bold),
                        Brushes.Black, 470, 442);

            //IMPRIME PADRES
            ev.Graphics.DrawString(padre + " Y " + madre,
                new Font("Times New Roman", 12, FontStyle.Bold),
                        Brushes.Black, 220, 513);

            //IMPRIME PADRINOS
            String padrinos="";
            if (padrino.Length > 4 && madrina.Length < 4)
                padrinos = padrino;
            else if (padrino.Length < 4 && madrina.Length > 4)
                padrinos = madrina;
            else if (padrino.Length > 4 && madrina.Length > 4)
                padrinos = padrino + " Y " + madrina;
            ev.Graphics.DrawString(padrinos,
                new Font("Times New Roman", 12, FontStyle.Bold),
                        Brushes.Black, 220, 538);

            //IMPRIME LUGAR Y FECHA DE BAUTISMO
            fecha = fechaBautismo.Split('-');
            string luharFechaBautismo = lugarBautismo + " EL DÍA " + fecha[2] + " DE " + fecha[1].ToUpper() + " DE " + fecha[0];
            notasRenglones(luharFechaBautismo, ev, 430, 564, 30,"a");

            //ESTABLECEMOS LA FECHA ACTUAL
            String d = DateTime.Now.Day + "";
            String m = DateTime.Now.ToString("MMMM");
            String a = DateTime.Now.Year + "";

            m = m.ToUpper();
            string fechaActual = d + " DE " + m + " DE " + a;
            ev.Graphics.DrawString(fechaActual,
                new Font("Times New Roman", 12, FontStyle.Bold),
                        Brushes.Black, 315, 700);
           
        }

        //METODO PARA IMPRIMIR FORMATO ORIGINAL HORIZONTAL EN BAUTISMOS
        private void imprimirBautismoFormato2(object sender, PrintPageEventArgs ev)
        {
            float tamaño_total, mitad;

            imprimeImagen(ev);

            //IMPRIME NOMBRE
            tamaño_total = 880 - ev.Graphics.MeasureString(nombre, new Font("Times New Roman", 11, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre,
               new Font("Times New Roman", 11, FontStyle.Bold),
                       Brushes.Black, mitad+15, 140);

            //LUGAR BAUTISMO
            tamaño_total = 880 - ev.Graphics.MeasureString(nombre_parroquia+ " " + ubicacion_parroquia, new Font("Times New Roman", 11, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre_parroquia+" "+ubicacion_parroquia,
               new Font("Times New Roman", 11, FontStyle.Bold),
                       Brushes.Black, mitad+15, 201);

            //IMPRIME FECHA DE BAUTISMO
            //separo la fecha de bautismo
            String []fecha = fechaBautismo.Split('-');
            fecha[1] = fecha[1].ToUpper();
            fecha[0] = fecha[0].Substring(2);
            //imprimo el dia
            ev.Graphics.DrawString(fecha[2],
                new Font("Times New Roman", 11, FontStyle.Bold),
                        Brushes.Black, 310, 260);

            //imprimo el mes
            ev.Graphics.DrawString(fecha[1],
                new Font("Times New Roman", 11, FontStyle.Bold),
                        Brushes.Black, 400, 260);

            //imprimo el año
            ev.Graphics.DrawString(fecha[0],
                new Font("Times New Roman", 11, FontStyle.Bold),
                        Brushes.Black, 610, 260);

            //IMPRIME LUGAR DE NACIMIENTO
            ev.Graphics.DrawString(lugarNacimiento,
                new Font("Times New Roman", 11, FontStyle.Bold),
                        Brushes.Black, 140, 293);

            //IMPRIME FECHA DE NACIMIENTO
            //separo la fecha de nacimiento
            fecha = fechaNacimiento.Split('-');
            fecha[1] = fecha[1].ToUpper();
            fecha[0] = fecha[0].Substring(2);
            //imprimo el dia
            ev.Graphics.DrawString(fecha[2],
                new Font("Times New Roman", 11, FontStyle.Bold),
                        Brushes.Black, 310, 324);

            //imprimo el mes
            ev.Graphics.DrawString(fecha[1],
                new Font("Times New Roman", 11, FontStyle.Bold),
                        Brushes.Black, 400, 324);

            //imprimo el año
            ev.Graphics.DrawString(fecha[0],
                new Font("Times New Roman", 11, FontStyle.Bold),
                        Brushes.Black, 610, 324);

            //IMPRIME PADRES
            ev.Graphics.DrawString(padre + " Y " + madre,
                new Font("Times New Roman", 11, FontStyle.Bold),
                        Brushes.Black, 130, 357);

            //IMPRIME PADRINOS
            ev.Graphics.DrawString(padrino + " Y " + madrina,
                new Font("Times New Roman", 11, FontStyle.Bold),
                        Brushes.Black, 145, 388);

            //IMPRIME LIBRO
            ev.Graphics.DrawString(libro,
                new Font("Times New Roman", 11, FontStyle.Bold),
                        Brushes.Black, 110, 420);

            //IMPRIME FOJA   
            ev.Graphics.DrawString(foja,
                new Font("Times New Roman", 11, FontStyle.Bold),
                        Brushes.Black, 120, 451);

            //IMPRIME PARTIDA
            ev.Graphics.DrawString(partida,
                new Font("Times New Roman", 11, FontStyle.Bold),
                        Brushes.Black, 150, 484);

            //IMPRIME PRESBITERO
            tamaño_total = 880 - ev.Graphics.MeasureString(presbitero, new Font("Times New Roman", 11, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;

            ev.Graphics.DrawString(presbitero,
                new Font("Times New Roman", 11, FontStyle.Bold),
                        Brushes.Black, mitad+130, 463);

        }

        //METODO PARA IMPRIMIR FORMATO ORIGINAL VERTICAL EN BAUTISMOS
        private void imprimirBautismoFormato1(object sender, PrintPageEventArgs ev)
        {
            float tamaño_total, mitad;
            imprimeImagen(ev);

            //IMPRIME NOMBRE
            tamaño_total = 880 - ev.Graphics.MeasureString(nombre, new Font("Times New Roman", 9, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre,
               new Font("Times New Roman", 9, FontStyle.Bold),
                       Brushes.Black, mitad-210, 127);

            //IMPRIME PADRES
            ev.Graphics.DrawString(padre + " Y \n \n" + madre,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 120, 327);

            //IMPRIME PADRINOS
            ev.Graphics.DrawString(padrino + " Y \n\n" + madrina,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 70, 415);

            //IMPRIME LUGAR DE NACIMIENTO
            ev.Graphics.DrawString(lugarNacimiento,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 220, 487);

            //IMPRIME FECHA DE NACIMIENTO

            //separo la fecha de nacimiento
            String[] fecha = fechaNacimiento.Split('-');
            fecha[1] = fecha[1].ToUpper();

            //Imprimo el dia 
            ev.Graphics.DrawString(fecha[2],
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 115, 514);

            //Imprimo el mes
            ev.Graphics.DrawString(fecha[1],
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 205, 514);

            //Imprimo el año
            ev.Graphics.DrawString(fecha[0],
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 505, 514);

            //IMPRIME LUGAR DE BAUTISMO
            tamaño_total = 880 - ev.Graphics.MeasureString(ubicacion_parroquia, new Font("Times New Roman", 9, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(ubicacion_parroquia,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, mitad-135, 587);

            //IMPRIME FECHA DE BAUTISMO
            //separo la fecha de bautismo
            fecha = fechaBautismo.Split('-');
            fecha[1] = fecha[1].ToUpper();

            //imprimo el dia
            ev.Graphics.DrawString(fecha[2],
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 115, 615);

            //imprimo el mes
            ev.Graphics.DrawString(fecha[1],
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 205, 615);

            //imprimo el año
            ev.Graphics.DrawString(fecha[0],
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 505, 615);

            //IMPRIME PRESBITERO
            ev.Graphics.DrawString(presbitero,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 190, 645);

            //IMPRIME ANOTACION
            ev.Graphics.DrawString(anotacion,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 190, 689);

            //IMPRIME LIBRO
            ev.Graphics.DrawString(libro,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 100, 720);

            //IMPRIME FOJA   
            ev.Graphics.DrawString(foja,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 113, 748);

            //IMPRIME PARTIDA
            ev.Graphics.DrawString(partida,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 120, 777);

            //NOMBRE DEL PARROCO
            tamaño_total = 880 - ev.Graphics.MeasureString(nombre_parroco, new Font("Times New Roman", 9, FontStyle.Bold)).Width;
            mitad = tamaño_total / 2;
            ev.Graphics.DrawString(nombre_parroco,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, mitad-90, 748);

        }

        //METODO PARA IMPRIMIR COPIA DE CONFIRMACION
        public void imprimirConfirmacionCopia(object sender, PrintPageEventArgs ev)
        {
            imprimeImagen(ev);

            /*OBTENCION DE LA MITAD DE LA HOJA***********************/
            /**/float tamaño_total;
            /**/tamaño_total = 880 - ev.Graphics.MeasureString(nombre, new Font("Times New Roman", 18, FontStyle.Bold) ).Width;
            /**/float mitad = tamaño_total / 2;
            /********************************************************/

            //IMPRIME NOMBRE
            ev.Graphics.DrawString(nombre,
               new Font("Times New Roman", 18, FontStyle.Bold),
                       Brushes.Black, mitad, 385);

            //IMPRIME FECHA DE CONFIRMACION
            String [] fecha = fechaConfirmacion.Split('-');
            ev.Graphics.DrawString(fecha[2]+" DE "+fecha[1].ToUpper()+" DE "+fecha[0]+".",
                new Font("Times New Roman", 12, FontStyle.Bold),
                        Brushes.Black, 267, 460);

            //IMPRIME PADRES
            ev.Graphics.DrawString(padre+" Y "+madre,
                new Font("Times New Roman", 11, FontStyle.Bold),
                        Brushes.Black, 220, 530);

            //IMPRIME PADRINOS
            ev.Graphics.DrawString(padrino + " Y " + madrina,
                new Font("Times New Roman", 11, FontStyle.Bold),
                        Brushes.Black, 220, 555);

            //IMPRIME LUGAR Y FECHA DE BAUTISMO
            fecha = fechaBautismo.Split('-');
            ev.Graphics.DrawString("EL " + fecha[2] + " DE " + fecha[1].ToUpper() + " DE " + fecha[0] + " EN " + lugarBautismo+".",
                new Font("Times New Roman", 11, FontStyle.Bold),
                        Brushes.Black, 220, 578);

            //IMPRIME PRESBITERO
            ev.Graphics.DrawString(presbitero+".",
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 405, 627);

            //IMPRIME FECHA ACTUAL
            String d = DateTime.Now.Day + "";
            String m = DateTime.Now.ToString("MMMM");
            String a = DateTime.Now.Year + "";

            //ESTABLECEMOS EL MES EN MAYUSCULA
            m = m.ToUpper();

            ev.Graphics.DrawString(d + " DE "+m+" DE "+a,
                new Font("Times New Roman", 11, FontStyle.Bold),
                        Brushes.Black, 313, 740);


        }

        //METODO PARA IMPRIMIR COPIA DE BAUTISMO
        public void imprimirBautismoCopia(object sender, PrintPageEventArgs ev)
        {

            imprimeImagen(ev);

            //IMPRIME LIBRO
            ev.Graphics.DrawString(libro,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 365, 260);

            //IMPRIME FOJA   
            ev.Graphics.DrawString(foja,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 525, 260);

            //IMPRIME PARTIDA
            ev.Graphics.DrawString(partida,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 680, 260);

             //IMPRIME Nombre
             ev.Graphics.DrawString(nombre,
                 new Font("Times New Roman", 9, FontStyle.Bold),
                         Brushes.Black, 310, 298);

            //IMPRIME PAPA 
            ev.Graphics.DrawString(padre,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 190, 405);

            //IMPRIME MADRE
            ev.Graphics.DrawString(madre,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 500, 405);

            //IMPRIME LUGAR DE NACIMIENTO
            ev.Graphics.DrawString(lugarNacimiento,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 185, 440);

            //IMPRIME FECHA DE NACIMIENTO

            //separo la fecha de nacimiento
            String[] fecha = fechaNacimiento.Split('-');
            fecha[1] = fecha[1].ToUpper();

            //Imprimo el dia 
            ev.Graphics.DrawString(fecha[2],
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 465, 440);

            //Imprimo el mes
            ev.Graphics.DrawString(fecha[1],
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 525, 440);

            //Imprimo el año
            ev.Graphics.DrawString(fecha[0],
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 695, 440);

            //IMPRIME FECHA DE BAUTISMO
            //separo la fecha de bautismo
            fecha = fechaBautismo.Split('-');

            fecha[1] = fecha[1].ToUpper();

            //imprimo el dia
            ev.Graphics.DrawString(fecha[2],
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 300, 477);

            //imprimo el mes
            ev.Graphics.DrawString(fecha[1],
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 435, 477);

            //imprimo el año
            ev.Graphics.DrawString(fecha[0],
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 650, 477);

            //IMPRIME PRESBITERO
            ev.Graphics.DrawString(presbitero,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 250, 513);

            //IMPRIME PADRINO
            ev.Graphics.DrawString(padrino,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 210, 547);

            //IMPRIME MADRINA
            ev.Graphics.DrawString(madrina,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 485, 547);

            //IMPRIME ANOTACIONES 
            notasRenglones(anotacion,ev, 260, 618, 60, "b");

            //ESTABLECEMOS LA FECHA ACTUAL
            String d = DateTime.Now.Day+"";
            String m = DateTime.Now.ToString("MMMM");
            String a = DateTime.Now.Year+"";

            m = m.ToUpper();

            ev.Graphics.DrawString(d,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 290, 795);

            ev.Graphics.DrawString(m,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 400, 795);

            ev.Graphics.DrawString(a,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 615, 795);


        }

        public void notasRenglones(String nota, PrintPageEventArgs ev, int i, int j, int u, string l )
        {
            if (cont == 1)
                u = 78;
            cont++;
            if (nota.Length > u)
            {
                ev.Graphics.DrawString(nota.Substring(0, u)+" - ",
              new Font("Times New Roman", 9, FontStyle.Bold),
                      Brushes.Black, i, j);
                if (l.CompareTo("a") == 0)
                {
                    i = 114;
                    j = j + 20;
                }
                else if(l.CompareTo("b")==0)
                {
                    i = 120;
                    j = j + 35;
                }

                notasRenglones(nota.Substring(u), ev, i, j, u,l);
            }
            else
            {
                ev.Graphics.DrawString(nota,
                new Font("Times New Roman", 9, FontStyle.Bold),
                Brushes.Black, i, j);
            }
            

        }

        public void imprimeImagen(PrintPageEventArgs ev)
        {
            //IMPRIMIMOS DOCUMENTO
            ev.Graphics.DrawImage(newImage, 0, 0);
            
        }


    }
}
