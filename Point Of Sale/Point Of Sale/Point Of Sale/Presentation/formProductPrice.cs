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
    public partial class formProductPrice : Point_Of_Sale.Presentation.Template.formDisplay
    {
        public formProductPrice()
        {
            InitializeComponent();
        }

        private void formProductPrice_Load(object sender, EventArgs e)
        {
            DAL.ProductPrice productPrice = new ProductPrice();
            productPrice.Search = textBoxSearch.Text;
            proGrid1.AutoGenerateColumns = false;
            proGrid1.DataSource = productPrice.Select().Tables[0];
            
            this.MinimumSize = this.Size;
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
           
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            formProductPriceNew productPrice = new formProductPriceNew();
            productPrice.ShowDialog();
            buttonSearch.PerformClick();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DAL.ProductPrice productPrice = new ProductPrice();
            productPrice.Search = textBoxSearch.Text;
            try
            {
                productPrice.ProductId = Convert.ToInt32(comboBoxProduct.SelectedValue);
                productPrice.UnitId = Convert.ToInt32(comboBoxUnit.SelectedValue);
            }
            catch
            {
                
            }

            proGrid1.AutoGenerateColumns = false;
            proGrid1.DataSource = productPrice.Select().Tables[0];
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if(proGrid1.SelectedRows.Count <= 0)
                return;

            formProductPriceEdit productPriceEdit = new formProductPriceEdit(Convert.ToInt32(proGrid1.SelectedRows[0].Cells["ColId"].Value));
            productPriceEdit.ShowDialog();
            buttonSearch.PerformClick();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(proGrid1.SelectedRows.Count <= 0)
                return;

            DialogResult deleteConfrm = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if(deleteConfrm != DialogResult.Yes)
                return;

            DAL.ProductPrice productPrice = new ProductPrice();
            string ids = "";
            for (int i = 0; i < proGrid1.SelectedRows.Count; i++)
            {
                ids += proGrid1.SelectedRows[i].Cells["ColId"].Value.ToString() + ", ";
            }
            ids = ids.Substring(0, ids.Length - 2);

            if (productPrice.Delete(ids))
            {
                MessageBox.Show("Product price is deleted");
                buttonSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(productPrice.Error);
            }

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DAL.ProductPrice productPrice = new ProductPrice();
            productPrice.Search = textBoxSearch.Text;
            proGrid1.AutoGenerateColumns = false;
            proGrid1.DataSource = productPrice.Select().Tables[0];
        }
    }
}
