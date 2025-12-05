using Kokomija.Data.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Kokomija.Middleware
{
    /// <summary>
    /// Middleware to check if site is closed and block non-ROOT users
    /// </summary>
    public class SiteClosureCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SiteClosureCheckMiddleware> _logger;

        public SiteClosureCheckMiddleware(RequestDelegate next, ILogger<SiteClosureCheckMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, IUnitOfWork unitOfWork, UserManager<Entity.ApplicationUser> userManager)
        {
            // Skip middleware for static files and specific paths
            var path = context.Request.Path.Value?.ToLower() ?? string.Empty;
            
            if (path.StartsWith("/css") || 
                path.StartsWith("/js") || 
                path.StartsWith("/lib") || 
                path.StartsWith("/images") ||
                path.StartsWith("/uploads") ||
                path.StartsWith("/favicon.ico") ||
                path.StartsWith("/api/stripewebhook"))
            {
                await _next(context);
                return;
            }

            // Check if site is closed
            var allClosures = await unitOfWork.SiteClosures.GetAllAsync();
            var activeClosure = allClosures.FirstOrDefault(sc => sc.IsClosed);

            if (activeClosure != null)
            {
                // Check if user is ROOT
                var isRoot = false;
                var currentUserName = "Anonymous";
                
                if (context.User?.Identity?.IsAuthenticated == true)
                {
                    var userName = context.User.Identity.Name;
                    if (!string.IsNullOrEmpty(userName))
                    {
                        currentUserName = userName;
                        var user = await userManager.FindByNameAsync(userName);
                        if (user != null)
                        {
                            isRoot = await userManager.IsInRoleAsync(user, "Root");
                        }
                    }
                }

                // Block non-ROOT users
                if (!isRoot)
                {
                    // Allow access to login page for ROOT to login
                    if (path.StartsWith("/account/login") || 
                        path.StartsWith("/account/logout"))
                    {
                        await _next(context);
                        return;
                    }

                    _logger.LogWarning("Site is closed. Blocking request from {IP} to {Path}", 
                        context.Connection.RemoteIpAddress, 
                        context.Request.Path);

                    // Set response
                    context.Response.StatusCode = 503; // Service Unavailable
                    context.Response.ContentType = "text/html; charset=utf-8";

                    var html = GenerateSiteClosedHtml(activeClosure.Reason, activeClosure.ScheduledReopenAt);
                    await context.Response.WriteAsync(html);
                    return;
                }
                else
                {
                    _logger.LogInformation("ROOT user {User} accessing site during closure", currentUserName);
                }
            }

            await _next(context);
        }

        private string GenerateSiteClosedHtml(string? reason, DateTime? reopenDate)
        {
            var reopenText = reopenDate.HasValue 
                ? $"<p class=\"reopen-date\">Scheduled to reopen: {reopenDate.Value:MMMM dd, yyyy HH:mm} UTC</p>"
                : "";

            return $@"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Site Temporarily Unavailable - Kokomija</title>
    <style>
        * {{
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }}
        
        body {{
            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, sans-serif;
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
            padding: 60px 40px;
            text-align: center;
        }}
        
        .icon {{
            width: 120px;
            height: 120px;
            margin: 0 auto 30px;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 60px;
            color: white;
        }}
        
        h1 {{
            font-size: 32px;
            color: #333;
            margin-bottom: 20px;
            font-weight: 700;
        }}
        
        .reason {{
            font-size: 18px;
            color: #666;
            line-height: 1.6;
            margin-bottom: 30px;
        }}
        
        .reopen-date {{
            background: #f8f9fa;
            padding: 15px;
            border-radius: 10px;
            color: #495057;
            font-weight: 500;
            margin-bottom: 30px;
        }}
        
        .info {{
            font-size: 14px;
            color: #999;
            line-height: 1.6;
        }}
        
        .login-link {{
            margin-top: 30px;
            padding-top: 30px;
            border-top: 1px solid #eee;
        }}
        
        .login-link a {{
            color: #667eea;
            text-decoration: none;
            font-weight: 600;
            transition: color 0.3s;
        }}
        
        .login-link a:hover {{
            color: #764ba2;
        }}
        
        @media (max-width: 768px) {{
            .container {{
                padding: 40px 25px;
            }}
            
            h1 {{
                font-size: 24px;
            }}
            
            .reason {{
                font-size: 16px;
            }}
        }}
    </style>
</head>
<body>
    <div class=""container"">
        <div class=""icon"">
            🔧
        </div>
        <h1>Site Temporarily Unavailable</h1>
        <div class=""reason"">
            {(string.IsNullOrEmpty(reason) ? "We're currently performing scheduled maintenance to improve your experience." : System.Net.WebUtility.HtmlEncode(reason))}
        </div>
        {reopenText}
        <div class=""info"">
            We apologize for any inconvenience. Please check back soon!
        </div>
        <div class=""login-link"">
            <small>Administrator? <a href=""/Account/Login"">Sign in here</a></small>
        </div>
    </div>
</body>
</html>";
        }
    }
}
