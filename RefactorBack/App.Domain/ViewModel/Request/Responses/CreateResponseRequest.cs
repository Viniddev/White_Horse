namespace App.Domain.ViewModel.Request.Responses;

public class CreateResponseRequest
{
    public Guid CreatorId { get; private set; }
    public Guid PostId { get; private set; }
    public string Message { get; private set; } = string.Empty;
}
