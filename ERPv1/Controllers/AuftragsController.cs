using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ERPv1.Models;

namespace ERPv1.Controllers
{
    [Authorize]
    public class AuftragsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Auftrags
        public ActionResult Index()
        {
            return View(db.Auftrag.ToList());
        }

        // GET: Auftrags/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auftrag auftrag = db.Auftrag.Find(id);
            if (auftrag == null)
            {
                return HttpNotFound();
            }
            return View(auftrag);
        }

        // GET: Auftrags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auftrags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID")] Auftrag auftrag)
        {
            if (ModelState.IsValid)
            {
                auftrag.ID = Guid.NewGuid();
                db.Auftrag.Add(auftrag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auftrag);
        }

        // GET: Auftrags/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auftrag auftrag = db.Auftrag.Find(id);
            if (auftrag == null)
            {
                return HttpNotFound();
            }
            return View(auftrag);
        }

        // POST: Auftrags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] Auftrag auftrag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auftrag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auftrag);
        }

        // GET: Auftrags/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auftrag auftrag = db.Auftrag.Find(id);
            if (auftrag == null)
            {
                return HttpNotFound();
            }
            return View(auftrag);
        }

        // POST: Auftrags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Auftrag auftrag = db.Auftrag.Find(id);
            db.Auftrag.Remove(auftrag);
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
