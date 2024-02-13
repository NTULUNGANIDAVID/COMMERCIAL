using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication1
{
    class Classbeatrice
    {
        public SqlConnection conbeatrice = new System.Data.SqlClient.SqlConnection();
        public SqlCommand cmd7 = new SqlCommand();
        public SqlDataAdapter da7 = new SqlDataAdapter();
        public SqlDataReader dr7;
        public DataTable dt7 = new DataTable();
        public void communicationbeatrice()
        {
            conbeatrice = new SqlConnection();
            //concoin .ConnectionString = "Data Source= 192.168.0.169,1433; Initial Catalog=GS_ALIMENT; User ID=sa; Password=2025@";
            conbeatrice.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=GS_ALIMENT;Integrated Security=True";
            try
            {
                if (conbeatrice.State == ConnectionState.Closed)
                {
                    conbeatrice.Open();
                }
            }
            catch (Exception lukananu)
            {
                Console.WriteLine(lukananu.Message);
            }
        }
    }
}
