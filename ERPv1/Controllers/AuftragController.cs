using System;
using System.Collections.Generic;
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
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Auftrags
        public ActionResult Index()
        {
            return View(db.Auftrag.ToList());
        }

        // GET: Auftrags/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var auftrag = db.Auftrag.Find(id);
            if (auftrag == null) return HttpNotFound();
            return View(auftrag);
        }

        // GET: Auftrags/Create
        public ActionResult Create()
        {
            var avm = new AuftragViewModel();
            var waren = db.Waren.Where(c => c.Anzahl > 0);
            avm.Waren = new List<WareViewModel>();
            var warenListe = new List<WareViewModel>();
            foreach (var ware in waren) warenListe.Add(new WareViewModel(ware, 0));
            avm.Waren = warenListe;
            avm.Auftrag = new Auftrag();
            return View(avm);
        }

        // POST: Auftrags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuftragViewModel avm)
        {
            if (ModelState.IsValid) return RedirectToAction("Index");

            return View(avm);
        }

        // GET: Auftrags/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var auftrag = db.Auftrag.Find(id);
            if (auftrag == null) return HttpNotFound();
            return View(auftrag);
        }

        // POST: Auftrags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuftragViewModel avm)
        {
            if (ModelState.IsValid) return RedirectToAction("Index");
            return View(avm);
        }

        // GET: Auftrags/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var auftrag = db.Auftrag.Find(id);
            if (auftrag == null) return HttpNotFound();
            return View(auftrag);
        }

        // POST: Auftrags/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var auftrag = db.Auftrag.Find(id);
            db.Auftrag.Remove(auftrag);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}