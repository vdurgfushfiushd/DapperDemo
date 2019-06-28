using IService;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GeneralService<T> : IGeneralService<T> where T : class, IModel
    {
        public int Execute(string sql,T t)
        {
            return DapperHelper<T>.Execute(sql,t);
        }

        public T GetEntity(string sql, object obj)
        {
            return DapperHelper<T>.GetEntity(sql,obj);
        }

        public IEnumerable<T> GetEntities(string sql, object obj)
        {
            return DapperHelper<T>.GetEntities(sql,obj);
        }

        //增删改操作(批量)
        public int Execute(string sql, object obj)
        {
            return DapperHelper<T>.Execute(sql,obj);
        }
    }
}
