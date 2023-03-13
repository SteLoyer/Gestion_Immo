using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionImmobiliere.DataContext;
using Gestion_Immobiliére.Models;

namespace GestionImmobiliere.Controllers
{
    public class OwnersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Owners
        public ActionResult Index()
        {
            return View(db.Owners.ToList());
        }

        // GET: Owners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner ownerClass = db.Owners.Find(id);
            if (ownerClass == null)
            {
                return HttpNotFound();
            }
            return View(ownerClass);
        }

        // GET: Owners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnerClasses/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_owner,Name_owner,First_name_owner,E_mail_owner,Phone_number_owner")] Owner ownerClass)
        {
            if (ModelState.IsValid)
            {
                db.Owners.Add(ownerClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ownerClass);
        }

        // GET: Owners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner ownerClass = db.Owners.Find(id);
            if (ownerClass == null)
            {
                return HttpNotFound();
            }
            return View(ownerClass);
        }

        // POST: Owners/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_owner,Name_owner,First_name_owner,E_mail_owner,Phone_number_owner")] Owner ownerClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ownerClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ownerClass);
        }

        // GET: Owners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner ownerClass = db.Owners.Find(id);
            if (ownerClass == null)
            {
                return HttpNotFound();
            }
            return View(ownerClass);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Owner ownerClass = db.Owners.Find(id);
            db.Owners.Remove(ownerClass);
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
