using Link.Common.Domain.Framework.Models;
using Link.EventManagement.Domain.Model.Enums;
using MongoDB.Bson.Serialization.Attributes;
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

        [BsonElement("userId")]
        public UserId UserId { get; }

        [BsonElement("name")]
        public string Name { get; }

        [BsonElement("expertType")]
        public ExpertType ExpertType { get; }

        [BsonElement("status")]
        public ExpertStatus Status { get; }

        [BsonElement("countOfNeededExperts")]
        public int CountOfNeededExperts { get; }

        [BsonElement("experts")]
        public List<Expert> Experts { get; }
    }
}
