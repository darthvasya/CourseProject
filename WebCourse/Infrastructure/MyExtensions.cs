using Microsoft.AspNetCore.Http;
using System;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using System.Threading.Tasks;
using System.Net;

namespace WebCourse.Infrastructure {
    public static class MyExtensions {
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue
                ? $"{request.Path}{request.QueryString}"
                : request.Path.ToString();

        public static async Task<bool> SendEmailAsync(string email, string subject, string message) {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("YOUR NAME HERE", "YOUR EMAIL HERE"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            using (var client = new SmtpClient()) {
                try {
                    client.LocalDomain = "127.0.0.1";
                    await client.ConnectAsync("YOUR MAIL SMTP HERE", 25, SecureSocketOptions.Auto).ConfigureAwait(false);
                    await client.AuthenticateAsync(new NetworkCredential("YOUR EMAIL HERE", "YOUR PASS HERE"));
                    await client.SendAsync(emailMessage).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                    return true;
                }catch(Exception ex) {
                    return false;
                }

            }
        }
    }
}
