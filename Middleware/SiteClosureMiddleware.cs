using Kokomija.Services;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace Kokomija.Middleware
{
    /// <summary>
    /// Middleware to block requests when site is closed for maintenance
    /// </summary>
    public class SiteClosureMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SiteClosureMiddleware> _logger;

        public SiteClosureMiddleware(RequestDelegate next, ILogger<SiteClosureMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, ISiteControlService siteControlService)
        {
            // Check if site is closed
            var isClosed = await siteControlService.IsSiteClosedAsync();
            
            if (!isClosed)
            {
                await _next(context);
                return;
            }

            // Allow access to specific paths even when closed
            var path = context.Request.Path.Value?.ToLower() ?? "";
            
            // Allow admin paths, maintenance page, and admin login
            if (path.StartsWith("/admin") || 
                path.StartsWith("/api/site-control") ||
                path.StartsWith("/api/email-command") ||
                path.StartsWith("/account/maintenancelogin") ||
                path.StartsWith("/home/maintenance") ||
                path.StartsWith("/signin-") ||  // Skip OAuth callbacks
                path.StartsWith("/account/externallogi") ||  // Skip external login callback
                path.StartsWith("/account/login") ||  // Allow regular login page access
                path.StartsWith("/account/logout"))  // Allow logout
            {
                await _next(context);
                return;
            }

            // Allow static files (CSS, JS, images for maintenance page)
            if (path.StartsWith("/css") || 
                path.StartsWith("/js") || 
                path.StartsWith("/images") ||
                path.StartsWith("/img") ||
                path.StartsWith("/lib") ||
                path.StartsWith("/wwwroot") ||
                path.Contains(".css") ||
                path.Contains(".js") ||
                path.Contains(".ico"))
            {
                await _next(context);
                return;
            }

            // Check if user is authenticated as admin
            if (context.User?.Identity?.IsAuthenticated == true && 
                (context.User.IsInRole("Admin") || context.User.IsInRole("Root")))
            {
                await _next(context);
                return;
            }

            // Get closure details
            var closure = await siteControlService.GetCurrentClosureAsync();
            
            _logger.LogWarning("Request blocked due to site closure: {Path}", path);

            // Redirect to maintenance page
            context.Response.Redirect("/Home/Maintenance");
        }

        private string GenerateMaintenancePage(Entity.SiteClosure? closure)
        {
            var reason = closure?.Reason ?? "Trwa konserwacja strony";
            var scheduledReopen = closure?.ScheduledReopenAt?.ToString("dd.MM.yyyy HH:mm") ?? "wkrótce";
            var daysClosed = closure?.ClosedAt.HasValue == true
                ? (int)(DateTime.UtcNow - closure.ClosedAt.Value).TotalDays
                : 0;

            return $@"
<!DOCTYPE html>
<html lang=""pl"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Kokomija - Strona w trakcie konserwacji</title>
    <style>
        * {{
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }}
        
        body {{
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            min-height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 20px;
        }}
        
        .container {{
            background: white;
            border-radius: 20px;
            box-shadow: 0 20px 60px rgba(0,0,0,0.3);
            max-width: 600px;
            width: 100%;
            padding: 50px 40px;
            text-align: center;
        }}
        
        .icon {{
            font-size: 80px;
            margin-bottom: 20px;
        }}
        
        h1 {{
            color: #333;
            font-size: 32px;
            margin-bottom: 15px;
        }}
        
        .reason {{
            color: #666;
            font-size: 18px;
            margin-bottom: 30px;
            line-height: 1.6;
        }}
        
        .info {{
            background: #f5f5f5;
            border-radius: 10px;
            padding: 20px;
            margin-bottom: 20px;
        }}
        
        .info-item {{
            margin: 10px 0;
            color: #555;
        }}
        
        .info-label {{
            font-weight: bold;
            color: #333;
        }}
        
        .emergency-access {{
            margin-top: 30px;
            padding-top: 30px;
            border-top: 1px solid #eee;
        }}
        
        .password-form {{
            display: flex;
            gap: 10px;
            max-width: 400px;
            margin: 20px auto 0;
        }}
        
        input[type=""password""] {{
            flex: 1;
            padding: 12px 20px;
            border: 2px solid #ddd;
            border-radius: 8px;
            font-size: 16px;
        }}
        
        input[type=""password""]:focus {{
            outline: none;
            border-color: #667eea;
        }}
        
        button {{
            padding: 12px 30px;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            border: none;
            border-radius: 8px;
            font-size: 16px;
            cursor: pointer;
            transition: transform 0.2s;
        }}
        
        button:hover {{
            transform: translateY(-2px);
        }}
        
        .footer {{
            margin-top: 30px;
            color: #999;
            font-size: 14px;
        }}
    </style>
</head>
<body>
    <div class=""container"">
        <div class=""icon"">🔧</div>
        <h1>Strona w trakcie konserwacji</h1>
        <p class=""reason"">{reason}</p>
        
        <div class=""info"">
            <div class=""info-item"">
                <span class=""info-label"">Przewidywane otwarcie:</span> {scheduledReopen}
            </div>
            <div class=""info-item"">
                <span class=""info-label"">Czas przestoju:</span> {daysClosed} dni
            </div>
        </div>
        
        <p style=""color: #666; margin: 20px 0;"">
            Przepraszamy za niedogodności. Wrócimy wkrótce!
        </p>
        
        <div class=""emergency-access"">
            <p style=""color: #999; font-size: 14px; margin-bottom: 15px;"">
                Dostęp awaryjny dla administratora
            </p>
            <form class=""password-form"" method=""POST"" action=""/admin/site-control/emergency-access"">
                <input type=""password"" name=""password"" placeholder=""Hasło awaryjne"" required />
                <button type=""submit"">Dostęp</button>
            </form>
        </div>
        
        <div class=""footer"">
            <p>© 2025 Kokomija. Wszystkie prawa zastrzeżone.</p>
        </div>
    </div>
</body>
</html>
            ";
        }
    }
}
