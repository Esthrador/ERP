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
    public class LagerController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Lager
        public ActionResult Index()
        {
            return View(_db.Lager.ToList());
        }

        // GET: Lager/Details/5
        public ActionResult Details(Guid id)
        {
            Lager lager = _db.Lager.Find(id);

            if (lager == null)           
                return HttpNotFound();
            
            return View(lager);
        }

        // GET: Lager/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Lager lager)
        {
            if (ModelState.IsValid)
            {
                lager.ID = Guid.NewGuid();

                _db.Lager.Add(lager);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(lager);
        }

        // GET: Lager/Edit/5
        public ActionResult Edit(Guid id)
        {
            Lager lager = _db.Lager.Find(id);

            if (lager == null)
                return HttpNotFound();

            return View(lager);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Lager lager)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(lager).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(lager);
        }

        // POST: Lager/Delete/5
        public ActionResult Delete(Guid id)
        {
            Lager lager = _db.Lager.Find(id);

            if (lager == null)
                return HttpNotFound();

            _db.Lager.Remove(lager);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult AddProducts(Guid id)
        {
            Lager lager = _db.Lager.Find(id);

            if (lager == null)
                return HttpNotFound();

            var vm = new LagerWarenViewModel
            {
                Lager = lager,
                Waren = _db.Waren.ToList()
            };

            return View("LagerWaren", vm);
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
