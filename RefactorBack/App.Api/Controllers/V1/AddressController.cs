using App.Domain.Services;
using App.Domain.ViewModel.Request;
using App.Domain.ViewModel.Request.Address;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers.V1;

public static class AddressController
{
    public static void MapUserAddressEndpoints(this IEndpointRouteBuilder map)
    {
        var group = map.MapGroup("api/v1/user-address").RequireAuthorization();

        group.MapPut("get-all-addresses", GetUserAddressesAsync);
        group.MapGet("get-addresses-by-id/{id}", GetUserAddressById);
        group.MapDelete("delete-user-address/{id}", DeleteUserAddressAsync);
    }

    public static async Task<IResult> GetUserAddressesAsync(
        [FromServices] IUserAddressService _userAddressService,
        [FromBody] PagedRequest request,
        CancellationToken cancellationToken
    )
    {
        var result = await _userAddressService.GetAllAddresses(request, cancellationToken);

        return result.Data is not null 
            ? Results.Ok(result) 
            : Results.NotFound(result);
    }

    public static async Task<IResult> GetUserAddressById(
        [FromServices] IUserAddressService _userAddressService,
        [FromRoute] Guid Id,
        CancellationToken cancellationToken
    )
    {
        var result = await _userAddressService.GetAddressById(Id, cancellationToken);

        return result.Data is not null
            ? Results.Ok(result)
            : Results.NotFound(result);
    }

    public static async Task<IResult> DeleteUserAddressAsync(
        [FromServices] IUserAddressService _userAddressService,
        [FromRoute] Guid id,
        CancellationToken cancellationToken
    )
    {
        if (id == Guid.Empty)
            return Results.BadRequest("Invalid address ID");

        var result = await _userAddressService.DeleteAddress(id, cancellationToken);

        return result.Data 
            ? Results.Ok(result) 
            : Results.NotFound(result);
    }
}
