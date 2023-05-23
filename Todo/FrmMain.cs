using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Todo.DAL.DTO;
using Todo.DAL;
using Todo.BLL;
namespace Todo
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        TaskDTO dto = new TaskDTO();
        TaskBLL bll = new TaskBLL();
        List<TASK> list = new List<TASK>();
        private void Form1_Load(object sender, EventArgs e)
        {
            FillAllData();
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Tasks";
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.DataSource = list;
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            FrmDeleted frm = new FrmDeleted();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            FillAllData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAdd frm = new FrmAdd();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            FillAllData();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dto.ID= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value); 
            dto.Task = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            dto.TaskState = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);           
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            TaskBLL.DeletedTask(dto.ID, TaskStates.Deleted);
            MessageBox.Show("Deleted");
            FillAllData();
        }
        void FillAllData()
        {
            list = TaskBLL.GetTask();
            list = list.Where(x => x.TaskState == 1).ToList();
            dataGridView1.DataSource = list;
        }
        private void btnComplete_Click(object sender, EventArgs e)
        {
            TaskBLL.CompleteTask(dto.ID, TaskStates.Completed);
            MessageBox.Show("Completed");
            FillAllData();
        }
    }
}
