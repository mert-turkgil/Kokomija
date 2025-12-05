using Kokomija.Data.Abstract;
using Kokomija.Services;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.BackgroundServices;

/// <summary>
/// Background service that sends automated earnings reports to the ROOT user
/// - Daily summary: Every day at 9:00 AM
/// - Weekly summary: Every Monday at 9:00 AM
/// - Monthly summary: First day of month at 9:00 AM
/// </summary>
public class EarningsReportWorker : BackgroundService
{
    private readonly ILogger<EarningsReportWorker> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration _configuration;

    public EarningsReportWorker(
        ILogger<EarningsReportWorker> logger,
        IServiceProvider serviceProvider,
        IConfiguration configuration)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Earnings Report Worker started - will check every hour for scheduled reports");

        // Wait 1 minute before first run to let the app fully start
        await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var now = DateTime.UtcNow;
                var currentHour = now.Hour;

                // Run reports at 9:00 AM UTC (adjust for your timezone)
                if (currentHour == 9 && now.Minute < 15)
                {
                    _logger.LogInformation("Running scheduled earnings reports at: {Time}", now);

                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                        var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                        // Daily Report - Every day
                        await SendDailyReportAsync(unitOfWork, emailService);

                        // Weekly Report - Every Monday
                        if (now.DayOfWeek == DayOfWeek.Monday)
                        {
                            await SendWeeklyReportAsync(unitOfWork, emailService);
                        }

                        // Monthly Report - First day of month
                        if (now.Day == 1)
                        {
                            await SendMonthlyReportAsync(unitOfWork, emailService);
                        }
                    }

