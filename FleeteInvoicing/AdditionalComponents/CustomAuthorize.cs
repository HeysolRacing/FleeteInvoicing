using System;
using System.Web;
using System.Web.Mvc;

namespace FleeteInvoicing
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        private string _notifyUrl = "/Home/Contact";

        public string NotifyUrl
        {
            get { return _notifyUrl; }
            set { _notifyUrl = value; }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //filterContext.Result = new HttpUnauthorizedResult(); // Try this but i'm not sure
            //filterContext.Result = new RedirectResult("/Error/Unauthorized");
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            if (AuthorizeCore(filterContext.HttpContext))
            {
                base.OnAuthorization(filterContext);
            }

            /// This code added to support custom Unauthorized pages.
            else if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                if (NotifyUrl != null)
                    filterContext.Result = new RedirectResult(NotifyUrl);
                else
                    // Redirect to Login page.
                    HandleUnauthorizedRequest(filterContext);
            }
            /// End of additional code
            else
            {
                // Redirect to Login page.
                HandleUnauthorizedRequest(filterContext);
            }



            //if (this.AuthorizeCore(filterContext.HttpContext))
            //{
            //    base.OnAuthorization(filterContext);
            //}
            //else
            //{
            //    HandleUnauthorizedRequest(filterContext);
            //}
        }
    }
}