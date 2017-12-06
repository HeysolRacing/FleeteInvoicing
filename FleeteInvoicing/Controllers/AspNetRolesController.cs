using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FleeteInvoicing.Models;
using System;
using System.Threading.Tasks;

namespace FleeteInvoicing.Controllers
{
    public class AspNetRolesController : Controller
    {
        private FleeteInvoicingEntities db = new FleeteInvoicingEntities();

        [CustomAuthorize(Roles = "Administrator", NotifyUrl = "/Error/Unauthorized")]
        public async Task<ActionResult> Index()
        {
            TempData["ROLES"] = await db.AspNetRoles.OrderBy(s => s.Name).ToListAsync();
            ViewBag.Warning = Session["MessageWarning"] == null ? null : Session["MessageWarning"].ToString();
            ViewBag.Message = Session["Message"] == null ? null : Session["Message"].ToString();
            Session.Clear();
            return View();
        }

        [CustomAuthorize(Roles = "Administrator", NotifyUrl = "/Error/Unauthorized")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] AspNetRole aspNetRole)
        {
            if (ModelState.IsValid)
            {
                aspNetRole.Id = Guid.NewGuid().ToString();
                db.AspNetRoles.Add(aspNetRole);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aspNetRole);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Administrator", NotifyUrl = "/Error/Unauthorized")]
        public async Task<JsonResult> Editing(string id)
        {
            try
            {
                Session["RoleID"] = id;
                var aspNetRole = await db.AspNetRoles.FindAsync(id);
                AspNetRole rol = new AspNetRole()
                {
                    Id = aspNetRole.Id,
                    Name = aspNetRole.Name
                };
                return new JsonResult
                {
                    Data = rol,
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
        public async Task<ActionResult> Edit(AspNetRole aspNetRole)
        {
            if (Session["RoleID"] != null)
            {
                string roleID = Session["RoleID"].ToString();
                string roleName = aspNetRole.Name;

                if (!String.IsNullOrWhiteSpace(roleID) && !String.IsNullOrWhiteSpace(roleName))
                {
                    aspNetRole = new AspNetRole { Id = roleID, Name = roleName };

                    if (ModelState.IsValid)
                    {
                        db.Entry(aspNetRole).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        Session["MessageWarning"] = string.Format("Se actualizo el registro : {0}  correctamente... ", aspNetRole.Name);
                    }
                }
                else
                {
                    Session["MessageWarning"] = string.Format("No se pudo actualizar el rol :  {0}  .Comunicate con el administrador del sistema …… ", aspNetRole.Name);
                }
            }

            return RedirectToAction("Index");
        }

        [CustomAuthorize(Roles = "Administrator", NotifyUrl = "/Error/Unauthorized")]
        public async Task<JsonResult> Deleting(string id)
        {
            try
            {
                Session["RoleID"] = id;
                var aspNetRole = await db.AspNetRoles.FindAsync(id);

                AspNetRole rol = new AspNetRole()
                {
                    Id = aspNetRole.Id,
                    Name = aspNetRole.Name
                };

                return new JsonResult
                {
                    Data = rol,
                    MaxJsonLength = int.MaxValue,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error:[Editing] :: {0} ", ex.Message));
            }
        }

        // POST: AspNetRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            if (Session["RoleID"] != null)
            {
                if (!String.IsNullOrWhiteSpace(Session["RoleID"].ToString()))
                {
                    id = Session["RoleID"].ToString();
                    if (ModelState.IsValid)
                    {
                        AspNetRole aspNetRole = await db.AspNetRoles.FindAsync(id);
                        db.AspNetRoles.Remove(aspNetRole);
                        await db.SaveChangesAsync();
                        Session["MessageWarning"] = "Se elimin&oacute; la informaci&oacute;n correctamente !! ";
                    }
                }
                else
                {
                    Session["MessageWarning"] = "No se pudo eliminar el rol, Comunicate con el administrador del sistema.";
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
