using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    /// <summary>
    /// Entity Framework configuration for BlogCategory entity
    /// </summary>
    public class BlogCategoryConfiguration : IEntityTypeConfiguration<BlogCategory>
    {
        public void Configure(EntityTypeBuilder<BlogCategory> builder)
        {
            // Table name
            builder.ToTable("BlogCategories");

            // Primary key
            builder.HasKey(bc => bc.Id);

            // Properties
            builder.Property(bc => bc.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(bc => bc.Slug)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(bc => bc.Description)
                .HasMaxLength(500);

            builder.Property(bc => bc.IconUrl)
                .HasMaxLength(500);

            builder.Property(bc => bc.DisplayOrder)
                .HasDefaultValue(0);

            builder.Property(bc => bc.IsActive)
                .HasDefaultValue(true);

            builder.Property(bc => bc.Language)
                .IsRequired()
                .HasMaxLength(10)
                .HasDefaultValue("pl");

            builder.Property(bc => bc.MetaDescription)
                .HasMaxLength(300);

            builder.Property(bc => bc.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(bc => bc.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(bc => bc.IsDeleted)
                .HasDefaultValue(false);

            // Indexes
            builder.HasIndex(bc => bc.Slug)
                .IsUnique()
                .HasDatabaseName("IX_BlogCategories_Slug");

            builder.HasIndex(bc => bc.DisplayOrder)
                .HasDatabaseName("IX_BlogCategories_DisplayOrder");

            builder.HasIndex(bc => bc.IsActive)
                .HasDatabaseName("IX_BlogCategories_IsActive");

            builder.HasIndex(bc => bc.Language)
                .HasDatabaseName("IX_BlogCategories_Language");

            builder.HasIndex(bc => bc.IsDeleted)
                .HasDatabaseName("IX_BlogCategories_IsDeleted");

            // Composite index for common queries
            builder.HasIndex(bc => new { bc.IsActive, bc.IsDeleted, bc.DisplayOrder })
                .HasDatabaseName("IX_BlogCategories_Active_Deleted_Order");

            // Query filter for soft delete
            builder.HasQueryFilter(bc => !bc.IsDeleted);
        }
    }
}
