using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using White_Horse_Inc_Api.Data;
using White_Horse_Inc_Core.Interfaces;
using White_Horse_Inc_Core.Models;

namespace White_Horse_Inc_Api.RepositoryMethods
{
    public class BaseRepository<TModel>(AppDbContext context, ILogger<BaseRepository<TModel>> logger) : IBaseRepository<TModel> where TModel : BaseEntity
    {
        protected readonly DbSet<TModel> _dbSet = context.GetDbSet<TModel>();

        public async Task<List<TModel>> GetAsync(CancellationToken cancellationToken)
            => await _dbSet.ToListAsync(cancellationToken: cancellationToken);

        public async Task CreateAsync(TModel model, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(model, cancellationToken: cancellationToken);
            await SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(TModel model, CancellationToken cancellationToken)
        {
            _dbSet.Update(model);
            await SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(TModel model, CancellationToken cancellationToken)
        {
            _dbSet.Remove(model);
            await SaveChangesAsync(cancellationToken);
        }

        protected async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                await context.SaveChangesAsync(cancellationToken: cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex, "Error saving changes to the database");
                throw new InvalidOperationException("Could not save changes to the database. See inner exception for details.", ex);
            }
            finally
            {
                await context.Database.CloseConnectionAsync();
            }
        }

        public async Task<TModel> GetAsync(long id, CancellationToken cancellationToken)
            => await _dbSet.SingleAsync(w => w.Id == id, cancellationToken);

        public async Task DeleteAsync(long id, CancellationToken cancellationToken)
        {
            var model = await _dbSet.SingleAsync(w => w.Id == id, cancellationToken);
            _dbSet.Remove(model);
            await SaveChangesAsync(cancellationToken);
        }
    }
}
