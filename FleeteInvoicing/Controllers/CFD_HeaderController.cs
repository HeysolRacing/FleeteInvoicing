using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using FleeteInvoicing.Models;
using System.Threading.Tasks;

namespace FleeteInvoicing.Controllers
{
    public class CFD_HeaderController : Controller
    {
        private FleeteInvoicingEntities db = new FleeteInvoicingEntities();

        // GET: Header
        [CustomAuthorize(Roles = "HeaderView", NotifyUrl = "/Error/Unauthorized")]
        public async Task<ActionResult> Index()
        {
            TempData["CFD_Header"] = await db.CFD_HEADER.OrderBy(s => s.headerFleet).ToListAsync();
            ViewBag.Warning = Session["MessageWarning"] == null ? null : Session["MessageWarning"].ToString();
            ViewBag.Message = Session["Message"] == null ? null : Session["Message"].ToString();
            Session.Clear();
            return View();
        }

        [HttpPost]
        //[CustomAuthorize(Roles = "HeaderEdit", NotifyUrl = "/Error/Unauthorized")]
        public async Task<JsonResult> Editing(string id)
        {
            try
            {
                Session["Header"] = id;
                var CFD_header = await db.CFD_HEADER.FindAsync(id);
                CFD_HEADER header = new CFD_HEADER()
                {
                    headerFleet = CFD_header.headerFleet,
                    headerSeries = CFD_header.headerSeries,
                    headerFolio = CFD_header.headerFolio,
                    headerObs3 = CFD_header.headerObs3,
                    headerComments = CFD_header.headerComments,
                    headerUUID = CFD_header.headerUUID,
                };

                return new JsonResult
                {
                    Data = header,
                    MaxJsonLength = int.MaxValue,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error:[Editing] :: {0} ", ex.Message));
            }
        }

        // POST: Header/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "headerUUID")] CFD_HEADER cFD_HEADER)
        {
            if (Session["Header"] != null)
            {
                string headerID = Session["Header"].ToString();

                if (!String.IsNullOrWhiteSpace(headerID))
                {
                    if (ModelState.IsValid)
                    {
                        var uuid = cFD_HEADER.headerUUID;
                        var headerObs3 = cFD_HEADER.headerObs3;
                        var headerComments = cFD_HEADER.headerComments;

                        cFD_HEADER = await db.CFD_HEADER.FindAsync(headerID);
                        cFD_HEADER.headerObs3 = headerObs3 + headerComments;
                        cFD_HEADER.headerComments = headerComments;
                        cFD_HEADER.headerUUID = uuid;

                        db.Entry(cFD_HEADER).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        Session["MessageWarning"] = "Se actualizo la informacion correctamente !! ";
                    }
                }
                else
                {
                    Session["MessageWarning"] = "No se pudo actualizar el cliente, Comunicate con el administrador del sistema.";
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
