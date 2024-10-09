using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.Abstract;

public abstract class LessonBaseUseCases : BaseUseCase<LessonEntity>
{

    public virtual Task Create(LessonEntity entity, long CourseId) =>
        throw new NotImplementedException("Should be overridden");

    public virtual Task Update(LessonEntity entity, long? courseId = null) =>
        throw new NotImplementedException("Should be overridden");

}