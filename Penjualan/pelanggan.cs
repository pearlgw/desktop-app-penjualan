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
    public partial class pelanggan : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        koneksi con = new koneksi();
        public pelanggan()
        {
            InitializeComponent();
            bersih();
            atur_tombol(false);
            refresh_pelanggan();
            auto_number();
        }
        void bersih()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox2.Focus();
        }
        void atur_tombol(Boolean status)
        {
            button2.Enabled = status;
            button3.Enabled = status;
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
        void cari_pelanggan()
        {
            SqlConnection conn = con.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from Pelanggan where Id_Pelanggan like '%" + textBox5.Text + "%' or Nama_Pelanggan like'%" + textBox5.Text + "%'", conn);
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
        void auto_number()
        {
            long hitung;
            string urut;
            SqlDataReader rd;
            SqlConnection conn = con.GetConn();
            conn.Open();
            cmd = new SqlCommand("select Id_Pelanggan from Pelanggan where Id_Pelanggan in (select max(Id_Pelanggan) from Pelanggan) order by Id_Pelanggan desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["Id_Pelanggan"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + hitung;
                urut = "P" + joinstr.Substring(joinstr.Length - 3, 3);
            }
            else
            {
                urut = "P001";
            }
            rd.Close();
            textBox1.Enabled = false;
            textBox1.Text = urut;
            conn.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            cari_pelanggan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap");
            }
            else
            {
                SqlConnection conn = con.GetConn();
                cmd = new SqlCommand("insert into Pelanggan values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan");
                refresh_pelanggan();
                bersih();
                atur_tombol(false);
                auto_number();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                button1.Enabled = false;
                atur_tombol(true);
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["Id_Pelanggan"].Value.ToString();
                textBox2.Text = row.Cells["Nama_Pelanggan"].Value.ToString();
                textBox3.Text = row.Cells["Alamat"].Value.ToString();
                textBox4.Text = row.Cells["No_Telepon"].Value.ToString();
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
                cmd = new SqlCommand("update Pelanggan set Nama_Pelanggan = '" + textBox2.Text + "',Alamat = '" + textBox3.Text + "',No_Telepon = '" + textBox4.Text + "' where Id_Pelanggan = '" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil diubah");
                refresh_pelanggan();
                bersih();
                atur_tombol(false);
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
            if (MessageBox.Show("Yakin Ingin Menghapus Data Barang :" + textBox2.Text + "?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                SqlConnection conn = con.GetConn();
                cmd = new SqlCommand("delete from Pelanggan where Id_Pelanggan = '" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Dihapus");
                refresh_pelanggan();
                bersih();
                atur_tombol(false);
                button1.Enabled = true;
                auto_number();
            }
        }
    }
}
