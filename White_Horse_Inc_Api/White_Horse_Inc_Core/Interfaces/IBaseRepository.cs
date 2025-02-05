using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using White_Horse_Inc_Core.Requests;
using White_Horse_Inc_Core.Response;

namespace White_Horse_Inc_Core.Interfaces
{
    public interface IBaseRepository<TModel>
    {
        Task<PagedResponse<List<TModel>>> GetAllPagedAsync(PagedRequest pagedRequest, CancellationToken cancellationToken);
        Task<PagedResponse<List<TModel>>> GetAllAsync(CancellationToken cancellationToken);
        Task<BaseResponse<TModel>> GetByIdAsync(long id, CancellationToken cancellationToken);
        Task<BaseResponse<TModel>> CreateAsync(TModel model, CancellationToken cancellationToken);
        Task<BaseResponse<TModel>> UpdateAsync(TModel model, CancellationToken cancellationToken);
        Task DeleteAsync(long id, CancellationToken cancellationToken);
        Task DeleteAsync(TModel model, CancellationToken cancellationToken);
    }
}
