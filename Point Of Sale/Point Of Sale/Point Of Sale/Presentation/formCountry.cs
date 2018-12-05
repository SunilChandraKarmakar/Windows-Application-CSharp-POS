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
    public partial class formCountry : Point_Of_Sale.Presentation.Template.formDisplay
    {
        public formCountry()
        {
            InitializeComponent();
        }

        private void formCountry_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;

            DAL.Country country = new Country();
            country.Search = textBoxSearch.Text;
            proGrid1.DataSource = country.Select().Tables[0];
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            formCountryNew countryNew = new formCountryNew();
            countryNew.ShowDialog();
            buttonSearch.PerformClick();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DAL.Country country = new Country();
            country.Search = textBoxSearch.Text;
            proGrid1.DataSource = country.Select().Tables[0];
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (proGrid1.SelectedRows.Count <= 0)
                return;

            formCountryEdit countryEdit = new formCountryEdit(Convert.ToInt32(proGrid1.SelectedRows[0].Cells["ColId"].Value));
            countryEdit.ShowDialog();
            buttonSearch.PerformClick();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(proGrid1.SelectedRows.Count <= 0)
                return;

            DialogResult confurmDelete = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if(confurmDelete != DialogResult.Yes)
                return;

            DAL.Country countryDelete = new DAL.Country();
            string ids = "";

            for (int i = 0; i < proGrid1.SelectedRows.Count; i++)
            {
                ids += proGrid1.SelectedRows[i].Cells["ColId"].Value.ToString() + ", ";
            }

            ids = ids.Substring(0, ids.Length - 2);

            if (countryDelete.Delete(ids))
            {
                MessageBox.Show("Data deleted");
                buttonSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(countryDelete.Error);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DAL.Country country = new Country();
            country.Search = textBoxSearch.Text;
            proGrid1.DataSource = country.Select().Tables[0];
        }
    }
}
