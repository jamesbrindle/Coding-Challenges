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
    /// Contains user interaction (action result) methods for anything uni 'course' related
    /// </summary>
    public class CourseController : Controller
    {
        private UniEnrollmentDBEntities _entities = new UniEnrollmentDBEntities();

        public ActionResult Index()
        {
            return View(_entities.Courses.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            // tiny security check...
            if (CookieHelper.LoggedInUserType == CookieHelper.LoggedInUserTypeEnum.STUDENT || !CookieHelper.IsLoggedIn())
            {
                return View("Index", _entities.Courses.ToList());
            }

            ModelState.Clear();
            return View(new CourseViewModel());
        }

        [HttpGet]
        public ActionResult CreateWithID(int? id)
        {
            // tiny security check...
            if (CookieHelper.LoggedInUserType == CookieHelper.LoggedInUserTypeEnum.STUDENT || !CookieHelper.IsLoggedIn())
            {
                return View("Index", _entities.Courses.ToList());
            }

            ModelState.Clear();
            ViewBag.Professor = _entities.Users.Single(p => p.ID == (int)id);

            return View(new CourseViewModel());
        }

        [HttpPost]
        public ActionResult SubmitCreate(CourseViewModel vmCourse)
        {
            if (ModelState.IsValid)
            {

                if (_entities.Courses.Any(s => s.Name == vmCourse.Name))
                {
                    ModelState.AddModelError(String.Empty, "That course code already exists");
                    ModelState.AddModelError("CourseCodeError", "That course code already exists");

                    return View("Create", new CourseViewModel());
                }
                else
                {
                    Course newCourse = new Course
                    {
                        CourseCode = vmCourse.CourseCode,
                        Name = vmCourse.Name,
                        Description = vmCourse.Description,
                        ProfessorID = vmCourse.ProfessorID
                    };

                    _entities.Courses.Add(newCourse);
                    _entities.Entry(newCourse).State = EntityState.Added;
                    _entities.SaveChanges();

                    return View("Index", _entities.Courses.ToList());
                }
            }
            else
            {
                return View("Create", new CourseViewModel());
            }
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                if (_entities.Courses.Any(s => s.ID == id))
                {
                    return View(_entities.Courses.Single(c => c.ID == id));
                }
            }

            return View("Index", _entities.Courses.ToList());
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            // tiny security check...
            if (CookieHelper.LoggedInUserType == CookieHelper.LoggedInUserTypeEnum.STUDENT || !CookieHelper.IsLoggedIn())
            {
                return View("Index", _entities.Courses.ToList());
            }

            ModelState.Clear();

            if (id != null)
            {
                // bit of validation...
                if (_entities.Courses.Any(s => s.ID == id))
                {
                    return View(_entities.Courses.Single(c => c.ID == id));
                }
            }

            return View("Index", _entities.Courses.ToList());
        }

        [HttpPost]
        public ActionResult SubmitEdit(Course course)
        {
            if (ModelState.IsValid)
            {
                _entities.Entry(course).State = EntityState.Modified;
                _entities.SaveChanges();

                return View("Index", _entities.Courses.ToList());
            }
            else
            {
                return View("Edit", _entities.Courses.Single(c => c.ID == course.ID));
            }
        }

        public ActionResult Delete(int? id)
        {
            // tiny security check...
            if (CookieHelper.LoggedInUserType == CookieHelper.LoggedInUserTypeEnum.STUDENT || !CookieHelper.IsLoggedIn())
            {
                return View("Index", _entities.Courses.ToList());
            }

            if (id != null)
            {
                // bit of validation...
                if (_entities.Courses.Any(s => s.ID == id))
                {
                    var course = _entities.Courses.Single(c => c.ID == id);
                    _entities.Courses.Remove(course);
                    _entities.Entry(course).State = EntityState.Deleted;
                    _entities.SaveChanges();

                    return View("Index", _entities.Courses.ToList());
                }
            }

            return View("Index", _entities.Courses.ToList());
        }
    }
}