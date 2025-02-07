using Microsoft.AspNetCore.Mvc;
using White_Horse_Inc_Api.Implementations.Services;
using White_Horse_Inc_Core.Models;
using White_Horse_Inc_Core.Requests.Authentication;
using White_Horse_Inc_Core.Response;
using White_Horse_Inc_Core.Response.Authentication;

namespace White_Horse_Inc_Api.Controllers.V1
{
    [ApiController]
    [Route("V1")]
    public class Authentication(IAuthenticationService _authenticationService) : ControllerBase
    {
        [HttpPut]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] Login loginInformations, CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new BaseResponse<UserInformations?>(null, 500, "Parameters not valid."));

                BaseResponse<LoginResponse> retorno = await _authenticationService.LoginService(loginInformations, cancellationToken);

                return Ok(retorno);
            }
            catch (Exception ex) 
            {
                return BadRequest(new BaseResponse<LoginResponse?>(null, 500, ex.Message));
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterInformation registryInformation, CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new BaseResponse<UserInformations?>(null, 500, "Parameters not valid."));

                BaseResponse<UserInformations> usuarioNovo = await _authenticationService.RegisterService(registryInformation, cancellationToken);

                return Ok(usuarioNovo);
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse<UserInformations?>(null, 500, ex.Message));
            }
        }
    }
}
