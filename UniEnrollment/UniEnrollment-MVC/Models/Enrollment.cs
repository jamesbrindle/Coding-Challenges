//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniEnrollment_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Enrollment
    {
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public System.DateTime EnrollmentDate { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
    }
}