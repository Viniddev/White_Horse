using App.Domain.Services;
using App.Domain.ViewModel.Request;
using App.Domain.ViewModel.Request.Address;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers.V1;

public static class ResponsesController
{
    public static void MapResponsesEndpoints(this IEndpointRouteBuilder map) 
    {
        var group = map.MapGroup("api/v1/responses/").RequireAuthorization();

        group.MapPut("get-all", GetAll);
        group.MapGet("get-by-id/{Id}", GetById);
        group.MapPost("create", CreatePost);
        group.MapPut("update", UpdateInformations);
        group.MapDelete("delete/{Id}", Delete);
    }

    public static async Task<IResult> GetAll(
        [FromBody] PagedRequest request, 
        [FromServices] IResponsesService _responsesService, 
        CancellationToken cancellationToken
    ) 
    {
        var response = await _responsesService.GetAllResponses(request, cancellationToken);

        return response.Data is not null
            ? Results.Ok(response)
            : Results.BadRequest(response);
    }

    public static async Task<IResult> GetById(
        [FromRoute] Guid Id,
        [FromServices] IResponsesService _responsesService,
        CancellationToken cancellationToken
    )
    {
        var response = await _responsesService.GetResponseById(Id, cancellationToken);

        return response.Data is not null
            ? Results.Ok(response)
            : Results.BadRequest(response);
    }

    public static async Task<IResult> CreatePost(
       [FromBody] CreateAddressRequest request,
       [FromServices] IResponsesService _responsesService,
       CancellationToken cancellationToken
   )
    {
        var response = await _responsesService.RespondPost(request, cancellationToken);

        return response.Data is not null
            ? Results.Ok(response)
            : Results.BadRequest(response);
    }

    public static async Task<IResult> UpdateInformations(
        [FromBody] UpdateAddressRequest request,
        [FromServices] IResponsesService _responsesService,
        CancellationToken cancellationToken
    )
    {
        var response = await _responsesService.UpdateResponse(request, cancellationToken);

        return response.Data
            ? Results.Ok(response)
            : Results.BadRequest(response);
    }

    public static async Task<IResult> Delete(
        [FromRoute] Guid Id,
        [FromServices] IResponsesService _responsesService,
        CancellationToken cancellationToken
    )
    {
        var response = await _responsesService.DeleteResponse(Id, cancellationToken);

        return response.Data
            ? Results.Ok(response)
            : Results.BadRequest(response);
    }
}
