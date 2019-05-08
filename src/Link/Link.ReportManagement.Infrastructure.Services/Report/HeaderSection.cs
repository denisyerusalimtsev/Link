using iText.Kernel.Colors;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Link.ReportManagement.Domain.Model.Entities;
using System.Collections.Generic;

namespace Link.ReportManagement.Infrastructure.Services.Report
{
    public class HeaderSection
    {
        private readonly ReportParameters _parameters;
        public HeaderSection(ReportParameters parameters)
        {
            _parameters = parameters;
        }

        public IBlockElement Render()
        {
            Table table = new Table(2)
                .SetWidth(510)
                .SetMarginLeft(18);

            foreach (ReportLine reportLine in Construct())
            {
                table.AddCell(new Cell()
                    .AddStyle(SetHeaderStyle())
                    .Add(reportLine.Label));

                table.AddCell(new Cell()
                    .AddStyle(SetNeurocheckStyle())
                    .Add(reportLine.Value));
            }

            return table;
        }

        private List<ReportLine> Construct()
        {
            var linkLabel = new Paragraph("Link");
            var coma = new Paragraph(", ");
            var firstName = new Paragraph(_parameters.User.FirstName);
            var lastName = new Paragraph(_parameters.User.LastName);

            var patientInfo = new Paragraph()
                .Add(lastName)
                .Add(coma)
                .Add(firstName);

            var label = new Paragraph("Link report");

            return new List<ReportLine>
            {
                new ReportLine(patientInfo, linkLabel),
                new ReportLine(label, new Paragraph())
            };
        }


        public Style SetHeaderStyle()
        {
            return new Style()
                .SetFontSize(14)
                .SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(0, 0, 0)))
                .SetBold()
                .SetWidth(420)
                .SetBorder(Border.NO_BORDER)
                .SetTextAlignment(TextAlignment.LEFT);
        }

        public Style SetNeurocheckStyle()
        {
            return new Style()
                .SetBold()
                .SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(0, 0, 0)))
                .SetWidth(100)
                .SetFontSize(14)
                .SetBorder(Border.NO_BORDER)
                .SetTextAlignment(TextAlignment.RIGHT);
        }
    }
}
