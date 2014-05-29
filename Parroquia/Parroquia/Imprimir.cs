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
        /**/ public int i = 260, j = 690, u = 50, cont = 0;
        /***********************************************************************/

        public static String libro, foja, partida, nombre, padre, madre, lugarNacimiento,
            fechaNacimiento, fechaBautismo, presbitero, madrina, padrino, anotacion;

        public void leerArchivo()
        {
            newImage = Image.FromFile("C:\\DOCSParroquia\\Bautismo.jpg");
        }

        public Imprimir(String a, String b, String c, String d, String e, String f, 
            String g, String h, String i, String j, String k, String l, String m)
        {
            //Asignacion de variables
            libro = a;
            foja = b;
            partida = c;
            nombre = d;
            padre = e;
            madre = f;
            lugarNacimiento = g;
            fechaNacimiento = h;
            fechaBautismo = i;
            presbitero = j;
            madrina = k;
            padrino = l;
            anotacion = m;



            //DESPUES DE GUARDAR IMPRIMO
            Cursor.Current = Cursors.WaitCursor;
            //SE ESTABLECEN LAS PROPIEDADES DE IMPRESORA
            pDialog = new PrintDialog();
            ppD = new PrintPreviewDialog();
            pd = new PrintDocument();
            

            ppD.PrintPreviewControl.Zoom = 1;
            ppD.WindowState = FormWindowState.Maximized;
            ppD.MinimizeBox = true;
            ppD.ShowInTaskbar = true;

            pDialog.AllowSomePages = false;
            pDialog.AllowPrintToFile = false;

            DialogResult t= pDialog.ShowDialog();
           

            if (t == DialogResult.OK)
            {
                //SE LEE EL ARCHIVO QUE SE IMPRIMIRA
                leerArchivo();

                pd.PrinterSettings = pDialog.PrinterSettings;
                pd.PrinterSettings.Copies = pDialog.PrinterSettings.Copies;

                pd.PrintPage += new PrintPageEventHandler
                    (this.imprimirBautismo);

               /* ppD.Document = pd;
                ppD.ShowDialog();
                ppD.BringToFront();*/
                
               pd.Print();
            }
        }

        public void imprimirBautismo(object sender, PrintPageEventArgs ev)
        {

            //IMPRIMIMOS DOCUMENTO
            ev.Graphics.DrawImage(newImage, 0, 0);

            //IMPRIME LIBRO
            ev.Graphics.DrawString(libro,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 355, 260);

            //IMPRIME FOJA   
            ev.Graphics.DrawString(foja,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 505, 260);

            //IMPRIME PARTIDA
            ev.Graphics.DrawString(partida,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 650, 260);

             //IMPRIME Nombre
             ev.Graphics.DrawString(nombre,
                 new Font("Times New Roman", 10, FontStyle.Bold),
                         Brushes.Black, 310, 298);

            //IMPRIME PAPA
            ev.Graphics.DrawString(padre,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 200, 478);

            //IMPRIME MADRE
            ev.Graphics.DrawString(madre,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 440, 478);

            //IMPRIME LUGAR DE NACIMIENTO
            ev.Graphics.DrawString(lugarNacimiento,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 185, 513);

            //IMPRIME FECHA DE NACIMIENTO
            //separo la fecha de nacimiento
            String[] fecha = fechaNacimiento.Split('-');

            //Imprimo el dia 
            ev.Graphics.DrawString(fecha[2],
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 495, 513);

            //Imprimo el mes
            ev.Graphics.DrawString(fecha[1],
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 575, 513);

            //Imprimo el año
            ev.Graphics.DrawString(fecha[0],
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 665, 513);

            //IMPRIME FECHA DE BAUTISMO
            //separo la fecha de bautismo
            fecha = fechaBautismo.Split('-');

            //imprimo el dia
            ev.Graphics.DrawString(fecha[2],
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 300, 550);

            //imprimo el mes
            ev.Graphics.DrawString(fecha[1],
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 490, 550);

            //imprimo el año
            ev.Graphics.DrawString(fecha[0],
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 620, 550);

            //IMPRIME PRESBITERO
            ev.Graphics.DrawString(presbitero,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 250, 585);

            //IMPRIME PADRINO
            ev.Graphics.DrawString(padrino,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 210, 620);

            //IMPRIME MADRINA
            ev.Graphics.DrawString(madrina,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 460, 620);

            //IMPRIME ANOTACIONES 
            notasMarginales(anotacion,ev);


            //ESTABLECEMOS LA FECHA ACTUAL
            String d = DateTime.Now.Day+"";
            String m = DateTime.Now.Month+"";
            String a = DateTime.Now.Year+"";

            ev.Graphics.DrawString(d,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 290, 866);

            ev.Graphics.DrawString(m,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 460, 866);

            ev.Graphics.DrawString(a,
                new Font("Times New Roman", 10, FontStyle.Bold),
                        Brushes.Black, 600, 866);


        }

        public void notasMarginales(String nota, PrintPageEventArgs ev)
        {
            if (cont == 1)
                u = 65;
            cont++;
            if (nota.Length > u)
            {
                ev.Graphics.DrawString(nota.Substring(0, u),
              new Font("Times New Roman", 10, FontStyle.Bold),
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

    }
}
