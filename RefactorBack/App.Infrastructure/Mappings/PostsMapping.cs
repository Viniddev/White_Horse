using App.Domain.Abstractions;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Mappings;

public class PostsMapping : MediaBaseMapping<Posts>, IEntityTypeConfiguration<Posts>, IAggregateRoot
{
    public new void Configure(EntityTypeBuilder<Posts> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Content)
            .IsRequired()
            .HasColumnType("NVARCHAR(MAX)");

        builder.Property(x => x.Topic)
            .IsRequired()
            .HasColumnType("NVARCHAR(280)");

        builder.Property(u => u.CreatorId)
           .HasColumnType("UNIQUEIDENTIFIER")
           .IsRequired();

        builder.ToTable("Posts");
    }
}
