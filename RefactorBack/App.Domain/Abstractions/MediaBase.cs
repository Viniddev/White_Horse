namespace App.Domain.Abstractions;

public class MediaBase: BaseEntity
{
    public long Likes { get; private set; }
    public long Deslikes { get; private set; }

    public void Curtir()
    {
        Likes++;
    }

    public void Reprovar()
    {
        Deslikes++;
    }
}
