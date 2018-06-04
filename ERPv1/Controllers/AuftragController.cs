using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ERPv1.Models;
using ERPv1.Models.DbContext;
using ERPv1.Models.ViewModels;

namespace ERPv1.Controllers
{
    [Authorize]
    public class AuftragController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Auftrag
        public ActionResult Index()
        {
            return View(_db.Auftrag.ToList());
        }

        // GET: Auftrag/Details/5
        public ActionResult Details(Guid id)
        {
            Auftrag auftrag = _db.Auftrag.Find(id);

            if (auftrag == null)
                return HttpNotFound();
            var avm = new AuftragViewModel();
            avm.Waren = new List<WareViewModel>();
            avm.AuftragToDo = auftrag;
            avm.AuftragToDo.KundenAuswahl = new List<SelectListItem>();
            avm.AuftragToDo.KundenAuswahl.Add(new SelectListItem
            {
                Text = "",
                Value =""
            });
            var kunden = _db.Kunden.ToList();
            foreach (var k in kunden)
            {
                avm.AuftragToDo.KundenAuswahl.Add(new SelectListItem
                {
                    Text = k.Vorname + " " + k.Nachname,
                    Value = k.ID.ToString()
                });
            }

            var tmpWaren = _db.LagerWaren.Include(c=>c.Ware).ToList();
            foreach (var t in tmpWaren)
            {
                avm.Waren.Add(new WareViewModel
                {
                    Menge = t.Menge,
                    LWID = t.LagerWarenID,
                    Ware = t.Ware,
                    Lager = t.Lager.Bezeichnung
                });
            }
            avm.SelectedWaren = new List<WareViewModel>();
            var aufWaren = _db.AuftragWaren.Where(c => c.AuftragID == auftrag.ID).ToList();
            foreach (var auftragWaren in aufWaren)
            {
                avm.SelectedWaren.Add(new WareViewModel
                {
                    Lager = auftragWaren.LagerWare.Lager.Bezeichnung,
                    LWID = auftragWaren.LagerWareID,
                    Menge = auftragWaren.Menge,
                    Ware = auftragWaren.LagerWare.Ware
                });
            }
            return View(avm);
        }

        // GET: Auftrag/Create
        public ActionResult Create()
        {
            var avm = new AuftragViewModel();
            avm.Waren = new List<WareViewModel>();
            avm.AuftragToDo = new Auftrag();
            avm.AuftragToDo.KundenAuswahl = new List<SelectListItem>();
            avm.AuftragToDo.KundenAuswahl.Add(new SelectListItem
            {
                Text = "",
                Value =""
            });
            var kunden = _db.Kunden.ToList();
            foreach (var k in kunden)
            {
                avm.AuftragToDo.KundenAuswahl.Add(new SelectListItem
                {
                    Text = k.Vorname + " " + k.Nachname,
                    Value = k.ID.ToString()
                });
            }

            var tmpWaren = _db.LagerWaren.Include(c=>c.Ware).ToList();
            foreach (var t in tmpWaren)
            {
                avm.Waren.Add(new WareViewModel
                {
                    Menge = t.Menge,
                    LWID = t.LagerWarenID,
                    Ware = t.Ware,
                    Lager = t.Lager.Bezeichnung
                });
            }
            avm.SelectedWaren = new List<WareViewModel>();
            return View(avm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuftragViewModel auftrag)
        {
            if (ModelState.IsValid)
            {
                Auftrag af = new Auftrag
                {
                    ID = Guid.NewGuid(),
                    AuftragsDatum = auftrag.AuftragToDo.AuftragsDatum,
                    RechnungsDatum = auftrag.AuftragToDo.RechnungsDatum,
                    KundeId = auftrag.AuftragToDo.KundeId
                    
                };
                auftrag.AuftragToDo.ID = Guid.NewGuid();
                foreach (var ware in auftrag.SelectedWaren)
                {
                    _db.AuftragWaren.Add(new AuftragWaren
                    {
                        AuftragID = auftrag.AuftragToDo.ID,
                        LagerWareID = ware.LWID,
                        Menge = ware.Ware.Anzahl
                    });
                }
                _db.Auftrag.Add(auftrag.AuftragToDo);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            var kunden = _db.Kunden.ToList();

            foreach (var k in kunden)
            {
                auftrag.AuftragToDo.KundenAuswahl.Add(new SelectListItem
                {
                    Text = k.Vorname + " " + k.Nachname,
                    Value = k.ID.ToString()
                });
            }

           
            var tmpWaren = _db.LagerWaren.Include(c=>c.Ware).ToList();
            foreach (var t in tmpWaren)
            {
                auftrag.Waren.Add(new WareViewModel
                {
                    Menge = t.Menge,
                    Ware = t.Ware,
                    Lager = t.Lager.Bezeichnung
                });
            }
            return View(auftrag);
        }

        // GET: Auftrag/Edit/5
        public ActionResult Edit(Guid id)
        {
            Auftrag auftrag = _db.Auftrag.Find(id);

            if (auftrag == null)
                return HttpNotFound();
            var avm = new AuftragViewModel();
            avm.Waren = new List<WareViewModel>();
            avm.AuftragToDo = auftrag;
            avm.AuftragToDo.KundenAuswahl = new List<SelectListItem>();
            avm.AuftragToDo.KundenAuswahl.Add(new SelectListItem
            {
                Text = "",
                Value =""
            });
            var kunden = _db.Kunden.ToList();
            foreach (var k in kunden)
            {
                avm.AuftragToDo.KundenAuswahl.Add(new SelectListItem
                {
                    Text = k.Vorname + " " + k.Nachname,
                    Value = k.ID.ToString()
                });
            }

            var tmpWaren = _db.LagerWaren.Include(c=>c.Ware).ToList();
            foreach (var t in tmpWaren)
            {
                avm.Waren.Add(new WareViewModel
                {
                    Menge = t.Menge,
                    LWID = t.LagerWarenID,
                    Ware = t.Ware,
                    Lager = t.Lager.Bezeichnung
                });
            }
            avm.SelectedWaren = new List<WareViewModel>();
            var aufWaren = _db.AuftragWaren.Where(c => c.AuftragID == auftrag.ID).ToList();
            foreach (var auftragWaren in aufWaren)
            {
                avm.SelectedWaren.Add(new WareViewModel
                {
                    Lager = auftragWaren.LagerWare.Lager.Bezeichnung,
                    LWID = auftragWaren.LagerWareID,
                    Menge = auftragWaren.Menge,
                    Ware = auftragWaren.LagerWare.Ware
                });
            }
            return View(avm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuftragViewModel auftrag)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(auftrag.AuftragToDo).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(auftrag);
        }

        // POST: Auftrag/Delete/5
        public ActionResult Delete(Guid id)
        {
            Auftrag auftrag = _db.Auftrag.Find(id);

            if (auftrag == null)
                return HttpNotFound();

            _db.Auftrag.Remove(auftrag);
            _db.SaveChanges();

            return RedirectToAction("Index");
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