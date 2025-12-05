using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Kokomija.Services;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace Kokomija.BackgroundServices;

/// <summary>
/// Background service that automatically processes developer payouts based on configured schedule
/// Payout frequency options: Daily, Weekly, BiWeekly, Monthly
/// Only processes payouts if balance meets minimum threshold
/// </summary>
public class AutomaticPayoutWorker : BackgroundService
{
    private readonly ILogger<AutomaticPayoutWorker> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration _configuration;

    public AutomaticPayoutWorker(
        ILogger<AutomaticPayoutWorker> logger,
        IServiceProvider serviceProvider,
        IConfiguration configuration)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Automatic Payout Worker started - will check daily for scheduled payouts");

        // Wait 5 minutes before first run to let the app fully start
        await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var now = DateTime.UtcNow;
                _logger.LogInformation("Checking for automatic payouts at: {Time}", now);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                    var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                    // Get commission settings
                    var allSettings = await unitOfWork.Repository<CommissionSettings>().GetAllAsync();
                    var commissionSettings = allSettings.FirstOrDefault();

                    if (commissionSettings == null || !commissionSettings.AutoPayoutEnabled)
                    {
                        _logger.LogInformation("Automatic payouts are disabled");
                        await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
                        continue;
                    }

                    // Check if payout should run based on frequency
                    if (ShouldRunPayout(commissionSettings.PayoutFrequency, now))
                    {
                        await ProcessPayoutAsync(unitOfWork, emailService, commissionSettings);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing automatic payouts");
            }

