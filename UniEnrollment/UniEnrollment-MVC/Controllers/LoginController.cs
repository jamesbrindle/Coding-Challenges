using System;
using System.Linq;
using System.Web.Mvc;
using UniEnrollment_MVC.Helpers;
using UniEnrollment_MVC.Models;

namespace UniEnrollment_MVC.Controllers
{
    /// <summary>
    /// Contains user interaction (action result) methods for anything uni 'logging in' related
    /// </summary>
    public class LoginController : Controller
    {
        private UniEnrollmentDBEntities _entities = new UniEnrollmentDBEntities();

        public ActionResult GoToLogin(string where)
        {
            ViewData["where"] = where;
            return View("Login");
        }

        public ActionResult PerformLogin(LoginViewModel vmLogin, string where)
        {
            if (ModelState.IsValid)
            {
                // bit of validation...
                if (!_entities.Users.Any(s => s.Username == vmLogin.Username))
                {
                    ModelState.AddModelError(String.Empty, "No such username exists");
                    ModelState.AddModelError("UsernameError", "No such username exists");

                    return View("Login");
                }
                // compare password to database password after decrypt
                else if (PasswordHelper.Decrypt(_entities.Users.Single(u => u.Username == vmLogin.Username).Password) != vmLogin.Password)
                {
                    ModelState.AddModelError(String.Empty, "Password incorrect");
                    ModelState.AddModelError("PasswordError", "Password incorrect");

                    return View("Login");
                }
                else
                {
                    // uses cookies to store login data...

                    CookieHelper.SetLoginCookie(_entities.Users.Single(u => u.Username == vmLogin.Username).ID);
                    if (String.IsNullOrEmpty(where))
                    {

                        return View("~/Views/Home/Index.cshtml");
                    }
                    else
                    {
                        // This part is incase a user is trying to access something they don't have access to
                        // and are redirected to the login page, after which they can be redirected to wherever
                        // they were supposed to be going in the first place (only 'enrollment' set up so far)
                        if (where == "enrollment")
                        {
                            return RedirectToAction("Details", "Student", new { id = CookieHelper.LoggedInUserID });
                        }
                    }

                    return View("~/Views/Home/Index.cshtml");
                }
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult LogOff()
        {
            CookieHelper.LogOut();

            return View("~/Views/Home/Index.cshtml");
        }
    }
}