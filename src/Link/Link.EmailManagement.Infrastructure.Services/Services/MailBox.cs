using Link.EmailManagement.Domain.Services.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Link.EmailManagement.Infrastructure.Services.Services
{
    public class MailBox : IMailBox
    {
        public async Task Send(string subject, string body, Stream attachment)
        {
            var smtpClient = Build();
            using (var message = new MailMessage("ontouragetest@gmail.com", "denis.yerusalimtsev@gmail.com"))
            {
                message.Subject = "Copter rent";
                message.Body = "Thank you for using Around system, here is your cheque. Have a nice day. Regards, Around Team";
                message.Attachments.Add(new Attachment(attachment, "AroundCheque", "application/pdf"));
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
