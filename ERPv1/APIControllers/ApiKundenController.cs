using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ERPv1.Models;
using ERPv1.Models.DbContext;

namespace ERPv1.APIControllers
{
    public class ApiKundenController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ApiKunden
        public IQueryable<Kunde> GetKunden()
        {
            return db.Kunden;
        }

        // GET: api/ApiKunden/5
        [ResponseType(typeof(Kunde))]
        public IHttpActionResult GetKunde(Guid id)
        {
            Kunde kunde = db.Kunden.Find(id);
            if (kunde == null)
            {
                return NotFound();
            }

            return Ok(kunde);
        }

        // PUT: api/ApiKunden/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKunde(Guid id, Kunde kunde)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kunde.ID)
            {
                return BadRequest();
            }

            db.Entry(kunde).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KundeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ApiKunden
        [ResponseType(typeof(Kunde))]
        public IHttpActionResult PostKunde(Kunde kunde)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kunden.Add(kunde);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KundeExists(kunde.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = kunde.ID }, kunde);
        }

        // DELETE: api/ApiKunden/5
        [ResponseType(typeof(Kunde))]
        public IHttpActionResult DeleteKunde(Guid id)
        {
            Kunde kunde = db.Kunden.Find(id);
            if (kunde == null)
            {
                return NotFound();
            }

            db.Kunden.Remove(kunde);
            db.SaveChanges();

            return Ok(kunde);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KundeExists(Guid id)
        {
            return db.Kunden.Count(e => e.ID == id) > 0;
        }
    }
}