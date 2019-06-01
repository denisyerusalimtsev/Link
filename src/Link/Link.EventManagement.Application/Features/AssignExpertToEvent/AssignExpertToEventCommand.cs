using Link.Common.Domain.Framework.Frameworks;

namespace Link.EventManagement.Application.Features.AssignExpertToEvent
{
    public sealed class AssignExpertToEventCommand : ICommand<AssignExpertToEventCommand.Reply>
    {
        public AssignExpertToEventCommand(string eventId, string expertId)
        {
            EventId = eventId;
            ExpertId = expertId;
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

        public string ExpertId { get; }
    }
}
