namespace CoursesWebApp.Application.UseCases.Abstract;

public abstract class BaseUseCase<T> where T : class
{
    
    public virtual Task Create() => Task.CompletedTask;

    public virtual Task CreateWithCourse(T entity, long courseId) => Task.CompletedTask;

    public virtual Task Update(T entity, long? courseId) => Task.CompletedTask;

    public virtual Task Remove(T entity) => Task.CompletedTask;

    public virtual Task Get() => Task.CompletedTask;

    public virtual Task GetById(long id) => Task.CompletedTask;
}