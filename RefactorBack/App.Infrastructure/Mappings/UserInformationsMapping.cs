
using App.Domain.Abstractions;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace App.Infrastructure.Mappings;

public class UserInformationsMapping : EntityBaseMapping<UserInformations>, IEntityTypeConfiguration<UserInformations>, IAggregateRoot
{
    public new void Configure(EntityTypeBuilder<UserInformations> builder)
    {
        base.Configure(builder);

        builder.ToTable("UserInformations");

        builder.Property(x => x.Name)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Cpf)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Rg)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Password)
            .HasColumnType("NVARCHAR(MAX)")
            .IsRequired();

        builder.Property(x => x.PhoneNumber)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.UserRole)
            .HasColumnType("TINYINT")
            .IsRequired();

        builder.Property(u => u.UserAddressId)
            .HasColumnType("UNIQUEIDENTIFIER")
            .IsRequired();
    }
}
