using App.Domain.ViewModel.Request;
using App.Domain.ViewModel.Response;
using App.Domain.ViewModel.Request.Posts;
using App.Domain.ViewModel.Response.Posts;

namespace App.Domain.Services;

public interface IPostsService
{
    Task<BaseResponse<PostInformationsResponse>> CreatePost(CreatePostRequest request, CancellationToken cancellationToken);
    Task<PagedResponse<List<PostInformationsResponse>>> GetAllPosts(PagedRequest request, CancellationToken cancellationToken);
    Task<BaseResponse<PostInformationsResponse>> GetPostById(Guid Id, CancellationToken cancellationToken);
    Task<BaseResponse<bool>> UpdatePost(CreatePostRequest addressInfo, CancellationToken cancellationToken);
    Task<BaseResponse<bool>> DeletePost(Guid Id, CancellationToken cancellationToken);
}
