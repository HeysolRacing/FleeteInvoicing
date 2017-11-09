using FleeteInvoicing.Models;
using FleeteInvoicing.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FleeteInvoicing.Controllers
{
    public class UsersController : Controller
    {
        private FleeteInvoicingEntities db = new FleeteInvoicingEntities();

        [CustomAuthorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var users = db.AspNetUsers.ToList().OrderBy(s => s.ADName);
            var usersView = new List<UserView>();

            foreach (var user in users)
            {
                var userView = new UserView
                {
                    ADName = user.ADName,
                    UserName = user.UserName,
                    UserID = user.Id
                };

                usersView.Add(userView);
            }

            return View(usersView);
        }

        [CustomAuthorize(Roles = "Administrator")]
        public ActionResult Roles(string userID)
        {
            var roles = db.AspNetRoles.ToList();
            var users = db.AspNetUsers.ToList();

            var user = users.Find(u => u.Id == userID);

            var rolesView = new List<RoleView>();

            foreach (var item in user.AspNetUserRoles)
            {
                var role = roles.Find(r => r.Id == item.RoleId);

                var roleView = new RoleView
                {
                    RoleID = role.Id,
                    Name = role.Name
                };

                rolesView.Add(roleView);
            }

            var userView = new UserView
            {
                UserID = user.Id,
                Roles = rolesView
            };

            return View(userView);
        }

        [CustomAuthorize(Roles = "Administrator")]
        public ActionResult AddRole(string userID)
        {
            if (string.IsNullOrEmpty(userID))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var users = db.AspNetUsers.ToList();
            var user = users.Find(u => u.Id == userID);

            if (user == null)
                return HttpNotFound();

            var userView = new UserView
            {
                ADName = user.ADName,
                UserName = user.UserName,
                UserID = user.Id
            };

            var list = db.AspNetRoles.ToList();
            //list.Add(new IdentityRole { Id = "", Name = "Seleccione un rol... " });
            list = list.OrderBy(r => r.Name).ToList();
            ViewBag.RoleID = new SelectList(list, "Id", "Name");

            return View(userView);
        }

        [HttpPost]
        public ActionResult AddRole(string userID, FormCollection form)
        {
            var roleID = Request["RoleID"];
            var roleManager = db.AspNetRoles.ToList();
            var user = db.AspNetUsers.ToList().Find(u => u.Id == userID);

            var userView = new UserView
            {
                UserName = user.UserName,
                ADName = user.ADName,
                UserID = user.Id,
            };

            if (string.IsNullOrEmpty(roleID))
            {
                ViewBag.Error = "You must select a role";
                var list = db.AspNetRoles.ToList();
                list = list.OrderBy(r => r.Name).ToList();
                ViewBag.RoleID = new SelectList(list, "Id", "Name");
                return View(userView);
            }

            if (ModelState.IsValid)
            {
                AspNetUserRole aspNetUserRole = new AspNetUserRole
                {
                    RoleId = roleID,
                    UserId = user.Id,
                };

                db.AspNetUserRoles.Add(aspNetUserRole);
                db.SaveChanges();
            }

            var rolesView = new List<RoleView>();

            foreach (var item in user.AspNetUserRoles)
            {
                var role = roleManager.Find(r => r.Id == item.RoleId);

                var roleView = new RoleView
                {
                    RoleID = role.Id,
                    Name = role.Name
                };

                rolesView.Add(roleView);
            }

            userView = new UserView
            {
                UserName = user.UserName,
                ADName = user.ADName,
                UserID = user.Id,
                Roles = rolesView,
            };

            return View("Roles", userView);
        }

        [CustomAuthorize(Roles = "Administrator")]
        public ActionResult Delete(string userID, string roleID)
        {
            if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(roleID))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var userManager = db.AspNetUsers.ToList();
            var roleManager = db.AspNetRoles.ToList();

            var user = userManager.Find(u => u.Id == userID);
            var role = roleManager.Find(u => u.Id == roleID);

            if (!string.IsNullOrEmpty(role.Id) || !string.IsNullOrEmpty(user.Id))
            {
                var userRole = db.AspNetUserRoles.ToList();
                var userRoleID = userRole.Find(i => i.UserId == user.Id && i.RoleId == role.Id);

                AspNetUserRole aspNetUserRole = db.AspNetUserRoles.Find(userRoleID.ID);
                db.AspNetUserRoles.Remove(aspNetUserRole);
                db.SaveChanges();
            }

            var users = userManager.ToList();
            var roles = roleManager.ToList();
            var rolesView = new List<RoleView>();

            foreach (var item in user.AspNetUserRoles)
            {
                role = roles.Find(r => r.Id == item.RoleId);

                var roleView = new RoleView
                {
                    RoleID = role.Id,
                    Name = role.Name
                };

                rolesView.Add(roleView);
            }

            var userView = new UserView
            {
                UserName = user.UserName,
                ADName = user.ADName,
                UserID = user.Id,
                Roles = rolesView
            };

            return View("Roles", userView);
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