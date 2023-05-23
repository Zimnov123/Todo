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
        public static void CompleteTask(int iD, int completed)
        {
            try
            {
                TASK status = db.TASKs.First(x => x.Id == iD);
                status.TaskState = completed;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void DeletedTask(int iD, int deleted)
        {
            try
            {
                TASK status = db.TASKs.First(x => x.Id == iD);
                status.TaskState = deleted;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void AppointeTask(int iD, int appointed)
        {
            try
            {
                TASK status = db.TASKs.First(x => x.Id == iD);
                status.TaskState = appointed;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void DeleteTask(int taskID)
        {
                TASK task = db.TASKs.First(x => x.Id == taskID);
                db.TASKs.DeleteOnSubmit(task);
                db.SubmitChanges();
        }
    }
}
