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

        public sealed class Reply : ICommandReply
        {
            public Reply(EventId eventId)
            {
                EventId = eventId;
            }

            public EventId EventId { get; }
        }

        public EventId EventId { get; }
    }
}
