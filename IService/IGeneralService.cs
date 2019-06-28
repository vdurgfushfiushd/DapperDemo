using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IService
{
    public interface IGeneralService<T> where T:class,IModel
    {
        //增删改操作(单个)
        int Execute(string sql,T t);

        T GetEntity(string sql, object obj);

        IEnumerable<T> GetEntities(string sql,object obj);

        //增删改操作(批量)
        int Execute(string sql, object obj);
    }
}
