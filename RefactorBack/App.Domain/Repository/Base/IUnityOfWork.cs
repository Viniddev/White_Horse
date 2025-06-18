namespace App.Domain.Repository.Base;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellation = default);
}
