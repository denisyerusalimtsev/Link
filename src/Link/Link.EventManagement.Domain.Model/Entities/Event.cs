using System.Collections.Generic;
using Link.Common.Domain.Framework.Models;
using Link.EventManagement.Domain.Model.Enums;
using Type = Link.EventManagement.Domain.Model.Enums.Type;

namespace Link.EventManagement.Domain.Model.Entities
{
    public class Event : AggregateRoot<EventId>
    {
        public EventId Id { get; set; }

        public string Name { get; set; }

        public Type Type { get; set; }

        public Status Status { get; set; }

        public int CountOfNeededExperts { get; set; }

        public List<Expert> Experts { get; set; }
    }
}
