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
    public partial class formBrandEdit : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        DAL.Brand brand = new Brand();
        public formBrandEdit(int id)
        {
            InitializeComponent();

            brand.Id = id;
            if (brand.SelectById())
            {
                textBoxName.Text = brand.Name;
                textBoxOrigin.Text = brand.Origin;
            }
            else
            {
                MessageBox.Show(brand.Error);
            }
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

            if (textBoxOrigin.Text == "")
            {
                error++;
                errorProvider.SetError(textBoxOrigin, "Required");
            }

            if (error > 0)
                return;

            
            brand.Name = textBoxName.Text;
            brand.Origin = textBoxOrigin.Text;

            if (brand.Update())
            {
                MessageBox.Show("Brand is Update.");
                textBoxName.Text = "";
                textBoxOrigin.Text = "";
                textBoxName.Focus();
            }
            else
            {
                MessageBox.Show(brand.Error);
            }
        }

        private void formBrandEdit_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
