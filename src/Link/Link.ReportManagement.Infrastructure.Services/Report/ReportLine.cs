using iText.Layout.Element;

namespace Link.ReportManagement.Infrastructure.Services.Report
{
    /// <summary>
    ///     Single line in the report.
    /// </summary>
    public class ReportLine
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ReportLine" /> class.
        /// </summary>
        /// <param name="label">The label of paragraph.</param>
        /// <param name="value">The value of paragraph.</param>
        public ReportLine(Paragraph label, Paragraph value)
        {
            Label = label;
            Value = value;
        }

        /// <summary>
        ///     Gets or sets label
        /// </summary>
        public Paragraph Label { get; set; }

        /// <summary>
        ///     Gets or sets value
        /// </summary>
        public Paragraph Value { get; set; }
    }
}
