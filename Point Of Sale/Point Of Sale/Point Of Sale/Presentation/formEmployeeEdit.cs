using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Point_Of_Sale.Presentation
{
    public partial class formEmployeeEdit : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        DAL.Employee editEmployee = new DAL.Employee();
        public formEmployeeEdit(int id)
        {
            InitializeComponent();
            
            editEmployee.Id = id;
            if (editEmployee.SelectById())
            {
                textBoxName.Text = editEmployee.Name;
                textBoxContact.Text = editEmployee.Contact;
                textBoxEmail.Text = editEmployee.Email;
                textBoxPassword.Text = editEmployee.Password;
                comboBoxType.Text = editEmployee.Type;
            }
            else
            {
                MessageBox.Show(editEmployee.Error);
            }
        }

        private void formEmployeeEdit_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int error = 0;
            errorProvider.Clear();

            if (textBoxName.Text == "")
            {
                error++;
                errorProvider.SetError(textBoxName, "Required");
            }

            if (textBoxContact.Text == "")
            {
                error++;
                errorProvider.SetError(textBoxContact, "Required");
            }

            if (textBoxEmail.Text == "")
            {
                error++;
                errorProvider.SetError(textBoxEmail, "Required");
            }

            if (textBoxPassword.Text == "")
            {
                error++;
                errorProvider.SetError(textBoxPassword, "Required");
            }

            if (comboBoxType.Text == "")
            {
                error++;
                errorProvider.SetError(comboBoxType, "Required");
            }

            if (error > 0)
                return;

            editEmployee.Name = textBoxName.Text;
            editEmployee.Contact = textBoxContact.Text;
            editEmployee.Email = textBoxEmail.Text;
            editEmployee.Password = textBoxPassword.Text;
            editEmployee.Type = comboBoxType.Text;

            if (editEmployee.Update())
            {
                MessageBox.Show("Employee is Update");
                textBoxName.Text = "";
                textBoxContact.Text = "";
                textBoxEmail.Text = "";
                textBoxPassword.Text = "";
                comboBoxType.Text = "";
                textBoxName.Focus();
            }
            else
            {
                MessageBox.Show(editEmployee.Error);
            }
        }

        private void buttoExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
