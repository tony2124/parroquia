using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parroquia
{
    public partial class Egresos : Form
    {
        public Egresos()
        {
            InitializeComponent();
            DataSet ds = new DataSet();
            tabla.Columns.Add("Fecha","Fecha");
            tabla.Columns.Add("conceptos", "Conceptos");
            tabla.Columns.Add("Fecha", "Sueldos");
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

            /**** ANCHO DE LA COLUMNA ******/
            tabla.Columns[0].Width = 40;
            for(int i = 1; i < 19; i++)
            {
                tabla.Columns[i].Width = 55;
                tabla.Columns[i].MinimumWidth = 30;
                tabla.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            //** suma por columnas **/
            for (int i = 2; i < 18; i++)
                sumaFilaColumna(0, i);

            //Suma opr filas
            for (int i = 0; i < 31; i++)
                sumaFilaColumna(i, 2);
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
            tabla.Rows[fila].Cells[18].Value = "$  " + suma;
            
            /*** SUMA DE COLUMNA ***/
            suma = 0.0;
            for(int i = 0; i < 31; i++)
            {
                if (estaVacia(i, col))
                    suma += 0.0;
                else
                {
                    //MessageBox.Show(tabla.Rows[i].Cells[col].Value + "");
                    suma += double.Parse(tabla.Rows[i].Cells[col].Value + "");
                }
            }
            tabla.Rows[31].Cells[col].Value = "$  " + suma;
        }

        private void tabla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show("Editada: Column: "+e.ColumnIndex+" Row:"+e.RowIndex);
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
    }
}
