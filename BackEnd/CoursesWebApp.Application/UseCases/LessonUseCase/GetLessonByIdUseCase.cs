using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.LessonUseCase;

public class GetLessonByIdUseCase : LessonUseCases
{
    private readonly IReadOnlyRepository<LessonEntity> _readOnlyRepository;

    public GetLessonByIdUseCase(IReadOnlyRepository<LessonEntity> readOnlyRepository)
    {
        _readOnlyRepository = readOnlyRepository;
    }

    public override async Task<LessonEntity?> GetById(long id)
    {
        return await _readOnlyRepository.GetByIdAsync(id);
    }
}