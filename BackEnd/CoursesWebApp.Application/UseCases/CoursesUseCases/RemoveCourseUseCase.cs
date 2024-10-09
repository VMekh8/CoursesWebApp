using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.CoursesUseCases;

public class RemoveCourseUseCase : CoursesBaseUseCase
{

    private readonly IRepository<CourseEntity> _repository;

    public RemoveCourseUseCase(IRepository<CourseEntity> repository)
    {
        _repository = repository;
    }

    public override async Task Remove(CourseEntity entity)
    {
        await _repository.DeleteAsync(entity.Id);
    }
}