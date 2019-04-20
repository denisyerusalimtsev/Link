using System.Net.Mail;
using Link.EmailManagement.Domain.Services.Interfaces;

namespace Link.EmailManagement.Infrastructure.Services.Services
{
    public class MailCreator : IMailCreator
    {
        public string AddBody()
        {
            return "Thank you for using Link system, here is your cheque. Have a nice day. Regards, Around Team"; ;
        }

        public string AddSubject()
        {
            return "Link Notification";
        }

        public Attachment AddAttachment()
        {
            throw new System.NotImplementedException();
        }
    }
}
