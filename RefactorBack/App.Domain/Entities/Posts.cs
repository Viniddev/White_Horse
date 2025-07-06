using App.Domain.Abstractions;
using App.Domain.ViewModel.Request.PostsRequests;

namespace App.Domain.Entities;

public class Posts: MediaBase, IAggregateRoot
{

    public Guid CreatorId { get; private set; }
    public virtual UserInformations Creator { get; private set; } = null!;

    public string Content { get; private set; } = string.Empty;
    public string Topic { get; private set; } = string.Empty;

    public Posts() { }

    public Posts(CreatePostRequest createPost) 
    {
        CreatorId = createPost.CreatorId;
        Topic = createPost.Topic;
        Content = createPost.Content;
    }

    public void CopyValuesFrom(UpdatePostRequest values) 
    {
        Content = values.Content;
    }
}
