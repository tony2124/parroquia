using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parroquia
{
    class Imprimir
    {
        PrintDialog pDialog;
        PrintPreviewDialog ppD ;
        PrintDocument pd;
        Image newImage;

        //Controladores para imprimir las anotaciones en diferentes renglones*/
        /**/ public int i = 260, j = 618, u = 60, cont = 0;
        /***********************************************************************/

        public static String libro, foja, partida, nombre, padre, madre, 
            lugarNacimiento, fechaNacimiento, fechaBautismo, presbitero, 
            madrina, padrino, anotacion, lugarBautismo, fechaConfirmacion;

        public int CATEGORIA;

        public void leerArchivoBautismo()
        {
            if(CATEGORIA == 1)
                newImage = Image.FromFile("C:\\DOCSParroquia\\Bautismo.jpg");
            else if (CATEGORIA == 2)
                newImage = Image.FromFile("C:\\DOCSParroquia\\Confirmacion.jpg");



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
            String i, String j, String k, String l, String m, int categoria)
        {
            //Asignacion de variables
            libro = a;
            foja = b;
            partida = c;
            CATEGORIA = categoria;

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



            //DESPUES DE GUARDAR IMPRIMO
            Cursor.Current = Cursors.WaitCursor;
            //SE ESTABLECEN LAS PROPIEDADES DE IMPRESORA
            

            if (ImpresoraProperties())
            {
                //SE LEE EL ARCHIVO QUE SE IMPRIMIRA
                leerArchivoBautismo();

                //SE manda a imprimir el archivo leido y lleno de informacion
                mandaImpresion();
                
            }
        }

        public void mandaImpresion(){
            pd.PrinterSettings = pDialog.PrinterSettings;
            pd.PrinterSettings.Copies = pDialog.PrinterSettings.Copies;

            if(CATEGORIA==1)
                pd.PrintPage += new PrintPageEventHandler
                    (this.imprimirBautismoCopia);
            else if(CATEGORIA==2)
                pd.PrintPage += new PrintPageEventHandler
                   (this.imprimirConfirmacionCopia);

            ppD.Document = pd;
            ppD.ShowDialog();
            ppD.BringToFront();

            //pd.Print();
        }

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
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 220, 532);

            //IMPRIME PADRINOS
            ev.Graphics.DrawString(padrino + " Y " + madrina,
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 220, 557);

            //IMPRIME LUGAR Y FECHA DE BAUTISMO
            fecha = fechaBautismo.Split('-');
            ev.Graphics.DrawString("EL " + fecha[2] + " DE " + fecha[1].ToUpper() + " DE " + fecha[0] + " EN " + lugarBautismo+".",
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 220, 581);

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
                new Font("Times New Roman", 9, FontStyle.Bold),
                        Brushes.Black, 310, 743);


        }

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

            //IMPRIME PAPA 478
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
            notasMarginales(anotacion,ev);


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

        public void notasMarginales(String nota, PrintPageEventArgs ev)
        {
            if (cont == 1)
                u = 78;
            cont++;
            if (nota.Length > u)
            {
                ev.Graphics.DrawString(nota.Substring(0, u)+" - ",
              new Font("Times New Roman", 9, FontStyle.Bold),
                      Brushes.Black, i, j);
                i = 120;
                j = j + 35;
                
                notasMarginales(nota.Substring(u), ev);
            }
            else
            {
                ev.Graphics.DrawString(nota,
                new Font("Times New Roman", 10, FontStyle.Bold),
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
