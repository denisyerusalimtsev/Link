using System.IO;
using Link.Common.Domain.Framework.Frameworks;

namespace Link.ReportManagement.Application.Features.GenerateReport
{
    public sealed class GenerateReportQueryResult : IQueryResult
    {
        public GenerateReportQueryResult(MemoryStream report)
        {
            Report = report;
            Success = true;
        }

        public GenerateReportQueryResult(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }

        public MemoryStream Report { get; }

        public bool Success { get; }

        public string ErrorMessage { get; }
    }
}
