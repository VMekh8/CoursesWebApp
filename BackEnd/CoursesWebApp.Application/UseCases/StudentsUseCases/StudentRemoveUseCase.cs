using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.StudentsUseCases;

public class StudentRemoveUseCase : UseCase<StudentEntity>
{

    private readonly IRepository<StudentEntity> _repository;

    public StudentRemoveUseCase(IRepository<StudentEntity> repository)
    {
        _repository = repository;
    }

    public override async Task Remove(StudentEntity entity)
    {
        await _repository.DeleteAsync(entity.Id);
    }
}