using App.Domain.Services;
using App.Domain.ViewModel.Request;
using App.Domain.ViewModel.Request.Responses;
using App.Domain.ViewModel.Response;
using App.Domain.ViewModel.Response.PostResponse;

namespace App.Application.Usecases.Responses;

public class ResponsesService : IResponsesService
{
    public Task<BaseResponse<bool>> DeleteResponse(Guid Id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<List<PostRequestResponse>>> GetAllResponses(PagedRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<PostRequestResponse>> GetResponseById(Guid Id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<PostRequestResponse>> RespondPost(CreateResponseRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<bool>> UpdateResponse(CreateResponseRequest addressInfo, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
