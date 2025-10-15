# Email & Turnstile Configuration Guide

## Overview
This guide covers the SMTP email service and Cloudflare Turnstile (CAPTCHA alternative) configuration for Kokomija e-commerce platform.

---

## 🔐 Security Notice

**IMPORTANT:** The following files contain sensitive credentials and are excluded from Git:
- ✅ `appsettings.Development.json` - Added to `.gitignore`
- ✅ `appsettings.Production.json` - Added to `.gitignore`

**NEVER commit these files to GitHub!**

The base `appsettings.json` contains only placeholder values and is safe to commit.

---

## 📧 Email Service (SMTP)

### Features
- ✅ **SMTP Configuration** - Works with any SMTP provider
- ✅ **HTML & Plain Text** - Support for both email formats
- ✅ **Attachments** - Send invoices, receipts, etc.
- ✅ **Bulk Emails** - Newsletter, promotions
- ✅ **Reply-To Support** - Customer service emails
- ✅ **Error Logging** - Failed emails logged for debugging

### Use Cases
1. **Order Confirmations** - After successful checkout
2. **Password Reset** - Forgot password emails
3. **Account Verification** - Email confirmation links
4. **Shipping Notifications** - Order status updates
5. **Promotional Emails** - Marketing campaigns
6. **Invoices** - PDF attachments

### Implementation

#### Interface
```csharp
public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body, bool isHtml = true);
    Task SendEmailAsync(string to, string subject, string body, string? replyTo, bool isHtml = true);
    Task SendEmailWithAttachmentAsync(string to, string subject, string body, string attachmentPath, bool isHtml = true);
    Task SendBulkEmailAsync(List<string> recipients, string subject, string body, bool isHtml = true);
}
```

#### Usage Examples

**Basic Email:**
```csharp
@inject IEmailService EmailService

await EmailService.SendEmailAsync(
    to: "customer@example.com",
    subject: "Dziękujemy za zamówienie!",
    body: "<h1>Twoje zamówienie zostało przyjęte</h1>",
    isHtml: true
);
```

**With Reply-To:**
```csharp
await EmailService.SendEmailAsync(
    to: "customer@example.com",
    subject: "Re: Your Support Request",
    body: "Thank you for contacting us...",
    replyTo: "support@kokomija.com",
    isHtml: true
);
```

**With Attachment:**
```csharp
await EmailService.SendEmailWithAttachmentAsync(
    to: "customer@example.com",
    subject: "Your Invoice",
    body: "Please find your invoice attached.",
    attachmentPath: "/path/to/invoice.pdf",
    isHtml: true
);
```

**Bulk Email:**
```csharp
var recipients = new List<string> 
{ 
    "customer1@example.com", 
    "customer2@example.com" 
};

await EmailService.SendBulkEmailAsync(
    recipients: recipients,
    subject: "New Products Available!",
    body: "<html>...</html>",
    isHtml: true
);
```

---

## 📨 SMTP Configuration

### Development (Mailtrap - Email Testing)

**Mailtrap.io** - Captures all emails in development (no real emails sent)

```json
{
  "Email": {
    "Smtp": {
      "Host": "smtp.mailtrap.io",
      "Port": 2525,
      "EnableSsl": true,
      "Username": "YOUR_MAILTRAP_USERNAME",
      "Password": "YOUR_MAILTRAP_PASSWORD",
      "FromEmail": "dev@kokomija.local",
      "FromName": "Kokomija Dev",
      "Timeout": 30000
    }
  }
}
```

**Setup Steps:**
1. Go to https://mailtrap.io and create free account
2. Navigate to Email Testing → Inboxes
3. Copy SMTP credentials
4. Update `appsettings.Development.json`
5. All emails will appear in Mailtrap inbox

### Production (Gmail Example)

**Gmail SMTP** - Real emails for production

```json
{
  "Email": {
    "Smtp": {
      "Host": "smtp.gmail.com",
      "Port": 587,
      "EnableSsl": true,
      "Username": "your-business-email@gmail.com",
      "Password": "YOUR_APP_SPECIFIC_PASSWORD",
      "FromEmail": "noreply@kokomija.com",
      "FromName": "Kokomija",
      "Timeout": 30000
    }
  }
}
```

**Gmail Setup:**
1. Enable 2-Factor Authentication on Google Account
2. Go to: https://myaccount.google.com/apppasswords
3. Create App Password for "Mail"
4. Copy 16-character password
5. Update `appsettings.Production.json` with app password

### Alternative SMTP Providers

#### SendGrid (Recommended for Production)
```json
{
  "Host": "smtp.sendgrid.net",
  "Port": 587,
  "Username": "apikey",
  "Password": "YOUR_SENDGRID_API_KEY"
}
```

#### AWS SES (Amazon)
```json
{
  "Host": "email-smtp.eu-west-1.amazonaws.com",
  "Port": 587,
  "Username": "YOUR_SMTP_USERNAME",
  "Password": "YOUR_SMTP_PASSWORD"
}
```

