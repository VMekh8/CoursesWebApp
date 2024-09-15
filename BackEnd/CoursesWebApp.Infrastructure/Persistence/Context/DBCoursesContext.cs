using CoursesWebApp.Domain.Entities;
using CoursesWebApp.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CoursesWebApp.Infrastructure.Persistence.Context
{
    public class DBCoursesContext : DbContext
    {
        public DBCoursesContext(DbContextOptions<DBCoursesContext> options) : base(options)
        {
        }

        public DbSet<NewsEntity> News { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }
        public DbSet<EnrollmentEntity> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());
        }
    }
}
