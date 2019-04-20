using System.Net.Mail;

namespace Link.EmailManagement.Domain.Services.Interfaces
{
    public interface IMailCreator
    {
        string AddBody();

        string AddSubject();

        Attachment AddAttachment();
    }
}
