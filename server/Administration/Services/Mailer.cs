using Administration.Models;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Security;
using Microsoft.Extensions.Configuration;

namespace Administration.Services
{
    public class Mailer
    {
        public async Task send(EmailRequest emailRequest)
        {
            var smtpSetting = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build()
                .GetSection("SmtpSetting");

            var mimeMessage = new MimeMessage
            {
                Sender = MailboxAddress.Parse(smtpSetting["Email"]),
                Subject = emailRequest.subject
            };

            foreach (var email in emailRequest.emails)
            {
                mimeMessage.To.Add(MailboxAddress.Parse(email));
            }

            var bodyBuilder = new BodyBuilder();
            if (emailRequest.attachments != null)
            {
                foreach (var file in emailRequest.attachments.Where(file => file.Length > 0))
                {
                    byte[] fileBytes;
                    await using (var ms = new MemoryStream())
                    {
                        await file.CopyToAsync(ms);
                        fileBytes = ms.ToArray();
                    }

                    bodyBuilder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                }
            }

            bodyBuilder.HtmlBody = emailRequest.body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            var smtp = new SmtpClient();
            await smtp.ConnectAsync(
                smtpSetting["Host"],
                Convert.ToInt16(smtpSetting["Port"]),
                SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(smtpSetting["Email"], smtpSetting["Password"]);
            await smtp.SendAsync(mimeMessage);
            await smtp.DisconnectAsync(true);
        }
    }
}