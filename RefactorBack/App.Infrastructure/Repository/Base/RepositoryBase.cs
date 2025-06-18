using App.Domain.Abstractions;
using App.Domain.Repository.Base;
using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repository.Base;

public class RepositoryBase<TEntity>(AppDbContext _context) : IRepositoryBase<TEntity> where TEntity : BaseEntity
{
    private readonly DbSet<TEntity> _DbContext = _context.Set<TEntity>();

    public async Task<TEntity?> CreateAsync(TEntity user, CancellationToken cancellationToken = default)
    {
        try
        {
            await _DbContext.AddAsync(user, cancellationToken);
            return user;
        }
        catch 
        {
            return default;
        }
    }

    public TEntity? UpdateAsync(TEntity user, CancellationToken cancellationToken = default)
    {
        try
        {
            user.UpdateValues();
            _DbContext.Update(user);
            return user;
        }
        catch
        {
            return default;
        }
    }

    public async Task<TEntity?> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _DbContext.FirstOrDefaultAsync(x => x.Id == id && x.IsActive, cancellationToken);
            user?.DisableEntity();
            return user ?? default;
        }
        catch 
        {
            return default;
        }
    }

    public async Task<TEntity?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _DbContext.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.IsActive, cancellationToken);
            return user ?? default;
        }
        catch 
        {
            return default;
        }
    }

    public async Task<List<TEntity>?> GetAllUsers(CancellationToken cancellationToken = default)
    {
        try
        {
            var usersList = await _DbContext
                .AsNoTracking()
                .Where(x => x.IsActive)
                .ToListAsync(cancellationToken);

            return usersList ?? [];
        }
        catch 
        {
            return [];
        }
    }
}