using App.Domain.Services.Base;
using App.Domain.ViewModel.Request.UserInfo;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers.V1;

public static class AuthenticationController
{
    public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder map)
    {
        var group = map.MapGroup("api/v1/");

        group.MapPost("login", LoginAsync);
        group.MapPost("create-user", RegisterAsync);
    }

    public static async Task<IResult> RegisterAsync(
        [FromServices] IAuthenticationService _userService,
        [FromBody] RegisterInformation registryInformation,
        CancellationToken cancellationToken
    )
    {
        var result = await _userService.CreateUserServiceAsync(registryInformation, cancellationToken);
        
        return result.Data is not null
            ? Results.Ok(result)
            : Results.BadRequest(result);
    }

    public static async Task<IResult> LoginAsync(
        [FromServices] IAuthenticationService _userService,
        [FromBody] LoginInformations login,
        CancellationToken cancellationToken
    ) 
    {
        var result = await _userService.LoginServiceAsync(login, cancellationToken);

        return result.Data is not null
            ? Results.Ok(result)
            : Results.BadRequest(result);
    }
}
