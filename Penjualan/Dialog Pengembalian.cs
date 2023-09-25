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
    public partial class Dialog_Pengembalian : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;


        koneksi con = new koneksi();
        public Dialog_Pengembalian()
        {
            InitializeComponent();
        }
        public string Nama_Barang, No_Kwitansi, Kode_Barang, Jumlah, Harga, Satuan = "";

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = con.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from View_Detail where Kode_Barang like '%" + textBox1.Text + "%' or Nama_Barang like'%" + textBox1.Text + "%'", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "View_Detail");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "View_Detail";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.Refresh();
            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public string ambil_Nama_Barang
        {
            get
            {
                return Nama_Barang;
            }
        }

        private void Cari_Pengembalia_Load(object sender, EventArgs e)
        {
            SqlConnection conn = con.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from View_Detail", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "View_Detail");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "View_Detail";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.Refresh();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            Nama_Barang = row.Cells["Nama_Barang"].Value.ToString();
            No_Kwitansi = row.Cells["No_Kwitansi"].Value.ToString();
            Kode_Barang = row.Cells["Kode_Barang"].Value.ToString();
            Jumlah = row.Cells["Jumlah"].Value.ToString();
            Harga = row.Cells["Harga"].Value.ToString();
            Satuan = row.Cells["Satuan"].Value.ToString();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public string ambil_No_Kwitansi
        {
            get
            {
                return No_Kwitansi;               
            }
        }
        public string ambil_Kode_Barang
        {
            get
            {
                return Kode_Barang;
            }
        }
        public string ambil_Jumlah
        {
            get
            {
                return Jumlah;
            }
        }
        public string ambil_Harga
        {
            get
            {
                return Harga;
            }
        }
        public string ambil_Satuan
        {
            get
            {
                return Satuan;
            }
        }
    }
}
