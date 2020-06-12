using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Data
{
    public class Utility
    {
        //Data Source=MYPC;User ID=sa;Password=********;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        private const string _connectionString = @"Data Source=MYPC; Initial Catalog=warehouse; User ID=sa; Password=p@ssw0rd";
        private static SqlConnection _sqlConnection = new SqlConnection { ConnectionString = _connectionString };

        //using command with parameters
        public static SqlDataReader Query(SqlCommand _command)
        {
            try
            {
                return UseConnection(_command, _ => _.ExecuteReader(System.Data.CommandBehavior.CloseConnection)) as SqlDataReader;
            }
            catch(SqlException e)
            {
                return null;
            }
            
            
        }

        //using command without parameter
        public static object Query(String command)
        {
            return 0;
        }

        private static object UseConnection(SqlCommand _sqlCommand, Func<SqlCommand, object> _execute)
        {
            OpenConnection();
            if (_sqlConnection.State==System.Data.ConnectionState.Open)
            {
                _sqlCommand.Connection = _sqlConnection;
                var _result = _execute(_sqlCommand);
                //CloseConnection();
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
        public static bool CloseConnection()
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
