using App.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Mappings;

public abstract class MediaBaseMapping<T> : IEntityTypeConfiguration<T> where T : MediaBase
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreationDate)
            .IsRequired(true)
            .HasColumnType("DATETIME2");

        builder.Property(x => x.UpdateDate)
            .IsRequired(false)
            .HasColumnType("DATETIME2");

        builder.Property(x => x.IsActive)
            .IsRequired(true)
            .HasColumnType("BIT");

        builder.Property(x => x.Likes)
          .HasColumnType("BIGINT")
          .IsRequired();

        builder.Property(x => x.Deslikes)
          .HasColumnType("BIGINT")
          .IsRequired();
    }
}
