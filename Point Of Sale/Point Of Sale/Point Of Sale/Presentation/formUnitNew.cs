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
    public partial class formUnitNew : Point_Of_Sale.Presentation.Template.formNew
    {
        ErrorProvider errorProvider = new ErrorProvider();
        public formUnitNew()
        {
            InitializeComponent();
        }

        private void formUnitNew_Load(object sender, EventArgs e)
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

            if (textBoxDescription.Text == "")
            {
                error++;
                errorProvider.SetError(textBoxDescription, "Required");
            }

            if (comboBoxQty.Text == "")
            {
                error++;
                errorProvider.SetError(comboBoxQty, "Required");
            }
            
            if(error > 0)
                return;

            DAL.Unit unit = new Unit();
            unit.Name = textBoxName.Text;
            unit.Description = textBoxDescription.Text;
            unit.PrimaryQty = Convert.ToInt32(comboBoxQty.Text);

            if(unit.Insert())
            {
                MessageBox.Show("Unit is save.");
                textBoxName.Text = "";
                textBoxDescription.Text = "";
                comboBoxQty.Text = "";
                textBoxName.Focus();
            }
            else
            {
                MessageBox.Show(unit.Error);
            }
        }
    }
}
