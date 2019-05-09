using Link.Common.Domain.Framework.Frameworks;
using Link.ReportManagement.Domain.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Link.ReportManagement.Application.Features.GenerateReport
{
    public sealed class GenerateReportQueryRunner : QueryRunner<GenerateReportQuery, GenerateReportQueryResult>
    {
        private readonly IReportRenderer _renderer;

        public GenerateReportQueryRunner(IReportRenderer renderer)
        {
            _renderer = renderer;
        }

        public override async Task<GenerateReportQueryResult> Run(GenerateReportQuery query)
        {
            try
            {
                var report = await Task.Run(() => _renderer.Render(query.Parameters));
                return new GenerateReportQueryResult(report);
            }
            catch (Exception message)
            {
                return new GenerateReportQueryResult(message.Message);
            }
        }
    }
}
