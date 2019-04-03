using Link.Common.Domain.Framework.Models;
using Link.EventManagement.Domain.Model.Enums;
using System.Collections.Generic;

namespace Link.EventManagement.Domain.Model.Entities
{
    public sealed class Event : AggregateRoot<EventId>
    {
        public Event(
            EventId id, 
            UserId userId,
            string name, 
            ExpertType expertType,
            ExpertStatus status, 
            int countOfNeededExperts, 
            List<Expert> experts)
        {
            Id = id;
            UserId = userId;
            Name = name;
            ExpertType = expertType;
            Status = status;
            CountOfNeededExperts = countOfNeededExperts;
            Experts = experts;
        }

        public UserId UserId { get; }

        public string Name { get; }

        public ExpertType ExpertType { get; }

        public ExpertStatus Status { get; }

        public int CountOfNeededExperts { get; }

        public List<Expert> Experts { get; }
    }
}
