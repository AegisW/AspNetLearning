using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Utility
{
    public class EmailSender : IEmailSender
    {
        public string EmailSenderAddress { get; set; }
        public string EmailSenderSecret { get; set; }
        public EmailSender(IConfiguration _config)
        {
            EmailSenderAddress = _config.GetValue<string>("Email:Address");
            EmailSenderSecret = _config.GetValue<string>("Email:SecretKey");
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //var emailToSend = new MimeMessage();
            //emailToSend.From.Add(MailboxAddress.Parse("hello@gmail.com"));
            //emailToSend.To.Add(MailboxAddress.Parse(email));
            //emailToSend.Subject = subject;
            //emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html){ Text = htmlMessage };

            ////send email
            //using (var emailClient = new SmtpClient())
            //{
            //    emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            //    emailClient.Authenticate(EmailSenderAddress, EmailSenderSecret);
            //    emailClient.Send(emailToSend);
            //    emailClient.Disconnect(true);
            //}

            return Task.CompletedTask;
        }
    }
}
