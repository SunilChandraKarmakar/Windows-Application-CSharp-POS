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
    public partial class formProductImage : Point_Of_Sale.Presentation.Template.formDisplay
    {
        public formProductImage()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DAL.ProductImage productImage = new ProductImage();
            productImage.Search = textBoxSearch.Text;

            try
            {
                productImage.ProductId = Convert.ToInt32(comboBoxProduct.SelectedValue);
            }
            catch (Exception)
            {
                
                
            }

            proGrid1.DataSource = productImage.Select().Tables[0];
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            formProductImageNew productImageNew = new formProductImageNew();
            productImageNew.ShowDialog();
            buttonSearch.PerformClick();
        }

        private void formProductImage_Load(object sender, EventArgs e)
        {
            DAL.ProductImage productImage = new ProductImage();
            productImage.Search = textBoxSearch.Text;
            proGrid1.DataSource = productImage.Select().Tables[0];
            
            DAL.Product product = new Product();
            comboBoxProduct.DataSource = product.Select().Tables[0];
            comboBoxProduct.DisplayMember = "name";
            comboBoxProduct.ValueMember = "id";
            comboBoxProduct.SelectedValue = -1;

            this.MinimumSize = this.Size;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if(proGrid1.SelectedRows.Count <= 0 )
                return;

            formProductImageEdit productImageEdit = new formProductImageEdit(Convert.ToInt32(proGrid1.SelectedRows[0].Cells["ColId"].Value));
            productImageEdit.ShowDialog();
            buttonSearch.PerformClick();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(proGrid1.SelectedRows.Count <= 0)
                return;

            DialogResult deleteComfrm = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if(deleteComfrm != DialogResult.Yes)
                return;

            DAL.ProductImage productImage = new ProductImage();
            string ids = "";

            for (int i = 0; i < proGrid1.SelectedRows.Count; i++)
            {
                ids += proGrid1.SelectedRows[i].Cells["ColId"].Value.ToString() + ", ";
            }

            ids = ids.Substring(0, ids.Length - 2);

            if (productImage.Delete(ids))
            {
                MessageBox.Show("Product Image Deleted");
                buttonSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(productImage.Error);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DAL.ProductImage productImage = new ProductImage();
            productImage.Search = textBoxSearch.Text;
            proGrid1.DataSource = productImage.Select().Tables[0];
        }
    }
}
