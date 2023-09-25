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
    public partial class Return_Barang : Form
    {
        public Return_Barang()
        {
            InitializeComponent();
        }

        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader dr;

        koneksi con = new koneksi();

        private void button1_Click(object sender, EventArgs e)
        {
            Dialog_Pengembalian dp = new Dialog_Pengembalian();
            dp.ShowDialog();
            Nokwitansi.Text = dp.ambil_No_Kwitansi;
            Kodebarang.Text = dp.ambil_Kode_Barang;
            namabarang.Text = dp.ambil_Nama_Barang;
            harga.Text = dp.ambil_Harga;
            satuan.Text = dp.ambil_Satuan;
            textBox7.Text = dp.ambil_Jumlah;
        }
        void auto_number()
        {
            long hitung;
            string urut;
            SqlDataReader rd;
            SqlConnection conn = con.GetConn();
            conn.Open();
            cmd = new SqlCommand("select ID_Pengembalian from pengembalian where ID_Pengembalian in (select max(ID_Pengembalian) from pengembalian) order by ID_Pengembalian desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["ID_Pengembalian"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + hitung;
                urut = "PB" + joinstr.Substring(joinstr.Length - 3, 3);
            }
            else
            {
                urut = "PB001";
            }
            rd.Close();
            IDpengembalian.Enabled = false;
            IDpengembalian.Text = urut;
            conn.Close();
        }
        void clear()
        {
            Nokwitansi.ReadOnly = true;
            Kodebarang.ReadOnly = true;
            namabarang.ReadOnly = true;
            harga.ReadOnly = true;
            satuan.ReadOnly = true;
            textBox7.ReadOnly = true;
            Nokwitansi.Clear();
            Kodebarang.Clear();
            namabarang.Clear();
            harga.Clear();
            satuan.Clear();
            textBox7.Clear();
        }
        void dg()
        {
            SqlConnection conn = con.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from Pengembalian order by Id_Pengembalian DESC", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "pengembalian");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "pengembalian";
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

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Yakin mengembalikan ini?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection conn = con.GetConn();
                conn.Open();
                cmd = new SqlCommand("insert into pengembalian values ('" + IDpengembalian.Text + "','" + Nokwitansi.Text + "','" + Kodebarang.Text + "','" + namabarang.Text + "','" + harga.Text + "','"+satuan.Text+"','"+tanggalkembali.Text+"')", conn);
                cmd = new SqlCommand("delete from Detail_Penjualan where No_Kwitansi = '" + Kodebarang.Text + "'",conn);
                MessageBox.Show("Berhasil mengembalikan barang");
                clear();
                dg();
                conn.Close();
            }
            else
            {
                clear();
            }
        }
       
        private void Return_Barang_Load(object sender, EventArgs e)
        {
            dg();
            auto_number();
        }
    }
}
