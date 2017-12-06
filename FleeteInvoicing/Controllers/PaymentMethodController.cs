using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using FleeteInvoicing.Models;
using System.Threading.Tasks;
using System;
using System.Web;

namespace FleeteInvoicing.Controllers
{
    public class PaymentMethodController : Controller
    {
        private FleeteInvoicingEntities db = new FleeteInvoicingEntities();

        [CustomAuthorize(Roles = "PaymentMethodView", NotifyUrl = "/Error/Unauthorized")]
        public async Task<ActionResult> Index()
        {
            TempData["PaymentMethod"] = await db.CAT_PAYMENTMETHODTYPE.OrderBy(s => s.paymentMethodTypeCode).ToListAsync();
            ViewBag.Warning = Session["MessageWarning"] == null ? null : Session["MessageWarning"].ToString();
            ViewBag.Message = Session["Message"] == null ? null : Session["Message"].ToString();
            Session.Clear();
            return View();
        }

        [CustomAuthorize(Roles = "PaymentMethodCreate", NotifyUrl = "/Error/Unauthorized")]
        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "paymentMethodTypeCode,paymentMethodDesc")] CAT_PAYMENTMETHODTYPE cAT_PAYMENTMETHODTYPE)
        {
            var payment = await db.CAT_PAYMENTMETHODTYPE.FindAsync(cAT_PAYMENTMETHODTYPE.paymentMethodTypeCode);

            if (payment == null)
            {
                if (ModelState.IsValid)
                {
                    cAT_PAYMENTMETHODTYPE.Created = DateTime.Now;
                    cAT_PAYMENTMETHODTYPE.CreatedBy = Environment.UserName;
                    db.CAT_PAYMENTMETHODTYPE.Add(cAT_PAYMENTMETHODTYPE);
                    await db.SaveChangesAsync();
                }
            }
            else
            {
                Session["MessageWarning"] = "La forma de pago que deseas ingresar ya existe en el sistema.";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [CustomAuthorize(Roles = "PaymentMethodEdit", NotifyUrl = "/Error/Unauthorized")]
        public async Task<JsonResult> Editing(string id)
        {
            try
            {
                Session["PaymentID"] = id;
                var payment = await db.CAT_PAYMENTMETHODTYPE.FindAsync(id);

                CAT_PAYMENTMETHODTYPE paymentMethod = new CAT_PAYMENTMETHODTYPE()
                {
                    paymentMethodTypeCode = payment.paymentMethodTypeCode,
                    paymentMethodDesc = payment.paymentMethodDesc,
                };
                return new JsonResult
                {
                    Data = paymentMethod,
                    MaxJsonLength = int.MaxValue,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error:[Editing] :: {0} ", ex.Message));
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "paymentMethodTypeId,paymentMethodTypeCode,paymentMethodDesc")] CAT_PAYMENTMETHODTYPE cAT_PAYMENTMETHODTYPE)
        {
            if (Session["PaymentID"] != null)
            {
                if (!String.IsNullOrWhiteSpace(Session["PaymentID"].ToString()))
                {
                    string paymentID = Session["PaymentID"].ToString();

                    if (ModelState.IsValid)
                    {
                        cAT_PAYMENTMETHODTYPE.paymentMethodTypeCode = paymentID;
                        cAT_PAYMENTMETHODTYPE.Created = DateTime.Now;
                        cAT_PAYMENTMETHODTYPE.CreatedBy = Environment.UserName;

                        db.Entry(cAT_PAYMENTMETHODTYPE).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        Session["MessageWarning"] = "La forma de pago " + paymentID + " se actualizo correctamente !! ";
                    }
                }
                else
                {
                    Session["MessageWarning"] = "No se pudo actualizar el forma de pago, Comunicate con el administrador del sistema.";
                }
            }

            return RedirectToAction("Index");
        }

        [CustomAuthorize(Roles = "PaymentMethodDelete", NotifyUrl = "/Error/Unauthorized")]
        public async Task<JsonResult> Deleting(string id)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(id))
                {
                    Session["PaymentID"] = id;
                    var payment = await db.CAT_PAYMENTMETHODTYPE.FindAsync(id);

                    CAT_PAYMENTMETHODTYPE paymentMethod = new CAT_PAYMENTMETHODTYPE()
                    {
                        paymentMethodTypeCode = payment.paymentMethodTypeCode,
                        paymentMethodDesc = payment.paymentMethodDesc,
                    };
                    return new JsonResult
                    {
                        Data = paymentMethod,
                        MaxJsonLength = int.MaxValue,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    throw new Exception(HttpUtility.HtmlEncode("Error de comunicación. Vuelva a intentarlo o comuniquese con el administrador. "));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error:[Deleting] :: {0} ", ex.Message));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            if (Session["PaymentID"] != null)
            {
                if (!String.IsNullOrWhiteSpace(Session["PaymentID"].ToString()))
                {
                    string paymentID = Session["PaymentID"].ToString();

                    if (ModelState.IsValid)
                    {
                        CAT_PAYMENTMETHODTYPE cAT_PAYMENTMETHODTYPE = db.CAT_PAYMENTMETHODTYPE.Find(paymentID);
                        db.CAT_PAYMENTMETHODTYPE.Remove(cAT_PAYMENTMETHODTYPE);
                        await db.SaveChangesAsync();
                        Session["MessageWarning"] = HttpUtility.HtmlEncode("La forma de pago " + paymentID + " se elimino correctamente !! ");
                    }
                }
                else
                {
                    Session["MessageWarning"] = "No se pudo eliminar la forma de pago, Comunicate con el administrador del sistema.";
                }
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
