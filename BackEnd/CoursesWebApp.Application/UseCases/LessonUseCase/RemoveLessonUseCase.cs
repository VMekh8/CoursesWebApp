using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.LessonUseCase;

public class RemoveLessonUseCase : Abstract.LessonUseCase
{
    private readonly IRepository<LessonEntity> _repository;

    public RemoveLessonUseCase(IRepository<LessonEntity> repository)
    {
        _repository = repository;
    }

    public override async Task Remove(LessonEntity entity)
    {
        await _repository.DeleteAsync(entity.Id);
    }
}