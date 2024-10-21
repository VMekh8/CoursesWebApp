using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Application.UseCases.CoursesUseCases;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.LessonUseCase;

public class UpdateLessonUseCase : Abstract.LessonUseCase
{
    private readonly IRepository<LessonEntity> _repository;
    private readonly GetCourseByIdUseCase _getCourse;

    public UpdateLessonUseCase(IRepository<LessonEntity> repository, GetCourseByIdUseCase getCourse)
    {
        _repository = repository;
        _getCourse = getCourse;
    }


    public override async Task Update(LessonEntity entity, long? courseId)
    {
        entity.Course = courseId is null ? null
            : await _getCourse.GetById((long)courseId);

        await _repository.UpdateAsync(entity);
    }
}