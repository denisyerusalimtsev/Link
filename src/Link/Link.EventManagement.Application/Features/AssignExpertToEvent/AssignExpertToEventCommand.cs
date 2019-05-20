using System.Collections.Generic;
using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Model.Entities;

namespace Link.EventManagement.Application.Features.AssignExpertToEvent
{
    public sealed class AssignExpertToEventCommand : ICommand<AssignExpertToEventCommand.Reply>
    {
        public AssignExpertToEventCommand(EventId eventId, List<ExpertId> expertsId)
        {
            EventId = eventId;
            ExpertsId = expertsId;
        }

        public sealed class Reply : ICommandReply
        {
            public Reply(EventId eventId, HashSet<ExpertId> expertsId)
            {
                EventId = eventId;
                ExpertsId = expertsId;
            }

            public EventId EventId { get; }

            public HashSet<ExpertId> ExpertsId { get; }
        }

        public EventId EventId { get; }

        public List<ExpertId> ExpertsId { get; }
    }
}
