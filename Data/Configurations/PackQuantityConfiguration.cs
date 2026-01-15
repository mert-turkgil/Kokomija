using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class PackQuantityConfiguration : IEntityTypeConfiguration<PackQuantity>
    {
        public void Configure(EntityTypeBuilder<PackQuantity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(50);

            builder.Property(x => x.NameKey)
                .HasMaxLength(100);

            builder.Property(x => x.DisplayOrder)
                .HasDefaultValue(0);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasMany(x => x.ProductVariants)
                .WithOne(x => x.PackQuantity)
                .HasForeignKey(x => x.PackQuantityId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable("PackQuantities");
        }
    }
}
