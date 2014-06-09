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
    public partial class configurarCoordenada : Form
    {
        public MySqlDataReader datos;
        private string bhx, bhy, bvx, bvy, cx, cy, px, py, mx, my;
        private ConexionBD Bda;
        public configurarCoordenada()
        {
            InitializeComponent();
            int i = 0;
            Bda = new ConexionBD();

            Bda.conexion();

            datos = Bda.obtenerBasesDatosMySQL("select x,y from coordenadas");

            if (datos.HasRows)
            {
                while (datos.Read())
                {
                    if (i == 0)
                    {
                        bhx = datos.GetString(0);
                        bhy = datos.GetString(1);
                    }
                    else if (i == 1)
                    {
                        cx = datos.GetString(0);
                        cy = datos.GetString(1);
                    }
                    else if (i == 2)
                    {
                        px = datos.GetString(0);
                        py = datos.GetString(1);
                    }
                    else if (i == 3)
                    {
                        mx = datos.GetString(0);
                        my = datos.GetString(1);
                    }
                    else if (i == 4)
                    {
                        bvx = datos.GetString(0);
                        bvy = datos.GetString(1);
                    }


                    i++;
                    
                }
            }
            datos.Close();
            Bda.Desconectar();

            BHX.Text = float.Parse(bhx) +"";
            BHY.Text = float.Parse(bhy) + "";

            BVX.Text = float.Parse(bvx) + "";
            BVY.Text = float.Parse(bvy) + "";

            CX.Text = float.Parse(cx)  + "";
            CY.Text = float.Parse(cy)  + "";

            PX.Text = float.Parse(px)  + "";
            PY.Text = float.Parse(py)  + "";

            MX.Text = float.Parse(mx)  + "";
            MY.Text = float.Parse(my)  + "";


        }

        private void configurarCoordenada_Load(object sender, EventArgs e)
        {

        }

        private void guardar_Click(object sender, EventArgs e)
        {
            Bda.conexion();
            //Math.Ceiling(float.Parse(BHX.Text) * 30 )
            if (Bda.peticion("update coordenadas set x=" + BHX.Text+ ", y=" + BHY.Text + " where id=1") > 0 &&
                Bda.peticion("update coordenadas set x=" + BVX.Text + ", y=" + BVY.Text + " where id=5") > 0 &&
                Bda.peticion("update coordenadas set x=" + CX.Text+ ", y=" + CY.Text+ " where id=2") > 0 &&
                Bda.peticion("update coordenadas set x=" + PX.Text+ ", y=" + PY.Text+ " where id=3") > 0 &&
                Bda.peticion("update coordenadas set x=" + MX.Text+ ", y=" + MY.Text + " where id=4") > 0)
                MessageBox.Show("Coordenadas actualizadas","Exito",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Bda.Desconectar();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
