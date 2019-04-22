using Link.Common.Domain.Framework.Models;
using System.Net.Mail;

namespace Link.EmailManagement.Domain.Model.Entities
{
    public class Email : AggregateRoot<Email>
    {
        public Email(
            string emailTo, 
            string subject,
            string body,
            Attachment attachment)
        {
            EmailTo = emailTo;
            Subject = subject;
            Body = body;
            Attachment = attachment;
        }

        public string EmailTo { get; }

        public string Subject { get; }

        public string Body { get; }

        public Attachment Attachment { get; }
    }
}
