using Link.EmailManagement.Domain.Services.Interfaces;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Link.EmailManagement.Domain.Model.Entities;

namespace Link.EmailManagement.Infrastructure.Services.Services
{
    public class MailBox : IMailBox
    {
        public async Task Send(Email mail)
        {
            var smtpClient = Build();
            using (var message = new MailMessage("ontouragetest@gmail.com", mail.EmailTo))
            {
                message.Subject = mail.Subject;
                message.Body = mail.Body;
                message.Attachments.Add(mail.Attachment);
                try
                {
                    await smtpClient.SendMailAsync(message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        private SmtpClient Build()
        {
            return new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("ontouragetest@gmail.com", "boulder840")
            };
        }
    }
}
