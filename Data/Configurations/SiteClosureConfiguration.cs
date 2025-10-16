using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class SiteClosureConfiguration : IEntityTypeConfiguration<SiteClosure>
    {
        public void Configure(EntityTypeBuilder<SiteClosure> builder)
        {
            builder.ToTable("SiteClosures");

            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.IsClosed)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(sc => sc.Reason)
                .HasMaxLength(1000);

            builder.Property(sc => sc.ClosedBy)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(sc => sc.ReopenConfirmationToken)
                .HasMaxLength(500);

            builder.Property(sc => sc.AllowPasswordAccess)
                .HasDefaultValue(true);

            builder.Property(sc => sc.EmergencyPasswordHash)
                .HasMaxLength(500);

            builder.Property(sc => sc.ReopenedBy)
                .HasMaxLength(200);

            builder.Property(sc => sc.ReopenMethod)
                .HasMaxLength(50);

            builder.Property(sc => sc.ConfirmationEmailsSent)
                .HasDefaultValue(0);

            builder.Property(sc => sc.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(sc => sc.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Indexes
            builder.HasIndex(sc => sc.IsClosed)
                .HasDatabaseName("IX_SiteClosures_IsClosed");

            builder.HasIndex(sc => sc.ScheduledReopenAt)
                .HasDatabaseName("IX_SiteClosures_ScheduledReopenAt");

            builder.HasIndex(sc => sc.ClosedAt)
                .HasDatabaseName("IX_SiteClosures_ClosedAt");

            builder.HasIndex(sc => new { sc.IsClosed, sc.ScheduledReopenAt })
                .HasDatabaseName("IX_SiteClosures_IsClosed_ScheduledReopenAt");
        }
    }
}
