using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using FleeteInvoicing.Models;
using System.Threading.Tasks;

namespace FleeteInvoicing.Controllers
{
    public class UniversalCollectionController : Controller
    {
        private FleeteInvoicingEntities db = new FleeteInvoicingEntities();

        [CustomAuthorize(Roles = "UniversalView", NotifyUrl = "/Error/Unauthorized")]
        public async Task<ActionResult> Index()
        {
            TempData["Universal"] = await db.UNIVERSAL_COLLECTION.OrderBy(s => s.uc_fleet).ToListAsync();
            ViewBag.Warning = Session["MessageWarning"] == null ? null : Session["MessageWarning"].ToString();
            ViewBag.Message = Session["Message"] == null ? null : Session["Message"].ToString();
            Session.Clear();
            return View();
        }

        [CustomAuthorize(Roles = "UniversalCreate", NotifyUrl = "/Error/Unauthorized")]
        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "uc_fleet,uc_account,uc_clabe,uc_aba,uc_swift,uc_currency")] UNIVERSAL_COLLECTION uNIVERSAL_COLLECTION)
        {
            if (ModelState.IsValid)
            {
                db.UNIVERSAL_COLLECTION.Add(uNIVERSAL_COLLECTION);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(uNIVERSAL_COLLECTION);
        }

        [CustomAuthorize(Roles = "UniversalEdit", NotifyUrl = "/Error/Unauthorized")]
        public async Task<JsonResult> Editing(string id)
        {
            try
            {
                Session["UniversalID"] = id;
                var universal = await db.UNIVERSAL_COLLECTION.FindAsync(int.Parse(id));

                UNIVERSAL_COLLECTION universalcollection = new UNIVERSAL_COLLECTION()
                {
                    uc_fleet = universal.uc_fleet,
                    uc_account = universal.uc_fleet,
                    uc_clabe = universal.uc_fleet,
                    uc_aba = universal.uc_aba,
                    uc_swift = universal.uc_swift,
                    uc_currency = universal.uc_currency
                };
                return new JsonResult
                {
                    Data = universalcollection,
                    MaxJsonLength = int.MaxValue,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error:[Editing] :: {0} ", ex.Message));
            }
        }

        // POST: UniversalCollection/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_universal,uc_fleet,uc_account,uc_clabe,uc_aba,uc_swift,uc_currency")] UNIVERSAL_COLLECTION uNIVERSAL_COLLECTION)
        {
            if (Session["UniversalID"] != null)
            {
                if (!String.IsNullOrWhiteSpace(Session["UniversalID"].ToString()))
                {
                    int universalID = int.Parse(Session["UniversalID"].ToString());

                    if (ModelState.IsValid)
                    {
                        uNIVERSAL_COLLECTION.id_universal = universalID;
                        db.Entry(uNIVERSAL_COLLECTION).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        Session["MessageWarning"] = "Se actualiz&oacute; la informaci&oacute;n correctamente !! ";
                    }
                }
                else
                {
                    Session["MessageWarning"] = "No se pudo actualizar la cuenta virtual, Comunicate con el administrador del sistema.";
                }
            }

            return RedirectToAction("Index");
        }

        [CustomAuthorize(Roles = "UniversalDelete", NotifyUrl = "/Error/Unauthorized")]
        public async Task<JsonResult> Deleting(string id)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(id))
                {
                    Session["UniversalID"] = id;
                    var universal = await db.UNIVERSAL_COLLECTION.FindAsync(int.Parse(id));

                    UNIVERSAL_COLLECTION universalcollection = new UNIVERSAL_COLLECTION()
                    {
                       uc_fleet = universal.uc_fleet,
                       uc_account = universal.uc_fleet,
                       uc_clabe = universal.uc_fleet,
                       uc_aba = universal.uc_aba,
                       uc_swift = universal.uc_swift,
                       uc_currency = universal.uc_currency
                    };
                    return new JsonResult
                    {
                        Data = universalcollection,
                        MaxJsonLength = int.MaxValue,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    throw new Exception("Error de comunicaci&oacute;n. Vuelva a intentarlo o comuniquese con el administrador. ");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error:[Deleting] :: {0} ", ex.Message));
            }
        }

        // POST: UniversalCollection/Delete/5
        [HttpPost, ActionName("Delete")]
        [CustomAuthorize(Roles = "UniversalDelete", NotifyUrl = "/Error/Unauthorized")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ? id)
        {
            if (id != null)
            {
                if (id > 0)
                {
                    UNIVERSAL_COLLECTION uNIVERSAL_COLLECTION = db.UNIVERSAL_COLLECTION.Find(id);
                    db.UNIVERSAL_COLLECTION.Remove(uNIVERSAL_COLLECTION);
                    db.SaveChanges();
                }
                else
                {
                    Session["MessageWarning"] = "No se pudo actualizar la cuenta virtual, Comunicate con el administrador del sistema.";
                }
            }
            else
            {
                Session["MessageWarning"] = "Usted no cuenta con los permisos suficientes para realizar esta acci&oacute;n, Comunicate con el administrador del sistema.";
            }
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
