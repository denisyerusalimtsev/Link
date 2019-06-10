using Link.EventManagement.Infrastructure.Messaging.Models;
using System.IO;
using System.Threading.Tasks;

namespace Link.EventManagement.Infrastructure.Messaging.Interfaces
{
    public interface IReportService
    {
        Task<MemoryStream> GetReportAsync(ReportParameters parameters);
    }
}
