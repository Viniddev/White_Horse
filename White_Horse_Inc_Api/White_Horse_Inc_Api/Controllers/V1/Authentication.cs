using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using White_Horse_Inc_Api.Data;
using White_Horse_Inc_Api.Data.RepositoryMethods;
using White_Horse_Inc_Core.Models;
using White_Horse_Inc_Core.Requests.Authentication;

namespace White_Horse_Inc_Api.Controllers.V1
{
    [ApiController]
    [Route("v1")]
    public class Authentication : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromServices] AppDbContext context, [FromBody] Login loginInformations)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var userInDatabase = context.GetDbSet<UserInformations>()
                .AsNoTracking().FirstOrDefault(x => x.Email == loginInformations.Email && x.Password == loginInformations.Password);

            if (userInDatabase == null)
                return NotFound("não existe o usuário no banco de dados, camarada");

            TokenService tokenService = new TokenService();
            var token = tokenService.GenerateToken(userInDatabase);

            return Ok(
                new
                {
                    User = userInDatabase,
                    Token = token
                }
            );
        }
    }
}
