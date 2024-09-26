using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Domain.Entities;
using CoursesWebApp.Infrastructure.Caching.Abstract;

namespace CoursesWebApp.Infrastructure.Caching.Decorators;

public class TeacherDecorator : IRepository<TeacherEntity>, IReadOnlyRepository<TeacherEntity>
{

    private const string AllTeacherKey = "all_teachers";

    private readonly IRepository<TeacherEntity> _repository;
    private readonly IReadOnlyRepository<TeacherEntity> _readOnlyRepository;
    private readonly IRedisService<TeacherEntity> _redisService;

    public TeacherDecorator(
        IRepository<TeacherEntity> repository, 
        IReadOnlyRepository<TeacherEntity> readOnlyRepository, 
        IRedisService<TeacherEntity> redisService)
    {
        _repository = repository;
        _readOnlyRepository = readOnlyRepository;
        _redisService = redisService;
    }

    public async Task CreateAsync(TeacherEntity entity)
    {
        await _repository.CreateAsync(entity);

        await _redisService.UpdateCacheAsync(entity.Id, entity, AllTeacherKey);
    }

    public async Task UpdateAsync(TeacherEntity entity)
    {
        await _repository.UpdateAsync(entity);

        await _redisService.UpdateCacheAsync(entity.Id, entity, AllTeacherKey);
    }

    public async Task DeleteAsync(long id)
    {
        await _repository.DeleteAsync(id);

        await _redisService.RemoveAsync(id);
    }

    public async Task<IEnumerable<TeacherEntity>> GetValuesAsync()
    {
        var cachedTeachers = await _redisService.GetAllAsync(AllTeacherKey);

        if (!cachedTeachers.Any())
        {

            var teachersList = await _readOnlyRepository.GetValuesAsync();

            if (!teachersList.Any())
            {
                return Enumerable.Empty<TeacherEntity>();
            }

            await _redisService.SetListAsync(AllTeacherKey, teachersList, TimeSpan.FromMinutes(30));

            return teachersList;
        }

        return cachedTeachers;
    }

    public async Task<TeacherEntity?> GetByIdAsync(long id)
    {
        var cachedTeacher = await _redisService.GetAsync(id);

        if (cachedTeacher is null)
        {

            var teacherItem = await _readOnlyRepository.GetByIdAsync(id);

            if (teacherItem is null)
            {
                return null;
            }

            await _redisService.SetAsync(teacherItem.Id, teacherItem, TimeSpan.FromMinutes(5));

            return teacherItem;
        }

        return cachedTeacher;
    }
}