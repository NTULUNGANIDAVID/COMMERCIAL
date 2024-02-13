using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication1
{
    class Seconnecter
    {
        public SqlConnection con = new System.Data.SqlClient.SqlConnection();
        public SqlCommand cmd, cmd1, cmd2, cmd3, cmd4 = new SqlCommand();
        public SqlDataAdapter da, da1, da2, da3 = new SqlDataAdapter();
        public SqlDataReader dr, dr1, dr2;
        public DataTable dt, dt1, dt2= new DataTable ();
        public DataSet ds, ds1 = new DataSet();
        public void communication()
        {
              con = new SqlConnection();
             //con.ConnectionString = "Data Source= 192.168.2.254,1433; Initial Catalog=GS_ALIMENT; User ID=sa; Password=2025@";
             con.ConnectionString ="Data Source=.\\SQLEXPRESS;Initial Catalog=GS_ALIMENT;Integrated Security=True";
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (Exception message)
            {
                Console.WriteLine(message.Message);
            }
        }
    }
}
