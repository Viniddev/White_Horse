using App.Domain.Services;
using App.Domain.ViewModel.Request;
using App.Domain.ViewModel.Request.PostsRequests;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers.V1;

public static class PostsController
{
    public static void MapPostsEndpoints(this IEndpointRouteBuilder map) 
    {
        var group = map.MapGroup("api/v1/posts/").RequireAuthorization();

        group.MapPut("get-all", GetAll);
        group.MapGet("get-by-id/{Id}", GetById);
        group.MapPost("create", CreatePost);
        group.MapPut("update", UpdateInformations);
        group.MapDelete("delete/{Id}", Delete);
    }

    public static async Task<IResult> GetAll(
        [FromBody] PagedRequest request, 
        [FromServices] IPostsService _postsService, 
        CancellationToken cancellationToken
    ) 
    {
        var response = await _postsService.GetAllPosts(request, cancellationToken);

        return response.Data is not null
            ? Results.Ok(response)
            : Results.BadRequest(response);
    }

    public static async Task<IResult> GetById(
        [FromRoute] Guid Id,
        [FromServices] IPostsService _postsService,
        CancellationToken cancellationToken
    )
    {
        var response = await _postsService.GetPostById(Id, cancellationToken);

        return response.Data is not null
            ? Results.Ok(response)
            : Results.BadRequest(response);
    }

    public static async Task<IResult> CreatePost(
       [FromBody] CreatePostRequest request,
       [FromServices] IPostsService _postsService,
       CancellationToken cancellationToken
    )
    {
        var response = await _postsService.CreatePost(request, cancellationToken);

        return response.Data is not null
            ? Results.Ok(response)
            : Results.BadRequest(response);
    }

    public static async Task<IResult> UpdateInformations(
        [FromBody] CreatePostRequest request,
        [FromServices] IPostsService _postsService,
        CancellationToken cancellationToken
    )
    {
        var response = await _postsService.UpdatePost(request, cancellationToken);

        return response.Data
            ? Results.Ok(response)
            : Results.BadRequest(response);
    }

    public static async Task<IResult> Delete(
        [FromRoute] Guid Id,
        [FromServices] IPostsService _postsService,
        CancellationToken cancellationToken
    )
    {
        var response = await _postsService.DeletePost(Id, cancellationToken);

        return response.Data
            ? Results.Ok(response)
            : Results.BadRequest(response);
    }
}
