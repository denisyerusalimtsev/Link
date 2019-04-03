using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Domain.Model.Enums;

namespace Link.EventManagement.Application.Features.AddOrUpdateEvent
{
    public sealed class AddOrUpdateEventCommand : ICommand<AddOrUpdateEventCommand.Reply>
    {
        public AddOrUpdateEventCommand(
            EventId id, 
            UserId userId,
            string name, 
            ExpertType expertType, 
            ExpertStatus status, 
            int countOfNeededExperts)
        {
            Id = id;
            UserId = userId;
            Name = name;
            ExpertType = expertType;
            Status = status;
            CountOfNeededExperts = countOfNeededExperts;
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

        public UserId UserId { get; }

        public string Name { get; }

        public ExpertType ExpertType { get; }

        public ExpertStatus Status { get; }

        public int CountOfNeededExperts { get; }
    }
}
