using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class PaymentTransactionConfiguration : IEntityTypeConfiguration<PaymentTransaction>
    {
        public void Configure(EntityTypeBuilder<PaymentTransaction> builder)
        {
            builder.ToTable("PaymentTransactions");

            builder.HasKey(pt => pt.Id);

            builder.Property(pt => pt.Type)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(pt => pt.Status)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(pt => pt.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(pt => pt.Currency)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasOne(pt => pt.Order)
                .WithMany()
                .HasForeignKey(pt => pt.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pt => pt.ReturnRequest)
                .WithMany()
                .HasForeignKey(pt => pt.ReturnRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(pt => pt.OrderId);
            builder.HasIndex(pt => pt.ReturnRequestId);
            builder.HasIndex(pt => pt.Type);
            builder.HasIndex(pt => pt.Status);
            builder.HasIndex(pt => pt.CreatedAt);
        }
    }
}
