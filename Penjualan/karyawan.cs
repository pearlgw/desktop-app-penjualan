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
    public partial class karyawan : Form
    {
        public karyawan()
        {
            InitializeComponent();
            Bersih();
            Atur_Tombol(false);
            refresh_barang();
            auto_number();
        }

        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        koneksi con = new koneksi();

        void Bersih()
        {
            //textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        void Atur_Tombol(Boolean Status)
        {
            button2.Enabled = Status;
            button3.Enabled = Status;
        }

        // prosedur tampilan barang
        void refresh_barang()
        {
            SqlConnection conn = con.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from Pengguna where Role = 'karyawan'", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Pengguna");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Pengguna";
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
            cmd = new SqlCommand("select Kode_User from Pengguna where Kode_User in (select max(Kode_User) from Pengguna) order by Kode_User desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["Kode_User"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + hitung;
                urut = "KRYWN" + joinstr.Substring(joinstr.Length - 3, 3);
            }
            else
            {
                urut = "K001";
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
                cmd = new SqlCommand("select * from Pengguna where Kode_User like '%" + textBox5.Text + "%' or Nama like'%" + textBox5.Text + "%'", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Pengguna");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Pengguna";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap");
            }
            else
            {
                SqlConnection conn = con.GetConn();
                cmd = new SqlCommand("insert into Pengguna values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "', 'karyawan')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan");
                refresh_barang();
                Bersih();
                Atur_Tombol(false);
                auto_number();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = con.GetConn();
            try
            {
                cmd = new SqlCommand("update Pengguna set Nama = '" + textBox2.Text + "',Username = '" + textBox3.Text + "',Password = '" + textBox4.Text + "',Alamat = '" + textBox6.Text + "' where Kode_User = '" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil diubah");
                refresh_barang();
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
            if (MessageBox.Show("Yakin Ingin Menghapus Data Admin :" + textBox2.Text + "?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                SqlConnection conn = con.GetConn();
                cmd = new SqlCommand("delete from Pengguna where Kode_User = '" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Dihapus");
                refresh_barang();
                Bersih();
                Atur_Tombol(false);
                button1.Enabled = true;
                auto_number();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            cari_barang();
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
                textBox1.Text = row.Cells["Kode_User"].Value.ToString();
                textBox2.Text = row.Cells["Nama"].Value.ToString();
                textBox3.Text = row.Cells["Username"].Value.ToString();
                textBox4.Text = row.Cells["Password"].Value.ToString();
                textBox6.Text = row.Cells["Alamat"].Value.ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }
    }
}
