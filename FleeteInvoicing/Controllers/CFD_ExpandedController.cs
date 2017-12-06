using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using FleeteInvoicing.Models;
using System.Threading.Tasks;
using System;

namespace FleeteInvoicing.Controllers
{
    public class CFD_ExpandedController : Controller
    {
        private FleeteInvoicingEntities db = new FleeteInvoicingEntities();

        [CustomAuthorize(Roles = "ExpandedView",NotifyUrl = "/Error/Unauthorized")]
        public async Task<ActionResult> Index()
        {
            TempData["Customers"] = await db.CFD_EXPANDED_ADDRESS.OrderBy(s => s.CUSTNAME).ToListAsync();
            ViewBag.ListPayment = await db.CAT_PAYMENTMETHODTYPE.ToListAsync();
            ViewBag.Warning = Session["MessageWarning"] == null ? null : Session["MessageWarning"].ToString();
            ViewBag.Message = Session["Message"] == null ? null : Session["Message"].ToString();
            Session.Clear();
            return View();
        }

        [CustomAuthorize(Roles = "ExpandedCreate", NotifyUrl = "/Error/Unauthorized")]
        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CUSTID,CORP_CD,CNTC_NO,ADDRESS1,ADDRESS2,ADDRESS3,CITY,STATE,ZIP,CUSTNAME,RFC,PAYMENT_METHOD_TYPE")] CFD_EXPANDED_ADDRESS CFD_Expanded_Address)
        {
            var customer = await db.CFD_EXPANDED_ADDRESS.FindAsync(CFD_Expanded_Address.CUSTID);

            if (customer == null)
            {
                if (ModelState.IsValid)
                {
                    CFD_Expanded_Address.CORP_CD = "MX";
                    CFD_Expanded_Address.CNTC_NO = "0001";
                    CFD_Expanded_Address.CREATED = DateTime.Now;
                    CFD_Expanded_Address.CREATEDBY = Environment.UserName;

                    db.CFD_EXPANDED_ADDRESS.Add(CFD_Expanded_Address);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                Session["MessageWarning"] = "El cliente que desea ingresar ya existe.";
                return RedirectToAction("Index");
            }

            return View(CFD_Expanded_Address);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "ExpandedEdit", NotifyUrl = "/Error/Unauthorized")]
        public async Task<JsonResult> Editing(string id)
        {
            try
            {
                Session["CustomerID"] = id;
                var customer = await db.CFD_EXPANDED_ADDRESS.FindAsync(id);
                CFD_EXPANDED_ADDRESS expanded = new CFD_EXPANDED_ADDRESS()
                {
                     CUSTID = customer.CUSTID,
                     CORP_CD = "MX",
                     CNTC_NO = "0001",
                     ADDRESS1 = customer.ADDRESS1,
                     ADDRESS2 = customer.ADDRESS2,
                     ADDRESS3 = customer.ADDRESS3,
                     CITY = customer.CITY,
                     STATE = customer.STATE,
                     ZIP = customer.ZIP,
                     CUSTNAME = customer.CUSTNAME ,
                     RFC = customer.RFC,
                     PAYMENT_METHOD_TYPE = customer.PAYMENT_METHOD_TYPE,
                };
                return new JsonResult
                {
                    Data = expanded,
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
        public async Task<ActionResult> Edit([Bind(Include = "CUSTID,CORP_CD,CNTC_NO,ADDRESS1,ADDRESS2,ADDRESS3,CITY,STATE,ZIP,CUSTNAME,RFC,PAYMENT_METHOD_TYPE")] CFD_EXPANDED_ADDRESS CFD_Expanded_Address)
        {
            if (Session["CustomerID"] != null)
            {
                string CustomerID = Session["CustomerID"].ToString();
          
                if (!String.IsNullOrWhiteSpace(CustomerID))
                {
                    if (ModelState.IsValid)
                    {
                        CFD_Expanded_Address.CUSTID = CustomerID;
                        CFD_Expanded_Address.CREATED = DateTime.Now;
                        CFD_Expanded_Address.CREATEDBY = Environment.UserName;
                        db.Entry(CFD_Expanded_Address).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        Session["MessageWarning"] = "Se actualizó el cliente " + CustomerID + " correctamente !! ";
                    }
                }
                else
                {
                    Session["MessageWarning"] = "No se pudo actualizar el cliente, Comunicate con el administrador del sistema.";
                }
            }

            return RedirectToAction("Index");
        }

        [CustomAuthorize(Roles = "ExpandedDelete", NotifyUrl = "/Error/Unauthorized")]
        public async Task<JsonResult> Deleting(string id)
        {
            try
            {
                Session["CustomerID"] = id;
                var customer = await db.CFD_EXPANDED_ADDRESS.FindAsync(id);
                CFD_EXPANDED_ADDRESS expanded = new CFD_EXPANDED_ADDRESS()
                {
                    CUSTID = customer.CUSTID,
                    CORP_CD = customer.CORP_CD,
                    CNTC_NO = customer.CNTC_NO,
                    ADDRESS1 = customer.ADDRESS1,
                    ADDRESS2 = customer.ADDRESS2,
                    ADDRESS3 = customer.ADDRESS3,
                    CITY = customer.CITY,
                    STATE = customer.STATE,
                    ZIP = customer.ZIP,
                    CUSTNAME = customer.CUSTNAME,
                    RFC = customer.RFC,
                    PAYMENT_METHOD_TYPE = customer.PAYMENT_METHOD_TYPE,
                };

                return new JsonResult
                {
                    Data = expanded,
                    MaxJsonLength = int.MaxValue,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
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
            if (Session["CustomerID"] != null)
            {
                string CustomerID = Session["CustomerID"].ToString();

                if (!String.IsNullOrWhiteSpace(CustomerID))
                {
                    if (ModelState.IsValid)
                    {
                        CFD_EXPANDED_ADDRESS CFD_Expanded_Address = db.CFD_EXPANDED_ADDRESS.Find(CustomerID);
                        db.CFD_EXPANDED_ADDRESS.Remove(CFD_Expanded_Address);
                        await db.SaveChangesAsync();
                        Session["MessageWarning"] = "Se elimino el cliente  " + CustomerID + " correctamente !! ";
                    }
                }
                else
                {
                    Session["MessageWarning"] = "No se pudo eliminar el cliente, Comunicate con el administrador del sistema …… ";
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
