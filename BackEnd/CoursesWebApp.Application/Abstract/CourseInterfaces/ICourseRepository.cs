using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.Abstract.CourseInterfaces
{
    public interface ICourseRepository
    {
        Task<CourseEntity?> GetCourseWithStudentsTask(long id);
        Task<CourseEntity?> GetCourseWithTeachersAsync(long id);
    }
}
