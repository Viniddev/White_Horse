using App.Domain.Services;
using App.Domain.ViewModel.Request;
using App.Domain.ViewModel.Request.Posts;
using App.Domain.ViewModel.Response;
using App.Domain.ViewModel.Response.Posts;

namespace App.Application.Usecases.Posts;

public class PostsService : IPostsService
{
    public Task<BaseResponse<PostInformationsResponse>> CreatePost(CreatePostRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<bool>> DeletePost(Guid Id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<List<PostInformationsResponse>>> GetAllPosts(PagedRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<PostInformationsResponse>> GetPostById(Guid Id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<bool>> UpdatePost(CreatePostRequest addressInfo, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
