using App.Domain.Entities;

namespace App.Domain.ViewModel.Response.PostsResponses;

public class PostInformationsResponse
{
    public Guid CreatorId { get; set; }
    public string Content { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
    public long Likes { get; set; }
    public long Deslikes { get; set; }

    public PostInformationsResponse() { }

    public PostInformationsResponse(Posts post)
    {
        CreatorId = post.CreatorId;
        Content = post.Content;
        Topic = post.Topic;
        Likes = post.Likes;
        Deslikes = post.Deslikes;
    }
}
