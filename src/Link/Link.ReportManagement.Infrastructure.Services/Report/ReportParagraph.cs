using iText.Kernel.Colors;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Link.ReportManagement.Domain.Model.Entities;
using System.Collections.Generic;
using System.Globalization;

namespace Link.ReportManagement.Infrastructure.Services.Report
{
    public class ReportParagraph
    {
        private readonly ReportParameters _parameters;

        public ReportParagraph(ReportParameters parameters)
        {
            _parameters = parameters;
        }

        public IBlockElement Render()
        {
            List<Cell> valueCells = GetValueCells();
            List<Cell> headerCells = GetHeaderCells();
            var table = new Table(headerCells.Count);
            table.SetWidth(510);

            foreach (Cell cell in valueCells)
            {
                cell.AddStyle(SetValueNeurocheckTableStyle());
                table.AddCell(cell);
            }

            foreach (Cell cell in headerCells)
            {
                cell.AddStyle(SetHeaderNeurocheckTableStyle());
                table.AddCell(cell);
            }

            return table;
        }

        private List<Cell> GetHeaderCells()
        {
            return new List<Cell>
            {
                new Cell()
                    .Add(new Paragraph(_parameters.Event.StartTime.ToString("dddd, dd MMMM yyyy",
                        CultureInfo.InvariantCulture))),
                new Cell()
                    .Add(new Paragraph(_parameters.Event.Name)),
                new Cell()
                    .Add(new Paragraph(_parameters.Event.EndTime.ToString("dddd, dd MMMM yyyy",
                        CultureInfo.InvariantCulture))),
                new Cell()
                    .Add(new Paragraph(_parameters.Event.CountOfNeededExperts.ToString(CultureInfo.InvariantCulture)))
                    .SetBorderRight(Border.NO_BORDER)
            };
        }

        private List<Cell> GetValueCells()
        {
            return new List<Cell>
            {
                new Cell()
                    .Add(new Paragraph("Start time")),
                new Cell()
                    .Add(new Paragraph("Event")),
                new Cell()
                    .Add(new Paragraph("Finish time")),
                new Cell()
                    .Add(new Paragraph("Count of experts"))
                    .SetBorderRight(Border.NO_BORDER)
            };
        }

        public Style SetHeaderNeurocheckTableStyle()
        {
            return new Style()
                .SetBold()
                .SetFontSize(10)
                .SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(84, 88, 87)))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetPaddingLeft(20)
                .SetBorder(Border.NO_BORDER)
                .SetBorderRight(new SolidBorder(Color.ConvertRgbToCmyk(new DeviceRgb(180, 182, 177)), 0.5f))
                .SetVerticalAlignment(VerticalAlignment.TOP);
        }

        public Style SetValueNeurocheckTableStyle()
        {
            return new Style()
                .SetFontSize(14)
                .SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(84, 88, 87)))
                .SetPaddingLeft(20f)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetMarginLeft(75f)
                .SetMinWidth(75f)
                .SetBorder(Border.NO_BORDER)
                .SetBorderRight(new SolidBorder(Color.ConvertRgbToCmyk(new DeviceRgb(180, 182, 177)), 0.5f));
        }
    }
}
