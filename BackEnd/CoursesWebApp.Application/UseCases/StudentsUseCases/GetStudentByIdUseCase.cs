using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.StudentsUseCases;

public class GetStudentByIdUseCase : UseCase<StudentEntity>
{
    
    private readonly IReadOnlyRepository<StudentEntity> _studentsRepository;

    public GetStudentByIdUseCase(IReadOnlyRepository<StudentEntity> studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }

    public override async Task<StudentEntity?> GetById(long id)
    {
        return await _studentsRepository.GetByIdAsync(id);
    }
}