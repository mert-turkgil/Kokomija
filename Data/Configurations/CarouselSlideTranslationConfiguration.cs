using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class CarouselSlideTranslationConfiguration : IEntityTypeConfiguration<CarouselSlideTranslation>
    {
        public void Configure(EntityTypeBuilder<CarouselSlideTranslation> builder)
        {
            builder.ToTable("CarouselSlideTranslations");

            builder.HasKey(t => t.Id);

            // Create index for efficient lookups
            builder.HasIndex(t => new { t.CarouselSlideId, t.CultureCode })
                   .IsUnique()
                   .HasDatabaseName("IX_CarouselSlideTranslations_SlideId_Culture");

            // Relationship with CarouselSlide
            builder.HasOne(t => t.CarouselSlide)
                   .WithMany(s => s.Translations)
                   .HasForeignKey(t => t.CarouselSlideId)
                   .OnDelete(DeleteBehavior.Cascade);

            // String length constraints
            builder.Property(t => t.CultureCode)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(t => t.Subtitle)
                   .HasMaxLength(500);

            builder.Property(t => t.ButtonText)
                   .HasMaxLength(100);

            builder.Property(t => t.LinkUrl)
                   .HasMaxLength(500);

            builder.Property(t => t.ControllerName)
                   .HasMaxLength(100);

            builder.Property(t => t.ActionName)
                   .HasMaxLength(100);

            builder.Property(t => t.AreaName)
                   .HasMaxLength(100);

            builder.Property(t => t.RouteParameters)
                   .HasMaxLength(1000);

            builder.Property(t => t.ImageAlt)
                   .IsRequired()
                   .HasMaxLength(300);

            // Default values
            builder.Property(t => t.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
