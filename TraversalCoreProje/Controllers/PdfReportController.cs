using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReport/" + "dosya1.pdf");
            var stream=new FileStream(path,FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document,stream);
            document.Open();

            Paragraph paragraph = new Paragraph("traversal rezervasyon pdf raporu");
            document.Add(paragraph);
            document.Close();
            return File("/PdfReport/dosya1.pdf", "application/pdf", "dosya1.pdf");
        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReport/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            PdfPTable pdfPTable = new PdfPTable(3);
            pdfPTable.AddCell("misafir adı");
            pdfPTable.AddCell("misafir soyadı");
            pdfPTable.AddCell("misafir tc");

            pdfPTable.AddCell("can");
            pdfPTable.AddCell("melek");
            pdfPTable.AddCell("1231231232");

            pdfPTable.AddCell("mert");
            pdfPTable.AddCell("bulur");
            pdfPTable.AddCell("2334242343");
            
            document.Add(pdfPTable);
            document.Close();
            return File("/PdfReport/dosya2.pdf", "application/pdf", "dosya2.pdf");
        }
    }
}
