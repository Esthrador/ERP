using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using ERPv1.Models;

namespace ERPv1.Helpers
{
    public static class EmailHelper
    {

        public static MailAddress FromAdress = new MailAddress("copyrightexception@gmail.com", "Copyright Exception Service");

        public static MailMessage GetMailMessageForContractBill(Auftrag auftrag, string pdfBillUrl)
        {
            var message = new MailMessage
            {
                Sender = FromAdress,
                From = FromAdress,
                To = { auftrag.Kunde.Email },
                Subject = $"CRE - Rechnung für Auftrag-Nr: {auftrag.ID}",
                Body = $"Sehr geehrte/r Frau/Herr {auftrag.Kunde.Nachname}, <br/>" +
                       $"Vielen Dank für Ihre Bestellung und Ihr Vertrauen in unsere Dienstleistungen!<br/>" +
                       $"Die Rechnung für diese Bestellung finden Sie im Anhang. <br/><br/>" +
                       $"Viele Grüße wünscht Ihnen<br/>" + 
                       $"Ihr Copyright Exception Team",
                IsBodyHtml = true
                
            };

            message.Attachments.Add(new Attachment(new MemoryStream(PdfHelper.GeneratePdfFromByteArray(pdfBillUrl)),
                "Rechnung_" + DateTime.Now.ToString("dd-MM-yyyy") + ".pdf"));

            return message;
        }

        public static void SendEmail(MailMessage message)
        {
            try
            {
                var smtpClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 25,
                    EnableSsl = true,
                    Timeout = 10000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("copyrightexception@gmail.com", "Pw123456#")
                };

                smtpClient.Send(message);
            }
            catch (Exception)
            {
                throw;
            }

           
        }
    }
}