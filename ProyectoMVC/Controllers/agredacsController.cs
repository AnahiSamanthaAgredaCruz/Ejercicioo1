using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class agredacsController : Controller
    {
        private Datacontext db = new Datacontext();

        // GET: agredacs
        [Authorize]
        public ActionResult Index()
        {
            return View(db.agredacs.ToList());
        }

        // GET: agredacs/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agredac agredac = db.agredacs.Find(id);
            if (agredac == null)
            {
                return HttpNotFound();
            }
            return View(agredac);
        }

        // GET: agredacs/Create
        [Authorize]
        public ActionResult Create()

        {
            return View();
        }

        // POST: agredacs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "agredaID,Friendofagreda,Place_lista,email,Birthday")] agredac agredac)
        {
            if (ModelState.IsValid)
            {
                db.agredacs.Add(agredac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agredac);
        }

        // GET: agredacs/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agredac agredac = db.agredacs.Find(id);
            if (agredac == null)
            {
                return HttpNotFound();
            }
            return View(agredac);
        }

        // POST: agredacs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "agredaID,Friendofagreda,Place_lista,email,Birthday")] agredac agredac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agredac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agredac);
        }

        // GET: agredacs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            agredac agredac = db.agredacs.Find(id);
            if (agredac == null)
            {
                return HttpNotFound();
            }
            return View(agredac);
        }

        // POST: agredacs/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            agredac agredac = db.agredacs.Find(id);
            db.agredacs.Remove(agredac);
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
