using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class TaxRateConfiguration : IEntityTypeConfiguration<TaxRate>
    {
        public void Configure(EntityTypeBuilder<TaxRate> builder)
        {
            builder.ToTable("TaxRates");

            builder.HasKey(tr => tr.Id);

            builder.Property(tr => tr.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(tr => tr.CountryCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(tr => tr.Rate)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(tr => tr.StripeTaxRateId)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(tr => tr.CountryCode);
            builder.HasIndex(tr => tr.IsActive);
            builder.HasIndex(tr => tr.IsDefault);
            builder.HasIndex(tr => new { tr.CountryCode, tr.StateCode });
        }
    }
}
