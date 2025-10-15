using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.HasKey(pv => pv.Id);

            builder.Property(pv => pv.SKU)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(pv => pv.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(pv => pv.StockQuantity)
                .IsRequired();

            builder.Property(pv => pv.StripePriceId)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(pv => pv.IsActive)
                .HasDefaultValue(true);

            builder.Property(pv => pv.CreatedAt)
                .IsRequired();

            // Relationships
            builder.HasOne(pv => pv.Product)
                .WithMany(p => p.Variants)
                .HasForeignKey(pv => pv.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pv => pv.Size)
                .WithMany(s => s.ProductVariants)
                .HasForeignKey(pv => pv.SizeId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(pv => pv.Color)
                .WithMany(c => c.ProductVariants)
                .HasForeignKey(pv => pv.ColorId)
                .OnDelete(DeleteBehavior.SetNull);

            // Indexes
            builder.HasIndex(pv => pv.SKU)
                .IsUnique();

            builder.HasIndex(pv => pv.StripePriceId);

            builder.HasIndex(pv => pv.ProductId);
        }
    }
}
