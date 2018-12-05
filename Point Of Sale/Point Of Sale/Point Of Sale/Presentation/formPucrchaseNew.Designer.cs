namespace Point_Of_Sale.Presentation
{
    partial class formPucrchaseNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxLedger = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerPucrchase = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxEmployee = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxVat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxDiscound = new System.Windows.Forms.TextBox();
            this.dataGridViewPucrchase = new System.Windows.Forms.DataGridView();
            this.ColProduct = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxGrandTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxPaid = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxReturn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPucrchase)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(18, 594);
            this.buttonSave.Size = new System.Drawing.Size(433, 27);
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(542, 594);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ledger";
            // 
            // comboBoxLedger
            // 
            this.comboBoxLedger.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxLedger.FormattingEnabled = true;
            this.comboBoxLedger.Location = new System.Drawing.Point(12, 131);
            this.comboBoxLedger.Name = "comboBoxLedger";
            this.comboBoxLedger.Size = new System.Drawing.Size(162, 26);
            this.comboBoxLedger.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(411, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Date Time";
            // 
            // dateTimePickerPucrchase
            // 
            this.dateTimePickerPucrchase.CustomFormat = "";
            this.dateTimePickerPucrchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerPucrchase.Location = new System.Drawing.Point(414, 109);
            this.dateTimePickerPucrchase.Name = "dateTimePickerPucrchase";
            this.dateTimePickerPucrchase.Size = new System.Drawing.Size(200, 24);
            this.dateTimePickerPucrchase.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(414, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Employee";
            // 
            // comboBoxEmployee
            // 
            this.comboBoxEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEmployee.FormattingEnabled = true;
            this.comboBoxEmployee.Location = new System.Drawing.Point(417, 166);
            this.comboBoxEmployee.Name = "comboBoxEmployee";
            this.comboBoxEmployee.Size = new System.Drawing.Size(197, 26);
            this.comboBoxEmployee.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(407, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Total";
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotal.Location = new System.Drawing.Point(454, 393);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.Size = new System.Drawing.Size(160, 24);
            this.textBoxTotal.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(411, 430);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "Vat";
            // 
            // textBoxVat
            // 
            this.textBoxVat.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Point_Of_Sale.Properties.Settings.Default, "Vat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxVat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxVat.Location = new System.Drawing.Point(454, 424);
            this.textBoxVat.Name = "textBoxVat";
            this.textBoxVat.ReadOnly = true;
            this.textBoxVat.Size = new System.Drawing.Size(160, 24);
            this.textBoxVat.TabIndex = 13;
            this.textBoxVat.Text = global::Point_Of_Sale.Properties.Settings.Default.Vat;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(377, 457);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "Discound";
            // 
            // textBoxDiscound
            // 
            this.textBoxDiscound.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Point_Of_Sale.Properties.Settings.Default, "Discount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxDiscound.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDiscound.Location = new System.Drawing.Point(454, 454);
            this.textBoxDiscound.Name = "textBoxDiscound";
            this.textBoxDiscound.ReadOnly = true;
            this.textBoxDiscound.Size = new System.Drawing.Size(160, 24);
            this.textBoxDiscound.TabIndex = 15;
            this.textBoxDiscound.Text = global::Point_Of_Sale.Properties.Settings.Default.Discount;
            // 
            // dataGridViewPucrchase
            // 
            this.dataGridViewPucrchase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPucrchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPucrchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColProduct,
            this.ColQty,
            this.ColRate,
            this.ColSubTotal});
            this.dataGridViewPucrchase.Location = new System.Drawing.Point(12, 198);
            this.dataGridViewPucrchase.Name = "dataGridViewPucrchase";
            this.dataGridViewPucrchase.Size = new System.Drawing.Size(602, 189);
            this.dataGridViewPucrchase.TabIndex = 16;
            this.dataGridViewPucrchase.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPucrchase_CellContentClick);
            this.dataGridViewPucrchase.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPucrchase_CellValueChanged);
            // 
            // ColProduct
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColProduct.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColProduct.HeaderText = "Product";
            this.ColProduct.Name = "ColProduct";
            // 
            // ColQty
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColQty.HeaderText = "Qty";
            this.ColQty.Name = "ColQty";
            // 
            // ColRate
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColRate.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColRate.HeaderText = "Rate";
            this.ColRate.Name = "ColRate";
            // 
            // ColSubTotal
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColSubTotal.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColSubTotal.HeaderText = "Sub Total";
            this.ColSubTotal.Name = "ColSubTotal";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(362, 487);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 18);
            this.label8.TabIndex = 17;
            this.label8.Text = "Grand Total";
            // 
            // textBoxGrandTotal
            // 
            this.textBoxGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGrandTotal.Location = new System.Drawing.Point(454, 484);
            this.textBoxGrandTotal.Name = "textBoxGrandTotal";
            this.textBoxGrandTotal.ReadOnly = true;
            this.textBoxGrandTotal.Size = new System.Drawing.Size(160, 24);
            this.textBoxGrandTotal.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(411, 512);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 18);
            this.label9.TabIndex = 19;
            this.label9.Text = "Paid";
            // 
            // textBoxPaid
            // 
            this.textBoxPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPaid.Location = new System.Drawing.Point(454, 512);
            this.textBoxPaid.Name = "textBoxPaid";
            this.textBoxPaid.Size = new System.Drawing.Size(160, 24);
            this.textBoxPaid.TabIndex = 20;
            this.textBoxPaid.TextChanged += new System.EventHandler(this.textBoxPaid_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(396, 543);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 18);
            this.label10.TabIndex = 21;
            this.label10.Text = "Return";
            // 
            // textBoxReturn
            // 
            this.textBoxReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxReturn.Location = new System.Drawing.Point(454, 540);
            this.textBoxReturn.Name = "textBoxReturn";
            this.textBoxReturn.Size = new System.Drawing.Size(160, 24);
            this.textBoxReturn.TabIndex = 22;
            this.textBoxReturn.TextChanged += new System.EventHandler(this.textBoxReturn_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Papyrus", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.Location = new System.Drawing.Point(190, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 42);
            this.label1.TabIndex = 23;
            this.label1.Text = "Pucrchase Insert";
            // 
            // formPucrchaseNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(651, 641);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxReturn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxPaid);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxGrandTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGridViewPucrchase);
            this.Controls.Add(this.textBoxDiscound);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxVat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxEmployee);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePickerPucrchase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxLedger);
            this.Controls.Add(this.label2);
            this.Name = "formPucrchaseNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pucrchase New";
            this.Load += new System.EventHandler(this.formPucrchaseNew_Load);
            this.Controls.SetChildIndex(this.buttonSave, 0);
            this.Controls.SetChildIndex(this.buttonExit, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.comboBoxLedger, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dateTimePickerPucrchase, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.comboBoxEmployee, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.textBoxTotal, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.textBoxVat, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.textBoxDiscound, 0);
            this.Controls.SetChildIndex(this.dataGridViewPucrchase, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.textBoxGrandTotal, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.textBoxPaid, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.textBoxReturn, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPucrchase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxLedger;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerPucrchase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxEmployee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxVat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxDiscound;
        private System.Windows.Forms.DataGridView dataGridViewPucrchase;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxGrandTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxPaid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxReturn;
        private System.Windows.Forms.Label label1;
    }
}
