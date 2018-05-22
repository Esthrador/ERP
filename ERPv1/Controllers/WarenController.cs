using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ERPv1.Models;
using ERPv1.Models.DbContext;

namespace ERPv1.Controllers
{
    [Authorize]
    public class WarenController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Waren
        public ActionResult Index()
        {
            return View(_db.Waren.ToList());
        }

        // GET: Waren/Details/5
        public ActionResult Details(Guid id)
        {
            Ware ware = _db.Waren.Find(id);

            if (ware == null)           
                return HttpNotFound();           

            return View(ware);
        }

        // GET: Waren/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ware ware)
        {
            if (ModelState.IsValid)
            {
                ware.ID = Guid.NewGuid();

                _db.Waren.Add(ware);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(ware);
        }

        // GET: Waren/Edit/5
        public ActionResult Edit(Guid id)
        {
            Ware ware = _db.Waren.Find(id);

            if (ware == null)           
                return HttpNotFound();
            
            return View(ware);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ware ware)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(ware).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(ware);
        }

        // POST: Waren/Delete/5
        public ActionResult Delete(Guid id)
        {
            Ware ware = _db.Waren.Find(id);

            if (ware == null)           
                return HttpNotFound();          

            _db.Waren.Remove(ware);
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
