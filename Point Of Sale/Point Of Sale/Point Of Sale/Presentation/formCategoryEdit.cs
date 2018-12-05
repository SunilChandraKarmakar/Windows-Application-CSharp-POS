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
    public partial class formCategoryEdit : Point_Of_Sale.Presentation.Template.formNew
    {
        ErrorProvider errorProvider = new ErrorProvider();
        DAL.Category category = new Category();

        public formCategoryEdit(int id)
        {
            InitializeComponent();

            LoadCategory();

            category.Id = id;
            if (category.SelectById())
            {
                textBoxName.Text = category.Name;
                textBoxDescription.Text = category.Description;
                comboBoxCategory.SelectedValue = category.CategoryId;
            }
        }

        private void formCategoryEdit_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
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
            if (comboBoxCategory.Text == "")
            {
                error++;
                errorProvider.SetError(comboBoxCategory, "Required");
            }

            if (error > 0)
                return;

            
            category.Name = textBoxName.Text;
            category.Description = textBoxDescription.Text;
            category.CategoryId = Convert.ToInt32(comboBoxCategory.SelectedValue);

            if (category.Update())
            {
                MessageBox.Show("Category is Update.");
                textBoxName.Text = "";
                textBoxDescription.Text = "";
                comboBoxCategory.Text = "";
                textBoxName.Focus();
                LoadCategory();
            }
            else
            {
                MessageBox.Show(category.Error);
            }
        }
    }
}
