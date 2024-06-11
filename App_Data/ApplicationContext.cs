using Microsoft.EntityFrameworkCore;
using rep.Models.DbModels;

namespace rep.App_Data
{
    //asdasd
    public class ApplicationContext : DbContext
    {
        #region DbSets
        public DbSet<Course> Course { get; set; } = null!;
        public DbSet<Grades> Grades { get; set; } = null!;
        public DbSet<Lesson> Lesson { get; set; } = null!;
        public DbSet<Material> Material { get; set; } = null!;
        public DbSet<Review> Review { get; set; } = null!;
        public DbSet<Student> Student { get; set; } = null!;
        public DbSet<StudentCourses> StudentCourses { get; set; } = null!;
        public DbSet<StudentGrades> StudentGrades { get; set; } = null!;
        public DbSet<Teacher> Teacher { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!;
        public DbSet<MarksStudents> MarksStudents { get; set; } = null!;
        #endregion

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
