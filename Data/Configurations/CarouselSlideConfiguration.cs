using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class CarouselSlideConfiguration : IEntityTypeConfiguration<CarouselSlide>
    {
        public void Configure(EntityTypeBuilder<CarouselSlide> builder)
        {
            builder.ToTable("CarouselSlides");

            builder.HasKey(cs => cs.Id);

            builder.Property(cs => cs.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(cs => cs.Subtitle)
                .HasMaxLength(500);

            builder.Property(cs => cs.ImagePath)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(cs => cs.MobileImagePath)
                .HasMaxLength(500);

            builder.Property(cs => cs.ImageAlt)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(cs => cs.LinkUrl)
                .HasMaxLength(500);

            builder.Property(cs => cs.ButtonText)
                .HasMaxLength(100);

            builder.Property(cs => cs.ButtonClass)
                .HasMaxLength(100)
                .HasDefaultValue("btn-primary");

            builder.Property(cs => cs.Location)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("home");

            builder.Property(cs => cs.BackgroundColor)
                .HasMaxLength(50);

            builder.Property(cs => cs.TextColor)
                .HasMaxLength(50);

            builder.Property(cs => cs.TextAlign)
                .HasMaxLength(20)
                .HasDefaultValue("center");

            builder.Property(cs => cs.AnimationType)
                .HasMaxLength(50)
                .HasDefaultValue("fade");

            builder.Property(cs => cs.Duration)
                .HasDefaultValue(5000);

            builder.Property(cs => cs.CustomCssClass)
                .HasMaxLength(200);

            builder.Property(cs => cs.CreatedBy)
                .HasMaxLength(450);

            builder.Property(cs => cs.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(cs => cs.UpdatedBy)
                .HasMaxLength(450);

            builder.Property(cs => cs.DeletedBy)
                .HasMaxLength(450);

            builder.Property(cs => cs.IsActive)
                .HasDefaultValue(true);

            builder.Property(cs => cs.IsDeleted)
                .HasDefaultValue(false);

            // Foreign key for Category
            builder.HasOne(cs => cs.Category)
                .WithMany()
                .HasForeignKey(cs => cs.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            // Indexes
            builder.HasIndex(cs => cs.DisplayOrder);
            builder.HasIndex(cs => cs.IsActive);
            builder.HasIndex(cs => cs.IsDeleted);
            builder.HasIndex(cs => cs.Location);
            builder.HasIndex(cs => cs.CategoryId);
            builder.HasIndex(cs => new { cs.StartDate, cs.EndDate });
            builder.HasIndex(cs => new { cs.Location, cs.IsActive, cs.DisplayOrder });
        }
    }
}
