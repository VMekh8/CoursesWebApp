using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.TeacherUseCases;

public class RemoveTeacherUseCase : TeacherUseCase
{
    private readonly IRepository<TeacherEntity> _repository;

    public RemoveTeacherUseCase(IRepository<TeacherEntity> repository)
    {
        _repository = repository;
    }

    public override async Task Remove(TeacherEntity entity)
    {
        await _repository.DeleteAsync(entity.Id);
    }
}