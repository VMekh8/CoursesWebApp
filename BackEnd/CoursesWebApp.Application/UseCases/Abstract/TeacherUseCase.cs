using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.Abstract;

public abstract class TeacherUseCase : UseCase<TeacherEntity>
{
    public virtual Task Create(TeacherEntity entity, IEnumerable<long> coursesId) =>
        throw new NotImplementedException("Should be overridden");

    public virtual Task Update(TeacherEntity entity, IEnumerable<long> coursesId) =>
        throw new NotImplementedException("Should be overridden");
}