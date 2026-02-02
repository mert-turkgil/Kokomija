using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class ShippingProviderConfiguration : IEntityTypeConfiguration<ShippingProvider>
    {
        public void Configure(EntityTypeBuilder<ShippingProvider> builder)
        {
            builder.ToTable("ShippingProviders");

            builder.HasKey(sp => sp.Id);

            builder.Property(sp => sp.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(sp => sp.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(sp => sp.ApiKey)
                .HasMaxLength(2000);

            builder.Property(sp => sp.ApiSecret)
                .HasMaxLength(2000);

            builder.HasIndex(sp => sp.Code)
                .IsUnique();

            builder.HasMany(sp => sp.ShippingRates)
                .WithOne(sr => sr.ShippingProvider)
                .HasForeignKey(sr => sr.ShippingProviderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(sp => sp.Shipments)
                .WithOne(s => s.ShippingProvider)
                .HasForeignKey(s => s.ShippingProviderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
