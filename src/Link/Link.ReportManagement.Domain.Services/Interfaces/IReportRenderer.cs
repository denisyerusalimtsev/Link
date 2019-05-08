using System.IO;
using Link.ReportManagement.Domain.Model.Entities;

namespace Link.ReportManagement.Domain.Services.Interfaces
{
    public interface IReportRenderer
    {
        MemoryStream Render(ReportParameters parameters);
    }
}
