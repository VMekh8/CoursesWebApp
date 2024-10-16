using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.NewsUseCases;

public class GetNewsUseCase : UseCase<NewsEntity>
{

    private readonly IReadOnlyRepository<NewsEntity> _newsRepository;

    public GetNewsUseCase(IReadOnlyRepository<NewsEntity> newsRepository)
    {
        _newsRepository = newsRepository;
    }

    public override async Task<IEnumerable<NewsEntity>> Get()
    {
        return await _newsRepository.GetValuesAsync();
    }
}