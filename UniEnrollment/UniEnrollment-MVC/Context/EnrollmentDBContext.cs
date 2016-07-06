using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniEnrollment_MVC.Models
{
    public class EnrollmentDBContext : DbContext
    {
        public EnrollmentDBContext() : base("name=DbConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Enrollment> Enrollments { get; set; }
    }
}