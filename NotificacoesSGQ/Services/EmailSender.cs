using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using NotificacoesSGQ.Services.Interfaces;

namespace NotificacoesSGQ.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendEmail(string subject, string body, string recieve, string sender, string Emailhead)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(recieve);
            mail.From = new MailAddress(sender, Emailhead, System.Text.Encoding.UTF8);
            mail.Subject = subject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = body;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            var smtpUser = _configuration["StmpUser"];
            var stmpPassword = _configuration["StmpPassword"];
            var stmpHost = _configuration["StmpHost"];
            var stmpPort = Convert.ToInt32(_configuration["StmpPort"]);

            using (var client = new SmtpClient())
            {
                EmailConfigs(client, smtpUser, stmpPassword, stmpHost, stmpPort, false);
                client.Send(mail);
            }
        }

        public void SendEmail(string subject, string body, List<string> receivers, string sender, string Emailhead, FileAttachment attachmentFile)
        {
            MailMessage mail = new MailMessage();
            foreach (var receive in receivers)
            {
                mail.To.Add(receive);
            }
            mail.From = new MailAddress(sender, Emailhead, System.Text.Encoding.UTF8);
            mail.Subject = subject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = body;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            if (attachmentFile?.Content != null)
            {
                MemoryStream stream = new MemoryStream(attachmentFile.Content);
                Attachment attachment = new Attachment(stream, attachmentFile.Name);
                mail.Attachments.Add(attachment);
            }

            var smtpUser = _configuration["StmpUser"];
            var stmpPassword = _configuration["StmpPassword"];
            var stmpHost = _configuration["StmpHost"];
            var stmpPort = Convert.ToInt32(_configuration["StmpPort"]);

            using (var client = new SmtpClient())
            {
                EmailConfigs(client, smtpUser, stmpPassword, stmpHost, stmpPort, false);
                client.Send(mail);
            }
        }

        public void EmailConfigs(SmtpClient client, string account, string password, string host, int port, bool enableSsl)
        {
            client.Credentials = new System.Net.NetworkCredential(account, password);
            client.Port = port;
            client.Host = host;
            client.EnableSsl = enableSsl;
        }

        public void SendEmailSuportCoppy(string subject, string body, List<string> receivers, string sender, string Emailhead, FileAttachment attachmentFile)
        {
            var mail = new MailMessage();
            foreach (var receive in receivers)
            {
                mail.To.Add(receive);
            }


            mail.From = new MailAddress(sender, Emailhead, System.Text.Encoding.UTF8);
            mail.Subject = subject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = body;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            if (attachmentFile?.Content != null)
            {
                var stream = new MemoryStream(attachmentFile.Content);
                var attachment = new Attachment(stream, attachmentFile.Name);
                mail.Attachments.Add(attachment);
            }

            var smtpUser = _configuration["StmpUser"];
            var stmpPassword = _configuration["StmpPassword"];
            var stmpHost = _configuration["StmpHost"];
            var stmpPort = Convert.ToInt32(_configuration["StmpPort"]);

            using (var client = new SmtpClient())
            {
                EmailConfigs(client, smtpUser, stmpPassword, stmpHost, stmpPort, false);
                client.Send(mail);
            }
        }
    }
}
