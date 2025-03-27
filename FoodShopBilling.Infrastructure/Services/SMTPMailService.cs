using FoodShopBilling.Application.Configurations;
using FoodShopBilling.Application.Interfaces.Services;
using FoodShopBilling.Utilities.Requests.Mail;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Infrastructure.Services
{
    public class SMTPMailService : IMailService
    {
        private readonly MailConfiguration _config;
        private readonly ILogger<SMTPMailService> _logger;

        public SMTPMailService(IOptions<MailConfiguration> config, ILogger<SMTPMailService> logger)
        {
            _config = config.Value;
            _logger = logger;
        }

        public async Task SendAsync(MailRequest request)
        {
            if (request.IsRelayServer)
            {
                try
                {
                    MailMessage email = new()
                    {
                        Sender = new MailAddress(_config.DisplayName, request.From ?? _config.From),
                        Subject = request.Subject,
                        Body = new BodyBuilder
                        {
                            HtmlBody = request.Body
                        }.ToMessageBody().ToString()
                    };
                    email.To.Add(new MailAddress(request.To));
                    email.From = new MailAddress(_config.From);
                    using (System.Net.Mail.SmtpClient smtp = new())
                    {
                        smtp.Host = _config.Host;
                        smtp.Port = _config.Port;
                        await smtp.SendMailAsync(email);
                    }

                }
                catch (System.Exception ex)
                {
                    _logger.LogError(ex.Message, ex);
                }
            }
            else
            {
                try
                {
                    MimeMessage email = new()
                    {
                        Sender = new MailboxAddress(_config.DisplayName, request.From ?? _config.From),
                        Subject = request.Subject,
                        Body = new BodyBuilder
                        {
                            HtmlBody = request.Body
                        }.ToMessageBody()
                    };
                    email.To.Add(MailboxAddress.Parse(request.To));
                    email.From.Add(MailboxAddress.Parse(_config.From));
                    using MailKit.Net.Smtp.SmtpClient smtp = new();
                    await smtp.ConnectAsync(_config.Host, _config.Port, SecureSocketOptions.StartTls);
                    await smtp.AuthenticateAsync(_config.UserName, _config.Password);
                    _ = await smtp.SendAsync(email);
                    await smtp.DisconnectAsync(true);
                }
                catch (System.Exception ex)
                {
                    _logger.LogError(ex.Message, ex);
                }
            }

        }

    }
}
