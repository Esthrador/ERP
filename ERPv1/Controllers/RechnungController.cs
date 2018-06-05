﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPv1.Helpers;
using ERPv1.Models;
using ERPv1.Models.DbContext;
using ERPv1.Models.ViewModels;
using HiQPdf;
using Microsoft.Ajax.Utilities;

namespace ERPv1.Controllers
{
    [Authorize]
    public class RechnungController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult ShowBillForContract(Auftrag auftrag)
        {
            var vm = new RechnungViewModel
            {
                Auftrag = auftrag
            };

            return View("~/Views/Shared/_Rechnung.cshtml", vm);
        }

        public ActionResult GenerateBillForContract(Guid auftragId)
        {
            string url = Url.Action("ShowBillForContract", "Rechnung", new { auftrag = _db.Auftrag.Find(auftragId) }, Request.Url?.Scheme);

            var pdfBuffer = PdfHelper.GeneratePdfFromByteArray(url);

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