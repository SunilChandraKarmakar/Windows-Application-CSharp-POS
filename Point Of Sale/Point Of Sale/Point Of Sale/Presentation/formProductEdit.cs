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
    public partial class formProductEdit : Point_Of_Sale.Presentation.Template.formNew
    {
        ErrorProvider errorProvider = new ErrorProvider();
        DAL.Product productEdit = new Product();
        public formProductEdit(int id)
        {
            InitializeComponent();

            DAL.Brand brand = new Brand();
            comboBoxBrand.DataSource = brand.Select().Tables[0];
            comboBoxBrand.DisplayMember = "name";
            comboBoxBrand.ValueMember = "id";
            comboBoxBrand.SelectedValue = -1;

            DAL.Category category = new Category();
            comboBoxCategory.DataSource = category.Select().Tables[0];
            comboBoxCategory.DisplayMember = "name";
            comboBoxCategory.ValueMember = "id";
            comboBoxCategory.SelectedValue = -1;

            productEdit.Id = id;
            if (productEdit.SelectById())
            {
                textBoxName.Text = productEdit.Name;
                textBoxCode.Text = productEdit.Code;
                textBoxDescription.Text = productEdit.Description;
                comboBoxBrand.SelectedValue = productEdit.BrandId;
                comboBoxCategory.SelectedValue = productEdit.CategoryId;
                textBoxPrice.Text = Convert.ToString(productEdit.Price);
            }
            else
            {
                MessageBox.Show(productEdit.Error);
            }
        }

        private void formProductEdit_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
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

            if (textBoxCode.Text == "")
            {
                error++;
                errorProvider.SetError(textBoxCode, "Required");
            }

            if (textBoxDescription.Text == "")
            {
                error++;
                errorProvider.SetError(textBoxDescription, "Required");
            }

            if (comboBoxBrand.Text == "")
            {
                error++;
                errorProvider.SetError(comboBoxBrand, "Required");
            }

            if (comboBoxCategory.Text == "")
            {
                error++;
                errorProvider.SetError(comboBoxCategory, "Required");
            }

            if (textBoxPrice.Text == "")
            {
                error++;
                errorProvider.SetError(textBoxPrice, "Required");
            }

            if (error > 0)
                return;

            productEdit.Name = textBoxName.Text;
            productEdit.Code = textBoxCode.Text;
            productEdit.Description = textBoxDescription.Text;
            productEdit.BrandId = Convert.ToInt32(comboBoxBrand.SelectedValue);
            productEdit.CategoryId = Convert.ToInt32(comboBoxCategory.SelectedValue);
            productEdit.Price = Convert.ToDouble(textBoxPrice.Text);

            if (productEdit.Update())
            {
                MessageBox.Show("Product Save");
                textBoxName.Text = "";
                textBoxCode.Text = "";
                textBoxDescription.Text = "";
                comboBoxBrand.Text = "";
                comboBoxCategory.Text = "";
                textBoxPrice.Text = "";
                textBoxName.Focus();
            }
            else
            {
                MessageBox.Show(productEdit.Error);
            }
        }
    }
}
