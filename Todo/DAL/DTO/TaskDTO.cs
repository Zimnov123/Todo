using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.DAL.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Task { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public bool IsComplete { get; set; }
    }
}
