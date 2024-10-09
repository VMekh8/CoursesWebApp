using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.NewsUseCases;

public class CreateNewsUseCase : BaseUseCase<NewsEntity>
{

    private readonly IRepository<NewsEntity> _repository;

    public CreateNewsUseCase(IRepository<NewsEntity> repository)
    {
        _repository = repository;
    }

    public override async Task Create(NewsEntity entity)
    {
        await _repository.CreateAsync(entity);
    }
}