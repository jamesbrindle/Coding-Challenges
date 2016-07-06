using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UniEnrollment_MVC.Models
{
    public class EnrollmentViewModel
    {
        public int CourseID { get; set; }

        public int StudentID { get; set; }

        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        /// <summary>
        /// Annoying method - Couldn't simply cast the query list to List of Users. It gets
        /// all the students who are enolled on a course by a specified professor
        /// </summary>
        /// <param name="profId">ID of professor</param>
        /// <returns>List of users</returns>
        public static List<User> GetAllStudentsListWithProfessorID(int profId)
        {
            var _entities = new UniEnrollmentDBEntities();

            List<int> queryResult = (from e in _entities.Enrollments
                                     join u in _entities.Users
                                          on e.StudentID equals u.ID
                                     join c in _entities.Courses
                                          on e.CourseID equals c.ID
                                     where c.ProfessorID == profId
                                     select u.ID).ToList();

            var students = new List<User>();

            foreach (int item in queryResult)
            {
                if (!students.Any(p => p.ID == item))
                    students.Add(_entities.Users.Single(u => u.ID == item));
            }

            return students;
        }

        /// <summary>
        /// Count of how many users are enrolled on a particular course
        /// </summary>
        /// <param name="courseId">The course ID of the course to count</param>
        /// <returns>Number of students in that course</returns>
        public static int GetCourseEnrollmentCount(int courseId)
        {
            var _entities = new UniEnrollmentDBEntities();
            return _entities.Enrollments.Where(e => e.CourseID == courseId).Count();
        }

        /// <summary>
        /// List of all the courses a user in enrolled on
        /// </summary>
        /// <param name="studentId">The ID of the student to see what course they're enrolled on</param>
        /// <returns>List of courses</returns>
        public static List<Course> GetCourseEnrollmentByStudentID(int studentId)
        {
            var _entities = new UniEnrollmentDBEntities();
            List<Enrollment> enrollments = _entities.Enrollments.Where(s => s.StudentID == studentId).ToList();
            List<Course> coursesEnrolledOn = new List<Course>();

            foreach (Enrollment item in enrollments)
            {
                coursesEnrolledOn.Add(_entities.Courses.Single(c => c.ID == item.CourseID));
            }

            return coursesEnrolledOn;
        }

        /// <summary>
        /// All other courses a particular student is not enrolled on - It's for populating a drop down
        /// So it's a 'filtering' method
        /// </summary>
        /// <param name="studentId">Student ID of student to determine what courses they don't belong to</param>
        /// <returns>A list of courses a user doesn't belong to</returns>
        public static List<Course> GetCoursesNotEnrolledOn(int studentId)
        {
            var _entities = new UniEnrollmentDBEntities();
            List<Enrollment> enrollments = _entities.Enrollments.Where(s => s.StudentID == studentId).ToList();
            List<Course> coursesNotEnrolledOn = _entities.Courses.ToList();

            foreach (Enrollment item in enrollments)
            {
                coursesNotEnrolledOn.Remove(_entities.Courses.Single(c => c.ID == item.CourseID));
            }

            return coursesNotEnrolledOn;
        }

        /// <summary>
        /// Get a list of users enrolled on a particular course
        /// </summary>
        /// <param name="courseId">The ID of the course that students belong to</param>
        /// <returns>A list of users belonging to a given course</returns>
        public static List<User> GetStudentsEnrolledOnCourse(int courseId)
        {
            var _entities = new UniEnrollmentDBEntities();
            List<Enrollment> enrollments = _entities.Enrollments.Where(s => s.CourseID == courseId).ToList();

            List<User> studentsEnrolled = new List<User>();

            foreach (Enrollment item in enrollments)
            {
                studentsEnrolled.Add(_entities.Users.Single(u => u.ID == item.StudentID));
            }

            return studentsEnrolled;
        }
    }
}
