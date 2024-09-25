namespace CoursesWebApp.Infrastructure.Caching.Abstract;

public interface IRedisService<T> where T : class
{
    Task<T> GetAsync(string key);

    Task SetAsync(string key, T value, TimeSpan? expiration = null);

    Task RemoveAsync(string key);
}