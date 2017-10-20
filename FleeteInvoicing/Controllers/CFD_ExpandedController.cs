using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FleeteInvoicing.Models;

namespace FleeteInvoicing.Controllers
{
    public class CFD_ExpandedController : Controller
    {
        private FleeteInvoicingEntities db = new FleeteInvoicingEntities();

        [CustomAuthorize(Roles = "ExpandedView")]
        public ActionResult Index()
        {
            return View(db.CFD_EXPANDED_ADDRESS1.ToList());
        }

        [CustomAuthorize(Roles = "ExpandedView")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFD_EXPANDED_ADDRESS1 cFD_EXPANDED_ADDRESS1 = db.CFD_EXPANDED_ADDRESS1.Find(id);
            if (cFD_EXPANDED_ADDRESS1 == null)
            {
                return HttpNotFound();
            }
            return View(cFD_EXPANDED_ADDRESS1);
        }

        [CustomAuthorize(Roles = "ExpandedCreate")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CUSTID,CORP_CD,CNTC_NO,ADDRESS1,ADDRESS2,ADDRESS3,CITY,STATE,ZIP,CUSTNAME,RFC,PAYMENT_METHOD_TYPE,CFDI_USAGE")] CFD_EXPANDED_ADDRESS1 cFD_EXPANDED_ADDRESS1)
        {
            if (ModelState.IsValid)
            {
                db.CFD_EXPANDED_ADDRESS1.Add(cFD_EXPANDED_ADDRESS1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cFD_EXPANDED_ADDRESS1);
        }

        [CustomAuthorize(Roles = "ExpandedEdit")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFD_EXPANDED_ADDRESS1 cFD_EXPANDED_ADDRESS1 = db.CFD_EXPANDED_ADDRESS1.Find(id);
            if (cFD_EXPANDED_ADDRESS1 == null)
            {
                return HttpNotFound();
            }
            return View(cFD_EXPANDED_ADDRESS1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CUSTID,CORP_CD,CNTC_NO,ADDRESS1,ADDRESS2,ADDRESS3,CITY,STATE,ZIP,CUSTNAME,RFC,PAYMENT_METHOD_TYPE,CFDI_USAGE")] CFD_EXPANDED_ADDRESS1 cFD_EXPANDED_ADDRESS1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cFD_EXPANDED_ADDRESS1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cFD_EXPANDED_ADDRESS1);
        }

        [CustomAuthorize(Roles = "ExpandedDelete")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFD_EXPANDED_ADDRESS1 cFD_EXPANDED_ADDRESS1 = db.CFD_EXPANDED_ADDRESS1.Find(id);
            if (cFD_EXPANDED_ADDRESS1 == null)
            {
                return HttpNotFound();
            }
            return View(cFD_EXPANDED_ADDRESS1);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CFD_EXPANDED_ADDRESS1 cFD_EXPANDED_ADDRESS1 = db.CFD_EXPANDED_ADDRESS1.Find(id);
            db.CFD_EXPANDED_ADDRESS1.Remove(cFD_EXPANDED_ADDRESS1);
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
