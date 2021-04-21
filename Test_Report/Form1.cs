using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport;
using FastReport.Utils;

namespace Test_Report
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Diploma.Diploma di = new Diploma.Diploma(@"Data Source = KRNALX\KRNALX; Initial Catalog = Diploma; Integrated Security = True");
            Report report = di.Test_Report("fgdf");
            report.Show();

        }
    }
}
