using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Domain.Entities;
using CoursesWebApp.Infrastructure.Caching.Abstract;

namespace CoursesWebApp.Infrastructure.Caching.Decorators;

public class NewsDecorator : IRepository<NewsEntity>, IReadOnlyRepository<NewsEntity>
{
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
        throw new NotImplementedException();
    }

    public Task UpdateAsync(NewsEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<NewsEntity>> GetValuesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<NewsEntity?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}