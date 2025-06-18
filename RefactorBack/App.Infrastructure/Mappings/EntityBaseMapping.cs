using App.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Mappings;

public abstract class EntityBaseMapping<T> : IEntityTypeConfiguration<T>  where T : BaseEntity
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
    }
}
