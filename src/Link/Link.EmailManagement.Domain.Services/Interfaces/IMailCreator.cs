using Link.EmailManagement.Domain.Model.Entities;
using System.IO;
using System.Net.Mail;

namespace Link.EmailManagement.Domain.Services.Interfaces
{
    public interface IMailCreator
    {
        string AddBody(Event ev);

        string AddBody(Event ev, Expert expert);

        string AddSubject();

        Attachment AddAttachment(Stream attachment);
    }
}
