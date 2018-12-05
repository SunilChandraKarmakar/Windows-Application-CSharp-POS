using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace Point_Of_Sale.Presentation
{
    public partial class formCategoryNew : Point_Of_Sale.Presentation.Template.formNew
    {
        ErrorProvider errorProvider = new ErrorProvider();
        public formCategoryNew()
        {
            InitializeComponent();
        }

        private void formCategoryNew_Load(object sender, EventArgs e)
        {
            LoadCategory();

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void LoadCategory()
        {
            DAL.Category category = new Category();
            comboBoxCategory.DataSource = category.Select().Tables[0];
            comboBoxCategory.DisplayMember = "name";
            comboBoxCategory.ValueMember = "id";
            comboBoxCategory.SelectedValue = -1;
            comboBoxCategory.Text = "-Select Category";
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

            if (textBoxDescription.Text == "")
            {
                error++;
                errorProvider.SetError(textBoxDescription, "Required");
            }

            if(error > 0)
                return;

            DAL.Category category = new Category();
            category.Name = textBoxName.Text;
            category.Description = textBoxDescription.Text;
            category.CategoryId = Convert.ToInt32(comboBoxCategory.SelectedValue);

            if (category.Insert())
            {
                MessageBox.Show("Category Is Save");
                textBoxName.Text = "";
                textBoxDescription.Text = "";
                comboBoxCategory.Text = "";
                textBoxName.Focus();
                comboBoxCategory.SelectedValue = -1;
                LoadCategory();
            }
            else
            {
                MessageBox.Show(category.Error);
            }
        }
    }
}
