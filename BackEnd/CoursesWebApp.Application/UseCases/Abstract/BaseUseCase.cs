namespace CoursesWebApp.Application.UseCases.Abstract;

public abstract class BaseUseCase<T> where T : class
{
    
    public virtual Task Create(T entity) => 
        throw new NotImplementedException("Should be overridden");

    public virtual Task Update(T entity) =>
        throw new NotImplementedException("Should be overridden");

    public virtual Task Remove(T entity) => 
        throw new NotImplementedException("Should be overridden");

    public virtual Task<IEnumerable<T>> Get() => 
        throw new NotImplementedException("Should be overridden");

    public virtual Task<T?> GetById(long id) => 
        throw new NotImplementedException("Should be overridden");
}