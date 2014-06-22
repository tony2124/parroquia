﻿using conexionbd;
using MySql.Data.MySqlClient;
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
    public partial class Ingresos : Form
    {

        static int num_columns = 6, num_rows = 5, num_dias_del_mes, primer_domingo;
        int[,] matriz_modificacion; // 0 -> null   1 -> ya registrado   2 -> modificado ya registrado  3 -> modificado no registrado
        double[,] matriz_mapeada; //matriz que mapea los datos a la tabla
        double cant_egresos;

        public Ingresos()
        {
            InitializeComponent();

            /****  MES Y AÑOS  ****/
            Object[] a = new Object[DateTime.Now.Year - 2014 + 1];
            for (int i = 2014; i <= DateTime.Now.Year; i++)
                a[i - 2014] = i;
            anio.Items.AddRange(a);
            anio.Text = DateTime.Now.Year + "";
            mes.SelectedIndex = DateTime.Now.Month - 1;

            /**** consultar EGRESOS ****
            ConexionBD db = new ConexionBD();
            db.conexion();
            MySqlDataReader Datos = db.obtenerBasesDatosMySQL("SELECT sum(cantidad) as suma FROM egresos WHERE fecha >= '" + anio.Text + "-" + (mes.SelectedIndex + 1) + "-01' AND fecha <= '" + anio.Text + "-" + (mes.SelectedIndex + 1) + "-31'");

            if (Datos.HasRows)
            {
                while (Datos.Read())
                {
                    cant_egresos = Datos.GetDouble(0);
                }
            }

         //   actualizarDatos();
            /**** IMPRIMIR ***/
        }

        //Actualizar datos
        void actualizarDatos()
        {
            if (mes.SelectedIndex == -1) return;

            /*** OBTENER EL NUMERO DE DIAS DEL MES ****/
            int calc_mes = (mes.SelectedIndex + 1) % 12 + 1;
            
            num_dias_del_mes = Convert.ToDateTime(anio.Text + "-" + calc_mes + "-01").AddDays(-1).Day;

            primer_domingo = (7 - (int)Convert.ToDateTime(anio.Text + "-" + (mes.SelectedIndex + 1) + "-01").DayOfWeek) % 7 + 1;

            //MessageBox.Show( primer_domingo + "");

            /*** CREAR NUEVAS MATRICES ***/
            matriz_modificacion = new int[num_rows, num_columns];
            matriz_mapeada = new double[num_rows + 1, num_columns + 1];

            tabla.Rows.Clear();

            /** CARACTERISTICAS DE LA TABLA ****/
            tabla.Rows.Add(num_rows);
            tabla.Rows.Insert(tabla.RowCount - 1, "");
            tabla.Rows[num_rows].Cells[0].Value = "TOTAL";

            tabla.Rows[num_rows].ReadOnly = true;
            tabla.Columns[num_columns].ReadOnly = true;

            //CALCULO DE SEMANAS
            for (int i = 0, dia_inicial = primer_domingo; dia_inicial <= num_dias_del_mes; i++, dia_inicial+=7)
                tabla.Rows[i].SetValues(dia_inicial + " " + mes.Text);

           // MessageBox.Show(DateTime.Now.DayOfWeek+"");

            //Hacer consulta
            restaurar((mes.SelectedIndex + 1) + "", anio.Text);

            //** calculo de totales **/
            calculoTotales();

        }

        //Consultar la informacion en la base de datos y mostrar la información.
        public void restaurar(string mes, string anio)
        {
            DateTime fecha;
            int concepto;
            double cantidad;

            ConexionBD db = new ConexionBD();
            db.conexion();
            MySqlDataReader Datos = db.obtenerBasesDatosMySQL("SELECT * FROM ingresos WHERE fecha >= '" + anio + "-" + mes + "-01' AND fecha <= '" + anio + "-" + mes + "-" + num_rows + "'");
            if (Datos.HasRows)
            {
                while (Datos.Read())
                {
                    fecha = Datos.GetDateTime(0);
                    concepto = Datos.GetInt32(1);
                    cantidad = Datos.GetDouble(2);
                    matriz_mapeada[fecha.Day - 1, concepto] = cantidad;
                    matriz_modificacion[fecha.Day - 1, concepto] = 1;
                    tabla.Rows[fecha.Day - 1].Cells[concepto].Value = cantidad;
                }
            }
            Datos.Close();
            Datos = db.obtenerBasesDatosMySQL("SELECT sum(cantidad) as suma FROM egresos WHERE fecha >= '" + anio + "-" + mes + "-01' AND fecha <= '" + anio + "-" + mes + "-31'");

            if (Datos.HasRows)
            {
                while (Datos.Read())
                {
                    try
                    {
                        cant_egresos = Datos.GetDouble(0);
                    }
                    catch (Exception e)
                    {
                        cant_egresos = 0;
                    }
                }
            }

            Datos.Close();

        }

        //escribir los datos en la matriz mapeada
        public void mapear_matriz(int fil, int col, double valor)
        {
            /*** CALCULANDO TOTALES Y ESCRIBIENDO NUEVO VALOR **/
            matriz_mapeada[fil, num_columns] = matriz_mapeada[fil, num_columns] - matriz_mapeada[fil, col] + valor;
            matriz_mapeada[num_rows, col] = matriz_mapeada[num_rows, col] - matriz_mapeada[fil, col] + valor;
            matriz_mapeada[fil, col] = valor;

            tabla.Rows[fil].Cells[num_columns].Value = matriz_mapeada[fil, num_columns];
            tabla.Rows[num_rows].Cells[col].Value = matriz_mapeada[num_rows, col];
            tabla.Rows[fil].Cells[col].Value = valor;

            /**** ESTABLECER MODO DE ALMACENAMIENTO ****/
            switch (matriz_modificacion[fil, col])
            {
                case 0: matriz_modificacion[fil, col] = 3; break;
                case 1: matriz_modificacion[fil, col] = 2; break;
            }

            /**** CALCULAR TOTAL ****/
            double suma = 0.0;
            for (int i = 0; i < num_rows; i++)
                suma += matriz_mapeada[i, num_columns];

            tabla.Rows[num_rows].Cells[num_columns].Value = suma;
            double exento = 0;
            if (cant_egresos - suma <= 0)
                exento = 0;
            else exento = cant_egresos - suma;
            
            tabla.Rows[0].Cells[1].Value = exento;

            total.Text = "$ " + String.Format("{0:0.00}", suma);
            ingresos_lbl.Text = "$ " + String.Format("{0:0.00}", suma);
            egresos.Text = "$ " + String.Format("{0:0.00}", cant_egresos);
            total_exento.Text = "$ " + String.Format("{0:0.00}", exento);
            diez_por_ciento.Text = "$ " + String.Format("{0:0.00}", suma * 0.1);
            dos_por_ciento.Text = "$ " + String.Format("{0:0.00}", suma * 0.02);
            total_mitra.Text = "$ " + String.Format("{0:0.00}", suma * 0.1 + suma * 0.02 + Double.Parse(otros_gastos.Text) + Double.Parse(contador.Text)); 
        }

        //CALCULAR LOS TOTALES
        private void calculoTotales()
        {
            double suma = 0;
            /*** SUMA DE FILA O(n*m) ***/
            for (int fila = 0; fila < num_rows; fila++)
            {
                suma = 0;
                for (int i = 2; i < num_columns; i++)
                    suma += matriz_mapeada[fila, i];
                matriz_mapeada[fila, num_columns] = suma;
                tabla.Rows[fila].Cells[num_columns].Value = suma;
            }

            /*** SUMA DE COLUMNA ***/
            for (int col = 2; col < num_columns + 1; col++)
            {
                suma = 0.0;
                for (int i = 0; i < num_rows; i++)
                    suma += matriz_mapeada[i, col];
                matriz_mapeada[num_rows, col] = suma;
                tabla.Rows[num_rows].Cells[col].Value = suma;
            }
            tabla.Rows[num_rows].Cells[num_columns].Value = suma;

            double exento = 0;
            if (cant_egresos - suma <= 0)
                exento = 0;
            else exento = cant_egresos - suma;

            tabla.Rows[0].Cells[1].Value = exento;
            total.Text = "$ " + String.Format("{0:0.00}", suma);
            ingresos_lbl.Text = "$ " + String.Format("{0:0.00}", suma);
            egresos.Text = "$ " + String.Format("{0:0.00}", cant_egresos);
            total_exento.Text = "$ " + String.Format("{0:0.00}", exento);
            diez_por_ciento.Text = "$ " + String.Format("{0:0.00}", suma * 0.1);
            dos_por_ciento.Text = "$ " + String.Format("{0:0.00}", suma * 0.02);
            total_mitra.Text = "$ " + String.Format("{0:0.00}", suma * 0.1 + suma * 0.02 + Double.Parse(otros_gastos.Text) + Double.Parse(contador.Text)); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void tabla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double valor = double.Parse(tabla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "");
                mapear_matriz(e.RowIndex, e.ColumnIndex, valor);
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, "El valor ingresado no es válido", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                mapear_matriz(e.RowIndex, e.ColumnIndex, 0);
            }
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            ConexionBD datos = new ConexionBD();
            datos.conexion();
            int dia_inicial = 1;
            for (int dia = 0; dia < num_rows; dia++)
                for (int concep = 2; concep < num_columns; concep++, dia_inicial += 7)
                {
                    if (matriz_modificacion[dia, concep] == 2)
                    {
                        String fecha = anio.Text + "-" + (mes.SelectedIndex + 1) + "-" + (dia_inicial);
                        if (datos.peticion("UPDATE ingresos SET cantidad = " + matriz_mapeada[dia, concep] + " WHERE fecha = '" + fecha + "' AND concepto = " + concep) > 0)
                        {
                            matriz_modificacion[dia, concep] = 1;
                        }
                    }
                    else if (matriz_modificacion[dia, concep] == 3)
                    {
                        String fecha = anio.Text + "-" + (mes.SelectedIndex + 1) + "-" + (dia_inicial);
                        if (datos.peticion("INSERT INTO ingresos (fecha, concepto, cantidad) values('" + fecha + "'," + concep + "," + matriz_mapeada[dia, concep] + ")") > 0)
                        {
                            matriz_modificacion[dia, concep] = 1;
                        }
                    }
                }
            MessageBox.Show(this, "Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void contador_Leave(object sender, EventArgs e)
        {
            if (contador.Text.CompareTo("") == 0)
                contador.Text = "0";
            calculoTotales();
        }

        private void otros_gastos_Leave(object sender, EventArgs e)
        {
            if (otros_gastos.Text.CompareTo("") == 0)
                otros_gastos.Text = "0";
            calculoTotales();
        }

        private void mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarDatos();
        }

        private void anio_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarDatos();
        }
    }
}
