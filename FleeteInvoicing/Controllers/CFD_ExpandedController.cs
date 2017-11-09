using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FleeteInvoicing.Models;
using System.Threading.Tasks;

namespace FleeteInvoicing.Controllers
{
    public class CFD_ExpandedController : Controller
    {
        private FleeteInvoicingEntities db = new FleeteInvoicingEntities();

        [CustomAuthorize(Roles = "ExpandedView",NotifyUrl = "/Error/Unauthorized")]
        public async Task<ActionResult> Index()
        {
            return View(await db.CFD_EXPANDED_ADDRESS1.ToListAsync());
        }

        [CustomAuthorize(Roles = "ExpandedView", NotifyUrl = "/Error/Unauthorized")]
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFD_EXPANDED_ADDRESS1 cFD_EXPANDED_ADDRESS1 = await db.CFD_EXPANDED_ADDRESS1.FindAsync(id);
            if (cFD_EXPANDED_ADDRESS1 == null)
            {
                return HttpNotFound();
            }
            return View(cFD_EXPANDED_ADDRESS1);
        }

        [CustomAuthorize(Roles = "ExpandedCreate", NotifyUrl = "/Error/Unauthorized")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CUSTID,CORP_CD,CNTC_NO,ADDRESS1,ADDRESS2,ADDRESS3,CITY,STATE,ZIP,CUSTNAME,RFC,PAYMENT_METHOD_TYPE,CFDI_USAGE")] CFD_EXPANDED_ADDRESS1 cFD_EXPANDED_ADDRESS1)
        {
            if (ModelState.IsValid)
            {
                db.CFD_EXPANDED_ADDRESS1.Add(cFD_EXPANDED_ADDRESS1);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cFD_EXPANDED_ADDRESS1);
        }

        [CustomAuthorize(Roles = "ExpandedEdit", NotifyUrl = "/Error/Unauthorized")]
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFD_EXPANDED_ADDRESS1 cFD_EXPANDED_ADDRESS1 = await db.CFD_EXPANDED_ADDRESS1.FindAsync(id);
            if (cFD_EXPANDED_ADDRESS1 == null)
            {
                return HttpNotFound();
            }
            return View(cFD_EXPANDED_ADDRESS1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CUSTID,CORP_CD,CNTC_NO,ADDRESS1,ADDRESS2,ADDRESS3,CITY,STATE,ZIP,CUSTNAME,RFC,PAYMENT_METHOD_TYPE,CFDI_USAGE")] CFD_EXPANDED_ADDRESS1 cFD_EXPANDED_ADDRESS1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cFD_EXPANDED_ADDRESS1).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cFD_EXPANDED_ADDRESS1);
        }

        [CustomAuthorize(Roles = "ExpandedDelete", NotifyUrl = "/Error/Unauthorized")]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFD_EXPANDED_ADDRESS1 cFD_EXPANDED_ADDRESS1 = await db.CFD_EXPANDED_ADDRESS1.FindAsync(id);
            if (cFD_EXPANDED_ADDRESS1 == null)
            {
                return HttpNotFound();
            }
            return View(cFD_EXPANDED_ADDRESS1);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            CFD_EXPANDED_ADDRESS1 cFD_EXPANDED_ADDRESS1 = db.CFD_EXPANDED_ADDRESS1.Find(id);
            db.CFD_EXPANDED_ADDRESS1.Remove(cFD_EXPANDED_ADDRESS1);
            await db.SaveChangesAsync();
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
