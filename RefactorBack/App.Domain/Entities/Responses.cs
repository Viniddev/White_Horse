using App.Domain.Abstractions;
using App.Domain.ViewModel.Request.ResponsesFromPosts;

namespace App.Domain.Entities;

public class Responses: MediaBase, IAggregateRoot
{
    public Guid CreatorId { get; private set; }
    public virtual UserInformations Creator { get; private set; } = null!;
    public Guid PostId { get; private set; }
    public virtual Posts Post { get; private set; } = null!;
    public string Message { get; private set; } = string.Empty;

    public Responses() { }

    public Responses(CreateResponseRequest response)
    {
        CreatorId = response.CreatorId;
        PostId = response.PostId;
        Message = response.Message;
    }
}
