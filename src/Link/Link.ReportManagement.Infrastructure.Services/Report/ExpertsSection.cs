using iText.Kernel.Colors;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Link.ReportManagement.Domain.Model.Entities;
using Link.ReportManagement.Infrastructure.Models.Models;

namespace Link.ReportManagement.Infrastructure.Services.Report
{
    public class ExpertsSection
    {
        private readonly ReportParameters _parameters;

        public ExpertsSection(ReportParameters parameters)
        {
            _parameters = parameters;
        }

        public IBlockElement Render()
        {
            Div block = new Div();
            if (_parameters.Experts == null || _parameters.Experts.Count == 0)
            {
                return block;
            }

            foreach (ExpertDto expert in _parameters.Experts)
            {
                block.Add(RenderTable(expert));
            }

            return block;
        }

        private Table RenderTable(ExpertDto expert)
        {
            Table table = new Table(3)
                .SetWidth(510)
                .SetMarginLeft(18);

            table.AddHeaderCell(
                new Cell()
                    .AddStyle(SetTableDateStyle())
                    .Add(
                        new Paragraph("Experts")))
                .AddCell(
                    new Cell()
                        .AddStyle(SetLabelCellStyle())
                        .Add(new Paragraph($"{expert.FirstName} {expert.LastName}")))
                .AddCell(
                    new Cell()
                        .AddStyle(SetCheckValueStyle())
                        .Add(new Paragraph(expert.Email)))
                .AddCell(
                    new Cell()
                        .AddStyle(SetCheckEndStyle())
                        .Add(new Paragraph(expert.LinkedInUrl)));


            return table;
        }

        public Style SetTableDateStyle()
        {
            return new Style()
                .SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(0, 0, 0)))
                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                .SetHorizontalAlignment(HorizontalAlignment.LEFT)
                .SetHeight(40)
                .SetFontSize(10)
                .SetBorder(Border.NO_BORDER);
        }

        public Style SetLabelCellStyle()
        {
            return new Style()
                .SetHorizontalAlignment(HorizontalAlignment.LEFT)
                .SetFontSize(12)
                .SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(84, 88, 87)))
                .SetWidth(220)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBorder(Border.NO_BORDER)
                .SetBorderTop(new SolidBorder(Color.ConvertRgbToCmyk(new DeviceRgb(180, 182, 177)), 0.5f))
                .SetBorderBottom(new SolidBorder(Color.ConvertRgbToCmyk(new DeviceRgb(180, 182, 177)), 0.5f));
        }

        public Style SetCheckValueStyle()
        {
            return new Style()
                .SetFontSize(12)
                .SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(178, 180, 174)))
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetBorder(Border.NO_BORDER)
                .SetBorderTop(new SolidBorder(Color.ConvertRgbToCmyk(new DeviceRgb(180, 182, 177)), 0.5f))
                .SetBorderBottom(new SolidBorder(Color.ConvertRgbToCmyk(new DeviceRgb(180, 182, 177)), 0.5f));
        }

        public Style SetCheckEndStyle()
        {
            return new Style()
                .SetFontSize(12)
                .SetWidth(100)
                .SetHorizontalAlignment(HorizontalAlignment.RIGHT)
                .SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(84, 88, 87)))
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetBorder(Border.NO_BORDER)
                .SetBorderTop(new SolidBorder(Color.ConvertRgbToCmyk(new DeviceRgb(180, 182, 177)), 0.5f))
                .SetBorderBottom(new SolidBorder(Color.ConvertRgbToCmyk(new DeviceRgb(180, 182, 177)), 0.5f));
        }
    }
}
