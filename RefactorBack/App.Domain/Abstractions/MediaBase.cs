namespace App.Domain.Abstractions;

public class MediaBase: BaseEntity
{
    public long Likes { get; private set; } = 0;
    public long Deslikes { get; private set; } = 0;

    public void Curtir()
    {
        Likes++;
    }

    public void DesCurtir()
    {
        Deslikes++;
    }
}
