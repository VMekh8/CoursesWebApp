namespace CoursesWebApp.Application.Abstract.CRUD
{
    public interface IReadOnlyRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetValuesAsync();
        Task<T?> GetByIdAsync(long id);
    }
}
