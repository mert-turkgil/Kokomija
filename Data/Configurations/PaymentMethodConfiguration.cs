using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    /// <summary>
    /// Entity Framework configuration for PaymentMethod entity
    /// </summary>
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            // Table name
            builder.ToTable("PaymentMethods");

            // Primary key
            builder.HasKey(pm => pm.Id);

            // Properties
            builder.Property(pm => pm.StripePaymentMethodId)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(pm => pm.UserId)
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(pm => pm.CardBrand)
                .HasMaxLength(50);

            builder.Property(pm => pm.Last4)
                .HasMaxLength(4);

            builder.Property(pm => pm.CardholderName)
                .HasMaxLength(200);

            builder.Property(pm => pm.BillingPostalCode)
                .HasMaxLength(20);

            builder.Property(pm => pm.BillingCountry)
                .HasMaxLength(100);

            builder.Property(pm => pm.Nickname)
                .HasMaxLength(100);

            builder.Property(pm => pm.IsDefault)
                .HasDefaultValue(false);

            builder.Property(pm => pm.IsActive)
                .HasDefaultValue(true);

            builder.Property(pm => pm.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(pm => pm.IsDeleted)
                .HasDefaultValue(false);

            // Relationships
            builder.HasOne(pm => pm.User)
                .WithMany(u => u.PaymentMethods)
                .HasForeignKey(pm => pm.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(pm => pm.StripePaymentMethodId)
                .IsUnique()
                .HasDatabaseName("IX_PaymentMethods_StripePaymentMethodId");

            builder.HasIndex(pm => pm.UserId)
                .HasDatabaseName("IX_PaymentMethods_UserId");

            builder.HasIndex(pm => new { pm.UserId, pm.IsDefault })
                .HasDatabaseName("IX_PaymentMethods_User_Default");

            builder.HasIndex(pm => pm.IsActive)
                .HasDatabaseName("IX_PaymentMethods_IsActive");

            builder.HasIndex(pm => pm.IsDeleted)
                .HasDatabaseName("IX_PaymentMethods_IsDeleted");

            // Query filter for soft delete
            builder.HasQueryFilter(pm => !pm.IsDeleted);
        }
    }
}
