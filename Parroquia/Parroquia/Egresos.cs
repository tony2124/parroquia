using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;

namespace Parroquia
{
    public partial class Egresos : Form
    {

        public PrintDocument MyPrintDocument;
        DataGridViewPrinter MyDataGridViewPrinter;

        public Egresos()
        {
            InitializeComponent();
            MyPrintDocument = new PrintDocument();
            this.MyPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.MyPrintDocument_PrintPage);
            DataSet ds = new DataSet();
            tabla.Columns.Add("fecha","Fecha");
            tabla.Columns.Add("conceptos", "Conceptos");
            tabla.Columns.Add("sueldo", "Sueldos");
            tabla.Columns.Add("Fecha", "Prima Seguro");
            tabla.Columns.Add("Fecha", "Seguro de Vida");
            tabla.Columns.Add("Fecha", "Mtto. vehículo");
            tabla.Columns.Add("Fecha", "Construcción");
            tabla.Columns.Add("Fecha", "Papelería");
            tabla.Columns.Add("Fecha", "Cocina");
            tabla.Columns.Add("Fecha", "IMSS");
            tabla.Columns.Add("Fecha", "Altar");
            tabla.Columns.Add("Fecha", "Telefono correos");
            tabla.Columns.Add("Fecha", "Luz");
            tabla.Columns.Add("Fecha", "Porcentaje MITRA");
            tabla.Columns.Add("Fecha", "SAR Infonavit");
            tabla.Columns.Add("Fecha", "Ordenadas");
            tabla.Columns.Add("Fecha", "Impuesto");
            tabla.Columns.Add("Fecha", "Diversos");
            tabla.Columns.Add("Fecha", "TOTAL");

            tabla.Rows.Add(31);
            tabla.Rows.Insert(tabla.RowCount-1, "");

            tabla.Rows[31].ReadOnly = true;
            tabla.Columns[18].ReadOnly = true;

            /****  MES Y AÑOS  ****/
            mes.SelectedIndex = DateTime.Now.Month - 1;
            anio.Text = DateTime.Now.Year + "";

            /**** ANCHO DE LA COLUMNA ******/
            tabla.Columns[0].Width = 40;
            for(int i = 1; i < 19; i++)
            {
                tabla.Columns[i].Width = 65;
                tabla.Columns[i].MinimumWidth = 30;
                tabla.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            //** suma por columnas **/
            for (int i = 2; i < 18; i++)
                sumaFilaColumna(0, i);

            //Suma opr filas
            for (int i = 0; i < 31; i++)
                sumaFilaColumna(i, 2);

            //Poner los numeros de los dias
            for (int i = 0; i < 31; i++)
                tabla.Rows[i].SetValues((i+1)+"");
        }

        bool estaVacia(int fil, int col)
        {
            if (tabla.Rows[fil].Cells[col].Value == null)
                return true;
            return false;
        }

        private void sumaFilaColumna(int fila, int col)
        {
            double suma = 0;
            /** SUMA DE FILA */
            for(int i = 2; i < 18; i++)
            {
                if (estaVacia(fila, i))
                    suma += 0.00;
                else 
                    suma += double.Parse(tabla.Rows[fila].Cells[i].Value+"");
            }
            tabla.Rows[fila].Cells[18].Value = "$ " + String.Format("{0:0.00}", suma); ;
            
            /*** SUMA DE COLUMNA ***/
            suma = 0.0;
            for(int i = 0; i < 31; i++)
            {
                if (estaVacia(i, col))
                    suma += 0.0;
                else
                    suma += double.Parse(tabla.Rows[i].Cells[col].Value + "");                
            }
            tabla.Rows[31].Cells[col].Value = "$ " + String.Format("{0:0.00}", suma); ;

            /** calculo de total **/
            suma = 0.0;
            for (int i = 0; i < 31; i++)
            {
                if (estaVacia(i, 18))
                    suma += 0.0;
                else
                    suma += double.Parse((tabla.Rows[i].Cells[18].Value + "").Replace("$",""));
            }
            tabla.Rows[31].Cells[18].Value = "$ " + String.Format("{0:0.00}", suma);;
            total.Text = "$ " + String.Format("{0:0.00}", suma);
        }

        private void tabla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 2)
                return;

            if (!estaVacia(e.RowIndex, e.ColumnIndex))
            {
                try
                {
                    double.Parse(tabla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(this, "El valor ingresado no es válido", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tabla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
            }
            sumaFilaColumna(e.RowIndex, e.ColumnIndex);

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = MyPrintDocument;
                MyPrintPreviewDialog.ShowDialog();
            }
        }

        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private bool SetupThePrinting()
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            MyPrintDocument.DocumentName = "Customers Report";
            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Landscape = true;
        
            MyPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("Legal", 850, 1400);
            MyPrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

           
            MyDataGridViewPrinter = new DataGridViewPrinter(tabla, MyPrintDocument, true, true, "Reportes mensuales", new Font("Tahoma", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
           
            return true;
        }
    }

}
