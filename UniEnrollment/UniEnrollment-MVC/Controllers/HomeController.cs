using System.Web.Mvc;

namespace UniEnrollment_MVC.Controllers
{
    /// <summary>
    /// Contains user interaction (action result) methods for the home page
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}