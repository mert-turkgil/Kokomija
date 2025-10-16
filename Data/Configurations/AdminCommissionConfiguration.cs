using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class AdminCommissionConfiguration : IEntityTypeConfiguration<AdminCommission>
    {
        public void Configure(EntityTypeBuilder<AdminCommission> builder)
        {
            builder.ToTable("AdminCommissions");

            builder.HasKey(ac => ac.Id);

            builder.Property(ac => ac.OrderId)
                .IsRequired();

            builder.Property(ac => ac.ProductPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(ac => ac.Quantity)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property(ac => ac.Subtotal)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(ac => ac.PlatformCommissionRate)
                .IsRequired()
                .HasColumnType("decimal(5,4)")
                .HasDefaultValue(0.01M);

            builder.Property(ac => ac.PlatformCommissionAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(ac => ac.StripeProcessingFeeRate)
                .IsRequired()
                .HasColumnType("decimal(5,4)")
                .HasDefaultValue(0.014M); // 1.4% for Poland

            builder.Property(ac => ac.StripeFixedFee)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(1.00M); // 1 PLN

            builder.Property(ac => ac.TotalStripeFees)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(ac => ac.TotalDeductions)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(ac => ac.Currency)
                .IsRequired()
                .HasMaxLength(10)
                .HasDefaultValue("PLN");

            builder.Property(ac => ac.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("pending");

            builder.Property(ac => ac.CalculatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(ac => ac.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(ac => ac.Order)
                .WithMany()
                .HasForeignKey(ac => ac.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ac => ac.OrderItem)
                .WithMany()
                .HasForeignKey(ac => ac.OrderItemId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(ac => ac.Product)
                .WithMany()
                .HasForeignKey(ac => ac.ProductId)
                .OnDelete(DeleteBehavior.SetNull);

            // Indexes
            builder.HasIndex(ac => ac.OrderId)
                .HasDatabaseName("IX_AdminCommissions_OrderId");

            builder.HasIndex(ac => ac.OrderItemId)
                .HasDatabaseName("IX_AdminCommissions_OrderItemId");

            builder.HasIndex(ac => ac.ProductId)
                .HasDatabaseName("IX_AdminCommissions_ProductId");

            builder.HasIndex(ac => ac.Status)
                .HasDatabaseName("IX_AdminCommissions_Status");

            builder.HasIndex(ac => ac.CalculatedAt)
                .HasDatabaseName("IX_AdminCommissions_CalculatedAt");

            builder.HasIndex(ac => new { ac.Status, ac.CalculatedAt })
                .HasDatabaseName("IX_AdminCommissions_Status_CalculatedAt");
        }
    }
}
