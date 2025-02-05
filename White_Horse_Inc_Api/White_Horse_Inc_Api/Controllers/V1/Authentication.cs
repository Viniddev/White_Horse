using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using White_Horse_Inc_Api.Data;
using White_Horse_Inc_Api.Data.RepositoryMethods;
using White_Horse_Inc_Api.Implementations.Interfaces;
using White_Horse_Inc_Core.Models;
using White_Horse_Inc_Core.Requests.Authentication;
using White_Horse_Inc_Core.Response;
using White_Horse_Inc_Core.Response.Authentication;

namespace White_Horse_Inc_Api.Controllers.V1
{
    [ApiController]
    [Route("V1")]
    public class Authentication(IUserInformationsRepository userInformationsRepository, IConfiguration configuration) : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] Login loginInformations, CancellationToken cancellationToken)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var ListUsers = await userInformationsRepository.GetAllAsync(cancellationToken);

            if (ListUsers.TotalCount == 0)
                return BadRequest(new BaseResponse<UserInformations?>(null, 500, "There are no users in the database."));

            var User = ListUsers.Data?.First(u => u.Email == loginInformations.Email && u.Password == loginInformations.Password);

            if (User is null)
                return BadRequest(new BaseResponse<UserInformations?>(null, 500, "Couldn't find any item or a bad request happened."));

            TokenService tokenService = new TokenService();
            var token = tokenService.GenerateToken(User, configuration);

            return Ok(new LoginResponse() 
            {
                Token = token,
                UserName = User.Name
            });
        }
    }
}
