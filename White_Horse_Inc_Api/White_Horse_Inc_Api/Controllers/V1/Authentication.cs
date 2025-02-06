using Microsoft.AspNetCore.Mvc;
using White_Horse_Inc_Api.Data.RepositoryMethods;
using White_Horse_Inc_Api.Implementations.Interfaces;
using White_Horse_Inc_Api.Implementations.Repositories;
using White_Horse_Inc_Core.Models;
using White_Horse_Inc_Core.Requests.Authentication;
using White_Horse_Inc_Core.Response;
using White_Horse_Inc_Core.Response.Authentication;

namespace White_Horse_Inc_Api.Controllers.V1
{
    [ApiController]
    [Route("V1")]
    public class Authentication(IUserInformationsRepository userInformationsRepository, IUserAddressRepository userAddressRepository, IConfiguration configuration) : ControllerBase
    {
        [HttpPut]
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

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterInformation loginInformations, CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var ListUsers = await userInformationsRepository.GetAllAsync(cancellationToken);

                if (ListUsers.TotalCount != 0) 
                {
                    var User = ListUsers.Data?.First(u => u.Email == loginInformations.Email && u.Password == loginInformations.Password);

                    if (User is not null)
                        return BadRequest(new BaseResponse<UserInformations?>(null, 500, "This user has already been registered in the system."));
                }

                UserAddress newAddress = new()
                {
                    Cep = loginInformations.Cep,
                    City = loginInformations.City,
                    Neighborhood = loginInformations.Neighborhood,
                    Street = loginInformations.Street,
                    Number = loginInformations.Number,
                };

                var NovoEnderecoCriado = await userAddressRepository.CreateAsync(newAddress, cancellationToken);

                UserInformations userInformations = new UserInformations()
                {
                    Cpf = loginInformations.Cpf,
                    Name = loginInformations.Name,
                    Email = loginInformations.Email,
                    Password = loginInformations.Password,
                    Rg = loginInformations.Rg,
                    PhoneNumber = loginInformations.PhoneNumber,
                    CompanyRoleId = loginInformations.CompanyRoleId,
                    AddressId = NovoEnderecoCriado.Data.Id,
                };

                var usuarioNovo = await userInformationsRepository.CreateAsync(userInformations, cancellationToken);

                return Ok(usuarioNovo);
            }
            catch 
            {
                return BadRequest(new BaseResponse<UserInformations?>(null, 400, "Inespected error ocurred during the process."));
            }
        }
    }
}
