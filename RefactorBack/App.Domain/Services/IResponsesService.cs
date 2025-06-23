using App.Domain.ViewModel.Request;
using App.Domain.ViewModel.Response;
using App.Domain.ViewModel.Response.Address;
using App.Domain.ViewModel.Request.Address;

namespace App.Domain.Services;

public interface IResponsesService
{
    Task<BaseResponse<AddressResponse>> RespondPost(CreateAddressRequest request, CancellationToken cancellationToken);
    Task<PagedResponse<List<AddressResponse>>> GetAllResponses(PagedRequest request, CancellationToken cancellationToken);
    Task<BaseResponse<AddressResponse>> GetResponseById(Guid Id, CancellationToken cancellationToken);
    Task<BaseResponse<bool>> UpdateResponse(UpdateAddressRequest addressInfo, CancellationToken cancellationToken);
    Task<BaseResponse<bool>> DeleteResponse(Guid Id, CancellationToken cancellationToken);
}
