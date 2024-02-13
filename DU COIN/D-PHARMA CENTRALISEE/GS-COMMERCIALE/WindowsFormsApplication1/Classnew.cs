using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication1
{
    class Classnew
    {
        public SqlConnection connew = new System.Data.SqlClient.SqlConnection();
        public SqlCommand cmd6 = new SqlCommand();
        public SqlDataAdapter da6 = new SqlDataAdapter();
        public SqlDataReader dr6;
        public DataTable dt6 = new DataTable();
        public void communicationnew()
        {
            connew = new SqlConnection();
            //concoin .ConnectionString = "Data Source= 192.168.0.169,1433; Initial Catalog=GS_ALIMENT; User ID=sa; Password=2025@";
            connew.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=GS_ALIMENT;Integrated Security=True";
            try
            {
                if (connew.State == ConnectionState.Closed)
                {
                    connew.Open();
                }
            }
            catch (Exception talabien_soki_makamu_eza_bien)
            {
                Console.WriteLine(talabien_soki_makamu_eza_bien.Message);
            }
        }
    }
}
