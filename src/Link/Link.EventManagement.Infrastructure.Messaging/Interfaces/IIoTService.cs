using System.Threading.Tasks;

namespace Link.EventManagement.Infrastructure.Messaging.Interfaces
{
    public interface IIoTService
    {
        Task StartEvent(string expertId);

        Task StopEvent(string expertId);
    }
}
