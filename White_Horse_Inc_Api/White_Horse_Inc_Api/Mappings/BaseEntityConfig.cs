using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using White_Horse_Inc_Core.Models;

namespace White_Horse_Inc_Api.Mappings
{
    public class BaseEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnOrder(0);

            builder.Property(x => x.CreationDate)
                .IsRequired(true)
                .HasColumnType("DATETIME2")
                .HasColumnOrder(1);

            builder.Property(x => x.UpdateDate)
               .IsRequired(false)
               .HasColumnType("DATETIME2")
               .HasColumnOrder(2);

            builder.Property(x => x.IsActive)
               .IsRequired(true)
               .HasColumnType("BIT")
               .HasColumnOrder(3);
        }
    }
}
