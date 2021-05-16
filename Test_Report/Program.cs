using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Report
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
          public static string connection_str =  @"Data Source = KRNALX\KRNALX; Initial Catalog = Diplomа_library; Integrated Security = True";
        public static int Maquette_id = 0;
        public static string Maquette_name = "";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
