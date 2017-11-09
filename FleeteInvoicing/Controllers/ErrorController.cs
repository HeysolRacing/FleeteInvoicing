using System.Web.Mvc;

namespace FleeteInvoicing.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Unauthorized()
        {
            ViewBag.Message = "You don´t have enough priviledges for this module.";
            return View();
        }
    }
}