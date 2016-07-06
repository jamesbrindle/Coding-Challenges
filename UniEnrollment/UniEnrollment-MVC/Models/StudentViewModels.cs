using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniEnrollment_MVC.Models
{
    public class StudentViewModel
    { 
        public string ID { get; set; }

        [Display(Name = "Student Name")]
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

        public virtual List<Enrollment> Enrollments { get; set; }
    }
}
