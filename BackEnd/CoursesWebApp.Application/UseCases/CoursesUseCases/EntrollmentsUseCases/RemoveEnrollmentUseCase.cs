using CoursesWebApp.Application.Abstract.Enrollment;
using CoursesWebApp.Application.UseCases.Abstract;

namespace CoursesWebApp.Application.UseCases.CoursesUseCases.EntrollmentsUseCases;

public class RemoveEnrollmentUseCase : CoursesUseCase
{
    private readonly IEnrollmentRepository _enrollmentRepo;

    public RemoveEnrollmentUseCase(IEnrollmentRepository enrollmentRepo)
    {
        _enrollmentRepo = enrollmentRepo;
    }

    public override async Task DeleteEnrollment(long enrollmentId)
    {
        await _enrollmentRepo.DeleteEnrollment(enrollmentId);
    }
}