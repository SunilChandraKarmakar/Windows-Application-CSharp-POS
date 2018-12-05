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
    public partial class formBrand : Point_Of_Sale.Presentation.Template.formDisplay
    {
        public formBrand()
        {
            InitializeComponent();
        }

        private void formBrand_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;

            DAL.Brand brand = new Brand();
            brand.Search = textBoxSearch.Text;
            proGrid1.DataSource = brand.Select().Tables[0];
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            formBrandNew brandNew = new formBrandNew();
            brandNew.ShowDialog();
            buttonSearch.PerformClick();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DAL.Brand brand = new Brand();
            brand.Search = textBoxSearch.Text;
            proGrid1.DataSource = brand.Select().Tables[0];
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (proGrid1.SelectedRows.Count <= 0)
                return;

            formBrandEdit brandEdit = new formBrandEdit(Convert.ToInt32(proGrid1.SelectedRows[0].Cells["ColId"].Value));
            brandEdit.ShowDialog();
            buttonSearch.PerformClick();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (proGrid1.SelectedRows.Count <= 0)
                return;

            DialogResult confurmDelete = MessageBox.Show("Are you sure?", "Confirmation.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (confurmDelete != DialogResult.Yes)
                return;

            DAL.Brand brandDelete = new DAL.Brand();
            string ids = "";

            for (int i = 0; i < proGrid1.SelectedRows.Count; i++)
            {
                ids += proGrid1.SelectedRows[i].Cells["ColId"].Value.ToString() + ", ";
            }

            ids = ids.Substring(0, ids.Length - 2);

            if (brandDelete.Delete(ids))
            {
                MessageBox.Show("Data deleted");
                buttonSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(brandDelete.Error);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DAL.Brand brand = new Brand();
            brand.Search = textBoxSearch.Text;
            proGrid1.DataSource = brand.Select().Tables[0];
        }
    }
}
