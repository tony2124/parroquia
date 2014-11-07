using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        MySqlDataAdapter customersTableAdapter;
        DataTable customerTable;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeSortedFilteredBindingSource(object sender, EventArgs e)
        {
            // Create the connection string, data adapter and data table.
            MySqlConnection connectionString =
                 new MySqlConnection("server=localhost; port=3306; user id=root; password=SIMPUS2124; database=parroquiaantunez");
            customersTableAdapter =
                new MySqlDataAdapter("Select * from bautismos", connectionString);
            
            customerTable = new DataTable();

            // Fill the the adapter with the contents of the customer table.
            customersTableAdapter.Fill(customerTable);
            bindingSource1.DataSource = customerTable;
            bindingSource1.Filter = "anio='2012'";
            dataGridView1.DataSource = bindingSource1;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            customersTableAdapter.Fill(customerTable);
            bindingSource1.DataSource = customerTable;
            bindingSource1.Filter = "anio='"+comboBox1.Text+"'";
            dataGridView1.DataSource = bindingSource1;
        }

    }
}
