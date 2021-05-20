using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Options;
using myprojectgym.DTO.DTONotification;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace myprojectgym.DAL.DALNotification
{
    public class DALNotification : IDALNotification
    {
        private const string templatepath = @"EmailTemplate/{0}.html";
        private readonly DTONotification _SMTPConfig;

        public DALNotification(IOptions<DTONotification> SMTPConfig)
        {
            _SMTPConfig = SMTPConfig.Value;
        }
        public async Task SendTestEmail(UserEmailOptions userEmail)
        {
            userEmail.Subject = "this is an test email";
            userEmail.Body = GetEmailBody("EmailTemplate");

            await SendEmail(userEmail);
        }
        private async Task SendEmail(UserEmailOptions userEmail)
        {
            MailMessage mail = new MailMessage
            {
                Subject = userEmail.Subject,
                Body = userEmail.Body,
                From = new MailAddress(_SMTPConfig.SenderAddress, _SMTPConfig.SenderDisplayName),
                IsBodyHtml = _SMTPConfig.IsBodyHtml

            };
            foreach (var ToEmail in userEmail.ToEmails)
            {
                mail.To.Add(ToEmail);
            }
            NetworkCredential credential = new NetworkCredential(_SMTPConfig.UserName, _SMTPConfig.Password);
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _SMTPConfig.host,
                Port = _SMTPConfig.Port,
                EnableSsl = _SMTPConfig.EnableSSL,
                UseDefaultCredentials = _SMTPConfig.UseDefaultCredential,
                Credentials = credential

            };
            mail.BodyEncoding = Encoding.Default;
            await smtpClient.SendMailAsync(mail);
        }
        private string GetEmailBody(string templatename)
        {
            var body = File.ReadAllText(string.Format(templatepath, templatename));
            return body;
        }
    }
}
