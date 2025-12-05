using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class ReturnRequestConfiguration : IEntityTypeConfiguration<ReturnRequest>
    {
        public void Configure(EntityTypeBuilder<ReturnRequest> builder)
        {
            builder.ToTable("ReturnRequests");

            builder.HasKey(rr => rr.Id);

            builder.Property(rr => rr.Reason)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(rr => rr.Description)
                .IsRequired();

            builder.Property(rr => rr.RequestedAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(rr => rr.RefundedAmount)
                .HasColumnType("decimal(18,2)");

            builder.Property(rr => rr.Status)
                .IsRequired()
                .HasConversion<string>();

            builder.HasOne(rr => rr.Order)
                .WithMany()
                .HasForeignKey(rr => rr.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(rr => rr.OrderItem)
                .WithMany()
                .HasForeignKey(rr => rr.OrderItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(rr => rr.User)
                .WithMany()
                .HasForeignKey(rr => rr.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(rr => rr.Reviewer)
                .WithMany()
                .HasForeignKey(rr => rr.ReviewedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(rr => rr.Images)
                .WithOne(i => i.ReturnRequest)
                .HasForeignKey(i => i.ReturnRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(rr => rr.StatusHistory)
                .WithOne(sh => sh.ReturnRequest)
                .HasForeignKey(sh => sh.ReturnRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(rr => rr.OrderId);
            builder.HasIndex(rr => rr.UserId);
            builder.HasIndex(rr => rr.Status);
            builder.HasIndex(rr => rr.RequestedAt);
        }
    }
}
