using App.Domain.Abstractions;
using App.Domain.ViewModel.Request.PostsRequests;

namespace App.Domain.Entities;

public class Posts: MediaBase, IAggregateRoot
{

    public Guid CreatorId { get; private set; }
    public virtual UserInformations? User { get; private set; }

    public string Content { get; private set; } = string.Empty;
    public string Topic { get; private set; } = string.Empty;

    public Posts() { }

    public Posts(CreatePostRequest createPost) 
    {
        CreatorId = createPost.CreatorId;
        Topic = createPost.Topic;
        Content = createPost.Content;
    }
}
