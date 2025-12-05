using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class ProductTranslationConfiguration : IEntityTypeConfiguration<ProductTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductTranslation> builder)
        {
            builder.ToTable("ProductTranslations");

            builder.HasKey(pt => pt.Id);

            builder.Property(pt => pt.CultureCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(pt => pt.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(pt => pt.Description)
                .IsRequired();

            builder.Property(pt => pt.Slug)
                .HasMaxLength(250);

            builder.Property(pt => pt.MetaDescription)
                .HasMaxLength(500);

            builder.Property(pt => pt.MetaKeywords)
                .HasMaxLength(500);

            builder.Property(pt => pt.CreatedAt)
                .IsRequired();

            builder.Property(pt => pt.UpdatedAt)
                .IsRequired();

            // Relationship with Product
            builder.HasOne(pt => pt.Product)
                .WithMany(p => p.Translations)
                .HasForeignKey(pt => pt.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Index for efficient lookups
            builder.HasIndex(pt => new { pt.ProductId, pt.CultureCode })
                .IsUnique()
                .HasDatabaseName("IX_ProductTranslations_ProductId_CultureCode");

            builder.HasIndex(pt => pt.Slug)
                .HasDatabaseName("IX_ProductTranslations_Slug");
        }
    }
}
