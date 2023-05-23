using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.DAL.DTO;
using Todo.DAL;
using Todo.DAL.DAO;
namespace Todo.BLL
{
    public class TaskBLL
    {
        public static void AddTask(TASK task)
        {
            TaskDAO.AddTask(task);
        }

        public static List<TASK> GetTask()
        {           
            return TaskDAO.GetTask();
        }
        public static void DeletedTask(int taskID, int deleted)
        {
            TaskDAO.DeletedTask(taskID, deleted);
        }
        public static void AppointeTask(int taskID, int appointed)
        {
            TaskDAO.AppointeTask(taskID, appointed);
        }
        public static void DeleteTask(int taskID)
        {
            TaskDAO.DeleteTask(taskID);
        }

        public static void CompleteTask(int iD, int completed)
        {
            TaskDAO.CompleteTask(iD, completed);
        }
    }
}