using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebapplicationGuarderia.Models;

namespace WebapplicationGuarderia.Controllers
{
    public class niñosController : Controller
    {
        private BDDguarderiaEntities db = new BDDguarderiaEntities();

        // GET: niños
        public ActionResult Index()
        {
            return View(db.niños.ToList());
        }

        // GET: niños/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            niños niños = db.niños.Find(id);
            if (niños == null)
            {
                return HttpNotFound();
            }
            return View(niños);
        }

        // GET: niños/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: niños/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idniños,nombre,apellido,edad,sexo")] niños niños)
        {
            if (ModelState.IsValid)
            {
                db.niños.Add(niños);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(niños);
        }

        // GET: niños/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            niños niños = db.niños.Find(id);
            if (niños == null)
            {
                return HttpNotFound();
            }
            return View(niños);
        }

        // POST: niños/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idniños,nombre,apellido,edad,sexo")] niños niños)
        {
            if (ModelState.IsValid)
            {
                db.Entry(niños).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(niños);
        }

        // GET: niños/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            niños niños = db.niños.Find(id);
            if (niños == null)
            {
                return HttpNotFound();
            }
            return View(niños);
        }

        // POST: niños/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            niños niños = db.niños.Find(id);
            db.niños.Remove(niños);
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
