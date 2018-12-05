using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Point_Of_Sale.Presentation
{
    public partial class formEmployee : Point_Of_Sale.Presentation.Template.formDisplay
    {
        public formEmployee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;

            DAL.Employee employee = new DAL.Employee();
            employee.Search = textBoxSearch.Text;
            proGrid1.DataSource = employee.Select().Tables[0];

        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            formEmlpoyeeNew employeeNew = new formEmlpoyeeNew();
            employeeNew.ShowDialog();
            buttonSearch.PerformClick();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DAL.Employee employee = new DAL.Employee();
            employee.Search = textBoxSearch.Text;
            proGrid1.DataSource = employee.Select().Tables[0];
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (proGrid1.SelectedRows.Count <= 0)
                return;

            formEmployeeEdit employeeEdit = new formEmployeeEdit(Convert.ToInt32(proGrid1.SelectedRows[0].Cells["ColId"].Value));
            employeeEdit.ShowDialog();
            buttonSearch.PerformClick();

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (proGrid1.SelectedRows.Count <= 0)
                return;
            
            DialogResult confurmDelete = MessageBox.Show("Are you sure?", "Confirmation.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (confurmDelete != DialogResult.Yes)
                return;

            DAL.Employee employeeDelete = new DAL.Employee();
            string ids = "";

            for (int i = 0; i < proGrid1.SelectedRows.Count; i++)
            {
                ids += proGrid1.SelectedRows[i].Cells["ColId"].Value.ToString() + ", ";
            }

            ids = ids.Substring(0, ids.Length - 2);

            if (employeeDelete.Delete(ids))
            {
                MessageBox.Show("Data deleted");
                buttonSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(employeeDelete.Error);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DAL.Employee employee = new DAL.Employee();
            employee.Search = textBoxSearch.Text;
            proGrid1.DataSource = employee.Select().Tables[0];
        }
    }
}
