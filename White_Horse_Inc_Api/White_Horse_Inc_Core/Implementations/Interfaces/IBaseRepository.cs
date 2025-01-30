namespace White_Horse_Inc_Core.Implementations.Interfaces
{
    public interface IBaseRepository<TModel>
    {
        Task<List<TModel>> GetAsync(CancellationToken cancellationToken);
        Task<TModel> GetAsync(long id, CancellationToken cancellationToken);
        Task CreateAsync(TModel model, CancellationToken cancellationToken);
        Task UpdateAsync(TModel model, CancellationToken cancellationToken);
        Task DeleteAsync(long id, CancellationToken cancellationToken);
        Task DeleteAsync(TModel model, CancellationToken cancellationToken);
    }
}
