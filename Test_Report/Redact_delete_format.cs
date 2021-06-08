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
    public partial class Redact_delete_format : Form
    {
        public Redact_delete_format()
        {
            InitializeComponent();
        }

        public void Load_Format()
        {
            Diploma.Format f = new Diploma.Format();
            List<Diploma.Format> n = f.Select_Formats(Program.connection_str);
            dataGridView1.RowCount = n.Count;
            for (int i = 0; i < n.Count; i++)
            {
                dataGridView1[0, i].Value = n[i].Name_format;
                dataGridView1[1, i].Value = n[i].Width;
                dataGridView1[2, i].Value = n[i].Height;
                dataGridView1[3, i].Value = n[i].id;
            }

        }
        private void Redact_delete_format_Load(object sender, EventArgs e)
        {
            Load_Format();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows != null)
            {

            
            int tt = Convert.ToInt32(dataGridView1.SelectedCells[0].RowIndex);
                Diploma.Format f = new Diploma.Format();
                int id = Convert.ToInt32(dataGridView1[3, tt].Value);
                f.Delete_Format(id, Program.connection_str);
                MessageBox.Show("Удаление  успешно!");
                Load_Format();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {

                Insert_format i = new Insert_format();
                int tt = Convert.ToInt32(dataGridView1.SelectedCells[0].RowIndex);
                Diploma.Format f = new Diploma.Format();
                int id = Convert.ToInt32(dataGridView1[3, tt].Value);
                f = f.Select_format_id(id, Program.connection_str);
                i.textBox1.Text = f.Name_format;
                i.numericUpDown1.Value = f.Width;
                i.numericUpDown2.Value = f.Height;
                if(i.ShowDialog() == DialogResult.OK)
                {
                    f.Update_format(f.id, i.textBox1.Text, Convert.ToInt32(i.numericUpDown2.Value), Convert.ToInt32(i.numericUpDown1.Value), Program.connection_str);
                    MessageBox.Show("Редактирование успешно!");
                }
                
                Load_Format();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
