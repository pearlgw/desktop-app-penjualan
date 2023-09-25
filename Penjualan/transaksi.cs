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
    public partial class transaksi : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader dr;

        koneksi con = new koneksi();
        public transaksi()
        {
            InitializeComponent();
            awal();
            auto_number();
        }

        private void bersih()
        {
            textBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            button6.Enabled = false;
            button4.Enabled = false;
        }

        public void awal()
        {
            bersih();
            SqlConnection conn = con.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from View_penjualan order by No_Kwitansi DESC", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "View_penjualan");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "View_penjualan";
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
            groupBox3.Enabled = false;
        }

        void auto_number()
        {
            long hitung;
            string urut;
            SqlDataReader rd;
            SqlConnection conn = con.GetConn();
            conn.Open();
            cmd = new SqlCommand("select No_Kwitansi from Penjualan where No_Kwitansi in (select max(No_Kwitansi) from Penjualan) order by No_Kwitansi desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["No_Kwitansi"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + hitung;
                urut = "TRX" + joinstr.Substring(joinstr.Length - 3, 3);
            }
            else
            {
                urut = "TRX0001" ;
            }
            rd.Close();
            textBox1.Enabled = false;
            textBox1.Text = urut;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dialog_Pelanggan plgn = new Dialog_Pelanggan();
            plgn.ShowDialog();
            textBox2.Text = plgn.ambil_ID_pelanggan;
            textBox3.Text = plgn.ambil_nama_pelanggan;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dialog_Barang brg = new Dialog_Barang();
            brg.ShowDialog();
            textBox4.Text = brg.ambil_kode_Barang;
            textBox5.Text = brg.ambil_nama_Barang;
            textBox6.Text = brg.Harga;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            awal();
            auto_number();
            dateTimePicker1.Focus();
            button1.Enabled = true;
        }

        void simpan_Penjualan()
        {
            SqlConnection conn = con.GetConn();
            {
                cmd = new SqlCommand("insert into Penjualan values('" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + textBox2.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        void simpan_detailPenjualan()
        {
            SqlConnection conn = con.GetConn();
            {
                cmd = new SqlCommand("insert into Detail_Penjualan values('" + textBox1.Text + "','" + textBox4.Text + "','" + textBox7.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        void refresh_penjualan()
        {
            SqlConnection conn = con.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from View_Detail where No_Kwitansi = '"+textBox1.Text+"'", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "View_Detail");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "View_Detail";
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
        void RefreshTransaksi()
        {
            refresh_penjualan();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox7.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataReader reader = null;
            SqlConnection conn = con.GetConn();
            {
                if(textBox1.Text.Trim() == "" || textBox2.Text.Trim() == ""|| textBox4.Text.Trim() == ""|| textBox7.Text.Trim() == "")
                {
                    MessageBox.Show("Data Belum Lengkap, lengkapi data");
                }
                else
                {
                    conn.Open();
                    cmd = new SqlCommand("select * from Penjualan where No_Kwitansi = '" + textBox1.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        simpan_detailPenjualan();
                        Total_Seluruh();
                    }
                    else
                    {
                        simpan_Penjualan();
                        simpan_detailPenjualan();
                        Total_Seluruh();
                    }
                    button1.Enabled = false;
                    button6.Enabled = true;
                    groupBox3.Enabled = true;
                    RefreshTransaksi();
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Enabled = false;
            button4.Enabled = true;
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            textBox4.Text = row.Cells["Kode_Barang"].Value.ToString();
            textBox5.Text = row.Cells["Nama_Barang"].Value.ToString();
            textBox6.Text = row.Cells["Harga"].Value.ToString();
            textBox7.Text = row.Cells["Jumlah"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = con.GetConn();
            {
                cmd = new SqlCommand("delete from Detail_Penjualan where No_Kwitansi = '" + textBox1.Text + "' AND Kode_Barang = '" + textBox4.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                RefreshTransaksi();
                button3.Enabled = true;
                button4.Enabled = false;
            }
        }

        void Total_Seluruh()
        {
            SqlConnection conn = con.GetConn();
            {
                conn.Open();
                cmd = new SqlCommand("select sum(harga*jumlah) as JumlahBayar from View_Detail where No_Kwitansi = '" + textBox1.Text + "'", conn);
                cmd.ExecuteNonQuery();
                cmd.Connection = conn;
                int result = ((int)cmd.ExecuteScalar());
                String TotalSeluruh = result.ToString();
                label9.Text = result.ToString();
                conn.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Transaksi selesai");
            awal();
            label9.Text = "0";
            button1.Enabled = true;
            auto_number();
        }

        private void transaksi_Load(object sender, EventArgs e)
        {
            auto_number();
        }
    }
}
