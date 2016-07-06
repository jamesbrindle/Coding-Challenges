using System.Linq;
using System.Web.Mvc;
using UniEnrollment_MVC.Helpers;
using UniEnrollment_MVC.Models;

namespace UniEnrollment_MVC.Controllers
{
    /// <summary>
    /// Contains user interaction (action result) methods for anything uni 'enrollment' related
    /// </summary>
    public class EnrollmentController : Controller
    {
        private UniEnrollmentDBEntities _entities = new UniEnrollmentDBEntities();

        public ActionResult Index()
        {
            // tiny security check...
            if (CookieHelper.LoggedInUserType == CookieHelper.LoggedInUserTypeEnum.STUDENT || !CookieHelper.IsLoggedIn())
            {
                return RedirectToAction("Index", "Home", null);
            }

            return View(_entities.Enrollments.ToList());
        }
    }
}