using App.Domain.ViewModel.Request.UserInfo;
using App.Domain.ViewModel.Response.UserInfo;
using App.Domain.ViewModel.Response;
using App.Domain.ViewModel.Request;

namespace App.Domain.Services;

public interface IUserService
{
    Task<PagedResponse<List<UserInformationResponse>>> GetAllUsersService(PagedRequest request, CancellationToken cancellationToken);
    Task<BaseResponse<UserInformationResponse>> GetUserByIdService(Guid Id, CancellationToken cancellationToken);
    Task<BaseResponse<UserInformationResponse>> GetUserByEmailService(GetProfileInfo email, CancellationToken cancellationToken);
    Task<BaseResponse<bool>> UpdateUserService(RegisterInformation userInfo, CancellationToken cancellationToken);
    Task<BaseResponse<bool>> DeleteUserService(Guid Id, CancellationToken cancellationToken);
}