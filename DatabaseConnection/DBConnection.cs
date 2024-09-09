using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    public class DBConnection
    {
      private static DBConnection _dbconnection;
        private static SqlConnection _connection;
        private string connectionSttring;

        public static DBConnection GetInstance()
        {
            if (_dbconnection == null)
                _dbconnection = new DBConnection();
            return _dbconnection;


        }

        public string ConnectionString
        {
            get
            {
                connectionSttring = ConfigurationManager.AppSettings["connectionString"].ToString();
                return connectionSttring;

            }
        }

        public static SqlConnection GetSqlConnection()
        {
            if (_connection == null)
                _connection = new SqlConnection(GetInstance().ConnectionString);
            return _connection;
        }
      
    }
}
