using JobFinderAPI.Application.Interfaces.Repositories;
using JobFinderAPI.Domain.Entities.Common;

namespace JobFinderAPI.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IReadRepository<T> ReadRepository<T>() where T : BaseEntity;
        IWriteRepository<T> WriteRepository<T>() where T : BaseEntity;
        Task<int> SaveAsync();
    }
}
