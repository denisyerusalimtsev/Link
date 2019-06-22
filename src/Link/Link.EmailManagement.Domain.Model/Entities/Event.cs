using Link.Common.Domain.Framework.Models;
using Link.EmailManagement.Domain.Model.Enums;
using System;

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
            double latitude, 
            double longitude,
            DateTime startTime,
            DateTime? endTime,
            int countOfNeededExperts)
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
        }

        public UserId UserId { get; }

        public string Name { get; }

        public ExpertType ExpertType { get; }

        public ExpertStatus Status { get; }

        public double Latitude { get; }

        public double Longitude { get; }

        public DateTime StartTime { get; }

        public DateTime? EndTime { get; }

        public int CountOfNeededExperts { get; }
    }
}
