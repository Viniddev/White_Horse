using White_Horse_Inc_Core.Models;
using White_Horse_Inc_Core.Requests.Authentication;
using White_Horse_Inc_Core.Response;
using White_Horse_Inc_Core.Response.Authentication;

namespace White_Horse_Inc_Api.Implementations.Services
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> LoginService(Login loginInformations, CancellationToken cancellationToken);
        Task<BaseResponse<UserInformations>> RegisterService(RegisterInformation registryInformation, CancellationToken cancellationToken);
    }
}
