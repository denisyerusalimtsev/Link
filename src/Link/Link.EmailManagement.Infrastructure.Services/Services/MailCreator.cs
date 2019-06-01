using System;
using Link.EmailManagement.Domain.Model.Entities;
using Link.EmailManagement.Domain.Services.Interfaces;
using System.IO;
using System.Net.Mail;

namespace Link.EmailManagement.Infrastructure.Services.Services
{
    public class MailCreator : IMailCreator
    {
        public string AddBody()
        {
            return "Thank you for using Link system, here is your cheque. Have a nice day. \n Regards, Link Team";
        }

        public string AddBody(Event ev, Expert expert)
        {
            var uri = new Uri($"https://localhost:60005/api/events/assign?eventId={ev.Id.Id}&expertId={expert.Id}");
            return $"Dear {expert.FullName}, \n would you like to join new event {ev.Name} in {ev.ExpertType.ToString()} profile, which is " +
                   $"you major specification. We need {ev.CountOfNeededExperts} experts, so join this event and help the world!" +
                   $"\n  {uri}"+
                   $"\n" +
                   $"\n Regards, Link Team";
        }

        public string AddSubject()
        {
            return "Link Notification";
        }

        public Attachment AddAttachment(Stream attachment)
        {
            return new Attachment(attachment, "LinkReport", "application/pdf");
        }
    }
}
