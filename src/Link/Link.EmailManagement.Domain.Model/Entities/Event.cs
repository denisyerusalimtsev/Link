using System.Collections.Generic;
using Link.Common.Domain.Framework.Models;
using Link.EmailManagement.Domain.Model.Enums;

namespace Link.EmailManagement.Domain.Model.Entities
{
    public sealed class Event : Entity<EventId>
    {
        public Event(
            EventId id, 
            UserId userId,
            string name, 
            ExpertType expertType,
            ExpertStatus status, 
            int countOfNeededExperts, 
            List<ExpertId> experts, double latitude, double longitude)
        {
            Id = id;
            UserId = userId;
            Name = name;
            ExpertType = expertType;
            Status = status;
            Latitude = latitude;
            Longitude = longitude;
            CountOfNeededExperts = countOfNeededExperts;          
            Experts = new HashSet<ExpertId>(experts);
        }

        public UserId UserId { get; }

        public string Name { get; }

        public ExpertType ExpertType { get; }

        public ExpertStatus Status { get; }

        public double Latitude { get; }

        public double Longitude { get; }

        public int CountOfNeededExperts { get; }

        public HashSet<ExpertId> Experts { get; }
    }
}
