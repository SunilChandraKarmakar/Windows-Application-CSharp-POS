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
    public partial class formProductPriceNew : Point_Of_Sale.Presentation.Template.formNew
    {
        ErrorProvider errorProvider = new ErrorProvider();
        public formProductPriceNew()
        {
            InitializeComponent();
        }

        private void formProductPriceNew_Load(object sender, EventArgs e)
        {
            DAL.Product product = new Product();
            comboBoxProduct.DataSource = product.Select().Tables[0];
            comboBoxProduct.DisplayMember = "name";
            comboBoxProduct.ValueMember = "id";
            comboBoxProduct.SelectedValue = -1;
            comboBoxProduct.Text = "-Select Product";

            DAL.Unit unit = new Unit();
            comboBoxUnit.DataSource = unit.Select().Tables[0];
            comboBoxUnit.DisplayMember = "name";
            comboBoxUnit.ValueMember = "primaryQty";
            comboBoxUnit.SelectedValue = -1;
            comboBoxUnit.Text = "-Select Unit";
           

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int error = 0;
            errorProvider.Clear();

            if (comboBoxProduct.Text == "")
            {
                error++;
                errorProvider.SetError(comboBoxProduct, "Required");
            }

            if (comboBoxUnit.Text == "")
            {
                error++;
                errorProvider.SetError(comboBoxUnit, "Required");
            }

            if (textBoxPrice.Text == "")
            {
                error++;
                errorProvider.SetError(textBoxPrice, "Required");
            }

            if(error > 0)
                return;

            DAL.ProductPrice productPrice = new ProductPrice();
            productPrice.ProductId = Convert.ToInt32(comboBoxProduct.SelectedValue);
            productPrice.UnitId = Convert.ToInt32(comboBoxUnit.SelectedValue);
            productPrice.Price = Convert.ToDouble(textBoxPrice.Text);

            if (productPrice.Insert())
            {
                MessageBox.Show("Product price is save");
                comboBoxProduct.Text = "";
                comboBoxUnit.Text = "";
                textBoxPrice.Text = "";
                comboBoxProduct.Focus();
                comboBoxProduct.SelectedValue = -1;
                comboBoxUnit.SelectedValue = -1;
            }

            else
            {
                MessageBox.Show(productPrice.Error);
            }
        }
    }
}
