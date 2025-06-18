using App.Domain.ViewModel.Request.UserInfo;
using App.Domain.ViewModel.Response;
using App.Domain.ViewModel.Response.UserInfo;

namespace App.Domain.Services.Base;

public interface IAuthenticationService
{
    Task<BaseResponse<LoginResponse>> LoginServiceAsync(LoginInformations login, CancellationToken cancellationToken);
    Task<BaseResponse<RegisterInformation>> CreateUserServiceAsync(RegisterInformation request, CancellationToken cancellationToken);
}