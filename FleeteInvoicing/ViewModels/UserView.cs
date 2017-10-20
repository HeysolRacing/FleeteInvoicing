using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FleeteInvoicing.ViewModels
{
    public class UserView
    {
        public string UserID { get; set; }

        public string UserName { get; set; }

        public string ADName { get; set; }

        public RoleView Role { get; set; } // Titulos de los encabezados.

        public List<RoleView> Roles { get; set; }

    }
}