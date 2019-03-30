using Link.Common.Domain.Framework.Models;
using Link.EventManagement.Domain.Model.Enums;
using System.Collections.Generic;
using Type = Link.EventManagement.Domain.Model.Enums.Type;

namespace Link.EventManagement.Domain.Model.Entities
{
    public sealed class Event : AggregateRoot<EventId>
    {
        public Event(
            EventId id, 
            UserId userId,
            string name, 
            Type type,
            Status status, 
            int countOfNeededExperts, 
            List<Expert> experts)
        {
            Id = id;
            UserId = userId;
            Name = name;
            Type = type;
            Status = status;
            CountOfNeededExperts = countOfNeededExperts;
            Experts = experts;
        }

        public UserId UserId { get; }

        public string Name { get; }

        public Type Type { get; }

        public Status Status { get; }

        public int CountOfNeededExperts { get; }

        public List<Expert> Experts { get; }
    }
}
