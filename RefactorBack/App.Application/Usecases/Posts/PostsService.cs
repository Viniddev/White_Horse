using App.Domain.Services;
using App.Domain.ViewModel.Request;
using App.Domain.ViewModel.Request.Address;
using App.Domain.ViewModel.Response;
using App.Domain.ViewModel.Response.Address;

namespace App.Application.Usecases.Posts;

internal class PostsService : IPostsService
{
    public Task<BaseResponse<AddressResponse>> CreatePost(CreateAddressRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<bool>> DeletePost(Guid Id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<List<AddressResponse>>> GetAllPosts(PagedRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<AddressResponse>> GetPostById(Guid Id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<bool>> UpdatePost(UpdateAddressRequest addressInfo, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
