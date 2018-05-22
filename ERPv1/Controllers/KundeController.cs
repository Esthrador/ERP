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
    public class KundeController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Kunde
        public ActionResult Index()
        {
            return View(_db.Kunden.ToList());
        }

        // GET: Kunde/Details/5
        public ActionResult Details(Guid id)
        {
            Kunde kunde = _db.Kunden.Find(id);

            if (kunde == null)           
                return HttpNotFound();
            
            return View(kunde);
        }

        // GET: Kunde/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kunde kunde)
        {
            if (ModelState.IsValid)
            {
                kunde.ID = Guid.NewGuid();

                _db.Kunden.Add(kunde);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(kunde);
        }

        // GET: Kunde/Edit/5
        public ActionResult Edit(Guid id)
        {
            Kunde kunde = _db.Kunden.Find(id);

            if (kunde == null)
                return HttpNotFound();

            return View(kunde);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kunde kunde)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(kunde).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(kunde);
        }

        // POST: Kunde/Delete/5
        public ActionResult Delete(Guid id)
        {
            Kunde kunde = _db.Kunden.Find(id);

            if (kunde == null)
                return HttpNotFound();

            _db.Kunden.Remove(kunde);
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
