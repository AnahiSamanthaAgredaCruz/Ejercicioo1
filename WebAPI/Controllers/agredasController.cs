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
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class agredasController : ApiController
    {
        private Datacontext db = new Datacontext();
        
        // GET: api/agredas
        [Authorize]
        public IQueryable<agreda> Getagredas()
        {
            return db.agredas;
        }

        // GET: api/agredas/5
        [Authorize]
        [ResponseType(typeof(agreda))]
        public IHttpActionResult Getagreda(int id)
        {
            agreda agreda = db.agredas.Find(id);
            if (agreda == null)
            {
                return NotFound();
            }

            return Ok(agreda);
        }

        // PUT: api/agredas/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Putagreda(int id, agreda agreda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agreda.agredaID)
            {
                return BadRequest();
            }

            db.Entry(agreda).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!agredaExists(id))
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

        // POST: api/agredas
        [Authorize]
        [ResponseType(typeof(agreda))]
        public IHttpActionResult Postagreda(agreda agreda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.agredas.Add(agreda);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = agreda.agredaID }, agreda);
        }

        public object Deleteagreda(agreda modelo)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/agredas/5
        [Authorize]
        [ResponseType(typeof(agreda))]
        public IHttpActionResult Deleteagreda(int id)
        {
            agreda agreda = db.agredas.Find(id);
            if (agreda == null)
            {
                return NotFound();
            }

            db.agredas.Remove(agreda);
            db.SaveChanges();

            return Ok(agreda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool agredaExists(int id)
        {
            return db.agredas.Count(e => e.agredaID == id) > 0;
        }
    }
}