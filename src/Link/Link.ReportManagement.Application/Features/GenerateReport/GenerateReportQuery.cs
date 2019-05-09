using Link.Common.Domain.Framework.Frameworks;
using Link.ReportManagement.Domain.Model.Entities;

namespace Link.ReportManagement.Application.Features.GenerateReport
{
    public sealed class GenerateReportQuery : IQuery<GenerateReportQueryResult>
    {
        public GenerateReportQuery(ReportParameters parameters)
        {
            Parameters = parameters;
        }

        public ReportParameters Parameters { get; }
    }
}
