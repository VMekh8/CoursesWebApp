using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.Abstract;

public abstract class CoursesBaseUseCase : BaseUseCase<CourseEntity>
{
    public virtual Task CreateEnrollment(long StudentId, long CoursesId) =>
        throw new NotImplementedException("Should be overridden");

    public virtual Task DeleteEnrollment(long EnrollmentId) =>
        throw new NotImplementedException("Should be overridden");
}