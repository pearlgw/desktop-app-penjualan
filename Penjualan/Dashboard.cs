using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Penjualan
{
    public partial class Dashboard : Form
    {
        public Dashboard(string role)
        {
            InitializeComponent();
            label6.Text = role;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new Home());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
            label3.Text = DateTime.Now.ToLongDateString();
        }
        private Form activeForm = null;
        private void openChildForm(Form ChildForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = ChildForm;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.None;
            ChildForm.TopLevel = false;

            panelUtama.Controls.Add(ChildForm);
            panelUtama.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
            OCF.Text = ChildForm.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new Barang());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new Home());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openChildForm(new pelanggan());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new Admin());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openChildForm(new karyawan());
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            openChildForm(new transaksi());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openChildForm(new Return_Barang());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openChildForm(new Laporan_Penjualan());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            openChildForm(new Laporan_Pengembalian());
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            if(label6.Text == "Karyawan")
            {
                button5.Hide();
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Gudang());
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Pemasok());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
