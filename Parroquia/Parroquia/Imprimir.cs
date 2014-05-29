using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parroquia
{
    class Imprimir
    {

        /*public Imprimir()
        {
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
        }

        public void imprimir()
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
        }*/

        /*    public void pd_PrintPage(object sender, PrintPageEventArgs ev)
    {
        //IMPRIME TITULO
        ev.Graphics.DrawString("ANTUNEZ MICHOACAN",
            new Font("Times New Roman", 10, FontStyle.Bold),
                    Brushes.Black, 350, 50);
        ev.Graphics.DrawString("PARROQUIA DE NUESTRA SEÑORA DE GUADALUPE",
            new Font("Times New Roman", 10, FontStyle.Bold),
                    Brushes.Black, 250, 80);
    }

        public void imprimirDato()
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
        }*/

    }
}
