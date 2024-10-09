using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.CoursesUseCases;

public class CourseUpdateUseCase : CoursesBaseUseCase
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