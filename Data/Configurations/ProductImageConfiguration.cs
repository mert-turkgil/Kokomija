using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasKey(pi => pi.Id);

            builder.Property(pi => pi.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(pi => pi.AltText)
                .HasMaxLength(200);

            builder.Property(pi => pi.DisplayOrder)
                .HasDefaultValue(0);

            builder.Property(pi => pi.IsPrimary)
                .HasDefaultValue(false);

            builder.Property(pi => pi.CreatedAt)
                .IsRequired();

            // Relationships
            builder.HasOne(pi => pi.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pi => pi.Color)
                .WithMany()
                .HasForeignKey(pi => pi.ColorId)
                .OnDelete(DeleteBehavior.SetNull);

            // Indexes
            builder.HasIndex(pi => pi.ProductId);
        }
    }
}
