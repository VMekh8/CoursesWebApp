using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.NewsUseCases;

public class GetNewsByIdUseCase : BaseUseCase<NewsEntity>
{
    private readonly IReadOnlyRepository<NewsEntity> _newOnlyRepository;

    public GetNewsByIdUseCase(IReadOnlyRepository<NewsEntity> newOnlyRepository)
    {
        _newOnlyRepository = newOnlyRepository;
    }

    public override async Task<NewsEntity?> GetById(long id)
    {
        return await _newOnlyRepository.GetByIdAsync(id);
    }
}