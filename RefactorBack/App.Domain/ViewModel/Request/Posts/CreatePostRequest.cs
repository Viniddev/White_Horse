namespace App.Domain.ViewModel.Request.Posts;

public class CreatePostRequest
{
    public Guid CreatorId { get; private set; }
    public string Content { get; private set; } = string.Empty;
    public string Topic { get; private set; } = string.Empty;
}
