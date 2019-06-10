using Link.Common.Domain.Framework.Frameworks;

namespace Link.EventManagement.Application.Features.FinishEvent
{
    public class FinishEventCommand : ICommand<FinishEventCommand.Reply>
    {
        public FinishEventCommand(string eventId)
        {
            EventId = eventId;
        }

        public sealed class Reply : ICommandReply
        {
            public Reply(string id)
            {
                Id = id;
            }

            public string Id { get; }
        }

        public string EventId { get; }
    }
}
