using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Point_Of_Sale.Presentation.ProControls
{
    public partial class ucDateSearch : UserControl
    {
        public ucDateSearch()
        {
            InitializeComponent();
        }

        private void ucDateSearch_Load(object sender, EventArgs e)
        {
            Checkuncheck();
        }

        private void Checkuncheck()
        {
            dateTimePickerFrom.Enabled = checkBoxDateSearch.Checked;
            dateTimePickerTo.Enabled = checkBoxDateSearch.Checked;
        }

        public DateTime DateFrom
        {
            get { return dateTimePickerFrom.Value; }
            set { dateTimePickerFrom.Value = value; }
        }

        public DateTime DateTo
        {
            get { return dateTimePickerTo.Value; }
            set { dateTimePickerTo.Value = value; }
        }


        public bool IsEnabled
        {
            get { return checkBoxDateSearch.Checked; }
        }
        private void checkBoxDateSearch_CheckedChanged(object sender, EventArgs e)
        {
            Checkuncheck();
        }
    }
}
