using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class SizeGuideConfiguration : IEntityTypeConfiguration<SizeGuide>
    {
        public void Configure(EntityTypeBuilder<SizeGuide> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ChartImageUrl)
                .HasMaxLength(500);

            builder.Property(x => x.MeasurementInstructionsKey)
                .HasMaxLength(100);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(x => x.Product)
                .WithOne(x => x.SizeGuide)
                .HasForeignKey<SizeGuide>(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("SizeGuides");
        }
    }
}
