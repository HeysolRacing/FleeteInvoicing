using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FleeteInvoicing.Models;

namespace FleeteInvoicing.Controllers
{
    public class UniversalCollectionController : Controller
    {
        private FleeteInvoicingEntities db = new FleeteInvoicingEntities();

        [CustomAuthorize(Roles = "UniversalView")]
        public ActionResult Index()
        {
            return View(db.UNIVERSAL_COLLECTION.ToList());
        }

        [CustomAuthorize(Roles = "UniversalView")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UNIVERSAL_COLLECTION uNIVERSAL_COLLECTION = db.UNIVERSAL_COLLECTION.Find(id);
            if (uNIVERSAL_COLLECTION == null)
            {
                return HttpNotFound();
            }
            return View(uNIVERSAL_COLLECTION);
        }

        [CustomAuthorize(Roles = "UniversalCreate")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniversalCollection/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_universal,uc_fleet,uc_account,uc_clabe,uc_aba,uc_swift,uc_currency")] UNIVERSAL_COLLECTION uNIVERSAL_COLLECTION)
        {
            if (ModelState.IsValid)
            {
                db.UNIVERSAL_COLLECTION.Add(uNIVERSAL_COLLECTION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uNIVERSAL_COLLECTION);
        }

        [CustomAuthorize(Roles = "UniversalEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UNIVERSAL_COLLECTION uNIVERSAL_COLLECTION = db.UNIVERSAL_COLLECTION.Find(id);
            if (uNIVERSAL_COLLECTION == null)
            {
                return HttpNotFound();
            }
            return View(uNIVERSAL_COLLECTION);
        }

        // POST: UniversalCollection/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_universal,uc_fleet,uc_account,uc_clabe,uc_aba,uc_swift,uc_currency")] UNIVERSAL_COLLECTION uNIVERSAL_COLLECTION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uNIVERSAL_COLLECTION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uNIVERSAL_COLLECTION);
        }

        [CustomAuthorize(Roles = "UniversalDelete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UNIVERSAL_COLLECTION uNIVERSAL_COLLECTION = db.UNIVERSAL_COLLECTION.Find(id);
            if (uNIVERSAL_COLLECTION == null)
            {
                return HttpNotFound();
            }
            return View(uNIVERSAL_COLLECTION);
        }

        // POST: UniversalCollection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UNIVERSAL_COLLECTION uNIVERSAL_COLLECTION = db.UNIVERSAL_COLLECTION.Find(id);
            db.UNIVERSAL_COLLECTION.Remove(uNIVERSAL_COLLECTION);
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
