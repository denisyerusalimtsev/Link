using System.IO;
using System.Threading.Tasks;

namespace Link.EmailManagement.Domain.Services.Interfaces
{
    public interface IMailBox
    {
        Task Send(string subject, string body, Stream attachment);
    }
}
