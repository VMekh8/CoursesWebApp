using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.Abstract;

public abstract class TeacherBaseUseCases : BaseUseCase<TeacherEntity>
{
    public virtual Task Create(LessonEntity entity, IEnumerable<long> CoursesId) =>
        throw new NotImplementedException("Should be overridden");

    public virtual Task Update(LessonEntity entity, IEnumerable<long> CoursesId) =>
        throw new NotImplementedException("Should be overridden");
}