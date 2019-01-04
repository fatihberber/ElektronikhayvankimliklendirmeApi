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
    public class VeterinerKimlikController : ApiController
    {
        private Hayvancilikta_Elektronik_KimliklendirmeEntities db = new Hayvancilikta_Elektronik_KimliklendirmeEntities();

        // GET: api/VeterinerKimlik
        public IQueryable<VeterinerKimlik> GetVeterinerKimlik()
        {
            return db.VeterinerKimlik;
        }

        // GET: api/VeterinerKimlik/5
        [ResponseType(typeof(VeterinerKimlik))]
        public IHttpActionResult GetVeterinerKimlik(int id)
        {
            VeterinerKimlik veterinerKimlik = db.VeterinerKimlik.Find(id);
            if (veterinerKimlik == null)
            {
                return NotFound();
            }

            return Ok(veterinerKimlik);
        }

        // PUT: api/VeterinerKimlik/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVeterinerKimlik(int id, VeterinerKimlik veterinerKimlik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != veterinerKimlik.VeterinerNo)
            {
                return BadRequest();
            }

            db.Entry(veterinerKimlik).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeterinerKimlikExists(id))
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

        // POST: api/VeterinerKimlik
        [ResponseType(typeof(VeterinerKimlik))]
        public IHttpActionResult PostVeterinerKimlik(VeterinerKimlik veterinerKimlik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VeterinerKimlik.Add(veterinerKimlik);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = veterinerKimlik.VeterinerNo }, veterinerKimlik);
        }

        // DELETE: api/VeterinerKimlik/5
        [ResponseType(typeof(VeterinerKimlik))]
        public IHttpActionResult DeleteVeterinerKimlik(int id)
        {
            VeterinerKimlik veterinerKimlik = db.VeterinerKimlik.Find(id);
            if (veterinerKimlik == null)
            {
                return NotFound();
            }

            db.VeterinerKimlik.Remove(veterinerKimlik);
            db.SaveChanges();

            return Ok(veterinerKimlik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VeterinerKimlikExists(int id)
        {
            return db.VeterinerKimlik.Count(e => e.VeterinerNo == id) > 0;
        }
    }
}