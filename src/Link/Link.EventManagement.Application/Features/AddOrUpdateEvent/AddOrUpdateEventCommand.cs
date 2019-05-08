using System;
using Link.Common.Domain.Framework.Frameworks;
using Link.EventManagement.Domain.Model.Entities;
using Link.EventManagement.Domain.Model.Enums;
using System.Collections.Generic;

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
            double latitude,
            double longitude,
            DateTime startTime, 
            DateTime endTime,
            int countOfNeededExperts, 
            List<ExpertId> experts)
        {
            Id = id;
            UserId = userId;
            Name = name;
            ExpertType = expertType;
            Status = status;
            Latitude = latitude;
            Longitude = longitude;
            StartTime = startTime;
            EndTime = endTime;
            CountOfNeededExperts = countOfNeededExperts;
            Experts = experts;      
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

        public double Longitude { get; }

        public double Latitude { get; }

        public DateTime StartTime { get; }

        public DateTime EndTime { get; }

        public int CountOfNeededExperts { get; }

        public List<ExpertId> Experts { get; }
    }
}
