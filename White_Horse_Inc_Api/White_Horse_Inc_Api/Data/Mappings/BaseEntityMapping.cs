using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using White_Horse_Inc_Core.Models.Base;

namespace White_Horse_Inc_Api.Data.Mappings
{
    public class BaseEntityMapping : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
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
}
