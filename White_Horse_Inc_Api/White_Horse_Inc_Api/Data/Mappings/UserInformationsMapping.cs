using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using White_Horse_Inc_Core.Models;

namespace White_Horse_Inc_Api.Data.Mappings
{
    public class UserInformationsMapping : BaseEntityMapping, IEntityTypeConfiguration<UserInformations>
    {
        public void Configure(EntityTypeBuilder<UserInformations> builder)
        {
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

            builder.Property(x => x.CompanyRoleId)
             .HasColumnType("BIGINT")
             .IsRequired();

            builder.Property(x => x.AddressId)
             .HasColumnType("BIGINT")
             .IsRequired();
        }
    }
}
