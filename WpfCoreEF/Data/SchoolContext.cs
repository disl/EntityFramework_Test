using EntityFramework_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_Test.Data
{
    public class SchoolContext : DbContext
    {
        // https://www.thecodebuzz.com/no-database-provider-has-been-configured-for-this-dbcontext/

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        public SchoolContext() : base() 
        { 
            DbInitializer.Initialize(this); 
        }

        //public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        //{
        //    DbInitializer.Initialize(this);
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection_str;

            if (System.Configuration.ConfigurationManager.ConnectionStrings.Count == 0) 
                return;

            try
            {
                connection_str = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
            catch
            {
                connection_str = System.Configuration.ConfigurationManager.ConnectionStrings[0].ConnectionString;
            }
            optionsBuilder.UseSqlServer(connection_str);
        }
    }
}
