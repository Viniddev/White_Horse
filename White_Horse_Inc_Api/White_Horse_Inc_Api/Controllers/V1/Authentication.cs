using Microsoft.AspNetCore.Mvc;
using White_Horse_Inc_Api.Implementations.Services;
using White_Horse_Inc_Core.Models;
using White_Horse_Inc_Core.ModelTransform;
using White_Horse_Inc_Core.Requests.Authentication;
using White_Horse_Inc_Core.Response;
using White_Horse_Inc_Core.Response.Authentication;
using White_Horse_Inc_Core.Response.Dtos;

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

                if (retorno.Data is not null)
                    return Ok(retorno);
                else
                    return BadRequest(retorno);
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

                var usuarioNovo = await _authenticationService.RegisterService(registryInformation, cancellationToken);

                if (usuarioNovo.Data is null)
                    return BadRequest("Erro ao registrar usuário.");

                return Ok(new BaseResponse<UserInformationResponse>
                {
                    Data = ModelTransform.TransformUserInformation(usuarioNovo.Data),
                    Message = usuarioNovo.Message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse<UserInformations?>(null, 500, ex.Message));
            }
        }
    }
}
