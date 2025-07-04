using App.Application.Helpers;
using App.Domain.Entities;
using App.Domain.Repository;
using App.Domain.Repository.Base;
using App.Domain.Services.Base;
using App.Domain.ViewModel.Request.UserInfo;
using App.Domain.ViewModel.Response;
using App.Domain.ViewModel.Response.UserInfo;
using Microsoft.Extensions.Configuration;

namespace App.Application.Usecases.Authentication;

public class AuthenticationService(
    IUserInformationsRepository _userInfoRepository,
    IUserAddressRepository _userAddressRepository,
    IUnitOfWork _unitOfWork,
    IConfiguration _configuration
) : IAuthenticationService
{
    public async Task<BaseResponse<LoginResponse>> LoginServiceAsync(LoginInformations login, CancellationToken cancellationToken)
    {
        var result = await _userInfoRepository.GetAllAsync(cancellationToken);
        var user = result?.FirstOrDefault(u => u.Email == login.Email && PasswordHash.Verify(u.Password, login.Password));

        if (user is null)
            return new BaseResponse<LoginResponse>(null, 404, "Usuário não encontrado ou senha incorreta.");

        var token = TokenService.GenerateToken(user, _configuration);
        var response = new LoginResponse(token, user.Name ,user.Email);

        return new BaseResponse<LoginResponse>(response, 200, "Success.");
    }

    public async Task<BaseResponse<RegisterInformation>> CreateUserServiceAsync(RegisterInformation request, CancellationToken cancellationToken)
    {
        var ListaUsers = await _userInfoRepository.GetAllAsync(cancellationToken) ?? [];

        if (ListaUsers.Count > 0)
        {
            var Register = ListaUsers.FirstOrDefault(u => u.Cpf.Equals(request.Cpf) || u.Email.Equals(request.Email));

            if (Register is not null)
                return new BaseResponse<RegisterInformation>(null, 500, "Usuario ja cadastrado no sistema");
        }

        //cria o endereco e commita
        UserAddress address = new(request.Address);
        await _userAddressRepository.CreateAsync(address);
        await _unitOfWork.CommitAsync();

        //criptografa senha e passa o id do endereço criado pro usuario
        request.Password = PasswordHash.Hash(request.Password);
        UserInformations NewUser = new(request, address.Id);

        //cria o usuário
        await _userInfoRepository.CreateAsync(NewUser, cancellationToken);
        
        //commita e retorna
        await _unitOfWork.CommitAsync();
        return new BaseResponse<RegisterInformation>(request, 201, "Success."); ;
    }
}
