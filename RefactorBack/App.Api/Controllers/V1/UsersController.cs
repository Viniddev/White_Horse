using App.Domain.Services;
using App.Domain.ViewModel.Request;
using App.Domain.ViewModel.Request.UserInfo;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers.V1;

public static class UsersController
{
    public static void MapUsersEndpoints(this IEndpointRouteBuilder map) 
    {
        var group = map.MapGroup("api/v1/users/").RequireAuthorization();

        group.MapPut("get-all", GetAll);
        group.MapGet("get-by-id/{Id}", GetById);
        group.MapPut("update", UpdateInformations);
        group.MapDelete("delete/{Id}", Delete);
    }

    public static async Task<IResult> GetAll(
        [FromBody] PagedRequest request, 
        [FromServices] IUserService _userService, 
        CancellationToken cancellationToken
    ) 
    {
        var response = await _userService.GetAllUsersService(request, cancellationToken);

        return response.Data is not null
            ? Results.Ok(response)
            : Results.BadRequest(response);
    }

    public static async Task<IResult> GetById(
        [FromRoute] Guid Id, 
        [FromServices] IUserService _userService,
        CancellationToken cancellationToken
    )
    {
        var response = await _userService.GetUserByIdService(Id, cancellationToken);

        return response.Data is not null
            ? Results.Ok(response)
            : Results.BadRequest(response);
    }

    public static async Task<IResult> UpdateInformations(
        [FromBody] RegisterInformation request,
        [FromServices] IUserService _userService,
        CancellationToken cancellationToken
    )
    {
        var response = await _userService.UpdateUserService(request, cancellationToken);

        return response.Data
            ? Results.Ok(response)
            : Results.BadRequest(response);
    }

    public static async Task<IResult> Delete(
        [FromRoute] Guid Id,
        [FromServices] IUserService _userService,
        CancellationToken cancellationToken
    )
    {
        var response = await _userService.DeleteUserService(Id, cancellationToken);

        return response.Data
            ? Results.Ok(response)
            : Results.BadRequest(response);
    }
}
