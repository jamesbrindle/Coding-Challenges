using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniEnrollment_MVC.Models
{
    public class CourseDBContext : DbContext
    {
        public CourseDBContext() : base("name=DbConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasKey(b => b.ID);
            modelBuilder.Entity<Course>().Property(b => b.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Course>().HasKey(b => b.ID);
            modelBuilder.Entity<Course>().Property(b => b.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Course>().HasKey(b => b.ID);
            modelBuilder.Entity<Course>().Property(b => b.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Course> Courses { get; set; }
    }
}