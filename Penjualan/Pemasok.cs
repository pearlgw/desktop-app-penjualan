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
    public partial class Pemasok : Form
    {
        public Pemasok()
        {
            InitializeComponent();
            Bersih();
            Atur_Tombol(false);
            refresh_pemasok();
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
        }

        void Atur_Tombol(Boolean Status)
        {
            button2.Enabled = Status;
            button3.Enabled = Status;
        }

        // prosedur tampilan barang
        void refresh_pemasok()
        {
            SqlConnection conn = con.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from Pemasok", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Pemasok");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Pemasok";
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
            cmd = new SqlCommand("select Kode_Pemasok from Pemasok where Kode_Pemasok in (select max(Kode_Pemasok) from Pemasok) order by Kode_Pemasok desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["Kode_Pemasok"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + hitung;
                urut = "PMSK" + joinstr.Substring(joinstr.Length - 3, 3);
            }
            else
            {
                urut = "PMSK001";
            }
            rd.Close();
            textBox1.Enabled = false;
            textBox1.Text = urut;
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                button1.Enabled = false;
                Atur_Tombol(true);
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["Kode_Pemasok"].Value.ToString();
                textBox2.Text = row.Cells["Nama_Pemasok"].Value.ToString();
                textBox3.Text = row.Cells["Alamat"].Value.ToString();
                textBox4.Text = row.Cells["No_Telp"].Value.ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
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
                cmd = new SqlCommand("insert into Pemasok values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan");
                refresh_pemasok();
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
                cmd = new SqlCommand("update Pemasok set Nama_Pemasok = '" + textBox2.Text + "',Alamat = '" + textBox3.Text + "', No_Telp = '" + textBox4.Text + "' where Kode_Pemasok = '" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil diubah");
                refresh_pemasok();
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
            if (MessageBox.Show("Yakin Ingin Menghapus Data Pemasok :" + textBox2.Text + "?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                SqlConnection conn = con.GetConn();
                cmd = new SqlCommand("delete from Pemasok where Kode_Pemasok = '" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Dihapus");
                refresh_pemasok();
                Bersih();
                Atur_Tombol(false);
                button1.Enabled = true;
                auto_number();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bersih();
        }
    }
}
