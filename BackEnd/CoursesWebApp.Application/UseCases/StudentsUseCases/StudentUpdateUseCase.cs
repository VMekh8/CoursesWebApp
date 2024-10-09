using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.StudentsUseCases;

public class StudentUpdateUseCase : BaseUseCase<StudentEntity>
{

    private readonly IRepository<StudentEntity> _repository;

    public StudentUpdateUseCase(IRepository<StudentEntity> repository)
    {
        _repository = repository;
    }

    public override async Task Update(StudentEntity entity)
    {
        await _repository.UpdateAsync(entity);
    }
}