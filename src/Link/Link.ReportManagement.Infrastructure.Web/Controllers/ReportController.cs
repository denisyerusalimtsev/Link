using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Link.ReportManagement.Application;
using Link.ReportManagement.Application.Features.GenerateReport;
using Link.ReportManagement.Domain.Model.Entities;
using Link.ReportManagement.Infrastructure.Web.Models;

namespace Link.ReportManagement.Infrastructure.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly LinkApplication _app;

        public ReportController(LinkApplication app)
        {
            _app = app;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateReport([FromBody] ReportParameters parameters)
        {
            GenerateReportQuery query = new GenerateReportQuery(parameters);
            GenerateReportQueryResult result = await _app.RunQuery(query);

            return Ok(new GenerateReportDto()
            {
                Report = result.Report
            });
        }
    }
}
