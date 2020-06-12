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
        private const string _connectionString = @"Data Source=<hostName>\<instanceName>; Initial Catalog=; User ID=; Password=";
        private static SqlConnection _sqlConnection = new SqlConnection { ConnectionString = _connectionString };

        //using command with parameters
        public static SqlDataReader Query(SqlCommand _command)
        {
             return UseConnection(_command, _ => _.ExecuteReader()) as SqlDataReader;
            
        }

        //using command without parameter
        public static object Query(String command)
        {
            return 0;
        }

        private static object UseConnection(SqlCommand _sqlCommand, Func<SqlCommand, object> _execute)
        {
            
            if (OpenConnection())
            {
                _sqlCommand.Connection = _sqlConnection;
                var _result = _execute(_sqlCommand);
                CloseConnection();
                return _result;
            }
            return null;
        }
        private static bool OpenConnection()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                try
                {
                    _sqlConnection.Open();
                    if (_sqlConnection.State == System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("connection opened successfully");
                        return true;
                    }
                }
                catch (SqlException _sqlException)
                {
                    if (_sqlConnection.State != System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("Failed to open the connection");
                    }
                    throw _sqlException;
                }
            return false;
        }
        private static bool CloseConnection()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Open)
                try
                {
                    _sqlConnection.Close();
                    if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                    {
                        Console.WriteLine("connection closed successfully");
                        return true;
                    }
                }
                catch (SqlException _sqlException)
                {
                    if (_sqlConnection.State != System.Data.ConnectionState.Closed)
                    {
                        Console.WriteLine("Failed to close the connection");
                    }
                    throw _sqlException;
                }
            return false;
        }
    }
}
