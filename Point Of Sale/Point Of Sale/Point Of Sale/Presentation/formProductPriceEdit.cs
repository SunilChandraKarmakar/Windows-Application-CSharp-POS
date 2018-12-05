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
    public partial class formProductPriceEdit : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        DAL.ProductPrice productPrice = new ProductPrice();
        public formProductPriceEdit(int id)
        {
            InitializeComponent();

            DAL.Product product = new Product();
            comboBoxProduct.DataSource = product.Select().Tables[0];
            comboBoxProduct.DisplayMember = "name";
            comboBoxProduct.ValueMember = "id";
            comboBoxProduct.SelectedValue = -1;
            

            DAL.Unit unit = new Unit();
            comboBoxUnit.DataSource = unit.Select().Tables[0];
            comboBoxUnit.DisplayMember = "name";
            comboBoxUnit.ValueMember = "id";
            comboBoxUnit.SelectedValue = -1;
            
            productPrice.Id = id;
            if (productPrice.SelectById())
            {
                comboBoxProduct.SelectedValue = productPrice.ProductId;
                comboBoxUnit.SelectedValue = productPrice.UnitId;
                textBoxPrice.Text = Convert.ToString(productPrice.Price);
            }
        }

        private void formProductPriceEdit_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
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

            if (error > 0)
                return;

            productPrice.ProductId = Convert.ToInt32(comboBoxProduct.SelectedValue);
            productPrice.UnitId = Convert.ToInt32(comboBoxUnit.SelectedValue);
            productPrice.Price = Convert.ToDouble(textBoxPrice.Text);

            if (productPrice.Update())
            {
                MessageBox.Show("Product price is update");
                comboBoxProduct.Text = "";
                comboBoxUnit.Text = "";
                textBoxPrice.Text = "";
                comboBoxProduct.Focus();
            }

            else
            {
                MessageBox.Show(productPrice.Error);
            }
        }
    }
}
