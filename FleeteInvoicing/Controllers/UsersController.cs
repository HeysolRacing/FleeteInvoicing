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

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var users = db.AspNetUsers.ToList();
            var usersView = new List<UserView>();

            foreach (var user in users)
            {
                var userView = new UserView
                {
                    ADName = user.ADName,
                    UserName = user.UserName,
                };

                usersView.Add(userView);
            }

            return View(usersView);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Roles(string userID)
        {
            var roles = db.AspNetRoles.ToList();
            var users = db.AspNetUsers.ToList();
            var user = users.Find(u => u.UserName == userID);

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
                UserName = user.UserName,
                ADName = user.ADName,
                Roles = rolesView
            };

            return View(userView);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult AddRole(string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var users = db.AspNetUsers.ToList();
            var user = users.Find(u => u.Id == userID);

            if (user == null)
            {
                return HttpNotFound();
            }
            var userView = new UserView
            {
                UserName = user.UserName,
                UserID = user.Id,
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
            var users = db.AspNetUsers.ToList();
            var user = users.Find(u => u.Id == userID);

            var userView = new UserView
            {
                ADName = user.ADName,
                UserName = user.UserName,
                UserID = user.Id,
            };

            if (string.IsNullOrEmpty(roleID))
            {
                ViewBag.Error = "You must select a role";

                var list = db.AspNetRoles.ToList();
                //list.Add(new IdentityRole { Id = "", Name = "Seleccione un rol... " });
                list = list.OrderBy(r => r.Name).ToList();
                ViewBag.RoleID = new SelectList(list, "Id", "Name");
                return View(userView);
            }

            var roles = db.AspNetRoles.ToList();
            var role = db.AspNetRoles.ToList().Find(r => r.Id == roleID);

            //if (!userManager.IsInRole(userID, role.Id))
            //{
            //    userManager.AddToRole(userID, role.Name);
            //}

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

            userView = new UserView
            {
                ADName = user.ADName,
                UserName = user.UserName,
                UserID = user.Id,
                Roles = rolesView
            };

            return View("Roles", userView);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(string userID, string roleID)
        {
            if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(roleID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var user = db.AspNetUsers.ToList().Find(u => u.Id == userID); 
            var role = db.AspNetRoles.ToList().Find(u => u.Id == roleID);

            //if (db.AspNetUsers.ToList().IsInRole(user.Id, role.Name))
            //{
            //    userManager.RemoveFromRole(user.Id, role.Name);
            //}

            var users = db.AspNetUsers.ToList();
            var roles = db.AspNetRoles.ToList();
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
                ADName = user.ADName,
                UserName = user.UserName,
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