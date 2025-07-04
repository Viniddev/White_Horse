using App.Domain.Entities;
using App.Domain.Repository;
using App.Domain.Repository.Base;
using App.Domain.Services;
using App.Domain.ViewModel.Request;
using App.Domain.ViewModel.Request.Address;
using App.Domain.ViewModel.Response;
using App.Domain.ViewModel.Response.Address;

namespace App.Application.Usecases.Address;

public class UserAddressService(IUserAddressRepository _addressRepository, IUnitOfWork _unitOfWork) : IUserAddressService
{
    public async Task<BaseResponse<AddressResponse>> CreateAddress(CreateAddressRequest request, CancellationToken cancellationToken)
    {
        var response = await _addressRepository.CreateAsync(new UserAddress(request), cancellationToken);

        return response is not null ?
            new BaseResponse<AddressResponse>(new AddressResponse(response), 201, "Endereço criado com sucesso") :
            new BaseResponse<AddressResponse>(null, 400, "Erro ao criar endereço");
    }

    public async Task<BaseResponse<bool>> DeleteAddress(Guid Id, CancellationToken cancellationToken)
    {
        var response = await _addressRepository.DeleteAsync(Id, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return response is not null
            ? new BaseResponse<bool>(true, 200, "Endereço deletado com sucesso")
            : new BaseResponse<bool>(false, 404, "Endereço nao encontrado no sistema");
    }

    public async Task<PagedResponse<List<AddressResponse>>> GetAllAddresses(PagedRequest request, CancellationToken cancellationToken)
    {
        var response = await _addressRepository.GetAllAsync(cancellationToken) ?? [];

        if (response.Count == 0)
        {
            var listAddressResponse = response.Select(x => new AddressResponse(x)).ToList();
            return new PagedResponse<List<AddressResponse>>(listAddressResponse, listAddressResponse.Count, listAddressResponse.Count, request.PageNumber);
        }

        return new PagedResponse<List<AddressResponse>>(null, 0, 0, 1);
    }

    public async Task<BaseResponse<AddressResponse>> GetAddressById(Guid Id, CancellationToken cancellationToken)
    {
        var response = await _addressRepository.GetByIdAsync(Id, cancellationToken);

        return response is not null
            ? new BaseResponse<AddressResponse>( new AddressResponse(response), 200, "Usuario encontrado com sucesso")
            : new BaseResponse<AddressResponse>(null, 404, "Usuario nao encontrado no sistema");
    }
}