#### Mailgun
```json
{
  "Host": "smtp.mailgun.org",
  "Port": 587,
  "Username": "postmaster@yourdomain.com",
  "Password": "YOUR_MAILGUN_PASSWORD"
}
```

#### Office 365
```json
{
  "Host": "smtp.office365.com",
  "Port": 587,
  "Username": "your-email@yourdomain.com",
  "Password": "YOUR_PASSWORD"
}
```

---

## 🛡️ Cloudflare Turnstile (CAPTCHA Alternative)

### What is Turnstile?
Cloudflare Turnstile is a privacy-focused alternative to reCAPTCHA that:
- ✅ **No user interaction** required in most cases
- ✅ **Privacy-first** - No tracking or fingerprinting
- ✅ **Fast** - Completes in milliseconds
- ✅ **Free** - Unlimited verifications
- ✅ **GDPR compliant** - No cookies for EU users

### Use Cases
1. **Login Forms** - Prevent brute force attacks
2. **Registration** - Stop bot signups
3. **Contact Forms** - Reduce spam
4. **Checkout** - Prevent automated purchases
5. **Password Reset** - Protect reset endpoint
6. **Reviews** - Stop fake reviews

### Configuration

#### Development (Test Keys)
```json
{
  "Turnstile": {
    "SiteKey": "1x00000000000000000000AA",
    "SecretKey": "1x0000000000000000000000000000000AA"
  }
}
```

**Test keys always pass** - Use for local development

#### Production (Real Keys)
```json
{
  "Turnstile": {
    "SiteKey": "0x4AAAAAAA...",
    "SecretKey": "0x4AAAAAAA..."
  }
}
```

**Get Production Keys:**
1. Go to https://dash.cloudflare.com/
2. Navigate to Turnstile
3. Create new site widget
4. Choose "Managed" mode (recommended)
5. Add your domain: `kokomija.com`
6. Copy Site Key and Secret Key
7. Update `appsettings.Production.json`

### Frontend Implementation

#### Add Turnstile Widget to Form
```html
<!-- In your form (Login, Register, etc.) -->
<form method="post">
    <!-- Your form fields -->
    <input type="email" name="email" required />
    <input type="password" name="password" required />
    
    <!-- Cloudflare Turnstile Widget -->
    <div class="cf-turnstile" 
         data-sitekey="@Configuration["Turnstile:SiteKey"]"
         data-theme="light"
         data-language="pl"></div>
    
    <button type="submit">Login</button>
</form>

<!-- Load Turnstile Script -->
<script src="https://challenges.cloudflare.com/turnstile/v0/api.js" async defer></script>
```

#### Widget Options
```html
<div class="cf-turnstile"
     data-sitekey="YOUR_SITE_KEY"
     data-theme="light"           <!-- light or dark or auto -->
     data-language="pl"            <!-- Polish: pl, English: en -->
     data-action="login"           <!-- Track different actions -->
     data-size="normal"            <!-- normal, compact, flexible -->
     data-callback="onSuccess"    <!-- JavaScript callback -->
     data-error-callback="onError"
     data-expired-callback="onExpire"></div>
```

### Backend Verification

#### In Controller
```csharp
[HttpPost]
public async Task<IActionResult> Login(LoginViewModel model)
{
    // Get Turnstile token from form
    var turnstileToken = Request.Form["cf-turnstile-response"];
    
    if (string.IsNullOrEmpty(turnstileToken))
    {
        ModelState.AddModelError("", "Please complete the verification");
        return View(model);
    }
    
    // Verify token with Turnstile service
    var result = await _turnstileService.VerifyTokenAsync(
        token: turnstileToken,
        remoteIp: HttpContext.Connection.RemoteIpAddress?.ToString()
    );
    
    if (!result.Success)
    {
        ModelState.AddModelError("", "Verification failed. Please try again.");
        return View(model);
    }
    
    // Continue with login logic...
    // ...
}
```

#### Verification Result
```csharp
public class TurnstileVerificationResult
{
    public bool Success { get; set; }
    public string? ChallengeTs { get; set; }    // Timestamp
    public string? Hostname { get; set; }       // Your domain
    public string[] ErrorCodes { get; set; }    // Error details
    public string? Action { get; set; }         // Action name
}
```

#### Error Codes
- `missing-input-secret` - Secret key not configured
- `invalid-input-secret` - Secret key invalid
- `missing-input-response` - Token missing
- `invalid-input-response` - Token invalid or expired
- `timeout-or-duplicate` - Token already used or expired

---

## 🔒 Security Best Practices