                    _logger.LogInformation("Earnings reports sent successfully");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while sending earnings reports");
            }

            // Check every hour
            await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
        }

        _logger.LogInformation("Earnings Report Worker stopped");
    }

    private async Task SendDailyReportAsync(IUnitOfWork unitOfWork, IEmailService emailService)
    {
        try
        {
            var yesterday = DateTime.UtcNow.Date.AddDays(-1);
            var today = DateTime.UtcNow.Date;

            var allEarnings = await unitOfWork.Repository<Entity.DeveloperEarnings>().GetAllAsync();
            var dailyEarnings = allEarnings
                .Where(de => de.EarnedAt >= yesterday && de.EarnedAt < today)
                .ToList();

            if (!dailyEarnings.Any())
            {
                _logger.LogInformation("No earnings for yesterday, skipping daily report");
                return;
            }

            var totalAmount = dailyEarnings.Sum(de => de.DeveloperCommission);
            var grossRevenue = dailyEarnings.Sum(de => de.GrossAmount);
            var stripeFees = dailyEarnings.Sum(de => de.StripeProcessingFee);
            var netRevenue = dailyEarnings.Sum(de => de.NetAmount);
            var totalOrders = dailyEarnings.Count;

            var rootEmail = _configuration["Email:Smtp:Username"];
            if (string.IsNullOrEmpty(rootEmail))
            {
                _logger.LogWarning("Root email not configured, cannot send daily report");
                return;
            }

            var template = await emailService.LoadEmailTemplate("DeveloperEarningsSummary");
            var emailBody = template
                .Replace("{{PERIOD}}", $"Daily Report - {yesterday:MMM dd, yyyy}")
                .Replace("{{TOTAL_AMOUNT}}", totalAmount.ToString("C"))
                .Replace("{{TOTAL_ORDERS}}", totalOrders.ToString())
                .Replace("{{GROSS_REVENUE}}", grossRevenue.ToString("C"))
                .Replace("{{STRIPE_FEES}}", stripeFees.ToString("C"))
                .Replace("{{NET_REVENUE}}", netRevenue.ToString("C"))
                .Replace("{{PENDING_PAYOUT}}", "N/A")
                .Replace("{{LAST_PAYOUT_AMOUNT}}", "N/A")
                .Replace("{{LAST_PAYOUT_DATE}}", "N/A")
                .Replace("{{NEXT_PAYOUT_DATE}}", "N/A")
                .Replace("{{DASHBOARD_URL}}", $"{_configuration["AppUrl"]}/Admin/DeveloperEarnings");

            await emailService.SendEmailAsync(
                rootEmail,
                $"💰 Daily Earnings Report - {yesterday:MMM dd}",
                emailBody,
                isHtml: true
            );

            _logger.LogInformation("Daily earnings report sent: {Amount} from {Orders} orders", totalAmount, totalOrders);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending daily earnings report");
        }
    }

    private async Task SendWeeklyReportAsync(IUnitOfWork unitOfWork, IEmailService emailService)
    {
        try
        {
            var lastWeekStart = DateTime.UtcNow.Date.AddDays(-7);
            var today = DateTime.UtcNow.Date;

            var allEarnings = await unitOfWork.Repository<Entity.DeveloperEarnings>().GetAllAsync();
            var weeklyEarnings = allEarnings
                .Where(de => de.EarnedAt >= lastWeekStart && de.EarnedAt < today)
                .ToList();

            if (!weeklyEarnings.Any())
            {
                _logger.LogInformation("No earnings for last week, skipping weekly report");
                return;
            }

            var totalAmount = weeklyEarnings.Sum(de => de.DeveloperCommission);
            var grossRevenue = weeklyEarnings.Sum(de => de.GrossAmount);
            var stripeFees = weeklyEarnings.Sum(de => de.StripeProcessingFee);
            var netRevenue = weeklyEarnings.Sum(de => de.NetAmount);
            var totalOrders = weeklyEarnings.Count;

            var rootEmail = _configuration["Email:Smtp:Username"];
            if (string.IsNullOrEmpty(rootEmail))
                return;

            var template = await emailService.LoadEmailTemplate("DeveloperEarningsSummary");
            var emailBody = template
                .Replace("{{PERIOD}}", $"Weekly Report - {lastWeekStart:MMM dd} to {today.AddDays(-1):MMM dd, yyyy}")
                .Replace("{{TOTAL_AMOUNT}}", totalAmount.ToString("C"))
                .Replace("{{TOTAL_ORDERS}}", totalOrders.ToString())
                .Replace("{{GROSS_REVENUE}}", grossRevenue.ToString("C"))
                .Replace("{{STRIPE_FEES}}", stripeFees.ToString("C"))
                .Replace("{{NET_REVENUE}}", netRevenue.ToString("C"))
                .Replace("{{PENDING_PAYOUT}}", "N/A")
                .Replace("{{LAST_PAYOUT_AMOUNT}}", "N/A")
                .Replace("{{LAST_PAYOUT_DATE}}", "N/A")
                .Replace("{{NEXT_PAYOUT_DATE}}", "N/A")
                .Replace("{{DASHBOARD_URL}}", $"{_configuration["AppUrl"]}/Admin/DeveloperEarnings");

            await emailService.SendEmailAsync(
                rootEmail,
                $"📊 Weekly Earnings Report - Week of {lastWeekStart:MMM dd}",
                emailBody,
                isHtml: true
            );

            _logger.LogInformation("Weekly earnings report sent: {Amount} from {Orders} orders", totalAmount, totalOrders);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending weekly earnings report");
        }
    }

    private async Task SendMonthlyReportAsync(IUnitOfWork unitOfWork, IEmailService emailService)
    {
        try
        {
            var lastMonthStart = DateTime.UtcNow.Date.AddMonths(-1).AddDays(1 - DateTime.UtcNow.Day);
            var thisMonthStart = DateTime.UtcNow.Date.AddDays(1 - DateTime.UtcNow.Day);

            var allEarnings = await unitOfWork.Repository<Entity.DeveloperEarnings>().GetAllAsync();
            var monthlyEarnings = allEarnings
                .Where(de => de.EarnedAt >= lastMonthStart && de.EarnedAt < thisMonthStart)
                .ToList();

            if (!monthlyEarnings.Any())
            {
                _logger.LogInformation("No earnings for last month, skipping monthly report");
                return;
            }

            var totalAmount = monthlyEarnings.Sum(de => de.DeveloperCommission);
            var grossRevenue = monthlyEarnings.Sum(de => de.GrossAmount);
            var stripeFees = monthlyEarnings.Sum(de => de.StripeProcessingFee);
            var netRevenue = monthlyEarnings.Sum(de => de.NetAmount);
            var totalOrders = monthlyEarnings.Count;
            var pending = monthlyEarnings.Where(de => de.PayoutStatus == Entity.PayoutStatus.Pending).Sum(de => de.DeveloperCommission);

            var rootEmail = _configuration["Email:Smtp:Username"];
            if (string.IsNullOrEmpty(rootEmail))
                return;

            var template = await emailService.LoadEmailTemplate("DeveloperEarningsSummary");
            var emailBody = template
                .Replace("{{PERIOD}}", $"Monthly Report - {lastMonthStart:MMMM yyyy}")
                .Replace("{{TOTAL_AMOUNT}}", totalAmount.ToString("C"))
                .Replace("{{TOTAL_ORDERS}}", totalOrders.ToString())
                .Replace("{{GROSS_REVENUE}}", grossRevenue.ToString("C"))
                .Replace("{{STRIPE_FEES}}", stripeFees.ToString("C"))
                .Replace("{{NET_REVENUE}}", netRevenue.ToString("C"))
                .Replace("{{PENDING_PAYOUT}}", pending.ToString("C"))
                .Replace("{{LAST_PAYOUT_AMOUNT}}", "N/A")
                .Replace("{{LAST_PAYOUT_DATE}}", "N/A")
                .Replace("{{NEXT_PAYOUT_DATE}}", "N/A")
                .Replace("{{DASHBOARD_URL}}", $"{_configuration["AppUrl"]}/Admin/DeveloperEarnings");

            await emailService.SendEmailAsync(
                rootEmail,
                $"📈 Monthly Earnings Report - {lastMonthStart:MMMM yyyy}",
                emailBody,
                isHtml: true
            );

            _logger.LogInformation("Monthly earnings report sent: {Amount} from {Orders} orders", totalAmount, totalOrders);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending monthly earnings report");
        }
    }
}
