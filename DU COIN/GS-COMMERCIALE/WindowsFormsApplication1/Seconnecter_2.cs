using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication1
{
    class Seconnecter_2
    {
        public SqlConnection con = new System.Data.SqlClient.SqlConnection();
        public SqlCommand cmd5 = new SqlCommand();
        public SqlCommand cmd6 = new SqlCommand();
        public SqlDataAdapter da3 = new SqlDataAdapter();
        public SqlDataAdapter da4 = new SqlDataAdapter();
        public SqlDataReader dr3;
        public SqlDataReader dr4;
        public DataTable dt3 = new DataTable();
        public DataTable dt4 = new DataTable();
        public void communication()
        {
            con = new SqlConnection();
            //con.ConnectionString = "Data Source= 192.168.0.169,1433; Initial Catalog=GS_ALIMENT; User ID=sa; Password=2025@";
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (Exception zongisa)
            {
                Console.WriteLine(zongisa.Message);
            }
        }
    }
}
