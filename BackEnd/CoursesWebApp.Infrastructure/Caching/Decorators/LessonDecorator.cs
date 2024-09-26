using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Domain.Entities;
using CoursesWebApp.Infrastructure.Caching.Abstract;

namespace CoursesWebApp.Infrastructure.Caching.Decorators;

public class LessonDecorator : IRepository<LessonEntity>, IReadOnlyRepository<LessonEntity>
{
    private const string AllLessonKey = "all_lessons";

    private readonly IRepository<LessonEntity> _repository;
    private readonly IReadOnlyRepository<LessonEntity> _readOnlyRepository;
    private readonly IRedisService<LessonEntity> _redisService;

    public LessonDecorator(
        IRepository<LessonEntity> repository,
        IReadOnlyRepository<LessonEntity> readOnlyRepository,
        IRedisService<LessonEntity> redisService)
    {
        
        _repository = repository;
        _readOnlyRepository = readOnlyRepository;
        _redisService = redisService;
    }

    public async Task CreateAsync(LessonEntity entity)
    {
        await _repository.CreateAsync(entity);

        await _redisService.UpdateCacheAsync(entity.Id, entity, AllLessonKey);
    }

    public async Task UpdateAsync(LessonEntity entity)
    {
        await _repository.UpdateAsync(entity);

        await _redisService.UpdateCacheAsync(entity.Id, entity, AllLessonKey);
    }

    public async Task DeleteAsync(long id)
    {
        await _repository.DeleteAsync(id);

        await _redisService.RemoveAsync(id);
    }

    public async Task<IEnumerable<LessonEntity>> GetValuesAsync()
    {
        var cachedLessons = (await _redisService.GetAllAsync(AllLessonKey)).ToList();

        if (!cachedLessons.Any())
        {

            var lessonsList = await _readOnlyRepository.GetValuesAsync();

            if (!lessonsList.Any())
            {
                return Enumerable.Empty<LessonEntity>();
            }

            await _redisService.SetListAsync(AllLessonKey, lessonsList, TimeSpan.FromMinutes(30));

            return lessonsList;
        }

        return cachedLessons;
    }

    public async Task<LessonEntity?> GetByIdAsync(long id)
    {
        var cachedLesson = await _redisService.GetAsync(id);

        if (cachedLesson is null)
        {

            var lessonItem = await _readOnlyRepository.GetByIdAsync(id);

            if (lessonItem is null)
            {
                return null;
            }

            await _redisService.SetAsync(lessonItem.Id, lessonItem, TimeSpan.FromMinutes(5));

            return lessonItem;
        }

        return cachedLesson;
    }
}