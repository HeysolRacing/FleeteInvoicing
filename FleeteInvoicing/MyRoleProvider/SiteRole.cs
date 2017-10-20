using FleeteInvoicing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FleeteInvoicing.MyRoleProvider
{
    public class SiteRole : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] rol = null;
            FleeteInvoicingEntities db = new FleeteInvoicingEntities();

            try
            {
                var roles = db.AspNetUsers.Join(db.AspNetUserRoles, user => user.Id, urol => urol.UserId, (user, urol) => new { user, urol })
                            .Join(db.AspNetRoles, ppc => ppc.urol.RoleId, c => c.Id, (ppc, c) => new { ppc, c }).Where(z => z.ppc.user.ADName == username).ToList();

                if (roles.Count() > 0)
                {
                    var contador = roles.Count();
                    rol = new string[contador];
                    int i = 0;

                    foreach (var l in roles)
                    {
                        rol[i++] = l.c.Name;
                    }
                }
                else
                {
                    string[] r = { "xxxxx" };
                    return r;

                }
                return rol;
            }
            catch 
            {

            }

            return null;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}