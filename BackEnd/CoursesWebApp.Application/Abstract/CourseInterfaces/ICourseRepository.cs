using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.Abstract.CourseInterfaces
{
    public interface ICourseRepository
    {
        Task<CourseEntity> GetCourseWithStudentsTask(long id);
        Task<CourseEntity> GetCourseWithTeachersAsync(long id);
        Task<EnrollmentEntity> AddNewEnrollmentAsync(EnrollmentEntity enrollment);
        Task<EnrollmentEntity> DeleteEnrollment(long id);
    }
}
