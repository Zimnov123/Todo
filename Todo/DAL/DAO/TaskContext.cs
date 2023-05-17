using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.DAL;

namespace Todo.DAL.DAO
{
    public class TaskContext
    {
        public static TaskDataClassDataContext db = new TaskDataClassDataContext();
    }
}
