using JobFinderAPI.Application.Interfaces.Repositories;
using JobFinderAPI.Application.Interfaces.UnitOfWorks;
using JobFinderAPI.Domain.Entities.Common;
using JobFinderAPI.Persistence.Context;
using JobFinderAPI.Persistence.Repositories;

namespace JobFinderAPI.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        JobFinderDbContext _context;
        public UnitOfWork(JobFinderDbContext context)
        {
            _context = context;
        }
        public async ValueTask DisposeAsync() => await _context.DisposeAsync();

        public Task<int> SaveAsync() => _context.SaveChangesAsync();

        public IReadRepository<T> ReadRepository<T>() where T : BaseEntity
            => new ReadRepository<T>(_context);

        public IWriteRepository<T> WriteRepository<T>() where T : BaseEntity
            => new WriteRepository<T>(_context);
    }
}
