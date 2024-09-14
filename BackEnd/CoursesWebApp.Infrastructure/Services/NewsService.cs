using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Infrastructure.Services
{
    public class NewsService : IRepository<NewsEntity>, IReadOnlyRepository<NewsEntity>
    {
        public Task<NewsEntity> CreateAsync(NewsEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<NewsEntity> UpdateAsync(NewsEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<NewsEntity> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NewsEntity>> GetValuesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<NewsEntity> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
