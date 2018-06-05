using System;
using System.Linq;
using System.Web.Mvc;
using ERPv1.Helpers;
using ERPv1.Models.DbContext;
using ERPv1.Models.ViewModels;

namespace ERPv1.Controllers
{
    [Authorize]
    public class RechnungController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult ShowBillForContract(Guid auftragIdForBill)
        {
            var vm = new RechnungViewModel
            {
                Auftrag = _db.Auftrag.Find(auftragIdForBill)
            };

            // Bearbeiter hinzufügen
            vm.Bearbeiter = _db.Users.FirstOrDefault(x => x.Email == vm.Auftrag.ChangedBy);

            return View("~/Views/Shared/_Rechnung.cshtml", vm);
        }

        public ActionResult GenerateBillForContract(Guid auftragId)
        {
            string url = Url.Action("ShowBillForContract", "Rechnung", new { auftragIdForBill = auftragId }, Request.Url?.Scheme);

            var pdfBuffer = PdfHelper.GeneratePdfFromByteArray(url);

            var mailMessage = EmailHelper.GetMailMessageForContractBill(_db.Auftrag.Find(auftragId), url);
            EmailHelper.SendEmail(mailMessage);

            return File(pdfBuffer, "application/pdf");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}