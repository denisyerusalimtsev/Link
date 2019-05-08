using Link.ReportManagement.Domain.Model.Entities;
using Link.ReportManagement.Domain.Services.Interfaces;
using System.IO;

namespace Link.ReportManagement.Infrastructure.Services.Report
{
    public class ReportRenderer : IReportRenderer
    {
        public MemoryStream Render(ReportParameters parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
