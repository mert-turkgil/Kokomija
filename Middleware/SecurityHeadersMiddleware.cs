namespace Kokomija.Middleware
{
    /// <summary>
    /// Adds security headers to all HTTP responses
    /// Implements OWASP best practices for e-commerce sites
    /// </summary>
    public class SecurityHeadersMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public SecurityHeadersMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Remove server information disclosure
            context.Response.Headers.Remove("Server");
            context.Response.Headers.Remove("X-Powered-By");

            // Prevent clickjacking attacks
            context.Response.Headers.Append("X-Frame-Options", "SAMEORIGIN");

            // Prevent MIME type sniffing
            context.Response.Headers.Append("X-Content-Type-Options", "nosniff");

            // Enable XSS protection
            context.Response.Headers.Append("X-XSS-Protection", "1; mode=block");

            // Referrer Policy - control referrer information
            context.Response.Headers.Append("Referrer-Policy", "strict-origin-when-cross-origin");

            // Permissions Policy (formerly Feature Policy)
            // Disable unnecessary browser features
            context.Response.Headers.Append("Permissions-Policy",
                "accelerometer=(), " +
                "camera=(), " +
                "geolocation=(), " +
                "gyroscope=(), " +
                "magnetometer=(), " +
                "microphone=(), " +
                "payment=(self), " + // Allow payment on same origin
                "usb=()");

            // Content Security Policy (CSP)
            // NOTE: Adjust based on your actual external resources (CDNs, Stripe, etc.)
            var cspPolicy = _configuration.GetValue<string>("Security:ContentSecurityPolicy") ??
                "default-src 'self'; " +
                "script-src 'self' 'unsafe-inline' 'unsafe-eval' https://js.stripe.com https://cdn.jsdelivr.net https://cdnjs.cloudflare.com https://challenges.cloudflare.com https://api.stripe.com https://cdn.ckeditor.com; " +
                "style-src 'self' 'unsafe-inline' https://cdn.jsdelivr.net https://cdnjs.cloudflare.com https://fonts.googleapis.com https://cdn.ckeditor.com; " +
                "img-src 'self' data: https: blob:; " +
                "font-src 'self' data: https://cdn.jsdelivr.net https://cdnjs.cloudflare.com https://fonts.gstatic.com https://fonts.googleapis.com; " +
                "connect-src 'self' https://api.stripe.com https://challenges.cloudflare.com wss://localhost:* ws://localhost:*; " +
                "frame-src 'self' https://js.stripe.com https://hooks.stripe.com https://challenges.cloudflare.com; " +
                "object-src 'none'; " +
                "base-uri 'self'; " +
                "form-action 'self' https: " + // Allow form submission to any HTTPS origin
                "frame-ancestors 'self';";

            context.Response.Headers.Append("Content-Security-Policy", cspPolicy);

            await _next(context);
        }
    }

    /// <summary>
    /// Extension method to easily add security headers middleware
    /// </summary>
    public static class SecurityHeadersMiddlewareExtensions
    {
        public static IApplicationBuilder UseSecurityHeaders(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SecurityHeadersMiddleware>();
        }
    }
}
