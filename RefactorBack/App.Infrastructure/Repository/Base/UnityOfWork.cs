using App.Domain.Repository.Base;
using App.Infrastructure.Data;

namespace App.Infrastructure.Repository.Base;

public class UnitOfWork(AppDbContext _dbContext) : IUnitOfWork
{
    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
