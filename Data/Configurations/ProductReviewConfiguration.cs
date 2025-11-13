using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
    {
        public void Configure(EntityTypeBuilder<ProductReview> builder)
        {
            builder.ToTable("ProductReviews");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Rating)
                .HasColumnType("decimal(2,1)")
                .IsRequired();

            builder.Property(r => r.Comment)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(r => r.AdminReply)
                .HasMaxLength(2000);

            builder.Property(r => r.IsVisible)
                .HasDefaultValue(true);

            builder.Property(r => r.IsVerifiedPurchase)
                .HasDefaultValue(false);

            builder.Property(r => r.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships - User and AdminUser only (Product relationship is in ProductConfiguration)
            builder.HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.AdminUser)
                .WithMany()
                .HasForeignKey(r => r.AdminReplyBy)
                .OnDelete(DeleteBehavior.NoAction);

            // Indexes
            builder.HasIndex(r => r.ProductId);
            builder.HasIndex(r => r.UserId);
            builder.HasIndex(r => r.IsVisible);
            builder.HasIndex(r => r.IsVerifiedPurchase);
            builder.HasIndex(r => r.CreatedAt);
            builder.HasIndex(r => new { r.ProductId, r.IsVisible, r.CreatedAt });
        }
    }
}
