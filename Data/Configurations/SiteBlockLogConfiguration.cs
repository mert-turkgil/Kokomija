using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class SiteBlockLogConfiguration : IEntityTypeConfiguration<SiteBlockLog>
    {
        public void Configure(EntityTypeBuilder<SiteBlockLog> builder)
        {
            builder.ToTable("SiteBlockLogs");

            builder.HasKey(sbl => sbl.Id);

            builder.Property(sbl => sbl.Reason)
                .IsRequired();

            builder.Property(sbl => sbl.UserMessage)
                .IsRequired();

            builder.HasOne(sbl => sbl.BlockedByUser)
                .WithMany()
                .HasForeignKey(sbl => sbl.BlockedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sbl => sbl.UnblockedByUser)
                .WithMany()
                .HasForeignKey(sbl => sbl.UnblockedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(sbl => sbl.IsActive);
            builder.HasIndex(sbl => sbl.BlockedAt);
        }
    }
}
