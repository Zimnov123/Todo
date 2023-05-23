using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Todo.DAL;
using Todo.BLL;
using Todo.DAL.DTO;

namespace Todo
{
    public partial class FrmAdd : Form
    {
        public FrmAdd()
        {
            InitializeComponent();
        }
        TASK dto = new TASK();
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAdd_Load(object sender, EventArgs e)
        {
            txtTask.Text = dto.Task1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTask.Text.Trim() == "")
                MessageBox.Show("Please fill the task");
            else
            {
                
                TASK task = new TASK();
                    task.Task1 = txtTask.Text;
                task.TaskState = 1;
                
                TaskBLL.AddTask(task);
                MessageBox.Show("Task was added");
                txtTask.Clear();
            }
        }
    }
}
