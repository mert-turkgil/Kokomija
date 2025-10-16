using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kokomija.Data.Configurations
{
    public class EmailCommandConfiguration : IEntityTypeConfiguration<EmailCommand>
    {
        public void Configure(EntityTypeBuilder<EmailCommand> builder)
        {
            builder.ToTable("EmailCommands");

            builder.HasKey(ec => ec.Id);

            builder.Property(ec => ec.CommandType)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ec => ec.SenderEmail)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(ec => ec.Subject)
                .HasMaxLength(500);

            builder.Property(ec => ec.Body)
                .HasColumnType("nvarchar(max)");

            builder.Property(ec => ec.CommandParameters)
                .HasColumnType("nvarchar(max)");

            builder.Property(ec => ec.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("pending");

            builder.Property(ec => ec.IsAuthorized)
                .HasDefaultValue(false);

            builder.Property(ec => ec.AuthorizationToken)
                .HasMaxLength(500);

            builder.Property(ec => ec.IsExecuted)
                .HasDefaultValue(false);

            builder.Property(ec => ec.ExecutionResult)
                .HasColumnType("nvarchar(max)");

            builder.Property(ec => ec.ErrorMessage)
                .HasColumnType("nvarchar(max)");

            builder.Property(ec => ec.ReceivedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(ec => ec.ConfirmationIp)
                .HasMaxLength(100);

            builder.Property(ec => ec.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Indexes
            builder.HasIndex(ec => ec.CommandType)
                .HasDatabaseName("IX_EmailCommands_CommandType");

            builder.HasIndex(ec => ec.SenderEmail)
                .HasDatabaseName("IX_EmailCommands_SenderEmail");

            builder.HasIndex(ec => ec.Status)
                .HasDatabaseName("IX_EmailCommands_Status");

            builder.HasIndex(ec => ec.IsAuthorized)
                .HasDatabaseName("IX_EmailCommands_IsAuthorized");

            builder.HasIndex(ec => ec.IsExecuted)
                .HasDatabaseName("IX_EmailCommands_IsExecuted");

            builder.HasIndex(ec => ec.ReceivedAt)
                .HasDatabaseName("IX_EmailCommands_ReceivedAt");

            builder.HasIndex(ec => new { ec.Status, ec.IsAuthorized, ec.ReceivedAt })
                .HasDatabaseName("IX_EmailCommands_Status_Auth_Received");
        }
    }
}
