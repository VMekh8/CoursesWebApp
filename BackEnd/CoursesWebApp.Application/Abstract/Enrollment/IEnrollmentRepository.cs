using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.Abstract.Enrollment;

public interface IEnrollmentRepository
{
    Task<EnrollmentEntity> AddNewEnrollmentAsync(EnrollmentEntity enrollment);
    Task<EnrollmentEntity> DeleteEnrollment(long id);
}