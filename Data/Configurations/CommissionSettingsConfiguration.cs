using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class CommissionSettingsConfiguration : IEntityTypeConfiguration<CommissionSettings>
    {
        public void Configure(EntityTypeBuilder<CommissionSettings> builder)
        {
            builder.ToTable("CommissionSettings");

            builder.HasKey(cs => cs.Id);

            builder.Property(cs => cs.DeveloperCommissionRate)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(cs => cs.PlatformCommissionRate)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(cs => cs.StripeCommissionRate)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(cs => cs.StripeFixedFee)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(cs => cs.MinimumPayoutAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(cs => cs.PayoutFrequency)
                .IsRequired()
                .HasConversion<string>();

            builder.HasOne(cs => cs.Modifier)
                .WithMany()
                .HasForeignKey(cs => cs.LastModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
