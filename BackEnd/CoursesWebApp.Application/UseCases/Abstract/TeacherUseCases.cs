using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.Abstract;

public abstract class TeacherUseCases : UseCase<TeacherEntity>
{
    public virtual Task Create(LessonEntity entity, IEnumerable<long> CoursesId) =>
        throw new NotImplementedException("Should be overridden");

    public virtual Task Update(LessonEntity entity, IEnumerable<long> CoursesId) =>
        throw new NotImplementedException("Should be overridden");
}