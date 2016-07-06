using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UniEnrollment_MVC.Models
{
    public class ProfessorViewModel
    {
        public string ID { get; set; }

        [Display(Name = "Professor Name")]
        [Required]
        [StringLength(100, ErrorMessage = "Name cannot be more than 100 characters long")]
        public string Name { get; set; }

        [Display(Name = "Username")]
        [Required]
        [StringLength(50, ErrorMessage = "Username cannot be more than 50 characters long.")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required]
        [StringLength(20, ErrorMessage = "Password cannot be more than 20 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }

        public virtual List<Course> Courses { get; set; }

        /// <summary>
        /// All active professors - for a drop down list
        /// </summary>
        /// <returns>A list of all active professor</returns>
        public static List<User> GetProfessorList()
        {
            int professorTypeID = new UniEnrollmentDBEntities().UserTypes.Where(t => t.Name == "Professor").FirstOrDefault().ID;
            return new UniEnrollmentDBEntities().Users.Where(p => p.UserTypeID == professorTypeID && p.Active == true).ToList();
        }
    }
}
