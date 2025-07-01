using App.Application.Usecases.Authentication;
using Microsoft.Extensions.DependencyInjection;
using App.Domain.Services;
using App.Application.Usecases.UserData;
using App.Domain.Services.Base;
using App.Application.Usecases.Address;
using App.Application.Usecases.PostsService;
using App.Application.Usecases.ResponsesService;

namespace App.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service) 
    {
        service.AddTransient<IAuthenticationService, AuthenticationService>();
        service.AddTransient<IUserService, UserService>();
        service.AddTransient<IUserAddressService, UserAddressService>();
        service.AddTransient<IPostsService, PostsService>();
        service.AddTransient<IResponsesService, ResponsesService>();

        return service;
    }
}
