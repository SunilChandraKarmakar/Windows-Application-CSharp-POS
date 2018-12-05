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
    public partial class formProductImageNew : Point_Of_Sale.Presentation.Template.formNew
    {
        ErrorProvider errorProvider = new ErrorProvider();
        public formProductImageNew()
        {
            InitializeComponent();
        }

        private void formProductImageNew_Load(object sender, EventArgs e)
        {
            DAL.Product product = new Product();
            comboBoxProduct.DataSource = product.Select().Tables[0];
            comboBoxProduct.DisplayMember = "name";
            comboBoxProduct.ValueMember = "id";
            comboBoxProduct.SelectedValue = -1;
            comboBoxProduct.Text = "-Select Product";

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void linkLabelClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBoxImage.Image = null;
        }

        private void linkLabelBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "JPG|*.jpg|PNG|*.png|GIF|*.gif|DOC|*.doc";
            openFileDialog.ShowDialog();

            if(openFileDialog.FileName == null || openFileDialog.FileName == "")
                return;

            pictureBoxImage.Image = Image.FromFile(openFileDialog.FileName);
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

            if (textBoxTitle.Text == "")
            {
                error++;
                errorProvider.SetError(textBoxTitle, "Required");
            }

            if (pictureBoxImage.Image == null)
            {
                error++;
                errorProvider.SetError(pictureBoxImage, "Required");
            }

            if(error > 0)
                return;

            DAL.ProductImage productImage = new ProductImage();
            productImage.ProductId = Convert.ToInt32(comboBoxProduct.SelectedValue);
            productImage.Title = textBoxTitle.Text;
            productImage.Image = DAL.FileImage.ImageToByte(pictureBoxImage.Image);

            if (productImage.Insert())
            {
                MessageBox.Show("Product Image save");
                comboBoxProduct.SelectedValue = -1;
                textBoxTitle.Text = "";
                pictureBoxImage.Image = null;
                comboBoxProduct.Focus();
            }
            else
            {
                MessageBox.Show(productImage.Error);
            }
        }
    }
}
