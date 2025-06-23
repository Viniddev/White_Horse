using App.Domain.Services;
using App.Domain.ViewModel.Request;
using App.Domain.ViewModel.Request.Address;
using App.Domain.ViewModel.Response;
using App.Domain.ViewModel.Response.Address;

namespace App.Application.Usecases.Responses;

public class ResponsesService : IResponsesService
{
    public Task<BaseResponse<bool>> DeleteResponse(Guid Id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResponse<List<AddressResponse>>> GetAllResponses(PagedRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<AddressResponse>> GetResponseById(Guid Id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<AddressResponse>> RespondPost(CreateAddressRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<bool>> UpdateResponse(UpdateAddressRequest addressInfo, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
