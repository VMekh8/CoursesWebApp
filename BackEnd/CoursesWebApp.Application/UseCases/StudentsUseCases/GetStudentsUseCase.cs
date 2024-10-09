using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.StudentsUseCases;

public class GetStudentsUseCase : BaseUseCase<StudentEntity>
{
    
    private readonly IReadOnlyRepository<StudentEntity> _studentsRepository;

    public GetStudentsUseCase(IReadOnlyRepository<StudentEntity> studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }

    public override async Task<IEnumerable<StudentEntity>> Get()
    {
        return await _studentsRepository.GetValuesAsync();
    }
}