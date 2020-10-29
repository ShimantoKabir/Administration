using Administration.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace Administration.Services
{
    public interface IMailer
    {
        Task SendEmailAsync(string email, string subject, string body);
    }

    public class Mailer : IMailer
    {
        private readonly SmtpSetting smtpSetting;
        private readonly IWebHostEnvironment env;

        public Mailer(IOptions<SmtpSetting> smtpSettings, IWebHostEnvironment env)
        {
            this.smtpSetting = smtpSettings.Value;
            this.env = env;
        }

        public async Task SendEmailAsync(string email, string subject, string body)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(smtpSetting.SenderName, smtpSetting.SenderEmail));
                message.To.Add(new MailboxAddress(email));
                message.Subject = subject;
                message.Body = new TextPart("html")
                {
                    Text = body
                };

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    if (env.IsDevelopment())
                    {
                        await client.ConnectAsync(smtpSetting.Server, smtpSetting.Port, true);
                    }
                    else
                    {
                        await client.ConnectAsync(smtpSetting.Server);
                    }

                    await client.AuthenticateAsync(smtpSetting.Username, smtpSetting.Password);
                    await client.SendAsync(message);
                    Console.WriteLine("SendAsync");
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}