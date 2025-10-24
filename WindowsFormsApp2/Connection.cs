using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class Connection
    {
        private const string ConnectionString = @"Data Source=MYPCPRO;Initial Catalog=loremipsum; Integrated Security=True; TrustServerCertificate=True";
        public static SqlConnection GetConnection()
        {
            SqlConnection conection = new SqlConnection(ConnectionString);
            return conection;
        }
    }
}
