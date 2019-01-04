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
    public class HayvanKimlikController : ApiController
    {
        private Hayvancilikta_Elektronik_KimliklendirmeEntities db = new Hayvancilikta_Elektronik_KimliklendirmeEntities();

        // GET: api/HayvanKimlik
        public IQueryable<HayvanKimlik> GetHayvanKimlik()
        {
            return db.HayvanKimlik;
        }

        // GET: api/HayvanKimlik/5
        [ResponseType(typeof(HayvanKimlik))]
        public IHttpActionResult GetHayvanKimlik(string id)
        {
            HayvanKimlik hayvanKimlik = db.HayvanKimlik.Find(id);
            if (hayvanKimlik == null)
            {
                return NotFound();
            }

            return Ok(hayvanKimlik);
        }

        // PUT: api/HayvanKimlik/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHayvanKimlik(string id, HayvanKimlik hayvanKimlik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hayvanKimlik.KupeNo)
            {
                return BadRequest();
            }

            db.Entry(hayvanKimlik).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HayvanKimlikExists(id))
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

        // POST: api/HayvanKimlik
        [ResponseType(typeof(HayvanKimlik))]
        [HttpOptions]
        [HttpPost]
        public IHttpActionResult PostHayvanKimlik(HayvanKimlik hayvanKimlik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HayvanKimlik.Add(hayvanKimlik);

            try
            {
                db.SaveChanges();
            }
            /*catch (DbUpdateException)
             {
                 if (HayvanKimlikExists(hayvanKimlik.KupeNo))
                 {
                     return Conflict();
                 }
                 else
                 {
                     throw;
                 }
             }*/
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


            return CreatedAtRoute("DefaultApi", new { id = hayvanKimlik.KupeNo }, hayvanKimlik);
        }

        // DELETE: api/HayvanKimlik/5
        [ResponseType(typeof(HayvanKimlik))]
        public IHttpActionResult DeleteHayvanKimlik(string id)
        {
            HayvanKimlik hayvanKimlik = db.HayvanKimlik.Find(id);
            if (hayvanKimlik == null)
            {
                return NotFound();
            }

            db.HayvanKimlik.Remove(hayvanKimlik);
            db.SaveChanges();

            return Ok(hayvanKimlik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HayvanKimlikExists(string id)
        {
            return db.HayvanKimlik.Count(e => e.KupeNo == id) > 0;
        }
    }
}