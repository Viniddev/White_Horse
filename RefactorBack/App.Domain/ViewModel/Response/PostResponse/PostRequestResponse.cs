namespace App.Domain.ViewModel.Response.PostResponse;

public class PostRequestResponse
{
    public Guid CreatorId { get; set; }
    public Guid PostId { get; set; }
    public string Message { get; set; } = string.Empty;
    public long Likes { get; set; }
    public long Deslikes { get; set; }
}
