using System.Threading.Tasks;

namespace Link.IoT.Hub.Cloud.Azure.Interfaces
{
    public interface IIoTHub
    {
        Task StartProjectWithExpertAsync(string expertId);

        Task FinishProjectWithExpertAsync(string expertId);
    }
}
