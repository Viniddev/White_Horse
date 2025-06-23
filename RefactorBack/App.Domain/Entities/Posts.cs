using App.Domain.Abstractions;

namespace App.Domain.Entities;

public class Posts: MediaBase
{
    public Guid CreatorId { get; private set; }
    public virtual UserInformations User { get; private set; } = null!;

    public string Content { get; private set; } = string.Empty;
    public string Topic { get; private set; } = string.Empty;
}
