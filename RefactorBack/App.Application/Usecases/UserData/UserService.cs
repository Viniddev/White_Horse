using App.Domain.Entities;
using App.Domain.Repository;
using App.Domain.Repository.Base;
using App.Domain.Services;
using App.Domain.ViewModel.Request;
using App.Domain.ViewModel.Request.UserInfo;
using App.Domain.ViewModel.Response;
using App.Domain.ViewModel.Response.UserInfo;

namespace App.Application.Usecases.UserData;

public class UserService(
    IUserInformationsRepository _userRepository,
    IUnitOfWork _unitOfWork
) : IUserService
{
    public async Task<BaseResponse<bool>> DeleteUserService(Guid Id, CancellationToken cancellationToken)
    {
        var response = await _userRepository.DeleteAsync(Id, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return response is not null
            ? new BaseResponse<bool>(true, 200, "Usuario deletado com sucesso")
            : new BaseResponse<bool>(false, 404, "Usuario nao encontrado no sistema");
    }

    public async Task<BaseResponse<bool>> UpdateUserService(UpdateUserInformations userInfo, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(userInfo.Id, cancellationToken);

        if (user is not null) 
        {
            user.CopyValuesFrom(userInfo);
            var result = _userRepository.UpdateAsync(user, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new BaseResponse<bool>(true, 200, "Usuario atualizado com sucesso");
        }

        return new BaseResponse<bool>(false, 404, "Usuario nao encontrado no sistema");
    }

    public async Task<PagedResponse<List<UserInformationResponse>>> GetAllUsersService(PagedRequest request, CancellationToken cancellationToken)
    {
        var response = await _userRepository.GetAllAsync(cancellationToken) ?? [];

        if (response.Count > 0)
        {
            var listUsersResponse = response.Select(x => new UserInformationResponse(x)).ToList();
            return new PagedResponse<List<UserInformationResponse>>(listUsersResponse, listUsersResponse.Count, listUsersResponse.Count, request.PageNumber);
        }
        
        return new PagedResponse<List<UserInformationResponse>>(null, 0, 0, 1);
    }

    public async Task<BaseResponse<UserInformationResponse>> GetUserByIdService(Guid Id, CancellationToken cancellationToken)
    {
        var response = await _userRepository.GetByIdAsync(Id, cancellationToken);

        return response is not null 
            ? new BaseResponse<UserInformationResponse>(new UserInformationResponse(response), 200, "Usuario encontrado com sucesso")
            : new BaseResponse<UserInformationResponse>(null, 404, "Usuario nao encontrado no sistema");
    }

    public async Task<BaseResponse<UserInformationResponse>> GetUserByEmailService(GetProfileInfo email, CancellationToken cancellationToken)
    {
        var response = await _userRepository.GetUserProfileInformationsRepository(email, cancellationToken);

        return response is not null
           ? new BaseResponse<UserInformationResponse>(new UserInformationResponse(response), 200, "Usuario encontrado com sucesso")
           : new BaseResponse<UserInformationResponse>(null, 404, "Usuario nao encontrado no sistema");
    }
}
