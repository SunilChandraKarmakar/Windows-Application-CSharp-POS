using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using DAL;

namespace Point_Of_Sale.Presentation
{
    public partial class formPucrchaseReport : Form
    {
        public formPucrchaseReport()
        {
            InitializeComponent();
        }

        private void formPucrchaseReport_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;

            DAL.Pucrchase pucrchase = new Pucrchase();
            //proGrid1.DataSource = pucrchase.Select().Tables[0];

            //ReportDocument reportDocument = new ReportDocument();
            CrystalReportPurchase pr = new CrystalReportPurchase();
            pr.Database.Tables["Purches"].SetDataSource(pucrchase.Select().Tables[0]);
            //reportDocument.Load("C:\\Users\\Sunil\\Documents\\Visual Studio 2013\\Projects\\Windows Form\\Point Of Sale\\Point Of Sale\\Point Of Sale\\Presentation\\PucrchaseReport.rpt");
            crystalReportPucrchase.ReportSource = pr;
            crystalReportPucrchase.Refresh();
        }
    }
}
