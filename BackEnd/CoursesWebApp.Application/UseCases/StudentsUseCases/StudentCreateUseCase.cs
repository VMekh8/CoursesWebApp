using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.StudentsUseCases;

public class StudentCreateUseCase : UseCase<StudentEntity>
{
    
    private readonly IRepository<StudentEntity> _repository;

    public StudentCreateUseCase(IRepository<StudentEntity> repository)
    {
        _repository = repository;
    }

    public override async Task Create(StudentEntity entity)
    {
        await _repository.CreateAsync(entity);
    }
}
