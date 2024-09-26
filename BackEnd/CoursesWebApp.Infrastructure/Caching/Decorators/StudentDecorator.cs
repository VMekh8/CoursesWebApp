using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Domain.Entities;
using CoursesWebApp.Infrastructure.Caching.Abstract;

namespace CoursesWebApp.Infrastructure.Caching.Decorators;

public class StudentDecorator : IRepository<StudentEntity>, IReadOnlyRepository<StudentEntity>
{
    private const string AllStudentsKey = "all_student";

    private readonly IRepository<StudentEntity> _repository;
    private readonly IReadOnlyRepository<StudentEntity> _readOnlyRepository;
    private readonly IRedisService<StudentEntity> _redisService;

    public StudentDecorator(
        IRepository<StudentEntity> repository,
        IReadOnlyRepository<StudentEntity> readOnlyRepository,
        IRedisService<StudentEntity> redisService)
    {
        _repository = repository;
        _readOnlyRepository = readOnlyRepository;
        _redisService = redisService;
    }

    public async Task CreateAsync(StudentEntity entity)
    {
        await _repository.CreateAsync(entity);

        await _redisService.UpdateCacheAsync(entity.Id, entity, AllStudentsKey);
    }

    public async Task UpdateAsync(StudentEntity entity)
    {
        await _repository.UpdateAsync(entity);

        await _redisService.UpdateCacheAsync(entity.Id, entity, AllStudentsKey);
    }

    public async Task DeleteAsync(long id)
    {
        await _repository.DeleteAsync(id);

        await _redisService.RemoveAsync(id);
    }

    public async Task<IEnumerable<StudentEntity>> GetValuesAsync()
    {
        var cachedStudents = (await _redisService.GetAllAsync(AllStudentsKey)).ToList();

        if (!cachedStudents.Any())
        {

            var studentsList = await _readOnlyRepository.GetValuesAsync();

            if (studentsList is null)
            {
                return Enumerable.Empty<StudentEntity>();
            }

            await _redisService.SetListAsync(AllStudentsKey, studentsList, TimeSpan.FromMinutes(30));

            return studentsList;
        }

        return cachedStudents;
    }

    public async Task<StudentEntity?> GetByIdAsync(long id)
    {
        var cachedStudent = await _redisService.GetAsync(id);

        if (cachedStudent is null)
        {

            StudentEntity studentItem = await _readOnlyRepository.GetByIdAsync(id);

            if (studentItem is null)
            {
                return null;
            }

            await _redisService.SetAsync(studentItem.Id, studentItem, TimeSpan.FromMinutes(5));

            return studentItem;
        }

        return cachedStudent;
    }
}