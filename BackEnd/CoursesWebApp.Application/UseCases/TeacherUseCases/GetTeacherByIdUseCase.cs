using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.TeacherUseCases;

public class GetTeacherByIdUseCase : TeacherUseCase
{
    private readonly IReadOnlyRepository<TeacherEntity> _readOnlyRepository;

    public GetTeacherByIdUseCase(IReadOnlyRepository<TeacherEntity> readOnlyRepository)
    {
        _readOnlyRepository = readOnlyRepository;
    }

    public override async Task<TeacherEntity?> GetById(long id)
    {
        return await _readOnlyRepository.GetByIdAsync(id);
    }
}