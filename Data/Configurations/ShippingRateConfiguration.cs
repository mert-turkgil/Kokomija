using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class ShippingRateConfiguration : IEntityTypeConfiguration<ShippingRate>
    {
        public void Configure(EntityTypeBuilder<ShippingRate> builder)
        {
            builder.ToTable("ShippingRates");

            builder.HasKey(sr => sr.Id);

            builder.Property(sr => sr.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(sr => sr.BasePrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(sr => sr.PricePerKg)
                .HasColumnType("decimal(18,2)");

            builder.Property(sr => sr.PricePerKm)
                .HasColumnType("decimal(18,2)");

            builder.Property(sr => sr.FreeShippingThreshold)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(sr => sr.ShippingProvider)
                .WithMany(sp => sp.ShippingRates)
                .HasForeignKey(sr => sr.ShippingProviderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(sr => sr.Shipments)
                .WithOne(s => s.ShippingRate)
                .HasForeignKey(s => s.ShippingRateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(sr => sr.ShippingProviderId);
            builder.HasIndex(sr => sr.IsActive);
        }
    }
}
