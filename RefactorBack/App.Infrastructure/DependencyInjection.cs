using App.Domain.Repository;
using App.Domain.Repository.Base;
using App.Domain.Services;
using App.Infrastructure.Repository;
using App.Infrastructure.Repository.Base;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service) 
    {
        service.AddTransient<IUnitOfWork, UnitOfWork>();
        service.AddTransient<IUserInformationsRepository, UserInformationsRepository>();
        service.AddTransient<IUserAddressRepository, UserAddressRepository>();
        service.AddTransient<IPostsRepository, PostsRepository>();

        return service;
    }
}
