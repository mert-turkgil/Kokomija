using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.HasKey(ps => ps.Id);

            builder.Property(ps => ps.IsActive)
                .HasDefaultValue(true);

            builder.Property(ps => ps.CreatedAt)
                .IsRequired();

            // Relationships
            builder.HasOne(ps => ps.Product)
                .WithMany(p => p.AvailableSizes)
                .HasForeignKey(ps => ps.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ps => ps.Size)
                .WithMany(s => s.ProductSizes)
                .HasForeignKey(ps => ps.SizeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(ps => new { ps.ProductId, ps.SizeId })
                .IsUnique();
        }
    }
}
