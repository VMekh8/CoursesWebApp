using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Domain.Entities;
using CoursesWebApp.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CoursesWebApp.Infrastructure.Services
{
    public class NewsService(DBCoursesContext context) : IRepository<NewsEntity>, IReadOnlyRepository<NewsEntity>
    {
        public async Task CreateAsync(NewsEntity entity)
        {
            await context.News.AddAsync(entity);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(NewsEntity entity)
        {
            await context.News
                .Where(n => n.Id == entity.Id)
                .ExecuteUpdateAsync(e =>
                    e.SetProperty(u => u.Title, entity.Title)
                    .SetProperty(u => u.Description, entity.Description)
                    .SetProperty(u => u.ImageURL, entity.ImageURL));

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await context.News
                .Where(n => n.Id == id)
                .ExecuteDeleteAsync();

            await context.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<NewsEntity>> GetValuesAsync() =>
            await context.News
                .AsNoTracking()
                .ToListAsync();
        

        public async Task<NewsEntity?> GetByIdAsync(long id) => 
            await context.News
                .FirstOrDefaultAsync(n => n.Id == id);
    }
}
