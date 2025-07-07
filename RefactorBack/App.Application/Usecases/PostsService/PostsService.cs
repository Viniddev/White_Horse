using App.Domain.Entities;
using App.Domain.Repository;
using App.Domain.Repository.Base;
using App.Domain.Services;
using App.Domain.ViewModel.Request;
using App.Domain.ViewModel.Request.PostsRequests;
using App.Domain.ViewModel.Response;
using App.Domain.ViewModel.Response.PostsResponses;

namespace App.Application.Usecases.PostsService;

public class PostsService(IPostsRepository _postRepository, IUnitOfWork _unitOfWork) : IPostsService
{
    public async Task<BaseResponse<PostInformationsResponse>> CreatePost(CreatePostRequest request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.CreateAsync(new Posts(request), cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return post is not null
            ? new BaseResponse<PostInformationsResponse>(new PostInformationsResponse(post), 201, "Success.")
            : new BaseResponse<PostInformationsResponse>(null, 500, "Erro inesperado ao salvar a entidade no banco.");
    }

    public async Task<BaseResponse<bool>> DeletePost(Guid Id, CancellationToken cancellationToken)
    {
        var response = await _postRepository.DeleteAsync(Id, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return response is not null
           ? new BaseResponse<bool>(true, 200, "Post deletado com sucesso")
           : new BaseResponse<bool>(false, 404, "Post nao encontrado no sistema");
    }

    public async Task<PagedResponse<List<PostInformationsResponse>>> GetAllPosts(PagedRequest request, CancellationToken cancellationToken)
    {
        var response = await _postRepository.GetAllAsync(cancellationToken) ?? [];

        if (response.Count > 0)
        {
            var listUsersResponse = response.Select(x => new PostInformationsResponse(x)).ToList();
            return new PagedResponse<List<PostInformationsResponse>>(listUsersResponse, listUsersResponse.Count, listUsersResponse.Count, request.PageNumber);
        }

        return new PagedResponse<List<PostInformationsResponse>>(null, 0, 0, 1);
    }

    public async Task<BaseResponse<PostInformationsResponse>> GetPostById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await _postRepository.GetByIdAsync(Id, cancellationToken);

        return response is not null
            ? new BaseResponse<PostInformationsResponse>(new PostInformationsResponse(response), 200, "Post encontrado com sucesso")
            : new BaseResponse<PostInformationsResponse>(null, 404, "Post nao encontrado no sistema");
    }

    public async Task<BaseResponse<bool>> UpdatePost(UpdatePostRequest postInfo, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(postInfo.PostId, cancellationToken);

        if (post is not null) 
        {
            post.CopyValuesFrom(postInfo);
            _postRepository.UpdateAsync(post, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new BaseResponse<bool>(true, 200, "Post atualizado com sucesso");
        }

        return new BaseResponse<bool>(false, 404, "Post nao encontrado no sistema");
    }
}
