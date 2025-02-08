using White_Horse_Inc_Api.Data.RepositoryMethods;
using White_Horse_Inc_Core.Response.Authentication;
using White_Horse_Inc_Core.Requests.Authentication;
using White_Horse_Inc_Api.Implementations.Repository.Interfaces;
using White_Horse_Inc_Core.Models;
using White_Horse_Inc_Core.Response;

namespace White_Horse_Inc_Api.Implementations.Services
{
    public class AuthenticationService(IUserInformationsRepository userInformationsRepository, IUserAddressRepository userAddressRepository, IConfiguration configuration) : IAuthenticationService
    {
        public async Task<BaseResponse<LoginResponse>> LoginService(Login loginInformations, CancellationToken cancellationToken)
        {
            var ListUsers = await userInformationsRepository.GetAllAsync(cancellationToken);

            if (ListUsers.TotalCount == 0)
                return new BaseResponse<LoginResponse>(null, 404, "There are no users in the database.");

            var User = ListUsers.Data?.FirstOrDefault(u => u.Email == loginInformations.Email && BCrypt.Net.BCrypt.Verify(loginInformations.Password, u.Password));

            if (User is null)
                return new BaseResponse<LoginResponse>(null, 404, "User or password incorrect.");

            TokenService tokenService = new TokenService();
            var token = tokenService.GenerateToken(User, configuration);

            var NewLogin = new LoginResponse()
            {
                Token = token,
                UserName = User.Name,
                Email = User.Email,
            };

            return new BaseResponse<LoginResponse>(NewLogin, 200, "Success.");
        }

        public async Task<BaseResponse<UserInformations>> RegisterService(RegisterInformation registryInformation, CancellationToken cancellationToken)
        {
            var ListUsers = await userInformationsRepository.GetAllAsync(cancellationToken);

            //criptografia da senha
            string senhaHash = BCrypt.Net.BCrypt.HashPassword(registryInformation.Password);

            if (ListUsers.TotalCount != 0)
            {
                var User = ListUsers.Data?
                    .FirstOrDefault(u => u.Email == registryInformation.Email && u.Cpf == registryInformation.Cpf);

                if (User is not null)
                    throw new ArgumentException("This user has already been registered in the system.");
            }

            UserAddress newAddress = new()
            {
                Cep = registryInformation.Cep,
                City = registryInformation.City,
                Neighborhood = registryInformation.Neighborhood,
                Street = registryInformation.Street,
                Number = registryInformation.Number,
            };

            var NovoEnderecoCriado = await userAddressRepository.CreateAsync(newAddress, cancellationToken);

            if (NovoEnderecoCriado.Data?.Id == null)
            {
                throw new ArgumentException("Couldn't create the address.");
            }

            UserInformations userInformations = new UserInformations()
            {
                Cpf = registryInformation.Cpf,
                Name = registryInformation.Name,
                Email = registryInformation.Email,
                Password = senhaHash,
                Rg = registryInformation.Rg,
                PhoneNumber = registryInformation.PhoneNumber,
                CompanyRoleId = registryInformation.CompanyRoleId,
                AddressId = NovoEnderecoCriado.Data.Id,
            };

            var usuarioNovo = await userInformationsRepository.CreateAsync(userInformations, cancellationToken);

            return usuarioNovo;
        }
    }
}
