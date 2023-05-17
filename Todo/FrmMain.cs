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
            list = TaskBLL.GetTask();
            dataGridView1.DataSource = list;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Tasks";
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAdd frm = new FrmAdd();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            list = TaskBLL.GetTask();
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dto.Task = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
