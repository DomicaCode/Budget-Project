using iTextSharp.text;
using iTextSharp.text.pdf;
using MoreLinq;
using Project_Budget.Engine;
using Project_Budget.Factories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project_Budget.Engine
{
    public class Logic
    {

        public static void exportGridPdf(DataTable dt)
        {            // definiraj trenutno vrijeme
            var time = DateTime.Now;

            //uzmi lokaciju documentsa, napravi folder
            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = docPath + @"\\.domica\\Shopping List " + time.ToString("dd/MM/yyyy H-mm-ss") + ".pdf";
            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));

            //napravi pdf file
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
            document.Open();

            Font font = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 14);


            PdfPTable table = new PdfPTable(dt.Columns.Count);
            table.TotalWidth = 300f;

            //Instanciram cellove i settingsi za njih
            PdfPCell cell = new PdfPCell(new Phrase("Shopping lista"));
            cell.Colspan = 3;
            cell.HorizontalAlignment = 1;


            float[] widths = new float[] { 4f, 4f, 4f, 4f };

            table.SetWidths(widths);

            table.WidthPercentage = 100;

            cell.Colspan = dt.Columns.Count;


             var dtSumObj = dt.Compute("sum(itm_price)", null);

            foreach (DataColumn c in dt.Columns)
            {
                table.AddCell(new Phrase(c.ColumnName, font));
            }

            foreach (DataRow r in dt.Rows)
            {
                if (dt.Rows.Count > 0)
                {
                    table.AddCell(new Phrase(r[0].ToString(), font));
                    table.AddCell(new Phrase(r[1].ToString(), font));
                    table.AddCell(new Phrase(r[2].ToString(), font));
                    table.AddCell(new Phrase(r[3].ToString(), font));
                }
            }
            float dtSum = Convert.ToSingle(dtSumObj);

            document.Add(table);
            document.Add(new iTextSharp.text.Paragraph(""));
            document.Add(new iTextSharp.text.Paragraph("Iznos ce biti: " + dtSum + " HRK"));
            document.Close();

            MessageBox.Show("Izbacio ti se pdf!");
        }
    }
}
