using IService;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserService userService = new UserService();

            INoteService noteService = new NoteService();

            string sql = "select * from t_users";

            var _user = userService.GetEntities(sql,null);

            var xx = noteService.GetAll();

            var list = noteService.GetNote("关羽");

            var ck_list = noteService.GetNote_Check(new string[] {"战斗","生活" });

            noteService.DeleteNoteAndUser("诸葛亮");

            if (_user != null)
            {
                Console.WriteLine("ok");
            }
            else
            {
                Console.WriteLine("fail");
            }

            Console.ReadKey();
        }
    }
}
