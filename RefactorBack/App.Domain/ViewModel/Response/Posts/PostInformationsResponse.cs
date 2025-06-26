namespace App.Domain.ViewModel.Response.Posts;

public class PostInformationsResponse
{
    public Guid CreatorId { get; set; }
    public string Content { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
    public long Likes { get; set; }
    public long Deslikes { get; set; }
}
