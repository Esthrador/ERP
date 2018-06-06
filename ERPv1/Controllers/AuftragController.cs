using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            List<Auftrag> aufträge;

            if (User.IsInRole("Abteilungsleiter") || User.IsInRole("Administration"))
            {
                aufträge = _db.Auftrag.Include(c=>c.Status).ToList();
            }
            else
            {
                aufträge = _db.Auftrag.Where(c => c.Status != null && c.Status.IsVisibleForAll).Include(c=>c.Status).ToList();
            }

            return View(aufträge);
        }

        // GET: Auftrag/Details/5
        public ActionResult Details(Guid id)
        {
            Auftrag auftrag = _db.Auftrag.Include("Status").SingleOrDefault(c=>c.ID == id);

            if (auftrag == null)
                return HttpNotFound();

            var avm = new AuftragViewModel
            {
                Waren = new List<WareViewModel>(),
                AuftragToDo = auftrag
            };

            avm.AuftragToDo.KundenAuswahl = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "",
                    Value = ""
                }
            };

            var kunden = _db.Kunden.ToList();
            foreach (var k in kunden)
            {
                avm.AuftragToDo.KundenAuswahl.Add(new SelectListItem
                {
                    Text = k.Vorname + @" " + k.Nachname,
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
            var avm = new AuftragViewModel
            {
                Waren = new List<WareViewModel>(),
                AuftragToDo = new Auftrag
                {
                    KundenAuswahl = new List<SelectListItem>
                    {
                        new SelectListItem
                        {
                            Text = "",
                            Value = ""
                        }
                    }
                },
                IsCreate = true
            };

            var kunden = _db.Kunden.ToList();
            foreach (var k in kunden)
            {
                avm.AuftragToDo.KundenAuswahl.Add(new SelectListItem
                {
                    Text = k.Vorname + @" " + k.Nachname,
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
            if (auftrag.SelectedWaren == null || auftrag.SelectedWaren.Count == 0 || auftrag.SelectedWaren.All(x => (x != null && x.Menge == 0) || x == null))
            {
                ModelState.AddModelError(string.Empty, @"Auftrag muss Waren beinhalten!");
            }

            // Überprüfe ob Menge noch im Lager vorhanden
            if (auftrag.SelectedWaren != null)
            {
                foreach (var wareViewModel in auftrag.SelectedWaren)
                {
                    var lagerWare = _db.LagerWaren.Find(wareViewModel.LWID);
                    var auftragWaren = _db.AuftragWaren.Where(x =>
                        ((x.Auftrag.Status != null && !x.Auftrag.Status.Bezeichnung.Equals("Abgeschlossen")) ||
                         x.Auftrag.Status == null) && x.Auftrag.DeletedOn == null && x.AuftragWarenID != wareViewModel.AWID && x.Auftrag != null);
                    var schwebendeMenge = auftragWaren.Where(x => x.LagerWare != null && x.LagerWare.WareID == lagerWare.WareID).ToList().Sum(x => x.Menge);

                    if ((lagerWare?.Menge - schwebendeMenge) < wareViewModel.Menge)
                        ModelState.AddModelError(string.Empty, $@"Die Ware {wareViewModel.Ware.ArtikelNummer} ist in der Menge nicht mehr vorhanden!");
                }
            }

            auftrag.IsCreate = true;

            if (ModelState.IsValid)
            {
                var stat = _db.AuftragStatus.SingleOrDefault(c => c.Bezeichnung.Equals("Angelegt"));
                auftrag.AuftragToDo.StatusId = stat?.ID;
                auftrag.AuftragToDo.ID = Guid.NewGuid();

                var auftragsnummer = 0;
                try
                {
                    auftragsnummer = _db.Auftrag.Max(x => x.Auftragsnummer) + 1;
                }
                catch
                {
                    auftragsnummer += 1;
                }
                auftrag.AuftragToDo.Auftragsnummer = auftragsnummer;

                auftrag.SelectedWaren = auftrag.SelectedWaren ?? new List<WareViewModel>();
                foreach (var ware in auftrag.SelectedWaren)
                {
                    _db.AuftragWaren.Add(new AuftragWaren
                    {
                        AuftragID = auftrag.AuftragToDo.ID,
                        LagerWareID = ware.LWID,
                        Menge = ware.Menge
                    });
                }

                _db.Auftrag.Add(auftrag.AuftragToDo);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            var kunden = _db.Kunden.ToList();
            if(auftrag.AuftragToDo.KundenAuswahl == null)
                auftrag.AuftragToDo.KundenAuswahl = new List<SelectListItem>();

            foreach (var k in kunden)
            {
                auftrag.AuftragToDo.KundenAuswahl.Add(new SelectListItem
                {
                    Text = k.Vorname + @" " + k.Nachname,
                    Value = k.ID.ToString()
                });
            }

           
            var tmpWaren = _db.LagerWaren.Include(c=>c.Ware).ToList();

            if(auftrag.Waren == null)
                auftrag.Waren = new List<WareViewModel>();

            foreach (var t in tmpWaren)
            {
                auftrag.Waren.Add(new WareViewModel
                {
                    Menge = t.Menge,
                    LWID = t.LagerWarenID,
                    Ware = t.Ware,
                    Lager = t.Lager.Bezeichnung
                });
            }

            if(auftrag.SelectedWaren == null)
                auftrag.SelectedWaren = new List<WareViewModel>();

            return View(auftrag);
        }

        // GET: Auftrag/Edit/5
        public ActionResult Edit(Guid id)
        {
            Auftrag auftrag = _db.Auftrag.Include("Status").SingleOrDefault(c=>c.ID == id);

            if (auftrag == null)
                return HttpNotFound();

            var avm = new AuftragViewModel
            {
                Waren = new List<WareViewModel>(),
                AuftragToDo = auftrag
            };

            avm.AuftragToDo.KundenAuswahl = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "",
                    Value = ""
                }
            };

            var kunden = _db.Kunden.ToList();
            foreach (var k in kunden)
            {
                avm.AuftragToDo.KundenAuswahl.Add(new SelectListItem
                {
                    Text = k.Vorname + @" " + k.Nachname,
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
                    AWID = auftragWaren.AuftragWarenID,
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
            if (auftrag.SelectedWaren == null || auftrag.SelectedWaren.Count == 0 || auftrag.SelectedWaren.All(x => (x != null && x.Menge == 0) || x == null))
            {
                ModelState.AddModelError(string.Empty, @"Auftrag muss Waren beinhalten!");
            }

            // Überprüfe ob Menge noch im Lager vorhanden
            if (auftrag.SelectedWaren != null)
            {
                foreach (var wareViewModel in auftrag.SelectedWaren)
                {
                    var lagerWare = _db.LagerWaren.Find(wareViewModel.LWID);
                    var auftragWaren = _db.AuftragWaren.Where(x =>
                        ((x.Auftrag.Status != null && !x.Auftrag.Status.Bezeichnung.Equals("Abgeschlossen")) ||
                        x.Auftrag.Status == null) && x.Auftrag.DeletedOn == null && x.AuftragWarenID != wareViewModel.AWID && x.Auftrag != null);
                    var schwebendeMenge = auftragWaren.Where(x => x.LagerWare != null && x.LagerWare.WareID == lagerWare.WareID).ToList().Sum(x => x.Menge);

                    if ((lagerWare?.Menge - schwebendeMenge) < wareViewModel.Menge)
                        ModelState.AddModelError(string.Empty, $@"Die Ware {wareViewModel.Ware.ArtikelNummer} ist in der Menge nicht mehr vorhanden!");
                }
            }

            if (ModelState.IsValid)
            {
                _db.Entry(auftrag.AuftragToDo).State = EntityState.Modified;

                auftrag.SelectedWaren = auftrag.SelectedWaren ?? new List<WareViewModel>();
                foreach (var wareViewModel in auftrag.SelectedWaren)
                {
                    var aw = _db.AuftragWaren.SingleOrDefault(c => c.AuftragWarenID == wareViewModel.AWID);
                    if (aw != null)
                    {
                        aw.Menge = wareViewModel.Menge;
                    }
                }

                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            auftrag.AuftragToDo.KundenAuswahl = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "",
                    Value = ""
                }
            };

            var kunden = _db.Kunden.ToList();
            foreach (var k in kunden)
            {
                auftrag.AuftragToDo.KundenAuswahl.Add(new SelectListItem
                {
                    Text = k.Vorname + @" " + k.Nachname,
                    Value = k.ID.ToString()
                });
            }

            var tmpWaren = _db.LagerWaren.Include(c => c.Ware).ToList();
            auftrag.Waren = auftrag.Waren ?? new List<WareViewModel>();
            foreach (var t in tmpWaren)
            {
                auftrag.Waren.Add(new WareViewModel
                {
                    Menge = t.Menge,
                    LWID = t.LagerWarenID,
                    Ware = t.Ware,
                    Lager = t.Lager.Bezeichnung
                });
            }

            auftrag.SelectedWaren = new List<WareViewModel>();
            var aufWaren = _db.AuftragWaren.Where(c => c.AuftragID == auftrag.AuftragToDo.ID).ToList();
            foreach (var auftragWaren in aufWaren)
            {
                auftrag.SelectedWaren.Add(new WareViewModel
                {
                    Lager = auftragWaren.LagerWare.Lager.Bezeichnung,
                    LWID = auftragWaren.LagerWareID,
                    AWID = auftragWaren.AuftragWarenID,
                    Menge = auftragWaren.Menge,
                    Ware = auftragWaren.LagerWare.Ware
                });
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

        public ActionResult AuftragFreigeben(Guid id)
        {
            Auftrag auftrag = _db.Auftrag.Find(id);
            if (auftrag != null)
            {
                auftrag.StatusId = _db.AuftragStatus.SingleOrDefault(c => c.Bezeichnung.Equals("Beauftragt"))?.ID;
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult AuftragAbweisen(Guid id)
        {
            Auftrag auftrag = _db.Auftrag.Find(id);
            if (auftrag != null)
            {
                auftrag.StatusId = _db.AuftragStatus.SingleOrDefault(c => c.Bezeichnung.Equals("Revision"))?.ID;
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult AuftragAbschliessen(Guid id)
        {
            Auftrag auftrag = _db.Auftrag.Find(id);
            if (auftrag != null)
            {
                foreach (var auftragWaren in auftrag.AuftragWaren)
                {
                    var lagerWare = _db.LagerWaren.Find(auftragWaren.LagerWareID);

                    if (lagerWare != null)
                        lagerWare.Menge -= auftragWaren.Menge;
                }

                auftrag.StatusId = _db.AuftragStatus.SingleOrDefault(c => c.Bezeichnung.Equals("Abgeschlossen"))?.ID;
                _db.SaveChanges();
            }
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