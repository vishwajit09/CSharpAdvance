using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using Restaurant.Repositories.Interface;
using Restaurant.Service.Interface;

namespace Restaurant.Service
{
    public class PdfConverter : IPdfConverter
    {
        public void ConvertTextToPdf(string text, string outputPath)
        {
            using (PdfDocument document = new PdfDocument())
            {
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont font = new XFont("Arial", 12);

                XTextFormatter tf = new XTextFormatter(gfx);
                XRect rect = new XRect(40, 40, page.Width - 80, page.Height - 80);
                tf.DrawString(text, font, XBrushes.Black, rect, XStringFormats.TopLeft);

                document.Save(outputPath);
            }
        }
    }
}

