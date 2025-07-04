using App.Domain.ViewModel.Request;
using App.Domain.ViewModel.Response;
using App.Domain.ViewModel.Response.Address;
using App.Domain.ViewModel.Request.Address;

namespace App.Domain.Services;

public interface IUserAddressService
{
    Task<BaseResponse<AddressResponse>> CreateAddress(CreateAddressRequest request, CancellationToken cancellationToken);
    Task<PagedResponse<List<AddressResponse>>> GetAllAddresses(PagedRequest request, CancellationToken cancellationToken);
    Task<BaseResponse<AddressResponse>> GetAddressById(Guid Id, CancellationToken cancellationToken);
    Task<BaseResponse<bool>> DeleteAddress(Guid Id, CancellationToken cancellationToken);
}
