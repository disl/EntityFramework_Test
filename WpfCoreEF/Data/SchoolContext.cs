using EntityFramework_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_Test.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        public SchoolContext() : base()
        {
            //DbContextOptions<SchoolContext> options = new DbContextOptions<SchoolContext>();
            //base.in(options);

            DbInitializer.Initialize(this);
        }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
            DbInitializer.Initialize(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
