using App.Domain.Abstractions;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Mappings;

public class ResponsesMapping : MediaBaseMapping<Responses>, IEntityTypeConfiguration<Responses>, IAggregateRoot
{
    public new void Configure(EntityTypeBuilder<Responses> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Message)
            .IsRequired()
            .HasColumnType("NVARCHAR(MAX)");

        builder.Property(u => u.CreatorId)
            .HasColumnType("UNIQUEIDENTIFIER")
            .IsRequired();

        builder.Property(u => u.PostId)
            .HasColumnType("UNIQUEIDENTIFIER")
            .IsRequired();

        builder.HasOne(p => p.Creator)
            .WithMany()
            .HasForeignKey(p => p.CreatorId)
            .IsRequired();

        builder.HasOne(p => p.Post)
            .WithMany()
            .HasForeignKey(p => p.PostId)
            .IsRequired();
    }
}
