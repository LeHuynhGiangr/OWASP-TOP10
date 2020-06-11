using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Data
{
    class Utility
    {
        private const string connectionString = @"Data Source=<hostName>\<instanceName>; Initial Catalog=; User ID=; Password=";
        private SqlConnection sqlConnection = new SqlConnection { ConnectionString = connectionString };

        //using command with parameters
        public static object Query(SqlCommand command)
        {
            try
            {
                
            }
            catch(SqlException sqlException)
            {

            }
            return 0;
        }

        //using command without parameter
        public static object Query(String command)
        {
            return 0;
        }
    }
}
