using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder.HasKey(pc => pc.Id);

            builder.Property(pc => pc.IsActive)
                .HasDefaultValue(true);

            builder.Property(pc => pc.CreatedAt)
                .IsRequired();

            // Relationships
            builder.HasOne(pc => pc.Product)
                .WithMany(p => p.AvailableColors)
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pc => pc.Color)
                .WithMany(c => c.ProductColors)
                .HasForeignKey(pc => pc.ColorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(pc => new { pc.ProductId, pc.ColorId })
                .IsUnique();
        }
    }
}
