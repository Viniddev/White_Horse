using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using White_Horse_Inc_Core.Interfaces;
using White_Horse_Inc_Core.Models;

namespace White_Horse_Inc_Api.Mappings
{
    public class CompanyRoleMapping : BaseEntityConfig<CompanyRole>
    {
        public void Configure(EntityTypeBuilder<CompanyRole> builder) 
        {
            base.Configure(builder);

            builder.ToTable("CompanyRole");

            builder.Property(x => x.Name)
               .IsRequired(true)
               .HasColumnType("NVARCHAR")
               .HasMaxLength(80);

            builder.Property(x => x.Description)
               .IsRequired(true)
               .HasColumnType("NVARCHAR")
               .HasMaxLength(200);
        }
    }
}
