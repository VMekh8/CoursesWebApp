using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.NewsUseCases;

public class RemoveNewsUseCase :BaseUseCase<NewsEntity>
{

    private readonly IRepository<NewsEntity> _repository;

    public RemoveNewsUseCase(IRepository<NewsEntity> repository)
    {
        _repository = repository;
    }

    public override async Task Remove(NewsEntity entity)
    {
        await _repository.DeleteAsync(entity.Id);
    }
}