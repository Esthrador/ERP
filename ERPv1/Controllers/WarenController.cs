using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ERPv1.Models;

namespace ERPv1.Controllers
{
    public class WarenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Waren
        public ActionResult Index()
        {
            return View(db.Waren.ToList());
        }

        // GET: Waren/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ware ware = db.Waren.Find(id);
            if (ware == null)
            {
                return HttpNotFound();
            }
            return View(ware);
        }

        // GET: Waren/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Waren/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Bezeichnung,KurzBezeichnung,Anzahl,ChangedOn,CreatedOn,Preis,SteuerKlasse,EinzelGewicht")] Ware ware)
        {
            if (ModelState.IsValid)
            {
                ware.ID = Guid.NewGuid();
                db.Waren.Add(ware);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ware);
        }

        // GET: Waren/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ware ware = db.Waren.Find(id);
            if (ware == null)
            {
                return HttpNotFound();
            }
            return View(ware);
        }

        // POST: Waren/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Bezeichnung,KurzBezeichnung,Anzahl,ChangedOn,CreatedOn,Preis,SteuerKlasse,EinzelGewicht")] Ware ware)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ware).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ware);
        }

        // GET: Waren/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ware ware = db.Waren.Find(id);
            if (ware == null)
            {
                return HttpNotFound();
            }
            return View(ware);
        }

        // POST: Waren/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Ware ware = db.Waren.Find(id);
            db.Waren.Remove(ware);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
