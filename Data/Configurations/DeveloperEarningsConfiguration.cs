using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class DeveloperEarningsConfiguration : IEntityTypeConfiguration<DeveloperEarnings>
    {
        public void Configure(EntityTypeBuilder<DeveloperEarnings> builder)
        {
            builder.ToTable("DeveloperEarnings");

            builder.HasKey(de => de.Id);

            builder.Property(de => de.GrossAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(de => de.StripeProcessingFee)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(de => de.DeveloperCommission)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(de => de.NetAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(de => de.PayoutStatus)
                .IsRequired()
                .HasConversion<string>();

            builder.HasOne(de => de.Order)
                .WithMany()
                .HasForeignKey(de => de.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(de => de.OrderId);
            builder.HasIndex(de => de.EarnedAt);
            builder.HasIndex(de => de.PayoutStatus);
        }
    }
}
