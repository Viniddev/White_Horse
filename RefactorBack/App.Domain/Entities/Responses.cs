using App.Domain.Abstractions;

namespace App.Domain.Entities;

public class Responses: MediaBase
{
    public Guid CreatorId { get; private set; }
    public virtual UserInformations User { get; private set; } = null!;

    public Guid PostId { get; private set; }
    public virtual Posts Post { get; private set; } = null!;

    public string Message { get; private set; } = string.Empty;
}
