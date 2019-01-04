using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ElektroikHayvanKimliklendirmeAPI.Models;

namespace ElektroikHayvanKimliklendirmeAPI.Controllers
{
    public class HayvanHastalikController : ApiController
    {
        private Hayvancilikta_Elektronik_KimliklendirmeEntities db = new Hayvancilikta_Elektronik_KimliklendirmeEntities();

        // GET: api/HayvanHastalik
        public IQueryable<HayvanHastalik> GetHayvanHastalik()
        {
            return db.HayvanHastalik;
        }

        // GET: api/HayvanHastalik/5
        [ResponseType(typeof(HayvanHastalik))]
        public IHttpActionResult GetHayvanHastalik(int id)
        {
            HayvanHastalik hayvanHastalik = db.HayvanHastalik.Find(id);
            if (hayvanHastalik == null)
            {
                return NotFound();
            }

            return Ok(hayvanHastalik);
        }

        // PUT: api/HayvanHastalik/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHayvanHastalik(int id, HayvanHastalik hayvanHastalik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hayvanHastalik.Id)
            {
                return BadRequest();
            }

            db.Entry(hayvanHastalik).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HayvanHastalikExists(id))
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

        // POST: api/HayvanHastalik
        [ResponseType(typeof(HayvanHastalik))]
        [HttpOptions]
        [HttpPost]
        public IHttpActionResult PostHayvanHastalik(HayvanHastalik hayvanHastalik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HayvanHastalik.Add(hayvanHastalik);
            try{ 
            db.SaveChanges(); }
             catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return CreatedAtRoute("DefaultApi", new { id = hayvanHastalik.Id }, hayvanHastalik);
        }

        // DELETE: api/HayvanHastalik/5
        [ResponseType(typeof(HayvanHastalik))]
        public IHttpActionResult DeleteHayvanHastalik(int id)
        {
            HayvanHastalik hayvanHastalik = db.HayvanHastalik.Find(id);
            if (hayvanHastalik == null)
            {
                return NotFound();
            }

            db.HayvanHastalik.Remove(hayvanHastalik);
            db.SaveChanges();

            return Ok(hayvanHastalik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HayvanHastalikExists(int id)
        {
            return db.HayvanHastalik.Count(e => e.Id == id) > 0;
        }
    }
}