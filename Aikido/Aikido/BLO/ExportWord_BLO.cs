using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aikido.BLO
{
    public class ExportWord_BLO
    {
        public void CreateDocument()
        {

                //Create New Word
                Document doc = new Document();

                //Add Section
                Spire.Doc.Section section = doc.AddSection();

                //Add Paragraph

                Spire.Doc.Documents.Paragraph Para = section.AddParagraph();

                //Append Text

                Para.AppendText("Hello! "

                + "I was created by Spire.Doc for WPF, it's a professional .NET Word component "

                + "which enables developers to perform a large range of tasks on Word document (such as create, open, write, edit, save and convert "

                + "Word document) without installing Microsoft Office and any other third-party tools on system.");

                //Save and launch
                doc.SaveToFile("MyWord.docx", FileFormat.Docx);

                System.Diagnostics.Process.Start("MyWord.docx");
            }

        
    }
}
