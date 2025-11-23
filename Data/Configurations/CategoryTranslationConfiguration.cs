using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class CategoryTranslationConfiguration : IEntityTypeConfiguration<CategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
        {
            builder.HasKey(ct => ct.Id);

            builder.Property(ct => ct.CultureCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(ct => ct.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ct => ct.Slug)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ct => ct.Description)
                .HasMaxLength(1000);

            builder.Property(ct => ct.MetaDescription)
                .HasMaxLength(160);

            builder.Property(ct => ct.MetaKeywords)
                .HasMaxLength(500);

            builder.Property(ct => ct.CreatedAt)
                .IsRequired();

            // Relationship
            builder.HasOne(ct => ct.Category)
                .WithMany(c => c.Translations)
                .HasForeignKey(ct => ct.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(ct => new { ct.CategoryId, ct.CultureCode })
                .IsUnique();

            builder.HasIndex(ct => new { ct.Slug, ct.CultureCode })
                .IsUnique();
        }
    }
}
