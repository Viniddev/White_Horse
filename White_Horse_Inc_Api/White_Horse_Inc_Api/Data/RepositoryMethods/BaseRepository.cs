using Microsoft.EntityFrameworkCore;
using White_Horse_Inc_Core.Interfaces;
using White_Horse_Inc_Core.Models.Base;
using White_Horse_Inc_Core.Requests;
using White_Horse_Inc_Core.Response;

namespace White_Horse_Inc_Api.Data.RepositoryMethods
{
    public class BaseRepository<TModel>(AppDbContext context, ILogger<BaseRepository<TModel>> logger) : IBaseRepository<TModel> where TModel : BaseEntity
    {
        protected readonly DbSet<TModel> _dbSet = context.GetDbSet<TModel>();

        public async Task<PagedResponse<List<TModel>>> GetAllPagedAsync(PagedRequest pagedRequest, CancellationToken cancellationToken)
        {
            var response = await _dbSet
                .Skip((pagedRequest.PageNumber - 1) * pagedRequest.PageSize)
                .Take(pagedRequest.PageSize)
                .ToListAsync(cancellationToken: cancellationToken);

            return new PagedResponse<List<TModel>>(response, response.Count(), pagedRequest.PageSize, pagedRequest.PageNumber);
        }

        public async Task<PagedResponse<List<TModel>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var response = await _dbSet
                .ToListAsync(cancellationToken: cancellationToken);

            return new PagedResponse<List<TModel>>(response, response.Count(), response.Count(), 1);
        }

        public async Task<BaseResponse<TModel>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            var response = await _dbSet.SingleAsync(w => w.Id == id, cancellationToken);

            return new BaseResponse<TModel>(response, 200, "Success.");
        }   

        public async Task<BaseResponse<TModel>> CreateAsync(TModel model, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(model, cancellationToken: cancellationToken);
            await SaveChangesAsync(cancellationToken);

            return new BaseResponse<TModel>(model, 201, "Success.");
        }

        public async Task<BaseResponse<TModel>> UpdateAsync(TModel model, CancellationToken cancellationToken)
        {
            _dbSet.Update(model);
            await SaveChangesAsync(cancellationToken);

            return new BaseResponse<TModel>(model, 200, "Success.");
        }

        public async Task DeleteAsync(TModel model, CancellationToken cancellationToken)
        {
            _dbSet.Remove(model);
            await SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken)
        {
            var model = await _dbSet.SingleAsync(w => w.Id == id, cancellationToken);
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
    }
}
