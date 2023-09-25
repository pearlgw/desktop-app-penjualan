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

namespace Penjualan
{
    public partial class Gudang : Form
    {
        public Gudang()
        {
            InitializeComponent();
            Bersih();
            refresh_gudang();
            Atur_Tombol(false);
            auto_number();
        }

        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        koneksi con = new koneksi();

        void Bersih()
        {
            textBox2.Text = "";
            textBox3.Text = "";
        }

        void Atur_Tombol(Boolean Status)
        {
            button2.Enabled = Status;
            button3.Enabled = Status;
        }

        void refresh_gudang()
        {
            SqlConnection conn = con.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from Gudang", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Gudang");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Gudang";
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

        void auto_number()
        {
            long hitung;
            string urut;
            SqlDataReader rd;
            SqlConnection conn = con.GetConn();
            conn.Open();
            cmd = new SqlCommand("select Kode_Gudang from Gudang where Kode_Gudang in (select max(Kode_Gudang) from Gudang) order by Kode_Gudang desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["Kode_Gudang"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + hitung;
                urut = "GDNG" + joinstr.Substring(joinstr.Length - 3, 3);
            }
            else
            {
                urut = "GDNG001";
            }
            rd.Close();
            textBox1.Enabled = false;
            textBox1.Text = urut;
            conn.Close();
        }

        // prosedur cari barang
        void cari_barang()
        {
            SqlConnection conn = con.GetConn();
            try
            {
                conn.Open();
                //cmd = new SqlCommand("select * from Gudang where Kode_User like '%" + textBox5.Text + "%' or Nama like'%" + textBox5.Text + "%'", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Gudang");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Gudang";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap");
            }
            else
            {
                SqlConnection conn = con.GetConn();
                cmd = new SqlCommand("insert into Gudang values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan");
                Bersih();
                refresh_gudang();
                Atur_Tombol(false);
                auto_number();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bersih();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                button1.Enabled = false;
                Atur_Tombol(true);
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["Kode_Gudang"].Value.ToString();
                textBox2.Text = row.Cells["Nama_Gudang"].Value.ToString();
                textBox3.Text = row.Cells["Alamat"].Value.ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = con.GetConn();
            try
            {
                cmd = new SqlCommand("update Gudang set Nama_Gudang = '" + textBox2.Text + "',Alamat = '" + textBox3.Text + "' where Kode_Gudang = '" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil diubah");
                refresh_gudang();
                Bersih();
                Atur_Tombol(false);
                button1.Enabled = true;
                auto_number();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin Ingin Menghapus Data Gudang :" + textBox2.Text + "?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                SqlConnection conn = con.GetConn();
                cmd = new SqlCommand("delete from Gudang where Kode_Gudang = '" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Dihapus");
                refresh_gudang();
                Bersih();
                Atur_Tombol(false);
                button1.Enabled = true;
                auto_number();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
