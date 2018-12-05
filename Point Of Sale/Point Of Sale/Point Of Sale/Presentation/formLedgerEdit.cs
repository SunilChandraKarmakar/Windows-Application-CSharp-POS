﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace Point_Of_Sale.Presentation
{
    public partial class formLedgerEdit : Point_Of_Sale.Presentation.Template.formNew
    {
        ErrorProvider errorProvider = new ErrorProvider();
        DAL.Ledger ledger = new Ledger();
        public formLedgerEdit(int id)
        {
            InitializeComponent();

            DAL.City city = new City();
            comboBoxCity.DataSource = city.Select().Tables[0];
            comboBoxCity.DisplayMember = "name";
            comboBoxCity.ValueMember = "id";
            comboBoxCity.SelectedValue = -1;

            ledger.Id = id;

            if (ledger.SelectById())
            {
                textBoxName.Text = ledger.Name;
                textBoxContact.Text = ledger.Contact;
                textBoxEmail.Text = ledger.Email;
                textBoxPassword.Text = ledger.Password;
                comboBoxGander.Text = ledger.Gander;
                textBoxAddress.Text = ledger.Address;
                comboBoxCity.SelectedValue = Convert.ToString(ledger.CityId);
                dateTimePickerDateOfBirth.Text = Convert.ToString(ledger.DateOfBirth);
                dateTimePickerCreateDate.Text = Convert.ToString(ledger.CreateDate);
                comboBoxType.Text = ledger.Type;
                pictureBoxLedger.Image = DAL.FileImage.ImageFromByte(ledger.Image);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void formLedgerEdit_Load(object sender, EventArgs e)
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

            if (textBoxContact.Text == "")
            {
                error++;
                errorProvider.SetError(textBoxContact, "Required");
            }

            if (textBoxEmail.Text == "")
            {
                error++;
                errorProvider.SetError(textBoxEmail, "Required");
            }

            if (textBoxPassword.Text == "")
            {
                error++;
                errorProvider.SetError(textBoxPassword, "Required");
            }

            if (comboBoxGander.Text == "")
            {
                error++;
                errorProvider.SetError(comboBoxGander, "Required");
            }

            if (textBoxAddress.Text == "")
            {
                error++;
                errorProvider.SetError(textBoxAddress, "Required");
            }

            if (comboBoxCity.Text == "")
            {
                error++;
                errorProvider.SetError(comboBoxCity, "Required");
            }

            if (dateTimePickerDateOfBirth.Text == "")
            {
                error++;
                errorProvider.SetError(dateTimePickerDateOfBirth, "Required");
            }

            if (dateTimePickerCreateDate.Text == "")
            {
                error++;
                errorProvider.SetError(dateTimePickerCreateDate, "Required");
            }

            if (comboBoxType.Text == "")
            {
                error++;
                errorProvider.SetError(comboBoxType, "Required");
            }

            //if (pictureBoxLedger.Text  == "")
            //{
            //    error++;
            //    errorProvider.SetError(pictureBoxLedger, "Required");
            //}

            if (error > 0)
                return;

            
            ledger.Name = textBoxName.Text;
            ledger.Contact = textBoxContact.Text;
            ledger.Email = textBoxEmail.Text;
            ledger.Password = textBoxPassword.Text;
            ledger.Gander = comboBoxGander.Text;
            ledger.Address = textBoxAddress.Text;
            ledger.CityId = Convert.ToInt32(comboBoxCity.SelectedValue);
            ledger.DateOfBirth = Convert.ToDateTime(dateTimePickerDateOfBirth.Text);
            ledger.CreateDate = Convert.ToDateTime(dateTimePickerCreateDate.Text);
            ledger.Type = comboBoxType.Text;
            ledger.Image = DAL.FileImage.ImageToByte(pictureBoxLedger.Image);

            if (ledger.Update())
            {
                MessageBox.Show("Ledger Updated");
                textBoxName.Text = "";
                textBoxContact.Text = "";
                textBoxEmail.Text = "";
                textBoxPassword.Text = "";
                comboBoxGander.Text = "";
                textBoxAddress.Text = "";
                comboBoxCity.Text = "";
                dateTimePickerDateOfBirth.Text = "";
                dateTimePickerCreateDate.Text = "";
                comboBoxType.Text = "";
                pictureBoxLedger.Text = "";
                textBoxName.Focus();
            }
            else
            {
                MessageBox.Show(ledger.Error);
            }
        }

        private void linkLabelBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "JPEG|*.jpg|PNG|*.png|GIF|*.gif|All File|*.*";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName == null || openFileDialog.FileName == "")
                return;

            pictureBoxLedger.Image = Image.FromFile(openFileDialog.FileName);
        }

        private void linkLabelClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBoxLedger.Image = null;
        }
    }
}