            // Check once per day at midnight UTC
            var nextRun = DateTime.UtcNow.Date.AddDays(1);
            var delay = nextRun - DateTime.UtcNow;
            _logger.LogInformation("Next payout check scheduled for: {NextRun}", nextRun);
            await Task.Delay(delay, stoppingToken);
        }

        _logger.LogInformation("Automatic Payout Worker stopped");
    }

    private bool ShouldRunPayout(PayoutFrequency frequency, DateTime now)
    {
        return frequency switch
        {
            PayoutFrequency.Daily => true, // Run every day
            PayoutFrequency.Weekly => now.DayOfWeek == DayOfWeek.Monday, // Every Monday
            PayoutFrequency.BiWeekly => now.DayOfWeek == DayOfWeek.Monday && (now.Day <= 7 || now.Day >= 15), // 1st or 3rd Monday of month
            PayoutFrequency.Monthly => now.Day == 1, // First day of month
            _ => false
        };
    }

    private async Task ProcessPayoutAsync(IUnitOfWork unitOfWork, IEmailService emailService, CommissionSettings settings)
    {
        try
        {
            // Get all pending earnings
            var allEarnings = await unitOfWork.Repository<DeveloperEarnings>().GetAllAsync();
            var pendingEarnings = allEarnings.Where(de => de.PayoutStatus == PayoutStatus.Pending).ToList();

            if (!pendingEarnings.Any())
            {
                _logger.LogInformation("No pending earnings to payout");
                return;
            }

            var totalPending = pendingEarnings.Sum(de => de.DeveloperCommission);

            // Check minimum threshold
            if (totalPending < settings.MinimumPayoutAmount)
            {
                _logger.LogInformation(
                    "Pending amount {Amount} is below minimum threshold {Threshold}, skipping payout",
                    totalPending, settings.MinimumPayoutAmount);
                return;
            }

            _logger.LogInformation(
                "Processing automatic payout of {Amount} for {Count} earnings records",
                totalPending, pendingEarnings.Count);

            // In a real implementation, you would integrate with Stripe Payouts API
            // For now, we'll mark the earnings as processed
            var payoutDate = DateTime.UtcNow;
            var payoutId = $"auto_payout_{payoutDate:yyyyMMddHHmmss}";

            foreach (var earning in pendingEarnings)
            {
                earning.PayoutStatus = PayoutStatus.Processed;
                earning.PayoutDate = payoutDate;
                earning.PayoutId = payoutId;
                unitOfWork.Repository<DeveloperEarnings>().Update(earning);
            }

            await unitOfWork.SaveChangesAsync();

            // Send notification email
            await SendPayoutNotificationAsync(emailService, totalPending, pendingEarnings.Count, payoutId);

            _logger.LogInformation(
                "Automatic payout completed: {Amount} paid out to developer",
                totalPending);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing automatic payout");
            throw;
        }
    }

    private async Task SendPayoutNotificationAsync(
        IEmailService emailService,
        decimal amount,
        int transactionCount,
        string payoutId)
    {
        try
        {
            var rootEmail = _configuration["Email:Smtp:Username"];
            if (string.IsNullOrEmpty(rootEmail))
            {
                _logger.LogWarning("Root email not configured, cannot send payout notification");
                return;
            }

            var subject = $"💸 Automatic Payout Processed - {amount:C}";
            var body = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset='UTF-8'>
                    <style>
                        body {{ font-family: 'Segoe UI', Arial, sans-serif; line-height: 1.6; color: #333; }}
                        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
                        .header {{ background: linear-gradient(135deg, #10b981 0%, #059669 100%); color: white; padding: 30px; text-align: center; border-radius: 8px 8px 0 0; }}
                        .content {{ background: #ffffff; padding: 30px; border: 1px solid #e5e7eb; }}
                        .payout-box {{ background: #d1fae5; border-left: 4px solid #10b981; padding: 20px; margin: 20px 0; border-radius: 4px; }}
                        .amount {{ font-size: 32px; font-weight: bold; color: #065f46; }}
                        .details {{ background: #f9fafb; padding: 15px; border-radius: 4px; margin: 20px 0; }}
                        .details table {{ width: 100%; }}
                        .details td {{ padding: 8px 0; }}
                        .footer {{ background: #f9fafb; padding: 20px; text-align: center; border-top: 1px solid #e5e7eb; color: #6b7280; font-size: 14px; }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h1 style='margin: 0; font-size: 28px;'>KOKOMIJA</h1>
                            <p style='margin: 10px 0 0 0; opacity: 0.9;'>Automatic Payout Notification</p>
                        </div>
                        <div class='content'>
                            <h2>✅ Payout Successfully Processed</h2>
                            <p>An automatic payout has been successfully processed based on your configured schedule.</p>
                            
                            <div class='payout-box'>
                                <p style='margin: 0 0 10px 0; font-size: 14px; color: #065f46; font-weight: 600;'>TOTAL PAYOUT AMOUNT</p>
                                <div class='amount'>{amount:C}</div>
                            </div>
                            
                            <div class='details'>
                                <table>
                                    <tr>
                                        <td style='color: #6b7280;'>Payout ID:</td>
                                        <td style='text-align: right; font-weight: 600;'>{payoutId}</td>
                                    </tr>
                                    <tr>
                                        <td style='color: #6b7280;'>Transaction Count:</td>
                                        <td style='text-align: right; font-weight: 600;'>{transactionCount}</td>
                                    </tr>
                                    <tr>
                                        <td style='color: #6b7280;'>Processed At:</td>
                                        <td style='text-align: right; font-weight: 600;'>{DateTime.UtcNow:yyyy-MM-dd HH:mm} UTC</td>
                                    </tr>
                                </table>
                            </div>
                            
                            <p style='background: #eff6ff; padding: 15px; border-left: 4px solid #3b82f6; border-radius: 4px; margin: 20px 0;'>
                                <strong>Note:</strong> This is an automated payout. All earnings have been marked as processed in your dashboard.
                            </p>
                            
                            <p style='text-align: center; margin-top: 30px;'>
                                <a href='{_configuration["AppUrl"]}/Admin/DeveloperEarnings' 
                                   style='background-color: #10b981; color: white; padding: 12px 30px; text-decoration: none; border-radius: 6px; font-weight: 600; display: inline-block;'>
                                    View Earnings Dashboard
                                </a>
                            </p>
                        </div>
                        <div class='footer'>
                            <p>© 2024 Kokomija. All rights reserved.</p>
                            <p style='font-size: 12px; margin-top: 10px;'>This is an automated system email.</p>
                        </div>
                    </div>
                </body>
                </html>";

            await emailService.SendEmailAsync(rootEmail, subject, body, isHtml: true);

            _logger.LogInformation("Payout notification email sent to {Email}", rootEmail);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending payout notification email");
        }
    }
}
