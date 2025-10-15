using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(s => s.DisplayName)
                .HasMaxLength(50);

            builder.Property(s => s.Region)
                .HasMaxLength(20);

            builder.Property(s => s.DisplayOrder)
                .HasDefaultValue(0);

            builder.Property(s => s.IsActive)
                .HasDefaultValue(true);

            builder.Property(s => s.CreatedAt)
                .IsRequired();

            // Indexes
            builder.HasIndex(s => s.Name);
        }
    }
}
