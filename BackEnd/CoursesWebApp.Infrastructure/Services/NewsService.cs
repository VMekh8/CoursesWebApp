using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Domain.Entities;
using CoursesWebApp.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CoursesWebApp.Infrastructure.Services
{
    public class NewsService : IRepository<NewsEntity>, IReadOnlyRepository<NewsEntity>
    {
        private readonly DBCoursesContext _context;

        public NewsService(DBCoursesContext context) =>
            _context = context;

        public async Task CreateAsync(NewsEntity entity) =>
             await _context.News.AddAsync(entity);
        

        public async Task UpdateAsync(NewsEntity entity) =>
            await _context.News
                .Where(n => n.Id == entity.Id)
                .ExecuteUpdateAsync(e =>
                    e.SetProperty(u => u.Title, entity.Title)
                    .SetProperty(u => u.Description, entity.Description)
                    .SetProperty(u => u.ImageURL, entity.ImageURL));

        public async Task DeleteAsync(long id) =>
            await _context.News
                .Where(n => n.Id == id)
                .ExecuteDeleteAsync();

        public async Task<IEnumerable<NewsEntity>> GetValuesAsync() =>
            await _context.News
                .AsNoTracking()
                .ToListAsync();
        

        public async Task<NewsEntity?> GetByIdAsync(long id) => 
            await _context.News
                .AsNoTracking()
                .FirstOrDefaultAsync(n => n.Id == id);
    }
}
