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
    public partial class formProductNew : Point_Of_Sale.Presentation.Template.formNew
    {
        ErrorProvider errorProvider = new ErrorProvider();
        public formProductNew()
        {
            InitializeComponent();
        }

        private void formProductNew_Load(object sender, EventArgs e)
        {
            DAL.Brand brand = new Brand();
            comboBoxBrand.DataSource = brand.Select().Tables[0];
            comboBoxBrand.DisplayMember = "name";
            comboBoxBrand.ValueMember = "id";
            comboBoxBrand.SelectedValue = -1;
            comboBoxBrand.Text = "-Select Brand";

            DAL.Category category = new Category();
            comboBoxCategory.DataSource = category.Select().Tables[0];
            comboBoxCategory.DisplayMember = "name";
            comboBoxCategory.ValueMember = "id";
            comboBoxCategory.SelectedValue = -1;
            comboBoxCategory.Text = "-Select Category";


            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
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

            if(error > 0)
                return;

            DAL.Product product = new Product();
            product.Name = textBoxName.Text;
            product.Code = textBoxCode.Text;
            product.Description = textBoxDescription.Text;
            product.BrandId = Convert.ToInt32(comboBoxBrand.SelectedValue);
            product.CategoryId = Convert.ToInt32(comboBoxCategory.SelectedValue);
            product.Price = Convert.ToDouble(textBoxPrice.Text);

            if (product.Insert())
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
                MessageBox.Show(product.Error);
            }
        }

        private void comboBoxBrand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
