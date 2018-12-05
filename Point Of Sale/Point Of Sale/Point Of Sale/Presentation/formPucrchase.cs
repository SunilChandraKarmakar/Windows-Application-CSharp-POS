using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
using CrystalDecisions.CrystalReports.Engine;


namespace Point_Of_Sale.Presentation
{
    public partial class formPucrchase : Point_Of_Sale.Presentation.Template.formDisplay
    {
        public formPucrchase()
        {
            InitializeComponent();
        }

        private void formPucrchase_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;

            DAL.Pucrchase pucrchase = new Pucrchase();
            pucrchase.Search = textBoxSearch.Text;
            proGrid1.DataSource = pucrchase.Select().Tables[0];
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            formPucrchaseNew pucrchaseNew = new formPucrchaseNew();
            pucrchaseNew.ShowDialog();
            buttonSearch.PerformClick();

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DAL.Pucrchase pucrchase = new Pucrchase();
            pucrchase.Search = textBoxSearch.Text;
            proGrid1.DataSource = pucrchase.Select().Tables[0];
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DAL.Pucrchase pucrchase = new Pucrchase();
            pucrchase.Search = textBoxSearch.Text;
            proGrid1.DataSource = pucrchase.Select().Tables[0];
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (proGrid1.SelectedRows.Count <= 0)
                return;

            DialogResult deletePro = MessageBox.Show("Are you sure?", "Comfirmation.", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (deletePro != DialogResult.Yes)
                return;

            DAL.Pucrchase pucrchase = new Pucrchase();

            string ids = "";

            for (int i = 0; i < proGrid1.SelectedRows.Count; i++)
            {
                ids += proGrid1.SelectedRows[i].Cells["ColNumber"].Value.ToString() + ", ";
            }

            ids = ids.Substring(0, ids.Length - 2);

            if (pucrchase.Delete(ids))
            {
                MessageBox.Show("Product is delete.");
                buttonSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(pucrchase.Error);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            formPucrchaseReport pucrchaseReport = new formPucrchaseReport();
            pucrchaseReport.ShowDialog();
        }
    }
}
