using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.DAL.DTO;
using Todo.DAL;

namespace Todo.DAL.DAO
{
    public class TaskDAO : TaskContext
    {
        public static void AddTask(TASK task)
        {
            try
            {
                db.TASKs.InsertOnSubmit(task);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TASK> GetTask()
        {
            return db.TASKs.ToList();
        }
        public static void DeleteTask(int id)
        {
            try
            {
                TASK task = db.TASKs.First(x => x.Id == id);
                db.TASKs.DeleteOnSubmit(task);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
