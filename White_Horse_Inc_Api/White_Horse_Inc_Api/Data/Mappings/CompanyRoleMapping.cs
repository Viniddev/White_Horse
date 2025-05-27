using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using White_Horse_Inc_Core.Models;

namespace White_Horse_Inc_Api.Data.Mappings
{
    public class CompanyRoleMapping : BaseEntityMapping, IEntityTypeConfiguration<CompanyRole>
    {
        public void Configure(EntityTypeBuilder<CompanyRole> builder)
        {
            builder.ToTable("CompanyRole");

            builder.Property(x => x.Name)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80)
                .IsRequired();

        }
    }
}