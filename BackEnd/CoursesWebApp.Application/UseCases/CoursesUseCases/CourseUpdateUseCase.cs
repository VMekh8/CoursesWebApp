using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Domain.Entities;
using CoursesWebApp.Application.UseCases.Abstract;

namespace CoursesWebApp.Application.UseCases.CoursesUseCases;

public class CourseUpdateUseCase : CoursesUseCase
{

    private readonly IRepository<CourseEntity> _repository;

    public CourseUpdateUseCase(IRepository<CourseEntity> repository)
    {
        _repository = repository;
    }

    public override async Task Update(CourseEntity entity)
    {
        await _repository.UpdateAsync(entity);
    }
}