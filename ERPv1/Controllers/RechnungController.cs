using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPv1.Models.ViewModels;
using HiQPdf;
using Microsoft.Ajax.Utilities;

namespace ERPv1.Controllers
{
    [Authorize]
    public class RechnungController : Controller
    {
        [AllowAnonymous]
        public ActionResult ShowBillForContract()
        {
            var vm = new RechnungViewModel
            {
                Auftrag = null
            };

            return View("~/Views/Shared/_Rechnung.cshtml", vm);
        }

        public ActionResult GenerateBillForContract(Guid auftragId)
        {
            // Create the HTML to PDF converter
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

            // Set PDF page margins
            htmlToPdfConverter.Document.Margins = new PdfMargins(5);

            // Convert URL to a PDF memory buffer
            string url = Url.Action("ShowBillForContract", "Rechnung", null, Request.Url.Scheme);

            var pdfBuffer = htmlToPdfConverter.ConvertUrlToMemory(url);

            return File(pdfBuffer, "application/pdf");
        }
    }
}