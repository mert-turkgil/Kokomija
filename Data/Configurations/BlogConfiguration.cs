using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    /// <summary>
    /// Entity Framework configuration for Blog entity
    /// </summary>
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            // Table name
            builder.ToTable("Blogs");

            // Primary key
            builder.HasKey(b => b.Id);

            // Properties
            builder.Property(b => b.FeaturedImage)
                .HasMaxLength(500);

            builder.Property(b => b.AuthorId)
                .IsRequired(false) // Nullable to support seed data
                .HasMaxLength(450);

            builder.Property(b => b.IsPublished)
                .HasDefaultValue(false);

            builder.Property(b => b.Views)
                .HasDefaultValue(0);

            builder.Property(b => b.AllowComments)
                .HasDefaultValue(true);

            builder.Property(b => b.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(b => b.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(b => b.IsDeleted)
                .HasDefaultValue(false);

            // Relationships
            builder.HasOne(b => b.Author)
                .WithMany()
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Category)
                .WithMany(c => c.Blogs)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Product)
                .WithMany()
                .HasForeignKey(b => b.ProductId)
                .OnDelete(DeleteBehavior.SetNull);

            // Indexes
            builder.HasIndex(b => b.AuthorId)
                .HasDatabaseName("IX_Blogs_AuthorId");

            builder.HasIndex(b => b.CategoryId)
                .HasDatabaseName("IX_Blogs_CategoryId");

            builder.HasIndex(b => b.ProductId)
                .HasDatabaseName("IX_Blogs_ProductId");

            builder.HasIndex(b => b.IsPublished)
                .HasDatabaseName("IX_Blogs_IsPublished");

            builder.HasIndex(b => b.PublishedDate)
                .HasDatabaseName("IX_Blogs_PublishedDate");

            builder.HasIndex(b => b.IsDeleted)
                .HasDatabaseName("IX_Blogs_IsDeleted");

            // Composite index for common queries
            builder.HasIndex(b => new { b.IsPublished, b.IsDeleted, b.PublishedDate })
                .HasDatabaseName("IX_Blogs_Published_Deleted_Date");

            // Query filter for soft delete
            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
