using Dapper;
using IService;
using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class NoteService:GeneralService<Note>,INoteService
    {
        //获取指定用户的Note(多表连接操作)
        public IEnumerable<Note> GetNote(string Name)
        {
            string sql = "select * from t_notes as note left join t_users as user on note.User_Id=user.Id where user.Name=@Name";
            //var conn = DapperHelper<Note>.conn;
            var conn = DbContextFactory.GetMySqlConnection();
            var result = conn.Query<Note>(sql,new {Name=Name });
            var result2 = conn.Query<User>(sql, new { Name = Name });
            var result3 = conn.Query(sql, new { Name = Name });
            return result;
        }

        //查询所有的note和user
        public IEnumerable<Note> GetAll()
        {
            string sql = "select * from t_users;select * from t_notes";
            //var conn = DapperHelper<Note>.conn;
            var conn = DbContextFactory.GetMySqlConnection();
            var multiReader = conn.QueryMultiple(sql);
            var userList = multiReader.Read<User>();
            var noteList = multiReader.Read<Note>();
            return noteList;
        }

        //查询指定多条件Note
        public IEnumerable<Note> GetNote_Check(string[] arr)
        {
            string sql="select * from t_notes where Name in @Name";
            return DapperHelper<Note>.GetEntities(sql,new { Name = arr });
        }

        //删除一个用户及指定的日志
        public void DeleteNoteAndUser(string Name)
        {
            using (MySqlConnection conn = DbContextFactory.GetMySqlConnection())
            using (IDbTransaction tx = conn.BeginTransaction())
            {
                try
                {
                    string sql1 = "select * from t_users where Name=@Name";
                    User user = DapperHelper<User>.GetEntity(sql1, new { Name = Name });
                    string sql2 = "delete from t_users where Id=@Id";
                    DapperHelper<User>.Execute(sql2, user);
                    string sql3 = "delete from t_notes where User_Id=@User_Id";
                    DapperHelper<Note>.Execute(sql3, new { User_Id = user.Id });
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception(ex.Message);
                }
            }     
        }
    }
}
