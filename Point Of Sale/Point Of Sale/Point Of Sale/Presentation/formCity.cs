using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace Point_Of_Sale.Presentation.ProControls
{
    public partial class formCity : Point_Of_Sale.Presentation.Template.formDisplay
    {
        public formCity()
        {
            InitializeComponent();
        }

        private void formCity_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;

            DAL.City citySearch = new City();
            citySearch.Search = textBoxSearch.Text;
            proGrid1.DataSource = citySearch.Select().Tables[0];

            DAL.Country countryLoad = new Country();
            comboBoxCountry.DataSource = countryLoad.Select().Tables[0];
            comboBoxCountry.DisplayMember = "name";
            comboBoxCountry.ValueMember = "id";
            comboBoxCountry.SelectedValue = -1;
            comboBoxCountry.Text = "-- Select Country --";

        }

        private void proGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            formCityNew cityNew = new formCityNew();
            cityNew.ShowDialog();
            buttonSearch.PerformClick();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DAL.City citySearch = new City();
            citySearch.Search = textBoxSearch.Text;
            try
            {
                citySearch.CountryId = Convert.ToInt32(comboBoxCountry.SelectedValue);
            }
            catch
            {

            }

            proGrid1.DataSource = citySearch.Select().Tables[0];
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if(proGrid1.SelectedRows.Count <= 0)
                return;

            formCityEdit cityEdit = new formCityEdit(Convert.ToInt32(proGrid1.SelectedRows[0].Cells["ColId"].Value));
            cityEdit.ShowDialog();
            buttonSearch.PerformClick();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (proGrid1.SelectedRows.Count <= 0)
                return;

            DialogResult confurmDelete = MessageBox.Show("Are you sure?", "Confirmation.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (confurmDelete != DialogResult.Yes)
                return;

            DAL.City city = new DAL.City();
            string ids = "";

            for (int i = 0; i < proGrid1.SelectedRows.Count; i++)
            {
                ids += proGrid1.SelectedRows[i].Cells["ColId"].Value.ToString() + ", ";
            }

            ids = ids.Substring(0, ids.Length - 2);

            if (city.Delete(ids))
            {
                MessageBox.Show("Data deleted");
                buttonSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(city.Error);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DAL.City citySearch = new City();
            citySearch.Search = textBoxSearch.Text;
            proGrid1.DataSource = citySearch.Select().Tables[0];
        }
    }
}
