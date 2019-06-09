using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using Link.ReportManagement.Domain.Model.Entities;
using Link.ReportManagement.Domain.Services.Interfaces;
using System.IO;

namespace Link.ReportManagement.Infrastructure.Services.Report
{
    public class ReportRenderer : IReportRenderer
    {
        public MemoryStream Render(ReportParameters parameters)
        {
            var stream = new MemoryStream();
            return ConstructReport(stream, parameters);
        }

        private MemoryStream ConstructReport<T>(T stream, ReportParameters parameters)
            where T : MemoryStream
        {
            using (var writer = new PdfWriter(stream))
            using (var pdf = new PdfDocument(writer))
            using (var document = new Document(pdf, PageSize.A4))
            {
                writer.SetCloseStream(false);
                SetDocumentInfo(pdf.GetDocumentInfo());
                document.Add(new HeaderSection(parameters).Render())
                    .Add(new ReportParagraph(parameters).Render())
                    .Add(new ExpertsSection(parameters).Render());

            }
            var bytes = stream.ToArray();

            return new MemoryStream(bytes);
        }

        private void SetDocumentInfo(PdfDocumentInfo documentInfo)
        {
            documentInfo
                .SetCreator("Denis Yerusalimtsev")
                .SetSubject("Link report")
                .SetTitle("Link report");
        }
    }
}
