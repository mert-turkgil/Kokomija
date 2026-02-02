using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class BusinessProfileConfiguration : IEntityTypeConfiguration<BusinessProfile>
    {
        public void Configure(EntityTypeBuilder<BusinessProfile> builder)
        {
            builder.ToTable("BusinessProfiles");
            
            builder.HasKey(bp => bp.Id);
            
            builder.Property(bp => bp.NIP)
                .IsRequired()
                .HasMaxLength(10);
            
            builder.Property(bp => bp.CompanyName)
                .IsRequired()
                .HasMaxLength(500);
            
            builder.Property(bp => bp.REGON)
                .HasMaxLength(14);
            
            builder.Property(bp => bp.KRS)
                .HasMaxLength(20);
            
            builder.Property(bp => bp.VATStatus)
                .HasMaxLength(50);
            
            builder.Property(bp => bp.ResidenceAddress)
                .HasMaxLength(500);
            
            builder.Property(bp => bp.WorkingAddress)
                .HasMaxLength(500);
            
            builder.Property(bp => bp.GovernmentRequestId)
                .HasMaxLength(100);
            
            // One-to-one relationship with ApplicationUser
            builder.HasOne(bp => bp.User)
                .WithOne(u => u.BusinessProfile)
                .HasForeignKey<BusinessProfile>(bp => bp.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Index for faster lookups
            builder.HasIndex(bp => bp.NIP);
            builder.HasIndex(bp => bp.UserId).IsUnique();
        }
    }

    public class NIPVerificationLogConfiguration : IEntityTypeConfiguration<NIPVerificationLog>
    {
        public void Configure(EntityTypeBuilder<NIPVerificationLog> builder)
        {
            builder.ToTable("NIPVerificationLogs");
            
            builder.HasKey(l => l.Id);
            
            builder.Property(l => l.NIP)
                .IsRequired()
                .HasMaxLength(10);
            
            builder.Property(l => l.IPAddress)
                .HasMaxLength(45);
            
            builder.Property(l => l.ErrorMessage)
                .HasMaxLength(500);
            
            builder.Property(l => l.ResponseCode)
                .HasMaxLength(20);
            
            // Relationship with ApplicationUser
            builder.HasOne(l => l.User)
                .WithMany(u => u.NIPVerificationLogs)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Indexes for rate limiting queries
            builder.HasIndex(l => new { l.UserId, l.AttemptedAt });
            builder.HasIndex(l => l.AttemptedAt);
        }
    }
}
