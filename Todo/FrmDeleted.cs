using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Todo.BLL;
using Todo.DAL;
using Todo.DAL.DTO;

namespace Todo
{
    public partial class FrmDeleted : Form
    {
        TaskDTO dto = new TaskDTO();
        List<TASK> list = new List<TASK>();
        public FrmDeleted()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TaskBLL.DeleteTask(dto.ID);
            MessageBox.Show("Task was deleted");
            FillAllData();
        }

        private void FrmDeleted_Load(object sender, EventArgs e)
        {            
            FillAllData();
            int numRows = dataGridView1.Rows.Count;
            if (numRows > 10)
            {
                TaskBLL.DeleteTask(dto.ID);
            }
            FillAllData();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Tasks";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True; 
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dto.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            dto.Task = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            dto.TaskState = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            TaskBLL.AppointeTask(dto.ID, TaskStates.Appointed);
            MessageBox.Show("Appointed");
            FillAllData();
        }
        void FillAllData()
        {
            list = TaskBLL.GetTask();
            list = list.Where(x => x.TaskState > 1).ToList();
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int is_Completed = Convert.ToInt32(row.Cells[2].Value);
                if (is_Completed == 3)
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }
    }
}
