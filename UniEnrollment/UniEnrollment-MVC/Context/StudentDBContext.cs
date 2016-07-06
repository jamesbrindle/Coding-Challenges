using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniEnrollment_MVC.Models
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext() : base("name=DbConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(b => b.ID);
            modelBuilder.Entity<Student>().Property(b => b.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Professor>().HasKey(b => b.ID);
            modelBuilder.Entity<Professor>().Property(b => b.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Course>().HasKey(b => b.ID);
            modelBuilder.Entity<Course>().Property(b => b.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
    }
}