using App.Domain.ViewModel.Request;
using App.Domain.ViewModel.Request.PostsRequests;
using App.Domain.ViewModel.Response;
using App.Domain.ViewModel.Response.PostsResponses;

namespace App.Domain.Services;

public interface IPostsService
{
    Task<BaseResponse<PostInformationsResponse>> CreatePost(CreatePostRequest request, CancellationToken cancellationToken);
    Task<PagedResponse<List<PostInformationsResponse>>> GetAllPosts(PagedRequest request, CancellationToken cancellationToken);
    Task<BaseResponse<PostInformationsResponse>> GetPostById(Guid Id, CancellationToken cancellationToken);
    Task<BaseResponse<bool>> UpdatePost(CreatePostRequest postInfo, CancellationToken cancellationToken);
    Task<BaseResponse<bool>> DeletePost(Guid Id, CancellationToken cancellationToken);
}
