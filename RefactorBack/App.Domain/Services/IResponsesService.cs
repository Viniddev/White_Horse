using App.Domain.ViewModel.Request;
using App.Domain.ViewModel.Response;
using App.Domain.ViewModel.Request.Responses;
using App.Domain.ViewModel.Response.PostResponse;

namespace App.Domain.Services;

public interface IResponsesService
{
    Task<BaseResponse<PostRequestResponse>> RespondPost(CreateResponseRequest request, CancellationToken cancellationToken);
    Task<PagedResponse<List<PostRequestResponse>>> GetAllResponses(PagedRequest request, CancellationToken cancellationToken);
    Task<BaseResponse<PostRequestResponse>> GetResponseById(Guid Id, CancellationToken cancellationToken);
    Task<BaseResponse<bool>> UpdateResponse(CreateResponseRequest addressInfo, CancellationToken cancellationToken);
    Task<BaseResponse<bool>> DeleteResponse(Guid Id, CancellationToken cancellationToken);
}
