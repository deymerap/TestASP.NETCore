using Education.Domain;
using Microsoft.EntityFrameworkCore;

namespace Education.Persistence
{
    public class EducatioDBContext : DbContext
    {
 
        public EducatioDBContext(DbContextOptions<EducatioDBContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"Server=CL-FE-DPM\MSSQLSERVER_2019;Initial Catalog=Education;User ID=sa;Password=Sa123456;Connection Timeout=30;MultipleActiveResultSets=true;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(e => e.Price)
                .HasPrecision(14,2);

            modelBuilder.Entity<Course>()
                .HasData(
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Description = "Curso basico de Java",
                    Title = "Curso de Java desde cero hasta avanzado",
                    CreatedDate = DateTime.Now,
                    PublishedDate = DateTime.Now.AddYears(1),
                    Price = 20
                },
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Description = "Curso basico de C#",
                    Title = "Curso de C# desde cero hasta avanzado",
                    CreatedDate = DateTime.Now,
                    PublishedDate = DateTime.Now.AddYears(2),
                    Price = 56
                },
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Description = "Curso basico de Net Core",
                    Title = "Curso de Net Core desde cero hasta avanzado",
                    CreatedDate = DateTime.Now,
                    PublishedDate = DateTime.Now.AddYears(2),
                    Price = 1000
                }
            );


        }


        public DbSet<Course> Courses { get; set; }
    }
}