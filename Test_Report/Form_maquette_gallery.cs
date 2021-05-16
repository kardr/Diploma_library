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
    public partial class Form_maquette_gallery : Form
    {
        public Form_maquette_gallery()
        {
            InitializeComponent();
        }
        int d = 0;
        List<Diploma.Maquette> maquettes;

        private void button2_Click(object sender, EventArgs e)
        {
            d++;
            Button_Enabled();
            Load_Image();
        }
        public void Load_Image()
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
                label1.Text = "";
            }
            if (pictureBox2.Image != null)
            {
                pictureBox2.Image.Dispose();
                pictureBox2.Image = null;
                label2.Text = "";
            }
            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Dispose();
                pictureBox3.Image = null;
                label3.Text = "";
            }
            int k = 0;
            for (int i = 0; i < maquettes.Count; i++)
            {
                k++;
                if (k % 3 == 1 && k / 3 == d)
                {
                    radioButton1.Text = maquettes[i].id.ToString();
                    label1.Text = maquettes[i].Name_maquette;
                    pictureBox1.Load("Maquette//" + maquettes[i].Background_image);
                }
                if (k % 3 == 2 && k / 3 == d)
                {
                    radioButton2.Text = maquettes[i].id.ToString();
                    label2.Text = maquettes[i].Name_maquette;
                    pictureBox2.Load("Maquette//" + maquettes[i].Background_image);
                }
                if (k % 3 == 0 && k / 3 == (d+1))
                {
                    radioButton3.Text = maquettes[i].id.ToString();
                    label3.Text = maquettes[i].Name_maquette;
                    pictureBox3.Load("Maquette//" + maquettes[i].Background_image);
                }
            }

        }
        private void Form_maquette_gallery_Load(object sender, EventArgs e)
        {
            Diploma.Maquette m = new Diploma.Maquette();
            maquettes = m.Select_maquetts(Program.connection_str);
            Load_Image();
            Button_Enabled();
        }

        public void Button_Enabled()
        {
            if (d <= 0)
            {
                button1.Enabled = false;

            }
            else
            {
                button1.Enabled = true;
            }
            if (d > (maquettes.Count / 3-1))
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            d--;
            Button_Enabled();
            Load_Image();
        }
    }
}
