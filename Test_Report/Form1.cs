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
        public string connection_str =  @"Data Source = KRNALX\KRNALX; Initial Catalog = Diplomа_library; Integrated Security = True";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Diploma.Diploma di = new Diploma.Diploma(connection_str);
            Diploma.Format n = comboBox1.Items[comboBox1.SelectedIndex] as Diploma.Format;
            Report report = di.Test_Report("yfhfhjfhjdfgd", n.Height, n.Width);
            report.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Diploma.Format f = new Diploma.Format();
            List<Diploma.Format> n = f.Select_Formats(connection_str);
            
           
            // comboBox1.Items.Add(new Diploma.Format(n[0]));
            //  comboBox1.Items.Add(new Diploma.Format(n[1]));
            comboBox1.DataSource =n;
            comboBox1.SelectedIndex = 0;

         //   comboBox1.DisplayMember = "Name_format";
           // comboBox1.ValueMember = "id";

            //дописать отображение данных в комбобокс
        }

        private void добавитьНовыйФорматToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insert_format fo = new Insert_format();
            if (fo.ShowDialog() == DialogResult.OK)
            {



                Diploma.Format f = new Diploma.Format();
                bool s = f.Add_format(fo.textBox1.Text, Convert.ToInt32(fo.numericUpDown1.Value), Convert.ToInt32(fo.numericUpDown2.Value),
                     connection_str);

                if (s)
                {
                    MessageBox.Show("Формат успешно добавлен!");

                }
                else
                {
                    int k = f.Select_format(Convert.ToInt32(fo.numericUpDown1.Value), Convert.ToInt32(fo.numericUpDown2.Value),
                    connection_str);
                    string d = f.Select_name_format(k,
                   connection_str);
                    MessageBox.Show("Данный формат уже существует под именем " + d);
                }
            }
           
        }

        private void работаСоСтрокойПодключенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connect_form c = new Connect_form();
            c.textBox1.Text = connection_str;
            if (c.ShowDialog() == DialogResult.OK)
            {
                connection_str = c.textBox1.Text.Trim();


            }
        }

        private void добавлениеФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_add_maquette add = new Form_add_maquette();
            if (add.ShowDialog() == DialogResult.OK)
            {
                Diploma.Maquette ma = new Diploma.Maquette();
                ma.Add_maquette(add.textBox1.Text, add.pictureBox1.Image.ToString(), add.pictureBox2.BackColor.ToString(), Convert.ToInt32(add.numericUpDown1.Value), Convert.ToInt32(add.numericUpDown2.Value), connection_str);

            }
        }
    }
}
