using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniEnrollment_MVC.Helpers;
using UniEnrollment_MVC.Models;

namespace UniEnrollment_MVC.Controllers
{
    /// <summary>
    /// Contains user interaction (action result) methods for anything uni 'student' related
    /// </summary>
    public class StudentController : Controller
    {
        private UniEnrollmentDBEntities _entities = new UniEnrollmentDBEntities();

        protected int StudentTypeID
        {
            get
            {
                return _entities.UserTypes.Where(u => u.Name == "Student").FirstOrDefault().ID;
            }
        }

        public ActionResult Index()
        {
            return View(_entities.Users.Where(u => u.UserTypeID == StudentTypeID));
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

            return View("Index", _entities.Users.Where(u => u.UserTypeID == StudentTypeID));
        }

        [HttpGet]
        public ActionResult Create()
        {
            // tiny security check...
            if (CookieHelper.LoggedInUserType == CookieHelper.LoggedInUserTypeEnum.STUDENT || 
                !CookieHelper.IsLoggedIn())
            {
                return View("Index", _entities.Users.Where(u => u.UserTypeID == StudentTypeID));
            }

            ModelState.Clear();
            return View(new StudentViewModel());
        }

        [HttpPost]
        public ActionResult SubmitCreate(StudentViewModel vmStudent)
        {
            if (ModelState.IsValid)
            {
                // a little bit of validation...
                if (_entities.Users.Any(s => s.Username == vmStudent.Username))
                {
                    ModelState.AddModelError(String.Empty, "That username already exists");
                    ModelState.AddModelError("UsernameError", "That username already exists");

                    return View("Create", new StudentViewModel());
                }
                else
                {
                    User newStudent = new User
                    {
                        UserTypeID = StudentTypeID,
                        Name = vmStudent.Name,
                        Username = vmStudent.Username,
                        Active = true,
                        Password = PasswordHelper.Encrypt(vmStudent.Password)
                    };

                    _entities.Users.Add(newStudent);
                    _entities.Entry(newStudent).State = EntityState.Added;

                    _entities.SaveChanges();

                    return View("Index", _entities.Users.Where(u => u.UserTypeID == StudentTypeID));
                }
            }
            else
            {
                return View("Create", new StudentViewModel());
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ModelState.Clear();

            if (id != null)
            {
                // a little bit of validation
                if (_entities.Users.Any(s => s.ID == id))
                {
                    return View(_entities.Users.Single(c => c.ID == id));
                }
            }

            return View("Index", _entities.Users.Where(u => u.UserTypeID == StudentTypeID));
        }

        [HttpPost]
        public ActionResult SubmitEdit(User student, string cbResetPassword)
        {
            if (ModelState.IsValid)
            {
                if (cbResetPassword == "true")
                {
                    student.Password = PasswordHelper.Encrypt("password");
                }

                _entities.Entry(student).State = EntityState.Modified;
                _entities.SaveChanges();

                return View("Index", _entities.Users.Where(u => u.UserTypeID == StudentTypeID));
            }
            else
            {
                return View("Edit", _entities.Users.Single(c => c.ID == student.ID));
            }
        }

        [HttpPost]
        public ActionResult Enroll(int? id, int? courseId)
        {
            if (id != null)
            {
                if (_entities.Users.Any(s => s.ID == id))
                {
                    Enrollment enrollment = new Enrollment
                    {
                        StudentID = (int)id,
                        CourseID = (int)courseId,
                        EnrollmentDate = DateTime.Now
                    };

                    _entities.Enrollments.Add(enrollment);
                    _entities.Entry(enrollment).State = EntityState.Added;

                    _entities.SaveChanges();
                }
            }

            return View("Details", _entities.Users.Where(u => u.ID == id).FirstOrDefault());
        }
    }
}