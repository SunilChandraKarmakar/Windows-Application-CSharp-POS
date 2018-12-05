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
    public partial class formPucrchaseNew : Point_Of_Sale.Presentation.Template.formNew
    {
        ErrorProvider errorProvider = new ErrorProvider();
        public formPucrchaseNew()
        {
            InitializeComponent();
        }

        private void formPucrchaseNew_Load(object sender, EventArgs e)
        {
            DAL.Ledger ledger = new Ledger();
            comboBoxLedger.DataSource = ledger.Select().Tables[0];
            comboBoxLedger.DisplayMember = "name";
            comboBoxLedger.ValueMember = "id";
            comboBoxLedger.SelectedValue = -1;
            
            DAL.Employee employee = new DAL.Employee();
            comboBoxEmployee.DataSource = employee.Select().Tables[0];
            comboBoxEmployee.DisplayMember = "name";
            comboBoxEmployee.ValueMember = "id";
            comboBoxEmployee.SelectedValue = -1;

            DAL.Product product = new Product();
            ColProduct.DataSource = product.Select().Tables[0];
            ColProduct.DisplayMember = "name";
            ColProduct.ValueMember = "id";

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int error = 0;
            errorProvider.Clear();

            //if (textBoxNumber.Text == "")
            //{
            //    error++;
            //    errorProvider.SetError(textBoxNumber, "Required");
            //}

            if (comboBoxLedger.Text == "")
            {
                error++;
                errorProvider.SetError(comboBoxLedger, "Required");
            }

            if (dateTimePickerPucrchase.Text == "")
            {
                error++;
                errorProvider.SetError(dateTimePickerPucrchase, "Required");
            }

            if (comboBoxEmployee.Text == "")
            {
                error++;
                errorProvider.SetError(comboBoxEmployee, "Required");
            }

            if (textBoxTotal.Text == "")
            {
                error++;
                errorProvider.SetError(textBoxTotal, "Required");
            }

            if (textBoxVat.Text == "")
            {
                error++;
                errorProvider.SetError(textBoxVat, "Required");
            }

            if (textBoxDiscound.Text == "")
            {
                error++;
                errorProvider.SetError(textBoxDiscound, "Required");
            }

            if (dataGridViewPucrchase.Rows.Count < 2)
            {
                error++;
                errorProvider.SetError(dataGridViewPucrchase, "Entered some item.");
            }

            if(error > 0)
                return;

            DAL.Pucrchase pucrchase = new Pucrchase();
            //pucrchase.Number = textBoxNumber.Text;
            pucrchase.LedgerId = Convert.ToInt32(comboBoxLedger.SelectedValue);
            pucrchase.DateTime = Convert.ToDateTime(dateTimePickerPucrchase.Text);
            pucrchase.EmployeeId = Convert.ToInt32(comboBoxEmployee.SelectedValue);
            pucrchase.Total = Convert.ToDouble(textBoxTotal.Text);
            pucrchase.Discount = Convert.ToDouble(textBoxDiscound.Text);
            pucrchase.Vat = Convert.ToDouble(textBoxVat.Text);

            if (pucrchase.Insert())
            {
                for (int i = 0; i < dataGridViewPucrchase.Rows.Count - 1; i++)
                {
                    DAL.PucrchaseDetails pucrchaseDetails = new PucrchaseDetails();
                    pucrchaseDetails.PucrchaseId = pucrchase.LastId;
                    pucrchaseDetails.ProductId = Convert.ToInt32(dataGridViewPucrchase.Rows[i].Cells["ColProduct"].Value);
                    pucrchaseDetails.Qty = Convert.ToInt32(dataGridViewPucrchase.Rows[i].Cells["ColQty"].Value);
                    pucrchaseDetails.Rate = Convert.ToDouble(dataGridViewPucrchase.Rows[i].Cells["ColRate"].Value);
                    pucrchaseDetails.Insert();
                }

                DAL.Transaction transactionTwo = new Transaction();
                transactionTwo.DateTime = dateTimePickerPucrchase.Value;
                transactionTwo.EmployeeId = pucrchase.EmployeeId;
                transactionTwo.LedgerId = pucrchase.LedgerId;
                transactionTwo.Number = "Automated transction number" + pucrchase.Number;
                transactionTwo.Reference = Convert.ToString(pucrchase.Number);
                transactionTwo.Remarks = "Automatic transaction during pucrchase";
                transactionTwo.Debit = 0;
                transactionTwo.Credit = Convert.ToDouble(textBoxGrandTotal.Text);

                if (!transactionTwo.Insert())
                {
                    MessageBox.Show(transactionTwo.Error);
                }


                double paid = 0;

                try
                {
                    paid = Convert.ToDouble(textBoxPaid.Text);
                    DAL.Transaction transaction = new Transaction();
                    transaction.DateTime = dateTimePickerPucrchase.Value;
                    transaction.EmployeeId = pucrchase.EmployeeId;
                    transaction.LedgerId = pucrchase.LedgerId;
                    transaction.Number = "Automated transction number" + pucrchase.Number;
                    transaction.Reference = Convert.ToString(pucrchase.Number);
                    transaction.Remarks = "Automatic transaction during pucrchase";
                    transaction.Debit = paid;
                    transaction.Credit = 0;

                    if (!transaction.Insert())
                    {
                        MessageBox.Show(transaction.Error);
                    }

                }
                catch (Exception)
                {
                    
                    
                }


                MessageBox.Show("Pucrchase Save");
                dataGridViewPucrchase.Rows.Clear();
                //textBoxNumber.Text = "";
                comboBoxLedger.Text = "";
                dateTimePickerPucrchase.Text = "";
                comboBoxEmployee.Text = "";
                textBoxTotal.Text = "";
                textBoxGrandTotal.Text = "";
            }

            else
            {
                MessageBox.Show(pucrchase.Error);
            }

        }

        public void loadTotal()
        {
            double total = 0;
            for (int i = 0; i < dataGridViewPucrchase.Rows.Count - 1; i++)
            {
                try
                {
                    total += Convert.ToDouble(dataGridViewPucrchase.Rows[i].Cells["ColSubTotal"].Value);
                }
                catch (Exception)
                {
                    
                }
            }

            textBoxTotal.Text = total.ToString();
            textBoxGrandTotal.Text = (total + total * Convert.ToDouble(textBoxVat.Text) / 100 - total * Convert.ToDouble(textBoxDiscound.Text) / 100).ToString();
        }

        private void dataGridViewPucrchase_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                DAL.Product product = new Product();
                product.Id = Convert.ToInt32(dataGridViewPucrchase.Rows[e.RowIndex].Cells["ColProduct"].Value);
                product.SelectById();
                dataGridViewPucrchase.Rows[e.RowIndex].Cells["ColQty"].Value = 1;
                dataGridViewPucrchase.Rows[e.RowIndex].Cells["ColRate"].Value = product.Price;
                dataGridViewPucrchase.Rows[e.RowIndex].Cells["ColSubTotal"].Value = 1 * product.Price;
            }

            if ((e.ColumnIndex == 1 || e.ColumnIndex ==2) && e.RowIndex >= 0)
            {
                double qty = Convert.ToDouble(dataGridViewPucrchase.Rows[e.RowIndex].Cells["ColQty"].Value);
                double rate = Convert.ToDouble(dataGridViewPucrchase.Rows[e.RowIndex].Cells["ColRate"].Value);
                dataGridViewPucrchase.Rows[e.RowIndex].Cells["ColSubTotal"].Value = qty * rate;
            }

            loadTotal();
        }

        private void textBoxReturn_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    double g = Convert.ToDouble(textBoxGrandTotal.Text);
            //    double h = Convert.ToDouble(textBoxPaid.Text);

            //    double re = g - h;

            //    MessageBox.Show(Convert.ToString(re));
            //}
            //catch (Exception)
            //{
                
            //    throw;
            //}
        }

        private void dataGridViewPucrchase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public int paid, grandTotal, backPayment;
        private void textBoxPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                paid = Convert.ToInt32(textBoxPaid.Text);
                grandTotal = Convert.ToInt32(textBoxGrandTotal.Text);
                backPayment = grandTotal - paid;
                textBoxReturn.Text = Convert.ToString(backPayment);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
