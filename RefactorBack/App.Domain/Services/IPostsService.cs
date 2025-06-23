using App.Domain.ViewModel.Request;
using App.Domain.ViewModel.Response;
using App.Domain.ViewModel.Response.Address;
using App.Domain.ViewModel.Request.Address;

namespace App.Domain.Services;

public interface IPostsService
{
    Task<BaseResponse<AddressResponse>> CreatePost(CreateAddressRequest request, CancellationToken cancellationToken);
    Task<PagedResponse<List<AddressResponse>>> GetAllPosts(PagedRequest request, CancellationToken cancellationToken);
    Task<BaseResponse<AddressResponse>> GetPostById(Guid Id, CancellationToken cancellationToken);
    Task<BaseResponse<bool>> UpdatePost(UpdateAddressRequest addressInfo, CancellationToken cancellationToken);
    Task<BaseResponse<bool>> DeletePost(Guid Id, CancellationToken cancellationToken);
}
