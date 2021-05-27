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
    public partial class Add_image_blоcks : Form
    {
        public Add_image_blоcks()
        {
            InitializeComponent();
        }

        private void add_file_button_Click(object sender, EventArgs e)
        {
           if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                label2.Text = openFileDialog1.FileName;
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {

        }
    }
}
