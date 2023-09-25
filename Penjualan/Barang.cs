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
    public partial class Barang : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        koneksi con = new koneksi();
        public Barang()
        {
            InitializeComponent();
            Bersih();
            Atur_Tombol(false);
            tampil();
            auto_number();
        }

        void Bersih()
        {
            //textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "";
            comboBox1.Text = "- Pilih Satuan - ";
        }

        void Atur_Tombol(Boolean Status)
        {
            button2.Enabled = Status;
            button3.Enabled = Status;
        }

        // prosedur tampilan barang
        void tampil()
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
            catch(Exception e)
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
            cmd = new SqlCommand("select Kode_Barang from Barang where Kode_Barang in (select max(Kode_Barang) from Barang) order by Kode_Barang desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["Kode_Barang"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + hitung;
                urut = "BRG" + joinstr.Substring(joinstr.Length - 3, 3);
            }
            else
            {
                urut = "BRG001";
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
                cmd = new SqlCommand("select * from Barang where Kode_Barang like '%"+textBox5.Text+"%' or Nama_Barang like'%"+textBox5.Text+"%'", conn);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim()=="" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap");
            }
            else
            {
                SqlConnection conn = con.GetConn();
                cmd = new SqlCommand("insert into Barang(Kode_Barang, Nama_Barang, Harga, Stok, Satuan) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan");
                tampil();
                Bersih();
                Atur_Tombol(false);
                auto_number();
            }
        }

        private void Barang_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bersih();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = con.GetConn();
               try
                {
                    cmd = new SqlCommand("update Barang set Nama_Barang = '"+textBox2.Text+ "',Harga = '" + textBox3.Text + "',Stok = '" + textBox4.Text + "',Satuan = '" + comboBox1.Text + "' where Kode_Barang = '"+textBox1.Text+"'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil diubah");
                    tampil();
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
            if (MessageBox.Show("Yakin Ingin Menghapus Data Barang :" +textBox2.Text+ "?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information)== DialogResult.Yes)
            {
                SqlConnection conn = con.GetConn();
                    cmd = new SqlCommand("delete from Barang where Kode_Barang = '"+textBox1.Text+"'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Dihapus");
                    tampil();
                    Bersih();
                    Atur_Tombol(false);
                    button1.Enabled = true;
                auto_number();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            cari_barang();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                button1.Enabled = false;
                Atur_Tombol(true);
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["Kode_Barang"].Value.ToString();
                textBox2.Text = row.Cells["Nama_Barang"].Value.ToString();
                textBox3.Text = row.Cells["Harga"].Value.ToString();
                textBox4.Text = row.Cells["Stok"].Value.ToString();
                comboBox1.Text = row.Cells["Satuan"].Value.ToString();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
