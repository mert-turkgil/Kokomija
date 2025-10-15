using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Description)
                .HasMaxLength(200);

            builder.Property(c => c.DiscountType)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("percentage");

            builder.Property(c => c.DiscountValue)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.MinimumOrderAmount)
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.MaximumDiscountAmount)
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.UsageCount)
                .HasDefaultValue(0);

            builder.Property(c => c.IsActive)
                .HasDefaultValue(true);

            builder.Property(c => c.StripeCouponId)
                .HasMaxLength(100);

            builder.Property(c => c.StripePromotionCodeId)
                .HasMaxLength(100);

            builder.Property(c => c.CreatedAt)
                .IsRequired();

            // Relationships
            builder.HasMany(c => c.Orders)
                .WithOne(o => o.Coupon)
                .HasForeignKey(o => o.CouponId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(c => c.CouponUsages)
                .WithOne(cu => cu.Coupon)
                .HasForeignKey(cu => cu.CouponId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(c => c.Code)
                .IsUnique();

            builder.HasIndex(c => c.StripeCouponId);

            builder.HasIndex(c => c.IsActive);

            builder.HasIndex(c => c.ValidFrom);

            builder.HasIndex(c => c.ValidUntil);
        }
    }
}
