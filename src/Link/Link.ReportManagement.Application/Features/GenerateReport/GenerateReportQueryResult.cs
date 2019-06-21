using Link.Common.Domain.Framework.Frameworks;

namespace Link.ReportManagement.Application.Features.GenerateReport
{
    public sealed class GenerateReportQueryResult : IQueryResult
    {
        public GenerateReportQueryResult(string fileName, string containerName)
        {
            FileName = fileName;
            ContainerName = containerName;
            Success = true;
        }

        public GenerateReportQueryResult(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }

        public string FileName { get; }

        public string ContainerName { get; }

        public bool Success { get; }

        public string ErrorMessage { get; }
    }
}
