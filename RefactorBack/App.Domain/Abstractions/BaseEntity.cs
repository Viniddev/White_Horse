namespace App.Domain.Abstractions;

public abstract class BaseEntity
{
    public Guid Id { get; init; } = new Guid();
    public DateTime CreationDate { get; init; } = DateTime.Now;
    public DateTime? UpdateDate { get; private set; }
    public bool IsActive { get; private set; } = true;

    public void UpdateValues()
    {
        UpdateDate = DateTime.Now;
    }

    public void DisableEntity()
    {
        UpdateDate = DateTime.Now;
        IsActive = false;
    }

    public void ActiveEntity()
    {
        UpdateDate = DateTime.Now;
        IsActive = true;
    }
}
