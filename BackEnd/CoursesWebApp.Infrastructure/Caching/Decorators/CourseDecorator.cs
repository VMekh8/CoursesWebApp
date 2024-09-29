using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Domain.Entities;
using CoursesWebApp.Infrastructure.Caching.Abstract;

namespace CoursesWebApp.Infrastructure.Caching.Decorators;

public class CourseDecorator : IRepository<CourseEntity>, IReadOnlyRepository<CourseEntity>
{
    private const string AllCourseKey = "all_courses";

    private readonly IRepository<CourseEntity> _repository;
    private readonly IReadOnlyRepository<CourseEntity> _readOnlyRepository;
    private readonly IRedisService<CourseEntity> _redisService;


    public CourseDecorator(
        IRepository<CourseEntity> repository,
        IReadOnlyRepository<CourseEntity> readOnlyRepository,
        IRedisService<CourseEntity> redisService)
    {
        _repository = repository;
        _readOnlyRepository = readOnlyRepository;
        _redisService = redisService;
    }

    public async Task CreateAsync(CourseEntity entity)
    {
        await _repository.CreateAsync(entity);

        await _redisService.UpdateCacheAsync(entity.Id, entity, AllCourseKey);
    }

    public async Task UpdateAsync(CourseEntity entity)
    {
        await _repository.UpdateAsync(entity);

        await _redisService.UpdateCacheAsync(entity.Id, entity, AllCourseKey);
    }

    public async Task DeleteAsync(long id)
    {
        await _repository.DeleteAsync(id);

        await _redisService.RemoveAsync(id);
    }

    public async Task<IEnumerable<CourseEntity>> GetValuesAsync()
    {
        var cachedCourses = await _redisService.GetAllAsync(AllCourseKey);

        if (!cachedCourses.Any())
        {

            var coursesList = await _readOnlyRepository.GetValuesAsync();

            if (!coursesList.Any())
            {
                return Enumerable.Empty<CourseEntity>();
            }

            await _redisService.SetListAsync(AllCourseKey, coursesList, TimeSpan.FromMinutes(30));

            return coursesList;
        }

        return cachedCourses;
    }

    public async Task<CourseEntity?> GetByIdAsync(long id)
    {
        var cachedCourse = await _redisService.GetAsync(id);

        if (cachedCourse is null)
        {
            var courseItem = await _readOnlyRepository.GetByIdAsync(id);

            if (courseItem is null)
            {
                return null;
            }

            await _redisService.SetAsync(courseItem.Id, courseItem, TimeSpan.FromMinutes(5));

            return courseItem;
        }

        return cachedCourse;
    }
}