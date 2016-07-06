using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace UniEnrollment_MVC.Models
{
    public class CourseViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Professor")]
        [Required]
        public int ProfessorID { get; set; }

        [Display(Name = "Course Code")]
        [StringLength(20, ErrorMessage = "Course code cannot be more than 20 characters long")]
        [Required]
        public string CourseCode { get; set; }

        [Display(Name = "Course Name")]
        [StringLength(100, ErrorMessage = "Course name / title cannot be more than 100 characters long")]
        [Required]
        public string Name { get; set; }
        
        [Display(Name = "Course Description")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// Returns the user 'Name' from their ID. Not strinctly required for most related views, the business models
        /// (seen in the DataMode.edmx) are related so you can just call from e.g. Model.Course.Professor.Name
        /// however I used this out of scope once so it's useful
        /// </summary>
        /// <param name="id">ID of user</param>
        /// <returns>Name of the professor (or user)</returns>
        public static string GetProfessorNameByID(int id)
        {
            return new UniEnrollmentDBEntities().Users.Where(p => p.ID == id).FirstOrDefault().Name;
        }

        /// <summary>
        /// Returns a list of courses specifically for use in drop down lsits
        /// </summary>
        /// <returns>List of courses</returns>
        public static List<Course> GetCourseList()
        {
            return new UniEnrollmentDBEntities().Courses.ToList();
        }

        /// <summary>
        /// Get a list of courses ran by a specific professor
        /// </summary>
        /// <param name="id">ID of professor (or user)</param>
        /// <returns>List of courses ran by specific professor</returns>
        public static List<Course> GetCourseListByProfessorID(int id)
        {
            return new UniEnrollmentDBEntities().Courses.Where(c => c.ProfessorID == id).ToList();
        }
    }
}

