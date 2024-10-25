using CoursesWebApp.Application.Abstract.Enrollment;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Application.UseCases.StudentsUseCases;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.CoursesUseCases.EntrollmentsUseCases;

public class AddEnrollmentUseCase : CoursesUseCase
{
    private readonly IEnrollmentRepository _enrollmentRepo;
    private readonly GetCourseByIdUseCase _getCourse;
    private readonly GetStudentByIdUseCase _getStudent;

    public AddEnrollmentUseCase(IEnrollmentRepository enrollmentRepo, GetCourseByIdUseCase getCourse, GetStudentByIdUseCase getStudent)
    {
        _enrollmentRepo = enrollmentRepo;
        _getCourse = getCourse;
        _getStudent = getStudent;
    }

    public override async Task CreateEnrollment(long studentId, long coursesId)
    {
        var student = await _getStudent.GetById(studentId);
        
        var course = await _getCourse.GetById(coursesId);

       IsNull(student);
       IsNull(course);

        await _enrollmentRepo.AddNewEnrollmentAsync(new EnrollmentEntity(student, course));
    }
    
    private void IsNull<T>(T entity)
    {
        if (entity is null)
        {
            throw new ArgumentException($"Can`t find a {entity.GetType()} for new enrollment");
        }
    }

}