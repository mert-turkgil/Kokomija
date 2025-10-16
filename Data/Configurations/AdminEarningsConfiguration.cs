using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class AdminEarningsConfiguration : IEntityTypeConfiguration<AdminEarnings>
    {
        public void Configure(EntityTypeBuilder<AdminEarnings> builder)
        {
            builder.ToTable("AdminEarnings");

            builder.HasKey(ae => ae.Id);

            builder.Property(ae => ae.PeriodType)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("all-time");

            builder.Property(ae => ae.TotalOrders)
                .HasDefaultValue(0);

            builder.Property(ae => ae.TotalProductsSold)
                .HasDefaultValue(0);

            builder.Property(ae => ae.TotalSalesRevenue)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            builder.Property(ae => ae.TotalPlatformCommission)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            builder.Property(ae => ae.TotalStripeFees)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            builder.Property(ae => ae.TotalDeductions)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            builder.Property(ae => ae.NetRevenue)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            builder.Property(ae => ae.AverageOrderValue)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            builder.Property(ae => ae.AverageCommissionPerOrder)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            builder.Property(ae => ae.CurrentCommissionRate)
                .HasColumnType("decimal(5,4)")
                .HasDefaultValue(0.01M);

            builder.Property(ae => ae.Currency)
                .IsRequired()
                .HasMaxLength(10)
                .HasDefaultValue("PLN");

            builder.Property(ae => ae.LastCalculatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(ae => ae.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(ae => ae.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Indexes
            builder.HasIndex(ae => ae.PeriodType)
                .HasDatabaseName("IX_AdminEarnings_PeriodType");

            builder.HasIndex(ae => ae.PeriodStart)
                .HasDatabaseName("IX_AdminEarnings_PeriodStart");

            builder.HasIndex(ae => ae.PeriodEnd)
                .HasDatabaseName("IX_AdminEarnings_PeriodEnd");

            builder.HasIndex(ae => new { ae.PeriodType, ae.PeriodStart, ae.PeriodEnd })
                .HasDatabaseName("IX_AdminEarnings_Period");
        }
    }
}
