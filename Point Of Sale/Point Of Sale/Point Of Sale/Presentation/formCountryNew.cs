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
    public partial class formCountryNew : Point_Of_Sale.Presentation.Template.formNew
    {
        ErrorProvider errorProvider = new ErrorProvider();
        public formCountryNew()
        {
            InitializeComponent();
        }

        private void formCountryNew_Load(object sender, EventArgs e)
        {
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

            if(error > 0)
                return;

            DAL.Country addCountry = new Country();
            addCountry.Name = textBoxName.Text;

            if (addCountry.Insert())
            {
                MessageBox.Show("Country is save");
                textBoxName.Text = "";
                textBoxName.Focus();
            }
            else
            {
                MessageBox.Show(addCountry.Error);
            }



        }

        private void buttonExit_Click(object sender, EventArgs e)
        {

        }
    }
}
