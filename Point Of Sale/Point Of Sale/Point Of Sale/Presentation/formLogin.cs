using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Point_Of_Sale.Presentation
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text  == "admin@info.com" && textBoxPassword.Text == "admin")
            {
                Form1 openManiForm = new Form1();
                openManiForm.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Please input currect email and password");
            }
        }
    }
}
