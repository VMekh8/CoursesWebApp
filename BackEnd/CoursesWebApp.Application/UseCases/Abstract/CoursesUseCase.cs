using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.Abstract;

public abstract class CoursesUseCase : UseCase<CourseEntity>
{
    public virtual Task CreateEnrollment(long studentId, long coursesId) =>
        throw new NotImplementedException("Should be overridden");

    public virtual Task DeleteEnrollment(long EnrollmentId) =>
        throw new NotImplementedException("Should be overridden");
}