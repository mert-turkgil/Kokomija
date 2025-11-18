using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations;

public class WishlistNotificationConfiguration : IEntityTypeConfiguration<WishlistNotification>
{
    public void Configure(EntityTypeBuilder<WishlistNotification> builder)
    {
        builder.HasKey(w => w.Id);

        builder.HasIndex(w => w.WishlistId);
        builder.HasIndex(w => w.IsRead);
        builder.HasIndex(w => w.EmailSent);
        builder.HasIndex(w => w.CreatedAt);

        builder.HasOne(w => w.Wishlist)
            .WithMany()
            .HasForeignKey(w => w.WishlistId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
