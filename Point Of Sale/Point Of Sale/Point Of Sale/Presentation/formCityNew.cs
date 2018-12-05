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
    public partial class formCityNew : Point_Of_Sale.Presentation.Template.formNew
    {
        ErrorProvider errorProvider = new ErrorProvider();
        DAL.City addCity = new City();
        public formCityNew()
        {
            InitializeComponent();
        }

        private void formCityNew_Load(object sender, EventArgs e)
        {
            DAL.Country country = new Country();
            comboBoxCountry.DataSource = country.Select().Tables[0];
            comboBoxCountry.DisplayMember = "name";
            comboBoxCountry.ValueMember = "id";
            comboBoxCountry.SelectedValue = -1;

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

            if (comboBoxCountry.Text == "")
            {
                error++;
                errorProvider.SetError(comboBoxCountry, "Required");
            }

            if(error > 0)
                return;
            
            
            addCity.Name = textBoxName.Text;
            addCity.CountryId = Convert.ToInt32(comboBoxCountry.SelectedValue);

            if (addCity.Insert())
            {
                MessageBox.Show("City is save.");
                textBoxName.Text = "";
                comboBoxCountry.Text = "";
                textBoxName.Focus();
            }

            else
            {
                MessageBox.Show(addCity.Error);
            }
        }
    }
}
