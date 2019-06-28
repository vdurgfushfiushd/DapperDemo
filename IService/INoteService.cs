using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IService
{
    public interface INoteService:IGeneralService<Note>
    {
        //获取每个用户的Note
        IEnumerable<Note> GetNote(string Name);

        //查询所有的note和user
        IEnumerable<Note> GetAll();

        //查询指定多条件Note
        IEnumerable<Note> GetNote_Check(string[] arr);

        //删除一个用户及指定的日志
        void DeleteNoteAndUser(string Name);

    }
}
