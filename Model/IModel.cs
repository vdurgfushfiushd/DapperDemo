using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IModel
    {
        long Id { get; set; }
        //删除标记
        bool IsDeleted { get; set; }
    }
}
