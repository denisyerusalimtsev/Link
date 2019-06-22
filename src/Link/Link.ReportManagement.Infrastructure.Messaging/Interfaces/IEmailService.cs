using Link.ReportManagement.Infrastructure.Models.Models;
using System.Threading.Tasks;

namespace Link.ReportManagement.Infrastructure.Messaging.Interfaces
{
    public interface IEmailService
    {
        Task SendFinishEventEmail(string fileName, UserDto userDto, EventDto eventDto);
    }
}
