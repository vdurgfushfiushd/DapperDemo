using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User:IModel
    {
        //主键
        public long Id { get; set; }
        //名字
        public string Name { get; set; }
        //创建时间
        public DateTime CreateTime { get; set; } = DateTime.Now;
        //删除标记
        public bool IsDeleted { get; set; } = false;
        //密码
        public string Password { get; set; }
    }
}
