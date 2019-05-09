using System.IO;

namespace Link.ReportManagement.Infrastructure.Web.Models
{
    public class GenerateReportDto
    {
        public MemoryStream Report { get; set; }
    }
}
