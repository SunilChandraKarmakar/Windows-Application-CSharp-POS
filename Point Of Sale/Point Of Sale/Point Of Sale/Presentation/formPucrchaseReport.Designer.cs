namespace Point_Of_Sale.Presentation
{
    partial class formPucrchaseReport
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
            this.crystalReportPucrchase = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportPucrchase
            // 
            this.crystalReportPucrchase.ActiveViewIndex = -1;
            this.crystalReportPucrchase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportPucrchase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportPucrchase.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportPucrchase.DisplayStatusBar = false;
            this.crystalReportPucrchase.Location = new System.Drawing.Point(12, 12);
            this.crystalReportPucrchase.Name = "crystalReportPucrchase";
            this.crystalReportPucrchase.Size = new System.Drawing.Size(1238, 594);
            this.crystalReportPucrchase.TabIndex = 0;
            this.crystalReportPucrchase.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // formPucrchaseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 618);
            this.Controls.Add(this.crystalReportPucrchase);
            this.Name = "formPucrchaseReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pucrchase Report";
            this.Load += new System.EventHandler(this.formPucrchaseReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportPucrchase;
    }
}