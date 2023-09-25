using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Penjualan
{
    class koneksi
    {
        public SqlConnection GetConn()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=LAPTOP-NBFDVNBR;Initial Catalog=Penjualan;Integrated Security=True";
            return con;
        }
    }
}
