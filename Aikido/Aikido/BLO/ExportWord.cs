using Aikido.DAO.Model;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using Spire.Doc.Formatting;
using System;
using System.Diagnostics;
using System.Drawing;

namespace Aikido.BLO
{
    public class ExportWord
    {
        public void CreateDocument(MemberInfo_ViewModel info, Image image , ref int i)
        {
            //Create New Word
            Document doc = new Document();
            if (image != null)
            {
                Image resize = (Image)(new Bitmap(image, new System.Drawing.Size(900, 1000)));
                doc.Background.Type = BackgroundType.Picture;
                doc.Background.Picture = resize;
               

            }

            //Add Section
            Spire.Doc.Section section = doc.AddSection();
            section.PageSetup.PageSize = PageSize.A4;
            section.PageSetup.Borders.Bottom.Space = 0;
            //Add Paragraph
            Paragraph pHeader = section.AddParagraph();
            //Header
            TextRange textRangel = pHeader.AppendText("HỒ SƠ HỌC VIÊN");
            textRangel.CharacterFormat.Bold = true;
            textRangel.CharacterFormat.TextColor = System.Drawing.Color.Blue;
            textRangel.CharacterFormat.FontSize = 24;
            textRangel.CharacterFormat.FontName = "Calibri Light (Headings)";
            pHeader.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
            pHeader.Format.AfterSpacing = 5;
            //SKU
            draw(doc, 210, 22, 20, 5, "SKU: " + info.SKU);
            //Register Number
            draw(doc, 210, 22, 260, -9, "SỐ ĐĂNG KÝ: " + info.RegisterNumber);
            //Name
            draw(doc, 450, 22, 20, 8, "HỌ TÊN: " + info.FullName);
            //Quốc Tịch
            draw(doc, 450, 22, 20, 25, "QUỐC TỊCH: " + info.Nation);
            //Address
            draw(doc, 450, 22, 20, 42, "ĐỊA CHỈ: " + info.Address);
            //PHONE
            draw(doc, 450, 22, 20, 60, "SỐ ĐIỆN THOẠI: " + info.PhoneNumber);
            //Image
            imageDraw(doc, 145, 115, 15, 75, info.Image);
            //Register Day
            draw(doc, 320, 22, 150, 67, "NGÀY ĐĂNG KÝ: " + info.Register_day.ToShortDateString());
            // Day of Birth
            draw(doc, 320, 22, 150, 90, "NGÀY SINH : " + info.Day_of_Birth.ToShortDateString());
            //Place of Birth
            draw(doc, 320, 22, 150, 115, "NƠI SINH: " + info.Place_of_Birth);
            //Class 
            draw(doc, 320, 22, 150, 139, "LỚP: " + info.Class_Name);
            //Cap 1-6

            draw(doc, 450, 22, 20, 160, "CẤP 6: " + (info.listLevel["Cap6"] != DateTime.MinValue ? info.listLevel["Cap6"].ToShortDateString() : ""));
            draw(doc, 450, 22, 20, 177, "CẤP 5: " + (info.listLevel["Cap5"] != DateTime.MinValue ? info.listLevel["Cap5"].ToShortDateString() : ""));
            draw(doc, 450, 22, 20, 193, "CẤP 4: " + (info.listLevel["Cap4"] != DateTime.MinValue ? info.listLevel["Cap4"].ToShortDateString() : ""));
            draw(doc, 450, 22, 20, 209, "CẤP 3: " + (info.listLevel["Cap3"] != DateTime.MinValue ? info.listLevel["Cap3"].ToShortDateString() : ""));
            draw(doc, 450, 22, 20, 225, "CẤP 2: " + (info.listLevel["Cap2"] != DateTime.MinValue ? info.listLevel["Cap2"].ToShortDateString() : ""));
            draw(doc, 450, 22, 20, 240, "CẤP 1: " + (info.listLevel["Cap1"] != DateTime.MinValue ? info.listLevel["Cap1"].ToShortDateString() : ""));

            draw(doc, 210, 22, 20, 260, "I DAN VN: " + (info.listLevel["DANVN1"] != DateTime.MinValue ? info.listLevel["DANVN1"].ToShortDateString() : ""));
            draw(doc, 210, 22, 20, 278, "II DAN VN: " + (info.listLevel["DANVN2"] != DateTime.MinValue ? info.listLevel["DANVN2"].ToShortDateString() : ""));
            draw(doc, 210, 22, 20, 296, "III DAN VN: " + (info.listLevel["DANVN3"] != DateTime.MinValue ? info.listLevel["DANVN3"].ToShortDateString() : ""));
            draw(doc, 210, 22, 20, 314, "IV DAN VN: " + (info.listLevel["DANVN4"] != DateTime.MinValue ? info.listLevel["DANVN4"].ToShortDateString() : ""));
            draw(doc, 210, 22, 20, 332, "V DAN VN: " + (info.listLevel["DANVN5"] != DateTime.MinValue ? info.listLevel["DANVN5"].ToShortDateString() : ""));
            draw(doc, 210, 22, 20, 350, "VI DAN VN: " + (info.listLevel["DANVN6"] != DateTime.MinValue ? info.listLevel["DANVN6"].ToShortDateString() : ""));
            draw(doc, 210, 22, 20, 368, "VII DAN VN: " + (info.listLevel["DANVN7"] != DateTime.MinValue ? info.listLevel["DANVN7"].ToShortDateString() : ""));
            draw(doc, 210, 22, 20, 384, "VIII DAN VN: " + (info.listLevel["DANVN8"] != DateTime.MinValue ? info.listLevel["DANVN8"].ToShortDateString() : ""));
            draw(doc, 210, 22, 260, 150, "I DAN AIKIDAI: " + (info.listLevel["DANAIKIKAI1"] != DateTime.MinValue ? info.listLevel["DANAIKIKAI1"].ToShortDateString() : ""));
            draw(doc, 210, 22, 260, 168, "II DAN AIKIDAI: " + (info.listLevel["DANAIKIKAI2"] != DateTime.MinValue ? info.listLevel["DANAIKIKAI2"].ToShortDateString() : ""));
            draw(doc, 210, 22, 260, 185, "III DAN AIKIDAI: " + (info.listLevel["DANAIKIKAI3"] != DateTime.MinValue ? info.listLevel["DANAIKIKAI3"].ToShortDateString() : ""));
            draw(doc, 210, 22, 260, 204, "IV DAN AIKIDAI: " + (info.listLevel["DANAIKIKAI4"] != DateTime.MinValue ? info.listLevel["DANAIKIKAI4"].ToShortDateString() : ""));
            draw(doc, 210, 22, 260, 220, "V DAN AIKIDAI: " + (info.listLevel["DANAIKIKAI5"] != DateTime.MinValue ? info.listLevel["DANAIKIKAI5"].ToShortDateString() : ""));
            draw(doc, 210, 22, 260, 238, "VI DAN AIKIDAI: " + (info.listLevel["DANAIKIKAI6"] != DateTime.MinValue ? info.listLevel["DANAIKIKAI6"].ToShortDateString() : ""));
            draw(doc, 210, 22, 260, 256, "VII DAN AIKIDAI: " + (info.listLevel["DANAIKIKAI7"] != DateTime.MinValue ? info.listLevel["DANAIKIKAI7"].ToShortDateString() : ""));
            draw(doc, 210, 22, 260, 274, "VIII DAN AIKIDAI: " + (info.listLevel["DANAIKIKAI8"] != DateTime.MinValue ? info.listLevel["DANAIKIKAI8"].ToShortDateString() : ""));

            
            //Save and launch
            i++;
            doc.SaveToFile("MemberInfo"+i+".docx", FileFormat.Docx);
     
            Process myProcess = new Process();
            try
            { 
                myProcess=Process.Start("MemberInfo" + i+ ".docx");
            }
            catch { }
        }
        public void draw(Document doc, int d, int r, int Hposition, int Vposition, String content)
        {
            TextBox txtbox = doc.Sections[0].AddParagraph().AppendTextBox(d, r);
            txtbox.Format.HorizontalPosition = Hposition;
            txtbox.Format.VerticalPosition = Vposition;
            txtbox.Format.LineColor = System.Drawing.Color.DarkBlue;
            txtbox.Format.LineStyle = TextBoxLineStyle.Simple;
            Paragraph p = txtbox.Body.AddParagraph();
            p.AppendText(content);
        }
        public void imageDraw(Document doc, int d, int r, int Hposition, int Vposition, byte[] image)
        {
            TextBox txtbox = doc.Sections[0].AddParagraph().AppendTextBox(r + 16, d + 5);
            txtbox.Format.HorizontalPosition = Hposition;
            txtbox.Format.VerticalPosition = Vposition;
            Paragraph p = txtbox.Body.AddParagraph();
            txtbox.Format.NoLine = true;
            if (image != null)
            {
                
                DocPicture picture = p.AppendPicture(image);
                picture.Width = r;
                picture.Height = d;
            }
            

        }

    }
}
