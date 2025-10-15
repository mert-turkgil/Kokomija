using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class SupportedLanguageConfiguration : IEntityTypeConfiguration<SupportedLanguage>
    {
        public void Configure(EntityTypeBuilder<SupportedLanguage> builder)
        {
            builder.ToTable("SupportedLanguages");

            builder.HasKey(sl => sl.Id);

            builder.Property(sl => sl.CultureCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasIndex(sl => sl.CultureCode)
                .IsUnique();

            builder.Property(sl => sl.DisplayName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(sl => sl.NativeName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(sl => sl.FlagIcon)
                .HasMaxLength(200);

            builder.Property(sl => sl.TwoLetterIsoCode)
                .IsRequired()
                .HasMaxLength(2);

            builder.HasIndex(sl => sl.TwoLetterIsoCode);

            builder.Property(sl => sl.IsEnabled)
                .HasDefaultValue(false);

            builder.Property(sl => sl.IsDefault)
                .HasDefaultValue(false);

            builder.Property(sl => sl.DisplayOrder)
                .HasDefaultValue(0);

            builder.Property(sl => sl.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }

    public class SiteSettingConfiguration : IEntityTypeConfiguration<SiteSetting>
    {
        public void Configure(EntityTypeBuilder<SiteSetting> builder)
        {
            builder.ToTable("SiteSettings");

            builder.HasKey(ss => ss.Id);

            builder.Property(ss => ss.Key)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(ss => ss.Key)
                .IsUnique();

            builder.Property(ss => ss.Value)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(ss => ss.Description)
                .HasMaxLength(500);

            builder.Property(ss => ss.Category)
                .HasMaxLength(50)
                .HasDefaultValue("General");

            builder.Property(ss => ss.DataType)
                .HasMaxLength(20)
                .HasDefaultValue("string");

            builder.HasIndex(ss => ss.Category);

            builder.Property(ss => ss.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(ss => ss.UpdatedBy)
                .HasMaxLength(256);
        }
    }
}
