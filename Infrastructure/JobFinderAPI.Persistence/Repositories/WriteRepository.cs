using JobFinderAPI.Application.Interfaces.Repositories;
using JobFinderAPI.Domain.Entities.Common;
using JobFinderAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace JobFinderAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly JobFinderDbContext _context;
        private readonly DbSet<T> _table;

        public WriteRepository(JobFinderDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }
        public async Task AddAsync(T entity) => await _table.AddAsync(entity);
        public async Task AddRangeAsync(List<T> entities) => await _table.AddRangeAsync(entities);
        public void Update(T entity) => _table.Update(entity);
        public void Delete(T entity) => _table.Remove(entity);
    }
}
