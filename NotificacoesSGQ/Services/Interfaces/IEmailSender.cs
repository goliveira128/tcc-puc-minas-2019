using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NotificacoesSGQ.Services.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(string subject, string body, string recieve, string sender, string Emailhead);
        void SendEmail(string subject, string body, List<String> receivers, string sender, string Emailhead, FileAttachment attachment);
        void SendEmailSuportCoppy(string subject, string body, List<String> receivers, string sender, string Emailhead, FileAttachment attachment);
        void EmailConfigs(SmtpClient client, string account, string password, string host, int port, bool enableSsl);
    }

    public class FileAttachment
    {
        public String Name { get; set; }
        public Byte[] Content { get; set; }
    }
}
