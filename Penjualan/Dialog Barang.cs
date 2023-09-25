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
    public partial class Dialog_Barang : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        public string Kode_Barang, Nama_Barang, Harga = "";

        koneksi con = new koneksi();
        public Dialog_Barang()
        {
            InitializeComponent();
            refresh_barang();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cari_barang();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                Kode_Barang = row.Cells["Kode_Barang"].Value.ToString();
                Nama_Barang = row.Cells["Nama_Barang"].Value.ToString();
                Harga = row.Cells["Harga"].Value.ToString();
                this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        void refresh_barang()
        {
            SqlConnection conn = con.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from Barang", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Barang");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Barang";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.Refresh();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        void cari_barang()
        {
            SqlConnection conn = con.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from Barang where Kode_Barang like '%" + textBox1.Text + "%' or Nama_Barang like'%" + textBox1.Text + "%'", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Barang");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Barang";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.Refresh();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        public String ambil_kode_Barang
        {
            get
            {
                return Kode_Barang;
            }
        }

        private void Dialog_Barang_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public String ambil_nama_Barang
        {
            get
            {
                return Nama_Barang;
            }
        }
        public String ambil_Harga
        {
            get
            {
                return Harga;
            }
        }
    }
}
