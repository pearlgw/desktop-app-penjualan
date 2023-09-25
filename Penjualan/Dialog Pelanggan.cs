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
    public partial class Dialog_Pelanggan : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        public string Id_Pelanggan, Nama_Pelanggan = "";

        koneksi con = new koneksi();
        public Dialog_Pelanggan()
        {
            InitializeComponent();
            refresh_pelanggan();
        }
        void refresh_pelanggan()
        {
            SqlConnection conn = con.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from Pelanggan", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Pelanggan");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Pelanggan";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cari_pelanggan();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        void cari_pelanggan()
        {
            SqlConnection conn = con.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from Pelanggan where Id_Pelanggan like '%" + textBox1.Text + "%' or Nama_Pelanggan like'%" + textBox1.Text + "%'", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Pelanggan");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Pelanggan";
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
        public String ambil_id_Pelanggan
        {
            get
            {
                return Id_Pelanggan;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                Id_Pelanggan = row.Cells["Id_Pelanggan"].Value.ToString();
                Nama_Pelanggan = row.Cells["Nama_Pelanggan"].Value.ToString();
                this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        public String ambil_nama_pelanggan
        {
            get
            {
                return Nama_Pelanggan;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public string ambil_ID_pelanggan
        {
            get
            {
                return Id_Pelanggan;
            }
        }
    }
}
