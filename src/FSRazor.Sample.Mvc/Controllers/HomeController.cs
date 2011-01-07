using System.Web.Mvc;

namespace FSRazor.Sample.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to FSRazor";
            return View();
        }
    }
}
