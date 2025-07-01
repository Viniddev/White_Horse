using App.Domain.Abstractions;

namespace App.Domain.Repository.Base;

public interface IRepositoryBase<TEntity>: IAggregateRoot
{
    Task<TEntity?> CreateAsync(TEntity user, CancellationToken cancellationToken = default);
    TEntity? UpdateAsync(TEntity user, CancellationToken cancellationToken = default);
    Task<TEntity?> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<TEntity>?> GetAllAsync(CancellationToken cancellationToken = default);
}
