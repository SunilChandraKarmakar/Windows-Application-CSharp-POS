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
    public partial class formLedger : Point_Of_Sale.Presentation.Template.formDisplay
    {
        public formLedger()
        {
            InitializeComponent();
        }

        private void formLedger_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;

            DAL.Ledger ledger = new Ledger();
            ledger.Search = textBoxSearch.Text;
            proGrid1.DataSource = ledger.Select().Tables[0];

        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            formLedgerNew ledgerNew = new formLedgerNew();
            ledgerNew.ShowDialog();
            buttonSearch.PerformClick();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DAL.Ledger ledger = new Ledger();
            ledger.Search = textBoxSearch.Text;
            proGrid1.DataSource = ledger.Select().Tables[0];
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(proGrid1.SelectedRows.Count <= 0)
                return;

            DialogResult deletePro = MessageBox.Show("Are you sure?", "Comfirmation.", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (deletePro != DialogResult.Yes)
                return;

            DAL.Ledger ledger = new Ledger();

            string ids = "";

            for (int i = 0; i < proGrid1.SelectedRows.Count; i++)
            {
                ids += proGrid1.SelectedRows[i].Cells["ColId"].Value.ToString() + ", ";
            }

            ids = ids.Substring(0, ids.Length - 2);

            if (ledger.Delete(ids))
            {
                MessageBox.Show("Product is delete.");
                buttonSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(ledger.Error);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if(proGrid1.SelectedRows.Count <= 0)
                return;

            formLedgerEdit ledgerEdit = new formLedgerEdit(Convert.ToInt32(proGrid1.SelectedRows[0].Cells["ColId"].Value));
            ledgerEdit.ShowDialog();
            buttonSearch.PerformClick();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DAL.Ledger ledger = new Ledger();
            ledger.Search = textBoxSearch.Text;
            proGrid1.DataSource = ledger.Select().Tables[0];
        }
    }
}
