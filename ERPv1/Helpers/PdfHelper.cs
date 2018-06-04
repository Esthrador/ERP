using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using HiQPdf;

namespace ERPv1.Helpers
{
    public static class PdfHelper
    {

        public static byte[] GeneratePdfFromByteArray(string url)
        {
            // Create the HTML to PDF converter
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

            // Set PDF page margins
            htmlToPdfConverter.Document.Margins = new PdfMargins(5);

            var pdfBuffer = htmlToPdfConverter.ConvertUrlToMemory(url);

            return pdfBuffer;
        }
    }
}