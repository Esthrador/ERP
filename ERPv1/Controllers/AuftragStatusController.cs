using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ERPv1.Models;
using ERPv1.Models.DbContext;

namespace ERPv1.Controllers
{
    [Authorize]
    public class AuftragStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AuftragStatus
        public ActionResult Index()
        {
            return View(db.AuftragStatus.ToList());
        }

        // GET: AuftragStatus/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuftragStatus auftragStatus = db.AuftragStatus.Find(id);
            if (auftragStatus == null)
            {
                return HttpNotFound();
            }
            return View(auftragStatus);
        }

        // GET: AuftragStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuftragStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Bezeichnung,KurzBezeichnung,IsVisibleForAll")] AuftragStatus auftragStatus)
        {
            if (ModelState.IsValid)
            {

                auftragStatus.ID = Guid.NewGuid();
                db.AuftragStatus.Add(auftragStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auftragStatus);
        }

        // GET: AuftragStatus/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuftragStatus auftragStatus = db.AuftragStatus.Find(id);
            if (auftragStatus == null)
            {
                return HttpNotFound();
            }
            return View(auftragStatus);
        }

        // POST: AuftragStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Bezeichnung,KurzBezeichnung,IsVisibleForAll")] AuftragStatus auftragStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auftragStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auftragStatus);
        }

        // GET: AuftragStatus/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuftragStatus auftragStatus = db.AuftragStatus.Find(id);
            if (auftragStatus == null)
            {
                return HttpNotFound();
            }
            return View(auftragStatus);
        }

        // POST: AuftragStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AuftragStatus auftragStatus = db.AuftragStatus.Find(id);
            db.AuftragStatus.Remove(auftragStatus);
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
