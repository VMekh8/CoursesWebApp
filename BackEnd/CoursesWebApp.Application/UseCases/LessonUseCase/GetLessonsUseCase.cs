using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.LessonUseCase;

public class GetLessonsUseCase : LessonUseCases
{
    private readonly IReadOnlyRepository<LessonEntity> _readOnlyRepository;

    public GetLessonsUseCase(IReadOnlyRepository<LessonEntity> readOnlyRepository)
    {
        _readOnlyRepository = readOnlyRepository;
    }

    public override async Task<IEnumerable<LessonEntity>> Get()
    {
        return await _readOnlyRepository.GetValuesAsync();
    }
}