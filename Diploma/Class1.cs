using FastReport;
using FastReport.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma
{
    public  class Diploma
    {
       
        string connection_string = "";
        Report report;
        List<ReportPage> page = new List<ReportPage>();
        public Diploma(string new_connection_string) // конструктор, в котором указывается подключение к БД
        {
            connection_string = new_connection_string;
            report = new Report();
        }

       public Report Create_maquette_fasrreport(int nid)
        {
            Maquette m = new Maquette();
            m = m.Select_maquette_id(nid, connection_string);
            Format f = new Format();
            f = f.Select_format_id(m.id_fk_format, connection_string);
            Add_report_page(f.Width, f.Height);
            report.Pages.Add(page[0]);

            page[0].ReportTitle = new ReportTitleBand();
            page[0].ReportTitle.Name = "lkjhljkhlhnljkn";
            // set its height to 1.5cm
            page[0].ReportTitle.Height = Units.Millimeters*f.Height;
            PictureObject picture = new PictureObject();
            //picture.ForceLoadImage("C://Users//Svetlana//Desktop//1.jpg");

            float w = Convert.ToSingle( Math.Round(f.Width * 3.8));
            float h = Convert.ToSingle(Math.Round(f.Height * 3.8));
            picture.Bounds = new RectangleF(0, 0, w, h); //Set object bounds
            String s = Environment.CurrentDirectory + "\\Maquette\\" + m.Background_image;

            // Bitmap b1 = new Bitmap(s);
            // Bitmap b2 = new Bitmap(b1, new Size(f.Width*4, f.Height*4));


            // picture.Image = b2; //Set picture

            picture.Image = new Bitmap(s); //Set picture
            page[0].ReportTitle.Objects.Add(picture);


            Text_blocks t = new Text_blocks();
            List<Text_blocks> tb = t.Select_text_blocks(connection_string, nid);
            for(int i=0; i<tb.Count; i++)
            {
                TextObject txt = new TextObject();
                float wt = Convert.ToSingle(Math.Round(tb[i].Width * 3.8));
                float ht = Convert.ToSingle(Math.Round(tb[i].Height * 3.8));
                txt.Bounds = new RectangleF(tb[i].X, tb[i].Y, wt, ht);
                txt.Text = tb[i].Content;
                if (tb[i].Alignment_text.Trim() == "По левому краю")
                {
                    txt.HorzAlign = HorzAlign.Left;

                    /*По левому краю*/
                }
                else if(tb[i].Alignment_text.Trim() == "По центру")
                {
                    txt.HorzAlign = HorzAlign.Center; //По центру
                }

                else if (tb[i].Alignment_text.Trim() == "По правому краю")
                {
                    txt.HorzAlign = HorzAlign.Right; //По правому краю
                }

                else if (tb[i].Alignment_text.Trim() == "По ширине")
                {
                    txt.HorzAlign = HorzAlign.Justify; //По ширине
                }


                FontStyle styl=FontStyle.Regular;
                if (tb[i].Mark_text.Trim() == "Bold")
                {
                    styl = FontStyle.Bold;
                
                }

                else if (tb[i].Mark_text.Trim() == "Italic")
                {
                    styl = FontStyle.Italic;

                }

                else if (tb[i].Mark_text.Trim() == "Underline")
                {
                    styl = FontStyle.Underline;

                }

                else if (tb[i].Mark_text.Trim() == "Regular")
                {
                    styl = FontStyle.Regular;

                }

                else if (tb[i].Mark_text.Trim() == "Strikeout")
                {
                    styl = FontStyle.Strikeout;

                }
                FontFamily fam = new FontFamily(tb[i].Font_type);
                
                txt.Font = new Font(fam, tb[i].Font_size, styl);
                page[0].ReportTitle.Objects.Add(txt);

            }


            Image_blocks im = new Image_blocks();
            List<Image_blocks> bl = im.Select_image_blocks(connection_string, nid);
            for (int i = 0; i < bl.Count; i++)
            {
                PictureObject pict = new PictureObject();
                //picture.ForceLoadImage("C://Users//Svetlana//Desktop//1.jpg");

                float wp = Convert.ToSingle(Math.Round(bl[i].Width * 3.8));
                float hp = Convert.ToSingle(Math.Round(bl[i].Height * 3.8));
                pict.Bounds = new RectangleF(0, 0, wp, hp); //Set object bounds
                String sp = Environment.CurrentDirectory + "\\Image_blocks\\" + bl[i].Image_content;
                // Bitmap b1 = new Bitmap(s);
                // Bitmap b2 = new Bitmap(b1, new Size(f.Width*4, f.Height*4));


                // picture.Image = b2; //Set picture

                pict.Image = new Bitmap(sp); //Set picture
                page[0].ReportTitle.Objects.Add(pict);


            }


            return report;

        }
        public void Add_report_page(int widht, int height)
        {
            ReportPage page1 = new ReportPage();
            page.Add(page1);
            
            page[0].Name = "Page1";
            page[0].PaperWidth = widht;
            page[0].PaperHeight = height;
            report.Pages.Add(page[0]);
            page[0].LeftMargin = 0;
            page[0].RightMargin = 0;
            page[0].TopMargin = 0;
            page[0].BottomMargin = 0;
        }

        public void Diploma_add_maquette()
        {
            Maquette a = new Maquette();

        }
        public void Diploma_delete_maquette(int nid)
        {
            Maquette a = new Maquette();
            a.Delete_maquette(nid, connection_string);
        }

    }
    
    public class Format
    {
        public int id;
        public  string Name_format;
        public int Height;
        public  int Width;
        public Format()
        {

        }
        public Format(Format nF)
        {
            id = nF.id;
             Name_format = nF.Name_format;
            Height = nF.Height;
             Width = nF.Width;
        }

        public override string ToString()
        {
            return Name_format;

        }
        public Format(int nid, string nName_format, int nHeight, int nWidth)
        {
             id = nid;
             Name_format = nName_format;
             Height = nHeight;
             Width = nWidth;
        }
        public bool Add_format(string nName_format, int nWidth, int nHeight, string nconnection_string)
        {
            int k = Select_format(nWidth, nHeight, nconnection_string);
            if (k == 0)
            {


                SqlConnection conn = new SqlConnection(nconnection_string);
                conn.Open();
                string d = "SELECT MAX(id) FROM Format";
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
                string z = "INSERT INTO Format(id, Name_format, Height, Width) " +
                    "VALUES ( " + count_id + ", '" + nName_format + "', " + nHeight + "," + nWidth + " )";
                SqlCommand command2 = new SqlCommand(z, conn);
                command2.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
                return false;
        }

        public int Select_format(int nWidth, int nHeight, string nconnection_string)
        {
            int f = 0;
            SqlConnection conn = new SqlConnection(nconnection_string);
            conn.Open();
            string d = "SELECT * FROM Format WHERE Height = " + nHeight + " AND Width = " + nWidth + "";
            SqlCommand command = new SqlCommand(d, conn);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                f = Convert.ToInt32(reader.GetValue(0));
                conn.Close();
            }


            return f;
        }

        public string Select_name_format(int nid, string nconnection_string)
        {
            string s = "";
            SqlConnection conn = new SqlConnection(nconnection_string);
            conn.Open();
            string d = "SELECT * FROM Format WHERE id = " + nid + "";
            SqlCommand command = new SqlCommand(d, conn);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                s = reader.GetValue(1).ToString();
                conn.Close();
            }

            return s;
        }

        public List<Format> Select_Formats(string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            List<Format> m = new List<Format>();
            conn.Open();
            string s = "SELECT * FROM Format";
            SqlCommand command = new SqlCommand(s, conn);
            SqlDataReader reader = command.ExecuteReader();
            int k = 0;
            //int c = 0;
            while (reader.Read())
            {

                Format maq = new Format(Convert.ToInt32(reader.GetValue(0)),
                        Convert.ToString(reader.GetValue(1)),
                         Convert.ToInt32(reader.GetValue(2)),
                         Convert.ToInt32(reader.GetValue(3))
                        );
                m.Add(maq);
                k++;

            }

            return m;
        }
        //добавть удаление макета по Id
        public void Delete_Format(int nid, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            conn.Open();
            string z = "DELETE FROM Format WHERE id =" + nid;
            SqlCommand command2 = new SqlCommand(z, conn);
            command2.ExecuteNonQuery();
            conn.Close();
        }

        public Format Select_format_id(int nid, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            conn.Open();
            string z = "SELECT * FROM Format WHERE id =" + nid;
            SqlCommand command2 = new SqlCommand(z, conn);
            SqlDataReader reader = command2.ExecuteReader();
            //int c = 0;
            reader.Read();
            

             Format f = new Format(Convert.ToInt32(reader.GetValue(0)),
                        Convert.ToString(reader.GetValue(1)),
                         Convert.ToInt32(reader.GetValue(2)),
                         Convert.ToInt32(reader.GetValue(3))
                        );
               
            conn.Close();
            return f;
        }

        public void Update_format(int nid, string nName_format, int nHeight, int nWidth, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            conn.Open();
            string z = "UPDATE Format SET Name_format = '" + nName_format + "', Height = " + nHeight + ", Width = " + nWidth + " WHERE id = " + nid;
            SqlCommand command2 = new SqlCommand(z, conn);
            command2.ExecuteNonQuery();
            conn.Close();
        }
    }

    public class Maquette 
    {
       public int id;
        public string Name_maquette;
        public string Background_image;
        public string Background_color;
        public int Height;
        public int Width;
        public int id_fk_format;

        public Maquette()
        {

        }

        public Maquette(int nid, string nName_maquette, string nBackground_image, string nBackground_color, int nHeight, int nWidth, int nid_fk_format)
        {
            id = nid;
            Name_maquette = nName_maquette;
            Background_image = nBackground_image;
            Background_color = nBackground_color;
             Height = nHeight ;
             Width = nWidth;
            id_fk_format = nid_fk_format;
        }
        
        public void Add_maquette(string nName_maquette, string nBackground_image, string nBackground_color, int nHeight, int nWidth, int nid, string nconnection_string)
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
            string z = "INSERT INTO Maquette(id, Name_maquette, Background_image, Background_color, Height, Width, id_fk_format) " +
                "VALUES ( " + count_id + ", '" + nName_maquette + "', '" + nBackground_image + "', " +
                "'" + nBackground_color + "', " + nHeight + "," + nWidth + " ,"+nid+")";
            SqlCommand command2 = new SqlCommand(z, conn);
            command2.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete_maquette(int nid, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            conn.Open();
            string z = "DELETE FROM Maquette WHERE id =" + nid;
            SqlCommand command2 = new SqlCommand(z, conn);
            command2.ExecuteNonQuery();
            conn.Close();
        }

        public List <Maquette> Select_maquetts(string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            List<Maquette> m = new List<Maquette>();
            conn.Open();
            string s = "SELECT * FROM Maquette";
            SqlCommand command = new SqlCommand(s, conn);
            SqlDataReader reader = command.ExecuteReader();
            int k = 0;
            //int c = 0;
            while (reader.Read())
            {

                Maquette maq = new Maquette(Convert.ToInt32(reader.GetValue(0)),
                        Convert.ToString(reader.GetValue(1)),
                        Convert.ToString(reader.GetValue(2)),
                        Convert.ToString(reader.GetValue(3)),
                         Convert.ToInt32(reader.GetValue(4)),
                         Convert.ToInt32(reader.GetValue(5)),
                         Convert.ToInt32(reader.GetValue(8))
                        );
                m.Add(maq);
                k++;

            }

            return m;
        }

        public Maquette Select_maquette(int nid, string nconnection_string)
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
                         Convert.ToInt32(reader.GetValue(5)),
                         Convert.ToInt32(reader.GetValue(8))
                        );
            }
            return m;
        }

        public Maquette Select_maquette_id(int nid, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            conn.Open();
            string z = "SELECT * FROM Maquette WHERE id =" + nid;
            SqlCommand command2 = new SqlCommand(z, conn);
            SqlDataReader reader = command2.ExecuteReader();
            //int k = 0;
            //int c = 0;
            reader.Read();


            Maquette m = new Maquette(Convert.ToInt32(reader.GetValue(0)),
                        Convert.ToString(reader.GetValue(1)),
                        Convert.ToString(reader.GetValue(2)),
                        Convert.ToString(reader.GetValue(3)),
                         Convert.ToInt32(reader.GetValue(4)),
                         Convert.ToInt32(reader.GetValue(5)),
                           Convert.ToInt32(reader.GetValue(8))
                        );

            conn.Close();
            return m;
        }
        public void Update_maquette(int nid, string nName_maquette, string nBackground_image, string nBackground_color, int nHeight, int nWidth, int nid_fk_format, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            conn.Open();
            string z = "UPDATE Maquette SET Name_maquette = '" + nName_maquette + "', Background_image = '" + nBackground_image + "', " +
                "Background_color = '" + nBackground_color + "', Height = " + nHeight + ", Width = " + nWidth + ", id_fk_format="+ nid_fk_format + " WHERE id = " + nid;
            SqlCommand command2 = new SqlCommand(z, conn);
            command2.ExecuteNonQuery();
            conn.Close();
        }
    }

 
    public class Text_blocks
    {
        public int id;
        public string Name_blocks;
        public string Content;
        public string Font_type;
        public string Alignment_text;
        public string Mark_text;
        public int Font_size;
        public int Height;
        public int Width;
        public int X;
        public int Y;
        public int id_maquette_fk;

        public Text_blocks()
        {

        }
        public Text_blocks(int nid, int nid_maquette_fk, string nName_blocks, string nContent, int nFont_size, string nFont_type, string nAlignment_text,
            string nMark_text,  int nHeight, int nWidth, int nX, int nY)
        {
             id = nid;
             Name_blocks = nName_blocks;
             Content = nContent ;
             Font_type = nFont_type;
             Alignment_text = nAlignment_text ;
             Mark_text = nMark_text ;
             Font_size = nFont_size;
             Height = nHeight ;
             Width = nWidth ;
             X = nX;
             Y = nY ;
             id_maquette_fk = nid_maquette_fk;
        }

        public void Add_text_blocks(string nName_blocks, string nContent, string nFont_type, string nAlignment_text,  
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
                "VALUES ( "+count_id+", '"+nName_blocks +"', '"+nContent + "', '" + nFont_type+ "', '" +nAlignment_text +"'," +
                " '" + nMark_text+ "', '" +nFont_size + "', " +nHeight + "," + nWidth+ " ," +nX + "," +nY +","+ nid_maquette_fk+" )";
            SqlCommand command2 = new SqlCommand(z, conn);
            command2.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete_text_blocks(int nid, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            conn.Open();
            string z = "DELETE FROM Text_blocks WHERE id =" + nid;
            SqlCommand command2 = new SqlCommand(z, conn);
            command2.ExecuteNonQuery();
            conn.Close();
        }

        public List<Text_blocks> Select_text_blocks(string nconnection_string, int Maquette_id)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            List<Text_blocks> m = new List<Text_blocks>();
            conn.Open();
            string s = "SELECT * FROM Text_blocks WHERE id_maquette_fk = " + Maquette_id;
            SqlCommand command = new SqlCommand(s, conn);
            SqlDataReader reader = command.ExecuteReader();
            int k = 0;
            //int c = 0;
            while (reader.Read())
            {

                Text_blocks maq = new Text_blocks(Convert.ToInt32(reader.GetValue(0)),
                        Convert.ToInt32(reader.GetValue(1)),
                        Convert.ToString(reader.GetValue(2)),
                        Convert.ToString(reader.GetValue(3)),
                        Convert.ToInt32(reader.GetValue(4)),
                         Convert.ToString(reader.GetValue(5)),
                         Convert.ToString(reader.GetValue(6)),
                         Convert.ToString(reader.GetValue(7)),
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

        public Text_blocks Select_text_block(int nid, string nconnection_string)
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
                        Convert.ToInt32(reader.GetValue(1)),
                        Convert.ToString(reader.GetValue(2)),
                        Convert.ToString(reader.GetValue(3)),
                        Convert.ToInt32(reader.GetValue(4)),
                         Convert.ToString(reader.GetValue(5)),
                         Convert.ToString(reader.GetValue(6)),
                         Convert.ToString(reader.GetValue(7)),
                         Convert.ToInt32(reader.GetValue(8)),
                         Convert.ToInt32(reader.GetValue(9)),
                         Convert.ToInt32(reader.GetValue(10)),
                         Convert.ToInt32(reader.GetValue(11))
                        );
               
            }
            return m;
        }
        public void Update_text_blocks(int nid, string nName_blocks, string nContent, string nFont_type, string nAlignment_text,
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

        public Text_blocks Select_text_blocks_id(int nid, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            conn.Open();
            string z = "SELECT * FROM Text_blocks WHERE id =" + nid;
            SqlCommand command2 = new SqlCommand(z, conn);
            SqlDataReader reader = command2.ExecuteReader();
            //int k = 0;
            //int c = 0;
            reader.Read();


            Text_blocks m = new Text_blocks(Convert.ToInt32(reader.GetValue(0)),
                        Convert.ToInt32(reader.GetValue(1)),
                        Convert.ToString(reader.GetValue(2)),
                        Convert.ToString(reader.GetValue(3)),
                        Convert.ToInt32(reader.GetValue(4)),
                         Convert.ToString(reader.GetValue(5)),
                         Convert.ToString(reader.GetValue(6)),
                         Convert.ToString(reader.GetValue(7)),
                         Convert.ToInt32(reader.GetValue(10)),
                         Convert.ToInt32(reader.GetValue(11)),
                          Convert.ToInt32(reader.GetValue(8)),
                         Convert.ToInt32(reader.GetValue(9))
                        );

            conn.Close();
            return m;
        }

    }

    public class Image_blocks
    {
        public int id;
        public string Name_blocks;
        public string Image_content;
        public int Height;
        public int Width;
        public int X;
        public int Y;
        public int id_maquette_fk;

        public Image_blocks()
        {

        }
        public Image_blocks(int nid, int nid_maquette_fk, string nName_blocks, string nImage_content,  int nHeight, int nWidth, int nX, int nY)
        {
             id = nid;
             Name_blocks = nName_blocks;
             Image_content = nImage_content;
             Height = nHeight;
             Width = nWidth;
            X = nX;
             Y = nY;
             id_maquette_fk = nid_maquette_fk;
        }
        public void Add_image_blocks(string nName_blocks, string nImage_content, int nHeight, int nWidth, int nX, int nY, int nid_maquette_fk, string nconnection_string)
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
            string z = "INSERT INTO Image_blocks(id, Name_blocks, Image_content, Height, Width, X, Y, id_maquette_fk) " +
                "VALUES ( " + count_id + ", '" + nName_blocks + "', '" + nImage_content + "', " +
                " " + nHeight + "," + nWidth + "," + nX + "," + nY + " ,"+ nid_maquette_fk + ")";
            SqlCommand command2 = new SqlCommand(z, conn);
            command2.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete_image_blocks(int nid, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            conn.Open();
            string z = "DELETE FROM Image_blocks WHERE id =" + nid;
            SqlCommand command2 = new SqlCommand(z, conn);
            command2.ExecuteNonQuery();
            conn.Close();
        }

        public List<Image_blocks> Select_image_blocks(string nconnection_string, int Maquette_id)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            List<Image_blocks> m = new List<Image_blocks>();
            conn.Open();
            string s = "SELECT * FROM Image_blocks WHERE id_maquette_fk = " + Maquette_id;
            SqlCommand command = new SqlCommand(s, conn);
            SqlDataReader reader = command.ExecuteReader();
            int k = 0;
            //int c = 0;
            while (reader.Read())
            {

                Image_blocks maq = new Image_blocks(Convert.ToInt32(reader.GetValue(0)),
                        Convert.ToInt32(reader.GetValue(1)),
                        Convert.ToString(reader.GetValue(2)),
                         Convert.ToString(reader.GetValue(3)),
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

        public Image_blocks Select_image_block(int nid, string nconnection_string)
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
                        Convert.ToInt32(reader.GetValue(1)),
                        Convert.ToString(reader.GetValue(2)),
                         Convert.ToString(reader.GetValue(3)),
                         Convert.ToInt32(reader.GetValue(4)),
                         Convert.ToInt32(reader.GetValue(5)),
                         Convert.ToInt32(reader.GetValue(6)),
                         Convert.ToInt32(reader.GetValue(7))
                        );
            }
           
            return m;
        }
       
        public void Update_image_blocks(int nid, string nName_blocks, string nImage_content, int nHeight, int nWidth, int nX, int nY, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            conn.Open();
            string z = "UPDATE Image_blocks SET Name_blocks = '" + nName_blocks + "', Image_content = '" + nImage_content + "', " +
                "Height = " + nHeight + ", Width = " + nWidth + ", X = " + nX + ", Y = " + nY + " WHERE id = " + nid;
            SqlCommand command2 = new SqlCommand(z, conn);
            command2.ExecuteNonQuery();
            conn.Close();
        }

        public Image_blocks Select_image_blocks_id(int nid, string nconnection_string)
        {
            SqlConnection conn = new SqlConnection(nconnection_string);

            conn.Open();
            string z = "SELECT * FROM Image_blocks WHERE id =" + nid;
            SqlCommand command2 = new SqlCommand(z, conn);
            SqlDataReader reader = command2.ExecuteReader();
            //int k = 0;
            //int c = 0;
            reader.Read();


            Image_blocks m = new Image_blocks(Convert.ToInt32(reader.GetValue(0)),
                        Convert.ToInt32(reader.GetValue(1)),
                        Convert.ToString(reader.GetValue(2)),
                         Convert.ToString(reader.GetValue(3)),
                         Convert.ToInt32(reader.GetValue(4)),
                         Convert.ToInt32(reader.GetValue(5)),
                         Convert.ToInt32(reader.GetValue(6)),
                         Convert.ToInt32(reader.GetValue(7))
                        );

            conn.Close();
            return m;
        }
    }
}
