using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.Abstract.CourseInterfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<StudentEntity>> GetStudentsInCourseAsync(long id);
        Task<IEnumerable<TeacherEntity>> GetTeachersInCourseAsync(long id);
        Task<EnrollmentEntity> AddNewEnrollmentAsync(StudentEntity student, CourseEntity course);
        Task<EnrollmentEntity> DeleteEnrollment(long id);
    }
}
