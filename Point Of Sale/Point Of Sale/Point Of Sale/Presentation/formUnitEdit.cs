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
    public partial class formUnitEdit : Point_Of_Sale.Presentation.Template.formNew
    {
        ErrorProvider errorProvider = new ErrorProvider();
        DAL.Unit unit = new Unit();

        public formUnitEdit(int id)
        {
            InitializeComponent();

            
            unit.Id = id;
            if (unit.SelectById())
            {
                textBoxName.Text = unit.Name;
                textBoxDescription.Text = unit.Description;
                comboBoxQty.Text = Convert.ToString(unit.PrimaryQty);
            }
            else
            {
                MessageBox.Show(unit.Error);
            }
        }

        private void formUnitEdit_Load(object sender, EventArgs e)
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

            unit.Name = textBoxName.Text;
            unit.Description = textBoxDescription.Text;
            unit.PrimaryQty = Convert.ToInt32(comboBoxQty.Text);

            if (unit.Update())
            {
                MessageBox.Show("Unit is Update.");
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
