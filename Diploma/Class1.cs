using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public void Diploma_delete_maquette(int nid)
        {
            Maquette a = new Maquette();
            a.delete_maquette(nid, connection_string);
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

        public Maquette()
        {

        }

        public Maquette(int nid, string nName_maquette, string nBackground_image, string nBackground_color, int nHeight, int nWidth)
        {
            int id = nid;
            string Name_maquette = nName_maquette;
            string Background_image = nBackground_image;
            string Background_color = nBackground_color;
            int Height = nHeight ;
            int Width = nWidth;
        }
        
        public void add_maquette(string nName_maquette, string nBackground_image, string nBackground_color, int nHeight, int nWidth, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);
            conn.Open();
            string d = "SELECT MAX(id) FROM Maquette";
            SqlCommand command = new SqlCommand(d, conn);
            SqlDataReader reader = command.ExecuteReader();
            int count_id = 0;

            if (reader.HasRows)
            {
                reader.Read();
                count_id = Convert.ToInt32(reader.GetValue(0)) + 1;
                conn.Close();
            }

            if (count_id == 0)
            {
                count_id++;
            }
            conn.Open();
            string z = "INSERT INTO Maquette(id, Name_maquette, Background_image, Background_color, Height, Width) " +
                "VALUES ( " + count_id + ", '" + nName_maquette + "', '" + nBackground_image + "', " +
                "'" + nBackground_color + "', " + nHeight + "," + nWidth + " )";
            SqlCommand command2 = new SqlCommand(z, conn);
            command2.ExecuteNonQuery();
            conn.Close();
        }

        public void delete_maquette(int nid, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            conn.Open();
            string z = "DELETE FROM Maquette WHERE id =" + nid;
            SqlCommand command2 = new SqlCommand(z, conn);
            command2.ExecuteNonQuery();
            conn.Close();
        }

        public List <Maquette> select_maquetts(string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            List<Maquette> m = new List<Maquette>();
            conn.Open();
            string s = "SELECT * FROM Maquette";
            SqlCommand command = new SqlCommand(s, conn);
            SqlDataReader reader = command.ExecuteReader();
            int k = 0;
            int c = 0;
            while (reader.Read())
            {

                Maquette maq = new Maquette(Convert.ToInt32(reader.GetValue(0)),
                        Convert.ToString(reader.GetValue(1)),
                        Convert.ToString(reader.GetValue(2)),
                        Convert.ToString(reader.GetValue(3)),
                         Convert.ToInt32(reader.GetValue(4)),
                         Convert.ToInt32(reader.GetValue(5))
                        );
                m.Add(maq);
                k++;

            }

            return m;
        }

        public Maquette select_maquette(int nid, string nconnection_string)
        {
            

            SqlConnection conn = new SqlConnection(nconnection_string);
            conn.Open();
            string s = "SELECT * FROM Maquette WHERE id =" + nid;
            SqlCommand command = new SqlCommand(s, conn);
            SqlDataReader reader = command.ExecuteReader();
            Maquette m = null;
            while (reader.Read())
            {

                m = new Maquette(Convert.ToInt32(reader.GetValue(0)),
                        Convert.ToString(reader.GetValue(1)),
                        Convert.ToString(reader.GetValue(2)),
                        Convert.ToString(reader.GetValue(3)),
                         Convert.ToInt32(reader.GetValue(4)),
                         Convert.ToInt32(reader.GetValue(5))
                        );
            }
            return m;
        }
        public void update_maquette(int nid, string nName_maquette, string nBackground_image, string nBackground_color, int nHeight, int nWidth, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            conn.Open();
            string z = "UPDATE Maquette SET Name_maquette = '" + nName_maquette + "', Background_image = '" + nBackground_image + "', " +
                "Background_color = '" + nBackground_color + "', Height = " + nHeight + ", Width = " + nWidth + " WHERE id = " + nid;
            SqlCommand command2 = new SqlCommand(z, conn);
            command2.ExecuteNonQuery();
            conn.Close();
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

        public Text_blocks()
        {

        }
        public Text_blocks(int nid, string nName_blocks, string nContent, string nFont_type, string nAlignment_text,
            string nMark_text, int nFont_size, int nHeight, int nWidth, int nX, int nY, int nid_maquette_fk)
        {
            int id = nid;
            string Name_blocks = nName_blocks;
            string Content = nContent ;
            string Font_type = nFont_type;
            string Alignment_text = nAlignment_text ;
            string Mark_text = nMark_text ;
            int Font_size = nFont_size;
            int Height = nHeight ;
            int Width = nWidth ;
            int X = nX;
            int Y = nY ;
            int id_maquette_fk = nid_maquette_fk;
        }

        public void add_text_blocks(string nName_blocks, string nContent, string nFont_type, string nAlignment_text,  
            string nMark_text, int nFont_size,  int nHeight, int nWidth, int nX, int nY, int nid_maquette_fk, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);
            conn.Open();
            string d = "SELECT MAX(id) FROM Text_blocks";
            SqlCommand command = new SqlCommand(d, conn);
            SqlDataReader reader = command.ExecuteReader();
            int count_id = 0;

            if (reader.HasRows)
            {
                reader.Read();
                count_id = Convert.ToInt32(reader.GetValue(0)) + 1;
                conn.Close();
            }

            if (count_id == 0)
            {
                count_id++;
            }
            conn.Open();
            string z = "INSERT INTO Text_blocks(id, Name_blocks, Content, " +
                "Font_type, Alignment_text,Mark_text, Font_size, Height,Width, X, Y, id_maquette_fk) " +
                "VALUES ( "+count_id+", '"+nName_blocks +"', '"+nContent + "', " + nFont_type+ ", '" +nAlignment_text +"'," +
                " '" + nMark_text+ "', '" +nFont_size + "', " +nHeight + "," + nWidth+ " ," +nX + "," +nY +" )";
            SqlCommand command2 = new SqlCommand(z, conn);
            command2.ExecuteNonQuery();
            conn.Close();
        }

        public void delete_text_blocks(int nid, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            conn.Open();
            string z = "DELETE FROM Text_blocks WHERE id =" + nid;
            SqlCommand command2 = new SqlCommand(z, conn);
            command2.ExecuteNonQuery();
            conn.Close();
        }

        public List<Text_blocks> select_text_blocks(string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            List<Text_blocks> m = new List<Text_blocks>();
            conn.Open();
            string s = "SELECT * FROM Text_blocks";
            SqlCommand command = new SqlCommand(s, conn);
            SqlDataReader reader = command.ExecuteReader();
            int k = 0;
            int c = 0;
            while (reader.Read())
            {

                Text_blocks maq = new Text_blocks(Convert.ToInt32(reader.GetValue(0)),
                        Convert.ToString(reader.GetValue(1)),
                        Convert.ToString(reader.GetValue(2)),
                        Convert.ToString(reader.GetValue(3)),
                        Convert.ToString(reader.GetValue(4)),
                         Convert.ToString(reader.GetValue(5)),
                         Convert.ToInt32(reader.GetValue(6)),
                         Convert.ToInt32(reader.GetValue(7)),
                         Convert.ToInt32(reader.GetValue(8)),
                         Convert.ToInt32(reader.GetValue(9)),
                         Convert.ToInt32(reader.GetValue(10)),
                         Convert.ToInt32(reader.GetValue(11))
                        );
                    m.Add(maq);
                    k++;
                
            }

            return m;
        }

        public Text_blocks select_text_block(int nid, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);
            conn.Open();
            string s = "SELECT * FROM Text_blocks WHERE id =" + nid;
            SqlCommand command = new SqlCommand(s, conn);
            SqlDataReader reader = command.ExecuteReader();
            Text_blocks m=null;
            while (reader.Read())
            {

                     m = new Text_blocks(Convert.ToInt32(reader.GetValue(0)),
                        Convert.ToString(reader.GetValue(1)),
                        Convert.ToString(reader.GetValue(2)),
                        Convert.ToString(reader.GetValue(3)),
                        Convert.ToString(reader.GetValue(4)),
                         Convert.ToString(reader.GetValue(5)),
                         Convert.ToInt32(reader.GetValue(6)),
                         Convert.ToInt32(reader.GetValue(7)),
                         Convert.ToInt32(reader.GetValue(8)),
                         Convert.ToInt32(reader.GetValue(9)),
                         Convert.ToInt32(reader.GetValue(10)),
                         Convert.ToInt32(reader.GetValue(11))
                        );
               
            }
            return m;
        }
        public void update_text_blocks(int nid, string nName_blocks, string nContent, string nFont_type, string nAlignment_text,
            string nMark_text, int nFont_size, int nHeight, int nWidth, int nX, int nY,  string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            conn.Open();
            string z = "UPDATE Text_blocks SET Name_blocks = '" + nName_blocks + "', Content = '" + nContent + "', " +
                "Font_type = '" + nFont_type + "', Alignment_text = '" + nAlignment_text + "', " +
                "Mark_text = '" + nMark_text + "', Font_size = " + nFont_size + ", Height = " + nHeight + ", " +
                "Width = " + nWidth + ", X = " + nX + ", Y = " + nY + " WHERE id = " + nid;
            SqlCommand command2 = new SqlCommand(z, conn);
            command2.ExecuteNonQuery();
            conn.Close();

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

        public Image_blocks()
        {

        }
        public Image_blocks(int nid, string nName_blocks, string nImage_content,  int nHeight, int nWidth, int nX, int nY, int nid_maquette_fk)
        {
            int id = nid;
            string Name_blocks = nName_blocks;
            string Image_content = nImage_content;
            int Height = nHeight;
            int Width = nWidth;
            int X = nX;
            int Y = nY;
            int id_maquette_fk = nid_maquette_fk;
        }
        public void add_image_blocks(string nName_blocks, string nImage_content, int nHeight, int nWidth, int nX, int nY, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);
            conn.Open();
            string d = "SELECT MAX(id) FROM Image_blocks";
            SqlCommand command = new SqlCommand(d, conn);
            SqlDataReader reader = command.ExecuteReader();
            int count_id = 0;

            if (reader.HasRows)
            {
                reader.Read();
                count_id = Convert.ToInt32(reader.GetValue(0)) + 1;
                conn.Close();
            }

            if (count_id == 0)
            {
                count_id++;
            }
            conn.Open();
            string z = "INSERT INTO Image_blocks(id, Name_blocks, Image_content, Height, Width, X, Y) " +
                "VALUES ( " + count_id + ", '" + nName_blocks + "', '" + nImage_content + "', " +
                " " + nHeight + "," + nWidth + "," + nX + "," + nY + " )";
            SqlCommand command2 = new SqlCommand(z, conn);
            command2.ExecuteNonQuery();
            conn.Close();
        }

        public void delete_image_blocks(int nid, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            conn.Open();
            string z = "DELETE FROM Image_blocks WHERE id =" + nid;
            SqlCommand command2 = new SqlCommand(z, conn);
            command2.ExecuteNonQuery();
            conn.Close();
        }

        public List<Image_blocks> select_image_blocks(string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            List<Image_blocks> m = new List<Image_blocks>();
            conn.Open();
            string s = "SELECT * FROM Image_blocks";
            SqlCommand command = new SqlCommand(s, conn);
            SqlDataReader reader = command.ExecuteReader();
            int k = 0;
            int c = 0;
            while (reader.Read())
            {

                Image_blocks maq = new Image_blocks(Convert.ToInt32(reader.GetValue(0)),
                        Convert.ToString(reader.GetValue(1)),
                        Convert.ToString(reader.GetValue(2)),
                         Convert.ToInt32(reader.GetValue(3)),
                         Convert.ToInt32(reader.GetValue(4)),
                         Convert.ToInt32(reader.GetValue(5)),
                         Convert.ToInt32(reader.GetValue(6)),
                         Convert.ToInt32(reader.GetValue(7))
                        );
                m.Add(maq);
                k++;

            }
            return m;
        }

        public Image_blocks select_image_block(int nid, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);
            conn.Open();
            string s = "SELECT * FROM Image_blocks WHERE id =" + nid;
            SqlCommand command = new SqlCommand(s, conn);
            SqlDataReader reader = command.ExecuteReader();
            Image_blocks m = null;
            while (reader.Read())
            {

                m = new Image_blocks(Convert.ToInt32(reader.GetValue(0)),
                        Convert.ToString(reader.GetValue(1)),
                        Convert.ToString(reader.GetValue(2)),
                         Convert.ToInt32(reader.GetValue(3)),
                         Convert.ToInt32(reader.GetValue(4)),
                         Convert.ToInt32(reader.GetValue(5)),
                         Convert.ToInt32(reader.GetValue(6)),
                         Convert.ToInt32(reader.GetValue(7))
                        );
            }
           
            return m;
        }
        public void update_image_blocks(int nid, string nName_blocks, string nImage_content, int nHeight, int nWidth, int nX, int nY, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            conn.Open();
            string z = "UPDATE Image_blocks SET Name_blocks = '" + nName_blocks + "', Image_content = '" + nImage_content + "', " +
                "Height = " + nHeight + ", Width = " + nWidth + ", X = " + nX + ", Y = " + nY + " WHERE id = " + nid;
            SqlCommand command2 = new SqlCommand(z, conn);
            command2.ExecuteNonQuery();
            conn.Close();
        }
    }
}
