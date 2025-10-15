using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.OrderNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(o => o.StripePaymentIntentId)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(o => o.StripeChargeId)
                .HasMaxLength(100);

            builder.Property(o => o.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(o => o.CommissionAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(o => o.CommissionRate)
                .IsRequired()
                .HasColumnType("decimal(5,4)")
                .HasDefaultValue(0.015M);

            builder.Property(o => o.DiscountAmount)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            builder.Property(o => o.SubtotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(o => o.CustomerEmail)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(o => o.CustomerName)
                .HasMaxLength(200);

            builder.Property(o => o.OrderStatus)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("pending");

            builder.Property(o => o.PaymentStatus)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("pending");

            builder.Property(o => o.CreatedAt)
                .IsRequired();

            // Relationships
            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(o => o.Coupon)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CouponId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(o => o.UserId);

            builder.HasIndex(o => o.CouponId);

            builder.HasIndex(o => o.OrderNumber)
                .IsUnique();

            builder.HasIndex(o => o.StripePaymentIntentId);

            builder.HasIndex(o => o.CustomerEmail);

            builder.HasIndex(o => o.OrderStatus);

            builder.HasIndex(o => o.CreatedAt);
        }
    }
}
