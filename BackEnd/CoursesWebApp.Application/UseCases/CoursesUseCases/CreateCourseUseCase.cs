using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.CoursesUseCases;

public class CreateCourseUseCase : CoursesUseCase
{

    private readonly IRepository<CourseEntity> _repository;

    public CreateCourseUseCase(IRepository<CourseEntity> repository)
    {
        _repository = repository;
    }

    public override async Task Create(CourseEntity entity)
    {
        await _repository.CreateAsync(entity);
    }
}