using App.Domain.Abstractions;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Mappings;

public class UserAddressMapping : EntityBaseMapping<UserAddress>, IEntityTypeConfiguration<UserAddress>, IAggregateRoot
{
    public new void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Cep)
               .HasColumnType("NVARCHAR")
               .HasMaxLength(30)
               .IsRequired();

        builder.Property(x => x.Street)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(x => x.Neighborhood)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(x => x.City)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(x => x.Number)
           .HasColumnType("INT")
           .IsRequired();

        builder.ToTable("UserAddress");
    }
}
