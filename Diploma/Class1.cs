using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma
{
    public  class Diploma
    {
        string connection_string = "";
        public Diploma(string new_connection_string) // конструктор, в котором указывается подключение к БД
        {
            connection_string = new_connection_string;
        }


        public void Diploma_add_maquette()
        {
            Maquette a = new Maquette();

        }
    }
    public class Maquette 
    {
        int id;
        string Name_maquette;
        string Background_image;
       string Background_color;
         int Height;
        int Width;

        public void add_maquette()
        {

        }

        public void delete_maquette()
        {

        }

        public List <Maquette> select_maquetts()
        {
            List<Maquette> m = new List<Maquette>();
            return m;
        }

        public Maquette select_maquette(int id)
        {
            Maquette m = new Maquette();
            return m;
        }
        public void update_maquette()
        {

        }
    }

    public class Text_blocks
    {
        int id;
        string Name_blocks;
        string Content;
        string Font_type;
        string Alignment_text;
        string Mark_text;
        int Font_size;
        int Height;
        int Width;
        int X;
        int Y;
        int id_maquette_fk;

        public void add_text_blocks()
        {

        }

        public void delete_text_blocks()
        {

        }

        public List<Text_blocks> select_text_blocks()
        {
            List<Text_blocks> m = new List<Text_blocks>();
            return m;
        }

        public Text_blocks select_text_blocks(int id)
        {
            Text_blocks m = new Text_blocks();
            return m;
        }
        public void update_text_blocks()
        {

        }

    }

    public class Image_blocks
    {
        int id;
        string Name_blocks;
        string Image_content;
        int Height;
        int Width;
        int X;
        int Y;
        int id_maquette_fk;

        public void add_text_blocks()
        {

        }

        public void delete_image_blocks()
        {

        }

        public List<Image_blocks> select_image_blocks()
        {
            List<Image_blocks> m = new List<Image_blocks>();
            return m;
        }

        public Image_blocks select_image_blocks(int id)
        {
            Image_blocks m = new Image_blocks();
            return m;
        }
        public void update_image_blocks()
        {

        }
    }
}
