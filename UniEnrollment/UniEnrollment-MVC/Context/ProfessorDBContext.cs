using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniEnrollment_MVC.Models
{
    public class ProfessorDBContext : DbContext
    {
        public ProfessorDBContext() : base("name=DbConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professor>().HasKey(b => b.ID);
            modelBuilder.Entity<Professor>().Property(b => b.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Professor>().HasKey(b => b.ID);
            modelBuilder.Entity<Professor>().Property(b => b.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Professor>().HasKey(b => b.ID);
            modelBuilder.Entity<Professor>().Property(b => b.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Professor> Professors { get; set; }
    }
}