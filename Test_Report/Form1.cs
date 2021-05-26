using FastReport;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Test_Report
{
    public partial class Form1 : Form
    {
          public Form1()
        {
            InitializeComponent();
        }
        int id_pic = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Diploma.Diploma di = new Diploma.Diploma(Program.connection_str);
            Diploma.Format n = comboBox1.Items[comboBox1.SelectedIndex] as Diploma.Format;
            Report report = di.Test_Report("yfhfhjfhjdfgd", n.Height, n.Width);
            report.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        
        public void Load_format()
        {
           
            comboBox1.DataSource = null;
            Diploma.Format f = new Diploma.Format();
            List<Diploma.Format> n = f.Select_Formats(Program.connection_str);


            // comboBox1.Items.Add(new Diploma.Format(n[0]));
            //  comboBox1.Items.Add(new Diploma.Format(n[1]));
            comboBox1.DataSource = n;
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Load_format();

            if (Program.Maquette_id == 0)
            {
                label2.Text = "Макет не выбран!";
            }
            else
            {
                label2.Text = Program.Maquette_id.ToString();
            }


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
                     Program.connection_str);

                if (s)
                {
                    MessageBox.Show("Формат успешно добавлен!");
                    Load_format();

                }
                else
                {
                    int k = f.Select_format(Convert.ToInt32(fo.numericUpDown1.Value), Convert.ToInt32(fo.numericUpDown2.Value),
                    Program.connection_str);
                    string d = f.Select_name_format(k,
                   Program.connection_str);
                    MessageBox.Show("Данный формат уже существует под именем " + d);
                }
            }
           
        }

        private void работаСоСтрокойПодключенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connect_form c = new Connect_form();
            c.textBox1.Text = Program.connection_str;
            if (c.ShowDialog() == DialogResult.OK)
            {
                Program.connection_str = c.textBox1.Text.Trim();


            }
        }

        private void добавлениеФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_add_maquette add = new Form_add_maquette();
            if (add.ShowDialog() == DialogResult.OK)
            {
                File.Copy(add.label2.Text, "Maquette//" + Path.GetFileName(add.label2.Text));
                Diploma.Maquette ma = new Diploma.Maquette();
                int id = (add.comboBox1.Items[add.comboBox1.SelectedIndex] as Diploma.Format).id;
                ma.Add_maquette(add.textBox1.Text, Path.GetFileName(add.label2.Text), add.pictureBox2.BackColor.ToString(), Convert.ToInt32(add.numericUpDown1.Value), Convert.ToInt32(add.numericUpDown2.Value),id, Program.connection_str);

            }
        }

        private void выборФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_maquette_gallery ga = new Form_maquette_gallery();
            if (ga.ShowDialog() == DialogResult.OK)
            {
                if (ga.radioButton1.Checked)
                {
                    id_pic = Convert.ToInt32(ga.radioButton1.Text);
                   // pictureBox1.Image = (ga.pictureBox1.Image);
                }
                else if (ga.radioButton2.Checked)
                {
                    id_pic = Convert.ToInt32(ga.radioButton2.Text);
                   // pictureBox1.Image = (ga.pictureBox2.Image);
                }
                else if (ga.radioButton3.Checked)
                {
                    id_pic = Convert.ToInt32(ga.radioButton3.Text);
                   // pictureBox1.Image = (ga.pictureBox3.Image);
                }

                Program.Maquette_id = id_pic;
                // Diploma.Maquette l = new Diploma.Maquette();
                // Program.Maquette_name = f.dataGridView1[1, tt].Value.ToString();


                Diploma.Maquette m = new Diploma.Maquette();
                m = m.Select_maquette_id(Program.Maquette_id, Program.connection_str);
                label2.Text = m.Name_maquette;
                pictureBox1.Load("Maquette//" + m.Background_image);
                int k = 0;
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    Diploma.Format fff = comboBox1.Items[i] as Diploma.Format;
                    if (fff.id == m.id_fk_format)
                    {
                        k = i;
                        break;
                    }
                }
                Load_image_blocks();
                Load_text_blocks();
                comboBox1.SelectedIndex = k;
            }

           // Select_maquette f = new Select_maquette();
          //  if (f.ShowDialog() == DialogResult.OK)
            
               // int tt = Convert.ToInt32(f.dataGridView1.SelectedCells[0].RowIndex);
             //   int id = Convert.ToInt32(f.dataGridView1[0, tt].Value);
               
            }

        private void работаСТекстомToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            add_text_blocks();

        }

        private void редактроватьФорматToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redact_delete_format f = new Redact_delete_format();
            if (f.ShowDialog() == DialogResult.OK)
            {

            }
        }

        public void add_text_blocks()
        {
            add_text_blocks f = new add_text_blocks();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Diploma.Text_blocks t = new Diploma.Text_blocks();
                t.Add_text_blocks(f.textBox1.Text, f.textBox2.Text, f.textBox3.Text, f.comboBox1.Text,
                   f.textBox4.Text, Convert.ToInt32(f.textBox5.Text), Convert.ToInt32(f.numericUpDown3.Value),
                   Convert.ToInt32(f.numericUpDown4.Value), Convert.ToInt32(f.numericUpDown1.Value),
                   Convert.ToInt32(f.numericUpDown2.Value), Program.Maquette_id, Program.connection_str);

            }
            Load_text_blocks();
        }
        private void добавтьТекстовыйБлокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_text_blocks();
        }

        public void add_image_blocks()
        {
            Add_image_blоcks f = new Add_image_blоcks();
            if (f.ShowDialog() == DialogResult.OK)
            {

                File.Copy(f.label2.Text, "Image_blocks//" + Path.GetFileName(f.label2.Text));
                Diploma.Image_blocks i = new Diploma.Image_blocks();
                i.Add_image_blocks(f.textBox1.Text, Path.GetFileName(f.label2.Text), Convert.ToInt32(f.numericUpDown3.Value),
                    Convert.ToInt32(f.numericUpDown4.Value), Convert.ToInt32(f.numericUpDown1.Value),
                    Convert.ToInt32(f.numericUpDown2.Value), Program.Maquette_id, Program.connection_str);
            }
            Load_image_blocks();
        }
        private void добавтьГрафическийБлокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_image_blocks();
           
        }

        public void Load_text_blocks()
        {
            dataGridView1.RowCount = 1;
            dataGridView1[0, 0].Value = "";
            dataGridView1[1, 0].Value = "";
            Diploma.Text_blocks f = new Diploma.Text_blocks();
            List<Diploma.Text_blocks> tb = f.Select_text_blocks(Program.connection_str, Program.Maquette_id);
            
            if (tb.Count != 0)
            {
                dataGridView1.RowCount = tb.Count;
                for (int i = 0; i < tb.Count; i++)
                {
                    dataGridView1[0, i].Value = tb[i].id;
                    dataGridView1[1, i].Value = tb[i].Name_blocks;
                }
            }

        }

        public void Load_image_blocks()
        {
            dataGridView2.RowCount = 1;
            dataGridView2[0, 0].Value = "";
            dataGridView2[1, 0].Value = "";
            Diploma.Image_blocks f = new Diploma.Image_blocks();
            List<Diploma.Image_blocks> tb = f.Select_image_blocks(Program.connection_str, Program.Maquette_id);
            if (tb.Count != 0)
            {
             dataGridView2.RowCount = tb.Count;
                for (int i = 0; i < tb.Count; i++)
                {
                     dataGridView2[0, i].Value = tb[i].id;
                     dataGridView2[1, i].Value = tb[i].Name_blocks;
                }
            }
            
            
        }
        private void выборМакетаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Select_maquette f = new Select_maquette();
            if (f.ShowDialog() == DialogResult.OK)
            {
                int tt = Convert.ToInt32(f.dataGridView1.SelectedCells[0].RowIndex);
                int id = Convert.ToInt32(f.dataGridView1[0, tt].Value);
                Program.Maquette_id = id;

                Program.Maquette_name = f.dataGridView1[1, tt].Value.ToString();
                label2.Text = Program.Maquette_name.ToString();

                Diploma.Maquette m = new Diploma.Maquette();
                m = m.Select_maquette_id(Program.Maquette_id, Program.connection_str);
                pictureBox1.Load("Maquette//" + m.Background_image);
                int k = 0;
                for (int i=0; i<comboBox1.Items.Count; i++)
                {
                    Diploma.Format fff = comboBox1.Items[i] as Diploma.Format;
                    if (fff.id == m.id_fk_format)
                    {
                        k = i;
                        break;
                    }
                }
                Load_image_blocks();
                Load_text_blocks();
                comboBox1.SelectedIndex = k;
               // comboBox1.SelectedValue = m.id_fk_format;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_add2_Click(object sender, EventArgs e)
        {
            add_image_blocks();
        }

        private void button_delete1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {

                int tt = Convert.ToInt32(dataGridView1.SelectedCells[0].RowIndex);
                Diploma.Text_blocks f = new Diploma.Text_blocks();
                int id = Convert.ToInt32(dataGridView1[0, tt].Value);
                f.Delete_text_blocks(id, Program.connection_str);
                Load_text_blocks();
            }
        }

        private void button_delete2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows != null)
            {

                int tt = Convert.ToInt32(dataGridView2.SelectedCells[0].RowIndex);
                Diploma.Image_blocks f = new Diploma.Image_blocks();
                int id = Convert.ToInt32(dataGridView2[0, tt].Value);
                f.Delete_image_blocks(id, Program.connection_str);
                Load_image_blocks();
            }
        }

        private void button_update1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {

                add_text_blocks i = new add_text_blocks();
                int tt = Convert.ToInt32(dataGridView1.SelectedCells[0].RowIndex);
                Diploma.Text_blocks f = new Diploma.Text_blocks();
                int id = Convert.ToInt32(dataGridView1[0, tt].Value);
                f = f.Select_text_blocks_id(id, Program.connection_str);
                i.textBox1.Text = f.Name_blocks;
                i.textBox2.Text = f.Content;
                i.numericUpDown1.Value = f.X;
                i.numericUpDown2.Value = f.Y;
                i.numericUpDown3.Value = f.Height;
                i.numericUpDown4.Value = f.Width;
                i.comboBox1.Text = f.Alignment_text;
                i.textBox3.Text = f.Font_type;
                i.textBox4.Text = f.Mark_text;
                i.textBox5.Text = f.Font_size.ToString();

                if (i.ShowDialog() == DialogResult.OK)
                {
                    f.Update_text_blocks(f.id, i.textBox1.Text, i.textBox2.Text, i.textBox3.Text, i.comboBox1.Text,
                  i.textBox4.Text, Convert.ToInt32(i.textBox5.Text), Convert.ToInt32(i.numericUpDown3.Value),
                  Convert.ToInt32(i.numericUpDown4.Value), Convert.ToInt32(i.numericUpDown1.Value),
                  Convert.ToInt32(i.numericUpDown2.Value), Program.connection_str);

                    
                }

                Load_text_blocks();
            }
        }

        private void button_update2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows != null)
            {
                Add_image_blоcks i = new Add_image_blоcks();
                int tt = Convert.ToInt32(dataGridView2.SelectedCells[0].RowIndex);
                Diploma.Image_blocks f = new Diploma.Image_blocks();
                int id = Convert.ToInt32(dataGridView2[0, tt].Value);
                f = f.Select_image_blocks_id(id, Program.connection_str);
                i.textBox1.Text = f.Name_blocks;
                i.numericUpDown1.Value = f.X;
                i.numericUpDown2.Value = f.Y;
                i.numericUpDown3.Value = f.Height;
                i.numericUpDown4.Value = f.Width;
                i.label2.Text = f.Image_content;
                i.pictureBox1.Load("Image_blocks//" + f.Image_content);

                if (i.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(i.label2.Text, "Image_blocks//" + Path.GetFileName(i.label2.Text));
                    }
                    catch
                    {

                    }
                    f.Update_image_blocks(f.id, i.textBox1.Text, Path.GetFileName(i.label2.Text), Convert.ToInt32(i.numericUpDown3.Value),
                    Convert.ToInt32(i.numericUpDown4.Value), Convert.ToInt32(i.numericUpDown1.Value),
                    Convert.ToInt32(i.numericUpDown2.Value), Program.connection_str);

                }

                Load_image_blocks();
            }
        }

        private void редактированиеМакетаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_add_maquette i = new Form_add_maquette();
           
            i.comboBox1.DataSource = null;
            Diploma.Format fd = new Diploma.Format();
            List<Diploma.Format> n = fd.Select_Formats(Program.connection_str);


            // comboBox1.Items.Add(new Diploma.Format(n[0]));
            //  comboBox1.Items.Add(new Diploma.Format(n[1]));
            i.comboBox1.DataSource = n;
            i.comboBox1.SelectedIndex = 0;

            Diploma.Maquette f = new Diploma.Maquette();
            int id = Program.Maquette_id;
            f = f.Select_maquette_id(id, Program.connection_str);
            i.textBox1.Text = f.Name_maquette;
            i.numericUpDown1.Value = f.Height;
            i.numericUpDown2.Value = f.Width;
            i.label2.Text = f.Background_image;
            int k = 0;
            for (int j = 0; j < i.comboBox1.Items.Count; j++)
            {
                Diploma.Format fff = i.comboBox1.Items[j] as Diploma.Format;
                if (fff.id == f.id_fk_format)
                {
                    k = j;
                    break;
                }
            }
  
            i.comboBox1.SelectedIndex = k;

            string str = "Color [A=255, R=230, G=200, B=231]";
            MatchCollection p = Regex.Matches(str, @"(?<=[ARGB]\=)(\d+)");
            Color color1 = Color.FromArgb(int.Parse(p[0].Value),
                              int.Parse(p[1].Value), int.Parse(p[2].Value), int.Parse(p[3].Value));
            Color color2 = Color.FromName(f.Background_color);

            if (color1 != null)
            {
                i.pictureBox2.BackColor = color1;

            }
            else if(color2 != null)
            {
                i.pictureBox2.BackColor = color2;
            }

            // System.Drawing.Color cl = new System.Drawing.Color();

            // i.pictureBox1.BackColor = new System.Drawing.Color();
            i.pictureBox1.Load("Maquette//" + f.Background_image);

            if (i.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.Copy(i.label2.Text, "Maquette//" + Path.GetFileName(i.label2.Text));
                }
                catch
                {

                }
                int id_f = (i.comboBox1.Items[i.comboBox1.SelectedIndex] as Diploma.Format).id;
                f.Update_maquette(Program.Maquette_id, i.textBox1.Text, Path.GetFileName(i.label2.Text), i.pictureBox2.BackColor.ToString(),
                    Convert.ToInt32(i.numericUpDown1.Value), Convert.ToInt32(i.numericUpDown2.Value), id_f, Program.connection_str);
                

            }

            Program.Maquette_id = id_pic;
            // Diploma.Maquette l = new Diploma.Maquette();
            // Program.Maquette_name = f.dataGridView1[1, tt].Value.ToString();


            Diploma.Maquette m = new Diploma.Maquette();
            m = m.Select_maquette_id(Program.Maquette_id, Program.connection_str);
            label2.Text = m.Name_maquette;
            pictureBox1.Load("Maquette//" + m.Background_image);
            int k2 = 0;
            for (int i2 = 0; i2 < comboBox1.Items.Count; i2++)
            {
                Diploma.Format fff = comboBox1.Items[i2] as Diploma.Format;
                if (fff.id == m.id_fk_format)
                {
                    k2 = i2;
                    break;
                }
            }
            Load_image_blocks();
            Load_text_blocks();
            comboBox1.SelectedIndex = k2;
        }
    }
}