### SMTP Security
1. ✅ **Use App Passwords** - Never use your real Gmail password
2. ✅ **Enable SSL/TLS** - Always set `EnableSsl: true`
3. ✅ **Rotate Credentials** - Change passwords regularly
4. ✅ **Monitor Failed Logins** - Check logs for authentication failures
5. ✅ **Use Dedicated Email** - Use `noreply@` or `no-reply@`
6. ✅ **Rate Limiting** - Prevent email flooding

### Turnstile Security
1. ✅ **Verify Server-Side** - Always validate on backend
2. ✅ **Check Hostname** - Verify token came from your domain
3. ✅ **One-Time Use** - Tokens expire after verification
4. ✅ **Log Failures** - Monitor suspicious activity
5. ✅ **Use Actions** - Track which form was submitted
6. ✅ **IP Validation** - Pass user's IP for extra security

---

## 🧪 Testing

### Test SMTP in Development
```bash
# Send test email
dotnet run

# Then in browser/Postman:
POST /api/test/send-email
{
  "to": "test@example.com",
  "subject": "Test Email",
  "body": "This is a test email"
}

# Check Mailtrap inbox for email
```

### Test Turnstile in Development
```bash
# Development keys always pass
# Just add widget to form with test keys
# No need for real verification in dev
```

### Test in Production
```bash
# SMTP: Send real email to your address
# Turnstile: Complete challenge on live form
# Check logs for any errors
```

---

## 📊 Configuration Summary

### appsettings.json (Placeholders - Safe to commit)
```json
{
  "Email": {
    "Smtp": {
      "Host": "smtp.example.com",
      "Port": 587,
      "EnableSsl": true,
      "Username": "your-email@example.com",
      "Password": "YOUR_SMTP_PASSWORD",
      "FromEmail": "noreply@kokomija.com",
      "FromName": "Kokomija",
      "Timeout": 30000
    }
  },
  "Turnstile": {
    "SiteKey": "YOUR_TURNSTILE_SITE_KEY",
    "SecretKey": "YOUR_TURNSTILE_SECRET_KEY"
  }
}
```

### appsettings.Development.json (Real values - NOT committed)
- Mailtrap SMTP credentials
- Turnstile test keys (always pass)
- Safe for testing

### appsettings.Production.json (Real values - NOT committed)
- Gmail/SendGrid SMTP credentials
- Real Turnstile keys
- Production domain

---

## 🚀 Quick Start

### 1. Setup Email (Development)
```bash
# Create Mailtrap account at mailtrap.io
# Update appsettings.Development.json with credentials
# Restart application
```

### 2. Setup Turnstile (Development)
```bash
# Use test keys in appsettings.Development.json (already configured)
# Add widget to your forms
# No additional setup needed
```

### 3. Setup Email (Production)
```bash
# Choose SMTP provider (Gmail, SendGrid, etc.)
# Generate app-specific password
# Update appsettings.Production.json
# Test with real email
```

### 4. Setup Turnstile (Production)
```bash
# Go to dash.cloudflare.com
# Create Turnstile site widget
# Add your domain
# Copy keys to appsettings.Production.json
# Update CSP to allow Cloudflare domains (already done)
```

---

## 📁 Files Modified/Created

### New Files
- `Services/EmailService.cs` - SMTP email service
- `Services/TurnstileService.cs` - Turnstile verification
- `.gitignore` - Protect sensitive files

### Modified Files
- `Program.cs` - Registered email and Turnstile services
- `appsettings.json` - Added Email and Turnstile placeholders
- `appsettings.Development.json` - Added test SMTP and Turnstile configs
- `appsettings.Production.json` - Added production SMTP and Turnstile configs

---

## ⚠️ Before Pushing to GitHub

### Checklist
- [ ] Verify `.gitignore` includes sensitive files
- [ ] Check `appsettings.Development.json` is NOT staged
- [ ] Check `appsettings.Production.json` is NOT staged
- [ ] Verify only `appsettings.json` (placeholders) is staged
- [ ] Remove any hardcoded credentials from code
- [ ] Review commit for sensitive data

### Git Commands
```bash
# Check status
git status

# Verify excluded files
git ls-files --others --ignored --exclude-standard

# If sensitive files are tracked, remove them:
git rm --cached appsettings.Development.json
git rm --cached appsettings.Production.json

# Then commit
git add .
git commit -m "Add email service and Turnstile configuration"
git push origin main
```

---

## 🎯 Next Steps

### Immediate
1. Create email templates (Order confirmation, Password reset)
2. Add Turnstile to Login form
3. Add Turnstile to Registration form
4. Test email sending in development

### Short-term
- Create email service for order confirmations
- Add forgot password functionality with email
- Implement email verification for new accounts
- Add Turnstile to contact form

### Long-term
- Create newsletter subscription system
- Implement email marketing campaigns
- Add email preference center
- Monitor email delivery rates

---

**Status:** ✅ Email Service and Turnstile Ready
**Security:** 🔒 Sensitive files protected by .gitignore
**Ready for:** Order emails, Password resets, Bot protection
