using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using White_Horse_Inc_Core.Models;

namespace White_Horse_Inc_Api.Data.Mappings
{
    public class UserAddressMapping : BaseEntityMapping, IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.ToTable("UserAddress");

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
        }
    }
}