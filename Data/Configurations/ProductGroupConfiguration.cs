using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class ProductGroupConfiguration : IEntityTypeConfiguration<ProductGroup>
    {
        public void Configure(EntityTypeBuilder<ProductGroup> builder)
        {
            builder.ToTable("ProductGroups");

            builder.HasKey(pg => pg.Id);

            builder.Property(pg => pg.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(pg => pg.NameKey)
                .HasMaxLength(100);

            builder.Property(pg => pg.Description)
                .HasMaxLength(500);

            builder.Property(pg => pg.DescriptionKey)
                .HasMaxLength(100);

            builder.Property(pg => pg.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Navigation: One ProductGroup has many Products
            builder.HasMany(pg => pg.Products)
                .WithOne(p => p.ProductGroup)
                .HasForeignKey(p => p.ProductGroupId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
