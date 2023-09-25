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
    public partial class Splash : Form
    {
        public Splash(string role)
        {
            InitializeComponent();
            label4.Text = role;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 60;
            if(panel2.Width >= 687)
            {
                timer1.Stop();
                Dashboard dsb = new Dashboard(label4.Text);
                dsb.Show();
                this.Hide();
            }
        }
    }
}
