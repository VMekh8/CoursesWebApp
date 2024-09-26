using System.Diagnostics;
using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Domain.Entities;
using CoursesWebApp.Infrastructure.Caching.Abstract;
using StackExchange.Redis;

namespace CoursesWebApp.Infrastructure.Caching.Decorators;

public class NewsDecorator : IRepository<NewsEntity>, IReadOnlyRepository<NewsEntity>
{
    private const string AllNewsKey = "all_news";

    private readonly IRedisService<NewsEntity> _redisServices;
    private readonly IRepository<NewsEntity> _newsRepository;
    private readonly IReadOnlyRepository<NewsEntity> _newsReadOnlyRepository;

    public NewsDecorator(
        IRedisService<NewsEntity> redisServices, 
        IRepository<NewsEntity> newsRepository, 
        IReadOnlyRepository<NewsEntity> newsReadOnlyRepository)
    {
        _redisServices = redisServices;
        _newsRepository = newsRepository;
        _newsReadOnlyRepository = newsReadOnlyRepository;
    }

    public async Task CreateAsync(NewsEntity entity)
    {
        await _newsRepository.CreateAsync(entity);

        await _redisServices.UpdateCacheAsync(entity.Id, entity, AllNewsKey);
    }

    public async Task UpdateAsync(NewsEntity entity)
    {
        await _newsRepository.UpdateAsync(entity);

        await _redisServices.UpdateCacheAsync(entity.Id, entity, AllNewsKey);
    }

    public async Task DeleteAsync(long id)
    {
        await _newsRepository.DeleteAsync(id);

        await _redisServices.RemoveAsync(id);
    }

    public async Task<IEnumerable<NewsEntity>> GetValuesAsync()
    {
        var cachedNews = await _redisServices.GetAllAsync(AllNewsKey);

        if (!cachedNews.Any())
        {

            var newsList = await _newsReadOnlyRepository.GetValuesAsync();

            if (!newsList.Any())
            {
                await _redisServices.SetListAsync(AllNewsKey, newsList, TimeSpan.FromMinutes(30));

                return newsList;
            }

            return Enumerable.Empty<NewsEntity>();
        }

        return cachedNews;
    }

    public async Task<NewsEntity?> GetByIdAsync(long id)
    {
        var cacheNews = await _redisServices.GetAsync(id);

        if (cacheNews is null)
        {
            NewsEntity newsItem = await _newsReadOnlyRepository.GetByIdAsync(id);

            if (newsItem is not null)
            {
                await _redisServices.SetAsync(id, newsItem, TimeSpan.FromMinutes(5));

                return newsItem;
            }

            return null;
        }

        return cacheNews;
    }
}