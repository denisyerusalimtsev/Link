﻿using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Model.Entities;

namespace Link.EventManagement.Application.Features.AssignExpertToEvent
{
    public sealed class AssignExpertToEventCommand : ICommand<AssignExpertToEventCommand.Reply>
    {
        public AssignExpertToEventCommand(EventId eventId, ExpertId expertId)
        {
            EventId = eventId;
            ExpertId = expertId;
        }

        public sealed class Reply : ICommandReply
        {
            public Reply(EventId eventId, ExpertId expertId)
            {
                EventId = eventId;
                ExpertId = expertId;
            }

            public EventId EventId { get; }

            public ExpertId ExpertId { get; }
        }

        public EventId EventId { get; }

        public ExpertId ExpertId { get; }
    }
}