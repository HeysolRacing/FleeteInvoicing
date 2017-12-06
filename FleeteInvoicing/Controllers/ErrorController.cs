using System.Web.Mvc;

namespace FleeteInvoicing.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Unauthorized()
        {
            ViewBag.Message = "Usted no cuenta con los permisos para accesar a este m&oacute;dulo.";
            return View();
        }
    }
}