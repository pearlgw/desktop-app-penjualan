using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Penjualan
{
    public partial class Laporan_Pengembalian : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-638C77F;Initial Catalog=Penjualan;Integrated Security=True");
        public Laporan_Pengembalian()
        {
            InitializeComponent();
        }
        void dg()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Pengembalian";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataGridView1.DataMember = "Pengembalian";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Refresh();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Laporan_Pengembalian_Load(object sender, EventArgs e)
        {
            dg();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Pengembalian where Kode_Barang like '%" + textBox1.Text + "%' or Nama_Barang like '%" + textBox1.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
