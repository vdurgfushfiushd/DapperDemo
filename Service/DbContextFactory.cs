using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DbContextFactory
    {
        public static MySqlConnection conn;

        //连接字符串
        private static readonly string connstr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        
        public static MySqlConnection GetMySqlConnection()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
            }
            return conn;
        }
    }
}
