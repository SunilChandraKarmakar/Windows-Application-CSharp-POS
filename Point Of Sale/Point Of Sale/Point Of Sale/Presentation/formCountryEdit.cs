using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace Point_Of_Sale.Presentation
{
    public partial class formCountryEdit : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        DAL.Country country = new Country();
        public formCountryEdit(int id)
        {
            InitializeComponent();

            country.Id = id;
            if (country.SelectById())
            {
                textBoxName.Text = country.Name;
            }
            else
            {
                MessageBox.Show(country.Error);
            }
        }

        private void formCountryEdit_Load(object sender, EventArgs e)
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

            if(error > 0)
                return;

            country.Name = textBoxName.Text;
            if (country.Update())
            {
                MessageBox.Show("Country is Update");
                textBoxName.Text = "";
                textBoxName.Focus();
            }
            else
            {
                MessageBox.Show(country.Error);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
