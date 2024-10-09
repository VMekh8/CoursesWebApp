using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.LessonUseCase;

public class CreateLessonUseCase : LessonBaseUseCases
{

    private readonly IRepository<LessonEntity> _repository;

    public CreateLessonUseCase(IRepository<LessonEntity> repository)
    {
        _repository = repository;
    }

    public override async Task Create(LessonEntity entity, long CourseId)
    {

    }
}