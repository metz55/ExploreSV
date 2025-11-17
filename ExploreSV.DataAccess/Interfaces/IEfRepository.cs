using Ardalis.Specification;

namespace ExploreSV.DataAccess.Interfaces
{
    public interface IEfRepository<T> : IRepositoryBase<T> where T : class
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    }
}