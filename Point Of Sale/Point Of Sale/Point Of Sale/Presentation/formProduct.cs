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
    public partial class formProduct : Point_Of_Sale.Presentation.Template.formDisplay
    {
        public formProduct()
        {
            InitializeComponent();
        }

        private void formProduct_Load(object sender, EventArgs e)
        {
            DAL.Product product = new Product();
            product.Search = textBoxSearch.Text;
            product.BrandId = Convert.ToInt32(comboBoxBrand.SelectedValue);
            product.CategoryId = Convert.ToInt32(comboBoxCategory.SelectedValue);

            product.IsDateSearch = ucDateSearch1.IsEnabled;
            product.DateFrom = ucDateSearch1.DateFrom;
            product.DateTo = ucDateSearch1.DateTo;

            proGrid1.DataSource = product.Select().Tables[0];


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

            this.MinimumSize = this.Size;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            formProductNew productNew = new formProductNew();
            productNew.ShowDialog();
            buttonSearch.PerformClick();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DAL.Product product = new Product();
            product.Search = textBoxSearch.Text;
            product.BrandId = Convert.ToInt32(comboBoxBrand.SelectedValue);
            product.CategoryId = Convert.ToInt32(comboBoxCategory.SelectedValue);

            product.IsDateSearch = ucDateSearch1.IsEnabled;
            product.DateFrom = ucDateSearch1.DateFrom;
            product.DateTo = ucDateSearch1.DateTo;
            
            proGrid1.DataSource = product.Select().Tables[0];
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if(proGrid1.SelectedRows.Count <= 0)
                return;

            formProductEdit productEdit = new formProductEdit(Convert.ToInt32(proGrid1.SelectedRows[0].Cells["ColId"].Value));
            productEdit.ShowDialog();
            buttonSearch.PerformClick();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(proGrid1.SelectedRows.Count <= 0)
                return;

            DialogResult deletePro = MessageBox.Show("Are you sure?", "Comfirmation.", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if(deletePro != DialogResult.Yes)
                return;

            DAL.Product productDelete = new Product();

            string ids = "";

            for (int i = 0; i < proGrid1.SelectedRows.Count; i++)
            {
                ids += proGrid1.SelectedRows[i].Cells["ColId"].Value.ToString() + ", ";
            }

            ids = ids.Substring(0, ids.Length - 2);

            if (productDelete.Delete(ids))
            {
                MessageBox.Show("Product is delete.");
                buttonSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(productDelete.Error);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DAL.Product product = new Product();
            product.Search = textBoxSearch.Text;
            product.BrandId = Convert.ToInt32(comboBoxBrand.SelectedValue);
            product.CategoryId = Convert.ToInt32(comboBoxCategory.SelectedValue);

            product.IsDateSearch = ucDateSearch1.IsEnabled;
            product.DateFrom = ucDateSearch1.DateFrom;
            product.DateTo = ucDateSearch1.DateTo;

            proGrid1.DataSource = product.Select().Tables[0];
        }
    }
}
