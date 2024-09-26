using System.Diagnostics;
using System.Text.Json;
using CoursesWebApp.Domain.Entities;
using CoursesWebApp.Infrastructure.Caching.Abstract;
using StackExchange.Redis;

namespace CoursesWebApp.Infrastructure.Caching.RedisServices
{
    public class RedisService<T> : IRedisService<T> where T : class
    {
        private readonly IDatabase _redisDb;

        public RedisService(IConnectionMultiplexer redisDatabase)
        {
            _redisDb = redisDatabase.GetDatabase();
        }
        public async Task<T?> GetAsync(long key)
        {
            var value = await _redisDb.StringGetAsync(key.ToString());

            return value.IsNull 
                ? null 
                : JsonSerializer.Deserialize<T>(value);
        }

        public async Task<IEnumerable<T>> GetAllAsync(string key)
        {
            var hashEntries = await _redisDb.HashGetAllAsync(key.ToString());

            if (hashEntries is null)
            {
                return Enumerable.Empty<T>();
            }

            return hashEntries.Select(entry =>
                JsonSerializer.Deserialize<T>(entry.Value))
                .AsEnumerable();
        }

        public async Task SetAsync(long key, T value, TimeSpan? expiration = null)
        {
            var jsonValue = JsonSerializer.Serialize(value);
            await _redisDb.StringSetAsync(key.ToString(), jsonValue, expiration);
        }

        public async Task SetListAsync(string key, IEnumerable<T> value, TimeSpan? expiration = null)
        {
            var jsonValue = JsonSerializer.Serialize(value);

            await _redisDb.StringSetAsync(key, jsonValue, expiration);
        }

        public async Task UpdateCacheAsync(long id, T entity, string constKey)
        {
            try
            {
                await SetAsync(id, entity, TimeSpan.FromMinutes(5));

                var cachedNewsList = (await GetAllAsync(constKey)).ToList();

                cachedNewsList.Add(entity);

                await SetListAsync(constKey, cachedNewsList, TimeSpan.FromMinutes(30));
            }
            catch (RedisException e)
            {
                Debug.WriteLine("Error with caching element");
                Debug.WriteLine(e.Message);
            }
        }

        public async Task RemoveAsync(long key)
        {
            await _redisDb.KeyDeleteAsync(key.ToString());
        }
    }
}
