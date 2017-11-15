using System.Web.Mvc;

namespace FleeteInvoicing.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Unauthorized()
        {
            ViewBag.Message = "Usted no tiene acceso a esta seccion. Consulte al administrador.";
            return View();
        }

        //[Authorize(Roles = "NotUserExist")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}