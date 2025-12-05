using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class OrderShipmentConfiguration : IEntityTypeConfiguration<OrderShipment>
    {
        public void Configure(EntityTypeBuilder<OrderShipment> builder)
        {
            builder.ToTable("OrderShipments");

            builder.HasKey(os => os.Id);

            builder.Property(os => os.Status)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(os => os.ShippingCost)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(os => os.Weight)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(os => os.Order)
                .WithMany()
                .HasForeignKey(os => os.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(os => os.ShippingProvider)
                .WithMany(sp => sp.Shipments)
                .HasForeignKey(os => os.ShippingProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(os => os.ShippingRate)
                .WithMany(sr => sr.Shipments)
                .HasForeignKey(os => os.ShippingRateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(os => os.TrackingEvents)
                .WithOne(te => te.OrderShipment)
                .HasForeignKey(te => te.OrderShipmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(os => os.OrderId);
            builder.HasIndex(os => os.TrackingNumber);
            builder.HasIndex(os => os.Status);
        }
    }
}
