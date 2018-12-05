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
    public partial class formBrandNew : Point_Of_Sale.Presentation.Template.formNew
    {
        ErrorProvider errorProvider = new ErrorProvider();
        public formBrandNew()
        {
            InitializeComponent();
        }

        private void formBrandNew_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
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
                
            DAL.Brand brand = new Brand();
            brand.Name = textBoxName.Text;
            brand.Origin = textBoxOrigin.Text;

            if (brand.Insert())
            {
                MessageBox.Show("Save Brand");
                textBoxName.Text = "";
                textBoxOrigin.Text = "";
                textBoxName.Focus();
            }
            else
            {
                MessageBox.Show(brand.Error);
            }
        }
    }
}
