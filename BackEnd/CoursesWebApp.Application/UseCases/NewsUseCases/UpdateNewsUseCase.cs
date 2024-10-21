using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.NewsUseCases;

public class UpdateNewsUseCase : UseCase<NewsEntity>
{

    private readonly IRepository<NewsEntity> _repository;

    public UpdateNewsUseCase(IRepository<NewsEntity> repository)
    {
        _repository = repository;
    }

    public override async Task Update(NewsEntity entity)
    {
        await _repository.UpdateAsync(entity);
    }
}