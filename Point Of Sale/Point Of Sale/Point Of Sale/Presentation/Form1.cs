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
using Point_Of_Sale.Presentation;
using Point_Of_Sale.Presentation.ProControls;

namespace Point_Of_Sale
{
    public partial class Form1 : Form
    {
        formProductImage _productImage = new formProductImage();
        formEmployee _formEmployee = new formEmployee();
        formCity _formCity = new formCity();
        formBrand _formBrand = new formBrand();
        formCategory _formCategory = new formCategory();
        formUnit _formUnit = new formUnit();
        formProduct _formProduct = new formProduct();
        formProductPrice _formProductPrice = new formProductPrice();
        formLedger _formLedger = new formLedger();
        formCountry _formCountry = new formCountry();
        formPucrchase _formPucrchase = new formPucrchase();

        public Form1()
        {
            InitializeComponent();
        }

        private void catagoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_formCategory.IsDisposed)
                _formCategory = new formCategory();
            //_formCategory.MdiParent = this;
            _formCategory.ShowDialog();
            _formCategory.BringToFront();
        }

        private void productImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_productImage.IsDisposed)
                _productImage = new formProductImage();
            //_productImage.MdiParent = this;
            _productImage.Show();
            _productImage.BringToFront();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            //this.MaximumSize = this.Size;
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_formEmployee.IsDisposed)
                _formEmployee = new formEmployee();
            //_formEmployee.MdiParent = this;
            _formEmployee.ShowDialog();
            _formEmployee.BringToFront();
        }

        private void cityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_formCity.IsDisposed)
                _formCity = new formCity();
            //_formCity.MdiParent = this;
            _formCity.ShowDialog();
            _formCity.BringToFront();

        }

        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_formBrand.IsDisposed)
                _formBrand = new formBrand();
            //_formBrand.MdiParent = this;
            _formBrand.ShowDialog();
            _formBrand.BringToFront();
        }

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_formUnit.IsDisposed)
                _formUnit = new formUnit();
            //_formUnit.MdiParent = this;
            _formUnit.ShowDialog();
            _formUnit.BringToFront();
        }

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(_formProduct.IsDisposed)
                _formProduct = new formProduct();
            //_formProduct.MdiParent = this;
            _formProduct.ShowDialog();
            _formProduct.BringToFront();
        }

        private void productPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_formProductPrice.IsDisposed)
                _formProductPrice = new formProductPrice();
            //_formProductPrice.MdiParent = this;
            _formProductPrice.ShowDialog();
            _formProductPrice.BringToFront();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(_formLedger.IsDisposed)
                _formLedger = new formLedger();
            //_formLedger.MdiParent = this;
            _formLedger.ShowDialog();
            _formLedger.BringToFront();
        }

        private void countryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_formCountry.IsDisposed)
                _formCountry = new formCountry();
            //_formCountry.MdiParent = this;
            _formCountry.ShowDialog();
            _formCountry.BringToFront();
        }

        private void pucrchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_formPucrchase.IsDisposed)
                _formPucrchase = new formPucrchase();
            //_formPucrchase.MdiParent = this;
            _formPucrchase.ShowDialog();
            _formPucrchase.BringToFront();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salesRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPucrchaseReport pucrchaseReport = new formPucrchaseReport();
            pucrchaseReport.ShowDialog();
        }

        private void referncessToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
