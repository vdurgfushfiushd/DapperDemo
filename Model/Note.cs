using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Note: IModel
    {
        //主键
        public long Id { get; set; }
        //笔记名字
        public string Name { get; set; }
        //笔记内容
        public string Detail { get; set; }
        //创建时间
        public DateTime CreateTime { get; set; } = DateTime.Now;
        //删除标记
        public bool IsDeleted { get; set; } = false;
        //笔记作者id
        public long User_Id { get; set; }

        public virtual User users { get; set; }
    }
}
