using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FleeteInvoicing.Models;

namespace FleeteInvoicing.Controllers
{
    public class PaymentMethodController : Controller
    {
        private FleeteInvoicingEntities db = new FleeteInvoicingEntities();

        public ActionResult Index()
        {
            return View(db.CAT_PAYMENTMETHODTYPE.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "paymentMethodTypeId,paymentMethodTypeCode,paymentMethodDesc")] CAT_PAYMENTMETHODTYPE cAT_PAYMENTMETHODTYPE)
        {
            if (ModelState.IsValid)
            {
                db.CAT_PAYMENTMETHODTYPE.Add(cAT_PAYMENTMETHODTYPE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cAT_PAYMENTMETHODTYPE);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAT_PAYMENTMETHODTYPE cAT_PAYMENTMETHODTYPE = db.CAT_PAYMENTMETHODTYPE.Find(id);
            if (cAT_PAYMENTMETHODTYPE == null)
            {
                return HttpNotFound();
            }
            return View(cAT_PAYMENTMETHODTYPE);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "paymentMethodTypeId,paymentMethodTypeCode,paymentMethodDesc")] CAT_PAYMENTMETHODTYPE cAT_PAYMENTMETHODTYPE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cAT_PAYMENTMETHODTYPE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cAT_PAYMENTMETHODTYPE);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAT_PAYMENTMETHODTYPE cAT_PAYMENTMETHODTYPE = db.CAT_PAYMENTMETHODTYPE.Find(id);
            if (cAT_PAYMENTMETHODTYPE == null)
            {
                return HttpNotFound();
            }
            return View(cAT_PAYMENTMETHODTYPE);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CAT_PAYMENTMETHODTYPE cAT_PAYMENTMETHODTYPE = db.CAT_PAYMENTMETHODTYPE.Find(id);
            db.CAT_PAYMENTMETHODTYPE.Remove(cAT_PAYMENTMETHODTYPE);
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
