using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.TeacherUseCases;

public class GetTeachersUseCase : TeacherUseCase
{
    private readonly IReadOnlyRepository<TeacherEntity> _readOnlyRepository;

    public GetTeachersUseCase(IReadOnlyRepository<TeacherEntity> readOnlyRepository)
    {
        _readOnlyRepository = readOnlyRepository;
    }

    public override async Task<IEnumerable<TeacherEntity>> Get()
    {
        return await _readOnlyRepository.GetValuesAsync();
    }
}