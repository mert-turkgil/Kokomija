using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class BlogTranslationConfiguration : IEntityTypeConfiguration<BlogTranslation>
    {
        public void Configure(EntityTypeBuilder<BlogTranslation> builder)
        {
            builder.HasKey(bt => bt.Id);

            builder.Property(bt => bt.CultureCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(bt => bt.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(bt => bt.Slug)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(bt => bt.Content)
                .IsRequired();

            builder.Property(bt => bt.Excerpt)
                .HasMaxLength(500);

            builder.Property(bt => bt.MetaDescription)
                .HasMaxLength(160);

            builder.Property(bt => bt.MetaKeywords)
                .HasMaxLength(500);

            builder.Property(bt => bt.Tags)
                .HasMaxLength(500);

            builder.Property(bt => bt.CreatedAt)
                .IsRequired();

            builder.Property(bt => bt.UpdatedAt)
                .IsRequired();

            // Relationship
            builder.HasOne(bt => bt.Blog)
                .WithMany(b => b.Translations)
                .HasForeignKey(bt => bt.BlogId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(bt => new { bt.BlogId, bt.CultureCode })
                .IsUnique();

            builder.HasIndex(bt => new { bt.Slug, bt.CultureCode })
                .IsUnique();

            // Query filter - only show translations for non-deleted blogs
            builder.HasQueryFilter(bt => bt.Blog != null && !bt.Blog.IsDeleted);
        }
    }
}
