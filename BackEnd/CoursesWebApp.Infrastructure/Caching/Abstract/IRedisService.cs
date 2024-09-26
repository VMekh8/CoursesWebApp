namespace CoursesWebApp.Infrastructure.Caching.Abstract;

public interface IRedisService<T> where T : class
{
    Task<T?> GetAsync(long key);

    Task<IEnumerable<T>> GetAllAsync(string key);

    Task SetAsync(long key, T value, TimeSpan? expiration = null);

    Task SetListAsync(string key, IEnumerable<T> value, TimeSpan? expiration = null);

    Task RemoveAsync(long key);
}