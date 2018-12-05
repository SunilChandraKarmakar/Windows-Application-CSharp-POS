using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Point_Of_Sale.Presentation
{
    public partial class formEmlpoyeeNew : Point_Of_Sale.Presentation.Template.formNew
    {
        ErrorProvider errorProvider = new ErrorProvider();
        public formEmlpoyeeNew()
        {
            InitializeComponent();
        }

        private void formEmlpoyeeNew_Load(object sender, EventArgs e)
        {
            comboBoxType.Text = "-Select Type";

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

            if(error > 0)
                return;

            DAL.Employee employee = new DAL.Employee();
            employee.Name = textBoxName.Text;
            employee.Contact = textBoxContact.Text;
            employee.Email = textBoxEmail.Text;
            employee.Password = textBoxPassword.Text;
            employee.Type = comboBoxType.Text;

            if (employee.Insert())
            {
                MessageBox.Show("Employee is save");
                textBoxName.Text = "";
                textBoxContact.Text = "";
                textBoxEmail.Text = "";
                textBoxPassword.Text = "";
                comboBoxType.Text = "";
                textBoxName.Focus();
            }

            else
            {
                MessageBox.Show(employee.Error);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {

        }
    }
}
