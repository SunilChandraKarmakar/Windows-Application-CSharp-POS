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
    public partial class formUnit : Point_Of_Sale.Presentation.Template.formDisplay
    {
        public formUnit()
        {
            InitializeComponent();
        }

        private void formUnit_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;

            DAL.Unit unit = new Unit();
            unit.Search = textBoxSearch.Text;
            proGrid1.DataSource = unit.Select().Tables[0];
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            formUnitNew unitNew = new formUnitNew();
            unitNew.ShowDialog();
            buttonSearch.PerformClick();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DAL.Unit unit = new Unit();
            unit.Search = textBoxSearch.Text;
            proGrid1.DataSource = unit.Select().Tables[0];
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if(proGrid1.SelectedRows.Count <= 0)
                return;
            
            formUnitEdit unitEdit = new formUnitEdit(Convert.ToInt32(proGrid1.SelectedRows[0].Cells["ColId"].Value));
            unitEdit.ShowDialog();
            buttonSearch.PerformClick();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(proGrid1.SelectedRows.Count <= 0)
                return;

            DialogResult delete = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            
            if(delete != DialogResult.Yes)
                return;
            
            DAL.Unit unitDelete = new Unit();
            string ids = "";

            for (int i = 0; i < proGrid1.SelectedRows.Count; i++)
            {
                ids += proGrid1.SelectedRows[i].Cells["ColId"].Value.ToString() + ", ";
            }
            ids = ids.Substring(0, ids.Length - 2);

            if (unitDelete.Delete(ids))
            {
                MessageBox.Show("Unit is delete.");
                buttonSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(unitDelete.Error);
            }

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DAL.Unit unit = new Unit();
            unit.Search = textBoxSearch.Text;
            proGrid1.DataSource = unit.Select().Tables[0];
        }
    }
}
