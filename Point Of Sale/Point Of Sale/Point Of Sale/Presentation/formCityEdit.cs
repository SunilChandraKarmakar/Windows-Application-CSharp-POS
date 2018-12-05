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
    public partial class formCityEdit : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        DAL.City cityEdit = new City();
        public formCityEdit(int id)
        {
            InitializeComponent();

            DAL.Country callCountry = new Country();
            comboBoxCountry.DataSource = callCountry.Select().Tables[0];
            comboBoxCountry.DisplayMember = "name";
            comboBoxCountry.ValueMember = "id";
            comboBoxCountry.SelectedValue = -1;

            cityEdit.Id = id;
            if (cityEdit.SelectById())
            {
                textBoxName.Text = cityEdit.Name;
                comboBoxCountry.SelectedValue = cityEdit.CountryId;
            }
        }

        private void formCityEdit_Load(object sender, EventArgs e)
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

            if (comboBoxCountry.SelectedValue == null || comboBoxCountry.SelectedValue.ToString() == "")
            {
                error++;
                errorProvider.SetError(comboBoxCountry, "Required");
            }

            if (error > 0)
                return;

            cityEdit.Name = textBoxName.Text;
            cityEdit.CountryId = Convert.ToInt32(comboBoxCountry.SelectedValue);

            if (cityEdit.Update())
            {
                MessageBox.Show("City is Update.");
                textBoxName.Text = "";
                comboBoxCountry.Text = "";
                textBoxName.Focus();
            }
            else
            {
                MessageBox.Show(cityEdit.Error);
            }

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
