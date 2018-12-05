using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace Point_Of_Sale.Presentation
{
    public partial class formProductImageEdit : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        DAL.ProductImage productImage = new ProductImage();

        public formProductImageEdit(int id)
        {
            InitializeComponent();

            DAL.Product product = new Product();
            comboBoxProduct.DataSource = product.Select().Tables[0];
            comboBoxProduct.DisplayMember = "name";
            comboBoxProduct.ValueMember = "id";
            comboBoxProduct.SelectedValue = -1;

            productImage.Id = id;
            if (productImage.SelectById())
            {
                comboBoxProduct.SelectedValue = productImage.ProductId;
                textBoxTitle.Text = productImage.Title;
                pictureBoxImage.Image = DAL.FileImage.ImageFromByte(productImage.Image);
            }

            else
            {
                MessageBox.Show(productImage.Error);
            }
        }

        private void formProductImageEdit_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
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

            if (error > 0)
                return;

            
            productImage.ProductId = Convert.ToInt32(comboBoxProduct.SelectedValue);
            productImage.Title = textBoxTitle.Text;
            productImage.Image = DAL.FileImage.ImageToByte(pictureBoxImage.Image);

            if (productImage.Update())
            {
                MessageBox.Show("Product Image Update");
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

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabelBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "JPG|*.jpg|PNG|*.png|GIF|*.gif|DOC|*.doc";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName == null || openFileDialog.FileName == "")
                return;

            pictureBoxImage.Image = Image.FromFile(openFileDialog.FileName);
        }

        private void linkLabelClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBoxImage.Image = null;
        }
    }
}
