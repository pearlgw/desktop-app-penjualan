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
    public partial class Login : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private DataTable dt;
        private SqlDataAdapter da;

        koneksi con = new koneksi();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = con.GetConn();
            conn.Open();
            cmd = new SqlCommand("select * from Pengguna where Username = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'", conn);
            ds = new DataSet();
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Pengguna");
            da.Fill(dt);

            if (ds.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Role"].ToString() == "admin")
                    {
                        string adm = "Admin";
                        Splash sp = new Splash(adm);
                        sp.Show();
                        this.Hide();
                        //Dashboard dsb = new Dashboard(adm);
                    }
                    else if (dr["Role"].ToString() == "karyawan")
                    {
                        string kw = "Karyawan";
                        this.Hide();
                        //Dashboard dsb = new Dashboard(pt);
                        Splash sp = new Splash(kw);
                        sp.Show();

                    }
                }
            }
            else
            {
                MessageBox.Show("Username / Password Salah !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }
    }
}
