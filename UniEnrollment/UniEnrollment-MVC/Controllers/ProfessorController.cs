using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using UniEnrollment_MVC.Helpers;
using UniEnrollment_MVC.Models;

namespace UniEnrollment_MVC.Controllers
{   
    /// <summary>
     /// Contains user interaction (action result) methods for anything uni 'professor' related
     /// </summary>
    public class ProfessorController : Controller
    {
        private UniEnrollmentDBEntities _entities = new UniEnrollmentDBEntities();

        protected int ProfessorTypeID
        {
            get
            {
                return _entities.UserTypes.Where(u => u.Name == "Professor").FirstOrDefault().ID;
            }
        }

        public ActionResult Index()
        {
            return View(_entities.Users.Where(u => u.UserTypeID == ProfessorTypeID));
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                // a little bit of validation...
                if (_entities.Users.Any(s => s.ID == id))
                {
                    return View(_entities.Users.Where(u => u.ID == id).FirstOrDefault());
                }
            }

            return View("Index", _entities.Users.Where(u => u.UserTypeID == ProfessorTypeID));
        }

        [HttpGet]
        public ActionResult Create()
        {
            // tiny security check...
            if (CookieHelper.LoggedInUserType == CookieHelper.LoggedInUserTypeEnum.STUDENT || 
                !CookieHelper.IsLoggedIn())
            {
                return View("Index", _entities.Users.Where(u => u.UserTypeID == ProfessorTypeID));
            }

            ModelState.Clear();
            return View(new ProfessorViewModel());
        }

        [HttpPost]
        public ActionResult SubmitCreate(ProfessorViewModel vmProfessor)
        {
            if (ModelState.IsValid)
            {
                // a little bit of validation...
                if (_entities.Users.Any(s => s.Username == vmProfessor.Username))
                {
                    ModelState.AddModelError(String.Empty, "That username already exists");
                    ModelState.AddModelError("UsernameError", "That username already exists");

                    return View("Create", new ProfessorViewModel());
                }
                else
                {
                    User professor = new User
                    {
                        UserTypeID = ProfessorTypeID,
                        Name = vmProfessor.Name,
                        Username = vmProfessor.Username,
                        Active = true,
                        Password = PasswordHelper.Encrypt(vmProfessor.Password)
                    };

                    _entities.Users.Add(professor);
                    _entities.Entry(professor).State = EntityState.Added;

                    _entities.SaveChanges();

                    return View("Index", _entities.Users.Where(u => u.UserTypeID == ProfessorTypeID));
                }
            }
            else
            {
                return View("Create", new ProfessorViewModel());
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            // tiny security check...
            if (CookieHelper.LoggedInUserType == CookieHelper.LoggedInUserTypeEnum.STUDENT || !CookieHelper.IsLoggedIn())
            {
                return View("Index", _entities.Users.Where(u => u.UserTypeID == ProfessorTypeID));
            }

            ModelState.Clear();

            if (id != null)
            {
                // a little bit of validation...
                if (_entities.Users.Any(s => s.ID == id))
                {
                    return View(_entities.Users.Single(c => c.ID == id));
                }
            }

            return View("Index", _entities.Users.Where(u => u.UserTypeID == ProfessorTypeID));
        }

        [HttpPost]
        public ActionResult SubmitEdit(User professor, string cbResetPassword)
        {
            if (ModelState.IsValid)
            {
                if (cbResetPassword == "true")
                {
                    professor.Password = PasswordHelper.Encrypt("password");
                }

                _entities.Entry(professor).State = EntityState.Modified;
                _entities.SaveChanges();

                return View("Index", _entities.Users.Where(u => u.UserTypeID == ProfessorTypeID));
            }
            else
            {
                return View("Edit", _entities.Users.Single(c => c.ID == professor.ID));
            }
        }
    }
}