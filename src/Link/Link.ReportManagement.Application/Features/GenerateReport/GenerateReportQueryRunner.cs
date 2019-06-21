using Link.Common.Domain.Framework.Frameworks;
using Link.ReportManagement.Domain.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Link.ReportManagement.Application.Features.GenerateReport
{
    public sealed class GenerateReportQueryRunner : QueryRunner<GenerateReportQuery, GenerateReportQueryResult>
    {
        private readonly IReportRenderer _renderer;
        private readonly IReportUploader _reportUploader;

        public GenerateReportQueryRunner(
            IReportRenderer renderer,
            IReportUploader reportUploader)
        {
            _renderer = renderer;
            _reportUploader = reportUploader;
        }

        public override async Task<GenerateReportQueryResult> Run(GenerateReportQuery query)
        {
            try
            {
                var report = await Task.Run(() => _renderer.Render(query.Parameters));
                string fileName = await _reportUploader.UploadToBlodAsync("LinkReport.pdf", report.ToArray(), "application/pdf");
                return new GenerateReportQueryResult(fileName, "linkblob");
            }
            catch (Exception message)
            {
                return new GenerateReportQueryResult(message.Message);
            }
        }
    }
}
