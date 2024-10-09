using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.CoursesUseCases;

public class GetCourseByIdUseCase : CoursesBaseUseCase
{
    
    private readonly IReadOnlyRepository<CourseEntity> _courseRepository;

    public GetCourseByIdUseCase(IReadOnlyRepository<CourseEntity> courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public override async Task<CourseEntity?> GetById(long id)
    {
        return await _courseRepository.GetByIdAsync(id);
    }
}