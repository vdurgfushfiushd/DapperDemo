using Dapper;
using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DapperHelper<T> where T:class,IModel
    {
        public static MySqlConnection conn = DbContextFactory.GetMySqlConnection();

        //增删改操作(单个)
        public static int Execute(string sql, T t)
        {
            return conn.Execute(sql,t);
        }

        //增删改操作(批量)
        public static int Execute(string sql, object obj)
        {
            return conn.Execute(sql, obj);
        }

        //根据条件查询符合的集合
        public static IEnumerable<T> GetEntities(string sql, object obj)
        {
            return conn.Query<T>(sql, obj);
        }

        //根据条件查询符合的单个
        public static T GetEntity(string sql, object obj)
        {
            return conn.QuerySingleOrDefault<T>(sql,obj);
        }

       
    }
}
