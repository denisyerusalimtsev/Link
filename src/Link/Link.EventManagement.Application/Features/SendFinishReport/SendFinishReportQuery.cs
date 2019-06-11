using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Model.Entities;

namespace Link.EventManagement.Application.Features.SendFinishReport
{
    public sealed class SendFinishReportQuery : IQuery<SendFinishReportQueryResult>
    {
        public SendFinishReportQuery(EventId eventId)
        {
            EventId = eventId;
        }

        public EventId EventId { get; }
    }
}
