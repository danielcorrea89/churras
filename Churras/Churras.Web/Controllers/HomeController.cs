using System.Web.Mvc;

namespace Churras.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Churrascos");
        }
    }
}