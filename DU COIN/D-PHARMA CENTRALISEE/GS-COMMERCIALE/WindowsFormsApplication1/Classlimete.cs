using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    class Classlimete
    {
        public SqlConnection conlimete = new System.Data.SqlClient.SqlConnection();
        public SqlCommand cmd5 = new SqlCommand();
        public SqlDataAdapter da5 = new SqlDataAdapter();
        public SqlDataReader dr5;
        public DataTable dt5 = new DataTable();
        public void communicationlimete()
        {
            conlimete = new SqlConnection();
            //concoin .ConnectionString = "Data Source= 192.168.0.169,1433; Initial Catalog=GS_ALIMENT; User ID=sa; Password=2025@";
            conlimete.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=GS_ALIMENT;Integrated Security=True";
            try
            {
                if (conlimete.State == ConnectionState.Closed)
                {
                    conlimete.Open();
                }
            }
            catch (Exception zongisa)
            {
                Console.WriteLine(zongisa.Message);
            }
        }
    }
}
