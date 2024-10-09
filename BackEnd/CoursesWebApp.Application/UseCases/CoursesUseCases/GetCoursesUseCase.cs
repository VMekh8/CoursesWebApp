using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.CoursesUseCases;

public class GetCoursesUseCase : CoursesBaseUseCase
{
    
    private readonly IReadOnlyRepository<CourseEntity> _courseRepository;

    public GetCoursesUseCase(IReadOnlyRepository<CourseEntity> courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public override async Task<IEnumerable<CourseEntity>> Get()
    {
        return await _courseRepository.GetValuesAsync();
    }
}