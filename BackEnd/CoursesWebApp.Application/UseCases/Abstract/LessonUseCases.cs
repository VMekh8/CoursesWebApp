using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.Abstract;

public abstract class LessonUseCases : UseCase<LessonEntity>
{

    public virtual Task Create(LessonEntity entity, long? courseId) =>
        throw new NotImplementedException("Should be overridden");

    public virtual Task Update(LessonEntity entity, long? courseId) =>
        throw new NotImplementedException("Should be overridden");

}