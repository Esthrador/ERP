using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using ERPv1.Models;

namespace ERPv1.Helpers
{
    public static class EmailHelper
    {
        public static MailMessage GetMailMessageForContractBill(Auftrag auftrag, string pdfBillUrl)
        {
            var message = new MailMessage
            {
                From = new MailAddress("copyrightexception@gmail.de"),
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
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Timeout = 15000,
                    Credentials = new NetworkCredential
                    {
                        UserName = "copyrightexception@gmail.de",
                        Password = "Pw123456#"
                    },
                    EnableSsl = true
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