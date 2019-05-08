using System.Threading.Tasks;
using Link.Common.Domain.Framework.Frameworks;

namespace Link.ReportManagement.Application.Features.GenerateReport
{
    public sealed class GenerateReportQueryRunner : QueryRunner<GenerateReportQuery, GenerateReportQueryResult>
    {
        public override Task<GenerateReportQueryResult> Run(GenerateReportQuery query)
        {
            throw new System.NotImplementedException();
        }
    }
}
