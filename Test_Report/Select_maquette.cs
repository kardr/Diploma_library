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
    public partial class Select_maquette : Form
    {
        public Select_maquette()
        {
            InitializeComponent();
        }
        public void Load_Maquette()
        {
            Diploma.Maquette f = new Diploma.Maquette();
            List<Diploma.Maquette> n = f.Select_maquetts(Program.connection_str);
            dataGridView1.RowCount = n.Count;
            for (int i = 0; i < n.Count; i++)
            {
                dataGridView1[0, i].Value = n[i].id;
                dataGridView1[1, i].Value = n[i].Name_maquette;
                

            }
        }
        private void Select_maquette_Load(object sender, EventArgs e)
        {
            Load_Maquette();
        }
    }
}
