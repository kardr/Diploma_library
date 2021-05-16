using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Report
{
    public partial class add_text_blocks : Form
    {
        public add_text_blocks()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                label6.Font = fontDialog1.Font;
                textBox3.Text = fontDialog1.Font.Name;
                textBox4.Text = fontDialog1.Font.Style.ToString();
                textBox5.Text = (Math.Round(fontDialog1.Font.Size)).ToString();
            }
                

        }

        private void add_text_blocks_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
