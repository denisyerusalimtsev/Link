using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Model.Entities;

namespace Link.EventManagement.Application.Features.DeleteEvent
{
    public sealed class DeleteEventCommand : ICommand<DeleteEventCommand.Reply>
    {
        public DeleteEventCommand(EventId id)
        {
            Id = id;
        }

        public sealed class Reply : ICommandReply
        {
            public Reply(EventId id)
            {
                Id = id;
            }

            public EventId Id { get; }
        }

        public EventId Id { get; }
    }
}
